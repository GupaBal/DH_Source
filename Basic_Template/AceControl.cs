using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apros_Class_Library_Base;
using DevComponents.DotNetBar.Controls;
using Basic_Template.Properties;
using ChartFX.WinForms.Gauge;
using DevComponents.DotNetBar;

namespace Basic_Template
{
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
        // 버전 정보 상수
        private readonly string Version = "Expand 'Panel Name' - Ver 1.00.00.xxxx";

        private readonly string DataPath = CommonBase.DataPath;
        private readonly string Configpath = CommonBase.ConfigPath;

        // 델리게이트 함수
        private delegate void addTextBoxText(TextBoxX tb, string msg);
        private delegate void setTextBoxText(TextBoxX tb, string msg);
        private delegate void setPanelBackgroundImage(Panel p, Image img);
        private delegate void setDigitalPanelValue(DigitalPanel dp, object val);
        private delegate void setLabelText(LabelX l, string msg);
        private delegate void setSwitchButton(SwitchButton sb, bool set);

        //
        private int[] agcnt;
        private MultiSetGraph Acc_Graph;
        private MultiSetGraph Gyro_Graph;
        private int[] gcnt;
        private MultiSetGraph[] Mag_Graphs;
        private List<Panel> Mag_Panels = new List<Panel>();
        private string Save_Time = string.Empty;

        // 센서 데이터 관련 변수
        private int SamplingRate = 128;
        private int Acc_Recv_Cnt = 0;
        private int Gyr_Recv_Cnt = 0;
        private List<float>[] Acc_Datas;
        private List<float>[] Gyro_Datas;
        private float Acc_Coef = 0.061f;
        private float Gyro_Coef = 4.375f;
        List<float> VectorSum = new List<float>();

        //
        private bool isInit = false;
        private bool isImpact = false;
        private int RecoverCnt = 0;
        private float[] ExPoint;
        private float Impact_RMS = 0.0f;
        private float Impact_Time = 0.0f;
        private int Axis = 2;

        // 분석용 데이터 파일용 데이터 저장 변수
        private List<float>[] Analysis_ACCs;
        private List<float>[] Analysis_Gyro;
        private List<float> Analysis_VectorSum = new List<float>();

        //
        private readonly string SID = "FF:FF:FF:FF:FF:FF:FF:FF";

        //
        DateTime CheckT;
        TimeSpan RecvT;

        //
        StringBuilder sb;

        // 초기화 수행 여부
        bool Init_State = true;

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

            widjet_Setting_Comm1.SetSerialBaudrate(7);

