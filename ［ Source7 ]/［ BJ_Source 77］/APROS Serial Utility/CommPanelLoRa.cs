using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Apros_Class_Library_Base;

namespace APROS_Serial_Utility
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2017-05-31 ] ///
    /// ▷ CommPanelLora : UserControl ◁                                                                           ///
    ///     SKT LoRa 테스트용 통신 패널                                                                             ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2017-05-31 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class CommPanelLora : UserControl
    {
        // 식별 이름
        private string ControlName = string.Empty;

        // SKT ThingPlug Server 통신용 객체
        private HttpWebRequest request;
        private HttpWebResponse response;

        // 통신 결과 처리 관련 변수
        private Stream ResponseStream;
        private StreamReader RStream;
        private string Result = string.Empty;
        private string Latest = string.Empty;
        private string DataPack = string.Empty;

        // 데이터 저장 관련 변수
        private string FPath = CommonBase.DataPath;
        private string FName = string.Empty;

        // 중복 데이터 표시 방지용 변수
        private bool DisplayOn = false;

        // 수신 데이터 버퍼
        private string[] ValBuff;
        private string[] TmpBuff;

        // 화면 표시 데이터 저장 변수
        private List<string> Display = new List<string>();

        // 초기 설정 LTID 콤보박스Index
        private int LTID_IDX = 0;

        // 기본 설정 값
        private readonly string Def_AppEUI = "9999991000000003";
        private readonly string Def_LTID = "00000078000c05c016101026";
        private readonly string Def_uKey = "RU1GeWk4R3B3K0xBUkhOTFZ2dS8xYnRNZ0h0Y2ZMdzlpOTY1YXFxa3N1NVU2a1BkRWt1bGZua29qQmpUSTdmOQ==";

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ CommPanelLora @                                                                                       ///
        ///     생성자로 컨트롤을 초기화하며 매개변수로 데이터를 저장할 파일 이름을 전달한다.                       ///
        /// </summary>                                                                                              ///
        /// <param name="fName"> string : 데이터 파일 이름 </param>                                                 ///
        ///=========================================================================================================///
        public CommPanelLora(string fName)
        {
            InitializeComponent();

            FName = fName;
            ControlName = fName;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ CommPanelRoLa_Load @                                                                                  ///
        ///     생성 후 로드되는 시점에 호출되는 이벤트 핸들러 초기 작업을 수행한다.                                ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void CommPanelRoLa_Load(object sender, EventArgs e)
        {
            m_cb_AppEUI.SelectedIndex = 0;
            m_cb_LTID.SelectedIndex = LTID_IDX;
            m_cb_Fucntion.SelectedIndex = 1;
            m_cb_uKey.SelectedIndex = 0;

            m_txb_savepath.Text = FPath;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_btn_Send_Click @                                                                                    ///
        ///     SKT Thingplug 서버로 프로토콜 패킷을 생성하여 전송하고 그 결과를 화면에 표출한다.                   ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_Send_Click(object sender, EventArgs e)
        {
            string func = m_cb_Fucntion.Text;

            switch (func)
            {
                case "Node":
                    try
                    {
                        request = (HttpWebRequest)WebRequest.Create("http://thingplugpf.sktiot.com:9000/"
                            + m_cb_AppEUI.Text + "/v1_0/" + "node-" + m_cb_LTID.Text);

                        request.Accept = "application/json";
                        request.Method = WebRequestMethods.Http.Get;
                        request.Headers.Add("X-M2M-Ri", "1234");
                        request.Headers.Add("X-M2M-Origin", "Origin");
                        request.Headers.Add("uKey", m_cb_uKey.Text);

                        response = (HttpWebResponse)request.GetResponse();

                        ResponseStream = response.GetResponseStream();
                        RStream = new StreamReader(ResponseStream, Encoding.Default);

                        Result = RStream.ReadToEnd();

                        FileManager.LogWriter(Result, CommonBase.DataPath, "LoRa_Raw", true, true, true, true, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Latest":
                    try
                    {
                        request = (HttpWebRequest)WebRequest.Create("http://thingplugpf.sktiot.com:9000/"
                            + m_cb_AppEUI.Text + "/v1_0/" + "remoteCSE-" + m_cb_LTID.Text + "/container-LoRa/latest");

                        request.Accept = "application/json";
                        request.Method = WebRequestMethods.Http.Get;
                        request.Headers.Add("X-M2M-Ri", "1234");
                        request.Headers.Add("X-M2M-Origin", "Origin");
                        request.Headers.Add("uKey", m_cb_uKey.Text);

                        response = (HttpWebResponse)request.GetResponse();

                        ResponseStream = response.GetResponseStream();
                        RStream = new StreamReader(ResponseStream, Encoding.Default);

                        Result = RStream.ReadToEnd();

                        FileManager.LogWriter(Result, CommonBase.DataPath, "LoRa_Raw", true, true, true, true, true);

                        ValBuff = Result.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < ValBuff.Length; i++)
                        {
                            if (ValBuff[i].Contains("st") == true)
                            {
                                TmpBuff = ValBuff[i].Split(new char[] { ' ', ':', '\"' }, StringSplitOptions.RemoveEmptyEntries);
                                Display.Add(TmpBuff[4]);

                                if (Latest.Equals(TmpBuff[4]) == false)
                                {
                                    DisplayOn = true;
                                    Latest = TmpBuff[4];
                                }
                            }
                            else if (ValBuff[i].Contains("con") == true)
                            {
                                TmpBuff = ValBuff[i].Split(new char[] { ' ', '\"' }, StringSplitOptions.RemoveEmptyEntries);
                                Display.Add(TmpBuff[2]);
                                DataPack = TmpBuff[2];
                            }
                            else if (ValBuff[i].Contains("ct") == true)
                            {
                                TmpBuff = ValBuff[i].Split(new char[] { ' ', '\"' }, StringSplitOptions.RemoveEmptyEntries);
                                Display.Add(TmpBuff[2]);
                            }
                        }

                        if (DisplayOn == true)
                        {
                            dataGridViewX1.Rows.Insert(0, Display.ToArray());

                            byte[] packet = CommonBase.HexStringToByteArray(DataPack);
                            PacketParsing(packet);

                            DisplayOn = false;
                        }

                        Display.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "DevReset":
                    try
                    {
                        request = (HttpWebRequest)WebRequest.Create("http://thingplugpf.sktiot.com:9000/"
                            + m_cb_AppEUI.Text + "/v1_0/" + "mgmtCmd-" + m_cb_LTID.Text + "_DevReset");

                        request.Accept = "application/xml";
                        request.Method = WebRequestMethods.Http.Get;
                        request.Headers.Add("X-M2M-Ri", "1234");
                        request.Headers.Add("X-M2M-Origin", "Origin");
                        request.Headers.Add("Content-Type", "application/vnd.onem2m-res+xml");
                        request.Headers.Add("X-M2M-NM", m_cb_LTID.Text + "_DevReset");
                        request.Headers.Add("uKey", m_cb_uKey.Text);

                        response = (HttpWebResponse)request.GetResponse();

                        ResponseStream = response.GetResponseStream();
                        RStream = new StreamReader(ResponseStream, Encoding.Default);

                        Result = RStream.ReadToEnd();

                        FileManager.LogWriter(Result, CommonBase.DataPath, "LoRa_Raw", true, true, true, true, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                default:
                    MessageBox.Show("오류 : 지원하지 않는 기능입니다.");
                    break;
            }

            m_txb_recv.Text = Result;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_ckb_repeat_CheckedChanged @                                                                         ///
        ///     전송 타이머를 시작/중지한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_ckb_repeat_CheckedChanged(object sender, EventArgs e)
        {
            if(m_ckb_repeat.Checked == true)
            {
                timer_repeat.Start();
            }
            else
            {
                timer_repeat.Stop();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ timer_repeat_Tick @                                                                                   ///
        ///     10초 주기로 Thingplug 서버로의 전송을 수행한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void timer_repeat_Tick(object sender, EventArgs e)
        {
            m_btn_Send_Click(sender, e);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ PacketParsing @                                                                                       ///
        ///     매개변수로 전달된 데이터 패킷을 파싱하여 결과를 화면에 표출하고 파일로 저장한다.                    ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 데이터 패킷 </param>                                                     ///
        ///=========================================================================================================///
        private void PacketParsing(byte[] packet)
        {
            string ID = string.Empty;
            int D_len;
            string Val = string.Empty;
            byte[] buff = new byte[2];
            List<string> Values = new List<string>();

            for (int i = 0; i < packet.Length; i++)
            {
                switch (packet[i])
                {
                    case 0x01:
                        ID = "ID";
                        D_len = Convert.ToInt32(packet[i + 1]);

                        for (int j = 0; j < 8; j++)
                            Val += packet[i + 2 + j].ToString("X2");

                        Values.Add(Val);

                        i += (1 + D_len);
                        break;
                    case 0x11:
                        ID = "Temp";
                        D_len = Convert.ToInt32(packet[i + 1]);

                        buff[0] = packet[i + 2];
                        buff[1] = packet[i + 3];

                        Val = (BitConverter.ToInt16(buff, 0) / 100.0f).ToString("00.00");
                        Values.Add(Val);

                        i += (1 + D_len);
                        break;
                    case 0x12:
                        ID = "Hum";
                        D_len = Convert.ToInt32(packet[i + 1]);

                        buff[0] = packet[i + 2];
                        buff[1] = packet[i + 3];

                        Val = (BitConverter.ToInt16(buff, 0) / 100.0f).ToString("00.00");
                        Values.Add(Val);

                        i += (1 + D_len);
                        break;
                    case 0x13:
                        ID = "SPL";
                        D_len = Convert.ToInt32(packet[i + 1]);

                        buff[0] = packet[i + 2];
                        buff[1] = packet[i + 3];

                        Val = (BitConverter.ToInt16(buff, 0) / 100.0f).ToString("00.00");
                        Values.Add(Val);

                        i += (1 + D_len);
                        break;
                    default: break;
                }
            }

            dataGridViewX2.Rows.Insert(0, Values.ToArray());

            string FileName = m_cb_LTID.Text.Substring(m_cb_LTID.Text.Length - 5, 5).ToUpper();

            StreamWriter sw = new StreamWriter(CommonBase.DataPath + "\\"
                + FileName + "-" + DateTime.Today.ToShortDateString() + ".csv", true);

            sw.WriteLine(DateTime.Now.ToString("hh:mm:ss") + "," + Values[1] + "," + Values[2] + "," + Values[3]);
            sw.Flush();
            sw.Close();

            if (string.IsNullOrEmpty(FName) == false)
            {
                string msg = CommonBase.Hex2Str16(packet, packet.Length);
                FileManager.LogWriter(msg, FPath, FName, false, false, false, false, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ LoRaConfigSet @                                                                                       ///
        ///     매개변수로 전달된 SKT LoRa 정보를 콤보박스에 설정한다.                                              ///
        /// </summary>                                                                                              ///
        /// <param name="AppEUI"> string[] : AppEUI 리스트 </param>                                                 ///
        /// <param name="LTID"> string[] : LTID 리스트 </param>                                                     ///
        /// <param name="uKey"> string[] : uKey 리스트 </param>                                                     ///
        ///=========================================================================================================///
        public void LoRaConfigSet(string[] AppEUI, string[] LTID, string[] uKey)
        {
            m_cb_AppEUI.Items.Clear();

            if (AppEUI.Length > 0)
            {
                for (int i = 0; i < AppEUI.Length; i++)
                {
                    m_cb_AppEUI.Items.Add(AppEUI[i]);
                }
            }
            else
            {
                m_cb_AppEUI.Items.Add(Def_AppEUI);
            }

            m_cb_LTID.Items.Clear();

            if (LTID.Length > 0)
            {
                for (int i = 0; i < LTID.Length; i++)
                {
                    m_cb_LTID.Items.Add(LTID[i]);
                }
            }
            else
            {
                m_cb_LTID.Items.Add(Def_LTID);
            }

            m_cb_uKey.Items.Clear();

            if (uKey.Length > 0)
            {
                for (int i = 0; i < uKey.Length; i++)
                {
                    m_cb_uKey.Items.Add(uKey[i]);
                }
            }
            else
            {
                m_cb_uKey.Items.Add(Def_uKey);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-05-31 ] ///
        /// @ m_btn_path_setup_Click @                                                                              ///
        ///     데이터 파일을 저장할 경로를 설정한다.                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_path_setup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                m_txb_savepath.Text = fbd.SelectedPath;
                FPath = fbd.SelectedPath;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-06-08 ] ///
        /// @ SetControlName @                                                                                      ///
        ///     컨트롤 식별용 이름을 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="name"> string : 식별 이름 </param>                                                         ///
        ///=========================================================================================================///
        public void SetControlName(string name)
        {
            ControlName = name;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-06-08 ] ///
        /// @ GetControlName @                                                                                      ///
        ///     컨트롤 식별용 이름을 반환한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <returns> string : 식별 이름 </returns>                                                                 ///
        ///=========================================================================================================///
        public string GetControlName()
        {
            return ControlName;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-06-08 ] ///
        /// @ SaveConfig @                                                                                          ///
        ///     컨트롤의 사용자 설정 환경을 작성하여 반환한다.                                                      ///
        /// </summary>                                                                                              ///
        /// <returns> string : 사용자 설정 환경 </returns>                                                          ///
        ///=========================================================================================================///
        public string SaveConfig()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("[" + GetControlName() + "]");

            if (m_cb_AppEUI.Items.Count > 0)
            {
                for (int i = 0; i < m_cb_AppEUI.Items.Count; i++)
                {
                    sb.AppendLine("AppEUI:" + m_cb_AppEUI.Items[i].ToString());
                }
            }

            if (m_cb_LTID.Items.Count > 0)
            {
                for (int i = 0; i < m_cb_LTID.Items.Count; i++)
                {
                    sb.AppendLine("LTID:" + m_cb_LTID.Items[i].ToString());
                }
            }

            if (m_cb_uKey.Items.Count > 0)
            {
                for (int i = 0; i < m_cb_uKey.Items.Count; i++)
                {
                    sb.AppendLine("uKey" + m_cb_uKey.Items[i].ToString());
                }
            }

            sb.AppendLine("Save Path:" + m_txb_savepath.Text);
            sb.AppendLine("Auto Repeat:" + Convert.ToInt32(m_ckb_repeat.Checked));

            return sb.ToString();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-06-08 ] ///
        /// @ SetConfig @                                                                                           ///
        ///     매개변수로 전달된 사용자 환경을 설정한다.                                                           ///
        /// </summary>                                                                                              ///
        /// <param name="values"> object[] : 사용자 환경 </param>                                                   ///
        ///=========================================================================================================///
        public void SetConfig(string data)
        {
            string[] values = data.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            m_cb_AppEUI.Items.Clear();
            m_cb_LTID.Items.Clear();
            m_cb_uKey.Items.Clear();

            for (int i = 0; i < values.Length; i++)
            {
                string[] sub = ((string)values[i]).Split(new char[] { ':', ',' });

                switch (sub[0])
                {
                    case "AppEUI":      m_cb_AppEUI.Items.Add(sub[1]); break;
                    case "LTID":        m_cb_LTID.Items.Add(sub[1]); break;
                    case "uKey":        m_cb_uKey.Items.Add(sub[1]); break;
                    case "Save Path":   m_txb_savepath.Text = sub[1]; break;
                    case "Auto Repeat": m_ckb_repeat.Checked = Convert.ToBoolean(Convert.ToInt32(sub[1])); break;
                    default: break;
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2017-07-24 ] ///
        /// @ Close @                                                                                               ///
        ///     통신 객체들의 동작을 중단하고 초기화한다.                                                           ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void Close()
        {
            // Not Used
        }
    }
    ///============================================================================== End of Class : CommPanelLora =///
}
