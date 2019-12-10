using System;
using System.Text;
using System.Windows.Forms;
using DevComponents.Editors;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.01 / 2014-04-17 ] ///
    /// ▷ WinForm_SetEthernet ◁                                                                                   ///
    ///     이더넷 통신 환경을 설정을 지원하는 UI 클래스로 속성 설정 후 시리얼 포트로 적용을 요청하는 이벤트를      ///
    ///     발생시키므로 시리얼 포트는 메인 폼의 컨트롤로 배치하고 메인 폼에서 이벤트 핸들러를 등록하여 처리한다.   ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-07 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2014-10-17 ]                                                                                   ///
    ///     ▶ 접속 정보를 매개변수로 받는 생성자 추가                                                              ///
    ///     ▶ IP 설정 관련 기능 추가                                                                               ///
    ///     ▶ 델리게이트 함수 구현                                                                                 ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class WinForm_SetEthernet : Form
    {
        #region [ # Defines & Variables ]
        private string ErrorPath = CommonVariables.ErrorPath;
        private string ErrorLogName = CommonVariables.ErrorLogName;

        private string ip_buffer = string.Empty;
        private string message = string.Empty;
        private StringBuilder MessageBuilder;

        public static event SetPortHandler SetEthernet;
        public delegate void SetPortHandler(string ip, int port);

        private delegate void setenable(bool enable);
        private delegate void setIpAddreess(IpAddressInput input, string ip);
        private delegate void setTextBox(TextBox tb, string msg);
        private delegate void setRadioButton(RadioButton rb, bool set);

        // 자동 재접속 여부 변수
        private bool autoReConn = false;
        public bool AutoReConn
        {
            get { return autoReConn; }
            set { autoReConn = value; }
        }
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ WinForm_SetEthernet @                                                                                 ///
        ///     생성자로 컨트롤과 변수를 초기화한다.                                                                ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public WinForm_SetEthernet()
        {
            InitializeComponent();

            SetEnable(false);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-02 ] ///
        /// @ m_btn_set_Click @                                                                                     ///
        ///     버튼 클릭 시 호출되는 이벤트 핸들러로 입력된 IP 주소와 포트 번호를 설정하도록 요청한다.             ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_set_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;

                autoReConn = m_ckb_autoreconn.Checked;

                if (m_rbtn_server.Checked == true)
                {
                    SetEthernet(string.Empty, Convert.ToInt32(m_txb_port.Text));
                }
                else
                {
                    SetEthernet(ipAddressInput1.Value, Convert.ToInt32(m_txb_port.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : m_btn_set_Click ]");
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
        /// @ m_btn_cancel_Click @                                                                                  ///
        ///     버튼 클릭 시 호출되는 이벤트 핸들러로 IP 설정을 취소하고 폼을 종료한다.                             ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : m_btn_cancel_Click ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(ex.Message);
                MessageBuilder.AppendLine();

                message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-03 ] ///
        /// @ m_txb_port_KeyPress @                                                                                 ///
        ///     텍스트 박스의 입력이 발생할 때 호출되는 이벤트 핸들러로 숫자만 입력되도록 제한한다.                 ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_txb_port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != '\b')) e.Handled = true;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ m_rbtn_server_Click @                                                                                 ///
        ///     서버 모드로 설정할 경우 원격지 접속 IP 주소 입력을 비활성화한다.                                    ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_rbtn_server_Click(object sender, EventArgs e)
        {
            SetEnable(false);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ m_rbtn_client_Click @                                                                                 ///
        ///     클라이언트 모드로 설정할 경우 원격지 접속 IP 주소 입력을 활성화한다.                                ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_rbtn_client_Click(object sender, EventArgs e)
        {
            SetEnable(true);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetEnable @                                                                                           ///
        ///     IP 주소 입력 컨트롤의 활성화 여부를 매개변수로 전달된 값으로 적용한다.                              ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="enable"> bool : 컨트롤 활성화 여부 </param>                                                ///
        ///=========================================================================================================///
        private void SetEnable(bool enable)
        {
            try
            {
                if (ipAddressInput1.InvokeRequired == true)
                {
                    ipAddressInput1.Invoke(new setenable(SetEnable), enable);
                }
                else
                {
                    ipAddressInput1.Enabled = enable;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetEnable ]");
                MessageBuilder.AppendLine("# enable   : " + enable.ToString());
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-10-17 ] ///
        /// @ WinForm_SetEthernet @                                                                                 ///
        ///     생성자로 초기화를 수행하며 매개변수로 IP와 Port 정보를 전달받아 초기 설정한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="ip"> string : 목적지 IP 주소 </param>                                                      ///
        /// <param name="port"> int : 목적지 Port 번호 </param>                                                     ///
        ///=========================================================================================================///
        public WinForm_SetEthernet(string ip, int port)
        {
            InitializeComponent();

            ipAddressInput1.Value = ip;
            m_txb_port.Text = port.ToString();

            SetEnable(false);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-10-17 ] ///
        /// @ SetInfo @                                                                                             ///
        ///     매개변수로 전달한 값으로 IP 주소와 Port 정보를 화면에 표시한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="ip"> string : 목적지 IP 주소 </param>                                                      ///
        /// <param name="port"> int : 목적지 Port 번호 </param>                                                     ///
        ///=========================================================================================================///
        public void SetInfo(string ip, int port)
        {
            SetIpAddress(ipAddressInput1, ip);
            SetTextBox(m_txb_port, port.ToString());
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-10-17 ] ///
        /// @ SetIpAddress @                                                                                        ///
        ///     IP 주소 입력 컨트롤에 매개변수로 전달된 IP 주소를 설정한다.                                         ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="input"> IpAdressInput : IP 주소 입력 컨트롤 </param>                                       ///
        /// <param name="ip"> string : IP 주소 </param>                                                             ///
        ///=========================================================================================================///
        private void SetIpAddress(IpAddressInput input, string ip)
        {
            try
            {
                if (input.InvokeRequired == true)
                {
                    input.Invoke(new setIpAddreess(SetIpAddress), input, ip);
                }
                else
                {
                    input.Value = ip;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetIpAddress ]");

                if (input != null)
                {
                    MessageBuilder.AppendLine("# IpAddressInput   : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# IpAddressInput   : " + input.Name);
                }

                if (string.IsNullOrEmpty(ip) == true)
                {
                    MessageBuilder.AppendLine("# IP       : NULL / Empty");
                }
                else
                {
                    MessageBuilder.AppendLine("# IP       : " + ip);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-10-17 ] ///
        /// @ SetTextBox @                                                                                          ///
        ///     텍스트박스 컨트롤에 매개변수로 전달된 값을 설정한다.                                                ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="tb"> TextBox : 설정 대상 텍스트박스 </param>                                               ///
        /// <param name="msg"> string : 설정 값 </param>                                                            ///
        ///=========================================================================================================///
        private void SetTextBox(TextBox tb, string msg)
        {
            try
            {
                if (tb.InvokeRequired == true)
                {
                    tb.Invoke(new setTextBox(SetTextBox), tb, msg);
                }
                else
                {
                    tb.Text = msg;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetTextBox ]");

                if (tb != null)
                {
                    MessageBuilder.AppendLine("# TextBox  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# TextBox  : " + tb.Name);
                }

                if (string.IsNullOrEmpty(msg) == true)
                {
                    MessageBuilder.AppendLine("# msg      : NULL / Empty");
                }
                else
                {
                    MessageBuilder.AppendLine("# msg      : " + msg);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-10-17 ] ///
        /// @ SetRadioButton @                                                                                      ///
        ///     매개변수로 지정된 라디오버튼의 체크 상태를 설정한다.                                                ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="rb"> RadioButton : 체크 상태 설정 대상 </param>                                            ///
        /// <param name="set"> bool : 체크 상태 값 </param>                                                         ///
        ///=========================================================================================================///
        private void SetRadioButton(RadioButton rb, bool set)
        {
            try
            {
                if (rb.InvokeRequired == true)
                {
                    rb.Invoke(new setRadioButton(SetRadioButton), rb, set);
                }
                else
                {
                    rb.Checked = set;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetTextBox ]");

                if (rb != null)
                {
                    MessageBuilder.AppendLine("# RadioButton  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# RadioButton  : " + rb.Name);
                }

                MessageBuilder.AppendLine("# set      : " + set.ToString());
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-10-17 ] ///
        /// @ SetMode @                                                                                             ///
        ///     Server / Client 여부를 화면상에 설정한다.                                                           ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> int : 모드 식별자 </param>                                                          ///
        ///=========================================================================================================///
        public void SetMode(int mode)
        {
            if (mode == 0)
            {
                SetRadioButton(m_rbtn_server, true);
                SetEnable(false);
            }
            else
            {
                SetRadioButton(m_rbtn_client, true);
                SetEnable(true);
            }
        }
        #endregion
    }
    ///======================================================================== End of Class : WinForm_SetEthernet =///
}