            sb = new StringBuilder();
        }

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
            Widjet_Setting_Comm.SendMsg += Widjet_Setting_Comm_SetLogMsg;
            widjet_Setting_Comm1.SetTCMType("D");
            widjet_Setting_Comm1.Enabled = true;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ Widjet_Setting_Comm_SetLogMsg @                                                                       ///
        ///     통신 설정 위젯에서 전달되는 메시지를 화면에 표출한다.                                               ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="msg"> string : 메시지 </param>                                                             ///
        ///=========================================================================================================///
        private void Widjet_Setting_Comm_SetLogMsg(object sender, string msg)
        {
            string name = ((Widjet_Setting_Comm)sender).Parent.Parent.Parent.Parent.Parent.Name;
            Type myType = typeof(AceControl);

            if (name.Equals(myType.Namespace) == true)
            {
                m_txb_comm_logs.AppendText(msg);
                m_txb_comm_raws.AppendText(msg);

                if ((msg.Contains("Opened") == true) || (msg.Contains("Start") == true) || (msg.Contains("Connected") == true))
                {
                    timer_getter.Start();
                }
                else
                {
                    timer_getter.Stop();
                }
            }
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
        /// @ timer_status_Tick @                                                                                   ///
        ///     통신 상태를 주기적으로 확인하여 화면에 표출한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void timer_status_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now.Second % 2) == 0)
            {
                SetPanelBackgroundImage(panel_comm, Resources.offline_icon);
            }
            else
            {
                if (timer_getter.Enabled == true)
                {
                    SetPanelBackgroundImage(panel_comm, Resources.online_icon);
                }
                else
                {
                    SetPanelBackgroundImage(panel_comm, Resources.online_red_icon);
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ timer_getter_Tick @                                                                                   ///
        ///     주기적으로 데이터 패킷 수신 여부를 확인하여 수신 데이터를 처리하여 화면에 표출한다.                 ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void timer_getter_Tick(object sender, EventArgs e)
        {
            List<byte[]> Packets = widjet_Setting_Comm1.GetPackets();

            foreach (byte[] packet in Packets)
            {
                sb.AppendLine(CommonBase.Hex2Str16(packet, packet.Length));


                string msg = Command_Manager.PacketParsing(packet, 12);
                string SID = string.Empty;
                string[] datas = msg.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string[] tmp;

                byte[] tmp_buff = new byte[packet.Length];
                packet.CopyTo(tmp_buff, 0);

                foreach (string data in datas)
                {
                    if (data.Contains("ID : ") == true)
                    {
                        tmp = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        SID = tmp[2].Replace(":", "");
                    }
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ SetTextBoxText @                                                                                      ///
        ///     매개변수로 지정한 텍스트박스에 메시지를 설정한다.                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="tb"> TextBoxX : 대상 객체 </param>                                                         ///
        /// <param name="msg"> string : 메시지 </param>                                                             ///
        ///=========================================================================================================///
        private void AddTextBoxText(TextBoxX tb, string msg)
        {
            if (tb.InvokeRequired == true)
            {
                tb.Invoke(new addTextBoxText(AddTextBoxText), tb, msg);
            }
            else
            {
                tb.Text += msg;

                tb.SelectionStart = tb.TextLength;
                tb.ScrollToCaret();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ SetTextBoxText @                                                                                      ///
        ///     매개변수로 지정한 텍스트박스에 메시지를 설정한다.                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="tb"> TextBoxX : 대상 객체 </param>                                                         ///
        /// <param name="msg"> string : 메시지 </param>                                                             ///
        ///=========================================================================================================///
        private void SetTextBoxText(TextBoxX tb, string msg)
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
        /// @ SetDIgitalPanelValue @                                                                                ///
        ///     매개변수로 지정한 디지털패널의 값을 설정한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="dp"> DigitalPanel : 대상 객체 </param>                                                     ///
        /// <param name="val"> object : 설정 값 </param>                                                            ///
        ///=========================================================================================================///
        private void SetDIgitalPanelValue(DigitalPanel dp, object val)
        {
            if (dp.InvokeRequired == true)
            {
                dp.Invoke(new setDigitalPanelValue(SetDIgitalPanelValue), dp, val);
            }
            else
            {
                dp.Value = val;
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

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ SetConfig @                                                                                           ///
        ///     매개변수로 전달된 사용자 환경을 설정한다.                                                           ///
        /// </summary>                                                                                              ///
        /// <param name="values"> object[] : 사용자 환경 </param>                                                   ///  
        ///=========================================================================================================///
        public void SetConfig(string data)
        {
            string[] values = data.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string value in values)
            {
                if ((value.Contains("Serial:") == true) || (value.Contains("Ethernet:") == true))
                {
                    widjet_Setting_Comm1.SetConfig(value);
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ SaveConfig @                                                                                          ///
        ///     컨트롤의 사용자 설정 환경을 작성하여 반환한다.                                                      ///
        /// </summary>                                                                                              ///
        /// <returns> string : 사용자 설정 환경 </returns>                                                          ///
        ///=========================================================================================================///
        public string SaveConfig()
        {
            string comm = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[IITP_Sensors]");

            comm = widjet_Setting_Comm1.SaveConfig();
            sb.AppendLine(comm);

            return sb.ToString();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ Close @                                                                                               ///
        ///     통신 객체들의 동작을 중단하고 초기화한다.                                                           ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void Close()
        {
            widjet_Setting_Comm1.Close();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ ProcessData @                                                                                         ///
        ///     
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 데이터 처리 모드 </param>                                                    ///
        ///=========================================================================================================///
        private void ProcessData(bool mode)
        {

        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 20XX-XX-XX ] ///
        /// @ timer_writer_Tick @                                                                                   ///
        ///     주기적으로 데이터를 파일로 저장한다.                                                                ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void timer_writer_Tick(object sender, EventArgs e)
        {
            if (sb.Length > 0)
            {
                FileManager.LogWriter(sb.ToString(), DataPath, "SLM", true, true, true, true, true);
                sb.Clear();
            }
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
    }
    ///================================================================================= End of Class : AceControl =///
}
