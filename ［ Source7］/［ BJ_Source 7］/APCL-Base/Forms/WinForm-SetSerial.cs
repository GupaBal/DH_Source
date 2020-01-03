using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-04-02 ] ///
    /// ▷ WinForm_SetSerial : Form ◁                                                                              ///
    ///     시리얼 포트의 속성을 설정하기 위한 UI를 제공하는 클래스로 속성 설정 후                                  ///
    ///     시리얼 포트로 적용을 요청하는 이벤트를 발생시키므로 시리얼 포트는 메인 폼의 컨트롤로 배치하고           ///
    ///     메인 폼에서 이벤트 핸들러를 등록하여 처리한다.                                                          ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-02 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class WinForm_SetSerial : Form
    {
        #region [ # Defines & Variables ]
        private string ErrorPath = CommonVariables.ErrorPath;
        private string ErrorLogName = CommonVariables.ErrorLogName;

        private string message = string.Empty;
        private StringBuilder MessageBuilder;
    
        private string[] properties;

        public static event SetPortHandler SetPort;
        public delegate void SetPortHandler(string[] property);

        private List<ComboBox> options;

        int[] index = { 0, 6, 3, 0, 1, 0 };
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ WinForm_SetSerial @                                                                                   ///
        ///     생성자로 컨트롤과 변수를 초기화한다.                                                                ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public WinForm_SetSerial()
        {
            InitializeComponent();

            properties = new string[6];
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ WinForm_SetSerial @                                                                                   ///
        ///     생성자로 컨트롤과 변수를 초기화한다.                                                                ///
        ///     매개변수로 넘겨지는 값은 콤보 박스의 초기 표시값을 지정한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="options"> int[] : 콤보 박스 인덱스 배열 </param>                                           ///
        ///=========================================================================================================///
        public WinForm_SetSerial(int[] options)
        {
            InitializeComponent();

            properties = new string[6];
            index = options;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ WinForm_SetSerial_Load @                                                                              ///
        ///     폼이 로드되는 시점에 호출되는 이벤트 핸들러로 콤보 박스에 초기 표시 값을 설정한다.                  ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void WinForm_SetSerial_Load(object sender, EventArgs e)
        {
            try
            {
                options = new List<ComboBox>();
                options.Add(m_cb_pn); options.Add(m_cb_br); options.Add(m_cb_db);
                options.Add(m_cb_p); options.Add(m_cb_sb); options.Add(m_cb_hs);

                RS232_Setter.SetOptionsCombo(ref options, index);
            }
            catch (Exception ex)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : WinForm_SetSerial_Load ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(ex.Message);
                MessageBuilder.AppendLine();

                message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ m_btn_Set_Click @                                                                                     ///
        ///     버튼이 클릭되면 호출되는 이벤트 핸들러로 콤보 박스의 값을 시리얼 포트에 적용하도록 요청한다.        ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_Set_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(CommonVariables.ConfigPath + "\\Serial.ini", false);
                sw.WriteLine("PortNmae:" + m_cb_pn.SelectedIndex);
                sw.WriteLine("Baudrate:" + m_cb_br.SelectedIndex);
                sw.WriteLine("DataBits:" + m_cb_db.SelectedIndex);
                sw.WriteLine("Parity:" + m_cb_p.SelectedIndex);
                sw.WriteLine("StopBits:" + m_cb_sb.SelectedIndex);
                sw.WriteLine("Hankshake:" + m_cb_hs.SelectedIndex);
                sw.Flush();
                sw.Close();

                SetPort(properties);
            }
            catch (Exception ex)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : m_btn_Set_Click ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(ex.Message);
                MessageBuilder.AppendLine();

                message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            this.Close();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ m_btn_Cancel_Click @                                                                                  ///
        ///     버튼이 클릭되면 호출되는 이벤트 핸들러로 폼을 종료한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ m_cb_Port_SelectedIndexChanged @                                                                      ///
        ///     콤보 박스의 선택 항목이 변경되면 호출되는 이벤트 핸들러로 선택된 항목을 변수에 저장한다.            ///
        ///     시리얼 포트 이름 설정                                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_cb_Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            properties[0] = m_cb_pn.Text;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ m_cb_Baud_SelectedIndexChanged @                                                                      ///
        ///     콤보 박스의 선택 항목이 변경되면 호출되는 이벤트 핸들러로 선택된 항목을 변수에 저장한다.            ///
        ///     시리얼 통신 속도 설정                                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_cb_Baud_SelectedIndexChanged(object sender, EventArgs e)
        {
            properties[1] = m_cb_br.Text;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ m_cb_db_SelectedIndexChanged @                                                                        ///
        ///     콤보 박스의 선택 항목이 변경되면 호출되는 이벤트 핸들러로 선택된 항목을 변수에 저장한다.            ///
        ///     시리얼 포트 데이터 비트 설정                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_cb_db_SelectedIndexChanged(object sender, EventArgs e)
        {
            properties[2] = m_cb_db.Text;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ m_cb_p_SelectedIndexChanged @                                                                         ///
        ///     콤보 박스의 선택 항목이 변경되면 호출되는 이벤트 핸들러로 선택된 항목을 변수에 저장한다.            ///
        ///     시리얼 포트 패리티 비트 설정                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_cb_p_SelectedIndexChanged(object sender, EventArgs e)
        {
            properties[3] = m_cb_p.Text;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ m_cb_sb_SelectedIndexChanged @                                                                        ///
        ///     콤보 박스의 선택 항목이 변경되면 호출되는 이벤트 핸들러로 선택된 항목을 변수에 저장한다.            ///
        ///     시리얼 포트 스탑 비트 설정                                                                          ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_cb_sb_SelectedIndexChanged(object sender, EventArgs e)
        {
            properties[4] = m_cb_sb.Text;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ m_cb_hs_SelectedIndexChanged @                                                                        ///
        ///     콤보 박스의 선택 항목이 변경되면 호출되는 이벤트 핸들러로 선택된 항목을 변수에 저장한다.            ///
        ///     시리얼 포트 핸드쉐이크 설정                                                                         ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_cb_hs_SelectedIndexChanged(object sender, EventArgs e)
        {
            properties[5] = m_cb_hs.Text;
        }
        #endregion
    }
    ///========================================================================== End of Class : WinForm_SetSerial =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-04-02 ] ///
    /// ▷ 시리얼 포트의 속성 설정 클래스 ◁                                                                        ///
    ///     메인 폼의 이벤트 핸들러에서 호출하여 사용하며 속성 별로 설정하는 함수를 호출한다.                       ///
    ///                                                                                                             ///
    /// [ Ver 1.0 / 2014-04-02 ]                                                                                    ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class RS232_Setter : CommonVariables
    {
        #region [ # Defines & Variables ]
        private static string Message = string.Empty;
        private static StringBuilder MessageBuilder;

        private static string[] baudrates = { "9600", "19200", "28800", "38400", "57600", "115200", "230400", "460800" };
        private static string[] databits = { "5", "6", "7", "8" };
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ SetPortname @                                                                                         ///
        ///     매개변수로 지정된 시리얼 포트에 포트 이름을 설정한다.                                               ///
        /// </summary>                                                                                              ///
        /// <param name="s"> SerialPort : 시리얼 포트 </param>                                                      ///
        /// <param name="name"> string : 포트 이름 </param>                                                         ///
        ///=========================================================================================================///
        public static void SetPortname(SerialPort s, string name)
        {
            try
            {
                if (s.PortName.Equals(name) == false)
                {
                    s.PortName = name;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetPortName ]");

                if (s == null)
                {
                    MessageBuilder.AppendLine("# serialport : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# serialport : " + s.PortName);
                }

                if (string.IsNullOrEmpty(name) == true)
                {
                    MessageBuilder.AppendLine("# portname : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# portname : " + name);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ SetBaudrate @                                                                                         ///
        ///     매개변수로 지정된 시리얼 포트에 통신 속도를 설정한다.                                               ///
        /// </summary>                                                                                              ///
        /// <param name="s"> SerialPort : 시리얼 포트 </param>                                                      ///
        /// <param name="baud"> string : 통신 속도 </param>                                                         ///
        ///=========================================================================================================///
        public static void SetBaudrate(SerialPort s, string baud)
        {
            try
            {
                int BaudRate = Convert.ToInt32(baud);

                if (s.BaudRate != BaudRate)
                {
                    s.BaudRate = BaudRate;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetBaudrate ]");
                MessageBuilder.AppendLine();

                if (s == null)
                {
                    MessageBuilder.AppendLine("# serialport : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# serialport : " + s.PortName);
                }

                if (string.IsNullOrEmpty(baud) == true)
                {
                    MessageBuilder.AppendLine("# baudrate : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# baudrate : " + baud.ToArray());
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ SetDatabits @                                                                                         ///
        ///     매개변수로 지정된 시리얼 포트에 데이터 비트를 설정한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="s"> SerialPort : 시리얼 포트 </param>                                                      ///
        /// <param name="dbit"> string : 데이터 비트 </param>                                                       ///
        ///=========================================================================================================///
        public static void SetDatabits(SerialPort s, string dbit)
        {
            try
            {
                int Databits = Convert.ToInt32(dbit);

                if (s.DataBits != Databits)
                {
                    s.DataBits = Databits;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetDatabits ]");

                if (s == null)
                {
                    MessageBuilder.AppendLine("# serialport : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# serialport : " + s.PortName);
                }

                if (string.IsNullOrEmpty(dbit) == true)
                {
                    MessageBuilder.AppendLine("# databits : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# databits : " + dbit);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ SetParity @                                                                                           ///
        ///     매개변수로 지정된 시리얼 포트에 패리티 비트를 설정한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="s"> SerialPort : 시리얼 포트 </param>                                                      ///
        /// <param name="pari"> string : 패리티 비트 </param>                                                       ///
        ///=========================================================================================================///
        public static void SetParity(SerialPort s, string pari)
        {
            try
            {
                Parity p = (Parity)Enum.Parse(typeof(Parity), pari);

                if (s.Parity != p)
                {
                    s.Parity = p;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetParity ]");

                if (s == null)
                {
                    MessageBuilder.AppendLine("# serialport : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# serialport : " + s.PortName);
                }

                if (string.IsNullOrEmpty(pari) == true)
                {
                    MessageBuilder.AppendLine("# paritybit : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# paritybit : " + pari);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ SetStopBits @                                                                                         ///
        ///     매개변수로 지정된 시리얼 포트에 스탑 비트를 설정한다.                                               ///
        /// </summary>                                                                                              ///
        /// <param name="s"> SerialPort : 시리얼 포트 </param>                                                      ///
        /// <param name="stop"> string : 스탑 비트 </param>                                                         ///
        ///=========================================================================================================///
        public static void SetStopBits(SerialPort s, string stop)
        {
            try
            {
                StopBits sb = (StopBits)Enum.Parse(typeof(StopBits), stop);

                if (s.StopBits != sb)
                {
                    s.StopBits = sb;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetStopBits ]");

                if (s == null)
                {
                    MessageBuilder.AppendLine("# serialport : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# serialport : " + s.PortName);
                }

                if (string.IsNullOrEmpty(stop) == true)
                {
                    MessageBuilder.AppendLine("# stopbits : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# stopbits : " + stop);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ SetHandShake @                                                                                        ///
        ///     매개변수로 지정된 시리얼 포트에 흐름 제어를 설정한다.                                               ///
        /// </summary>                                                                                              ///
        /// <param name="s"> SerialPort : 시리얼 포트 </param>                                                      ///
        /// <param name="hand"> string : 흐름 제어 방식 </param>                                                    ///
        ///=========================================================================================================///
        public static void SetHandShake(SerialPort s, string hand)
        {
            try
            {
                Handshake hs = (Handshake)Enum.Parse(typeof(Handshake), hand);

                if (s.Handshake != hs)
                {
                    s.Handshake = hs;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetHandShake ]");

                if (s == null)
                {
                    MessageBuilder.AppendLine("# serialport : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# serialport : " + s.PortName);
                }

                if (string.IsNullOrEmpty(hand) == true)
                {
                    MessageBuilder.AppendLine("# handshake : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# handsahke : " + hand);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ SetOptionsCombo @                                                                                     ///
        ///     매개변수로 콤보 박스 리스트를 넘겨 받아 로컬 시스템에서 사용할 수 있는 시리얼 속성 값을 추가한다.   ///
        ///     매개변수를 통해 지정한 인덱스로 초기 표시 항목을 설정한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="boxes"> ref List<ComboBox> : 시리얼 포트 속성 표시 콤보 박스 리스트 </param>               ///
        /// <param name="indexer"> int[] : 초기 표시 항목 인덱스 </param>                                           ///
        ///=========================================================================================================///
        public static void SetOptionsCombo(ref List<ComboBox> boxes, int[] indexer)
        {
            try
            {
                bool[] flag = new bool[indexer.Length];

                for (int i = 0; i < indexer.Length; i++)
                {
                    if (indexer[i] != -1) flag[i] = true;
                }

                string[] EnablePorts = SerialPort.GetPortNames();

                if (EnablePorts.Length > 0)
                {
                    if (flag[0] == true)
                    {
                        boxes[0].Items.Clear();

                        foreach (string portname in EnablePorts)
                        {
                            if (boxes[0].FindStringExact(portname) < 0)
                            {
                                SerialPort serialPort = new SerialPort(portname);
                                bool not_use = true;

                                try
                                {
                                    serialPort.Open();
                                }
                                catch (Exception e)
                                {
                                    string error = e.Message;
                                    not_use = false;
                                }

                                if (not_use == true)
                                {
                                    boxes[0].Items.Add(portname);

                                    if (serialPort.IsOpen == true)
                                    {
                                        serialPort.Close();
                                    }
                                }
                            }
                        }

                        if (boxes[0].Items.Count > indexer[0])
                        {
                            boxes[0].SelectedIndex = indexer[0];
                        }
                        else
                        {
                            boxes[0].SelectedIndex = 0;
                        }
                    }

                    if (flag[1] == true)
                    {
                        boxes[1].Items.Clear();

                        foreach (string baudrate in baudrates)
                        {
                            boxes[1].Items.Add(baudrate);
                        }

                        if (boxes[1].Items.Count > indexer[1])
                        {
                            boxes[1].SelectedIndex = indexer[1];
                        }
                        else
                        {
                            boxes[1].SelectedIndex = 0;
                        }
                    }

                    if (flag[2] == true)
                    {
                        boxes[2].Items.Clear();

                        foreach (string databit in databits)
                        {
                            boxes[2].Items.Add(databit);
                        }

                        if (boxes[2].Items.Count > indexer[2])
                        {
                            boxes[2].SelectedIndex = indexer[2];
                        }
                        else
                        {
                            boxes[2].SelectedIndex = 0;
                        }
                    }

                    if (flag[3] == true)
                    {
                        boxes[3].Items.Clear();

                        foreach (string parity in Enum.GetNames(typeof(Parity)))
                        {
                            boxes[3].Items.Add(parity);
                        }

                        if (boxes[3].Items.Count > indexer[3])
                        {
                            boxes[3].SelectedIndex = indexer[3];
                        }
                        else
                        {
                            boxes[3].SelectedIndex = 0;
                        }
                    }

                    if (flag[4] == true)
                    {
                        boxes[4].Items.Clear();

                        foreach (string stopbits in Enum.GetNames(typeof(StopBits)))
                        {
                            boxes[4].Items.Add(stopbits);
                        }

                        if (boxes[4].Items.Count > indexer[4])
                        {
                            boxes[4].SelectedIndex = indexer[4];
                        }
                        else
                        {
                            boxes[4].SelectedIndex = 0;
                        }
                    }

                    if (flag[5] == true)
                    {
                        boxes[5].Items.Clear();

                        foreach (string handshake in Enum.GetNames(typeof(Handshake)))
                        {
                            boxes[5].Items.Add(handshake);
                        }

                        if (boxes[5].Items.Count > indexer[5])
                        {
                            boxes[5].SelectedIndex = indexer[5];
                        }
                        else
                        {
                            boxes[5].SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetOptionsCombo ]");

                if (boxes == null)
                {
                    MessageBuilder.AppendLine("# ComboBox : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# ComboBox : " + boxes.Count.ToString());
                }

                if (indexer == null)
                {
                    MessageBuilder.AppendLine("# indexer  : NULL");
                }
                else
                {
                    MessageBuilder.Append("# indexer  : ");

                    foreach (int n in indexer)
                    {
                        MessageBuilder.Append(n.ToString() + " ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }
        #endregion
    }
    ///=============================================================================== End of Class : RS232_Setter =///
}
