using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.02 / 2018-12-06 ] ///
    /// ▷ WinForm_Message : Form ◁                                                                                ///
    ///     윈도우 폼을 상속하여 만든 메세지 폼 클래스로 기본 윈도우 폼의 기능에                                    /// 
    ///     일정 시간 표시 후 자동으로 종료되는 기능을 추가하였다.                                                  ///
    ///     메시지 폼을 생성할 때 메시지 본문을 텍스트 또는 이미지로 표시할 수 있다.                                ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-14 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2018-12-05 ]                                                                                   ///
    ///     ▶ 배경 이미지, 메시지, 캡션 동시 표시 및 배경 이미지 레이아웃 설정 추가                                ///
    /// [ Ver 1.02 / 2018-12-06 ]                                                                                   ///
    ///     ▶ 텍스트 폰트, 색상 및 내용 설정 추가                                                                  ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class WinForm_Message : Form
    {
        #region [ # Defines & Variables ]
        private string ErrorPath = CommonVariables.ErrorPath;
        private string ErrorLogName = CommonVariables.ErrorLogName;

        private string MSG = string.Empty;
        private string CAP = string.Empty;
        private string BTM = "확인";
        private int close_time = 5;
        private int time_checker = 0;

        private delegate void changeLabelText(Label l, string msg);
        private delegate void changeCaption(WinForm_Message mf, string msg);
        private delegate void changeButtonText(Button btn, string msg);
        private delegate void changebackcolor(Color color);
        private delegate void changefontcolor(Control c, Color color);
        private delegate void changefontstyle(Control c, Font f);
        private delegate void changelabelpoint(Point p);

        private string message = string.Empty;
        private StringBuilder MessageBuilder;

        private readonly new Point Location = new Point(12, 34);

        public enum FontTarget { All, Caption, Message, Button };
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ WinForm_Message @                                                                                     ///
        ///     메시지 폼 생성자로 매개변수로 전달된 속성을 설정하여 표시한다.                                      ///
        /// </summary>                                                                                              ///
        /// <param name="message"> string : 메시지 폼 본문 표시 내용 </param>                                       ///
        /// <param name="caption"> string : 메시지 폼 상단 표시 내용 </param>                                       ///
        /// <param name="button"> bool : 버튼 표시 여부 </param>                                                    ///
        ///=========================================================================================================///
        public WinForm_Message(string message, string caption, bool button)
        {
            InitializeComponent();

            MSG = message;
            CAP = caption;

            m_btn_ok.Visible = button;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ WinForm_Message @                                                                                     ///
        ///     메시지 폼 생성자로 매개변수로 전달된 속성을 설정하여 표시한다.                                      ///
        /// </summary>                                                                                              ///
        /// <param name="message"> string : 메시지 폼 본문 표시 내용 </param>                                       ///
        /// <param name="caption"> string : 메시지 폼 상단 표시 내용 </param>                                       ///
        /// <param name="time"> int : 메시지 폼 표시 시간 </param>                                                  ///
        /// <param name="button"> bool : 버튼 표시 여부 </param>                                                    ///
        ///=========================================================================================================///
        public WinForm_Message(string message, string caption, int time, bool button)
        {
            InitializeComponent();

            MSG = message;
            CAP = caption;
            close_time = time;

            m_btn_ok.Visible = button;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ WinForm_Message @                                                                                     ///
        ///     메시지 폼 생성자로 매개변수로 전달된 속성을 설정하여 표시한다.                                      ///
        /// </summary>                                                                                              ///
        /// <param name="background"> Image : 메시지 폼 배경 이미지 </param>                                        ///
        /// <param name="caption"> string : 메시지 폼 상단 표시 내용 </param>                                       ///
        /// <param name="button"> bool : 버튼 표시 여부 </param>                                                    ///
        ///=========================================================================================================///
        public WinForm_Message(Image background, string caption, bool button)
        {
            InitializeComponent();

            this.BackgroundImage = background;
            CAP = caption;

            m_btn_ok.Visible = button;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ WinForm_Message @                                                                                     ///
        ///     메시지 폼 생성자로 매개변수로 전달된 속성을 설정하여 표시한다.                                      ///
        /// </summary>                                                                                              ///
        /// <param name="background"> Image : 메시지 폼 배경 이미지 </param>                                        ///
        /// <param name="caption"> string : 메시지 폼 상단 표시 내용 </param>                                       ///
        /// <param name="time"> int : 메시지 폼 표시 시간 </param>                                                  ///
        /// <param name="button"> bool : 버튼 표시 여부 </param>                                                    ///
        ///=========================================================================================================///
        public WinForm_Message(Image background, string caption, int time, bool button)
        {
            InitializeComponent();

            this.BackgroundImage = background;
            CAP = caption;
            close_time = time;

            m_btn_ok.Visible = button;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ WinForm_Message_Load @                                                                                ///
        ///     메시지 폼이 생성된 후 호출되는 이벤트 핸들러로 속성 값들을 컨트롤에 설정한다.                       ///
        ///     자동 종료 타이머를 시작한다. (기본 설정 시간 5초)                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void WinForm_Message_Load(object sender, EventArgs e)
        {
            ChangeLabelText(label_message, MSG);
            ChangeCaption(this, CAP);
            ChangeButtonText(m_btn_ok, BTM + "(" + close_time + ")");

            if (close_time != -1)
            {
                timer_close.Start();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ m_btn_ok_Click @                                                                                      ///
        ///     메시지 폼의 버튼 클릭 시 호출되는 이벤트 핸들러로 종료 시간에 관계없이 메시지 폼을 종료한다.        ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ timer_close_Tick @                                                                                    ///
        ///     1초 주기로 호출되는 타이머 이벤트 핸들러로 설정된 종료 시각이 되면 메시지 폼을 종료한다.            ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void timer_close_Tick(object sender, EventArgs e)
        {
            time_checker++;

            ChangeButtonText(m_btn_ok, BTM + "(" + (close_time - time_checker) + ")");

            if (time_checker == close_time)
            {
                this.Close();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ SetLabelText @                                                                                        ///
        ///     매개변수로 전달된 메시지를 지정된 라벨 컨트롤의 텍스트 속성에 설정한다.                             ///
        /// </summary>                                                                                              ///
        /// <param name="l"> Label : 메시지를 설정할 라벨 컨트롤 </param>                                           ///
        /// <param name="msg"> string : 메시지 </param>                                                             ///
        ///=========================================================================================================///
        private void ChangeLabelText(Label l, string msg)
        {
            try
            {
                if (l.InvokeRequired == true)
                {
                    l.BeginInvoke(new changeLabelText(ChangeLabelText), l, msg);
                }
                else
                {
                    l.Text = msg;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ChangeLabelText ]");

                if (l == null)
                {
                    MessageBuilder.AppendLine("# Label    : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Label    : " + l.Text);
                }

                if (string.IsNullOrEmpty(msg) == true)
                {
                    MessageBuilder.AppendLine("# message  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# message  : " + msg);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ SetCaption @                                                                                          ///
        ///     매개변수로 전달된 메시지를 메시지 폼의 텍스트 속성에 설정한다.                                      ///
        /// </summary>                                                                                              ///
        /// <param name="mf"> WinForm_Message : 메시지 폼 객체 </param>                                             ///
        /// <param name="msg"> string : 메시지 </param>                                                             ///
        ///=========================================================================================================///
        private void ChangeCaption(WinForm_Message mf, string msg)
        {
            try
            {
                if (mf.InvokeRequired == true)
                {
                    mf.BeginInvoke(new changeCaption(ChangeCaption), mf, msg);
                }
                else
                {
                    mf.Text = msg;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ChangeCaption ]");

                if (mf == null)
                {
                    MessageBuilder.AppendLine("# winform  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# winform  : " + mf.Name);
                }

                if (string.IsNullOrEmpty(msg) == true)
                {
                    MessageBuilder.AppendLine("# message  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# message  : " + msg);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ SetButtonText @                                                                                       ///
        ///     매개변수로 전달된 메시지를 버튼의 텍스트 속성에 설정한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="btn"> Button : 메시지를 설정할 버튼 컨트롤 </param>                                        ///
        /// <param name="msg"> string : 메시지</param>                                                              ///
        ///=========================================================================================================///
        private void ChangeButtonText(Button btn, string msg)
        {
            try
            {
                if (btn.InvokeRequired == true)
                {
                    btn.BeginInvoke(new changeButtonText(ChangeButtonText), btn, msg);
                }
                else
                {
                    btn.Text = msg;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ChangeButtonText ] ");

                if (btn == null)
                {
                    MessageBuilder.AppendLine("# button   : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# button   : " + btn.Name);
                }

                if (string.IsNullOrEmpty(msg) == true)
                {
                    MessageBuilder.AppendLine("# message  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# message  : " + msg);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ WinForm_Message_FormClosing @                                                                         ///
        ///     메시지 폼이 종료되는 시점에 호출되는 이벤트 핸들러로 타이머를 중단시키고                            ///
        ///     다이얼로그 결과 속성을 설정한다.                                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void WinForm_Message_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer_close.Stop();
            this.DialogResult = DialogResult.OK;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ ChangeBackColor @                                                                                     ///
        ///     메시지 폼의 배경 색상을 변경하며 크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.            ///
        /// </summary>                                                                                              ///
        /// <param name="color"> Color : 배경 색상 </param>                                                         ///
        ///=========================================================================================================///
        public void ChangeBackColor(Color color)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    this.Invoke(new changebackcolor(ChangeBackColor), color);
                }
                else
                {
                    this.BackColor = color;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ChangeBackColor ]");

                if (color == null)
                {
                    MessageBuilder.AppendLine("# Color    : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Color    : " + color.Name);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ ChangeFontColor @                                                                                     ///
        ///     매개변수로 지정한 컨트롤의 폰트 색상을 변경한다.                                                    ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="c"> Control : 폰트 색상 변경 대상 </param>                                                 ///
        /// <param name="color"> Color : 폰트 색상 </param>                                                         ///
        ///=========================================================================================================///
        private void ChangeFontColor(Control c, Color color)
        {
            try
            {
                if (c.InvokeRequired == true)
                {
                    c.Invoke(new changefontcolor(ChangeFontColor), c, color);
                }
                else
                {
                    c.ForeColor = color;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ChangeFontColor ]");

                if (c == null)
                {
                    MessageBuilder.AppendLine("# Control  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Control  : " + c.Name);
                }

                if (color == null)
                {
                    MessageBuilder.AppendLine("# Color    : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Color    : " + color.Name);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ ChangeFontStyle @                                                                                     ///
        ///     매개변수로 지정된 컨트롤의 폰트 정보를 변경한다.                                                    ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="c"> Control : 폰트 변경 대상 </param>                                                      ///
        /// <param name="f"> Font : 폰트 정보 </param>                                                              ///
        ///=========================================================================================================///
        private void ChangeFontStyle(Control c, Font f)
        {
            try
            {
                if (c.InvokeRequired == true)
                {
                    c.Invoke(new changefontstyle(ChangeFontStyle), c, f);
                }
                else
                {
                    c.Font = f;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ChangeFontStyle ]");

                if (c == null)
                {
                    MessageBuilder.AppendLine("# Control  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Control  : " + c.Name);
                }

                if (f == null)
                {
                    MessageBuilder.AppendLine("# Font     : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Font     : " + f.Name);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ MultiLineMode @                                                                                       ///
        ///     메시지 폼의 메시지 내용이 멀티 라인 여부에 따라 라벨의 위치를 변경한다.                             ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 멀티 라인 여부 </param>                                                      ///
        ///=========================================================================================================///
        public void MultiLineMode(bool mode)
        {
            if (mode == true)
            {
                ChangeLabelPoint(new Point(12, 9));
            }
            else
            {
                ChangeLabelPoint(Location);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] /// 
        /// @ ChangeLabelPoint @                                                                                    ///
        ///     메시지 라벨의 위치를 매개변수로 지정한 위치로 변경한다.                                             ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="p"> Point : 라벨 위치 </param>                                                             ///
        ///=========================================================================================================///
        private void ChangeLabelPoint(Point p)
        {
            try
            {
                if (label_message.InvokeRequired == true)
                {
                    label_message.Invoke(new changelabelpoint(ChangeLabelPoint), p);
                }
                else
                {
                    label_message.Location = p;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ChangeLabelPoint ]");

                if (p == null)
                {
                    MessageBuilder.AppendLine("# Point    : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Point    : " + p.X + ", " + p.Y);
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
        /// <summary>                                                                     [ Ver 1.01 / 2018-12-05 ] ///
        /// @ WinForm_Message @                                                                                     ///
        ///     메시지 폼 생성자로 매개변수로 전달된 속성을 설정하여 표시한다.                                      ///
        /// </summary>                                                                                              ///
        /// <param name="background"> Image : 메시지 폼 배경 이미지 </param>                                        ///
        /// <param name="message"> string : 메시지 폼 본문 표시 내용 </param>                                       ///
        /// <param name="caption"> string : 메시지 폼 상단 표시 내용 </param>                                       ///
        /// <param name="time"> int : 메시지 폼 표시 시간 </param>                                                  ///
        /// <param name="button"> bool : 버튼 표시 여부 </param>                                                    ///
        ///=========================================================================================================///
        public WinForm_Message(Image background, string message, string caption, int time, bool button)
        {
            InitializeComponent();

            this.BackgroundImage = background;
            MSG = message;
            CAP = caption;
            close_time = time;

            m_btn_ok.Visible = button;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2018-12-05 ] ///
        /// @ SetBackgroudImageLayout @                                                                             ///
        ///     배경 이미지를 표시하기 위한 레이아웃을 지정한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="layout"> ImageLayout : 배경 이미지 표시 레이아웃 </param>                                  ///
        ///=========================================================================================================///
        public void SetBackgroudImageLayout(ImageLayout layout)
        {
            this.BackgroundImageLayout = layout;
        }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2018-12-06 ] ///
        /// @ SetFontColor @                                                                                        ///
        ///     메시지 폼에 표시되는 텍스트의 색상을 설정한다.                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="target"> FontTarget : 설정 대상 </param>                                                   ///
        /// <param name="c"> Color : 설정 색상 </param>                                                             ///
        ///=========================================================================================================///
        public void SetFontColor(FontTarget target, Color c)
        {
            if (target == FontTarget.All)
            {
                ChangeFontColor(this, c);
            }
            else if (target == FontTarget.Caption)
            {
                ChangeFontColor(this, c);
                ChangeFontColor(label_message, SystemColors.ControlText);
                ChangeFontColor(m_btn_ok, SystemColors.ControlText);
            }
            else if (target == FontTarget.Message)
            {
                ChangeFontColor(label_message, c);
            }
            else if (target == FontTarget.Button)
            {
                ChangeFontColor(m_btn_ok, c);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2018-12-06 ] ///
        /// @ SetFontSytle @                                                                                        ///
        ///     메시지 폼의 폰트를 설정한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="target"> FontTarget : 설정 대상 </param>                                                   ///
        /// <param name="f"> Font : 폰트 정보 </param>                                                              ///
        ///=========================================================================================================///
        public void SetFontSytle(FontTarget target, Font f)
        {
            if (target == FontTarget.All)
            {
                ChangeFontStyle(this, f);
            }
            else if (target == FontTarget.Caption)
            {
                Font tmp = label_message.Font;

                ChangeFontStyle(this, f);
                ChangeFontStyle(label_message, tmp);
                ChangeFontStyle(m_btn_ok, tmp);
            }
            else if (target == FontTarget.Message)
            {
                ChangeFontStyle(label_message, f);
            }
            else if (target == FontTarget.Button)
            {
                ChangeFontStyle(m_btn_ok, f);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2018-12-06 ] ///
        /// @ SetCaptionText @                                                                                      ///
        ///     메시지 폼에 표시할 캡션 내용을 설정한다.                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="caption"> string : 캡션 내용 </param>                                                      ///
        ///=========================================================================================================///
        public void SetCaptionText(string caption)
        {
            CAP = caption;
            ChangeCaption(this, CAP);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2018-12-06 ] ///
        /// @ SetMessageText @                                                                                      ///
        ///     메시지 폼에 표시할 메시지 내용을 설정한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <param name="message"> string : 메시지 내용 </param>                                                    ///
        ///=========================================================================================================///
        public void SetMessageText(string message)
        {
            MSG = message;
            ChangeLabelText(label_message, MSG);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2018-12-06 ] ///
        /// @ SetButtonText @                                                                                       ///
        ///     메시지 폼의 버튼 텍스트 내용을 설정한다.                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="comment"> string : 설정 텍스트 </param>                                                    ///
        ///=========================================================================================================///
        public void SetButtonText(string comment)
        {
            BTM = comment;
            ChangeButtonText(m_btn_ok, BTM + "(" + close_time + ")");
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2018-12-06 ] ///
        /// @ SetShowTime @                                                                                         ///
        ///     메시지 폼이 표시되는 시간을 설정한다.                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="sec"> int : 표시 시간 </param>                                                             ///
        ///=========================================================================================================///
        public void SetShowTime(int sec)
        {
            close_time = sec;
        }
        #endregion
    }
    ///============================================================================ End of Class : WinForm_Message =///
}
