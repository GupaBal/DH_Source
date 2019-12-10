using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Apros_Class_Library_Base;
using System.Reflection;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace APROS_Serial_Utility
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.03 / 2017-12-01 ] ///
    /// ▷ MainForm : Form ◁                                                                                       ///
    ///     소프트웨어에서 사용되는 모든 이벤트 핸들러를 구현한다.                                                  ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2017-03-14 ]                                                                                   ///
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
        #region [ # Constructor & Initializer ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ MainForm @                                                                                            /// 
        ///     생성자로 컨트롤을 초기화한다.                                                                       ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public MainForm()
        {
            InitializeComponent();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ MainForm_Load @                                                                                       ///
        ///     폼 생성 후 로드되는 시점에 호출되는 이벤트 핸들러 초기 작업을 수행한다.                             ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void MainForm_Load(object sender, EventArgs e)
        {
            FileManager.MakePath(Application.StartupPath);

            ReloadConfig();

            CheckingPanel();

            this.Text = Version;

            SetTitleStyle(ribbonBar1);
            SetTitleStyle(ribbonBar2);
            SetTitleStyle(ribbonBar3);
            /*
            // CT Sensor Pan
            label_version.Text = "Expand APROS CT - Ver 1.01.00.0724";

            labelX1.Text = "x" + "\u00B9" + "\u2070";
            labelX2.Text = "x" + "\u2079";
            labelX3.Text = "x" + "\u2078";
            labelX4.Text = "x" + "\u2077";
            labelX5.Text = "x" + "\u2076";
            labelX6.Text = "x" + "\u2075";
            labelX7.Text = "x" + "\u2074";
            labelX8.Text = "x" + "\u00B3";
            labelX9.Text = "x" + "\u00B2";
            labelX10.Text = "x" + "\u00B9";
            labelX11.Text = "x" + "\u2070";

            WaveGraph = new MultiSetGraph();
            WaveGraph.CreateGraph(panel_waveform, SGraphPlottingMethod.Line, false);
            WaveGraph.SubsetCount = 1;
            WaveGraph.DataPointCount = 4096;
            WaveGraph.SetSubsetGraph(0, Color.Yellow, "CT Waveform");
            WaveGraph.RefreshGraph();

            //Configs.InitConfig(ConfigPath + @"\Config.ini");

            textBoxX01.Text = Configs.CT_Coefs[0].ToString();
            textBoxX02.Text = Configs.CT_Coefs[1].ToString();
            textBoxX03.Text = Configs.CT_Coefs[2].ToString();
            textBoxX04.Text = Configs.CT_Coefs[3].ToString();
            textBoxX05.Text = Configs.CT_Coefs[4].ToString();
            textBoxX06.Text = Configs.CT_Coefs[5].ToString();
            textBoxX07.Text = Configs.CT_Coefs[6].ToString();
            textBoxX08.Text = Configs.CT_Coefs[7].ToString();
            textBoxX09.Text = Configs.CT_Coefs[8].ToString();
            textBoxX10.Text = Configs.CT_Coefs[9].ToString();
            textBoxX11.Text = Configs.CT_Coefs[10].ToString();
            
            SubItemsCollection sic = ribbonBarExtra.Items;

            for (int i = 0; i < sic.Count; i++)
            {
                if (sic[i].Text.Equals("SLM_QC") == true)
                {
                    m_btn_AppendPanel_Click(sic[i], new EventArgs());
                }
            }
            */
        }
        #endregion

        #region [ # Panel Handler - Basic ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_btn_PanAdd_Click @                                                                                  ///
        ///     통신 Panel을 추가로 생성하여 화면에 표시한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_PanAdd_Click(object sender, EventArgs e)
        {
            string name = string.Empty;

            if (sender == m_btn_PanAdd_Gen)
            {
                name = "Comm" + ++PanCnt;
                TabItems.Add(Comm1.CreateTab(name));
                
                TabCons.Add(new TabControlPanel());

                TabCons[LastIDX] = (TabControlPanel)TabItems[LastIDX].AttachedControl;
                TabCons[LastIDX].Name = name;
                TabCons[LastIDX].Controls.Add(new CommPanel(name));

                LastIDX++;
            }
            else if (sender == m_btn_PanAdd_AT)
            {
                name = "AT" + ++PATCnt;
                TabItems.Add(Comm1.CreateTab(name));

                TabCons.Add(new TabControlPanel());

                TabCons[LastIDX] = (TabControlPanel)TabItems[LastIDX].AttachedControl;
                TabCons[LastIDX].Name = name;
                TabCons[LastIDX].Controls.Add(new CommPanelAT(name));

                LastIDX++;
            }
            else if (sender == m_btn_PanAdd_LoRa)
            {
                name = "LoRa" + ++PLRCnt;
                CommPanelLora cpl = new CommPanelLora(name);
                cpl.LoRaConfigSet(Configs.AppEUI.ToArray(), Configs.LTID.ToArray(), Configs.uKey.ToArray());

                TabItems.Add(Comm1.CreateTab(name));

                TabCons.Add(new TabControlPanel());

                TabCons[LastIDX] = (TabControlPanel)TabItems[LastIDX].AttachedControl;
                TabCons[LastIDX].Name = name;
                TabCons[LastIDX].Controls.Add(cpl);

                LastIDX++;
            }

            Comm1.RecalcLayout();
            Comm1.SelectedTabIndex = TabItems.Count;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_btn_PanRemove_Click @                                                                               ///
        ///     현재 선택된 통신 Panel을 제거한다.                                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_PanRemove_Click(object sender, EventArgs e)
        {
            if (TabCons.Count > 0)
            {
                string sel_name = Comm1.SelectedTab.Text;
                TabItem itemToRemove = Comm1.SelectedTab;

                int iDX = Comm1.Tabs.IndexOf(itemToRemove);// - 1;
                /*
                foreach (TabControlPanel tcp in TabCons)
                {
                    if (tcp.Name.Equals(sel_name) == true)
                    {
                        iDX = TabCons.IndexOf(tcp);
                        break;
                    }
                }
                */
                try
                {
                    Type type = TabCons[iDX].Controls[0].GetType();

                    MethodInfo mi = type.GetMethod("Close");

                    string msg = (string)(mi.Invoke(TabCons[iDX].Controls[0], null));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                TabCons[iDX].Controls.RemoveAt(0);
                TabCons.RemoveAt(iDX);
                TabItems.RemoveAt(iDX);
                LastIDX--;

                if (sel_name.Contains("Comm") == true)
                {
                    PanCnt--;
                }
                else if (sel_name.Contains("AT") == true)
                {
                    PATCnt--;
                }
                else if (sel_name.Contains("LoRa") == true)
                {
                    PLRCnt--;
                }

                Comm1.Tabs.Remove(itemToRemove);
                //Comm1.Controls.Remove(itemToRemove.AttachedControl);
                Comm1.RecalcLayout();
            }
        }
        #endregion
        
        #region [ # Panel Handler - Expand ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_btn_AppendPanel_Click @                                                                             ///
        ///     Append Panel을 통해 추가된 UserControl들을 생성하여 화면에 표시한다.                                ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_AppendPanel_Click(object sender, EventArgs e)
        {
            try
            {
                string name = ((ButtonItem)sender).Text;

                int idx = -1;

                for (int i = 0; i < DllLoader.Count; i++)
                {
                    if (DllLoader[i].FullName.Contains(name) == true)
                    {
                        idx = i;
                        break;
                    }
                }

                Type t = DllLoader[idx].GetType(name + ".AceControl");
                UserControl uc = Activator.CreateInstance(t) as UserControl;

                TabItem ti = Comm1.CreateTab(name);
                ti.Name = Comm1.Tabs.IndexOf(ti).ToString();

                TabItems.Add(ti);

                TabCons.Add(new TabControlPanel());

                TabCons[LastIDX] = (TabControlPanel)TabItems[LastIDX].AttachedControl;
                TabCons[LastIDX].Name = name;
                TabCons[LastIDX].Controls.Add(uc);

                LastIDX++;
            }
            catch (Exception ex)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : m_btn_AppendPanel_Click ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(ex.Message);
                MessageBuilder.AppendLine();

                ErrMessage = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(ErrMessage, ErrorPath, ErrorName, true, true, true, true, true);
            }

            Comm1.RecalcLayout();
            Comm1.SelectedTabIndex = TabItems.Count;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2017-07-05 ] ///
        /// @ Comm1_TabItemClose @                                                                                  ///
        ///     TabItem에서 Close 이벤트가 발생하면 Tab 제거 함수를 호출한다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> TabStripActionEventArgs : 이벤트 관련 정보 </param>                                    ///
        ///=========================================================================================================///
        private void Comm1_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            m_btn_PanRemove_Click(sender, e);
        }
        #endregion

        #region [ # Config / Environment Loader ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_btn_config_reload_Click @                                                                           ///
        ///     Config 파일 로드 함수를 호출한다.                                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_config_reload_Click(object sender, EventArgs e)
        {
            ReloadConfig();
            CheckingPanel();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_btn_config_Click @                                                                                  ///
        ///     사용자 환경을 저장 / 로드한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_config_Click(object sender, EventArgs e)
        {
            if(sender == m_btn_config_read)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = CommonBase.ConfigPath;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(ofd.FileName);
                    StringBuilder sb = new StringBuilder();

                    while (sr.EndOfStream != true)
                    {
                        string data = sr.ReadLine();
                        string name = data.Replace("[", "").Replace("]", "");

                        SubItemsCollection sic = ribbonBar1.Items;

                        foreach (BaseItem bi in sic)
                        {
                            if (name.Contains(bi.Text) == true)
                            {
                                data = sr.ReadLine();

                                while (string.IsNullOrEmpty(data) == false)
                                {
                                    sb.AppendLine(data);
                                    data = sr.ReadLine();
                                }

                                m_btn_PanAdd_Click(bi, e);

                                try
                                {
                                    Type type = TabCons[TabCons.Count - 1].Controls[0].GetType();

                                    MethodInfo mi = type.GetMethod("SetConfig");
                                    ParameterInfo[] parameters = mi.GetParameters();

                                    object[] parameterArray = new object[] { sb.ToString() };

                                    mi.Invoke(TabCons[TabCons.Count - 1].Controls[0], parameterArray);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }

                        sic = ribbonBarExtra.Items;

                        foreach (BaseItem bi in sic)
                        {
                            if (bi.Text.Equals(name) == true)
                            {
                                data = sr.ReadLine();

                                while (string.IsNullOrEmpty(data) == false)
                                {
                                    sb.AppendLine(data);
                                    data = sr.ReadLine();
                                }

                                m_btn_AppendPanel_Click(bi, e);

                                try
                                {
                                    Type type = TabCons[TabCons.Count - 1].Controls[0].GetType();

                                    MethodInfo mi = type.GetMethod("SetConfig");
                                    ParameterInfo[] parameters = mi.GetParameters();

                                    object[] parameterArray = new object[] { sb.ToString() };

                                    mi.Invoke(TabCons[TabCons.Count - 1].Controls[0], parameterArray);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                break;
                            }
                        }
                    }

                    Comm1.RecalcLayout();
                    Comm1.SelectedTabIndex = TabItems.Count;
                }
            }
            else if(sender == m_btn_config_save)
            {
                if (Comm1.Tabs.Count > 0)
                {
                    if (MessageBox.Show("마지막 환경을 저장하시겠습니까?", "Save Config", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Text Files | *.txt";
                        sfd.DefaultExt = "txt";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            int n = TabCons.Count;
                            StreamWriter sw;

                            if (n > 0)
                            {
                                sw = new StreamWriter(sfd.FileName, false);
                                sw.Flush();
                                sw.Close();
                            }

                            sw = new StreamWriter(sfd.FileName, true);

                            for (int i = 0; i < n; i++)
                            {
                                try
                                {
                                    Type type = TabCons[i].Controls[0].GetType();

                                    MethodInfo mi = type.GetMethod("SaveConfig");

                                    string msg = (string)(mi.Invoke(TabCons[i].Controls[0], null));
                                    sw.WriteLine(msg);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }

                            sw.Flush();
                            sw.Close();
                        }
                    }
                }
            }
        }
        #endregion

        #region [ # Event Handler ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ MainForm_SizeChanged @                                                                                ///
        ///     화면 최소화 시 notifyIcon만 보이고 화면을 숨긴다.                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ notifyIcon1_MouseDoubleClick @                                                                        ///
        ///     화면을 복구한다.                                                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> MouseEventArgs : 이벤트 관련 정보 </param>                                             ///
        ///=========================================================================================================///
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ MainForm_FormClosing @                                                                                ///
        ///     메인 폼이 종료될 때 마지막 사용자 환경 저장을 호출한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //widjet_Setting_Comm1.Close();

            m_btn_config_Click(m_btn_config_save, e);

            int n = Comm1.Tabs.Count;

            for (int i = 1; i < n; i++)
            {
                try
                {
                    Type type = TabCons[i].Controls[0].GetType();

                    MethodInfo mi = type.GetMethod("Close");

                    string msg = (string)(mi.Invoke(TabCons[i].Controls[0], null));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region [ # ETC - Testing ]
        private void buttonItem14_Click(object sender, EventArgs e)
        {
            string path = @"E:\［ 8. Temporary Closed ］\새 폴더";
            //string path = @"F:\［ Download ］\3월3일센서데이터\새 폴더";

            DirectoryInfo[] dirs = new DirectoryInfo(path).GetDirectories();

            double volt = 3.0;
            double sensitivity = 26.4;
            int bits = 24;
            string[] sub;
            List<string> SID = new List<string>();

            List<int> twos_comp = new List<int>();
            List<double> adc_vals = new List<double>();
            List<double> volt_vals = new List<double>();
            List<double> accg_vals = new List<double>();

            foreach (DirectoryInfo dir in dirs)
            {
                FileInfo[] fis = dir.GetFiles();

                foreach(FileInfo fi in fis)
                {
                    using (StreamReader sr = new StreamReader(fi.FullName))
                    {
                        while(sr.EndOfStream != true)
                        {
                            string data = sr.ReadLine();
                            byte[] packet = CommonBase.HexStringToByteArray(data);

                            string msg = SmartSensor_Acc.PacketParsing(packet, bits);

                            if (msg.Contains("Packet Index") == true)
                            {
                                sub = msg.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                                string id = sub[1].Substring(5);

                                //if (SID.Contains(id) == false)
                                {
                                    int cnt = sub.Length - 4;

                                    for (int i = 0; i < cnt; i++)
                                    {
                                        int tmp = Convert.ToInt32(sub[4 + i]);
                                        twos_comp.Add(tmp);

                                        double dmp = tmp / Math.Pow(2, (Configs.ADC_Bits - 1)) * volt;
                                        volt_vals.Add(dmp);

                                        dmp = (dmp * 1000) / sensitivity;
                                        accg_vals.Add(dmp);
                                    }

                                    if (Convert.ToInt32(sub[2].Substring(15)) == 255)
                                    {
                                        //if (SID.Contains(id) == false)
                                        {
                                            //SID.Add(id);
                                        }

                                        StringBuilder sb = new StringBuilder();
                                        sb.AppendLine(id);
                                        sb.AppendLine("time : " + fi.Name.Substring(6, 2));

                                        for(int i=0; i<twos_comp.Count; i++)
                                        {
                                            sb.AppendLine(twos_comp[i] + ", " + volt_vals[i] + "," + accg_vals[i]);
                                        }

                                        StreamWriter sw = new StreamWriter(@"E:\［ 8. Temporary Closed ］\" + id.Replace(":","") + "_" + dir.Name +".dat", true);
                                        sw.Write(sb.ToString());
                                        sw.Flush();
                                        sw.Close();

                                        twos_comp.Clear();
                                        volt_vals.Clear();
                                        accg_vals.Clear();
                                    }
                                }
                            }
                        }

                        SID.Clear();
                        sr.Close();
                    }
                }
            }
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            string path = @"F:\［ Download ］\3월3일센서데이터\새 폴더";

            DirectoryInfo[] dirs = new DirectoryInfo(path).GetDirectories();
            byte[] packet;

            foreach (DirectoryInfo dir in dirs)
            {
                FileInfo[] fis = dir.GetFiles();

                foreach (FileInfo fi in fis)
                {
                    using (StreamReader sr = new StreamReader(fi.FullName))
                    {
                        using (StreamWriter sw = new StreamWriter(dir.FullName + @"\" + fi.Name + ".dat"))
                        {
                            while (sr.EndOfStream != true)
                            {
                                string data = sr.ReadLine();
                                string type = data.Substring(0, 2);

                                if (type.Equals("A4") == true)
                                {
                                    data = ("401B010108" + dir.Name + data + "00007D");
                                    packet = CommonBase.HexStringToByteArray(data);
                                    CommonBase.SetCRC16_CCITT(packet, 1);
                                    sw.WriteLine(CommonBase.Hex2Str16(packet, packet.Length));
                                }
                                else if (type.Equals("AF") == true)
                                {
                                    data = ("4044020108" + dir.Name + data + "00007D");
                                    packet = CommonBase.HexStringToByteArray(data);
                                    CommonBase.SetCRC16_CCITT(packet, 1);
                                    sw.WriteLine(CommonBase.Hex2Str16(packet, packet.Length));
                                }

                                sw.Flush();
                            }

                            sw.Close();
                        }

                        sr.Close();
                    }
                }
            }
        }
        #endregion

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            Report_Manager rm = new Report_Manager();
            
            #region [ # Data Loading ]
            string data_file = @"F:\［ Download ］\8109 몽촌토성역~잠실역 점검대장(관리).xlsx";
            rm.Init_Excel_Report(data_file, "Page 3");

            int pnum = 3;

            List<string[]> datas = new List<string[]>();
            List<string> buffer = new List<string>();
            
            while (rm.Existing_Sheet("Page " + pnum) == true)
            {
                rm.Change_Worksheet("Page " + pnum);
                object[,] data_buffer = rm.GetData();
                int row = data_buffer.GetLength(0);
                int col = data_buffer.GetLength(1);

                if (col == 17)
                {
                    for (int i = 5; i < (row + 1); i++)
                    {
                        buffer.Add(data_buffer[i, 4] == null ? "" : data_buffer[i, 4].ToString());      // 부재 level 3
                        buffer.Add(data_buffer[i, 6] == null ? "" : data_buffer[i, 6].ToString());      // 부재 level 4
                        buffer.Add(data_buffer[i, 7] == null ? "" : data_buffer[i, 7].ToString());      // 부재 level 5
                        buffer.Add(data_buffer[i, 8] == null ? "" : data_buffer[i, 8].ToString());      // 부재 level 6
                        buffer.Add(data_buffer[i, 15] == null ? "" : data_buffer[i, 15].ToString());    // 부재별 상태등급
                        buffer.Add(data_buffer[i, 9] == null ? "" : data_buffer[i, 9].ToString());      // 손상종류
                        buffer.Add(data_buffer[i, 12] == null ? "" : data_buffer[i, 12].ToString());    // 손상 개소수
                        buffer.Add(data_buffer[i, 17] == null ? "" : data_buffer[i, 17].ToString());    // 비고

                        datas.Add(buffer.ToArray());
                        buffer.Clear();
                    }
                }

                pnum++;
            }

            //rm.Save_Excel();
            //Thread.Sleep(3000);
            rm.CloseExcel();
            #endregion
            
            #region [ # Reporting ]
            string report_name = @"E:\［ 2. Projects ］\［20190529］동해종합기술공사\06.05(수)\01_터널\8호선\8109 몽촌토성-잠실.xlsx";
            rm.Init_Excel_Report(report_name, "점검진단정보");

            int idx = 2;
            string sheet_name = string.Empty;

            while (true)
            {
                sheet_name = "점검진단정보 (" + idx + ")";

                if (rm.Existing_Sheet(sheet_name) == false)
                {
                    break;
                }

                idx++;
            }

            idx--;
            sheet_name = "점검진단정보 (" + idx + ")";

            if (idx == 1)
            {
                rm.Change_Worksheet("점검진단정보");
            }
            else
            {
                rm.Change_Worksheet(sheet_name);
            }

            int s_idx = 0;

            while (true)
            {
                object tmp = rm.GetData(s_idx + 1, 1);

                if (tmp == null)
                {
                    break;
                }

                s_idx++;
            }

            int pages = 0;
            int index;
            int start = s_idx + 1;

            List<string> Data_Sets = new List<string>();
            
            for (int i = 0; i < datas.Count; i++)
            {
                index = (s_idx + i) - (3000 * pages) + 1;

                if (index > 3000)
                {
                    try
                    {
                        rm.Change_Worksheet("샘플");

                        idx = 2;
                        sheet_name = string.Empty;

                        while (true)
                        {
                            sheet_name = "점검진단정보 (" + idx + ")";

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

                Data_Sets.Add(datas[i][0]);
                Data_Sets.Add(datas[i][1]);
                Data_Sets.Add(datas[i][2]);
                Data_Sets.Add(datas[i][3]);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(datas[i][4]);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(datas[i][5]);
                Data_Sets.Add(datas[i][6]);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(datas[i][7]);

                rm.InsertExcel("N" + index, Data_Sets.ToArray());

                Data_Sets.Clear();
            }
            
            rm.Save_Excel();
            //Thread.Sleep(3000);
            //rm.SaveAs_Excel(@"F:", "암사 천호.xlsx");
            rm.CloseExcel();
            #endregion
        }

        public struct Condition_Assessment
        {
            public string span;
            public string Parts_Lv3;
            public string Parts_Lv4;
            public string Parts_Lv5;
            public string Parts_Lv6;
            public string Parts_Grade;
            public string Parts_Defect;
            public string Damage_Kind;
            public string Damage_Points;
            public string Remarks;
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            Report_Manager rm = new Report_Manager();
            List<Condition_Assessment> Datas = new List<Condition_Assessment>();

            #region [ # Data Loading ]
            string data_file = @"F:\［ Download ］\상태평가(몽촌토성~잠실역).xlsx";
            rm.Init_Excel_Report(data_file, "Page 1");

            object[,] data_buffer = rm.GetData();
            int row = data_buffer.GetLength(0);
            int col = data_buffer.GetLength(1);

            for (int i = 6; i < (row + 1); i++)
            {
                if (data_buffer[i, 1] != null)
                {
                    int tmp;

                    if (int.TryParse(data_buffer[i, 1].ToString(), out tmp) == true)
                    {
                        tmp = 0;

                        for (int j = 8; j < 18; j++)
                        {
                            if ((data_buffer[i, j].ToString().Equals("0") == false) && data_buffer[i, j].ToString().Equals("-") == false)
                            {
                                Condition_Assessment ca = new Condition_Assessment();
                                ca.span = data_buffer[i, 1].ToString();
                                ca.Parts_Lv3 = (data_buffer[i, 2].ToString() + data_buffer[i, 3].ToString()).Replace("\n", "");
                                ca.Parts_Lv4 = data_buffer[i, 5] == null ? "" : data_buffer[i, 5].ToString();
                                ca.Parts_Lv5 = data_buffer[i, 6] == null ? "" : data_buffer[i, 6].ToString();
                                ca.Parts_Lv6 = data_buffer[i, 7] == null ? "" : data_buffer[i, 7].ToString();
                                ca.Parts_Defect = data_buffer[i, 19].ToString();
                                ca.Damage_Kind = data_buffer[5, j].ToString().Replace("\n", "");
                                ca.Damage_Points = data_buffer[i, j].ToString();

                                if (col >= 20)
                                {
                                    ca.Remarks = data_buffer[i, 20] == null ? "" : data_buffer[i, 19].ToString();
                                }

                                Datas.Add(ca);
                                tmp++;
                            }
                        }

                        if (tmp == 0)
                        {
                            Condition_Assessment ca = new Condition_Assessment();
                            ca.span = data_buffer[i, 1].ToString();
                            ca.Parts_Lv3 = (data_buffer[i, 2].ToString() + data_buffer[i, 3].ToString()).Replace("\n", "");
                            ca.Parts_Lv4 = data_buffer[i, 5] == null ? "" : data_buffer[i, 5].ToString();
                            ca.Parts_Lv5 = data_buffer[i, 6] == null ? "" : data_buffer[i, 6].ToString();
                            ca.Parts_Lv6 = data_buffer[i, 7] == null ? "" : data_buffer[i, 7].ToString();
                            ca.Parts_Defect = data_buffer[i, 19].ToString();

                            if (col >= 20)
                            {
                                ca.Remarks = data_buffer[i, 20] == null ? "" : data_buffer[i, 19].ToString();
                            }

                            Datas.Add(ca);
                        }
                    }
                }
            }
            
            rm.Change_Worksheet("Page 2");

            data_buffer = rm.GetData();
            row = data_buffer.GetLength(0);
            col = data_buffer.GetLength(1);

            for (int i = 5; i < (row + 1); i++)
            {
                if (data_buffer[i, 1] != null)
                {
                    int tmp;

                    if (int.TryParse(data_buffer[i, 1].ToString(), out tmp) == true)
                    {
                        for (int j = 0; j < Datas.Count; j++)
                        {
                            if (Datas[j].span.Equals(data_buffer[i, 1].ToString()) == true)
                            {
                                Condition_Assessment ca = Datas[j];
                                ca.Parts_Grade = data_buffer[i, 18].ToString();
                                Datas[j] = ca;
                            }
                        }
                    }
                }
            }
            
            rm.Change_Worksheet("Page 3");
            data_buffer = rm.GetData();

            string Facility_Grade = rm.GetData(15, 16).ToString();
            string Facility_Defect = rm.GetData(12, 16).ToString();

            rm.Save_Excel();
            //Thread.Sleep(3000);
            rm.CloseExcel();
            #endregion

            #region [ # Reporting ]
            string report_name = @"E:\［ 2. Projects ］\［20190529］동해종합기술공사\06.05(수)\01_터널\8호선\8109 몽촌토성-잠실.xlsx";
            rm.Init_Excel_Report(report_name, "점검진단정보");
            rm.Change_Worksheet("점검진단정보");

            int idx = 2;
            string sheet_name = string.Empty;

            while (true)
            {
                sheet_name = "점검진단정보 (" + idx + ")";

                if (rm.Existing_Sheet(sheet_name) == false)
                {
                    break;
                }

                idx++;
            }

            idx--;
            sheet_name = "점검진단정보 (" + idx + ")";

            if (idx == 1)
            {
                rm.Change_Worksheet("점검진단정보");
            }
            else
            {
                rm.Change_Worksheet(sheet_name);
            }

            int s_idx = 0;

            while (true)
            {
                object tmp = rm.GetData(s_idx + 1, 1);

                if (tmp == null)
                {
                    break;
                }

                s_idx++;
            }

            int pages = 0;
            int index;
            int start = s_idx + 1;

            List<string> Data_Sets = new List<string>();

            for (int i = 0; i < Datas.Count; i++)
            {
                index = (s_idx + i) - (3000 * pages) + 1;

                if (index > 3000)
                {
                    try
                    {
                        rm.Change_Worksheet("샘플");

                        idx = 2;
                        sheet_name = string.Empty;

                        while (true)
                        {
                            sheet_name = "점검진단정보 (" + idx + ")";

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

                Data_Sets.Add(Datas[i].Parts_Lv3);
                Data_Sets.Add(Datas[i].Parts_Lv4);
                Data_Sets.Add(Datas[i].Parts_Lv5);
                Data_Sets.Add(Datas[i].Parts_Lv6);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(Datas[i].Parts_Grade);
                Data_Sets.Add(Datas[i].Parts_Defect);
                Data_Sets.Add(Facility_Grade);
                Data_Sets.Add(Facility_Defect);
                Data_Sets.Add(Datas[i].Damage_Kind);
                Data_Sets.Add(Datas[i].Damage_Points);
                //Data_Sets.Add(Datas[i].Remarks);

                rm.InsertExcel("N" + index, Data_Sets.ToArray());

                Data_Sets.Clear();
            }

            rm.Save_Excel();
            //Thread.Sleep(3000);
            //rm.SaveAs_Excel(@"F:", "암사 천호.xlsx");
            rm.CloseExcel();
            #endregion
        }

        private string report_file = "3-012 녹번-홍제_점검진단";
        private string data_file1 = "녹번~홍제역 진단리스트";
        private string data_file2 = "20161027181144105_01.상태평가(녹번~홍제역)";

        // 리스트 Type-A
        private void buttonItem18_Click(object sender, EventArgs e)
        {
            Report_Manager rm = new Report_Manager();

            #region [ # Data Loading ]
            string data_file = @"F:\［ Download ］\" + data_file1 + ".xlsx";
            string[] data_sheets = new string[] { "홍제역 본선 (최종)" };

            rm.Init_Excel_Report(data_file, data_sheets[0]);

            List<string[]> datas = new List<string[]>();
            List<string> buffer = new List<string>();

            for (int sheet = 0; sheet < data_sheets.Length; sheet++)
            {
                rm.Change_Worksheet(data_sheets[sheet]);

                object[,] data_buffer = rm.GetData();
                int row = data_buffer.GetLength(0);
                int col = data_buffer.GetLength(1);

                int offset = 2;

                if (col > 10)
                {
                    for (int i = 5; i < (row + 1); i++)
                    {
                        if (data_buffer[i, 4] != null)
                        {
                            for (int j = 11 + offset; j < 25; j++)
                            {
                                if (data_buffer[i, j] != null)
                                {
                                    string name = string.Empty, count = string.Empty;

                                    if (j == (11 + offset))
                                    {
                                        if (data_buffer[i, j - 2] != null)
                                        {
                                            name = data_buffer[i, j - 2].ToString();
                                        }

                                        name += "균열";
                                        count = "폭:" + data_buffer[i, j - 1].ToString() + "mm, 길이:" + data_buffer[i, j].ToString() + "m";
                                    }
                                    else if (j == (12 + offset))
                                    {
                                        name = "누수";
                                        count = "연장:" + data_buffer[i, j].ToString() + "m";
                                    }
                                    else if (j == (13 + offset))
                                    {
                                        name = "백태";
                                        count = "면적:" + data_buffer[i, j].ToString() + "㎡";
                                    }
                                    else if (j == (14 + offset))
                                    {
                                        name = "박리";
                                        count = "면적:" + data_buffer[i, j].ToString() + "㎡";
                                    }
                                    else if (j == (15 + offset))
                                    {
                                        name = "박리";
                                        count = "깊이:" + data_buffer[i, j].ToString() + "cm";
                                    }
                                    else if (j == (16 + offset))
                                    {
                                        name = "박락";
                                        count = "면적:" + data_buffer[i, j].ToString() + "㎡";
                                    }
                                    else if (j == (17 + offset))
                                    {
                                        name = "박락";
                                        count = "깊이:" + data_buffer[i, j].ToString() + "cm";
                                    }
                                    else if (j == (18 + offset))
                                    {
                                        name = "층분리";
                                        count = "면적:" + data_buffer[i, j].ToString() + "㎡";
                                    }
                                    else if (j == (19 + offset))
                                    {
                                        name = "층분리";
                                        count = "깊이:" + data_buffer[i, j].ToString() + "cm";
                                    }
                                    else if (j == (20 + offset))
                                    {
                                        name = "철근노출";
                                        count = "면적:" + data_buffer[i, j].ToString() + "㎡";
                                    }
                                    else if (j == (21 + offset))
                                    {
                                        name = "재료분리";
                                        count = "면적:" + data_buffer[i, j].ToString() + "㎡";
                                    }
                                    else if (j == (22 + offset))
                                    {
                                        name = "배수관탈락";
                                        count = data_buffer[i, j].ToString() + "m";
                                    }
                                    else if (j == (23 + offset))
                                    {
                                        name = "기타";
                                        count = "연장:" + data_buffer[i, j].ToString() + "m";
                                    }
                                    else if (j == (24 + offset))
                                    {
                                        name = "기타";
                                        count = "면적:" + data_buffer[i, j].ToString() + "㎡";
                                    }
                                        //case 22:
                                        //    name = "철근노출";
                                        //    count = "연장:" + data_buffer[i, j].ToString() + "m";
                                        //    break;
                                        //case 23:
                                        //    if (string.IsNullOrEmpty(name) == true)
                                        //    {
                                        //        name = "철근노출";
                                        //        count = "면적:" + data_buffer[i, j].ToString() + "㎡";
                                        //    }
                                        //    else
                                        //    {
                                        //        count += ", 면적:" + data_buffer[i, j].ToString() + "㎡";
                                        //    }
                                        //    break;
                                        //case 24:
                                        //    name = "매입유도관박리";
                                        //    count = "연장:" + data_buffer[i, j].ToString() + "m";
                                        //    break;

                                    buffer.Add(data_buffer[i, 6] == null ? "" : data_buffer[i, 6].ToString());      // 부재 level 3
                                    buffer.Add(data_buffer[i, 8] == null ? "" : data_buffer[i, 8].ToString());      // 부재 level 4
                                    buffer.Add(data_buffer[i, 9] == null ? "" : data_buffer[i, 9].ToString());      // 부재 level 5
                                    buffer.Add("");// data_buffer[i, 9] == null ? "" : data_buffer[i, 9].ToString());      // 부재 level 6
                                    buffer.Add(data_buffer[i, 10] == null ? "" : data_buffer[i, 10].ToString());      // 부재별 상태등급
                                    buffer.Add(name);                                                               // 손상종류
                                    buffer.Add(count);                                                              // 손상 개소수
                                    buffer.Add(string.Empty);                                                       // 유지보수
                                    buffer.Add(string.Empty);                                                       // 유지보수

                                    string remarks = data_buffer[i, 27] == null ? "" : data_buffer[i, 27].ToString();       // 비고
                                    //remarks += data_buffer[i, 27] == null ? "" : (" " + data_buffer[i, 27].ToString());
                                    buffer.Add(remarks);

                                    datas.Add(buffer.ToArray());
                                    buffer.Clear();
                                }
                            }
                        }
                    }
                }
            }

            rm.CloseExcel();
            #endregion

            Writing_Report(1, datas);

            #region [ # Reporting ]
            /*
            string report_name = @"F:\동해 데이터 처리 건\01. FMS받은자료\01_터널\3호선\" + report_file + ".xlsx";
            rm.Init_Excel_Report(report_name, "점검진단정보");

            int idx = 2;
            string sheet_name = string.Empty;

            while (true)
            {
                sheet_name = "점검진단정보 (" + idx + ")";

                if (rm.Existing_Sheet(sheet_name) == false)
                {
                    break;
                }

                idx++;
            }

            idx--;
            sheet_name = "점검진단정보 (" + idx + ")";

            if (idx == 1)
            {
                rm.Change_Worksheet("점검진단정보");
            }
            else
            {
                rm.Change_Worksheet(sheet_name);
            }

            int s_idx = 0;

            while (true)
            {
                object tmp = rm.GetData(s_idx + 1, 1);

                if (tmp == null)
                {
                    break;
                }

                s_idx++;
            }

            int pages = 0;
            int index;
            int start = s_idx + 1;

            List<string> Data_Sets = new List<string>();

            for (int i = 0; i < datas.Count; i++)
            {
                index = (s_idx + i) - (3000 * pages) + 1;

                if (index > 3000)
                {
                    try
                    {
                        rm.Change_Worksheet("샘플");

                        idx = 2;
                        sheet_name = string.Empty;

                        while (true)
                        {
                            sheet_name = "점검진단정보 (" + idx + ")";

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

                Data_Sets.Add(datas[i][0]);
                Data_Sets.Add(datas[i][1]);
                Data_Sets.Add(datas[i][2]);
                Data_Sets.Add(datas[i][3]);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(datas[i][4]);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(datas[i][5]);
                Data_Sets.Add(datas[i][6]);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(datas[i][7]);
                Data_Sets.Add(datas[i][8]);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(string.Empty);
                Data_Sets.Add(datas[i][9]);

                rm.InsertExcel("N" + index, Data_Sets.ToArray());

                Data_Sets.Clear();
            }

            rm.Save_Excel();
            rm.CloseExcel();

            MessageBox.Show("완료");
            */
            #endregion
        }

        // 리스트 Type-B
        private void buttonItem20_Click(object sender, EventArgs e)
        {
            Report_Manager rm = new Report_Manager();

            #region [ # Data Loading ]
            string data_file = @"F:\［ Download ］\" + data_file1 + ".xlsx";
            string[] data_sheets = new string[] { "홍제역 본선 (최종)" };

            rm.Init_Excel_Report(data_file, data_sheets[0]);
            //rm.Init_Excel_Report(data_file, "Page 1");

            int pnum = 1;

            List<string[]> datas = new List<string[]>();
            List<string> buffer = new List<string>();

            for (int sheet = 0; sheet < data_sheets.Length; sheet++)
            //while (rm.Existing_Sheet("Page " + pnum) == true)
            {
                rm.Change_Worksheet(data_sheets[sheet]);
                //rm.Change_Worksheet("Page " + pnum);

                object[,] data_buffer = rm.GetData();
                int row = data_buffer.GetLength(0);
                int col = data_buffer.GetLength(1);

                if (col > 21)
                {
                    for (int i = 7; i < (row + 1); i++)
                    {
                        if (data_buffer[i, 2] != null)
                        {
                            int idx_m;
                            buffer.Add(data_buffer[i, 6] == null ? "" : data_buffer[i, 6].ToString());              // 부재 level 3
                            string tmp_str = data_buffer[i, 9] == null ? "" : data_buffer[i, 9].ToString();
                            //tmp_str += (" / " + data_buffer[i, 8] == null ? "" : data_buffer[i, 8].ToString());
                            buffer.Add(tmp_str);                                                                    // 부재 level 4
                            buffer.Add(data_buffer[i, 11] == null ? "" : data_buffer[i, 11].ToString());              // 부재 level 5
                            buffer.Add(data_buffer[i, 12] == null ? "" : data_buffer[i, 12].ToString());              // 부재 level 6
                            buffer.Add(data_buffer[i, 15] == null ? "" : data_buffer[i, 15].ToString());              // 부재별 상태등급

                            string kind = data_buffer[i, 13] == null ? "" : data_buffer[i, 13].ToString() + "/";    // 손상종류
                            kind += data_buffer[i, 16] == null ? "" : data_buffer[i, 16].ToString();
                            kind += data_buffer[i, 14] == null ? "" : data_buffer[i, 14].ToString();
                            buffer.Add(kind);

                            idx_m = 20;
                            if (data_buffer[i, idx_m] == null)                                                         // 손상 개소수
                            {
                                string damage = string.Empty;

                                damage += data_buffer[i, idx_m - 3] == null ? "" : ("폭: " + data_buffer[i, idx_m - 3].ToString() + "mm ");
                                damage += data_buffer[i, idx_m - 2] == null ? "" : ("연장 : " + data_buffer[i, idx_m - 2].ToString() + "m ");
                                damage += data_buffer[i, idx_m - 1] == null ? "" : ("깊이 : " + data_buffer[i, idx_m - 1].ToString() + "㎡");
                                buffer.Add(damage);
                            }
                            else
                            {
                                buffer.Add(data_buffer[i, idx_m] == null ? "" : data_buffer[i, idx_m].ToString());
                            }

                            idx_m = 21;
                            string maintenance = data_buffer[i, idx_m + 0] == null ? "" : data_buffer[i, idx_m + 0].ToString();   // 유지보수
                            maintenance += data_buffer[i, idx_m + 1] == null ? "" : (" " + data_buffer[i, idx_m + 1].ToString());
                            buffer.Add(maintenance);                            
                            buffer.Add(data_buffer[i, idx_m + 2] == null ? "" : data_buffer[i, idx_m + 2].ToString());

                            idx_m = 24;
                            string remarks = data_buffer[i, idx_m + 0] == null ? "" : data_buffer[i, idx_m + 0].ToString();       // 비고
                            remarks += data_buffer[i, idx_m + 1] == null ? "" : (" " + data_buffer[i, idx_m + 1].ToString());
                            //remarks += data_buffer[i, idx_m + 2] == null ? "" : (" " + data_buffer[i, idx_m + 2].ToString());
                            buffer.Add(remarks);

                            datas.Add(buffer.ToArray());
                            buffer.Clear();

                        }
                    }
                }

                pnum++;
            }

            rm.CloseExcel();
            #endregion

            Writing_Report(1, datas);

        }

        // 상태평가 Type-A
        private void buttonItem19_Click(object sender, EventArgs e)
        {
            Report_Manager rm = new Report_Manager();
            
            #region [ # Data Loading ]
            string data_file = @"F:\［ Download ］\" + data_file2 + ".xlsx";
            rm.Init_Excel_Report(data_file, "Page 1");

            object[,] data_buffer = rm.GetData();
            int row = data_buffer.GetLength(0);
            int col = data_buffer.GetLength(1);

            int sub = 1;

            List<string[]> datas = new List<string[]>();
            List<string> buffer = new List<string>();

            for (int i = 3; i < row; i++)
            {
                if (data_buffer[i, 1] != null)
                {
                    for (int j = 3; j < 13; j++)
                    {
                        if ((data_buffer[i, j] != null) && (data_buffer[i, j].ToString().Equals("0") == false) && (data_buffer[i, j].ToString().Equals("-") == false))
                        {
                            buffer.Add(data_buffer[i, 1] == null ? "" : data_buffer[i, 1].ToString());           // 부재 level 3
                            buffer.Add(data_buffer[i, 2] == null ? "" : data_buffer[i, 2].ToString());           // 부재 level 4
                            buffer.Add(data_buffer[i, 15] == null ? "" : data_buffer[i, 15].ToString());          // 부재별 상태등급
                            buffer.Add(data_buffer[i, 14] == null ? "" : data_buffer[i, 14].ToString());          // 부재별 결함지수
                            buffer.Add("");                                     // 시설물 등급
                            buffer.Add("");                                     // 시설물 결함지수
                            buffer.Add(data_buffer[2, j] == null ? "" : data_buffer[2, j].ToString());           // 손상종류
                            buffer.Add(data_buffer[i, j] == null ? "" : data_buffer[i, j].ToString());           // 개소수
                            buffer.Add(data_buffer[i, 16] == null ? "" : data_buffer[i, 16].ToString());          // 비고
                            datas.Add(buffer.ToArray());
                            buffer.Clear();
                        }
                    }
                }
            }

            rm.CloseExcel();
            #endregion

            Writing_Report(2, datas);
        }

        // 상태평가 Type-B
        private void buttonItem21_Click(object sender, EventArgs e)
        {
            Report_Manager rm = new Report_Manager();

            #region [ # Data Loading ]
            string data_file = @"F:\［ Download ］\" + data_file2 + ".xlsx";
            rm.Init_Excel_Report(data_file, "1.상태평가 결과");

            object[,] data_buffer = rm.GetData();
            int row = data_buffer.GetLength(0);
            int col = data_buffer.GetLength(1);

            int sub = 0;
            string score = Convert.ToDouble(data_buffer[98, 14 - sub]).ToString("#0.00");
            string grade = data_buffer[99, 14 - sub].ToString();

            string[] data_sheets = new string[] { "2.결함지수 및 등급산정(개착식터널)_강제입력", "3.결함지수 및 등급산정(ASSM 무근)_강제입력", "2.결함지수 및 등급산정(개착식 정거장)" };

            List<string[]> datas = new List<string[]>();
            List<string> buffer = new List<string>();

            for (int sheet = 0; sheet < data_sheets.Length; sheet++)
            {
                rm.Change_Worksheet(data_sheets[sheet]);

                data_buffer = rm.GetData();
                row = data_buffer.GetLength(0);
                col = data_buffer.GetLength(1);

                for (int i = 5; i < row; i++)
                {
                    if (data_buffer[i, 1] != null)
                    {
                        int sss = 1;
                        int gap = 2;
                        int val = 0;
                        Int32.TryParse(data_buffer[i, 1].ToString(), out val);

                        if (val > 0)
                        {
                            for (int j = (5 + sss); j < (35 + sss); j += (1 + gap))
                            {
                                if ((data_buffer[i, j] != null) && (data_buffer[i, j].ToString().Equals("0") == false) && (data_buffer[i, j].ToString().Equals("-") == false))
                                {
                                    string level3 = data_buffer[i, 3] == null ? "" : data_buffer[i, 3].ToString();
                                    level3 += data_buffer[i, 4] == null ? "" : ("~" + data_buffer[i, 4].ToString());
                                    buffer.Add(level3);                                                             // 부재 level 3
                                    buffer.Add(data_buffer[i, 2] == null ? "" : data_buffer[i, 2].ToString());      // 부재 level 4
                                    buffer.Add(data_buffer[i, j + gap] == null ? "" : data_buffer[i, j + gap].ToString());    // 부재별 상태등급
                                    buffer.Add(data_buffer[i, 36 + sss] == null ? "" : Convert.ToDouble(data_buffer[i, 36 + sss]).ToString("#0.00"));    // 결함지수
                                    buffer.Add(grade);
                                    buffer.Add(score);
                                    buffer.Add(data_buffer[4, j] == null ? (data_buffer[3, j] == null ? "" : data_buffer[3, j].ToString()) : data_buffer[4, j].ToString());                                       // 손상종류
                                    buffer.Add(data_buffer[i, j].ToString());                                       // 손상 개소수
                                    buffer.Add("");// data_buffer[i, 16] == null ? "" : data_buffer[i, 16].ToString());    // 비고
                                    datas.Add(buffer.ToArray());
                                    buffer.Clear();
                                }
                            }
                        }
                    }
                }
            }

            rm.CloseExcel();
            #endregion

            Writing_Report(2, datas);
        }

        private void Writing_Report(int Type, List<string[]> Datas)
        {
            Report_Manager rm = new Report_Manager();

            #region [ # Reporting ]
            string report_name = @"F:\동해 데이터 처리 건\01. FMS받은자료\01_터널\3호선\" + report_file + ".xlsx";
            rm.Init_Excel_Report(report_name, "점검진단정보");

            int idx = 2;
            string sheet_name = string.Empty;

            while (true)
            {
                sheet_name = "점검진단정보 (" + idx + ")";

                if (rm.Existing_Sheet(sheet_name) == false)
                {
                    break;
                }

                idx++;
            }

            idx--;
            sheet_name = "점검진단정보 (" + idx + ")";

            if (idx == 1)
            {
                rm.Change_Worksheet("점검진단정보");
            }
            else
            {
                rm.Change_Worksheet(sheet_name);
            }

            int s_idx = 0;

            while (true)
            {
                object tmp = rm.GetData(s_idx + 1, 1);

                if (tmp == null)
                {
                    break;
                }

                s_idx++;
            }

            int pages = 0;
            int index;
            int start = s_idx + 1;

            List<string> Data_Sets = new List<string>();

            for (int i = 0; i < Datas.Count; i++)
            {
                index = (s_idx + i) - (3000 * pages) + 1;

                if (index > 3000)
                {
                    try
                    {
                        rm.Change_Worksheet("샘플");

                        idx = 2;
                        sheet_name = string.Empty;

                        while (true)
                        {
                            sheet_name = "점검진단정보 (" + idx + ")";

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

                if (Type == 2)
                {
                    Data_Sets.Add(Datas[i][0]);
                    Data_Sets.Add(Datas[i][1]);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(Datas[i][2]);
                    Data_Sets.Add(Datas[i][3]);
                    Data_Sets.Add(Datas[i][4]);
                    Data_Sets.Add(Datas[i][5]);
                    Data_Sets.Add(Datas[i][6]);
                    Data_Sets.Add(Datas[i][7]);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(Datas[i][8]);
                }
                else
                {
                    Data_Sets.Add(Datas[i][0]);
                    Data_Sets.Add(Datas[i][1]);
                    Data_Sets.Add(Datas[i][2]);
                    Data_Sets.Add(Datas[i][3]);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(Datas[i][4]);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(Datas[i][5]);
                    Data_Sets.Add(Datas[i][6]);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(Datas[i][7]);
                    Data_Sets.Add(Datas[i][8]);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(string.Empty);
                    Data_Sets.Add(Datas[i][9]);
                }

                rm.InsertExcel("N" + index, Data_Sets.ToArray());

                Data_Sets.Clear();
            }

            rm.Save_Excel();
            rm.CloseExcel();
            #endregion

            MessageBox.Show("완료");
        }

    }
    ///=================================================================================== End of Class : MainForm =///
}
