using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-04-10 ] ///
    /// ▷ WinForm_ImageSave : Form ◁                                                                              ///
    ///     이미지 저장 관련 기능을 제공하는 클래스로 이미지 포맷, 해상도, 저장 경로를 지정할 수 있다.              ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-10 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class WinForm_ImageSave : Form
    {
        #region [ # Defines & Variables ]
        private string ErrorPath = CommonVariables.ErrorPath;
        private string ErrorLogName = CommonVariables.ErrorLogName; 
        
        private string Message = string.Empty;
        private StringBuilder MessageBuilder;

        private ImageFormat img_format = ImageFormat.Bmp;
        private IntPtr SourceHandle;
        private int img_width = 0;
        private int img_height = 0;
        private bool setoption = false;
        private bool changeresoultion = false;
        private string FilePath = string.Empty;
        private string FileName = string.Empty;
        private string FileExtension = ".bmp";

        public static event SetOptionHandler SetOption;
        public delegate void SetOptionHandler();

        private delegate void setbuttontext(Button btn, string msg);
        private delegate void setcontrolenable(Control c, bool enable);
        private delegate void settextboxtext(TextBox tb, string msg);
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ WinForm_ImageSave @                                                                                   ///
        ///     생성자로 이미지 저장 관련 설정 모드로 동작한다.                                                     ///
        ///     이미지를 캡쳐할 대상을 알 수 없기 때문이다.                                                         ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public WinForm_ImageSave()
        {
            InitializeComponent();
            CaptureWindow(SourceHandle);
            setoption = true;
            SetButtonText(m_btn_save, "이미지 저장");
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ WinForm_ImageSave @                                                                                   ///
        ///     생성자로 이미지 저장 설정 및 파일 저장을 수행한다.                                                  ///
        ///     매개변수로 이미지를 캡쳐할 대상을 지정한다.                                                         ///
        /// </summary>                                                                                              ///
        /// <param name="handle"> IntPtr : 이미지 캡쳐 대상 식별자 </param>                                         ///
        ///=========================================================================================================///
        public WinForm_ImageSave(IntPtr handle)
        {
            InitializeComponent();

            SourceHandle = handle;
            CaptureWindow(SourceHandle);
            setoption = false;
            SetButtonText(m_btn_save, "이미지 저장");
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-10 ] ///
        /// @ WinForm_ImageSave_Load @                                                                              ///
        ///     폼 생성 후 로드되는 시점에 호출되는 이벤트 핸들러로 컨트롤의 초기값을 설정한다.                     ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void WinForm_ImageSave_Load(object sender, EventArgs e)
        {
            SetTextBoxText(m_txb_path, CommonVariables.DownPath);
        }
 
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ SetButtonText @                                                                                       ///
        ///     매개변수로 지정한 버튼의 텍스트를 지정한 내용으로 변경한다.                                         ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="btn"> Button : 버튼 객체 </param>                                                          ///
        /// <param name="msg"> string : 변경 메시지 </param>                                                        ///
        ///=========================================================================================================///
        private void SetButtonText(Button btn, string msg)
        {
            try
            {
                if (btn.InvokeRequired == true)
                {
                    btn.Invoke(new setbuttontext(SetButtonText), btn, msg);
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
                MessageBuilder.AppendLine("[ Function : SetButtonText ]");

                if (btn == null)
                {
                    MessageBuilder.AppendLine("# Button   : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Button   : " + btn.Name);
                }

                if (string.IsNullOrEmpty(msg) == true)
                {
                    MessageBuilder.AppendLine("# msg      : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# msg      : " + msg);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ SetControlEnable @                                                                                    ///
        ///     매개변수로 지정한 컨트롤의 활성화 여부를 설정한다.                                                  ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="c"> Control : 컨트롤 객체 </param>                                                         ///
        /// <param name="enable"> bool : 활성화 여부 </param>                                                       ///
        ///=========================================================================================================///
        private void SetControlEnable(Control c, bool enable)
        {
            try
            {
                if (c.InvokeRequired == true)
                {
                    c.Invoke(new setcontrolenable(SetControlEnable), c, enable);
                }
                else
                {
                    c.Enabled = enable;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetControlEnable ]");

                if (c == null)
                {
                    MessageBuilder.AppendLine("# Control  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Control  : " + c.Name);
                }

                MessageBuilder.AppendLine("# enable   : " + enable.ToString());
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ SetTextBoxText @                                                                                      ///
        ///     매개변수로 지정한 텍스트 박스의 내용을 지정한 내용으로 설정한다.                                    ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="tb"> TextBox : 텍스트 박스 객체 </param>                                                   ///
        /// <param name="msg"> stirng : 변경 메시지 </param>                                                        ///
        ///=========================================================================================================///
        private void SetTextBoxText(TextBox tb, string msg)
        {
            try
            {
                if (tb.InvokeRequired == true)
                {
                    tb.Invoke(new settextboxtext(SetTextBoxText), tb, msg);
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
                MessageBuilder.AppendLine("[ Function : SetTextBoxText ]");

                if (tb == null)
                {
                    MessageBuilder.AppendLine("# TextBox  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# TextBox  : " + tb.Text);
                }

                if (string.IsNullOrEmpty(msg) == true)
                {
                    MessageBuilder.AppendLine("# msg      : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# msg      : " + msg);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ CaptureWindow @                                                                                       ///
        ///     특정 창 / 폼의 화면을 캡쳐하여 이미지로 반환한다.                                                   ///
        ///     매개변수로 전달된 핸들을 이용하여 대상을 식별한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="handle"> IntPtr : 창 / 폼의 식별자 </param>                                                ///
        /// <returns> Image : 캡쳐 이미지 </returns>                                                                ///
        ///=========================================================================================================///
        public Image CaptureWindow(IntPtr handle)
        {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            img_width = windowRect.right - windowRect.left;
            img_height = windowRect.bottom - windowRect.top;
            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, img_width, img_height);
            // select the bitmap object
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            // bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, img_width, img_height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            // restore selection
            GDI32.SelectObject(hdcDest, hOld);
            // clean up
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            // get a .NET image object for it
            Image img = Image.FromHbitmap(hBitmap);
            // free up the Bitmap object
            GDI32.DeleteObject(hBitmap);
            return img;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ SaveImage @                                                                                           ///
        ///     특정 창 / 폼의 화면을 이미지로 저장한다.                                                            ///
        ///     매개변수로 전달된 핸들을 이용하여 대상을 식별한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="handle"> IntPtr : 창 / 폼의 식별자 </param>                                                ///
        ///=========================================================================================================///
        public void SaveImage(IntPtr handle)
        {
            Image img = CaptureWindow(handle);

            if (changeresoultion == false)
            {
                img.Save(FilePath + "\\" + GetFileName(), img_format);
            }
            else
            {
                Bitmap bt = new Bitmap(img, img_width, img_height);
                bt.Save(FilePath + "\\" + GetFileName(), img_format);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ m_txb_width_KeyPress @                                                                                ///
        ///     텍스트 박스에서 키가 눌러지면 호출되는 이벤트 핸들러로                                              ///
        ///     해당 텍스트 박스의 입력이 숫자만 가능하도록 제한한다.                                               ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_txb_width_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != '\b')) e.Handled = true;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ m_ckb_changeresolution_Click @                                                                        ///
        ///     체크 박스를 클릭하면 호출되는 이벤트 핸들러로 해상도 변경 관련 컨트롤들을 활성화한다.               ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_ckb_changeresolution_Click(object sender, EventArgs e)
        {
            changeresoultion = m_ckb_changeresolution.Checked;
            SetControlEnable(m_cb_resolution, changeresoultion);
            SetControlEnable(m_ckb_define, changeresoultion);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ m_ckb_define_Click @                                                                                  ///
        ///     체크 박스를 클릭하면 호출되는 이벤트 핸들러로 해상도를 사용자가 직접 입력할 수 있도록               ///
        ///     입력 텍스트 박스들을 활성화한다.                                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_ckb_define_Click(object sender, EventArgs e)
        {
            SetControlEnable(m_txb_width, m_ckb_define.Checked);
            SetControlEnable(m_txb_height, m_ckb_define.Checked);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ GetResolution @                                                                                       ///
        ///     이미지 저장 해상도 정보를 반환한다.                                                                 ///
        /// </summary>                                                                                              ///
        /// <returns> int[] : 이미지 해상도 </returns>                                                              ///
        ///=========================================================================================================///
        public int[] GetResolution()
        {
            int[] resolution = new int[2];

            resolution[0] = img_width;
            resolution[1] = img_height;

            return resolution;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ GetSavePath @                                                                                         ///
        ///     이미지 파일 저장 경로를 반환한다.                                                                   ///
        /// </summary>                                                                                              ///
        /// <returns> string : 이미지 파일 저장 경로 </returns>                                                     ///
        ///=========================================================================================================///
        public string GetSavePath()
        {
            return FilePath;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ GetFileName @                                                                                         ///
        ///     이미지 파일 이름을 반환한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <returns> string : 이미지 파일 이름 </returns>                                                          ///
        ///=========================================================================================================///
        public string GetFileName()
        {
            if (string.IsNullOrEmpty(FileName) == true)
            {
                DateTime now = DateTime.Now;

                FileName = now.Year.ToString("0000") + now.Month.ToString("00") + now.Day.ToString("00")
                    + " " + now.Hour.ToString("00") + now.Minute.ToString("00") + now.Second.ToString("00");
            }

            return (FileName + FileExtension);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ GetFormat @                                                                                           ///
        ///     이미지 파일의 저장 포맷 정보를 반환한다.                                                            ///
        /// </summary>                                                                                              ///
        /// <returns> ImageFormat : 이미지 파일 포맷 </returns>                                                     ///
        ///=========================================================================================================///
        public ImageFormat GetFormat()
        {
            return img_format;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ m_btn_path_Click @                                                                                    ///
        ///     이미지 파일 저장 경로를 변경한다.                                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                SetTextBoxText(m_txb_filename, fbd.SelectedPath);
                FilePath = fbd.SelectedPath;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ m_btn_save_Click @                                                                                    ///
        ///     버튼 클릭 시 호출되는 이벤트 핸들러로 이미지 캡쳐 대상의 식별자가 유효하면                          ///
        ///     이미지를 파일로 저장하고 그렇지 않으면 설정 완료를 알리는 이벤트를 발생시킨다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_save_Click(object sender, EventArgs e)
        {
            if (setoption == true)
            {
                SetOption();
            }
            else
            {
                SaveImage(SourceHandle);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ m_rbtn_bmp_Click @                                                                                    ///
        ///     라디오 버튼 클릭 시 호출되는 이벤트 핸들러로 이미지 처리 모드를 BMP로 설정한다.                     ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_rbtn_bmp_Click(object sender, EventArgs e)
        {
            img_format = ImageFormat.Bmp;
            FileExtension = ".bmp";
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ m_rbtn_jpg_Click @                                                                                    ///
        ///     라디오 버튼 클릭 시 호출되는 이벤트 핸들러로 이미지 처리 모드를 JPG로 설정한다.                     ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_rbtn_jpg_Click(object sender, EventArgs e)
        {
            img_format = ImageFormat.Jpeg;
            FileExtension = ".jpg";
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ m_rbtn_png_Click @                                                                                    ///
        ///     라디오 버튼 클릭 시 호출되는 이벤트 핸들러로 이미지 처리 모드를 PNG로 설정한다.                     ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_rbtn_png_Click(object sender, EventArgs e)
        {
            img_format = ImageFormat.Png;
            FileExtension = ".png";
        }
        #endregion
    }
    ///========================================================================== End of Class : WinForm_ImageSave =///

    ///=============================================================================================================///
    /// <summary>                                                                                                   ///
    /// Helper class containing GDI32 API functions                                                                 ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class GDI32
    {
        public const int SRCCOPY = 0x00CC0020;
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
            int nWidth, int nHeight, IntPtr hObjectSource,
            int nXSrc, int nYSrc, int dwRop);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
            int nHeight);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
    }
    ///====================================================================================== End of Class : GDI32 =///

    ///=============================================================================================================///
    /// <summary>                                                                                                   ///
    /// Helper class containing User32 API functions                                                                ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
    }
    ///===================================================================================== End of Class : User32 =///
}
