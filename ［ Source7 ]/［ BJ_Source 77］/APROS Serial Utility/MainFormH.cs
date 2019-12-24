using System.Collections.Generic;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using Apros_Class_Library_Base;
using System.IO;
using System;
using System.Text;
using System.Reflection;
using System.Drawing;

namespace APROS_Serial_Utility
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.03 / 2017-12-01 ] ///
    /// ▷ MainForm : Form ◁                                                                                       ///
    ///     변수 및 함수 선언, 정의                                                                                 ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2017-05-31 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2017-07-05 ]                                                                                   ///
    ///     ▶ TabItem에서 Tab 닫기 추가                                                                            ///
    /// [ Ver 1.02 / 2017-11-10 ]                                                                                   ///
    ///     ▶ 리로드에서 DLL 파일 변경 사항 체크 UI 반영                                                           ///
    /// [ Ver 1.03 / 2017-12-01 ]                                                                                   ///
    ///     ▶ UI 확장 (1200:800 -> 1600:900) 리뉴얼                                                                ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class MainForm : Form
    {
        #region [ # Defines & Variables ]
        // 에러 로그 관련 변수
        private readonly string ErrorPath = CommonBase.ErrorPath;
        private readonly string ErrorName = CommonBase.ErrorLogName;
        private StringBuilder MessageBuilder;
        private string ErrMessage = string.Empty;

        // Cinfig 파일 경로
        private readonly string ConfigPath = CommonBase.ConfigPath;

        // 데이터 파일 경로
        private string DataPath = CommonBase.DataPath;

        // 버전 상수
        private readonly string Version = "APROS Comm Utility Beta - Ver 1.03.04.1201";

        // 통신 패널 제어 관련 변수
        private List<TabItem> TabItems = new List<TabItem>();
        private List<TabControlPanel> TabCons = new List<TabControlPanel>();

        private int LastIDX = 0;

        private int PanCnt = 0;
        private int PATCnt = 0;
        private int PLRCnt = 0;

        // SKT LoRa 관련 데이터 저장 변수
        //private List<string> AppEUI = new List<string>();
        //private List<string> LTID = new List<string>();
        //private List<string> uKey = new List<string>();
        private CommonConfig Configs = new CommonConfig();

        // 동적 통신 패널 제어 관련 변수
        private List<Assembly> DllLoader = new List<Assembly>();
        private RibbonBar ribbonBarExtra = null;

        // CT Sensor Pan
        // 타이머 제어 변수
        private bool TimerOn = false;
        // 웨이브폼 그래프
        private MultiSetGraph WaveGraph;
        private int g_cnt = 0;
        #endregion

        #region [ # Initializer ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ ReloadConfig @                                                                                        ///
        ///     Config 파일로부터 SKT LoRa 통신에 필요한 정보를 읽어들인다.                                         ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void ReloadConfig()
        {
            Configs.InitConfig(CommonBase.ConfigPath + "\\Config.ini");
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2017-11-10 ] ///
        /// @ CheckingPanel @                                                                                       ///
        ///     Append Panel 폴더에 패널 DLL 파일이 존재하면 해당 패널을 추가하기 위한 버튼을 화면에 추가한다.      ///
        ///                                                                                                         ///
        /// [ Ver 1.00 / 2017-05-31 ]                                                                               ///
        ///     ▶ 초기버전                                                                                         ///
        /// [ Ver 1.02 / 2017-11-10 ]                                                                               ///
        ///     ▶ 리로드에서 DLL 파일 변경 사항 체크 UI 반영                                                       ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void CheckingPanel()
        {
            try
            {
                string[] files = Directory.GetFiles(Application.StartupPath + "\\[Append Panel]", "*.dll");

                if (ribbonBarExtra != null)
                {
                    for (int i = 0; i < ribbonBarExtra.Items.Count; i++)
                    {
                        ribbonBarExtra.Items[i].Dispose();
                    }

                    ribbonBarExtra.Items.Clear();
                    DllLoader.Clear();

                    ribbonPanel1.Controls.Remove(ribbonBarExtra);
                    ribbonBarExtra.Dispose();
                    ribbonBarExtra = null;
                }

                if (ribbonBarExtra == null)
                {
                    ribbonBarExtra = new RibbonBar();
                    ribbonBarExtra.Text = "Extra Panel";
                    ribbonBarExtra.AutoOverflowEnabled = true;
                    ribbonBarExtra.BackgroundMouseOverStyle.CornerType = eCornerType.Square;
                    ribbonBarExtra.BackgroundStyle.CornerType = eCornerType.Square;
                    ribbonBarExtra.ContainerControlProcessDialogKey = true;
                    ribbonBarExtra.Dock = DockStyle.Left;
                    ribbonBarExtra.DragDropSupport = true;
                    ribbonBarExtra.Location = new Point(503, 0);
                    ribbonBarExtra.Size = new Size();
                    ribbonBarExtra.Name = "ribbonBarExtra";
                    ribbonBarExtra.Style = eDotNetBarStyle.StyleManagerControlled;
                    ribbonBarExtra.TabIndex = 3;

                    ribbonPanel1.Controls.Add(ribbonBarExtra);

                    SetTitleStyle(ribbonBarExtra);
                }

                foreach (string file in files)
                {
                    try
                    {
                        Assembly assem = Assembly.LoadFile(file);
                        DllLoader.Add(assem);

                        Module[] modules = DllLoader[DllLoader.IndexOf(assem)].GetModules();
                        string name = modules[0].Name;
                        string[] sub = name.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

                        ButtonItem BI = new ButtonItem();
                        BI.ImagePosition = eImagePosition.Top;
                        BI.Name = sub[0] + DateTime.Now.ToString("HHmmss");
                        BI.SubItemsExpandWidth = 14;
                        BI.Symbol = "";
                        BI.SymbolColor = Color.Orange;
                        BI.SymbolSize = 35F;
                        BI.Text = sub[0];
                        BI.Click += m_btn_AppendPanel_Click;

                        ribbonBarExtra.Items.Add(BI);

                        ribbonControl1.PerformLayout();
                    }
                    catch (Exception e)
                    {
                        MessageBuilder = new StringBuilder();
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine("[ Function : CheckingPanel - DLL Load ]");
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine(e.Message);
                        MessageBuilder.AppendLine();

                        ErrMessage = MessageBuilder.ToString();

                        FileManager.SetFileExtension(".dat");
                        FileManager.LogWriter(ErrMessage, ErrorPath, ErrorName, true, true, true, true, true);
                    }
                }

                ribbonBarExtra.Width = DllLoader.Count * 210;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CheckingPanel ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                ErrMessage = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(ErrMessage, ErrorPath, ErrorName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ SetTitleStyle @                                                                                       ///
        ///     RibbonBar의 속성을 설정한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="ribbonBar"> RibbonBar : 설정 대상 객체 </param>                                            ///
        ///=========================================================================================================///
        private void SetTitleStyle(RibbonBar ribbonBar)
        {
            ribbonBar.TitleStyle.BackColor         = SystemColors.Highlight;
            ribbonBar.TitleStyle.BackColor2        = Color.Blue;
            ribbonBar.TitleStyle.TextAlignment     = eStyleTextAlignment.Center;
            ribbonBar.TitleStyle.TextColor         = Color.White;
            ribbonBar.TitleStyle.TextLineAlignment = eStyleTextAlignment.Far;

            ribbonBar.Visible = Configs.Property[0];
            ribbonBar.Enabled = Configs.Property[1];
        }
        #endregion
    }
    ///=================================================================================== End of Class : MainForm =///
}
