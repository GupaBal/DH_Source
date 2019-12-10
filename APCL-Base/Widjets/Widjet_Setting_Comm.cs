using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.11 / 2019-01-16 ] ///
    /// ▷ Widjet_Setting_Comm : UserControl ◁                                                                     ///
    ///     시리얼 / 이더넷 통신 설정을 지원하는 위젯 형태의 UI 컨트롤이다.                                         ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-03-28 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2017-06-12 ]                                                                                   ///
    ///     ▶ 사용자 환경 저장 / 로드                                                                              ///
    /// [ Ver 1.02 / 2017-06-22 ]                                                                                   ///
    ///     ▶ 이더넷 통신 데이터 처리                                                                              ///
    /// [ Ver 1.03 / 2017-07-10 ]                                                                                   ///
    ///     ▶ 통신 연결 상태 조회                                                                                  ///
    /// [ Ver 1.04 / 2017-07-17 ]                                                                                   ///
    ///     ▶ 시리얼 포트 데이터 처리 최소 기준 설정                                                               ///
    /// [ Ver 1.05 / 2017-07-24 ]                                                                                   ///
    ///     ▶ 통신 종료 기능 추가                                                                                  ///
    /// [ Ver 1.06 / 2018-03-26 ]                                                                                   ///
    ///     ▶ 외부에서 통신 시작 요청 추가                                                                         ///
    /// [ Ver 1.07 / 2018-04-06 ]                                                                                   ///
    ///     ▶ 시리얼 통신 속성 변경 지원 함수 추가                                                                 ///
    /// [ Ver 1.08 / 2018-09-19 ]                                                                                   ///
    ///     ▶ 시리얼 포트의 수신 데이터를 문자열로 반환 함수 추가                                                  ///
    /// [ Ver 1.09 / 2018-09-20 ]                                                                                   ///
    ///     ▶ 데이터 패킷 길이 제한 설정 함수 추가                                                                 ///
    /// [ Ver 1.10 / 2018-10-17 ]                                                                                   ///
    ///     ▶ 통신 설정 옵션의 활성화 여부 설정 함수 추가                                                          ///
    /// [ Ver 1.11 / 2019-01-16 ]                                                                                   ///
    ///     ▶ 스레드 동작 관련 제어 기능 추가                                                                      ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class Widjet_Setting_Comm : UserControl
    {
        #region [ # Defines & Variables ]
        // TCP 통신 객체
        private TCP_Comm_Server Server;
        private TCP_Comm_Manager Client;

        // 데이터 저장 버퍼
        bool PackA_On = true;
        private List<byte[]> Packets_A;
        private List<byte[]> Packets_B;
        bool TimeLabel = true;
        private List<DateTime> Times_A;
        private List<DateTime> Times_B;
        bool isArray = false;
        private StringBuilder SB_Lines;
        private List<string> DataLines;

        // 데이터 처리 모드
        private string TCM_Type = "P";
        private bool Readline = false;

        // 통신 상태 메시지
        private string Conn_Result = string.Empty;

        // 사용자 정의 이벤트
        public static event SetLogHandler SendMsg;
        public delegate void SetLogHandler(object sender, string msg);

        // Parsing되지 않은 Packet 부분 저장 버퍼
        private byte[] remain = new byte[0];

        // Packet 구성 정보
        private byte STX = 0x40;
        private byte ETX = 0x7D;
        private int Limit_Len = 100;

        // 시리얼 통신 속성
        private int[] Serial_Option = { 0, 3, 0, 1, 0 };

        // 시리얼 통신 설정 데이터
        private static string[] baudrates = { "9600", "19200", "28800", "38400", "57600", "115200", "230400", "460800" };
        private static string[] databits = { "5", "6", "7", "8" };
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ Widjet_Setting_Comm @                                                                                 ///
        ///     생성자로 컨트롤을 초기화한다.                                                                       ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public Widjet_Setting_Comm()
        {
            InitializeComponent();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ Widjet_Setting_Comm_Load @                                                                            ///
        ///     폼 생성 후 로드되는 시점에 호출되는 이벤트 핸들러 초기 작업을 수행한다.                             ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void Widjet_Setting_Comm_Load(object sender, EventArgs e)
        {
            Packets_A = new List<byte[]>();
            Packets_B = new List<byte[]>();

            Times_A = new List<DateTime>();
            Times_B = new List<DateTime>();

            SB_Lines = new StringBuilder();
            DataLines = new List<string>();

            TCP_Comm_Server.SetLogMsg += TCP_Comm_Server_SetLogMsg;

            TCP_Comm_Manager.DisConnecting    += TCP_Comm_Manager_DisConnecting;
            TCP_Comm_Manager.NotifyData       += TCP_Comm_Manager_NotifyData;
            TCP_Comm_Manager.NotifyDisconnect += TCP_Comm_Manager_NotifyDisconnect;
            TCP_Comm_Manager.NotifyMsg        += TCP_Comm_Manager_NotifyMsg;

            InitSerialInfo();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ CommConnect @                                                                                         ///
        ///     통신 연결을 시도하며 그 결과를 반환한다.                                                            ///
        /// </summary>                                                                                              ///
        /// <returns> string : 통신 연결 결과 </returns>                                                            ///
        ///=========================================================================================================///
        public string CommConnect()
        {
            if (m_rbtn_serial.Checked == true)
            {
                try
                {
                    if (serialPort.IsOpen == true)
                    {
                        serialPort.Close();
                    }

                    RS232_Setter.SetPortname(serialPort, m_cb_portname.Text);
                    RS232_Setter.SetBaudrate(serialPort, m_cb_baudrate.Text);
                    RS232_Setter.SetDatabits(serialPort, m_cb_databits.Text);
                    RS232_Setter.SetParity(serialPort, m_cb_parity.Text);
                    RS232_Setter.SetStopBits(serialPort, m_cb_stopbits.Text);
                    RS232_Setter.SetHandShake(serialPort, m_cb_flowtype.Text);

                    serialPort.Open();

                    return (" * Serial Port " + m_cb_portname.Text + " Opened!!" + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine);

                    return ex.Message;
                }
            }
            else
            {
                int port = Convert.ToInt32(m_txb_portnum.Text);

                if (m_rbtn_tcp_server.Checked == true)
                {
                    Server = new TCP_Comm_Server(port, 10);
                    Server.SetTCMType(TCM_Type);

                    return (" * Server Port (" + port + ") Start : " + Server.ServerStart().ToString() + Environment.NewLine);
                }
                else
                {
                    Client = new TCP_Comm_Manager(ipAddressInput1.Text, port, TCM_Type);

                    return (" * Client IsConnected to (" + ipAddressInput1.Text + ":" + port + ") :" 
                        + Client.GetConntected() + Environment.NewLine);
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ CommDisconnect @                                                                                      ///
        ///     연결된 통신을 종료하고 그 결과를 반환한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <returns> string : 통신 종료 결과 </returns>                                                            ///
        ///=========================================================================================================///
        public string CommDisconnect()
        {
            if (m_rbtn_serial.Checked == true)
            {
                try
                {
                    serialPort.Close();

                    return (" * Serial Port " + serialPort.PortName + " Closed" + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine);

                    return ex.Message;
                }
            }
            else
            {
                int port = Convert.ToInt32(m_txb_portnum.Text);

                if (m_rbtn_tcp_server.Checked == true)
                {
                    return (" * Server Port (" + port + ") Stop : " + Server.ServerStop().ToString() + Environment.NewLine);
                }
                else
                {
                    Client.Close();

                    return (" * Client Is Connected to (" + ipAddressInput1.Text + ":" + port + ") :"
                        + Client.GetConntected().ToString() + Environment.NewLine);
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ SetTCMType @                                                                                          ///
        ///     수신 데이터를 처리하기 위해 사용할 처리 함수를 지정하는 정보를 매개변수로 넘겨받아 설정한다.        ///
        /// </summary>                                                                                              ///
        /// <param name="type"> string : 모드 데이터 </param>                                                       ///
        ///=========================================================================================================///
        public void SetTCMType(string type)
        {
            TCM_Type = type;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ serialPort_DataReceived @                                                                             ///
        ///     시리얼 포트를 통해 수신된 데이터를 처리하여 화면에 표출한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (Readline == true)
            {
                if (isArray == false)
                {
                    SB_Lines.AppendLine(serialPort.ReadLine());
                }
                else
                {
                    DataLines.Add(serialPort.ReadLine());
                }
            }
            else
            {
                byte[] temp;
                byte[] buff = new byte[serialPort.BytesToRead];

                serialPort.Read(buff, 0, buff.Length);

                //FileManager.LogWriter(CommonBase.Hex2Str16(buff, buff.Length),
                //    CommonBase.ErrorPath, "buff", false, false, false, false, true);

                if (buff.Length > 0)
                {
                    switch (TCM_Type)
                    {
                        case "D":
                            if (remain.Length > 0)
                            {
                                temp = new byte[buff.Length];
                                Array.Copy(buff, temp, buff.Length);

                                buff = new byte[remain.Length + temp.Length];
                                Array.Copy(remain, buff, remain.Length);
                                Array.Copy(temp, 0, buff, remain.Length, temp.Length);

                                remain = new byte[0];
                            }

                            for (int i = 0; i < buff.Length; i++)
                            {
                                if (buff[i] == STX)
                                {
                                    if ((i + 1) < buff.Length)
                                    {
                                        int len = Convert.ToInt16(buff[i + 1]);

                                        if (len < Limit_Len)
                                        {
                                            int EDX = i + len + 1;

                                            if (EDX < buff.Length)
                                            {
                                                if (buff[i + len + 1] == ETX)
                                                {
                                                    temp = new byte[len + 2];

                                                    Array.Copy(buff, i, temp, 0, temp.Length);

                                                    if (PackA_On == true)
                                                    {
                                                        Packets_A.Add(temp);

                                                        if (TimeLabel == true)
                                                        {
                                                            Times_A.Add(DateTime.Now);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Packets_B.Add(temp);

                                                        if (TimeLabel == true)
                                                        {
                                                            Times_B.Add(DateTime.Now);
                                                        }
                                                    }

                                                    i += (len + 1);
                                                }
                                            }
                                            else
                                            {
                                                remain = new byte[buff.Length - i];
                                                Array.Copy(buff, i, remain, 0, remain.Length);
                                                //FileManager.LogWriter(CommonBase.Hex2Str16(remain, remain.Length),
                                                //    CommonBase.ErrorPath, "remain", false, false, false, false, true);
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        remain = new byte[1];
                                        remain[0] = buff[i];
                                    }
                                }
                            }
                            break;
                        default:
                            if (PackA_On == true)
                            {
                                Packets_A.Add(buff);
                            }
                            else
                            {
                                Packets_B.Add(buff);
                            }
                            break;
                    }
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ GetPackets @                                                                                          ///
        ///     버퍼에 저장된 수신 데이터 패킷을 반환한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <returns> List<byte[]> : 수신 데이터 패킷 버퍼 </returns>                                               ///
        ///=========================================================================================================///
        public List<byte[]> GetPackets()
        {
            List<byte[]> Buffer = new List<byte[]>();

            if (PackA_On == true)
            {
                PackA_On = false;

                if (Packets_A.Count > 0)
                {
                    Buffer = Packets_A.GetRange(0, Packets_A.Count);
                    Packets_A.Clear();
                }
            }
            else
            {
                PackA_On = true;

                if (Packets_B.Count > 0)
                {
                    Buffer = Packets_B.GetRange(0, Packets_B.Count);
                    Packets_B.Clear();
                }
            }

            return Buffer;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ GetTimeLabels @                                                                                       ///
        ///     
        /// </summary>                                                                                              ///
        /// <returns> List<DateTime> : 데이터 수신 시간 버퍼 </returns>                                             ///
        ///=========================================================================================================///
        public List<PacketTTag> GetPacketsWithTime()
        {
            List<PacketTTag> PackTs = new List<PacketTTag>();

            int pack_cnt = 0;
            int err_idx = 0;
            PacketTTag tmp = new PacketTTag();

            try
            {
                if (PackA_On == true)
                {
                    PackA_On = false;
                    pack_cnt = Packets_A.Count;

                    for (int i = 0; i < pack_cnt; i++)
                    {
                        err_idx = i;
                        tmp = new PacketTTag();
                        tmp.packet = Packets_A[i];
                        tmp.TTag = Times_A[i];
                        PackTs.Add(tmp);
                    }

                    Packets_A.Clear();
                    Times_A.Clear();
                }
                else
                {
                    PackA_On = true;
                    pack_cnt = Packets_B.Count;

                    for (int i = 0; i < pack_cnt; i++)
                    {
                        err_idx = i;
                        tmp = new PacketTTag();
                        tmp.packet = Packets_B[i];
                        tmp.TTag = Times_B[i];
                        PackTs.Add(tmp);
                    }

                    Packets_B.Clear();
                    Times_B.Clear();
                }
            }
            catch (Exception e)
            {
                FileManager.LogWriter(e.Message + Environment.NewLine + "err_idx : " + err_idx + ", pack_cnt ; " + pack_cnt,
                    CommonBase.ErrorPath, CommonBase.ErrorLogName, true, true, true, true, true);
            }

            return PackTs;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ SendPacket @                                                                                          ///
        ///     매개변수로 전달된 데이터 패킷을 통신 객체를 통해 전송한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 데이터 패킷 </param>                                                     ///
        /// <returns> string : 전송 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        public string SendPacket(byte[] packet)
        {
            if (m_rbtn_serial.Checked == true)
            {
                try
                {
                    if (serialPort.IsOpen == true)
                        serialPort.Write(packet, 0, packet.Length);

                    return (" * Data Sended!! " + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine);

                    return ex.Message + Environment.NewLine;
                }
            }
            else
            {
                int port = Convert.ToInt32(m_txb_portnum.Text);

                if (m_rbtn_tcp_server.Checked == true)
                {
                    foreach(TCP_Comm_Manager tcm in Server.GetClients())
                    {
                        tcm.Send(packet);
                    }

                    return (" * Data Sended!! " + Environment.NewLine);
                }
                else
                {
                    Client.Send(packet);

                    return (" * Data Sended!! " + Environment.NewLine);
                }
            }

        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ TCP_Comm_Server_SetLogMsg @                                                                           ///
        ///     Not Used                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="port"> int : 포트 번호 </param>                                                            ///
        /// <param name="msg"> string : 메시지 </param>                                                             ///
        ///=========================================================================================================///
        private void TCP_Comm_Server_SetLogMsg(int port, string msg)
        {
            // Not Used
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ TCP_Comm_Manager_DisConnecting @                                                                      ///
        ///     Not Used                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="ip"> string : 원격지 접속 IP 주소 </param>                                                 ///
        /// <param name="port"> int : 원격지 접속 포트 번호 </param>                                                ///
        ///=========================================================================================================///
        private void TCP_Comm_Manager_DisConnecting(string ip, int port)
        {
            // Not Used
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ TCP_Comm_Manager_NotifyData @                                                                         ///
        ///     Not Used                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="port"> int : 포트 번호 </param>                                                            ///
        /// <param name="buff"> byte[] : 데이터 버퍼 </param>                                                       ///
        ///=========================================================================================================///
        private void TCP_Comm_Manager_NotifyData(int port, byte[] buff)
        {
            // Not Used
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ TCP_Comm_Manager_NotifyDisconnect @                                                                   ///
        ///     Not Used                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="port"> int : 포트 번호 </param>                                                            ///
        ///=========================================================================================================///
        private void TCP_Comm_Manager_NotifyDisconnect(int port)
        {
            // Not Used
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ TCP_Comm_Manager_NotifyMsg @                                                                          ///
        ///     Not Used                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="port"> int : 포트 번호 </param>                                                            ///
        /// <param name="msg"> string : 메시지 </param>                                                             ///
        ///=========================================================================================================///
        private void TCP_Comm_Manager_NotifyMsg(int port, string msg)
        {
            // Not Used
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ m_btn_conn_Click @                                                                                    ///
        ///     통신 연결 / 종료를 시도한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_conn_Click(object sender, EventArgs e)
        {
            if ((m_btn_conn.Text.Equals("Connect") == true) || (m_btn_conn.Text.Equals("Server Start") == true))
            {
                Conn_Result = CommConnect();

                if (m_btn_conn.Text.Equals("Connect") == true)
                {
                    m_btn_conn.Text = "Disconncect";
                }
                else
                {
                    m_btn_conn.Text = "Server Stop";
                }

                if (m_rbtn_tcp.Checked == true)
                {
                    timer_grabber.Start();
                }

                SendMsg(this, Conn_Result);
            }
            else
            {
                Conn_Result = CommDisconnect();

                if (m_btn_conn.Text.Contains("Server") == true)
                {
                    m_btn_conn.Text = "Server Start";
                }
                else
                {
                    m_btn_conn.Text = "Connect";
                }

                if (m_rbtn_tcp.Checked == true)
                {
                    timer_grabber.Stop();
                }

                SendMsg(this, Conn_Result);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ m_btn_refresh_Click @                                                                                 ///
        ///     로컬시스템에 연결된 COM 포트의 정보를 재설정한다.                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_refresh_Click(object sender, EventArgs e)
        {
            InitSerialInfo();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ InitSerialInfo @                                                                                      ///
        ///     시리얼 통신 관련 설정 값들을 콤보박스에 적용한다.                                                   ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void InitSerialInfo()
        {
            m_cb_portname.Items.Clear();
            m_cb_baudrate.Items.Clear();
            m_cb_databits.Items.Clear();
            m_cb_parity.Items.Clear();
            m_cb_stopbits.Items.Clear();
            m_cb_flowtype.Items.Clear();

            foreach (string portname in SerialPort.GetPortNames())
            {
                if (m_cb_portname.FindStringExact(portname) < 0)
                {
                    //serialPort = new SerialPort(portname);
                    //bool not_use = true;
                    /*
                    try
                    {
                        serialPort.Open();
                    }
                    catch (Exception e)
                    {
                        string error = e.Message;
                        not_use = false;
                    }
                    */
                    //if (not_use == true)
                    {
                        m_cb_portname.Items.Add(portname);

                        //if (serialPort.IsOpen == true)
                        {
                        //    serialPort.Close();
                        }
                    }
                }
            }

            foreach (string baudrate in baudrates)
            {
                m_cb_baudrate.Items.Add(baudrate);
            }

            foreach (string databit in databits)
            {
                m_cb_databits.Items.Add(databit);
            }

            foreach (string parity in Enum.GetNames(typeof(Parity)))
            {
                m_cb_parity.Items.Add(parity);
            }

            foreach (string stopbits in Enum.GetNames(typeof(StopBits)))
            {
                m_cb_stopbits.Items.Add(stopbits);
            }

            foreach (string handshake in Enum.GetNames(typeof(Handshake)))
            {
                m_cb_flowtype.Items.Add(handshake);
            }

            SetSerialBaudrate(Serial_Option[0]);
            SetSerialDataBits(Serial_Option[1]);
            SetSerialParity(Serial_Option[2]);
            SetSerialStopBtis(Serial_Option[3]);
            SetSerialFlowtype(Serial_Option[4]);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-19 ] ///
        /// @ m_rbtn_CheckedChanged @                                                                               ///
        ///     통신 모드 선택에 따라 세부 옵션의 사용 여부를 설정한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                if (sender == m_rbtn_serial)
                {
                    m_cb_portname.Enabled = true;
                    m_cb_baudrate.Enabled = true;
                    m_cb_databits.Enabled = true;
                    m_cb_parity.Enabled = true;
                    m_cb_stopbits.Enabled = true;
                    m_cb_flowtype.Enabled = true;

                    m_rbtn_tcp_server.Enabled = false;
                    m_rbtn_tcp_client.Enabled = false;
                    ipAddressInput1.Enabled = false;
                    m_txb_portnum.Enabled = false;

                    if (serialPort.IsOpen == true)
                    {
                        serialPort.Close();
                    }
                }
                else if (sender == m_rbtn_tcp)
                {
                    m_cb_portname.Enabled = false;
                    m_cb_baudrate.Enabled = false;
                    m_cb_databits.Enabled = false;
                    m_cb_parity.Enabled = false;
                    m_cb_stopbits.Enabled = false;
                    m_cb_flowtype.Enabled = false;

                    m_rbtn_tcp_server.Enabled = true;
                    m_rbtn_tcp_client.Enabled = true;

                    if (m_rbtn_tcp_server.Checked == true)
                    {
                        m_rbtn_CheckedChanged(m_rbtn_tcp_server, e);
                    }
                    else
                    {
                        m_rbtn_CheckedChanged(m_rbtn_tcp_client, e);
                    }
                }
                else if (sender == m_rbtn_tcp_server)
                {
                    ipAddressInput1.Enabled = false;
                    m_txb_portnum.Enabled = true;
                    m_btn_conn.Text = "Server Start";
                }
                else if (sender == m_rbtn_tcp_client)
                {
                    ipAddressInput1.Enabled = true;
                    m_txb_portnum.Enabled = true;
                    m_btn_conn.Text = "Connect";
                }
            }
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2017-06-12 ] ///
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
                comm += (Convert.ToInt16(m_rbtn_tcp_server.Checked) + ",");
                comm += (ipAddressInput1.Value + ",");
                comm += m_txb_portnum.Text;
            }

            return comm;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2017-06-12 ] ///
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

                        int port = Convert.ToInt32(sub[1]);

                        if (m_cb_portname.Items.Count > port)
                        {
                            m_cb_portname.SelectedIndex = port;
                        }

                        m_cb_baudrate.SelectedIndex = Convert.ToInt32(sub[2]);
                        m_cb_databits.SelectedIndex = Convert.ToInt32(sub[3]);
                        m_cb_parity.SelectedIndex = Convert.ToInt32(sub[4]);
                        m_cb_stopbits.SelectedIndex = Convert.ToInt32(sub[5]);
                        m_cb_flowtype.SelectedIndex = Convert.ToInt32(sub[6]);
                        break;
                    case "Ethernet":
                        m_rbtn_tcp.Checked = true;

                        if (Convert.ToInt32(sub[1]) == 1)
                        {
                            m_rbtn_tcp_server.Checked = true;
                        }
                        else
                        {
                            m_rbtn_tcp_client.Checked = true;
                        }

                        ipAddressInput1.Value = sub[2];
                        m_txb_portnum.Text = sub[3];
                        break;
                    default: break;
                }
            }

        }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2017-06-22 ] ///
        /// @ timer_grabber_Tick @                                                                                  ///
        ///     주기적으로 이더넷 통신 객체로 수신된 데이터를 가져와 버퍼에 저장한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void timer_grabber_Tick(object sender, EventArgs e)
        {
            List<byte[]> Temp_Packs;

            if (m_rbtn_tcp_server.Checked == true)
            {
                foreach (TCP_Comm_Manager tcm in Server.GetClients())
                {
                    Temp_Packs = tcm.GetPackets();

                    foreach (byte[] packet in Temp_Packs)
                    {
                        if (PackA_On == true)
                        {
                            Packets_A.Add(packet);

                            if (TimeLabel == true)
                            {
                                Times_A.Add(DateTime.Now);
                            }
                        }
                        else
                        {
                            Packets_B.Add(packet);

                            if (TimeLabel == true)
                            {
                                Times_B.Add(DateTime.Now);
                            }
                        }
                    }
                }
            }
            else
            {
                Temp_Packs = Client.GetPackets();

                foreach (byte[] packet in Temp_Packs)
                {
                    if (PackA_On == true)
                    {
                        Packets_A.Add(packet);

                        if (TimeLabel == true)
                        {
                            Times_A.Add(DateTime.Now);
                        }
                    }
                    else
                    {
                        Packets_B.Add(packet);

                        if (TimeLabel == true)
                        {
                            Times_B.Add(DateTime.Now);
                        }
                    }
                }
            }
        }
        #endregion

        #region [ # Ver 1.03 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2017-07-10 ] ///
        /// @ IsConnect @                                                                                           ///
        ///     통신 객체의 연결 상태를 조회하여 반환한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <returns> bool : 통신 상태 </returns>                                                                   ///
        ///=========================================================================================================///
        public bool IsConnect()
        {
            bool status = false;

            if (m_rbtn_serial.Checked == true)
            {
                status = serialPort.IsOpen;
            }
            else
            {
                if (m_rbtn_tcp_server.Checked == true)
                {
                    if (Server != null)
                    {
                        status = Server.GetServerStatus();
                    }
                }
                else
                {
                    status = Client.GetConntected();
                }
            }

            return status;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2017-07-10 ] ///
        /// @ GetClients @                                                                                          ///
        ///     서버에 접속된 클라이언트의 수를 반화한다.                                                           ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public int GetClients()
        {
            int cnt = 0;

            if (Server != null)
            {
                TCP_Comm_Manager[] list = Server.GetClients();
                cnt = list.Length;
            }

            return cnt;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2017-07-10 ] ///
        /// @ GetPortInfo @                                                                                         ///
        ///     활성화된 통신 객체의 포트 정보를 반환한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <returns> string : 통신 포트 정보 </returns>                                                            ///
        ///=========================================================================================================///
        public string GetPortInfo()
        {
            string port = string.Empty;

            if (m_rbtn_serial.Checked == true)
            {
                port = serialPort.PortName;
            }
            else
            {
                if (m_rbtn_tcp_server.Checked == true)
                {
                    port = Server.GetServerPort().ToString();
                }
                else
                {
                    port = Client.GetRemotePort().ToString();
                }
            }

            return port;
        }
        #endregion

        #region [ # Ver 1.04 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2017-07-17 ] ///
        /// @ SetRecvThreshold @                                                                                    ///
        ///     시리얼 포트의 데이터 처리 이벤트 호출 기준을 설정한다.                                              ///
        /// </summary>                                                                                              ///
        /// <param name="bytes"> int : 이벤트 호출 수신 바이트 수 </param>                                          ///
        ///=========================================================================================================///
        public void SetRecvThreshold(int bytes)
        {
            serialPort.ReceivedBytesThreshold = bytes;
        }
        #endregion

        #region [ # Ver 1.05 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.05 / 2017-07-24 ] ///
        /// @ Close @                                                                                               ///
        ///     통신 객체들의 동작을 중단하고 초기화한다.                                                           ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void Close()
        {
            if (Server != null)
            {
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
        #endregion

        #region [ # Ver 1.06 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.06 / 2018-03-26 ] ///
        /// @ StartComm @                                                                                           ///
        ///     통신 연결 이벤트를 호출한다.                                                                        ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void StartComm()
        {
            m_btn_conn_Click(this, new EventArgs());
        }
        #endregion

        #region [ # Ver 1.07 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2018-04-06 ] ///
        /// @ SetSerialBaudrate @                                                                                   ///
        ///     매개변수로 지정된 인덱스를 Baudrate 옵션에 적용한다.                                                ///
        ///                                                                                                         ///
        ///     0 - 9600        4 - 57600                                                                           ///
        ///     1 - 19200       5 - 115200                                                                          ///
        ///     2 - 28800       6 - 230400                                                                          ///
        ///     3 - 38400       7 - 460800                                                                          ///
        /// </summary>                                                                                              ///
        /// <param name="option"> int : 속성 값 인덱스 </param>                                                     ///
        ///=========================================================================================================///
        public void SetSerialBaudrate(int option)
        {
            m_cb_baudrate.SelectedIndex = option;
            Serial_Option[0] = option;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2018-04-06 ] ///
        /// @ SetSerialDataBits @                                                                                   ///
        ///     매개변수로 지정된 인덱스를 Databits 옵션에 적용한다.                                                ///
        ///                                                                                                         ///
        ///     0 - 5           2 - 7                                                                               ///
        ///     1 - 6           3 - 8                                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="option"> int : 속성 값 인덱스 </param>                                                     ///
        ///=========================================================================================================///
        public void SetSerialDataBits(int option)
        {
            m_cb_databits.SelectedIndex = option;
            Serial_Option[1] = option;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2018-04-06 ] ///
        /// @ SetSerialParity @                                                                                     ///
        ///     매개변수로 지정된 인덱스를 Parity 옵션에 적용한다.                                                  ///
        ///                                                                                                         ///
        ///     0 - None        3 - Mark                                                                            ///
        ///     1 - Odd         4 - Space                                                                           ///
        ///     2 - Even                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="option"> int : 속성 값 인덱스 </param>                                                     ///
        ///=========================================================================================================///
        public void SetSerialParity(int option)
        {
            m_cb_parity.SelectedIndex = option;
            Serial_Option[2] = option;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2018-04-06 ] ///
        /// @ SetSerialStopBtis @                                                                                   ///
        ///     매개변수로 지정된 인덱스를 Stopbits 옵션에 적용한다.                                                ///
        ///                                                                                                         ///
        ///     0 - None        2 - Two                                                                             ///
        ///     1 - One         3 - OnePointFive                                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="option"> int : 속성 값 인덱스 </param>                                                     ///
        ///=========================================================================================================///
        public void SetSerialStopBtis(int option)
        {
            m_cb_stopbits.SelectedIndex = option;
            Serial_Option[3] = option;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2018-04-06 ] ///
        /// @ SetSerialFlowtype @                                                                                   ///
        ///     매개변수로 지정된 인덱스를 Flowtype 옵션에 적용한다.                                                ///
        ///                                                                                                         ///
        ///     0 - None        2 - RequestToSend                                                                   ///
        ///     1 - XOnXOff     3 - RequestToSendXO                                                                 ///
        /// </summary>                                                                                              ///
        /// <param name="option"> int : 속성 값 인덱스 </param>                                                     ///
        ///=========================================================================================================///
        public void SetSerialFlowtype(int option)
        {
            m_cb_flowtype.SelectedIndex = option;
            Serial_Option[4] = option;
        }
        #endregion

        #region [ # Ver 1.08 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.08 / 2018-09-19 ] ///
        /// @ SetReadLineMode @                                                                                     ///
        ///     시리얼 포트에서 데이터를 라인 단위로 처리할 지 여부를 설정한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 문자열로 수신 여부 </param>                                                  ///
        /// <param name="array"> bool : 결과 문자열을 배열 형태로 반환할 것인지 여부 </param>                       ///
        ///=========================================================================================================///
        public void SetReadLineMode(bool mode, bool array)
        {
            Readline = mode;
            isArray = array;
        }
        
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.08 / 2018-09-19 ] ///
        /// @ GetDatalines @                                                                                        ///
        ///     시리얼 포트로 문자열 단위로 수신된 데이터를 반환한다.                                               ///
        /// </summary>                                                                                              ///
        /// <returns> object : string 또는 string 배열 </returns>                                                   ///
        ///=========================================================================================================///
        public object GetDatalines()
        {
            if (isArray == false)
            {
                string result = SB_Lines.ToString();
                SB_Lines.Clear();

                return result;
            }
            else
            {
                string[] result = DataLines.ToArray();
                DataLines.Clear();

                return result;
            }
        }
        #endregion

        #region [ # Ver 1.09 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.09 / 2018-09-20 ] ///
        /// @ SetLimitLength @                                                                                      ///
        ///     데이터 패킷 처리 제한 길이를 서정한다.                                                              ///
        /// </summary>                                                                                              ///
        /// <param name="len"> int : 제한 길이 </param>                                                             ///
        ///=========================================================================================================///
        public void SetLimitLength(int len)
        {
            Limit_Len = len;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.09 / 2018-09-20 ] ///
        /// @ SetUseTimeLabel @                                                                                     ///
        ///     데이터 패킷의 수신 시간 저장 여부를 설정한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="use"> bool : 시간 라벨 사용 여부 </param>                                                  ///
        ///=========================================================================================================///
        public void SetUseTimeLabel(bool use)
        {
            TimeLabel = use;
        }
        #endregion

        #region [ # Ver 1.10 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2018-10-17 ] ///
        /// @ SetDisableSerialPort @                                                                                ///
        ///     시리얼 통신 설정의 활성화 여부를 설정한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <param name="use"> bool : 시리얼 설정 활성화 여부 </param>                                              ///
        /// <param name="options"> bool[] : 세부 설정 옵션 활성화 여부 </param>                                     ///
        ///=========================================================================================================///
        public void SetDisableSerialPort(bool use, bool[] options)
        {
            if (use == false)
            {
                m_rbtn_serial.Enabled = false;
                m_gp_serial.Enabled = false;
            }
            else
            {
                m_rbtn_serial.Enabled = true;
                m_gp_serial.Enabled = true;

                m_cb_portname.Enabled = options[0];
                m_cb_baudrate.Enabled = options[1];
                m_cb_databits.Enabled = options[2];
                m_cb_parity.Enabled   = options[3];
                m_cb_stopbits.Enabled = options[4];
                m_cb_flowtype.Enabled = options[5];
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2018-10-17 ] ///
        /// @ SetDisableEthernet @                                                                                  ///
        ///     이더넷 통신 설정의 활성화 여부를 설정한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <param name="use"> bool : 이더넷 설정 활성화 여부 </param>                                              ///
        /// <param name="options"> bool[] : 세부 설정 옵션 활성화 여부 </param>                                     ///
        ///=========================================================================================================///
        public void SetDisableEthernet(bool use, bool[] options)
        {
            if (use == false)
            {
                m_rbtn_tcp.Enabled = false;
                m_gp_tcp.Enabled = false;
            }
            else
            {
                m_rbtn_tcp.Enabled = true;

                m_rbtn_tcp_client.Enabled = options[0];
                m_rbtn_tcp_server.Enabled = options[1];
                ipAddressInput1.Enabled   = options[2];
                m_txb_portnum.Enabled     = options[3];
            }
        }
        #endregion

        #region [ # Ver 1.11 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.11 / 2019-01-16 ] ///
        /// @ SetDummyMode @                                                                                        ///
        ///     네트워크 연결 확인용 더미 패킷 전송 모드를 설정한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 더미 전송 모드 </param>                                                      ///
        ///=========================================================================================================///
        public void SetDummyMode(bool mode)
        {
            if (m_rbtn_tcp_server.Checked == true)
            {
                foreach (TCP_Comm_Manager tcm in Server.GetClients())
                {
                    tcm.SetDummyMode(mode);
                }
            }
            else
            {
                Client.SetDummyMode(mode);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.11 / 2019-01-16 ] ///
        /// @ SetLoggingMode @                                                                                      ///
        ///     로그 파일 저장 모드를 설정한다.                                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 로그 파일 저장 모드 </param>                                                 ///
        ///=========================================================================================================///
        public void SetLoggingMode(bool mode)
        {
            if (m_rbtn_tcp_server.Checked == true)
            {
                foreach (TCP_Comm_Manager tcm in Server.GetClients())
                {
                    tcm.SetLoggingMode(mode);
                }
            }
            else
            {
                Client.SetLoggingMode(mode);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.11 / 2019-01-16 ] ///
        /// @ SetHighSpeedMode @                                                                                    ///
        ///     데이터 처리 모드를 설정한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 데이터 고속 처리 모드 </param>                                               ///
        ///=========================================================================================================///
        public void SetHighSpeedMode(bool mode)
        {
            if (m_rbtn_tcp_server.Checked == true)
            {
                foreach (TCP_Comm_Manager tcm in Server.GetClients())
                {
                    tcm.SetHighSpeedMode(mode);
                }
            }
            else
            {
                Client.SetHighSpeedMode(mode);
            }
        }
        #endregion
    }
    ///======================================================================== End of Class : Widjet_Setting_Comm =///
}
