using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-04-10 ] ///
    /// ▷ WinForm_Splash : Form ◁                                                                                 ///
    ///     소프트웨어 실행 시 메인 화면 이전에 표시되는 스플래쉬 폼을 표시한다.                                    ///
    ///     기본적인 동작은 3초 동안 투명해지는 방식으로 적용된다.                                                  ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-10 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class WinForm_Splash : Form
    {
        #region [ # Defines & Variables ]
        private readonly string ErrorPath = CommonVariables.ErrorPath;
        private readonly string ErrorLogName = CommonVariables.ErrorLogName;

        private string Message = string.Empty;
        private StringBuilder MessageBuilder;

        private delegate void setbackgroundimage(Control c, Image i);

        private Video video;

        private bool opacity = true;

        private readonly int Close_Time = 6;
        private int close_timer = 0;
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-10 ] ///
        /// @ WinForm_Splash @                                                                                      ///
        ///     기본 생성자로 컨트롤들을 초기화한다.                                                                ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public WinForm_Splash()
        {
            InitializeComponent();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2015-01-06 ] ///
        /// @ WinForm_Splash @                                                                                      ///
        ///     매개 변수로 지정된 영상을 표시한다.                                                                 ///
        /// </summary>                                                                                              ///
        /// <param name="source"> string : 영상 파일의 경로 </param>                                                ///
        ///=========================================================================================================///
        public WinForm_Splash(string source)
        {
            InitializeComponent();
            timer_close.Interval = 1000;
            opacity = false;
            panel1.Visible = true;

            video = new Video(source);
            video.Owner = panel1;
            video.Size = new Size(600, 300);
            video.Play();

            StartPosition = FormStartPosition.CenterScreen;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-10 ] ///
        /// @ WinForm_Splash @                                                                                      ///
        ///     스플래쉬 폼 생성자로 동작 시간을 매개변수를 통해 설정 가능하다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="interval"> int : 타이머 동작 시간 간격 </param>                                            ///
        ///=========================================================================================================///
        public WinForm_Splash(int interval)
        {
            InitializeComponent();

            timer_close.Interval = interval;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-10 ] ///
        /// @ WinForm_Splash @                                                                                      ///
        ///     스플래쉬 폼 생성자로 표시 이미지와 동작 시간을 매개변수를 통해 설정 가능하다.                       ///
        /// </summary>                                                                                              ///
        /// <param name="img"> Image : 스플래쉬 폼 배경 이미지 </param>                                             ///
        /// <param name="interval"> int : 타이머 동작 시간 간격 </param>                                            ///
        ///=========================================================================================================///
        public WinForm_Splash(Image img, int interval)
        {
            InitializeComponent();

            SetBackgroundImage(this, img);
            timer_close.Interval = interval;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-10 ] ///
        /// @ WinForm_Splash @                                                                                      ///
        ///     스플래쉬 폼 생성자로 폼의 크기와 표시 이미지, 동작 시간을 매개변수를 통해 설정 가능하다.            ///
        /// </summary>                                                                                              ///
        /// <param name="win_size"> Size : 스플래쉬 폼 크기 </param>                                                ///
        /// <param name="img"> Image : 스플래쉬 폼 배경 이미지 </param>                                             ///
        /// <param name="interval"> int : 타이머 동작 시간 간격 </param>                                            ///
        ///=========================================================================================================///
        public WinForm_Splash(Size win_size, Image img, int interval)
        {
            InitializeComponent();

            this.Size = win_size;
            SetBackgroundImage(this, img);
            timer_close.Interval = interval;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-10 ] ///
        /// @ WinForm_Splash_Load @                                                                                 ///
        ///     폼 생성 후 로드 시 호출되는 이벤트 핸들러로 타이머 동작을 시작한다.                                 ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void WinForm_Splash_Load(object sender, EventArgs e)
        {
            timer_close.Start();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-10 ] ///
        /// @ timer_close_Tick @                                                                                    ///
        ///     타이머 이벤트 핸들러로 지정된 주기마다 호출되며 폼의 투명도를 조절한다.                             ///
        ///     스플래쉬 폼의 투명도가 0(투명)이 되면 타이머를 정지하고 폼을 닫는다.                                ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void timer_close_Tick(object sender, EventArgs e)
        {
            if (opacity == true)
            {
                this.Opacity -= 0.01;

                if (this.Opacity == 0)
                {
                    timer_close.Stop();
                    this.Close();
                }
            }
            else
            {
                close_timer++;

                if (close_timer == Close_Time)
                {
                    timer_close.Stop();
                    this.Close();
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-10 ] ///
        /// @ SetBackgroundImage @                                                                                  ///
        ///     매개변수로 지정된 컨트롤의 배경 이미지를 매개변수로 전달된 이미지로 설정한다.                       ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="c"> Control : 컨트롤 객체 </param>                                                         ///
        /// <param name="i"> Image : 변경할 이미지 </param>                                                         ///
        ///=========================================================================================================///
        private void SetBackgroundImage(Control c, Image i)
        {
            try
            {
                if (c.InvokeRequired == true)
                {
                    c.Invoke(new setbackgroundimage(SetBackgroundImage), c, i);
                }
                else
                {
                    c.BackgroundImage = i;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetBackgroundImage ]");

                if (c == null)
                {
                    MessageBuilder.AppendLine("# Control  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Control  : " + c.Name);
                }

                if (i == null)
                {
                    MessageBuilder.AppendLine("# Image    : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Image    : ");
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
    ///============================================================================= End of Class : WinForm_Splash =///
}
