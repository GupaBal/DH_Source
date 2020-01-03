using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Apros_Class_Library_Base;
using System.IO.Ports;
using DevComponents.DotNetBar.Controls;

namespace APROS_Serial_Utility
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.01 / 2017-07-24 ] ///
    /// ▷ CommPanelAT : UserControl ◁                                                                             ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2017-05-31 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2017-07-24 ]                                                                                   ///
    ///     ▶ 통신 종료 기능 추가                                                                                  ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class CommPanelAT : UserControl
    {
        // 식별 이름
        private string ControlName = string.Empty;

        // 에러 로그 관련 변수
        private readonly string ErrorPath = CommonBase.ErrorPath;
        private readonly string ErrorName = CommonBase.ErrorLogName;

        // 통신 모드 설정 변수
        private bool Serial_Mode = true;
        private bool AutoFeedLine = false;
        private bool SendViewMode = false;
        private bool TimeViewMode = false;
        private bool Server_Mode = false;

        // 데이터 저장 관련 변수
        private string FPath = CommonBase.DataPath;
        private string FName = string.Empty;

        // 데이터 임시 보관 변수
        private string TmpString = string.Empty;
        private byte[] TmpBuffer;

        // 이더넷 통신 객체
        private TCP_Comm_Server Server;
        private TCP_Comm_Manager Client;

        // 데이터 패킷 관련 변수
        private List<byte[]> Packets;
        private byte[] Send_Buffer;

        // 델리게이트 함수
        private delegate void appendTextBox(TextBoxX tb, string msg);

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ CommPanelAT @                                                                                         ///
        ///     생성자로 컨트롤을 초기화하며 매개변수로 데이터를 저장할 파일 이름을 전달한다.                       ///
        /// </summary>                                                                                              ///
        /// <param name="fName"> string : 데이터 파일 이름 </param>                                                 ///
        ///=========================================================================================================///
        public CommPanelAT(string fName)
        {
            InitializeComponent();

            FName = fName;
            ControlName = fName;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ CommPanel_Load @                                                                                      ///
        ///     생성자로 컨트롤을 초기화한다.                                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void CommPanel_Load(object sender, EventArgs e)
        {
            FileManager.MakePath(Application.StartupPath);

            TCP_Comm_Server.SetLogMsg += TCP_Comm_Server_SetLogMsg;

            TCP_Comm_Manager.DisConnecting += TCP_Comm_Manager_DisConnecting;
            TCP_Comm_Manager.NotifyData += TCP_Comm_Manager_NotifyData;
            TCP_Comm_Manager.NotifyDisconnect += TCP_Comm_Manager_NotifyDisconnect;
            TCP_Comm_Manager.NotifyMsg += TCP_Comm_Manager_NotifyMsg;

            Packets = new List<byte[]>();

            foreach (string portname in SerialPort.GetPortNames())
                m_cb_portname.Items.Add(portname);

            foreach (string stopbits in Enum.GetNames(typeof(StopBits)))
                m_cb_stopbits.Items.Add(stopbits);

            foreach (string handshake in Enum.GetNames(typeof(Handshake)))
                m_cb_flowtype.Items.Add(handshake);

            m_cb_baudrate.SelectedIndex = 0;
            m_cb_databits.SelectedIndex = 3;
            m_cb_parity.SelectedIndex = 0;
            m_cb_stopbits.SelectedIndex = 1;
            m_cb_flowtype.SelectedIndex = 0;

            m_txb_savepath.Text = FPath;

            m_ckb_CheckedChanged(m_ckb_autofeedline, e);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ TCP_Comm_Manager_NotifyMsg @                                                                          ///
        ///     Not Used                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="port"> int : TCP 포트 번호 </param>                                                        ///
        /// <param name="msg"> string : 메시지 </param>                                                             ///
        ///=========================================================================================================///
        private void TCP_Comm_Manager_NotifyMsg(int port, string msg)
        {
            // Not USed
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ TCP_Comm_Manager_NotifyDisconnect @                                                                   ///
        ///     Not Used                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="port"> int : TCP 포트 번호 </param>                                                        ///
        ///=========================================================================================================///
        private void TCP_Comm_Manager_NotifyDisconnect(int port)
        {
            // Not USed
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ TCP_Comm_Manager_NotifyData @                                                                         ///
        ///     Not Used                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="port"> int : TCP 포트 번호 </param>                                                        ///
        /// <param name="buff"> byte[] : 수신 데이터 </param>                                                       ///
        ///=========================================================================================================///
        private void TCP_Comm_Manager_NotifyData(int port, byte[] buff)
        {
            // Not USed
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ TCP_Comm_Manager_DisConnecting @                                                                      ///
        ///     Not Used                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="ip"> string : 원격지 접속 IP 주소 </param>                                                 ///
        /// <param name="port"> int : TCP 포트 번호 </param>                                                        ///
        ///=========================================================================================================///
        private void TCP_Comm_Manager_DisConnecting(string ip, int port)
        {
            // Not USed
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ TCP_Comm_Server_SetLogMsg @                                                                           ///
        ///     Not Used                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="port"> int : TCP 포트 번호 </param>                                                        ///
        /// <param name="msg"> string : 메시지 </param>                                                             ///
        ///=========================================================================================================///
        private void TCP_Comm_Server_SetLogMsg(int port, string msg)
        {
            // Not USed
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_btn_Click @                                                                                         ///
        ///     버튼 클릭 시 해당 버튼의 작업을 수행한다.                                                           ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_Click(object sender, EventArgs e)
        {
            if (sender == m_btn_open)
            {
                if (m_btn_open.Text.Equals("Open") == true)
                {
                    if (m_btn_open.Text.Equals("Open") == true)
                    {
                        if (Serial_Mode == true)
                        {
                            try
                            {
                                if (serialPort.IsOpen == true)
                                    serialPort.Close();

                                RS232_Setter.SetPortname(serialPort, m_cb_portname.Text);
                                RS232_Setter.SetBaudrate(serialPort, m_cb_baudrate.Text);
                                RS232_Setter.SetDatabits(serialPort, m_cb_databits.Text);
                                RS232_Setter.SetParity(serialPort, m_cb_parity.Text);
                                RS232_Setter.SetStopBits(serialPort, m_cb_stopbits.Text);
                                RS232_Setter.SetHandShake(serialPort, m_cb_flowtype.Text);

                                serialPort.Open();

                                AppendTextBox(m_txb_recv, " * Serial Port " + m_cb_portname.Text + " Opened!!" + Environment.NewLine);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);

                                FileManager.LogWriter(ex.Message, ErrorPath, ErrorName, true, true, true, true, true);
                            }
                        }
                        else
                        {
                            int port = Convert.ToInt32(m_txb_portnum.Text);

                            if (Server_Mode == true)
                            {
                                Server = new TCP_Comm_Server(port, 1);
                                Server.SetTCMType("P");
                                Server.ServerStart();

                                AppendTextBox(m_txb_recv, " * Server " + m_txb_portnum.Text + " Started!!" + Environment.NewLine);
                            }
                            else
                            {
                                Client = new TCP_Comm_Manager(ipAddressInput1.Text, port);
                                Client.SetTCMType("P");
                                Client.Connect();

                                AppendTextBox(m_txb_recv, " * Client " + m_cb_portname.Text + " " + Client.GetConntected() + Environment.NewLine);
                            }

                            timer_getter.Start();
                        }

                        m_btn_open.Text = "Close";
                    }
                    else
                    {
                        if (Serial_Mode == true)
                        {
                            try
                            {
                                serialPort.Close();
                                AppendTextBox(m_txb_recv, " * Serial Port " + m_cb_portname.Text + " Closed!!" + Environment.NewLine);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);

                                FileManager.LogWriter(ex.Message, ErrorPath, ErrorName, true, true, true, true, true);
                            }

                        }
                        else
                        {
                            if (Server_Mode == true)
                            {
                                Server.ServerStop();
                                AppendTextBox(m_txb_recv, " * Server " + m_txb_portnum.Text + " Stopped!!" + Environment.NewLine);
                            }
                            else
                            {
                                Client.Close();

                                AppendTextBox(m_txb_recv, " * Client " + m_cb_portname.Text + " " + Client.GetConntected() + Environment.NewLine);
                            }

                            timer_getter.Stop();
                        }

                        m_btn_open.Text = "Open";
                    }
                }
                else
                {
                    if (Serial_Mode == true)
                    {

                        try
                        {
                            serialPort.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                            FileManager.LogWriter(ex.Message, ErrorPath, ErrorName, true, true, true, true, true);
                        }

                        m_btn_open.Text = "Open";
                    }
                    else
                    {
                        if (Server_Mode == true)
                        {
                            Server.ServerStop();
                        }
                        else
                        {
                            Client.Close();
                        }
                    }
                }
            }
            else if (sender == m_btn_recvclear)
            {
                m_txb_recv.Text = string.Empty;
            }
            else if (sender == m_btn_sendclear)
            {
                m_txb_send.Text = string.Empty;
            }
            else if (sender == m_btn_send)
            {
                if (Send() == false)
                {
                    m_txb_recv.AppendText(" * Send Failed!! ");
                }
                else
                {
                    if (SendViewMode == true)
                    {
                        AppendText(m_txb_send.Text);
                    }
                }
            }
            else if (sender == m_btn_path_setup)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    m_txb_savepath.Text = fbd.SelectedPath;
                    FPath = fbd.SelectedPath;
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_rbtn_serial_CheckedChanged @                                                                        ///
        ///     통신 방식 설정에 따라 해당 속성의 설정 여부를 변경한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_rbtn_serial_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == m_rbtn_serial)
            {
                m_cb_portname.Enabled = true;
                m_cb_baudrate.Enabled = true;
                m_cb_databits.Enabled = true;
                m_cb_parity.Enabled = true;
                m_cb_stopbits.Enabled = true;
                m_cb_flowtype.Enabled = true;

                m_ckb_Server.Enabled = false;
                ipAddressInput1.Enabled = false;
                m_txb_portnum.Enabled = false;

                Serial_Mode = true;
            }
            else if (sender == m_rbtn_tcp)
            {
                m_cb_portname.Enabled = false;
                m_cb_baudrate.Enabled = false;
                m_cb_databits.Enabled = false;
                m_cb_parity.Enabled = false;
                m_cb_stopbits.Enabled = false;
                m_cb_flowtype.Enabled = false;

                m_ckb_Server.Enabled = true;
                ipAddressInput1.Enabled = true;
                m_txb_portnum.Enabled = true;

                Serial_Mode = false;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_rbtn_sendT_CheckedChanged @                                                                         ///
        ///     데이터 전송 방식에 따라 입력된 데이터를 변환한다.                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_rbtn_sendT_CheckedChanged(object sender, EventArgs e)
        {
            TmpString = m_txb_send.Text;

            if (sender == m_rbtn_sendT)
            {
                if (m_rbtn_sendT.Checked == true)
                {
                    TmpBuffer = CommonBase.HexStringToByteArray(TmpString);
                    m_txb_send.Text = Encoding.Default.GetString(TmpBuffer);
                }
            }
            else if (sender == m_rbtn_sendH)
            {
                if (m_rbtn_sendH.Checked == true)
                {
                    TmpBuffer = Encoding.UTF8.GetBytes(TmpString);
                    m_txb_send.Text = CommonBase.Hex2Str16(TmpBuffer, TmpBuffer.Length);
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_ckb_CheckedChanged @                                                                                ///
        ///     화면 표시 속성이나 주기 반복 전송을 설정한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_ckb_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == m_ckb_autofeedline)
            {
                AutoFeedLine = m_ckb_autofeedline.Checked;
            }
            else if (sender == m_ckb_displaySend)
            {
                SendViewMode = m_ckb_displaySend.Checked;
            }
            else if (sender == m_ckb_dispalyTime)
            {
                TimeViewMode = m_ckb_dispalyTime.Checked;
            }
            else if (sender == m_ckb_Server)
            {
                if (m_ckb_Server.Checked == true)
                {
                    ipAddressInput1.Enabled = false;
                    Server_Mode = true;
                }
                else
                {
                    ipAddressInput1.Enabled = true;
                    Server_Mode = false;
                }
            }
            else if (sender == m_ckb_sendLoop)
            {
                if (m_ckb_sendLoop.Checked == true)
                {
                    timer_loop.Interval = Convert.ToInt32(m_txb_loop.Text);
                    timer_loop.Start();
                }
                else
                {
                    timer_loop.Stop();
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_txb_KeyPress @                                                                                      ///
        ///     텍스트박스에 숫자만 입력 가능하도록 제한한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> KeyPressEventArgs : 이벤트 관련 정보 </param>                                          ///
        ///=========================================================================================================///
        private void m_txb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != '\b')) e.Handled = true;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_cb_SelectedIndexChanged @                                                                           ///
        ///     콤보박스에서 선택한 항목의 AT 커맨드를 설정한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = ((ComboBoxEx)sender).SelectedIndex;
            string cmd = string.Empty;

            if (sender == m_cb_GetCommand)
            {
                switch(idx)
                {
                    case 0: cmd = "AT+GFWVER";      break;
                    case 1: cmd = "AT+GDEVEUI";     break;
                    case 2: cmd = "AT+GAPPEUI";     break;
                    case 3: cmd = "AT+GAPKEY";      break;
                    case 4: cmd = "AT+GPKTRSSI";    break;
                    case 5: cmd = "AT+GSNR";        break;
                    case 6: cmd = "AT+GDR";         break;
                    case 7: cmd = "AT+GTXPWR";      break;
                    case 8: cmd = "AT+GADR";        break;
                    case 9: cmd = "AT+GCLASS";      break;
                    case 10: cmd = "AT+GTXREP";     break;
                    case 11: cmd = "AT+GTXPTIIME";  break;
                    case 12: cmd = "AT+GTXUNREP";   break;
                    case 13: cmd = "AT+GREPIMMD=";  break;
                    case 14: cmd = "AT+GDBGON";     break;
                    default: break;
                }
            }
            else if (sender == m_cb_SetCommand)
            {
                switch (idx)
                {
                    case 0: cmd = "AT+*#HSDEUI=";   break;
                    case 1: cmd = "AT+SAPPEUI=";    break;
                    case 2: cmd = "AT+SAPKEY=";     break;
                    case 3: cmd = "AT+SADR=";       break;
                    case 4: cmd = "AT+SSF=";        break;
                    case 5: cmd = "AT+STXPWR=";     break;
                    case 6: cmd = "AT+SCLASS=";     break;
                    case 7: cmd = "AT+SMSGTYPE=";   break;
                    case 8: cmd = "AT+STXREP=";     break;
                    case 9: cmd = "AT+STXPTIIME=";  break;
                    case 10: cmd = "AT+SPARAMRESET"; break;
                    case 11: cmd = "AT+SDIVRESET";  break;
                    case 12: cmd = "AT+SANTGAIN=";  break;
                    case 13: cmd = "AT+SREPORT=";   break;
                    case 14: cmd = "AT+SSF=";       break;
                    case 15: cmd = "AT+STXUNREP=";  break;
                    case 16: cmd = "AT+SCHTXPOWER="; break;
                    case 17: cmd = "AT+SREPIMMD=";  break;
                    case 18: cmd = "AT+SDBGON=1";   break;
                    default: break;
                }
            }
            else if (sender == m_cb_ETCCommand)
            {
                switch (idx)
                {
                    case 0: cmd = "AT+IJOIN";       break;
                    case 1: cmd = "AT+SVPARAM";     break;
                    case 2: cmd = "AT+STXDATA=";    break;
                    case 3: cmd = "AT+SMACLINK";    break;
                    case 4: cmd = "AT+STXDATA=";    break;
                    default: break;
                }
            }

            m_txb_send.Text = cmd + Environment.NewLine;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ serialPort_DataReceived @                                                                             ///
        ///     시리얼 포트로 수신된 데이터를 화면에 표출한다.                                                      ///
        ///     (string 처리를 위해 null은 공백으로 0x0a는 CR+LF로 대체)                                            ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> SerialDataReceivedEventArgs : 이벤트 관련 정보 </param>                                ///
        ///=========================================================================================================///
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] tmp = new byte[serialPort.BytesToRead];
            serialPort.Read(tmp, 0, tmp.Length);

            TmpString = string.Empty;

            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == 0x00)
                {
                    TmpString += string.Empty;
                }
                else if (tmp[i] == 0x0a)
                {
                    TmpString += Environment.NewLine;
                }
                else
                {
                    TmpString += Convert.ToChar(tmp[i]);
                }
            }

            AppendText(TmpString);

            FileManager.LogWriter(TmpString, FPath, FName, false, false, false, false, true);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ timer_loop_Tick @                                                                                     ///
        ///     지정된 주기마다 데이터 전송 함수를 호출한다.                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void timer_loop_Tick(object sender, EventArgs e)
        {
            if (Send() == false)
            {
                m_txb_recv.AppendText(" * Send Failed!! ");
            }
            else
            {
                if (SendViewMode == true)
                {
                    AppendText(m_txb_send.Text);
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ timer_getter_Tick @                                                                                   ///
        ///     이더넷 통신 모드일 경우 주기적으로 통신 객체로부터 데이터를 처리한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void timer_getter_Tick(object sender, EventArgs e)
        {
            if (Server_Mode == true)
            {
                foreach (TCP_Comm_Manager tcm in Server.GetClients())
                {
                    Packets = tcm.GetPackets();

                    foreach (byte[] packet in Packets)
                    {
                        TmpString = tcm.GetRemoteIP() + "(" + tcm.GetRemotePort() + ") : " + CommonBase.Hex2Str16(packet, packet.Length);

                        AppendText(TmpString);

                        FileManager.LogWriter(TmpString, FPath, FName, false, false, false, false, true);
                    }
                }
            }
            else
            {
                Packets = Client.GetPackets();

                foreach (byte[] packet in Packets)
                {
                    TmpString = Client.GetRemoteIP() + "(" + Client.GetRemotePort() + ") : " + CommonBase.Hex2Str16(packet, packet.Length);

                    AppendText(TmpString);

                    FileManager.LogWriter(TmpString, FPath, FName, false, false, false, false, true);
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ Send @                                                                                                ///
        ///     입력된 데이터를 전송한다.                                                                           ///
        /// </summary>                                                                                              ///
        /// <returns> bool : 전송 여부 </returns>                                                                   ///
        ///=========================================================================================================///
        private bool Send()
        {
            try
            {
                if (m_rbtn_sendH.Checked == true)
                {
                    TmpString = Encoding.Default.GetString(CommonBase.HexStringToByteArray(m_txb_send.Text));
                }
                else
                {
                    TmpString = m_txb_send.Text;
                }

                Send_Buffer = Encoding.UTF8.GetBytes(TmpString);

                if (Serial_Mode == true)
                {
                    serialPort.Write(Send_Buffer, 0, Send_Buffer.Length);
                }
                else
                {
                    if (Server_Mode == true)
                    {
                        foreach (TCP_Comm_Manager tcm in Server.GetClients())
                        {
                            tcm.Send(Send_Buffer);
                        }
                    }
                    else
                    {
                        Client.Send(Send_Buffer);
                    }
                }

                //m_cb_GetCommand.Items.Add(TmpString);

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                FileManager.LogWriter(e.Message, ErrorPath, ErrorName, true, true, true, true, true);

                return false;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ AppendText @                                                                                          ///
        ///     텍스트박스에 매개변수로 전달된 내용을 추가한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="Text"> string : 추가 내용 </param>                                                         ///
        ///=========================================================================================================///
        private void AppendText(string Text)
        {
            if (TimeViewMode == true)
            {
                AppendTextBox(m_txb_recv, DateTime.Now.ToLongTimeString() + " - ");
            }

            if (m_rbtn_recvT.Checked == true)
            {
                AppendTextBox(m_txb_recv, Text);
            }
            else
            {
                TmpBuffer = Encoding.UTF8.GetBytes(Text);
                AppendTextBox(m_txb_recv, CommonBase.Hex2Str16(TmpBuffer, TmpBuffer.Length));
            }

            if (AutoFeedLine == true)
            {
                AppendTextBox(m_txb_recv, Environment.NewLine);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ AppendTextBox @                                                                                       ///
        ///     지정된 텍스트박스에 매개변수로 전달된 내용을 추가하는 델리게이트 함수이다.                          ///
        /// </summary>                                                                                              ///
        /// <param name="tb"> TextBoxX : 추가 대상 객체 </param>                                                    ///
        /// <param name="msg"> string : 추가 내용 </param>                                                          ///
        ///=========================================================================================================///
        private void AppendTextBox(TextBoxX tb, string msg)
        {
            if (tb.InvokeRequired == true)
            {
                tb.Invoke(new appendTextBox(AppendTextBox), tb, msg);
            }
            else
            {
                tb.AppendText(msg);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ SetFName @                                                                                            ///
        ///     파일 저장 경로와 이름을 설정한다.                                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="path"> string : 파일 저장 경로 </param>                                                    ///
        /// <param name="name"> string : 파일명 </param>                                                            ///
        ///=========================================================================================================///
        public void SetFName(string path, string name)
        {
            FPath = path;
            FName = name;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-06-08 ] ///
        /// @ SetControlName @                                                                                      ///
        ///     컨트롤 식별용 이름을 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="name"> string : 식별 이름 </param>                                                         ///
        ///=========================================================================================================///
        public void SetControlName(string name)
        {
            ControlName = name;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-06-08 ] ///
        /// @ GetControlName @                                                                                      ///
        ///     컨트롤 식별용 이름을 반환한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <returns> string : 식별 이름 </returns>                                                                 ///
        ///=========================================================================================================///
        public string GetControlName()
        {
            return ControlName;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-06-08 ] ///
        /// @ SaveConfig @                                                                                          ///
        ///     컨트롤의 사용자 설정 환경을 작성하여 반환한다.                                                      ///
        /// </summary>                                                                                              ///
        /// <returns> string : 사용자 설정 환경 </returns>                                                          ///
        ///=========================================================================================================///
        public string SaveConfig()
        {
            string comm = string.Empty;

            if (m_rbtn_serial.Checked == true)
            {
                comm = "Serial:";
                comm += (m_cb_portname.SelectedIndex + ",");
                comm += (m_cb_baudrate.SelectedIndex + ",");
                comm += (m_cb_databits.SelectedIndex + ",");
                comm += (m_cb_parity.SelectedIndex + ",");
                comm += (m_cb_stopbits.SelectedIndex + ",");
                comm += m_cb_flowtype.SelectedIndex;
            }
            else
            {
                comm = "Ethernet:";
                comm += (Convert.ToInt16(m_ckb_Server.Checked) + ",");
                comm += (ipAddressInput1.Value + ",");
                comm += m_txb_portnum.Text;
            }

            string recv = "Recv Setting:";

            if (m_rbtn_recvT.Checked == true)
            {
                recv += "T,";
            }
            else
            {
                recv += "H,";
            }

            recv += (Convert.ToInt16(m_ckb_autofeedline.Checked) + ",");
            recv += (Convert.ToInt16(m_ckb_displaySend.Checked) + ",");
            recv += (Convert.ToInt16(m_ckb_dispalyTime.Checked) + ",");

            string send = "Send Setting:";

            if (m_rbtn_sendT.Checked == true)
            {
                send += "T,";
            }
            else
            {
                send += "H,";
            }

            if (m_ckb_sendLoop.Checked == true)
            {
                send += ("T," + m_txb_loop.Text);
            }
            else
            {
                send += "F";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("[" + GetControlName() + "]");
            sb.AppendLine(comm);
            sb.AppendLine(recv);
            sb.AppendLine(send);
            sb.AppendLine("Save Path:" + m_txb_savepath.Text);

            return sb.ToString();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-06-08 ] ///
        /// @ SetConfig @                                                                                           ///
        ///     매개변수로 전달된 사용자 환경을 설정한다.                                                           ///
        /// </summary>                                                                                              ///
        /// <param name="values"> object[] : 사용자 환경 </param>                                                   ///
        ///=========================================================================================================///
        public void SetConfig(string data)
        {
            string[] values = data.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < values.Length; i++)
            {
                string[] sub = ((string)values[i]).Split(new char[] { ':', ',' });

                switch (sub[0])
                {
                    case "Serial":
                        m_rbtn_serial.Checked = true;
                        m_cb_portname.SelectedIndex = Convert.ToInt32(sub[1]);
                        m_cb_baudrate.SelectedIndex = Convert.ToInt32(sub[2]);
                        m_cb_databits.SelectedIndex = Convert.ToInt32(sub[3]);
                        m_cb_parity.SelectedIndex = Convert.ToInt32(sub[4]);
                        m_cb_stopbits.SelectedIndex = Convert.ToInt32(sub[5]);
                        m_cb_flowtype.SelectedIndex = Convert.ToInt32(sub[6]);
                        break;
                    case "Ethernet":
                        m_rbtn_tcp.Checked = true;
                        m_ckb_Server.Checked = Convert.ToBoolean(Convert.ToInt32(sub[1]));
                        ipAddressInput1.Value = sub[2];
                        m_txb_portnum.Text = sub[3];
                        break;
                    case "Recv Setting":
                        if (sub[1].Equals("T") == true)
                        {
                            m_rbtn_recvT.Checked = true;
                        }
                        else
                        {
                            m_rbtn_recvH.Checked = true;
                        }

                        m_ckb_autofeedline.Checked = Convert.ToBoolean(Convert.ToInt32(sub[2]));
                        m_ckb_displaySend.Checked = Convert.ToBoolean(Convert.ToInt32(sub[3]));
                        m_ckb_dispalyTime.Checked = Convert.ToBoolean(Convert.ToInt32(sub[4]));
                        break;
                    case "Send Setting":
                        if (sub[1].Equals("T") == true)
                        {
                            m_rbtn_sendT.Checked = true;
                        }
                        else
                        {
                            m_rbtn_sendH.Checked = true;
                        }

                        if (sub[2].Equals("1") == true)
                        {
                            m_ckb_sendLoop.Checked = true;
                            m_txb_loop.Text = sub[3];
                        }
                        break;
                    case "Save Path":
                        m_txb_savepath.Text = sub[1];
                        break;
                    default: break;
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2017-07-24 ] ///
        /// @ Close @                                                                                               ///
        ///     통신 객체들의 동작을 중단하고 초기화한다.                                                           ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void Close()
        {
            if (Server != null)
            {
                Server.DisconnectAll();
                Server.ServerStop();
            }

            if (Client != null)
            {
                Client.Close();
            }

            if (serialPort.IsOpen == true)
            {
                serialPort.Close();
            }
        }
    }
    ///================================================================================ End of Class : CommPanelAT =///
}
