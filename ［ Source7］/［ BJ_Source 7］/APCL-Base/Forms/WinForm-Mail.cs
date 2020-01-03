using System;
using System.Text;
using System.Windows.Forms;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.01 / 2014-08-05 ] ///
    /// ▷ WinForm_Mail ◁                                                                                          ///
    ///     메일 전송을 위한 UI 클래스로 SMTP를 이용하여 관리자에게 메일을 전송한다.                                ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-03 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2014-08-05 ]                                                                                   ///
    ///     ▶ 이메일 주소 유효성 검사                                                                              ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class WinForm_Mail : Form
    {
        #region [ # Defines & Variables ]
        private string ErrorPath = CommonVariables.ErrorPath;
        private string ErrorLogName = CommonVariables.ErrorLogName;

        private string message = string.Empty;
        private StringBuilder MessageBuilder;

        private int Admin = 0;
        string Subject = string.Empty;
        string Reciever = string.Empty; 
        private string[] AttachFiles;
        private string[] FileNames;

        private delegate void cleardgv(DataGridView dgv);
        private delegate void adddgv(DataGridView dgv, object[] data);
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-03 ] ///
        /// @ WinForm_Mail @                                                                                        ///
        ///     생성자로 컨트롤 및 변수를 초기화한다.                                                               ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public WinForm_Mail()
        {
            InitializeComponent();

            AttachFiles = new string[0];
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-03 ] ///
        /// @ WinForm_Mail @                                                                                        ///
        ///     생성자로 컨트롤 및 변수를 초기화하고 매개변수로 지정한 매알 수신 관리자를 설정한다.                 ///
        /// </summary>                                                                                              ///
        /// <param name="admin"> int : 수신 관리자 선택 정보 </param>                                               ///
        ///=========================================================================================================///
        public WinForm_Mail(int admin)
        {
            InitializeComponent();

            Admin = admin;
            AttachFiles = new string[0];
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-03 ] ///
        /// @ WinForm_Mail_Load @                                                                                   ///
        ///     폼이 생성되어 로드되는 시점에 호출되는 이벤트 핸들러로 메일 수신자 관련 정보를 설정한다.            ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void WinForm_Mail_Load(object sender, EventArgs e)
        {
            if (Admin == 0)
            {
                Subject = "기술 지원";
                Reciever = CommonVariables.Contact_Support;
                this.Text = "기술 지원 요청 메일을 보냅니다.";
            }
            else
            {
                Subject = "제품 관련";
                Reciever = CommonVariables.Contact_Develop;
                this.Text = "제품 관련 문의 메일을 보냅니다.";
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-03 ] ///
        /// @ m_btn_attachment_Click @                                                                              ///
        ///     파일 선택 다이얼로그를 통해 첨부할 파일을 선택한다.                                                 ///
        ///     파일 선택을 완료하면 화면 우측에 선택된 파일들의 이름을 표시한다.                                   ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_attachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AttachFiles = ofd.FileNames;
                FileNames = ofd.SafeFileNames;
            }

            ClearDGV(dataGridView1);
            AddDGV(dataGridView1, FileNames);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-03 ] ///
        /// @ m_btn_mailsend_Click @                                                                                ///
        ///     입력된 내용과 첨부 파일을 메일로 전송한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_mailsend_Click(object sender, EventArgs e)
        {
            WinForm_Message wfm;

            if (ValidateAddres(m_txb_retrunmail.Text) == true)
            {
                string[] recv = new string[] { Reciever };
                string[] rcc = new string[] { };

                bool result = CommonBase.SendMail(CommonBase.SMTPServer2, CommonBase.SMTPID, CommonBase.SMTPPW,
                    m_txb_retrunmail.Text, m_txb_sender.Text, recv, rcc, Subject, m_txb_body.Text, AttachFiles);

                if (result == false)
                {
                    wfm = new WinForm_Message("메일 전송에 실패했습니다.", "Error!", -1, true);
                    wfm.ShowDialog();
                }
                else
                    this.Close();
            }
            else
            {
                wfm = new WinForm_Message("메일 주소를 확인해주세요.", "Caution!", -1, true);
                wfm.ShowDialog();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-03 ] ///
        /// @ m_btn_cancel_Click @                                                                                  ///
        ///     창을 닫는다.                                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-03 ] ///
        /// @ ClearDGV @                                                                                            ///
        ///     매개변수로 지정한 데이터 그리드 뷰의 내용을 초기화한다.                                             ///
        ///     크로스 스레드 예외를 피하기 위한 델리게이트 함수이다.                                               ///
        /// </summary>                                                                                              ///
        /// <param name="dgv"> DataGridView : 초기화할 데이터 그리드 뷰 </param>                                    ///
        ///=========================================================================================================///
        private void ClearDGV(DataGridView dgv)
        {
            try
            {
                if (dgv.InvokeRequired == true)
                {
                    dgv.Invoke(new cleardgv(ClearDGV), dgv);
                }
                else
                {
                    dgv.Rows.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ClearDGV ]");

                if (dgv == null)
                {
                    MessageBuilder.AppendLine("# DataGridView : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# DataGridView : " + dgv.Name);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-03 ] ///
        /// @ AddDGV @                                                                                              ///
        ///     매개변수로 지정한 데이터 그리드 뷰에 데이터를 삽입한다.                                             ///
        ///     크로스 스레드 예외를 피하기 위한 델리게이트 함수이다.                                               ///
        /// </summary>                                                                                              ///
        /// <param name="dgv"> DataGridView : 데이터를 표시할 데이터 그리드 뷰 </param>                             ///
        /// <param name="data"> objectp[] : 그리드에 표시할 데이터 배열 </param>                                    ///
        ///=========================================================================================================///
        private void AddDGV(DataGridView dgv, object[] data)
        {
            try
            {
                if (dgv.InvokeRequired == true)
                {
                    dgv.Invoke(new adddgv(AddDGV), dgv, data);
                }
                else
                {
                    foreach (object o in data)
                    {
                        dgv.Rows.Add(o);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ClearDGV ]");

                if (dgv == null)
                {
                    MessageBuilder.AppendLine("# DataGridView : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# DataGridView : " + dgv.Name);
                }

                if (data == null)
                {
                    MessageBuilder.AppendLine("# data     : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# data     : " + data.ToString());
                }

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
        /// <summary>                                                                     [ Ver 1.01 / 2014-08-05 ] ///
        /// @ ValidateAddres @                                                                                      ///
        ///     입력된 이메일 주소의 양식을 확인하여 유효 여부를 반환한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="address"> string : 사용자 입력 이메일 주소 </param>                                        ///
        /// <returns> bool : 이메일 주소 유효 여부 </returns>                                                       ///
        ///=========================================================================================================///
        private bool ValidateAddres(string address)
        {
            bool result = false;

            if ((address.Contains("@") == true) && (address.Contains(".") == true))
            {
                result = true;
            }

            return result;
        }
        #endregion
    }
    ///=============================================================================== End of Class : WinForm_Mail =///
}
