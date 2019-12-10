using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apros_Class_Library_Base;
using DevComponents.DotNetBar.Controls;
using DH_Facility_Report_Part2.Properties;
using ChartFX.WinForms.Gauge;
using DevComponents.DotNetBar;
using System.IO;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
 


namespace DH_Facility_Report_Part2
{
    #region [ # Data Structure ]
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 20XX-XX-XX ] ///
    /// ▷ Section_Info ◁                                                                                          ///
    /// 
    /// </summary>
    ///=============================================================================================================///
    public struct Section_Info
    {
        public string Section_Num;
        public string Station_Start;
        public double Station_Sval;
        public string Station_End;
        public double Station_Eval;
    }

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 20XX-XX-XX ] ///
    /// ▷ Facility_Info ◁                                                                                         ///
    /// 
    /// </summary>
    ///=============================================================================================================///
    public struct Facility_Info
    {
        public string Facility_Num;
        public string Facility_Name;
        public List<Section_Info> Sections_Tunnel;
        public List<Section_Info> Sections_Lining;
    }

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 20XX-XX-XX ] ///
    /// ▷ Workbook_Info ◁                                                                                         ///
    /// 
    /// </summary>
    ///=============================================================================================================///
    #region [ # Workbook_Info ]
    public struct Workbook_Info
    {
        public string File_Name;
        public string Processing;
        public string Completion_Date;
        public string Facility_Address;
        public string Facility_Type;
        public string Diagnosis_Type;
        public string Diagnosis_Company;
        public string Diagnosis_Price;
        public string Diagnosis_Start_Date;
        public string Diagnosis_End_Date;
        public string Parts_Level1;
        public string Parts_Level2;
        public string Facility_Grade;
        public string Facility_Defect;
    }
    #endregion

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 20XX-XX-XX ] ///
    /// ▷ Sheet_Info ◁                                                                                            ///
    /// 
    /// </summary>
    ///=============================================================================================================///
    #region [ # Sheet_Info ]
    public struct Sheet_Info
    {
        public string Sheet_Name;
        public string Processing;
        public string Data_Index;
        public string Parts_Level3;
        public string Parts_Level4;
        public string Parts_Level5;
        public string Parts_Level6;
        public string Performance_Improve;
        public string Parts_Grade;
        public string Parts_Defect;
        public string Facility_Grade;
        public string Facility_Defect;
        public string Damage_Type;
        public string Damage_Points;
        public string Damage_Picture;
        public string Maintenance_Plan;
        public string Maintenance_Method;
        public string Maintenance_Quantity;
        public string Maintenance_Quantity_Unit;
        public string Maintenance_Unit_Price;
        public string Maintenance_Cost;
        public string Remarks;
    }
    #endregion

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 20XX-XX-XX ] ///
    /// ▷ Data_File_Info ◁                                                                                        ///
    /// 
    /// </summary>
    ///=============================================================================================================///
    #region [ # Data_File_Info ]
    public struct Data_File_Info
    {
        public Workbook_Info Workbook;
        public List<Sheet_Info> Sheets;
    }
    #endregion

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 20XX-XX-XX ] ///
    /// ▷ Data_File_List ◁                                                                                        ///
    /// 
    /// </summary>
    ///=============================================================================================================///
    #region
    public struct Data_File_List
    {
        public string Report_Name;
        public List<Data_File_Info> Files;
    }
    #endregion

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 20XX-XX-XX ] ///
    /// ▷ Data_Index ◁                                                                                            ///
    /// 
    /// </summary>
    ///=============================================================================================================///
    #region [ # Data_Index ]
    public struct Data_Index
    {
        public List<List<int>> row;
        public List<List<int>> col;
    }
    #endregion

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 20XX-XX-XX ] ///
    /// ▷ Basic_Report_Data ◁                                                                                           ///
    /// 
    /// </summary>
    ///=============================================================================================================///
    #region [ # Basic_Report_Data ]
    public struct Basic_Report_Data
    {
        public string facility_management;
        public string C;
        public string D;
        public string E;
        public string F;
        public string G;
        public string H;
        public string AJ;
        public string CA;
        public string I;
        public string J;
        public string K;
        public string L;
        public string M;
        public string N;
        public string O;
        public string P;
        public string R;
        public string S;
        public string U;
        public string V;
        public string W;
        public string Y;
        public string Z;
        public string AA;
        public string AB;
        public string AC;
        public string AD;
        public string AE;
        public string AF;
        public string AG;
        public string XJ;
        public string AH;
        public string AI;
        public string AK;
        public string AL;
        public string AM;
        public string AN;
        public string AO;
        public string AP;
        public string XK;
        public string CC;
        public string CD;
        public string CE;
        public string AQ;
        public string AT;
        public string XL;
        public string XA;
        public string CF;
        public string CG;
        public string AR;
        public string AS;
        public string BI;
        public string XM;
        public string BJ;
        public string BK;
        public string BL;
        public string BM;
        public string BN;
        public string BO;
        public string BP;
        public string XB;
        public string XC;
        public string XD;
        public string CH;
        public string CI;
        public string CJ;
        public string CK;
        public string CL;
        public string CM;
        public string CN;
        public string CO;
        public string CP;
        public string XN;
        public string CQ;
        public string CR;
        public string CS;
        public string CT;
        public string CU;
        public string CV;
        public string CW;
        public string CX;
        public string CY;
        public string CZ;
        public string DA;
        public string DB;
        public string DC;
        public string DD;
        public string DE;
        public string DF;
        public string DG;
        public string XE;
        public string XF;
        public string XG;
        public string Q;
        public string T;
        public string X;
        public string AU;
        public string AV;
        public string AW;
        public string AX;
        public string AY;
        public string AZ;
        public string BA;
        public string BC;
        public string BD;
        public string BE;
        public string BF;
        public string BG;
        public string BH;
        public string BQ;
        public string BR;
        public string BS;
        public string BT;
        public string BU;
        public string BV;
        public string BW;
        public string BX;
        public string BY;
        public string BZ;
        public string CB;
        public string BB;
        public string A;  //A
        public string B; //B
    }
    #endregion
    #region [ # etc_Report_Data ]
    public struct etc_Report_Data
    {
        //	사용제한 조치 및 중대결함사후관리
        public string A;
        public string B;
        public string C;
        public string D;
        public string E;
        public string F;
        public string G;
        public string H;
        public string I;
        public string J;
        public string L;
        public string K;
        public string M;

        //비용정보 입력 					
        public string N;
        public string O;
        public string P;
        public string Q;
        public string R;
        public string S;

        //투입비용총괄표					
        public string T;
        public string U;
        public string V;
        public string W;
        public string X;
        public string Y;
        public string Z;
        public string AA;
        public string AB;
        public string AC;
        public string AD;
        public string AE;
        public string AF;
        public string AG;
        public string AH;
        public string AI;
        public string AJ;
        public string AK;
        public string AL;
        public string AM;
        public string AN;
        public string AO;
        public string AP;
        public string AQ;
        public string AR;
        public string AS;
        public string AT;
        public string AU;
        public string AV;
        public string AW;
        public string AX;
        public string AY;

        // 유지관리비용 추이					
        public string AZ;
        public string BA;
        public string BB;
        public string BC;
        public string BD;
        public string BE;
        public string BF;
        public string BG;
        public string BH;
        public string BI;
        public string BJ;
        public string BK;

    }
    #endregion
    #region [ # Basic_Data ]
    public struct Basic_Data
    {
        public string path;
        public string facility_management;
        public string C;
        public string D;
        public string E;
        public string F;
        public string G;
        public string H;
        public string AJ;
        public string CA;
        public string I;
        public string J;
        public string K;
        public string L;
        public string M;
        public string N;
        public string O;
        public string P;
        public string R;
        public string S;
        public string U;
        public string V;
        public string W;
        public string Y;
        public string Z;
        public string AA;
        public string AB;
        public string AC;
        public string AD;
        public string AE;
        public string AF;
        public string AG;
        public string XJ;
        public string AH;
        public string AI;
        public string AK;
        public string AL;
        public string AM;
        public string AN;
        public string AO;
        public string AP;
        public string XK;
        public string CC;
        public string CD;
        public string CE;
        public string AQ;
        public string AT;
        public string XL;
        public string XA;
        public string CF;
        public string CG;
        public string AR;
        public string AS;
        public string BI;
        public string XM;
        public string BJ;
        public string BK;
        public string BL;
        public string BM;
        public string BN;
        public string BO;
        public string BP;
        public string XB;
        public string XC;
        public string XD;
        public string CH;
        public string CI;
        public string CJ;
        public string CK;
        public string CL;
        public string CM;
        public string CN;
        public string CO;
        public string CP;
        public string XN;
        public string CQ;
        public string CR;
        public string CS;
        public string CT;
        public string CU;
        public string CV;
        public string CW;
        public string CX;
        public string CY;
        public string CZ;
        public string DA;
        public string DB;
        public string DC;
        public string DD;
        public string DE;
        public string DF;
        public string DG;
        public string XE;
        public string XF;
        public string XG;
        public string Q;
        public string T;
        public string X;
        public string AU;
        public string AV;
        public string AW;
        public string AX;
        public string AY;
        public string AZ;
        public string BA;
        public string BC;
        public string BD;
        public string BE;
        public string BF;
        public string BG;
        public string BH;
        public string BQ;
        public string BR;
        public string BS;
        public string BT;
        public string BU;
        public string BV;
        public string BW;
        public string BX;
        public string BY;
        public string BZ;
        public string CB;
        public string BB;
        public string A;
        public string B;

    }
    #endregion
    #region [ # etc_Data ]
    public struct etc_Data
    {
        //	사용제한 조치 및 중대결함사후관리 		
        public string A;
        public string B;
        public string C;
        public string D;
        public string E;
        public string F;
        public string G;
        public string H;
        public string I;
        public string J;
        public string L;
        public string K;
        public string M;

        //비용정보 입력 					
        public string N;
        public string O;
        public string P;
        public string Q;
        public string R;
        public string S;

        //투입비용총괄표					
        public string T;
        public string U;
        public string V;
        public string W;
        public string X;
        public string Y;
        public string Z;
        public string AA;
        public string AB;
        public string AC;
        public string AD;
        public string AE;
        public string AF;
        public string AG;
        public string AH;
        public string AI;
        public string AJ;
        public string AK;
        public string AL;
        public string AM;
        public string AN;
        public string AO;
        public string AP;
        public string AQ;
        public string AR;
        public string AS;
        public string AT;
        public string AU;
        public string AV;
        public string AW;
        public string AX;
        public string AY;

        // 유지관리비용 추이					
        public string AZ;
        public string BA;
        public string BB;
        public string BC;
        public string BD;
        public string BE;
        public string BF;
        public string BG;
        public string BH;
        public string BI;
        public string BJ;
        public string BK;

    }
    #endregion
    #endregion

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 20XX-XX-XX ] ///
    /// ▷ AceControl: UserControl ◁                                                                               ///
    ///     소프트웨어에서 사용되는 모든 이벤트 핸들러를 구현한다.                                                  ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 20XX-XX-XX ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class AceControl: UserControl
    {
        #region [ # Defines & Variables ]
        // 버전 정보 상수
        private readonly string Version = "Expand DH_Facility_Report_Part2 - Ver 1.00.00.xxxx";

        private readonly string DataPath = CommonBase.DataPath;
        private readonly string Configpath = CommonBase.ConfigPath;

        // 델리게이트 함수
        private delegate void setTextBoxText(TextBoxX tb, string msg);
        private delegate void setPanelBackgroundImage(Panel p, Image img);
        private delegate void setLabelText(LabelX l, string msg);
        private delegate void setSwitchButton(SwitchButton sb, bool set);


        //
        private StringBuilder sb;

        // 초기화 수행 여부
        private bool Init_State = true;

        // 
        private List<Facility_Info> Facilities = new List<Facility_Info>();

        // 
        private string ConfigFile = string.Empty;
        private List<Data_File_List> Data_Source = new List<Data_File_List>();

        //
        private Dictionary<string, int> Indexer = new Dictionary<string, int>();
        #endregion

        #region [ # Constructor & Initializer ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ AceControl @                                                                                          ///
        ///     생성자로 컨트롤을 초기화한다.                                                                       ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public AceControl()
        {
            InitializeComponent();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ AceControl_Load @                                                                                     ///
        ///     폼이 로드되는 시점에 호출되며 다항식 라벨의 값을 설정한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void AceControl_Load(object sender, EventArgs e)
        {
            label_version.Text = Version;

            sb = new StringBuilder();

            Indexer.Add("A", 1);   Indexer.Add("B", 2);   Indexer.Add("C", 3);   Indexer.Add("D", 4);   Indexer.Add("E", 5);
            Indexer.Add("F", 6);   Indexer.Add("G", 7);   Indexer.Add("H", 8);   Indexer.Add("I", 9);   Indexer.Add("J", 10);
            Indexer.Add("K", 11);  Indexer.Add("L", 12);  Indexer.Add("M", 13);  Indexer.Add("N", 14);  Indexer.Add("O", 15);
            Indexer.Add("P", 16);  Indexer.Add("Q", 17);  Indexer.Add("R", 18);  Indexer.Add("S", 19);  Indexer.Add("T", 20);
            Indexer.Add("U", 21);  Indexer.Add("V", 22);  Indexer.Add("W", 23);  Indexer.Add("X", 24);  Indexer.Add("Y", 25);
            Indexer.Add("Z", 26);  Indexer.Add("AA", 27); Indexer.Add("AB", 28); Indexer.Add("AC", 29); Indexer.Add("AD", 30);
            Indexer.Add("AE", 31); Indexer.Add("AF", 32); Indexer.Add("AG", 33); Indexer.Add("AH", 34); Indexer.Add("AI", 35);
            Indexer.Add("AJ", 36); Indexer.Add("AK", 37); Indexer.Add("AL", 38); Indexer.Add("AM", 39); Indexer.Add("AN", 40);
            Indexer.Add("AO", 41); Indexer.Add("AP", 42); Indexer.Add("AQ", 43); Indexer.Add("AR", 44); Indexer.Add("AS", 45);
            Indexer.Add("AT", 46); Indexer.Add("AU", 47); Indexer.Add("AV", 48); Indexer.Add("AW", 49); Indexer.Add("AX", 50);
            Indexer.Add("AY", 51); Indexer.Add("AZ", 52);
        }
        #endregion

        #region [ # Delegate Functions ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ SetTextBoxText @                                                                                      ///
        ///     매개변수로 지정한 텍스트박스에 메시지를 설정한다.                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="tb"> TextBoxX : 대상 객체 </param>                                                         ///
        /// <param name="msg"> string : 메시지 </param>                                                             ///
        ///=========================================================================================================///
        private void SetTextBoxText(TextBoxX tb, string msg)        //22222
        {
        

            if (tb.InvokeRequired == true)
            {
                tb.Invoke(new setTextBoxText(SetTextBoxText), tb, msg);
            }
            else
            {
                tb.Text = msg;
            }
            
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ SetPanelBackgroundImage @                                                                             ///
        ///     매개변수로 지정한 패널의 배경 이미지를 설정한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="p"> Panel : 대상 객체 </param>                                                             ///
        /// <param name="img"> Image : 설정 이미지 </param>                                                         ///
        ///=========================================================================================================///
        private void SetPanelBackgroundImage(Panel p, Image img)
        {
            if (p.InvokeRequired == true)
            {
                p.Invoke(new setPanelBackgroundImage(SetPanelBackgroundImage), p, img);
            }
            else
            {
                p.BackgroundImage = img;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ SetLabelText @                                                                                        ///
        ///     매개변수로 지정하 라벨에 값을 설정한다.                                                             ///
        /// </summary>                                                                                              ///
        /// <param name="l"> LabelX : 대상 객체 </param>                                                            ///
        /// <param name="msg"> string : 설정 값 </param>                                                            ///
        ///=========================================================================================================///
        private void SetLabelText(LabelX l, string msg)
        {
            if(l.InvokeRequired==true)
            {
                l.Invoke(new setLabelText(SetLabelText), l, msg);
            }
            else
            {
                l.Text = msg;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ SetSwitchButton @                                                                                     ///
        ///     매개변수로 지정한 스위치버튼의 값을 설정한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="sb"> SwitchButton : 대상 객체 </param>                                                     ///
        /// <param name="set"> bool : 설정 값 </param>                                                              ///
        ///=========================================================================================================///
        private void SetSwitchButton(SwitchButton sb, bool set)
        {
            if (sb.InvokeRequired == true)
            {
                sb.Invoke(new setSwitchButton(SetSwitchButton), sb, set);
            }
            else
            {
                sb.Value = set;
            }
        }
        #endregion

        #region [ # Ver 1.00 ]
        #region [ # Timer Handler ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ timer_status_Tick @                                                                                   ///
        ///     통신 상태를 주기적으로 확인하여 화면에 표출한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void timer_status_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now.Second % 3) == 0)
            {

            }
            else
            {

            }
        }
        #endregion

        #region [ # Event Handler ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ m_btn_Init_Click @                                                                                    ///
        ///     초기화 작업을 수행한다.                                                                             ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_Init_Click(object sender, EventArgs e)
        {

        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ m_btn_log_clear_Click @                                                                               ///
        ///     통신 로그 창의 내용을 초기화한다.                                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_log_clear_Click(object sender, EventArgs e)
        {
            m_txb_comm_logs.Text = string.Empty;
            m_txb_comm_raws.Text = string.Empty;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ AceControl_VisibleChanged @                                                                           ///
        ///     패널의 표시 상태 변경 시 초기화 이벤트를 호출한다.                                                  ///
        ///     (초기 1회만 수행)                                                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void AceControl_VisibleChanged(object sender, EventArgs e)
        {
            if (Init_State == true)
            {
                m_btn_Init_Click(sender, e);
                Init_State = false;
                tabControl1.SelectedTabIndex = 0;
            }
        }

        #region [ # Tunnel Data ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ m_btn_Tunnel_Button_Click @                                                                           ///
        ///     버튼 클릭 시 해당 기능을 수행한다.                                                                  ///    
        ///                                                                                                         ///
        ///     ▶ m_btn_TData_Path      : 처리할 데이터 파일의 경로를 지정한다.                                    ///
        ///     ▶ m_btn_Proc_Tunnel     : 터널 데이터를 처리하여 진단 보고서를 생성한다.                           ///
        ///     ▶ m_btn_sel_infoFacT    : 시설물 기본 정보를 불러와 정보 리스트를 생성한다.                        ///
        ///     ▶ m_btn_sel_infoSecL    : 터널의 상세정보(본선라이닝)를 불러온다.                                  ///
        ///     ▶ m_btn_sel_infoSecT    : 터널의 상세정보(개착터널)를 불러온다.                                    ///
        ///     ▶ m_btn_sel_formTunn    : 진단 보고서 양식을 지정한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_Tunnel_Button_Click(object sender, EventArgs e)          //1-1 공통 파일 선택 
        {
            #region [ # m_btn_TData_Path ]
            if (sender == m_btn_TData_Path)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.SelectedPath = Application.StartupPath;

                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        SetTextBoxText(m_txb_TuData_Path, fbd.SelectedPath);
                    }
                }
            }
            #endregion
            #region [ # m_btn_sel_formTunn ]
            else if (sender == m_btn_sel_formTunn)                          //11111레포트 경로  파일선택
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.SelectedPath = Application.StartupPath;

                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        SetTextBoxText(m_txb_path_TuReport, fbd.SelectedPath);
                      
                    }
                }
            }
            #endregion
            #region [ # m_btn_Proc_Tunnel ]
            else if (sender == m_btn_Proc_Tunnel)
            {

                ProcessData(true);

 
            }
            #endregion
            else
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.InitialDirectory = CommonBase.DataPath;

                    if (ofd.ShowDialog() == DialogResult.OK)            //1-2 파일 선택
                    {
                        FileInfo fi;
                        Report_Manager rm = new Report_Manager();

                        #region [ # m_btn_sel_infoFacT ]
                        if (sender == m_btn_sel_infoFacT)
                        {
                            SetTextBoxText(m_txb_path_TuFac, ofd.FileName);
                            fi = new FileInfo(m_txb_path_TuFac.Text);

                            rm.Init_Excel_Report(fi.FullName, "건축물_상세제원정보");
                            object[,] data = rm.GetData();
                            int row = data.GetLength(0);
                            int col = data.GetLength(1);
                            rm.CloseExcel();

                            if (Facilities.Count > 0)
                            {
                                Facilities.Clear();
                            }

                            for (int i = 2; i < (row + 1); i++)
                            {
                                if (data[i, 1] != null)
                                {
                                    Facility_Info faci = new Facility_Info();
                                    faci.Facility_Num = data[i, 1].ToString();
                                    faci.Facility_Name = data[i, 2].ToString();
                                    faci.Sections_Tunnel = new List<Section_Info>();
                                    faci.Sections_Lining = new List<Section_Info>();

                                    Facilities.Add(faci);
                                }
                                else
                                {
                                    break;
                                }
                            }

                            MessageBox.Show("상세제원(공통) 로드 완료");
                        }
                        #endregion
                        #region [ # m_btn_sel_infoSecL ]
                        else if (sender == m_btn_sel_infoSecL)
                        {
                            SetTextBoxText(m_txb_path_Section_Line, ofd.FileName);
                            fi = new FileInfo(m_txb_path_TuFac.Text);

                            rm.Init_Excel_Report(fi.FullName, "건축물_상세제원정보");
                            object[,] data = rm.GetData();
                            rm.CloseExcel();

                            string f_num = string.Empty;
                            List<Section_Info> SI = new List<Section_Info>();

                            foreach (object[] tmp in data)
                            {
                                if (string.IsNullOrEmpty(f_num) == true)
                                {
                                    f_num = tmp[0].ToString();
                                }
                                else
                                {
                                    if (f_num.Equals(tmp[0].ToString()) == true)
                                    {
                                        Section_Info seci  = new Section_Info();
                                        seci.Section_Num   = tmp[1].ToString();
                                        seci.Station_Start = tmp[3].ToString();
                                        seci.Station_End   = tmp[4].ToString();

                                        string[] sub = seci.Station_Start.Split(new char[] { ')', 'K' }, StringSplitOptions.RemoveEmptyEntries);
                                        seci.Station_Sval = Convert.ToInt32(sub[1]) * 1000 + Convert.ToDouble(sub[2]);

                                        sub = seci.Station_End.Split(new char[] { ')', 'K' }, StringSplitOptions.RemoveEmptyEntries);
                                        seci.Station_Eval = Convert.ToInt32(sub[1]) * 1000 + Convert.ToDouble(sub[2]);

                                        SI.Add(seci);
                                    }
                                }
                            }

                            foreach (Facility_Info faci in Facilities)
                            {
                                if (faci.Facility_Num.Equals(f_num) == true)
                                {
                                    Facility_Info new_one = new Facility_Info();
                                    new_one.Facility_Name = faci.Facility_Name;
                                    new_one.Facility_Num = faci.Facility_Num;

                                    if (new_one.Sections_Lining.Count > 0)
                                    {
                                        new_one.Sections_Lining.Clear();
                                    }

                                    new_one.Sections_Lining = SI;

                                    int idx = Facilities.IndexOf(faci);
                                    Facilities[idx] = new_one;
                                }
                            }
                        }
                        #endregion
                        #region [ # m_btn_sel_infoSecT ]
                        else if (sender == m_btn_sel_infoSecT)
                        {
                            SetTextBoxText(m_txb_path_Section_Tunnel, ofd.FileName);
                            fi = new FileInfo(m_txb_path_TuFac.Text);

                            rm.Init_Excel_Report(fi.FullName, "건축물_상세제원정보");
                            object[,] data = rm.GetData();
                            rm.CloseExcel();

                            string f_num = string.Empty;
                            List<Section_Info> SI = new List<Section_Info>();

                            foreach (object[] tmp in data)
                            {
                                if (string.IsNullOrEmpty(f_num) == true)
                                {
                                    f_num = tmp[0].ToString();
                                }
                                else
                                {
                                    if (f_num.Equals(tmp[0].ToString()) == true)
                                    {
                                        Section_Info seci = new Section_Info();
                                        seci.Section_Num = tmp[1].ToString();
                                        seci.Station_Start = tmp[3].ToString();
                                        seci.Station_End = tmp[4].ToString();

                                        string[] sub = seci.Station_Start.Split(new char[] { ')', 'K' }, StringSplitOptions.RemoveEmptyEntries);
                                        seci.Station_Sval = Convert.ToInt32(sub[1]) * 1000 + Convert.ToDouble(sub[2]);

                                        sub = seci.Station_End.Split(new char[] { ')', 'K' }, StringSplitOptions.RemoveEmptyEntries);
                                        seci.Station_Eval = Convert.ToInt32(sub[1]) * 1000 + Convert.ToDouble(sub[2]);

                                        SI.Add(seci);
                                    }
                                }
                            }

                            foreach (Facility_Info faci in Facilities)
                            {
                                if (faci.Facility_Num.Equals(f_num) == true)
                                {
                                    Facility_Info new_one = new Facility_Info();
                                    new_one.Facility_Name = faci.Facility_Name;
                                    new_one.Facility_Num = faci.Facility_Num;

                                    if (new_one.Sections_Tunnel.Count > 0)
                                    {
                                        new_one.Sections_Tunnel.Clear();
                                    }

                                    new_one.Sections_Tunnel = SI;

                                    int idx = Facilities.IndexOf(faci);
                                    Facilities[idx] = new_one;
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion
        #endregion

        #region [ # ETC ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ Load_FileInfos @                                                                                      ///
        ///     처리 대상 데이터 파일의 정보 리스트를 구성한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="path"> string : 파일 정보 정의 파일 </param>                                               ///
        ///=========================================================================================================///
        private void Load_FileInfos(string path)   
        {
            StreamReader sr = new StreamReader(path,Encoding.Default);
            Data_File_List one = new Data_File_List();
            int cnt = 0;

            while (sr.EndOfStream == false)
            {
                string line = sr.ReadLine(); cnt++;
                string[] sub = line == null ? new string[0] : line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (sub.Length > 0)
                {
                    if (sub[0].Equals("시설물관리대장") == true)
                    {
                        line = sr.ReadLine(); cnt++;
                        sub = line == null ? new string[0] : line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        if (string.IsNullOrEmpty(one.Report_Name) == false)
                        {
                            Data_Source.Add(one);
                            one = new Data_File_List();
                        }

                        one.Report_Name = sub[0];
                        one.Files = new List<Data_File_Info>();

                        line = sr.ReadLine(); cnt++;
                    }
                    else if (sub[0].Equals("[Data_List]") == true)                   // [Data_List]
                    {
                        line = sr.ReadLine(); cnt++;
                        sub = line == null ? new string[0] : line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        Data_File_Info dfi = new Data_File_Info();
                        dfi.Workbook = new Workbook_Info();
                        dfi.Workbook.Processing             = "L";                   // 데이터 파일 종류
                        dfi.Workbook.File_Name              = sub[0];                // 파일명
                        dfi.Workbook.Completion_Date        = sub[1];                // 준공일자
                        dfi.Workbook.Facility_Address       = sub[2];                // 주소
                        dfi.Workbook.Facility_Type          = sub[3];                // 종별
                        dfi.Workbook.Diagnosis_Type         = sub[4];                // 점검진단종류
                        dfi.Workbook.Diagnosis_Company      = sub[5];                // 용역업체
                        dfi.Workbook.Diagnosis_Price        = sub[6];                // 용역금액
                        dfi.Workbook.Diagnosis_Start_Date   = sub[7];                // 시작일자
                        dfi.Workbook.Diagnosis_End_Date     = sub[8];                // 종료일자
                        dfi.Workbook.Parts_Level1           = sub[9];                // 부재1
                        dfi.Workbook.Parts_Level2           = sub[10];               // 부재2

                        if (sub.Length >= 13)
                        {
                            dfi.Workbook.Facility_Grade     = sub[11];               // 시설물등급
                            dfi.Workbook.Facility_Defect    = sub[12];               // 지수
                        }

                        dfi.Sheets = new List<Sheet_Info>();

                        while (true)
                        {
                            Sheet_Info si = new Sheet_Info();

                            line = sr.ReadLine(); cnt++;
                            sub = line == null ? new string[0] : line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            if (sub.Length == 0)
                            {
                                break;
                            }
                            else
                            {
                                si.Sheet_Name                   = sub[0];           // 시트명
                                si.Processing                   = sub[1];           // 타입
                                si.Data_Index                   = sub[2];           // Data시점
                                si.Parts_Level3                 = sub[3];           // 부재3
                                si.Parts_Level4                 = sub[4];           // 부재4
                                si.Parts_Level5                 = sub[5];           // 부재5
                                si.Parts_Level6                 = sub[6];           // 부재6
                                si.Performance_Improve          = sub[7];           // 성능개선
                                si.Parts_Grade                  = sub[8];           // 부재등급
                                si.Parts_Defect                 = sub[9];           // 지수
                                si.Damage_Type                  = sub[10];          // 손상종류
                                si.Damage_Points                = sub[11];          // 손상수
                                si.Damage_Picture               = sub[12];          // 사진
                                si.Maintenance_Plan             = sub[13];          // 유지보수안
                                si.Maintenance_Method           = sub[14];          // 공법
                                si.Maintenance_Quantity         = sub[15];          // 물량
                                si.Maintenance_Quantity_Unit    = sub[16];          // 단위
                                si.Maintenance_Unit_Price       = sub[17];          // 단가
                                si.Maintenance_Cost             = sub[18];          // 공사비
                                si.Remarks                      = sub[19];          // 비고
                            }

                            dfi.Sheets.Add(si);
                        }

                        one.Files.Add(dfi);
                    }
                    else if (sub[0].Equals("[Data_Grade]") == true)                 // [Data_Grade]
                    {
                        line = sr.ReadLine(); cnt++;
                        sub = line == null ? new string[0] : line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        Data_File_Info dfi = new Data_File_Info();
                        dfi.Workbook = new Workbook_Info();
                        dfi.Workbook.File_Name                  = sub[0];           // 파일명
                        dfi.Workbook.Processing                 = "G";              // 데이터 파일 종류
                        dfi.Workbook.Completion_Date            = sub[1];           // 준공일자
                        dfi.Workbook.Facility_Address           = sub[2];           // 주소
                        dfi.Workbook.Facility_Type              = sub[3];           // 종별
                        dfi.Workbook.Diagnosis_Type             = sub[4];           // 점검진단종류
                        dfi.Workbook.Diagnosis_Company          = sub[5];           // 용역업체
                        dfi.Workbook.Diagnosis_Price            = sub[6];           // 용역금액
                        dfi.Workbook.Diagnosis_Start_Date       = sub[7];           // 시작일자
                        dfi.Workbook.Diagnosis_End_Date         = sub[8];           // 종료일자
                        dfi.Workbook.Parts_Level1               = sub[9];           // 부재1
                        dfi.Workbook.Parts_Level2               = sub[10];          // 부재2

                        dfi.Sheets = new List<Sheet_Info>();

                        while (true)
                        {
                            Sheet_Info si = new Sheet_Info();

                            line = sr.ReadLine(); cnt++;
                            sub = line == null ? new string[0] : line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            if (sub.Length == 0)
                            {
                                break;
                            }
                            else
                            {
                                si.Sheet_Name                   = sub[0];           // 시트명
                                si.Processing                   = sub[1];           // 타입
                                si.Data_Index                   = sub[2];           // Data시점
                                si.Parts_Level3                 = sub[3];           // 부재3
                                si.Parts_Level4                 = sub[4];           // 부재4
                                si.Parts_Level5                 = sub[5];           // 부재5
                                si.Parts_Level6                 = sub[6];           // 부재6
                                si.Performance_Improve          = sub[7];           // 성능개선
                                si.Parts_Grade                  = sub[8];           // 부재등급
                                si.Parts_Defect                 = sub[9];           // 지수
                                si.Facility_Grade               = sub[10];          // 시설물등급
                                si.Facility_Defect              = sub[11];          // 지수
                                si.Damage_Type                  = sub[12];          // 손상종류
                                si.Damage_Points                = sub[13];          // 손상수
                                si.Damage_Picture               = sub[14];          // 사진
                                si.Maintenance_Plan             = sub[15];          // 유지보수안
                                si.Maintenance_Method           = sub[16];          // 공법
                                si.Maintenance_Quantity         = sub[17];          // 물량
                                si.Maintenance_Quantity_Unit    = sub[18];          // 단위
                                si.Maintenance_Unit_Price       = sub[19];          // 단가
                                si.Maintenance_Cost             = sub[20];          // 공사비
                                si.Remarks                      = sub[21];          // 비고
                            }

                            dfi.Sheets.Add(si);
                        } 
                        
  
                        one.Files.Add(dfi);
                    }
                }
            }

            Data_Source.Add(one);

            sr.Close();
            MessageBox.Show("데이터 기초 정보 로드 완료");
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ ProcessData @                                                                                         ///
        ///     
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 데이터 처리 모드 </param>                                                    ///
        ///=========================================================================================================///
        ///
        private int pathcnt = 0;
        private int LineCnt = 0;
        private void ProcessData(bool mode)
        {
            //   report_file.Init_Excel_Report(@"" + m_txb_path_TuReport.Text + @"\" + dfl.Report_Name, "점검진단정보");

              
            MessageBox.Show("작업이 완료 되었습니다!!", "작업이 완료 되었습니다!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
         


            Report_Manager rm = new Report_Manager();
            FileInfo fi;
            Basic_Data Basic = new Basic_Data();
            List<Basic_Report_Data> Reports = new List<Basic_Report_Data>();
            int cnt = 4;
            string[] stringArray = new string[130];
            string[] Files_List = new string[150];

            string pathaddress = "";
            string Files_FullName = "";

            string txtList1 = "";
            string txtList2 = "";
            string txtList3 = "";

            int ProcessCnt = 0;
           



            pathaddress = m_txb_path_TuReport.Text;
                if (System.IO.Directory.Exists(m_txb_path_TuReport.Text))
                {


                    int index = 0;
                    foreach (string s in System.IO.Directory.GetFiles(m_txb_path_TuReport.Text))
                    {
                        Files_List[index] += s;
                        ++index;

                    }
                }

                for(int j=0; j < 150; j++)
            {
                if(Files_List[j] != null)
                {
                    ++ProcessCnt;
                }else
                {
                    break;
                }
            }

            for (int t = 0; t < ProcessCnt; t++)
            {
                if (null != Files_List[pathcnt])
                {
                    Files_FullName = Files_List[pathcnt];


                }
               


                //     fi = new FileInfo(Files_FullName);

                /// <param name="intPRow"> int : 엑셀 시트 열 위치 </param>                                                 ///
                /// <param name="intPColumn"> int : 엑셀 시트 행 위치 </param>   
                int start_key = 5;
                int temp = 0;
                string[] stringtempArray2 = new string[130];
                string[] stringtempArray4 = new string[130];
                string stringtemp = "";
                string stringtemp3 = "";
                string stringtemp5 = "";
                string stringtemp6 = "";
                string stringtemp7 = "";
                string stringtemp8 = "";
                string stringtemp9 = "";
                string stringtemp10 = "";
                string stringtemp11 = "";
                string stringtemp12 = "";
                string stringtemp13 = "";
                string[] temp1 = new string[100];
                string[] temp2 = new string[100];
                string[] temp3 = new string[100];


                //object[,] data = rm.GetData();

                //   int row = data.GetLength(0);
                //    int col = data.GetLength(1);

          
             
                  rm.Init_Excel_Report(Files_FullName, "기초정보");
             
             Basic.facility_management = rm.GetData(1, 1).ToString();

                #region [ # 교량 Basic_code ]
             /*
                if (Basic.facility_management == rm.GetData(1, 1).ToString())
                {
                   (rm.GetData(i, 6).ToString() != null
                    // for (int i = 4; i < 130; i++) 이거
                    for (int i = 4; i < 130; i++)
                    {
                        if ((rm.GetData(i, 6).ToString() != null) && i < 97)
                        {


                            stringArray[i] = rm.GetData(i, 6).ToString();

                            if (i == 16 || i == 36 || i == 17) //년월일 제거
                            {
                                stringtemp = rm.GetData(i, 6).ToString();
                                temp1 = stringtemp.Split('년');
                                stringtemp = temp1[1];
                                temp2 = stringtemp.Split('월');
                                stringtemp = temp2[1];
                                temp3 = stringtemp.Split('일');
                                stringtempArray2[0] = temp1[0] + temp2[0] + temp3[0];
                                stringtemp3 = stringtempArray2[0];
                                temp1 = stringtemp3.Split(' ');
                                stringtemp3 = temp1[1];
                                temp2 = stringtemp3.Split(' ');
                                stringtemp3 = temp2[0];
                                temp3 = stringtemp3.Split(' ');
                                stringArray[i] = temp1[0] + temp1[1] + temp1[2];
                            }
                            if (i == 19) //시작일 종료일 나누기 P,Q 
                            {
                                stringtemp = rm.GetData(i, 6).ToString();
                                temp1 = stringtemp.Split('년');
                                stringtemp = temp1[1];
                                temp2 = stringtemp.Split('월');
                                stringtemp = temp2[1];
                                temp3 = stringtemp.Split('일');
                                stringtempArray2[0] = temp1[0] + temp2[0] + temp3[0];
                                stringtemp3 = stringtempArray2[0];
                                temp1 = stringtemp3.Split(' ');
                                stringtemp3 = temp1[1];
                                temp2 = stringtemp3.Split(' ');
                                stringtemp3 = temp2[0];
                                temp3 = stringtemp3.Split(' ');
                                stringArray[i] = temp1[0] + temp1[1] + temp1[2];


                            }
                            if (i == 21 || i == 24) //시작일 종료일 나누기 S,T  (24감리기간 오류 확인용)
                            {
                                stringtemp = rm.GetData(i, 6).ToString();
                                temp1 = stringtemp.Split('년');
                                stringtemp = temp1[1] + temp1[2];
                                temp2 = stringtemp.Split('월');
                                stringtemp = temp2[1] + temp2[2];
                                temp3 = stringtemp.Split('일');
                                stringtempArray2[0] = temp1[0] + temp2[0] + temp3[0] + temp3[1];
                                stringtemp3 = stringtempArray2[0];
                                temp1 = stringtemp3.Split(' ');
                                stringtemp3 = temp1[1];
                                temp2 = stringtemp3.Split(' ');
                                stringtemp3 = temp2[0];
                                temp3 = stringtemp3.Split(' ');
                                stringtempArray4[0] = temp1[0] + temp1[1] + temp1[2] + temp1[3] + temp1[4];
                                stringtemp5 = stringtempArray4[0];
                                stringtemp6 = stringtemp5.Substring(0, 8);
                                stringtemp7 = stringtemp5.Substring(8, 8);

                                if (i == 21)
                                {
                                    stringArray[i] = stringtemp6;
                                    stringArray[98] = stringtemp7;
                                }
                                if (i == 24)
                                {
                                    stringArray[i] = stringtemp6;
                                    stringArray[99] = stringtemp7;
                                }

                            }
                            if (i == 23) //시공비 백만원 제거 
                            {
                                stringtemp8 = rm.GetData(i, 6).ToString();
                                stringtemp9 = stringtemp8.Replace("백만원", "");
                                stringArray[i] = stringtemp9;
                            }
                            if (i == 37 || i == 38 || i == 39 || i == 40 || i == 41 || i == 42) //AK ~ AP 좌표 : 제거 
                            {
                                stringtemp10 = rm.GetData(i, 6).ToString();
                                stringtemp11 = stringtemp10.Replace("X좌표", "");
                                stringtemp11 = stringtemp11.Replace("Y좌표", "");
                                stringtemp11 = stringtemp11.Replace(":", "");
                                stringArray[i] = stringtemp11;

                            }
                            if (i == 48) // - 제거 
                            {
                                stringtemp12 = rm.GetData(i, 6).ToString();
                                stringtemp13 = stringtemp12.Replace("-", "");
                                stringArray[i] = stringtemp13;
                            }

                        }
                        else
                        {
                            if (i != 98)
                            {
                                stringArray[i] = " ";
                            }

                        }


                    }
                    stringArray[4] = rm.GetData(4, 6).ToString();

             #endregion

             #region [ # 교량 Basic_데이터 값 ]
             /*
                   //Basic.A = stringArray[1];
                   Basic.A = stringArray[4];
                   Basic.D = stringArray[5];
                   Basic.E = stringArray[6];
                   Basic.F = stringArray[7];
                   Basic.G = stringArray[8];
                   Basic.H = stringArray[9];
                   Basic.AJ = stringArray[10];
                   Basic.CA = stringArray[11];
                   Basic.I = stringArray[12];
                   Basic.J = stringArray[13];
                   Basic.K = stringArray[14];
                   Basic.L = stringArray[15];
                   Basic.M = stringArray[16];  //년월일 제거 
                   Basic.N = stringArray[17];  //년월일 제거 
                   Basic.O = stringArray[18];
                   Basic.P = stringArray[19];  //시작일 종료일 나누기 P,Q 
                   Basic.R = stringArray[20];
                   Basic.S = stringArray[21];  //시작일 종료일 나누기 S,T
                   Basic.U = stringArray[22];
                   Basic.V = stringArray[23];  //시공비 백만원 제거 
                   Basic.W = stringArray[24];
                   Basic.Y = stringArray[25];
                   Basic.Z = stringArray[26];
                   Basic.AA = stringArray[27];
                   Basic.AB = stringArray[28];
                   Basic.AC = stringArray[29];
                   Basic.AD = stringArray[30];
                   Basic.AE = stringArray[31];
                   Basic.AF = stringArray[32];
                   Basic.AG = stringArray[33];
                   Basic.XJ = stringArray[34];
                   Basic.AH = stringArray[35];
                   Basic.AI = stringArray[36];  //년월일 제거 
                   Basic.AK = stringArray[37];  //AK ~ AP 좌표 : 제거 
                   Basic.AL = stringArray[38];
                   Basic.AM = stringArray[39];
                   Basic.AN = stringArray[40];
                   Basic.AO = stringArray[41];
                   Basic.AP = stringArray[42];
                   Basic.XK = stringArray[43];
                   Basic.CC = stringArray[44];
                   Basic.CD = stringArray[45];
                   Basic.CE = stringArray[46];
                   Basic.AQ = stringArray[47];
                   Basic.AT = stringArray[48];   // - 제거 
                   Basic.XL = stringArray[49];
                   Basic.XA = stringArray[50];
                   Basic.CF = stringArray[51];
                   Basic.CG = stringArray[52];
                   Basic.AR = stringArray[53];
                   Basic.AS = stringArray[54];
                   Basic.BI = stringArray[55];
                   Basic.XM = stringArray[56];
                   Basic.BJ = stringArray[57];
                   Basic.BK = stringArray[58];
                   Basic.BL = stringArray[59];
                   Basic.BM = stringArray[60];
                   Basic.BN = stringArray[61];
                   Basic.BO = stringArray[62];
                   Basic.BP = stringArray[63];
                   Basic.XB = stringArray[64];
                   Basic.XC = stringArray[65];
                   Basic.XD = stringArray[66];
                   Basic.CH = stringArray[67];
                   Basic.CI = stringArray[68];
                   Basic.CJ = stringArray[69];
                   Basic.CK = stringArray[70];
                   Basic.CL = stringArray[71];
                   Basic.CM = stringArray[72];
                   Basic.CN = stringArray[73];
                   Basic.CO = stringArray[74];
                   Basic.CP = stringArray[75];
                   Basic.XN = stringArray[76];
                   Basic.CQ = stringArray[77];
                   Basic.CR = stringArray[78];
                   Basic.CS = stringArray[79];
                   Basic.CT = stringArray[80];
                   Basic.CU = stringArray[81];
                   Basic.CV = stringArray[82];
                   Basic.CW = stringArray[83];
                   Basic.CX = stringArray[84];
                   Basic.CY = stringArray[85];
                   Basic.CZ = stringArray[86];
                   Basic.DA = stringArray[87];
                   Basic.DB = stringArray[88];
                   Basic.DC = stringArray[89];
                   Basic.DD = stringArray[90];
                   Basic.DE = stringArray[91];
                   Basic.DF = stringArray[92];
                   Basic.DG = stringArray[93];
                   Basic.XE = stringArray[94];
                   Basic.XF = stringArray[95];
                   Basic.XG = stringArray[96];
                   Basic.Q = stringArray[97];
                   Basic.T = stringArray[98];
                   Basic.X = stringArray[99];
                   Basic.AU = stringArray[100];
                   Basic.AV = stringArray[101];
                   Basic.AW = stringArray[102];
                   Basic.AX = stringArray[103];
                   Basic.AY = stringArray[104];
                   Basic.AZ = stringArray[105];
                   Basic.BA = stringArray[106];
                   Basic.BC = stringArray[107];
                   Basic.BD = stringArray[108];
                   Basic.BE = stringArray[109];
                   Basic.BF = stringArray[110];
                   Basic.BG = stringArray[111];
                   Basic.BH = stringArray[112];
                   Basic.BQ = stringArray[113];
                   Basic.BR = stringArray[114];
                   Basic.BS = stringArray[115];
                   Basic.BT = stringArray[116];
                   Basic.BU = stringArray[117];
                   Basic.BV = stringArray[118];
                   Basic.BW = stringArray[119];
                   Basic.BX = stringArray[120];
                   Basic.BY = stringArray[121];
                   Basic.BZ = stringArray[122];
                   Basic.CB = stringArray[123];
                   Basic.BB = stringArray[124];                 
                   Basic.B = stringArray[126];

                   Basic_Report_Data Report = new Basic_Report_Data();

                 //  Report.A = Basic.A;
                   Report.A = Basic.A;
                   Report.C = Basic.C;
                   Report.D = Basic.D;
                   Report.E = Basic.E;
                   Report.F = Basic.F;
                   Report.G = Basic.G;
                   Report.H = Basic.H;
                   Report.AJ = Basic.AJ;
                   Report.CA = Basic.CA;
                   Report.I = Basic.I;
                   Report.J = Basic.J;
                   Report.K = Basic.K;
                   Report.L = Basic.L;
                   Report.M = Basic.M;
                   Report.N = Basic.N;
                   Report.O = Basic.O;
                   Report.P = Basic.P;
                   Report.R = Basic.R;
                   Report.S = Basic.S;
                   Report.U = Basic.U;
                   Report.V = Basic.V;
                   Report.W = Basic.W;
                   Report.Y = Basic.Y;
                   Report.Z = Basic.Z;
                   Report.AA = Basic.AA;
                   Report.AB = Basic.AB;
                   Report.AC = Basic.AC;
                   Report.AD = Basic.AD;
                   Report.AE = Basic.AE;
                   Report.AF = Basic.AF;
                   Report.AG = Basic.AG;
                   Report.XJ = Basic.XJ;
                   Report.AH = Basic.AH;
                   Report.AI = Basic.AI;
                   Report.AK = Basic.AK;
                   Report.AL = Basic.AL;
                   Report.AM = Basic.AM;
                   Report.AN = Basic.AN;
                   Report.AO = Basic.AO;
                   Report.AP = Basic.AP;
                   Report.XK = Basic.XK;
                   Report.CC = Basic.CC;
                   Report.CD = Basic.CD;
                   Report.CE = Basic.CE;
                   Report.AQ = Basic.AQ;
                   Report.AT = Basic.AT;
                   Report.XL = Basic.XL;
                   Report.XA = Basic.XA;
                   Report.CF = Basic.CF;
                   Report.CG = Basic.CG;
                   Report.AR = Basic.AR;
                   Report.AS = Basic.AS;
                   Report.BI = Basic.BI;
                   Report.XM = Basic.XM;
                   Report.BJ = Basic.BJ;
                   Report.BK = Basic.BK;
                   Report.BL = Basic.BL;
                   Report.BM = Basic.BM;
                   Report.BN = Basic.BN;
                   Report.BO = Basic.BO;
                   Report.BP = Basic.BP;
                   Report.XB = Basic.XB;
                   Report.XC = Basic.XC;
                   Report.XD = Basic.XD;
                   Report.CH = Basic.CH;
                   Report.CI = Basic.CI;
                   Report.CJ = Basic.CJ;
                   Report.CK = Basic.CK;
                   Report.CL = Basic.CL;
                   Report.CM = Basic.CM;
                   Report.CN = Basic.CN;
                   Report.CO = Basic.CO;
                   Report.CP = Basic.CP;
                   Report.XN = Basic.XN;
                   Report.CQ = Basic.CQ;
                   Report.CR = Basic.CR;
                   Report.CS = Basic.CS;
                   Report.CT = Basic.CT;
                   Report.CU = Basic.CU;
                   Report.CV = Basic.CV;
                   Report.CW = Basic.CW;
                   Report.CX = Basic.CX;
                   Report.CY = Basic.CY;
                   Report.CZ = Basic.CZ;
                   Report.DA = Basic.DA;
                   Report.DB = Basic.DB;
                   Report.DC = Basic.DC;
                   Report.DD = Basic.DD;
                   Report.DE = Basic.DE;
                   Report.DF = Basic.DF;
                   Report.DG = Basic.DG;
                   Report.XE = Basic.XE;
                   Report.XF = Basic.XF;
                   Report.XG = Basic.XG;
                   Report.Q = Basic.Q;
                   Report.T = Basic.T;
                   Report.X = Basic.X;
                   Report.AU = Basic.AU;
                   Report.AV = Basic.AV;
                   Report.AW = Basic.AW;
                   Report.AX = Basic.AX;
                   Report.AY = Basic.AY;
                   Report.AZ = Basic.AZ;
                   Report.BA = Basic.BA;
                   Report.BC = Basic.BC;
                   Report.BD = Basic.BD;
                   Report.BE = Basic.BE;
                   Report.BF = Basic.BF;
                   Report.BG = Basic.BG;
                   Report.BH = Basic.BH;
                   Report.BQ = Basic.BQ;
                   Report.BR = Basic.BR;
                   Report.BS = Basic.BS;
                   Report.BT = Basic.BT;
                   Report.BU = Basic.BU;
                   Report.BV = Basic.BV;
                   Report.BW = Basic.BW;
                   Report.BX = Basic.BX;
                   Report.BY = Basic.BY;
                   Report.BZ = Basic.BZ;
                   Report.CB = Basic.CB;
                   Report.BB = Basic.BB;
                   Report.B = Basic.B;

                   */
                #endregion


                #region [ # 터널 Basic_code ]
                /*
                string testt1 = "";
                string testt2 = "";

                
                testt1 = rm.Find("시설물관리대장");
                testt2 = testt1.Replace("$A$", "");
                int intVal11 = Convert.ToInt32(testt2);
           


                if (Basic.facility_management == rm.GetData(1, 1).ToString())
                    {
    
                    // for (int i = 4; i < 130; i++) 이거
                    for (int i = 4; i < 130; i++)
                        {
                       

                           if (null != ( stringArray[i] = rm.GetData(i, 6) == null ? null : rm.GetData(i, 6).ToString()))
                            {


                                stringArray[i] = rm.GetData(i, 6).ToString();

                                if (i == 16 || i == 36 || i == 17) //년월일 제거
                                {
                                    stringtemp = rm.GetData(i, 6).ToString();
                                    temp1 = stringtemp.Split('년');
                                    stringtemp = temp1[1];
                                    temp2 = stringtemp.Split('월');
                                    stringtemp = temp2[1];
                                    temp3 = stringtemp.Split('일');
                                    stringtempArray2[0] = temp1[0] + temp2[0] + temp3[0];
                                    stringtemp3 = stringtempArray2[0];
                                    temp1 = stringtemp3.Split(' ');
                                    stringtemp3 = temp1[1];
                                    temp2 = stringtemp3.Split(' ');
                                    stringtemp3 = temp2[0];
                                    temp3 = stringtemp3.Split(' ');
                                    stringArray[i] = temp1[0] + temp1[1] + temp1[2];
                                }
                                if (i == 19) //시작일 종료일 나누기 P,Q 
                                {
                                    stringtemp = rm.GetData(i, 6).ToString();
                                    temp1 = stringtemp.Split('년');
                                    stringtemp = temp1[1];
                                    temp2 = stringtemp.Split('월');
                                    stringtemp = temp2[1];
                                    temp3 = stringtemp.Split('일');
                                    stringtempArray2[0] = temp1[0] + temp2[0] + temp3[0];
                                    stringtemp3 = stringtempArray2[0];
                                    temp1 = stringtemp3.Split(' ');
                                    stringtemp3 = temp1[1];
                                    temp2 = stringtemp3.Split(' ');
                                    stringtemp3 = temp2[0];
                                    temp3 = stringtemp3.Split(' ');
                                    stringArray[i] = temp1[0] + temp1[1] + temp1[2];


                                }
                                if (i == 21 || i == 24) //시작일 종료일 나누기 S,T  (24감리기간 오류 확인용)
                                {
                                    stringtemp = rm.GetData(i, 6).ToString();
                                    temp1 = stringtemp.Split('년');
                                    stringtemp = temp1[1] + temp1[2];
                                    temp2 = stringtemp.Split('월');
                                    stringtemp = temp2[1] + temp2[2];
                                    temp3 = stringtemp.Split('일');
                                    stringtempArray2[0] = temp1[0] + temp2[0] + temp3[0] + temp3[1];
                                    stringtemp3 = stringtempArray2[0];
                                    temp1 = stringtemp3.Split(' ');
                                    stringtemp3 = temp1[1];
                                    temp2 = stringtemp3.Split(' ');
                                    stringtemp3 = temp2[0];
                                    temp3 = stringtemp3.Split(' ');
                                    stringtempArray4[0] = temp1[0] + temp1[1] + temp1[2] + temp1[3] + temp1[4];
                                    stringtemp5 = stringtempArray4[0];
                                    stringtemp6 = stringtemp5.Substring(0, 8);
                                    stringtemp7 = stringtemp5.Substring(8, 8);

                                    if (i == 21)
                                    {
                                        stringArray[i] = stringtemp6;
                                        stringArray[98] = stringtemp7;
                                    }
                                    if (i == 24)
                                    {
                                        stringArray[i] = stringtemp6;
                                        stringArray[99] = stringtemp7;
                                    }

                                }
                                if (i == 23) //시공비 백만원 제거 
                                {
                                    stringtemp8 = rm.GetData(i, 6).ToString();
                                    stringtemp9 = stringtemp8.Replace("백만원", "");
                                    stringArray[i] = stringtemp9;
                                }
                                if (i == 37 || i == 38 || i == 39 || i == 40 || i == 41 || i == 42) //AK ~ AP 좌표 : 제거 
                                {
                                    stringtemp10 = rm.GetData(i, 6).ToString();
                                    stringtemp11 = stringtemp10.Replace("X좌표", "");
                                    stringtemp11 = stringtemp11.Replace("Y좌표", "");
                                    stringtemp11 = stringtemp11.Replace(":", "");
                                    stringArray[i] = stringtemp11;

                                }
                                if (i > 83 && i < 93)
                                {
                                    stringArray[i] = " ";
                                }
                                if (i > 93)
                                {
                                    stringArray[i] = rm.GetData(i, 6).ToString();
                                }

                                }
                                
                                else
                                {
                                    
                                    stringArray[i] = " ";
                              

                                }


                        }
                        stringArray[4] = rm.GetData(4, 6).ToString();
                        #endregion

                    # region [터널 Basic_데이터 값]

                    Basic.C = stringArray[4];
                    Basic.D = stringArray[5];
                    Basic.E = stringArray[6];
                    Basic.F = stringArray[7];
                    Basic.G = stringArray[8];
                    Basic.H = stringArray[9];
                    Basic.AJ = stringArray[10];
                    Basic.CA = stringArray[11];
                    Basic.I = stringArray[12];
                    Basic.J = stringArray[13];
                    Basic.K = stringArray[14];
                    Basic.L = stringArray[15];
                    Basic.M = stringArray[16];  //년월일 제거 
                    Basic.N = stringArray[17];  //년월일 제거 
                    Basic.O = stringArray[18];
                    Basic.P = stringArray[19];  //시작일 종료일 나누기 P,Q 
                    Basic.R = stringArray[20];
                    Basic.S = stringArray[21];  //시작일 종료일 나누기 S,T
                    Basic.U = stringArray[22];
                    Basic.V = stringArray[23];  //시공비 백만원 제거 
                    Basic.W = stringArray[24];
                    Basic.Y = stringArray[25];
                    Basic.Z = stringArray[26];
                    Basic.AA = stringArray[27];
                    Basic.AB = stringArray[28];
                    Basic.AC = stringArray[29];
                    Basic.AD = stringArray[30];
                    Basic.AE = stringArray[31];
                    Basic.AF = stringArray[32];
                    Basic.AG = stringArray[33];
                    Basic.XJ = stringArray[34];
                    Basic.AH = stringArray[35];
                    Basic.AI = stringArray[36];  //년월일 제거 
                    Basic.AK = stringArray[37];  //AK ~ AP 좌표 : 제거 
                    Basic.AL = stringArray[38];
                    Basic.AM = stringArray[39];
                    Basic.AN = stringArray[40];
                    Basic.AO = stringArray[41];
                    Basic.AP = stringArray[42];

                    Basic.AQ = stringArray[43];
                    Basic.AT = stringArray[44];
                    Basic.XK = stringArray[45];
                    Basic.AJ = stringArray[46];
                    Basic.AR = stringArray[47];
                    Basic.AS = stringArray[48];   // - 제거 
                    Basic.BE = stringArray[49];
                    Basic.BF = stringArray[50];
                    Basic.BG = stringArray[51];
                    Basic.BI = stringArray[52];
                    Basic.BK = stringArray[53];
                    Basic.BL = stringArray[54];
                    Basic.BM = stringArray[55];
                    Basic.BN = stringArray[56];
                    Basic.BO = stringArray[57];
                    Basic.BP = stringArray[58];
                    Basic.BQ = stringArray[59];
                    Basic.BR = stringArray[60];
                    Basic.BS = stringArray[61];
                    Basic.BT = stringArray[62];
                    Basic.BU = stringArray[63];
                    Basic.BV = stringArray[64];
                    Basic.XC = stringArray[65];
                    Basic.CA = stringArray[66];
                    Basic.CB = stringArray[67];
                    Basic.CC = stringArray[68];
                    Basic.CD = stringArray[69];
                    Basic.CE = stringArray[70];
                    Basic.CL = stringArray[71];
                    Basic.CM = stringArray[72];
                    Basic.CP = stringArray[73];
                    Basic.CQ = stringArray[74];
                    Basic.CR = stringArray[75];
                    Basic.CS = stringArray[76];
                    Basic.CT = stringArray[77];
                    Basic.CU = stringArray[78];
                    Basic.CV = stringArray[79];
                    Basic.CW = stringArray[80];
                    Basic.CX = stringArray[81];
                    Basic.CY = stringArray[82];
                    Basic.CZ = stringArray[83];

                    Basic.DA = stringArray[84];
                    Basic.DB = stringArray[85];
                    Basic.DC = stringArray[86];
                    Basic.AU = stringArray[87];
                    Basic.AV = stringArray[88];
                    Basic.AW = stringArray[89];
                    Basic.AX = stringArray[90];
                    Basic.AY = stringArray[91];
                    Basic.AZ = stringArray[92];


                    Basic.DD = stringArray[93];
                    Basic.DE = stringArray[94];
                    Basic.DF = stringArray[95];

                    Basic.XG = stringArray[96];
                    Basic.Q = stringArray[97];
                    Basic.T = stringArray[98];
                    Basic.X = stringArray[99];
  

                    Basic_Report_Data Report = new Basic_Report_Data();
              //      Report.A = Basic.A;
                    Report.C = Basic.C;
                    Report.D = Basic.D;
                    Report.E = Basic.E;
                    Report.F = Basic.F;
                    Report.G = Basic.G;
                    Report.H = Basic.H;
                    Report.AJ = Basic.AJ;
                    Report.CA = Basic.CA;
                    Report.I = Basic.I;
                    Report.J = Basic.J;
                    Report.K = Basic.K;
                    Report.L = Basic.L;
                    Report.M = Basic.M;
                    Report.N = Basic.N;
                    Report.O = Basic.O;
                    Report.P = Basic.P;
                    Report.R = Basic.R;
                    Report.S = Basic.S;
                    Report.U = Basic.U;
                    Report.V = Basic.V;
                    Report.W = Basic.W;
                    Report.Y = Basic.Y;
                    Report.Z = Basic.Z;
                    Report.AA = Basic.AA;
                    Report.AB = Basic.AB;
                    Report.AC = Basic.AC;
                    Report.AD = Basic.AD;
                    Report.AE = Basic.AE;
                    Report.AF = Basic.AF;
                    Report.AG = Basic.AG;
                    Report.XJ = Basic.XJ;
                    Report.AH = Basic.AH;
                    Report.AI = Basic.AI;
                    Report.AK = Basic.AK;
                    Report.AL = Basic.AL;
                    Report.AM = Basic.AM;
                    Report.AN = Basic.AN;
                    Report.AO = Basic.AO;
                    Report.AP = Basic.AP;
                    Report.AQ = Basic.AQ;
                    Report.AT = Basic.AT;
                    Report.XK = Basic.XK;
                    Report.AJ = Basic.AJ;
                    Report.AR = Basic.AR;
                    Report.AS = Basic.AS;
                    Report.BE = Basic.BE;
                    Report.BF = Basic.BF;
                    Report.BG = Basic.BG;
                    Report.BI = Basic.BI;
                    Report.BK = Basic.BK;
                    Report.BL = Basic.BL;
                    Report.BM = Basic.BM;
                    Report.BN = Basic.BN;
                    Report.BO = Basic.BO;
                    Report.BP = Basic.BP;
                    Report.BQ = Basic.BQ;
                    Report.BR = Basic.BR;
                    Report.BS = Basic.BS;
                    Report.BT = Basic.BT;
                    Report.BU = Basic.BU;
                    Report.BV = Basic.BV;
                    Report.XC = Basic.XC;
                    Report.CA = Basic.CA;
                    Report.CB = Basic.CB;
                    Report.CC = Basic.CC;
                    Report.CD = Basic.CD;
                    Report.CE = Basic.CE;
                    Report.CL = Basic.CL;
                    Report.CM = Basic.CM;
                    Report.CP = Basic.CP;
                    Report.CQ = Basic.CQ;
                    Report.CR = Basic.CR;
                    Report.CS = Basic.CS;
                    Report.CT = Basic.CT;
                    Report.CU = Basic.CU;
                    Report.CV = Basic.CV;
                    Report.CW = Basic.CW;
                    Report.CX = Basic.CX;
                    Report.CY = Basic.CY;
                    Report.CZ = Basic.CZ;
                    Report.DA = Basic.DA;
                    Report.DB = Basic.DB;
                    Report.DC = Basic.DC;
                    Report.DA = Basic.DA;
                    Report.DB = Basic.DB;
                    Report.DC = Basic.DC;
                    Report.AU = Basic.AU;
                    Report.AV = Basic.AV;
                    Report.AW = Basic.AW;
                    Report.AX = Basic.AX;
                    Report.AY = Basic.AY;
                    Report.AZ = Basic.AZ;
                    Report.DD = Basic.DD;
                    Report.DE = Basic.DE;
                    Report.DF = Basic.DF;
                    Report.XG = Basic.XG;
                    Report.Q = Basic.Q;
                    Report.T = Basic.T;
                    Report.X = Basic.X;
                    */
                #endregion


                #region [ 역사 Basic_code]
           
                if (Basic.facility_management == rm.GetData(1, 1).ToString())
                {
                    stringArray[0] = " ";
                    stringArray[1] = " ";
                    stringArray[2] = " ";
                    stringArray[3] = " ";
                    // for (int i = 4; i < 130; i++) 이거
                    for (int i = 4; i < 107; i++)
                    {


                        if (null != (stringArray[i] = rm.GetData(i, 6) == null ? null : rm.GetData(i, 6).ToString()))
                        {


                            stringArray[i] = rm.GetData(i, 6).ToString();

                            if (i == 15 || i == 16 || i == 34) //년월일 제거
                            {
                                stringtemp = rm.GetData(i, 6).ToString();
                                temp1 = stringtemp.Split('년');
                                stringtemp = temp1[1];
                                temp2 = stringtemp.Split('월');
                                stringtemp = temp2[1];
                                temp3 = stringtemp.Split('일');
                                stringtempArray2[0] = temp1[0] + temp2[0] + temp3[0];
                                stringtemp3 = stringtempArray2[0];
                                temp1 = stringtemp3.Split(' ');
                                stringtemp3 = temp1[1];
                                temp2 = stringtemp3.Split(' ');
                                stringtemp3 = temp2[0];
                                temp3 = stringtemp3.Split(' ');
                                stringArray[i] = (temp1[0]+"-") + (temp1[1] + "-") + (temp1[2]+"-");

                            }
                      

                        }

                        else
                        {

                            stringArray[i] = " ";


                        }


                    }

                    #endregion

                   stringArray[38] = " ";
                    #region [교량,터널,역사 etc_데이터 값]

                    Basic.A = stringArray[4];
                    Basic.B = stringArray[5];
                    Basic.C = stringArray[6];
                    Basic.D = stringArray[7];
                    Basic.E = stringArray[8];
                    Basic.F = stringArray[9];
                    Basic.G = stringArray[10];
                    Basic.H = stringArray[11];
                    Basic.I = stringArray[12];
                    Basic.J = stringArray[13];
                    Basic.K = stringArray[14];
                    Basic.L = stringArray[15];
                    Basic.M = stringArray[16];
                    Basic.N = stringArray[17];
                    Basic.O = stringArray[18];
                    Basic.P = stringArray[19];
                    Basic.Q = stringArray[20];
                    Basic.R = stringArray[21];
                    Basic.S = stringArray[22];
                    Basic.T = stringArray[23];
                    Basic.U = stringArray[24];
                    Basic.V = stringArray[25];
                    Basic.W = stringArray[26];
                    Basic.X = stringArray[27];
                    Basic.Y = stringArray[28];
                    Basic.Z = stringArray[29];
                    Basic.AA = stringArray[30];
                    Basic.AB = stringArray[31];
                    Basic.AC = stringArray[32];
                    Basic.AD = stringArray[33];
                    Basic.AE = stringArray[34];
                    Basic.AF = stringArray[35];
                    Basic.AG = stringArray[36];
                    Basic.AH = stringArray[37];
                    Basic.XA = stringArray[38];
                    Basic.AI = stringArray[39];
                    Basic.AJ = stringArray[40];
                    Basic.AK = stringArray[41];
                    Basic.AL = stringArray[42];
                    Basic.AM = stringArray[43];
                    Basic.AN = stringArray[44];
                    Basic.AO = stringArray[45];
                    Basic.AP = stringArray[46];
                    Basic.AQ = stringArray[47];
                    Basic.AR = stringArray[48];
                    Basic.AS = stringArray[49];
                    Basic.AT = stringArray[50];
                    Basic.AU = stringArray[51];
                    Basic.AV = stringArray[52];
                    Basic.AW = stringArray[53];
                    Basic.AX = stringArray[54];
                    Basic.AY = stringArray[55];
                    Basic.AZ = stringArray[56];
                    Basic.BA = stringArray[57];
                    Basic.BB = stringArray[58];
                    Basic.BC = stringArray[59];
                    Basic.BD = stringArray[60];
                    Basic.BE = stringArray[61];
                    Basic.BF = stringArray[62];
                    Basic.BG = stringArray[63];
                    Basic.BH = stringArray[64];
                    Basic.BI = stringArray[65];
                    Basic.BJ = stringArray[66];
                    Basic.BK = stringArray[67];
                    Basic.BL = stringArray[68];
                    Basic.BM = stringArray[69];
                    Basic.BN = stringArray[70];
                    Basic.BO = stringArray[71];
                    Basic.BP = stringArray[72];
                    Basic.BQ = stringArray[73];
                    Basic.BR = stringArray[74];
                    Basic.BS = stringArray[75];
                    Basic.BT = stringArray[76];
                    Basic.BU = stringArray[77];
                    Basic.BV = stringArray[78];
                    Basic.BW = stringArray[79];
                    Basic.BX = stringArray[80];
                    Basic.BY = stringArray[81];
                    Basic.BZ = stringArray[82];
                    Basic.CA = stringArray[83];
                    Basic.CB = stringArray[84];
                    Basic.CC = stringArray[85];
                    Basic.CD = stringArray[86];
                    Basic.CE = stringArray[87];
                    Basic.CF = stringArray[88];
                    Basic.CG = stringArray[89];
                    Basic.CH = stringArray[90];
                    Basic.CI = stringArray[91];
                    Basic.CJ = stringArray[92];
                    Basic.CK = stringArray[93];
                    Basic.CL = stringArray[94];
                    Basic.CM = stringArray[95];
                    Basic.CN = stringArray[96];
                    Basic.CO = stringArray[97];
                    Basic.CP = stringArray[98];
                    Basic.CQ = stringArray[99];
                    Basic.CR = stringArray[100];
                    Basic.CS = stringArray[101];
                    Basic.CT = stringArray[102];
                    Basic.CU = stringArray[103];
                    Basic.CV = stringArray[104];
                    Basic.CW = stringArray[105];
                    Basic.CX = stringArray[106];
                    Basic.CY = stringArray[107];





                    Basic_Report_Data Report = new Basic_Report_Data();
                    //      Report.A = Basic.A;
                    Report.A = Basic.A;
                    Report.B = Basic.B;
                    Report.C = Basic.C;
                    Report.D = Basic.D;
                    Report.E = Basic.E;
                    Report.F = Basic.F;
                    Report.G = Basic.G;
                    Report.H = Basic.H;
                    Report.I = Basic.I;
                    Report.J = Basic.J;
                    Report.K = Basic.K;
                    Report.L = Basic.L;
                    Report.M = Basic.M;
                    Report.N = Basic.N;
                    Report.O = Basic.O;
                    Report.P = Basic.P;
                    Report.Q = Basic.Q;
                    Report.R = Basic.R;
                    Report.S = Basic.S;
                    Report.T = Basic.T;
                    Report.U = Basic.U;
                    Report.V = Basic.V;
                    Report.W = Basic.W;
                    Report.X = Basic.X;
                    Report.Y = Basic.Y;
                    Report.Z = Basic.Z;
                    Report.AA = Basic.AA;
                    Report.AB = Basic.AB;
                    Report.AC = Basic.AC;
                    Report.AD = Basic.AD;
                    Report.AE = Basic.AE;
                    Report.AF = Basic.AF;
                    Report.AG = Basic.AG;
                    Report.AH = Basic.AH;
                    Report.AI = Basic.AI;
                    Report.AJ = Basic.AJ;
                    Report.AK = Basic.AK;
                    Report.AL = Basic.AL;
                    Report.AM = Basic.AM;
                    Report.AN = Basic.AN;
                    Report.AO = Basic.AO;
                    Report.AP = Basic.AP;
                    Report.AQ = Basic.AQ;
                    Report.AR = Basic.AR;
                    Report.AS = Basic.AS;
                    Report.AT = Basic.AT;
                    Report.AU = Basic.AU;
                    Report.AV = Basic.AV;
                    Report.AW = Basic.AW;
                    Report.AX = Basic.AX;
                    Report.AY = Basic.AY;
                    Report.AZ = Basic.AZ;
                    Report.BA = Basic.BA;
                    Report.BB = Basic.BB;
                    Report.BC = Basic.BC;
                    Report.BD = Basic.BD;
                    Report.BE = Basic.BE;
                    Report.BF = Basic.BF;
                    Report.BG = Basic.BG;
                    Report.BH = Basic.BH;
                    Report.BI = Basic.BI;
                    Report.BJ = Basic.BJ;
                    Report.BK = Basic.BK;
                    Report.BL = Basic.BL;
                    Report.BM = Basic.BM;
                    Report.BN = Basic.BN;
                    Report.BO = Basic.BO;
                    Report.BP = Basic.BP;
                    Report.BQ = Basic.BQ;
                    Report.BR = Basic.BR;
                    Report.BS = Basic.BS;
                    Report.BT = Basic.BT;
                    Report.BU = Basic.BU;
                    Report.BV = Basic.BV;
                    Report.BW = Basic.BW;
                    Report.BX = Basic.BX;
                    Report.BY = Basic.BY;
                    Report.BZ = Basic.BZ;
                    Report.CA = Basic.CA;
                    Report.CB = Basic.CB;
                    Report.CC = Basic.CC;
                    Report.CD = Basic.CD;
                    Report.CE = Basic.CE;
                    Report.CF = Basic.CF;
                    Report.CG = Basic.CG;
                    Report.CH = Basic.CH;
                    Report.CI = Basic.CI;
                    Report.CJ = Basic.CJ;
                    Report.CK = Basic.CK;
                    Report.CL = Basic.CL;
                    Report.CM = Basic.CM;
                    Report.CN = Basic.CN;
                    Report.CO = Basic.CO;
                    Report.CP = Basic.CP;
                    Report.CQ = Basic.CQ;
                    Report.CR = Basic.CR;
                    Report.CS = Basic.CS;
                    Report.CT = Basic.CT;
                    Report.CU = Basic.CU;
                    Report.CV = Basic.CV;
                    Report.CW = Basic.CW;
                    Report.CX = Basic.CX;
                    Report.CY = Basic.CY;



                    #endregion

                    Reports.Add(Report);

                  

                    Report_Manager report_file = new Report_Manager();


                    report_file.Init_Excel_Report(@"E:\동해\기초자료\7호선\역사기초\1.역사_기초.xlsx", "기초");




                    if (Reports.Count > 0)
                    {

                        Basic_Writing_Report(report_file, Reports, LineCnt);
                    }
                    LineCnt++;
                    report_file.Save_Excel();
                    report_file.CloseExcel();

                }

                
            

                /******************기타데이터 **************/
                #region [ 기타데이터 변수 ]


                etc_Data etc_Data = new etc_Data();
                List<etc_Report_Data> Reports1 = new List<etc_Report_Data>();
                etc_Report_Data Report1 = new etc_Report_Data();

                string usage_limit = "사용제한 조치 및 중대결함사후관리";
                string usage = "결함발생부재";
                string cost_information = "비용정보 입력";
                string Total_input_cost = "투입비용총괄표";
                string maintenance_costs = "유지관리비용 추이";
                string facility = "시설물번호";

                string[] stringArray1 = new string[100];
                string stringcompare1 = "";
                string stringcompare2 = "";
                string stringcompare3 = "";
                string stringcompare4 = "";
                string stringcompare5 = "";
                string stringcompare6 = "";
                string stringcompare7 = "";

                string test1 = "";
                string test2 = "";
                string test3 = "";
                string test4 = "";
                string test5 = "";
                string test6 = "";
                string test7 = "";
                string test8 = "";
                string test9 = "";
                string test10 = "";
                string test11 = "";
                string test12 = "";


                int tempVal1 = 0;
                int tempVal2 = 0;
                int tempVal3 = 0;
                int tempVal4 = 0;
                int tempVal5 = 0;
                int tempVal6 = 0;

                int cnt1 = 0;
                int cnt2 = 1;
              


                int compare1 = 0;
                int compare2 = 0;

                int compare3 = 0;
                int compare4 = 0;

                int compare5 = 0;
                int compare6 = 0;
                int compare7 = 0;
                int compare8 = 0;

                bool stopflag = true;


                int stopcnt1 = 1;
                int stopcnt2 = 1;
                int stopcnt3 = 1;
                int stopcnt4 = 1;
                int stopcnt5 = 1;

                int stopcnttotal = 0;

                test1 = rm.Find(usage_limit);
                test2 = test1.Replace("$A$", "");
                int intVal1 = Convert.ToInt32(test2);
                compare1 = intVal1;
                compare1 += 1;
                tempVal1 = compare1;
                compare2 = compare1 + 5;

                test3 = rm.Find(usage);
                test4 = test3.Replace("$C$", "");
                int intVal2 = Convert.ToInt32(test4);
                intVal2 -= 2;
                compare3 = intVal2;
                tempVal2 = compare3;
                compare4 = compare3 + 10;

                test5 = rm.Find(cost_information);
                test6 = test5.Replace("$A$", "");
                int intVal3 = Convert.ToInt32(test6);
                compare5 = intVal3;
                tempVal3 = compare5 + 1;


                test7 = rm.Find(Total_input_cost);
                test8 = test7.Replace("$A$", "");
                int intVal4 = Convert.ToInt32(test8);
                compare6 = intVal4;
                tempVal4 = compare6 + 1;

                test9 = rm.Find(maintenance_costs);
                test10 = test9.Replace("$A$", "");
                int intVal5 = Convert.ToInt32(test10);
                compare7 = intVal5;
                tempVal5 = compare7 + 1;

                test11 = rm.Find(facility);
                test12 = test11.Replace("$A$", "");
                int intVal6 = Convert.ToInt32(test12);
                compare8 = intVal6;
                #endregion
               

                while (stopflag != false)
                {
                 

                    if (("사용제한 조치 및 중대결함사후관리" == rm.GetData(intVal1, 1).ToString()) && (start_key == 5))
                    {
                        #region [ # 사용제한 조치 ]


                        if ("n회" == rm.GetData(tempVal1, 2).ToString() || "3회" == rm.GetData(tempVal1, 2).ToString())
                        {
                            --start_key;
                        }

                        if ("1회" != rm.GetData(tempVal1, 2).ToString() && "n회" != rm.GetData(tempVal1, 2).ToString())
                        {
                            stringArray1[0] = rm.GetData(intVal6, 6) == null ? null : rm.GetData(intVal6, 6).ToString();
                            stringArray1[1] = rm.GetData(tempVal1, 2).ToString();
                            tempVal1++;
                            stringArray1[2] = rm.GetData(tempVal1, 6) == null ? null : rm.GetData(tempVal1, 6).ToString();
                            stringArray1[3] = rm.GetData(tempVal1, 6) == null ? null : rm.GetData(tempVal1, 6).ToString();
                            tempVal1++;
                            stringArray1[4] = rm.GetData(tempVal1, 6) == null ? null : rm.GetData(tempVal1, 6).ToString();
                            tempVal1++;
                            stringArray1[5] = rm.GetData(tempVal1, 6) == null ? null : rm.GetData(tempVal1, 6).ToString();
                            tempVal1++;



                        }

                        if ("1회" == rm.GetData(compare1, 2).ToString() && tempVal1 < compare2)
                        {
                            stringArray1[0] = rm.GetData(intVal6, 6) == null ? null : rm.GetData(intVal6, 6).ToString();
                            stringArray1[1] = rm.GetData(tempVal1, 2).ToString();
                            stringArray1[2] = rm.GetData(tempVal1, 6) == null ? null : rm.GetData(tempVal1, 6).ToString();
                            tempVal1++;
                            stringArray1[3] = rm.GetData(tempVal1, 6) == null ? null : rm.GetData(tempVal1, 6).ToString();
                            tempVal1++;
                            stringArray1[4] = rm.GetData(tempVal1, 6) == null ? null : rm.GetData(tempVal1, 6).ToString();
                            tempVal1++;
                            stringArray1[5] = rm.GetData(tempVal1, 6) == null ? null : rm.GetData(tempVal1, 6).ToString();
                            tempVal1++;
                        }

                        #endregion

                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////              
                    if (("중대결함사후관리" == rm.GetData(intVal2, 1).ToString()) && (start_key == 4))
                    {
                        #region [ # 중대결함사후관리 >> find는 결함발생부재 ]

                        if ("n회" == rm.GetData(tempVal2, 2).ToString())
                        {
                            start_key--;
                        }

                        if ("1회" != rm.GetData(tempVal2, 2).ToString() && "n회" != rm.GetData(tempVal2, 2).ToString())
                        {
                            stringArray1[0] = rm.GetData(intVal6, 6) == null ? null : rm.GetData(intVal6, 6).ToString();
                            stringArray1[1] = rm.GetData(tempVal2, 2).ToString();
                            tempVal2++;
                            tempVal2++;
                            stringArray1[6] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[7] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[8] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[9] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[10] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[11] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[12] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;



                        }

                        if ("1회" == rm.GetData(compare3, 2).ToString() && tempVal2 < compare4)
                        {
                            stringArray1[0] = rm.GetData(intVal6, 6) == null ? null : rm.GetData(intVal6, 6).ToString();
                            stringArray1[1] = rm.GetData(compare3, 2).ToString();
                            tempVal2++;
                            tempVal2++;
                            stringArray1[6] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[7] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[8] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[9] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[10] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[11] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                            stringArray1[12] = rm.GetData(tempVal2, 6) == null ? null : rm.GetData(tempVal2, 6).ToString();
                            tempVal2++;
                        }

                        #endregion

                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////  
                    if (("비용정보 입력" == rm.GetData(intVal3, 1).ToString()) && (start_key == 3))
                    {
                        #region [ # 비용정보 입력 ]

                        stringcompare1 = rm.GetData(tempVal3, 1).ToString() == null ? null : rm.GetData(tempVal3, 1).ToString();

                        stringcompare2 = stringcompare1.Substring(4, 2);

                        if ("년도" != stringcompare2)
                        {
                            start_key--;
                        }

                        if ("년도" == stringcompare2)
                        {
                            stringArray1[0] = rm.GetData(intVal6, 6) == null ? null : rm.GetData(intVal6, 6).ToString();
                            stringArray1[1] = rm.GetData(tempVal3, 1).ToString() == null ? null : rm.GetData(tempVal3, 1).ToString();
                            stringArray1[13] = rm.GetData(tempVal3, 6) == null ? null : rm.GetData(tempVal3, 6).ToString();
                            tempVal3++;
                            stringArray1[14] = rm.GetData(tempVal3, 6) == null ? null : rm.GetData(tempVal3, 6).ToString();
                            tempVal3++;
                            stringArray1[15] = rm.GetData(tempVal3, 6) == null ? null : rm.GetData(tempVal3, 6).ToString();
                            tempVal3++;
                            stringArray1[16] = rm.GetData(tempVal3, 6) == null ? null : rm.GetData(tempVal3, 6).ToString();
                            tempVal3++;
                            stringArray1[17] = rm.GetData(tempVal3, 6) == null ? null : rm.GetData(tempVal3, 6).ToString();
                            tempVal3++;
                            stringArray1[18] = rm.GetData(tempVal3, 6) == null ? null : rm.GetData(tempVal3, 6).ToString();
                            tempVal3++;

                        }


                        #endregion

                    }

                    if (("투입비용총괄표" == rm.GetData(intVal4, 1).ToString()) && (start_key == 2))
                    {
                        #region [ # 투입비용총괄표 ]

                        stringcompare3 = rm.GetData(tempVal4, 1).ToString() == null ? null : rm.GetData(tempVal4, 1).ToString();
                        stringcompare4 = stringcompare3.Substring(4, 2);

                        if ("년도" != stringcompare4)
                        {
                            start_key--;
                        }

                        if ("년도" == stringcompare4)
                        {
                            stringArray1[0] = rm.GetData(intVal6, 6) == null ? null : rm.GetData(intVal6, 6).ToString();
                            stringArray1[1] = rm.GetData(tempVal4, 1).ToString() == null ? null : rm.GetData(tempVal4, 1).ToString();
                            stringArray1[19] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[20] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[21] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[22] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[23] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[24] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[25] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[26] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[27] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[28] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[29] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[30] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[31] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[32] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[33] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[34] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[35] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[36] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[37] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[38] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[39] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[40] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[41] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[42] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[43] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[44] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[45] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[46] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[47] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[48] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[49] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;
                            stringArray1[50] = rm.GetData(tempVal4, 6) == null ? null : rm.GetData(tempVal4, 6).ToString();
                            tempVal4++;


                        }


                        #endregion

                    }

                    if (("유지관리비용 추이" == rm.GetData(intVal5, 1).ToString()) && (start_key == 1))
                    {
                        #region [ # 유지관리비용 추이 ]

                        stringcompare5 = rm.GetData(tempVal5, 1).ToString() == null ? null : rm.GetData(tempVal5, 1).ToString();
                        stringcompare6 = stringcompare5.Substring(4, 2);

                        if ("년도" != stringcompare6)
                        {
                            start_key--;
                        }

                        if ("년도" == stringcompare6)
                        {
                            stringArray1[0] = rm.GetData(intVal6, 6) == null ? null : rm.GetData(intVal6, 6).ToString();
                            stringArray1[1] = rm.GetData(tempVal5, 1).ToString() == null ? null : rm.GetData(tempVal5, 1).ToString();
                            stringArray1[51] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;
                            stringArray1[52] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;
                            stringArray1[53] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;
                            stringArray1[54] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;
                            stringArray1[55] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;
                            stringArray1[56] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;
                            stringArray1[57] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;
                            stringArray1[58] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;
                            stringArray1[59] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;
                            stringArray1[60] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;
                            stringArray1[61] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;
                            stringArray1[62] = rm.GetData(tempVal5, 6) == null ? null : rm.GetData(tempVal5, 6).ToString();
                            tempVal5++;

                        }


                        #endregion

                    }

                    //stopcnttotal = stopcnt1 + stopcnt2 + stopcnt3 + stopcnt4 + stopcnt5;
              

                    #region [ # 사용제한 조치 데이터 값 ]
                    if (start_key == 5)
                    {
                        etc_Data.A = stringArray1[0];
                        etc_Data.B = stringArray1[1];
                        etc_Data.C = stringArray1[2];
                        etc_Data.D = stringArray1[3];
                        etc_Data.E = stringArray1[4];
                        etc_Data.F = stringArray1[5];
                        Report1.A = etc_Data.A;
                        Report1.B = etc_Data.B;
                        Report1.B = etc_Data.B;
                        Report1.C = etc_Data.C;
                        Report1.D = etc_Data.D;
                        Report1.E = etc_Data.E;
                        Report1.F = etc_Data.F;
                    }
                    if (start_key < 5)
                    {

                        etc_Data.A = "";
                        etc_Data.B = "";
                        etc_Data.C = "";
                        etc_Data.D = "";
                        etc_Data.E = "";
                        etc_Data.F = "";
                        Report1.A = etc_Data.A;
                        Report1.B = etc_Data.B;
                        Report1.B = etc_Data.B;
                        Report1.C = etc_Data.C;
                        Report1.D = etc_Data.D;
                        Report1.E = etc_Data.E;
                        Report1.F = etc_Data.F;
                    }
                    #endregion

                    #region [ # 중대결함사후관리 데이터 값 ]
                    if (start_key == 4)
                    {
                        etc_Data.A = stringArray1[0];
                        etc_Data.B = stringArray1[1];
                        etc_Data.G = stringArray1[6];
                        etc_Data.H = stringArray1[7];
                        etc_Data.I = stringArray1[8];
                        etc_Data.J = stringArray1[9];
                        etc_Data.L = stringArray1[10];
                        etc_Data.K = stringArray1[11];
                        etc_Data.M = stringArray1[12];
                        Report1.A = etc_Data.A;
                        Report1.B = etc_Data.B;
                        Report1.G = etc_Data.G;
                        Report1.H = etc_Data.H;
                        Report1.I = etc_Data.I;
                        Report1.J = etc_Data.J;
                        Report1.L = etc_Data.L;
                        Report1.K = etc_Data.K;
                        Report1.M = etc_Data.M;
                    }

                    if (start_key < 4)
                    {
                        etc_Data.A = "";
                        etc_Data.B = "";
                        etc_Data.G = "";
                        etc_Data.H = "";
                        etc_Data.I = "";
                        etc_Data.J = "";
                        etc_Data.L = "";
                        etc_Data.K = "";
                        etc_Data.M = "";
                        Report1.A = etc_Data.A;
                        Report1.B = etc_Data.B;
                        Report1.G = etc_Data.G;
                        Report1.H = etc_Data.H;
                        Report1.I = etc_Data.I;
                        Report1.J = etc_Data.J;
                        Report1.L = etc_Data.L;
                        Report1.K = etc_Data.K;
                        Report1.M = etc_Data.M;
                    }
                    #endregion

                    #region [ # 비용정보 입력 데이터 값 ]
                    if (start_key == 3)
                    {

                        etc_Data.A = stringArray1[0];
                        etc_Data.B = stringArray1[1];
                        etc_Data.N = stringArray1[13];
                        etc_Data.O = stringArray1[14];
                        etc_Data.P = stringArray1[15];
                        etc_Data.Q = stringArray1[16];
                        etc_Data.R = stringArray1[17];
                        etc_Data.S = stringArray1[18];
                        Report1.A = etc_Data.A;
                        Report1.B = etc_Data.B;
                        Report1.N = etc_Data.N;
                        Report1.O = etc_Data.O;
                        Report1.P = etc_Data.P;
                        Report1.Q = etc_Data.Q;
                        Report1.R = etc_Data.R;
                        Report1.S = etc_Data.S;
                    }
                    if (start_key < 3)
                    {

                        etc_Data.A = "";
                        etc_Data.B = "";
                        etc_Data.N = "";
                        etc_Data.O = "";
                        etc_Data.P = "";
                        etc_Data.Q = "";
                        etc_Data.R = "";
                        etc_Data.S = "";
                        Report1.A = etc_Data.A;
                        Report1.B = etc_Data.B;
                        Report1.N = etc_Data.N;
                        Report1.O = etc_Data.O;
                        Report1.P = etc_Data.P;
                        Report1.Q = etc_Data.Q;
                        Report1.R = etc_Data.R;
                        Report1.S = etc_Data.S;
                    }

                    #endregion

                    #region [ # 투입비용총괄표 데이터 값 ]
                    if (start_key == 2)
                    {
                        etc_Data.A = stringArray1[0];
                        etc_Data.B = stringArray1[1];
                        etc_Data.T = stringArray1[19];
                        etc_Data.U = stringArray1[20];
                        etc_Data.V = stringArray1[21];
                        etc_Data.W = stringArray1[22];
                        etc_Data.X = stringArray1[23];
                        etc_Data.Y = stringArray1[24];
                        etc_Data.Z = stringArray1[25];
                        etc_Data.AA = stringArray1[26];
                        etc_Data.AB = stringArray1[27];
                        etc_Data.AC = stringArray1[28];
                        etc_Data.AD = stringArray1[29];
                        etc_Data.AE = stringArray1[30];
                        etc_Data.AF = stringArray1[31];
                        etc_Data.AG = stringArray1[32];
                        etc_Data.AH = stringArray1[33];
                        etc_Data.AI = stringArray1[34];
                        etc_Data.AJ = stringArray1[35];
                        etc_Data.AK = stringArray1[36];
                        etc_Data.AL = stringArray1[37];
                        etc_Data.AM = stringArray1[38];
                        etc_Data.AN = stringArray1[39];
                        etc_Data.AO = stringArray1[40];
                        etc_Data.AP = stringArray1[41];
                        etc_Data.AQ = stringArray1[42];
                        etc_Data.AR = stringArray1[43];
                        etc_Data.AS = stringArray1[44];
                        etc_Data.AT = stringArray1[45];
                        etc_Data.AU = stringArray1[46];
                        etc_Data.AV = stringArray1[47];
                        etc_Data.AW = stringArray1[48];
                        etc_Data.AX = stringArray1[49];
                        etc_Data.AY = stringArray1[50];

                        Report1.A = etc_Data.A;
                        Report1.B = etc_Data.B;
                        Report1.T = etc_Data.T;
                        Report1.U = etc_Data.U;
                        Report1.V = etc_Data.V;
                        Report1.W = etc_Data.W;
                        Report1.X = etc_Data.X;
                        Report1.Y = etc_Data.Y;
                        Report1.Z = etc_Data.Z;
                        Report1.AA = etc_Data.AA;
                        Report1.AB = etc_Data.AB;
                        Report1.AC = etc_Data.AC;
                        Report1.AD = etc_Data.AD;
                        Report1.AE = etc_Data.AE;
                        Report1.AF = etc_Data.AF;
                        Report1.AG = etc_Data.AG;
                        Report1.AH = etc_Data.AH;
                        Report1.AI = etc_Data.AI;
                        Report1.AJ = etc_Data.AJ;
                        Report1.AK = etc_Data.AK;
                        Report1.AL = etc_Data.AL;
                        Report1.AM = etc_Data.AM;
                        Report1.AN = etc_Data.AN;
                        Report1.AO = etc_Data.AO;
                        Report1.AP = etc_Data.AP;
                        Report1.AQ = etc_Data.AQ;
                        Report1.AR = etc_Data.AR;
                        Report1.AS = etc_Data.AS;
                        Report1.AT = etc_Data.AT;
                        Report1.AU = etc_Data.AU;
                        Report1.AV = etc_Data.AV;
                        Report1.AW = etc_Data.AW;
                        Report1.AX = etc_Data.AX;
                        Report1.AY = etc_Data.AY;


                    }
                    if (start_key < 2)
                    {
                        etc_Data.A = "";
                        etc_Data.B = "";
                        etc_Data.T = "";
                        etc_Data.U = "";
                        etc_Data.V = "";
                        etc_Data.W = "";
                        etc_Data.X = "";
                        etc_Data.Y = "";
                        etc_Data.Z = "";
                        etc_Data.AA = "";
                        etc_Data.AB = "";
                        etc_Data.AC = "";
                        etc_Data.AD = "";
                        etc_Data.AE = "";
                        etc_Data.AF = "";
                        etc_Data.AG = "";
                        etc_Data.AH = "";
                        etc_Data.AI = "";
                        etc_Data.AJ = "";
                        etc_Data.AK = "";
                        etc_Data.AL = "";
                        etc_Data.AM = "";
                        etc_Data.AN = "";
                        etc_Data.AO = "";
                        etc_Data.AP = "";
                        etc_Data.AQ = "";
                        etc_Data.AR = "";
                        etc_Data.AS = "";
                        etc_Data.AT = "";
                        etc_Data.AU = "";
                        etc_Data.AV = "";
                        etc_Data.AW = "";
                        etc_Data.AX = "";
                        etc_Data.AY = "";

                        Report1.A = etc_Data.A;
                        Report1.B = etc_Data.B;
                        Report1.T = etc_Data.T;
                        Report1.U = etc_Data.U;
                        Report1.V = etc_Data.V;
                        Report1.W = etc_Data.W;
                        Report1.X = etc_Data.X;
                        Report1.Y = etc_Data.Y;
                        Report1.Z = etc_Data.Z;
                        Report1.AA = etc_Data.AA;
                        Report1.AB = etc_Data.AB;
                        Report1.AC = etc_Data.AC;
                        Report1.AD = etc_Data.AD;
                        Report1.AE = etc_Data.AE;
                        Report1.AF = etc_Data.AF;
                        Report1.AG = etc_Data.AG;
                        Report1.AH = etc_Data.AH;
                        Report1.AI = etc_Data.AI;
                        Report1.AJ = etc_Data.AJ;
                        Report1.AK = etc_Data.AK;
                        Report1.AL = etc_Data.AL;
                        Report1.AM = etc_Data.AM;
                        Report1.AN = etc_Data.AN;
                        Report1.AO = etc_Data.AO;
                        Report1.AP = etc_Data.AP;
                        Report1.AQ = etc_Data.AQ;
                        Report1.AR = etc_Data.AR;
                        Report1.AS = etc_Data.AS;
                        Report1.AT = etc_Data.AT;
                        Report1.AU = etc_Data.AU;
                        Report1.AV = etc_Data.AV;
                        Report1.AW = etc_Data.AW;
                        Report1.AX = etc_Data.AX;
                        Report1.AY = etc_Data.AY;

                    }

                    #endregion

                    #region [ # 유지관리비용 추이 데이터 값 ]

                    if (start_key == 1)
                    {
                        etc_Data.A = stringArray1[0];
                        etc_Data.B = stringArray1[1];
                        etc_Data.AZ = stringArray1[51];
                        etc_Data.BA = stringArray1[52];
                        etc_Data.BB = stringArray1[53];
                        etc_Data.BC = stringArray1[54];
                        etc_Data.BD = stringArray1[55];
                        etc_Data.BE = stringArray1[56];
                        etc_Data.BF = stringArray1[57];
                        etc_Data.BG = stringArray1[58];
                        etc_Data.BH = stringArray1[59];
                        etc_Data.BI = stringArray1[60];
                        etc_Data.BJ = stringArray1[61];
                        etc_Data.BK = stringArray1[62];

                        Report1.A = etc_Data.A;
                        Report1.B = etc_Data.B;
                        Report1.AZ = etc_Data.AZ;
                        Report1.BA = etc_Data.BA;
                        Report1.BB = etc_Data.BB;
                        Report1.BC = etc_Data.BC;
                        Report1.BD = etc_Data.BD;
                        Report1.BE = etc_Data.BE;
                        Report1.BF = etc_Data.BF;
                        Report1.BG = etc_Data.BG;
                        Report1.BH = etc_Data.BH;
                        Report1.BI = etc_Data.BI;
                        Report1.BJ = etc_Data.BJ;
                        Report1.BK = etc_Data.BK;

                    }

                    if (start_key < 1)
                    {
                        etc_Data.A = "";
                        etc_Data.B = "";
                        etc_Data.AZ = "";
                        etc_Data.BA = "";
                        etc_Data.BB = "";
                        etc_Data.BC = "";
                        etc_Data.BD = "";
                        etc_Data.BE = "";
                        etc_Data.BF = "";
                        etc_Data.BG = "";
                        etc_Data.BH = "";
                        etc_Data.BI = "";
                        etc_Data.BJ = "";
                        etc_Data.BK = "";
                        Report1.A = etc_Data.A;
                        Report1.B = etc_Data.B;
                        Report1.AZ = etc_Data.AZ;
                        Report1.BA = etc_Data.BA;
                        Report1.BB = etc_Data.BB;
                        Report1.BC = etc_Data.BC;
                        Report1.BD = etc_Data.BD;
                        Report1.BE = etc_Data.BE;
                        Report1.BF = etc_Data.BF;
                        Report1.BG = etc_Data.BG;
                        Report1.BH = etc_Data.BH;
                        Report1.BI = etc_Data.BI;
                        Report1.BJ = etc_Data.BJ;
                        Report1.BK = etc_Data.BK;


                    }


                    #endregion


                    Reports1.Add(Report1);


                    string pathaddress1 = @"E:\동해\기초자료\7호선\역사기타";
                    string[] Files_List1 = new string[100];
                    string Files_FullName1 = "";

                    if (System.IO.Directory.Exists(pathaddress1))
                    {

                        int index = 0;
                        foreach (string s in System.IO.Directory.GetFiles(pathaddress1))
                        {
                            Files_List1[index] += s;
                            ++index;

                        }
                    }

                    if (null != Files_List1[pathcnt])
                    {
                        Files_FullName1 = Files_List1[pathcnt];


                    }

                    Report_Manager report_file1 = new Report_Manager();
                    report_file1.Init_Excel_Report(Files_FullName1, "기타");

                    if (Reports1.Count > 0)
                    {

                        etc_Writing_Report(report_file1, Reports1);
                    }
                    report_file1.Save_Excel();
                    report_file1.CloseExcel();

                    if (start_key == 0)
                    {
                        stopflag = false;
                    }

                }

                rm.CloseExcel();

                LineCnt++;

                pathcnt++;

    
            }


        }   

     



        private Facility_Info Find_Facility(string name)
        {
            Facility_Info res = new Facility_Info();
            res.Facility_Name = "-";
            res.Facility_Num = "-";

            string[] sub = name.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            sub = sub[1].Split(new string[] { "-", "_" }, StringSplitOptions.RemoveEmptyEntries);

            string s_name = sub[0];
            //   string e_name = sub[1];

            foreach (Facility_Info fi in Facilities)
            {
                if ((fi.Facility_Name.Contains(s_name) == true))
                {
                    res = fi;
                }

            }

            return res;
        }

        public struct Post_Row_Proc
        {
            public bool is_row;
            public int ck_row;
        }

        private bool is_row = false;

        private List<Post_Row_Proc> PostRows = new List<Post_Row_Proc>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Data_Index> Search_Index(string WB, Sheet_Info si)
        {
            List<Data_Index> Data_Indexes = new List<Data_Index>();

            List<string> Items = new List<string>();
            Items.Add(si.Parts_Level3);
            Items.Add(si.Parts_Level4);
            Items.Add(si.Parts_Level5);
            Items.Add(si.Parts_Level6);
            Items.Add(si.Performance_Improve);
            Items.Add(si.Parts_Grade);
            Items.Add(si.Parts_Defect);
            Items.Add(si.Damage_Type);
            Items.Add(si.Damage_Points);
            Items.Add(si.Damage_Picture);
            Items.Add(si.Maintenance_Plan);
            Items.Add(si.Maintenance_Method);
            Items.Add(si.Maintenance_Quantity);
            Items.Add(si.Maintenance_Quantity_Unit);
            Items.Add(si.Maintenance_Unit_Price);
            Items.Add(si.Maintenance_Cost);
            Items.Add(si.Remarks);

            foreach (string item in Items)
            {
                if (item.Equals("-") == false)
                {
                    if (item.Contains("/") == true)
                    {
                        Data_Indexes.Add(Proc_Index_Slash(item, Convert.ToInt32(si.Data_Index)));

                        if (is_row == true)
                        {
                            Post_Row_Proc prp = new Post_Row_Proc();
                            prp.is_row = true;
                            prp.ck_row = Data_Indexes.Count - 1;

                            is_row = false;
                        }
                    }
                    else if (item.Contains("~") == true)
                    {
                        int offset = 0;

                        if ((WB.Equals("G") == true) && (si.Processing.Equals("B") == true))
                        {
                            if ((Items.IndexOf(item) == 5) || (Items.IndexOf(item) == 8))
                            {
                                if ((Items[5].Contains("~") == true) && (Items[8].Contains("~") == true))
                                {
                                    string[] sub = Items[5].Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
                                    int s = Indexer[sub[0]];

                                    sub = Items[8].Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
                                    int e = Indexer[sub[0]];

                                    offset = Math.Abs(e - s);
                                }
                            }
                        }

                        Data_Indexes.Add(Proc_Index_Tild(item, Convert.ToInt32(si.Data_Index), offset));

                        if (is_row == true)
                        {
                            Post_Row_Proc prp = new Post_Row_Proc();
                            prp.is_row = true;
                            prp.ck_row = Data_Indexes.Count - 1;

                            PostRows.Add(prp);

                            is_row = false;
                        }
                    }
                    else
                    {
                        if (item.Contains("+") == true)
                        {
                            Data_Index new_DX = new Data_Index();
                            new_DX.row = new List<List<int>>();
                            new_DX.col = new List<List<int>>();

                            List<int> buff = new List<int>();
                            buff.Add(Convert.ToInt32(si.Data_Index));
                            new_DX.row.Add(buff);

                            new_DX.col.Add(Proc_Index_Plus(item));

                            Data_Indexes.Add(new_DX);
                        }
                        else
                        {
                            Data_Index new_DX = new Data_Index();
                            new_DX.row = new List<List<int>>();
                            new_DX.col = new List<List<int>>();

                            int tmp;

                            if (int.TryParse(item, out tmp) == false)
                            {
                                List<int> buff = new List<int>();
                                buff.Add(Indexer[item]);
                                new_DX.col.Add(buff);

                                buff = new List<int>();
                                buff.Add(Convert.ToInt32(si.Data_Index));
                                new_DX.row.Add(buff);
                            }
                            else
                            {
                                List<int> buff = new List<int>();
                                new_DX.col.Add(buff);

                                buff = new List<int>();
                                buff.Add(Convert.ToInt32(item));
                                new_DX.row.Add(buff);
                            }

                            Data_Indexes.Add(new_DX);
                        }
                    }
                }
                else
                {
                    Data_Index empty = new Data_Index();
                    empty.row = new List<List<int>>();
                    empty.col = new List<List<int>>();

                    Data_Indexes.Add(empty);
                }
            }

            foreach (Post_Row_Proc prp in PostRows)
            {
                if (prp.is_row == true)
                {
                    Data_Index tmp_one = new Data_Index();
                    tmp_one.row = Data_Indexes[prp.ck_row].row;
                    tmp_one.col = Data_Indexes[8].col;

                    Data_Indexes[prp.ck_row] = tmp_one;
                }
            }

            PostRows.Clear();

            return Data_Indexes;
        }

        private List<int> Proc_Index_Plus(string index)
        {
            string[] sub = index.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> idx = new List<int>();
            int tmp;

            foreach (string str in sub)
            {
                if (int.TryParse(str, out tmp) == false)
                {
                    idx.Add(Indexer[str.ToUpper()]);
                }
                else
                {
                    idx.Add(Convert.ToInt32(str));
                }
            }

            return idx;
        }

        private Data_Index Proc_Index_Tild(string index, int d_index, int offset)
        {
            Data_Index new_DX = new Data_Index();
            new_DX.row = new List<List<int>>();
            new_DX.col = new List<List<int>>();

            string[] sub = index.Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
            int tmp, start, end;

            if (int.TryParse(sub[0], out tmp) == false)
            {
                List<int> buff = new List<int>();
                buff.Add(d_index);
                new_DX.row.Add(buff);

                if (sub[0].Contains("+") == true)
                {
                    buff = Proc_Index_Plus(sub[0]);
                    new_DX.col.Add(buff);

                    start = buff[buff.Count - 1] + 1;
                    end   = Indexer[sub[1].ToUpper()];
                }
                else if (sub[1].Contains("+") == true)
                {
                    buff = Proc_Index_Plus(sub[1]);
                    new_DX.col.Add(buff);

                    start = Indexer[sub[0].ToUpper()];
                    end   = buff[0] - 1;

                }
                else
                {
                    start = Indexer[sub[0].ToUpper()];
                    end   = Indexer[sub[1].ToUpper()];
                }

                for (int i = start; i <= end; i += (1 + offset))
                {
                    buff = new List<int>();
                    buff.Add(i);
                    new_DX.col.Add(buff);
                }
            }
            else
            {
                List<int> buff = new List<int>();

                start = Convert.ToInt32(sub[0]);
                end = Convert.ToInt32(sub[1]);

                for (int i = start; i <= end; i++)
                {
                    buff = new List<int>();
                    buff.Add(i);
                    new_DX.row.Add(buff);
                }

                is_row = true;
            }

            return new_DX;
        }

        private Data_Index Proc_Index_Slash(string index, int d_index)
        {
            Data_Index new_DX = new Data_Index();
            new_DX.row = new List<List<int>>();
            new_DX.col = new List<List<int>>();

            string[] sub = index.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            int tmp;

            if (int.TryParse(sub[0], out tmp) == false)
            {
                List<int> buff = new List<int>();
                buff.Add(d_index);
                new_DX.row.Add(buff);

                if (sub[0].Contains("+") == true)
                {
                    buff = Proc_Index_Plus(sub[0]);
                    new_DX.col.Add(buff);

                    buff = new List<int>();
                    buff.Add(-1);
                    new_DX.col.Add(buff);

                    buff = new List<int>();
                    buff.Add(Indexer[sub[1].ToUpper()]);
                    new_DX.col.Add(buff);
                }
                else if (sub[1].Contains("+") == true)
                {
                    buff = new List<int>();
                    buff.Add(Indexer[sub[0].ToUpper()]);
                    new_DX.col.Add(buff);

                    buff = new List<int>();
                    buff.Add(-1);
                    new_DX.col.Add(buff);

                    buff = Proc_Index_Plus(sub[1]);
                    new_DX.col.Add(buff);
                }
                else
                {
                    buff = new List<int>();
                    buff.Add(Indexer[sub[0].ToUpper()]);
                    new_DX.col.Add(buff);

                    buff = new List<int>();
                    buff.Add(-1);
                    new_DX.col.Add(buff);

                    buff = new List<int>();
                    buff.Add(Indexer[sub[1].ToUpper()]);
                    new_DX.col.Add(buff);
                }
            }
            else
            {
                List<int> buff = new List<int>();

                buff = new List<int>();
                buff.Add(Convert.ToInt32(sub[0]));
                new_DX.row.Add(buff);

                buff = new List<int>();
                buff.Add(-1);
                new_DX.row.Add(buff);

                buff = new List<int>();
                buff.Add(Convert.ToInt32(sub[1]));
                new_DX.row.Add(buff);

                is_row = true;
            }

            return new_DX;
        }

        private void Gathering_Data(Sheet_Info si)
        {

        }

        private void Writing_Report(Report_Manager rm, List<Basic_Report_Data> Datas)
        {
            int idx = 2;
            string sheet_name = string.Empty;

            while (true)
            {
                sheet_name = "기초 (" + idx + ")";

                if (rm.Existing_Sheet(sheet_name) == false)
                {
                    break;
                }

                idx++;
            }

            idx--;
            sheet_name = "기초 (" + idx + ")";

            if (idx == 1)
            {
                rm.Change_Worksheet("기초");
            }
            else
            {
                rm.Change_Worksheet(sheet_name);
            }

            int s_idx = 0;

         /*   while (true)
            {
                object tmp = rm.GetData(s_idx + 1, 1);

                if (tmp == null)
                {
                    break;
                }

                s_idx++;
            }
            */
            int pages = 0;
            int index;
            int start = s_idx + 6;

            List<string> Data_Sets = new List<string>();

            for (int i = 0; i < Datas.Count; i++)
            {
                index = (s_idx + i) - (3000 * pages) + 7;

                if (index > 3000)
                {
                    try
                    {
                        rm.Change_Worksheet("샘플");

                        idx = 2;
                        sheet_name = string.Empty;

                        while (true)
                        {
                            sheet_name = "기초 (" + idx + ")";

                            if (rm.Existing_Sheet(sheet_name) == false)
                            {
                                break;
                            }

                            idx++;
                        }

                        rm.Copy_Worksheet(rm.exlWorkSheet, sheet_name);
                        rm.Change_Worksheet(sheet_name);
                        start = 2;

                        rm.Save_Excel();

                    }
                    catch (Exception exx)
                    {
                        string test = exx.Message;
                    }

                    pages++;

                    index = (s_idx + i) - (2999 * pages) + 1;
                }

                Data_Sets.Add(Datas[i].A);
                Data_Sets.Add(Datas[i].B);
                Data_Sets.Add(Datas[i].C);
                Data_Sets.Add(Datas[i].D);
                Data_Sets.Add(Datas[i].E);
                Data_Sets.Add(Datas[i].F);
                Data_Sets.Add(Datas[i].G);
                Data_Sets.Add(Datas[i].H);
                Data_Sets.Add(Datas[i].I);
                Data_Sets.Add(Datas[i].J);
                Data_Sets.Add(Datas[i].K);
                Data_Sets.Add(Datas[i].L);
                Data_Sets.Add(Datas[i].M);
                Data_Sets.Add(Datas[i].N);
                Data_Sets.Add(Datas[i].O);
                Data_Sets.Add(Datas[i].P);
                Data_Sets.Add(Datas[i].Q);
                Data_Sets.Add(Datas[i].R);
                Data_Sets.Add(Datas[i].S);
                Data_Sets.Add(Datas[i].T);
                Data_Sets.Add(Datas[i].U);
                Data_Sets.Add(Datas[i].V);
                Data_Sets.Add(Datas[i].W);
                Data_Sets.Add(Datas[i].X);
                Data_Sets.Add(Datas[i].Y);
                Data_Sets.Add(Datas[i].Z);
      
                Data_Sets.Add(Datas[i].AA);
                Data_Sets.Add(Datas[i].AB);
                Data_Sets.Add(Datas[i].AC);
                Data_Sets.Add(Datas[i].AD);
                Data_Sets.Add(Datas[i].AE);
                Data_Sets.Add(Datas[i].AF);
                Data_Sets.Add(Datas[i].AG);              
                Data_Sets.Add(Datas[i].AH);
                Data_Sets.Add(Datas[i].AI);
                Data_Sets.Add(Datas[i].AJ);
                Data_Sets.Add(Datas[i].AK);
                Data_Sets.Add(Datas[i].AL);
                Data_Sets.Add(Datas[i].AM);
                Data_Sets.Add(Datas[i].AN);
                Data_Sets.Add(Datas[i].AO);
                Data_Sets.Add(Datas[i].AP);
                Data_Sets.Add(Datas[i].AQ);
                Data_Sets.Add(Datas[i].AR);
                Data_Sets.Add(Datas[i].AS);
                Data_Sets.Add(Datas[i].AT);
                Data_Sets.Add(Datas[i].AU);
                Data_Sets.Add(Datas[i].AV);
                Data_Sets.Add(Datas[i].AW);
                Data_Sets.Add(Datas[i].AX);
                Data_Sets.Add(Datas[i].AY);
                Data_Sets.Add(Datas[i].AZ);

                Data_Sets.Add(Datas[i].BA);
                Data_Sets.Add(Datas[i].BB);
                Data_Sets.Add(Datas[i].BC);
                Data_Sets.Add(Datas[i].BD);
                Data_Sets.Add(Datas[i].BE);
                Data_Sets.Add(Datas[i].BF);
                Data_Sets.Add(Datas[i].BG);
                Data_Sets.Add(Datas[i].BH);                     
                Data_Sets.Add(Datas[i].BI);           
                Data_Sets.Add(Datas[i].BJ);
                Data_Sets.Add(Datas[i].BK);
                Data_Sets.Add(Datas[i].BL);
                Data_Sets.Add(Datas[i].BM);
                Data_Sets.Add(Datas[i].BN);
                Data_Sets.Add(Datas[i].BO);
                Data_Sets.Add(Datas[i].BP);
                Data_Sets.Add(Datas[i].BQ);
                Data_Sets.Add(Datas[i].BR);
                Data_Sets.Add(Datas[i].BS);
                Data_Sets.Add(Datas[i].BT);
                Data_Sets.Add(Datas[i].BU);
                Data_Sets.Add(Datas[i].BV);
                Data_Sets.Add(Datas[i].BW);
                Data_Sets.Add(Datas[i].BX);
                Data_Sets.Add(Datas[i].BY);
                Data_Sets.Add(Datas[i].BZ);

                Data_Sets.Add(Datas[i].CA);
                Data_Sets.Add(Datas[i].CB);
                Data_Sets.Add(Datas[i].CC);
                Data_Sets.Add(Datas[i].CD);
                Data_Sets.Add(Datas[i].CE);
                Data_Sets.Add(Datas[i].CF);
                Data_Sets.Add(Datas[i].CG);
                Data_Sets.Add(Datas[i].CH);
                Data_Sets.Add(Datas[i].CI);
                Data_Sets.Add(Datas[i].CJ);
                Data_Sets.Add(Datas[i].CK);
                Data_Sets.Add(Datas[i].CL);
                Data_Sets.Add(Datas[i].CM);
                Data_Sets.Add(Datas[i].CN);
                Data_Sets.Add(Datas[i].CO);
                Data_Sets.Add(Datas[i].CP);
                Data_Sets.Add(Datas[i].CQ);               
                Data_Sets.Add(Datas[i].CR);
                Data_Sets.Add(Datas[i].CS);
                Data_Sets.Add(Datas[i].CT);
                Data_Sets.Add(Datas[i].CU);
                Data_Sets.Add(Datas[i].CV);
                Data_Sets.Add(Datas[i].CW);
                Data_Sets.Add(Datas[i].CX);
                Data_Sets.Add(Datas[i].CY);
                Data_Sets.Add(Datas[i].CZ);

                Data_Sets.Add(Datas[i].DA);
                Data_Sets.Add(Datas[i].DB);
                Data_Sets.Add(Datas[i].DC);
                Data_Sets.Add(Datas[i].DD);
                Data_Sets.Add(Datas[i].DE);
                Data_Sets.Add(Datas[i].DF);
                Data_Sets.Add(Datas[i].DG);

                /*      
                Data_Sets.Add(Datas[i].XA);
                Data_Sets.Add(Datas[i].XB);     
                Data_Sets.Add(Datas[i].XC);
                Data_Sets.Add(Datas[i].XD);
                Data_Sets.Add(Datas[i].XK);
                Data_Sets.Add(Datas[i].XL);                           
                Data_Sets.Add(Datas[i].XN);
                Data_Sets.Add(Datas[i].XE);
                Data_Sets.Add(Datas[i].XF);
                Data_Sets.Add(Datas[i].XG);
                Data_Sets.Add(Datas[i].XJ);
                Data_Sets.Add(Datas[i].XM);
                */
                rm.InsertExcel("A" + index, Data_Sets.ToArray());
                  
                Data_Sets.Clear();
            }

            rm.Save_Excel();
            
            //MessageBox.Show("완료");
        }

        private void Basic_Writing_Report(Report_Manager rm, List<Basic_Report_Data> Datas, int LineCnt)
        {
            int idx = 2;
            string sheet_name = string.Empty;

            while (true)
            {
                sheet_name = "기초 (" + idx + ")";

                if (rm.Existing_Sheet(sheet_name) == false)
                {
                    break;
                }

                idx++;
            }

            idx--;
            sheet_name = "기초 (" + idx + ")";

            if (idx == 1)
            {
                rm.Change_Worksheet("기초");
            }
            else
            {
                rm.Change_Worksheet(sheet_name);
            }

            int s_idx = 0;

            /*   while (true)
               {
                   object tmp = rm.GetData(s_idx + 1, 1);

                   if (tmp == null)
                   {
                       break;
                   }

                   s_idx++;
               }
               */
            int pages = 0;
            int index;
            int start = s_idx + 6;

            List<string> Data_Sets = new List<string>();

            for (int i = 0; i < Datas.Count; i++)
            {
                index = (s_idx + i) - (3000 * pages) + 7 + LineCnt;

                if (index > 3000)
                {
                    try
                    {
                        rm.Change_Worksheet("샘플");

                        idx = 2;
                        sheet_name = string.Empty;

                        while (true)
                        {
                            sheet_name = "기초 (" + idx + ")";

                            if (rm.Existing_Sheet(sheet_name) == false)
                            {
                                break;
                            }

                            idx++;
                        }

                        rm.Copy_Worksheet(rm.exlWorkSheet, sheet_name);
                        rm.Change_Worksheet(sheet_name);
                        start = 2;

                        rm.Save_Excel();

                    }
                    catch (Exception exx)
                    {
                        string test = exx.Message;
                    }

                    pages++;

                    index = (s_idx + i) - (2999 * pages) + 1;
                }

                Data_Sets.Add(Datas[i].A);
                Data_Sets.Add(Datas[i].B);
                Data_Sets.Add(Datas[i].C);
                Data_Sets.Add(Datas[i].D);
                Data_Sets.Add(Datas[i].E);
                Data_Sets.Add(Datas[i].F);
                Data_Sets.Add(Datas[i].G);
                Data_Sets.Add(Datas[i].H);
                Data_Sets.Add(Datas[i].I);
                Data_Sets.Add(Datas[i].J);
                Data_Sets.Add(Datas[i].K);
                Data_Sets.Add(Datas[i].L);
                Data_Sets.Add(Datas[i].M);
                Data_Sets.Add(Datas[i].N);
                Data_Sets.Add(Datas[i].O);
                Data_Sets.Add(Datas[i].P);
                Data_Sets.Add(Datas[i].Q);
                Data_Sets.Add(Datas[i].R);
                Data_Sets.Add(Datas[i].S);
                Data_Sets.Add(Datas[i].T);
                Data_Sets.Add(Datas[i].U);
                Data_Sets.Add(Datas[i].V);
                Data_Sets.Add(Datas[i].W);
                Data_Sets.Add(Datas[i].X);
                Data_Sets.Add(Datas[i].Y);
                Data_Sets.Add(Datas[i].Z);

                Data_Sets.Add(Datas[i].AA);
                Data_Sets.Add(Datas[i].AB);
                Data_Sets.Add(Datas[i].AC);
                Data_Sets.Add(Datas[i].AD);
                Data_Sets.Add(Datas[i].AE);
                Data_Sets.Add(Datas[i].AF);
                Data_Sets.Add(Datas[i].AG);
                Data_Sets.Add(Datas[i].AH);
                Data_Sets.Add(Datas[i].AI);
                Data_Sets.Add(Datas[i].AJ);
                Data_Sets.Add(Datas[i].AK);
                Data_Sets.Add(Datas[i].AL);
                Data_Sets.Add(Datas[i].AM);
                Data_Sets.Add(Datas[i].AN);
                Data_Sets.Add(Datas[i].AO);
                Data_Sets.Add(Datas[i].AP);
                Data_Sets.Add(Datas[i].AQ);
                Data_Sets.Add(Datas[i].AR);
                Data_Sets.Add(Datas[i].AS);
                Data_Sets.Add(Datas[i].AT);
                Data_Sets.Add(Datas[i].AU);
                Data_Sets.Add(Datas[i].AV);
                Data_Sets.Add(Datas[i].AW);
                Data_Sets.Add(Datas[i].AX);
                Data_Sets.Add(Datas[i].AY);
                Data_Sets.Add(Datas[i].AZ);

                Data_Sets.Add(Datas[i].BA);
                Data_Sets.Add(Datas[i].BB);
                Data_Sets.Add(Datas[i].BC);
                Data_Sets.Add(Datas[i].BD);
                Data_Sets.Add(Datas[i].BE);
                Data_Sets.Add(Datas[i].BF);
                Data_Sets.Add(Datas[i].BG);
                Data_Sets.Add(Datas[i].BH);
                Data_Sets.Add(Datas[i].BI);
                Data_Sets.Add(Datas[i].BJ);
                Data_Sets.Add(Datas[i].BK);
                Data_Sets.Add(Datas[i].BL);
                Data_Sets.Add(Datas[i].BM);
                Data_Sets.Add(Datas[i].BN);
                Data_Sets.Add(Datas[i].BO);
                Data_Sets.Add(Datas[i].BP);
                Data_Sets.Add(Datas[i].BQ);
                Data_Sets.Add(Datas[i].BR);
                Data_Sets.Add(Datas[i].BS);
                Data_Sets.Add(Datas[i].BT);
                Data_Sets.Add(Datas[i].BU);
                Data_Sets.Add(Datas[i].BV);
                Data_Sets.Add(Datas[i].BW);
                Data_Sets.Add(Datas[i].BX);
                Data_Sets.Add(Datas[i].BY);
                Data_Sets.Add(Datas[i].BZ);

                Data_Sets.Add(Datas[i].CA);
                Data_Sets.Add(Datas[i].CB);
                Data_Sets.Add(Datas[i].CC);
                Data_Sets.Add(Datas[i].CD);
                Data_Sets.Add(Datas[i].CE);
                Data_Sets.Add(Datas[i].CF);
                Data_Sets.Add(Datas[i].CG);
                Data_Sets.Add(Datas[i].CH);
                Data_Sets.Add(Datas[i].CI);
                Data_Sets.Add(Datas[i].CJ);
                Data_Sets.Add(Datas[i].CK);
                Data_Sets.Add(Datas[i].CL);
                Data_Sets.Add(Datas[i].CM);
                Data_Sets.Add(Datas[i].CN);
                Data_Sets.Add(Datas[i].CO);
                Data_Sets.Add(Datas[i].CP);
                Data_Sets.Add(Datas[i].CQ);
                Data_Sets.Add(Datas[i].CR);
                Data_Sets.Add(Datas[i].CS);
                Data_Sets.Add(Datas[i].CT);
                Data_Sets.Add(Datas[i].CU);
                Data_Sets.Add(Datas[i].CV);
                Data_Sets.Add(Datas[i].CW);
                Data_Sets.Add(Datas[i].CX);
                Data_Sets.Add(Datas[i].CY);
                Data_Sets.Add(Datas[i].CZ);

                Data_Sets.Add(Datas[i].DA);
                Data_Sets.Add(Datas[i].DB);
                Data_Sets.Add(Datas[i].DC);
                Data_Sets.Add(Datas[i].DD);
                Data_Sets.Add(Datas[i].DE);
                Data_Sets.Add(Datas[i].DF);
                Data_Sets.Add(Datas[i].DG);
    
                Data_Sets.Add(Datas[i].XA);
                Data_Sets.Add(Datas[i].XB);     
                Data_Sets.Add(Datas[i].XC);
                Data_Sets.Add(Datas[i].XD);
                Data_Sets.Add(Datas[i].XK);
                Data_Sets.Add(Datas[i].XL);                           
                Data_Sets.Add(Datas[i].XN);
                Data_Sets.Add(Datas[i].XE);
                Data_Sets.Add(Datas[i].XF);
                Data_Sets.Add(Datas[i].XG);
                Data_Sets.Add(Datas[i].XJ);
                Data_Sets.Add(Datas[i].XM);

                /*  
                */
                rm.InsertExcel("A" + index, Data_Sets.ToArray());

                Data_Sets.Clear();
            }

            rm.Save_Excel();

            //MessageBox.Show("완료");
        }
        #endregion
        #endregion
        private void etc_Writing_Report(Report_Manager rm, List<etc_Report_Data> Datas1)
        {
            int idx = 2;
            string sheet_name = string.Empty;

            while (true)
            {
                sheet_name = "기타 (" + idx + ")";

                if (rm.Existing_Sheet(sheet_name) == false)
                {
                    break;
                }

                idx++;
            }

            idx--;
            sheet_name = "기타 (" + idx + ")";

            if (idx == 1)
            {
                rm.Change_Worksheet("기타");
            }
            else
            {
                rm.Change_Worksheet(sheet_name);
            }

            int s_idx = 0;

            /*   while (true)
               {
                   object tmp = rm.GetData(s_idx + 1, 1);

                   if (tmp == null)
                   {
                       break;
                   }

                   s_idx++;
               }
               */
            int pages = 0;
            int index;
            int start = s_idx + 6;

            List<string> Data_Sets = new List<string>();

            for (int i = 0; i < Datas1.Count; i++)
            {
                index = (s_idx + i) - (3000 * pages) + 7;

                if (index > 3000)
                {
                    try
                    {
                        rm.Change_Worksheet("샘플");

                        idx = 2;
                        sheet_name = string.Empty;

                        while (true)
                        {
                            sheet_name = "기타 (" + idx + ")";

                            if (rm.Existing_Sheet(sheet_name) == false)
                            {
                                break;
                            }

                            idx++;
                        }

                        rm.Copy_Worksheet(rm.exlWorkSheet, sheet_name);
                        rm.Change_Worksheet(sheet_name);
                        start = 2;

                        rm.Save_Excel();

                    }
                    catch (Exception exx)
                    {
                        string test = exx.Message;
                    }

                    pages++;

                    index = (s_idx + i) - (2999 * pages) + 1;

   


                }

                #region [ Data_sets.add List]
                Data_Sets.Add(Datas1[i].A);
                Data_Sets.Add(Datas1[i].B);
                Data_Sets.Add(Datas1[i].C);
                Data_Sets.Add(Datas1[i].D);
                Data_Sets.Add(Datas1[i].E);
                Data_Sets.Add(Datas1[i].F);

                Data_Sets.Add(Datas1[i].G);
                Data_Sets.Add(Datas1[i].H);
                Data_Sets.Add(Datas1[i].I);
                Data_Sets.Add(Datas1[i].J);
                Data_Sets.Add(Datas1[i].L);
                Data_Sets.Add(Datas1[i].K);
                Data_Sets.Add(Datas1[i].M);

                Data_Sets.Add(Datas1[i].N);
                Data_Sets.Add(Datas1[i].O);
                Data_Sets.Add(Datas1[i].P);
                Data_Sets.Add(Datas1[i].Q);
                Data_Sets.Add(Datas1[i].R);
                Data_Sets.Add(Datas1[i].S);

                Data_Sets.Add(Datas1[i].T);
                Data_Sets.Add(Datas1[i].U);
                Data_Sets.Add(Datas1[i].V);
                Data_Sets.Add(Datas1[i].W);
                Data_Sets.Add(Datas1[i].X);
                Data_Sets.Add(Datas1[i].Y);
                Data_Sets.Add(Datas1[i].Z);
                Data_Sets.Add(Datas1[i].AA);
                Data_Sets.Add(Datas1[i].AB);
                Data_Sets.Add(Datas1[i].AC);
                Data_Sets.Add(Datas1[i].AD);
                Data_Sets.Add(Datas1[i].AE);
                Data_Sets.Add(Datas1[i].AF);
                Data_Sets.Add(Datas1[i].AG);
                Data_Sets.Add(Datas1[i].AH);
                Data_Sets.Add(Datas1[i].AI);
                Data_Sets.Add(Datas1[i].AJ);
                Data_Sets.Add(Datas1[i].AK);
                Data_Sets.Add(Datas1[i].AL);
                Data_Sets.Add(Datas1[i].AM);
                Data_Sets.Add(Datas1[i].AN);
                Data_Sets.Add(Datas1[i].AO);
                Data_Sets.Add(Datas1[i].AP);
                Data_Sets.Add(Datas1[i].AQ);
                Data_Sets.Add(Datas1[i].AR);
                Data_Sets.Add(Datas1[i].AS);
                Data_Sets.Add(Datas1[i].AT);
                Data_Sets.Add(Datas1[i].AU);
                Data_Sets.Add(Datas1[i].AV);
                Data_Sets.Add(Datas1[i].AW);
                Data_Sets.Add(Datas1[i].AX);
                Data_Sets.Add(Datas1[i].AY);

                Data_Sets.Add(Datas1[i].AZ);
                Data_Sets.Add(Datas1[i].BA);
                Data_Sets.Add(Datas1[i].BB);
                Data_Sets.Add(Datas1[i].BC);
                Data_Sets.Add(Datas1[i].BD);
                Data_Sets.Add(Datas1[i].BE);
                Data_Sets.Add(Datas1[i].BF);
                Data_Sets.Add(Datas1[i].BG);
                Data_Sets.Add(Datas1[i].BH);
                Data_Sets.Add(Datas1[i].BI);
                Data_Sets.Add(Datas1[i].BJ);
                Data_Sets.Add(Datas1[i].BK);
                #endregion

                /**/
                rm.InsertExcel("A" + index, Data_Sets.ToArray());

                Data_Sets.Clear();
            }

            rm.Save_Excel();

            //MessageBox.Show("완료");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Load_FileInfos(@"E:\동해\기초자료\4호선\교량\2-029 잠실철교2.xlsx");
        }

      
    }


    ///================================================================================= End of Class : AceControl =///
}
