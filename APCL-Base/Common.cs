using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Net.Mail;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Resources;
using Apros_Class_Library_Base.Properties;
using DevComponents.DotNetBar;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-03-31 ] ///
    /// ▷ CommonVariables ◁                                                                                       ///
    ///     전역 참조 변수 선언 클래스                                                                              ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-03-31 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class CommonVariables
    {
        #region [ # Defines & Variables ]
        // 기본 참조 경로
        static public readonly string AlarmPath  = @".\[Alarm Logs]";
        static public readonly string ConfigPath = @".\[Config Files]";
        static public readonly string CRCPath    = @".\[CRC Logs]";
        static public readonly string DataPath   = @".\[Data Files]";
        static public readonly string DownPath   = @".\[Download Files]";
        static public readonly string ErrorPath  = @".\[Error Logs]";
        static public readonly string LogPath    = @".\[Program Logs]";

        static public readonly string ErrorLogName = "ErrorLog";

        static public readonly string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";

        // Apros 메일 정보
        static public readonly string SMTPServer1 = "uws64-109.cafe24.com"; // 호스팅 설정에 따라 변동될 수 있음
        static public readonly string SMTPServer2 = "go-apros.com";
        static public readonly string SMTPID = "apros337@go-apros.com";
        static public readonly string SMTPPW = "apros83378";

        static public readonly string Contact_Develop = "develop@go-apros.com";
        static public readonly string Contact_Support = "support@go-apros.com";
        public enum GraphKind { Line, Bar, ThreeD };

        public ResourceManager APCL_ResourceManager;

        // 센서 정보 정의
        static public Dictionary<byte, string> SensorTypes = new Dictionary<byte, string>()
        {
            // Group 0X
            { 0x00, "Reserved" }, { 0x01,"ID" }, { 0x02, "Battery" }, { 0x03, "Date" }, { 0x04, "Time" }, { 0x05, "RSSI" }, { 0x06, "Status" }, { 0X07, "None" },
            { 0X08, "None" }, { 0X09, "None" },{ 0X0A, "None" }, { 0X0B, "None" }, { 0X0C, "None" }, { 0X0D, "None" }, { 0X0E, "None" }, { 0X0F, "None" },
            // Group 1X
            { 0x10, "Motion" }, { 0x11, "Temp" }, { 0x12, "Hum" }, { 0x13, "SPL" }, { 0x14, "Light" }, { 0x15, "Location" },{ 0x16, "Wind Vane" }, { 0x17, "Wind Speed" },
            { 0x18, "Solar" },{ 0x19, "Heat" }, { 0x1A, "GPS" }, { 0X1B, "None" }, { 0X1C, "None" }, { 0X1D, "None" }, { 0X1E, "None" }, { 0X1F, "None" },
            // Group 2X
            { 0x20, "Ph" }, { 0x21, "CO2" }, { 0x22, "O2" }, { 0x23, "H2" }, { 0x24, "CO" }, { 0x25, "VOC" }, { 0x26, "NH3" }, { 0x27, "NO2" },
            { 0x28, "None" },{ 0x29, "None" }, { 0x2A, "None" }, { 0X2B, "None" }, { 0X2C, "None" }, { 0X2D, "None" }, { 0X2E, "None" }, { 0X2F, "None" },
            // Group 3X
            { 0x30, "Watt" }, { 0x31, "Volt" }, { 0x32, "Current" }, { 0x33, "Power Factor" }, { 0x34, "Freq" }, { 0x35, "None" }, { 0x36, "None" }, { 0x37, "None" },
            { 0x38, "None" },{ 0x39, "None" }, { 0x3A, "None" }, { 0X3B, "None" }, { 0X3C, "None" }, { 0X3D, "None" }, { 0X3E, "None" }, { 0X3F, "None" },
            // Group 4X
            { 0x40, "Crack" }, { 0x41, "Displacement" }, { 0x42, "Pressure" }, { 0x43, "Slope" }, { 0x44, "Weight" }, { 0x45, "None" }, { 0x46, "None" }, { 0x47, "None" },
            { 0x48, "None" },{ 0x49, "None" }, { 0x4A, "None" }, { 0X4B, "None" }, { 0X4C, "None" }, { 0X4D, "None" }, { 0X4E, "None" }, { 0X4F, "None" },
            // Group AX
            { 0xA0, "Ph" }, { 0xA1, "CO2" }, { 0xA2, "O2" }, { 0xA3, "H2" }, { 0xA4, "CO" }, { 0xA5, "VOC" }, { 0xA6, "NH3" }, { 0xA7, "NO2" },
            { 0xA8, "None" },{ 0xA9, "None" }, { 0xAA, "None" }, { 0XAB, "None" }, { 0XAC, "None" }, { 0XAD, "None" }, { 0XAE, "None" }, { 0XAF, "None" }
        };
        #endregion
    }
    ///============================================================================ End of Class : CommonVariables =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.02 / 2018-11-30 ] ///
    /// ▷ CommonConfig ◁                                                                                          ///
    ///     환경 설정 변수 관리 클래스                                                                              ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2018-02-19 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2018-10-16 ]                                                                                   ///
    ///     ▶ RibbonBar 옵션 추가                                                                                  ///
    /// [ Ver 1.02 / 2018-11-30 ]                                                                                   ///
    ///     ▶ MQTT 관련 옵션 추가                                                                                  ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class CommonConfig
    {
        #region [ # Defines & Variables ]
        // [RibbonBar]
        public List<bool> Property = new List<bool>();

        // [Conversion]
        public int ADC_Bits  = 24;
        public double Coef   = 0.0;
        public double Scale  = 0.0;
        public double Gain   = 0.0;
        public double Offset = 0.0;
        public List<double> CT_Coefs = new List<double>();

        // [Axis]
        public bool X_enable = false;
        public bool Y_enable = false;
        public bool Z_enable = false;

        // [DB]
        public string DBServer_IP = string.Empty;
        public int DBServer_Port  = 0;
        public string DBCategory  = string.Empty;

        // [Site]
        public string Site_Name = string.Empty;
        public string InfoServer_IP = string.Empty;
        public int InfoServer_Port = 0;
        public string InfoCategory = string.Empty;

        // [MQTT]
        public string Broker_IP = string.Empty;
        public List<string> Topics = new List<string>();

        // SKT LoRa Environment
        // [LoRa]
        public List<string> AppEUI = new List<string>();
        public List<string> LTID = new List<string>();
        public List<string> uKey = new List<string>();

        // APROS Smart Sensor Environment
        public List<GateInfo> GIDs = new List<GateInfo>();
        public List<BaseInfo> BIDs = new List<BaseInfo>();
        public List<NodeInfo> NIDs = new List<NodeInfo>();

        // For PdM Target Device Environment
        public List<TargetInfo> TIDs = new List<TargetInfo>();
        public List<Alarms> Alarm = new List<Alarms>();
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-19 ] ///
        /// @ InitConfig @                                                                                          ///
        ///     매개변수로 지정한 경로에 환경 설정 파일이 존재하면 해당 값으로 초기화를 수행한다.                   ///
        /// </summary>                                                                                              ///
        /// <param name="path"> string : 환경 설정 파일 경로 </param>                                               ///
        ///=========================================================================================================///
        public void InitConfig(string path)
        {
            List<string> configs = new List<string>();
            string Set_Conf = string.Empty;

            FileInfo fi = new FileInfo(path);

            if (fi.Exists == true)
            {
                StreamReader sr = new StreamReader(fi.FullName, Encoding.GetEncoding("euc-kr"));

                while (sr.EndOfStream == false)
                {
                    string data = sr.ReadLine();

                    if (data.Contains("[") == true)
                    {
                        if (string.IsNullOrEmpty(Set_Conf) == true)
                        {
                            Set_Conf = data;
                        }
                        else
                        {
                            if (Set_Conf.Equals("[Axis]") == true)
                            {
                                Config_Axis(configs.ToArray());
                            }
                            else if (Set_Conf.Equals("[Conversion]") == true)
                            {
                                Config_Conversion(configs.ToArray());
                            }
                            else if (Set_Conf.Equals("[GID]") == true)
                            {
                                Config_GID(configs.ToArray());
                            }
                            else if (Set_Conf.Equals("[BID]") == true)
                            {
                                Config_BID(configs.ToArray());
                            }
                            else if (Set_Conf.Equals("[NID]") == true)
                            {
                                Config_NID(configs.ToArray());
                            }
                            else if (Set_Conf.Equals("[TID]") == true)
                            {
                                Config_TID(configs.ToArray());
                            }
                            else if (Set_Conf.Equals("[ALARM]") == true)
                            {
                                Config_Alarm(configs.ToArray());
                            }
                            else if (Set_Conf.Equals("[DB]") == true)
                            {
                                Config_DB(configs.ToArray());
                            }
                            else if (Set_Conf.Equals("[LoRa]") == true)
                            {
                                Config_LoRa(configs.ToArray());
                            }
                            else if (Set_Conf.Equals("[Ribbon]") == true)
                            {
                                Config_Ribbon(configs.ToArray());
                            }
                            else if (Set_Conf.Equals("[Site]") == true)
                            {
                                Config_SiteInfo(configs.ToArray());
                            }
                            else if (Set_Conf.Equals("[MQTT]") == true)
                            {
                                Config_MQTT(configs.ToArray());
                            }

                            configs.Clear();
                            Set_Conf = data;
                        }
                    }
                    else
                    {
                        configs.Add(data);
                    }
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-20 ] ///
        /// @ Config_Axis @                                                                                         ///
        ///     환경 설정 데이터에서 축 관련 정보를 추출하여 환경 변수에 설정한다.                                  ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_Axis(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("info") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        switch (sub[0])
                        {
                            case "X": bool.TryParse(sub[1], out X_enable); break;
                            case "Y": bool.TryParse(sub[1], out Y_enable); break;
                            case "Z": bool.TryParse(sub[1], out Z_enable); break;
                            default: break;
                        }

                        cnt++;
                    }
                }
            }

            return (cnt - info);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-20 ] ///
        /// @ Config_Conversion @                                                                                   ///
        ///     환경 설정 데이터에서 데이터 환산 관련 정보를 추출하여 환경 변수에 설정한다.                         ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_Conversion(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("info") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        switch (sub[0])
                        {
                            case "adc_bits" : checker = Int32.TryParse(sub[1], out ADC_Bits); break;
                            case "coef"     : checker = Double.TryParse(sub[1], out Coef); break;
                            case "scale"    : checker = Double.TryParse(sub[1], out Scale); break;
                            case "gain"     : checker = Double.TryParse(sub[1], out Gain); break;
                            case "offset"   : checker = Double.TryParse(sub[1], out Offset); break;
                            case "CT"       :
                                {
                                    double tmp = 0;
                                    int coefs = 0;

                                    checker = Int32.TryParse(sub[1], out coefs);

                                    for (int j = 0; j < coefs; j++)
                                    {
                                        checker = double.TryParse(sub[2 + j], out tmp);
                                        CT_Coefs.Add(tmp);
                                    }
                                }
                                break;
                            default: break;
                        }

                        cnt++;
                    }
                }
            }

            return (cnt - info);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-21 ] ///
        /// @ Config_GID @                                                                                          ///
        ///     환경 설정 데이터에서 그룹 ID 관련 정보를 추출하여 환경 변수에 설정한다.                             ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_GID(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("gateway") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 8)
                    {
                        GateInfo gi = new GateInfo();
                        int tmpX = 0, tmpY = 0;

                        checker       = Int32.TryParse(sub[0], out gi.Idx);
                        gi.ID         = sub[1];
                        checker       = Int32.TryParse(sub[2], out tmpX);
                        checker       = Int32.TryParse(sub[3], out tmpY);
                        gi.Location   = new Point(tmpX, tmpY);
                        gi.Setup_X    = sub[4];
                        gi.Setup_Y    = sub[5];
                        gi.Power_Type = sub[6];
                        gi.IP_Address = sub[7];
                        gi.Port       = sub[8];

                        GIDs.Add(gi);
                        cnt++;
                    }
                }
            }

            return (cnt - info);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-21 ] ///
        /// @ Config_BID @                                                                                          ///
        ///     환경 설정 데이터에서 베이스 모듈 ID 관련 정보를 추출하여 환경 변수에 설정한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_BID(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("base") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 4)
                    {
                        BaseInfo bi = new BaseInfo();

                        checker = Int32.TryParse(sub[0], out bi.Idx);
                        checker = Int32.TryParse(sub[1], out bi.Gid);
                        bi.ID   = sub[2];
                        checker = Int32.TryParse(sub[3], out bi.Nodes);
                        checker = Int32.TryParse(sub[4], out bi.Channel);

                        BIDs.Add(bi);
                        cnt++;
                    }
                }
            }

            return (cnt - info);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-21 ] ///
        /// @ Config_NID @                                                                                          ///
        ///     환경 설정 데이터에서 센서 노드 ID 관련 정보를 추출하여 환경 변수에 설정한다.                        ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_NID(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("node") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        NodeInfo ni = new NodeInfo();
                        int tmpX = 0, tmpY = 0;

                        checker       = Int32.TryParse(sub[0], out ni.Bid);
                        checker       = Int32.TryParse(sub[1], out ni.Idx);
                        ni.ID         = sub[2];
                        checker       = Int32.TryParse(sub[3], out tmpX);
                        checker       = Int32.TryParse(sub[4], out tmpY);
                        ni.Setup_X    = sub[5];
                        ni.Setup_Y    = sub[6];
                        checker       = Int32.TryParse(sub[7], out ni.Tid);
                        checker       = Int32.TryParse(sub[8], out ni.Alarms);
                        ni.Power_Type = sub[9];

                        NIDs.Add(ni);
                        cnt++;
                    }
                }
            }

            return (cnt - info);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-21 ] ///
        /// @ Config_TID @                                                                                          ///
        ///     환경 설정 데이터에서 계측 대상 ID 관련 정보를 추출하여 환경 변수에 설정한다.                        ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_TID(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("target") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        TargetInfo ti = new TargetInfo();

                        checker    = Int32.TryParse(sub[0], out ti.ID);
                        ti.Name    = sub[1];
                        ti.Process = sub[2];
                        ti.Type    = sub[3];
                        ti.Gas     = sub[4];
                        ti.Maker   = sub[5];
                        ti.Model   = sub[6];

                        TIDs.Add(ti);
                        cnt++;
                    }
                }
            }

            return (cnt - info);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-21 ] ///
        /// @ Config_Alarm @                                                                                        ///
        ///     환경 설정 데이터에서 알람 관련 정보를 추출하여 환경 변수에 설정한다.                                ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_Alarm(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("alarms") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 5)
                    {
                        int tmp = 0;
                        int Lv1 = 0, Lv2 = 0, Lv3 = 0;
                        Alarms ai = new Alarms();

                        checker = Int32.TryParse(sub[0], out ai.ID);
                        checker = Int32.TryParse(sub[1], out tmp);

                        for (int j = 0; j < tmp; j++)
                        {
                            checker = Int32.TryParse(sub[3 * j + 2], out Lv1);
                            checker = Int32.TryParse(sub[3 * j + 3], out Lv2);
                            checker = Int32.TryParse(sub[3 * j + 4], out Lv3);
                        }

                        ai.Levels.Add(new float[] { Lv1, Lv2, Lv3 });

                        Alarm.Add(ai);
                        cnt++;
                    }
                }
            }

            return (cnt - info);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-20 ] ///
        /// @ Config_DB @                                                                                           ///
        ///     환경 설정 데이터에서 DB 서버 관련 정보를 추출하여 환경 변수에 설정한다.                             ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_DB(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("info") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    cnt++;
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        switch (sub[0])
                        {
                            case "Server_IP"   : DBServer_IP = sub[1]; break;
                            case "Server_Port" : Int32.TryParse(sub[1], out DBServer_Port); break;
                            case "Category"    : DBCategory = sub[1]; break;
                            default: break;
                        }
                    }
                }
            }

            return (cnt - info);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-21 ] ///
        /// @ Config_LoRa @                                                                                         ///
        ///     환경 설정 데이터에서 LoRa 통신 관련 정보를 추출하여 환경 변수에 설정한다.                           ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_LoRa(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("info") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    cnt++;
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        switch (sub[0])
                        {
                            case "AppEUI" : AppEUI.Add(sub[2]); break;
                            case "LTID"   : LTID.Add(sub[2]); break;
                            case "uKey"   : uKey.Add(sub[2]); break;
                            default: break;
                        }
                    }
                }
            }

            return (cnt - info);
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2018-10-16 ] ///
        /// @ Config_Ribbon @                                                                                       ///
        ///     환경 설정 데이터에서 RibbonBar 설정 관련 정보를 추출하여 환경 변수에 설정한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_Ribbon(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("info") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    cnt++;
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        switch (sub[0])
                        {
                            case "property":
                                for (int j = 1; j < sub.Length; j++)
                                {
                                    bool val;

                                    if (sub[j].Equals("T") == true)
                                    {
                                        val = true;
                                    }
                                    else
                                    {
                                        val = false;
                                    }

                                    Property.Add(val);
                                }
                                break;
                            default: break;
                        }
                    }
                }
            }

            return (cnt - info);
        }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2018-11-30 ] ///
        /// @ Config_SiteInfo @                                                                                     ///
        ///     데이터 서버 접속 정보를 설정한다.                                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_SiteInfo(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("info") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    cnt++;
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        switch (sub[0])
                        {
                            case "Name":        Site_Name = sub[1];                        break;
                            case "Server_IP":   InfoServer_IP = sub[1];                    break;
                            case "Server_Port": InfoServer_Port = Convert.ToInt32(sub[1]); break;
                            case "Category":    InfoCategory = sub[1];                     break;
                            default: break;
                        }
                    }
                }
            }

            return (cnt - info);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2018-11-30 ] ///
        /// @ Config_MQTT @                                                                                         ///
        ///     MQTT Broker 접속 정보를 설정한다.                                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="configs"> string[] : 환경 설정 데이터 </param>                                             ///
        /// <returns> int : 처리 결과 </returns>                                                                    ///
        ///=========================================================================================================///
        private int Config_MQTT(string[] configs)
        {
            bool checker = false;
            int info = 0, cnt = 0;
            string[] sub;

            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i].Contains("info") == true)
                {
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        checker = Int32.TryParse(sub[1], out info);
                    }
                }
                else
                {
                    cnt++;
                    sub = configs[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length > 1)
                    {
                        switch (sub[0])
                        {
                            case "Broker_IP": Broker_IP = sub[1]; break;
                            case "Topics":
                                for (int j = 1; j < sub.Length; j++)
                                {
                                    Topics.Add(sub[j]);
                                }
                                break;
                            default: break;
                        }
                    }
                }
            }

            return (cnt - info);
        }
        #endregion
    }
    ///=============================================================================== End of Class : CommonConfig =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2018-11-30 ] ///
    /// ▷ AcePanel : Panel ◁                                                                                      ///
    ///     노드 패널의 화면 이동시 깜박거리는 현상을 줄이기위한 패널                                               ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2017-11-30 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class AcePanel : Panel
    {
        #region [ # Defines & Variables ]
        private LabelX label;
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-11-30 ] ///
        /// @ AcePanel @                                                                                            ///
        ///     생성자로 컨트롤을 초기화한다.                                                                       ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public AcePanel()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            label = new LabelX();
            label.Size = new Size(50, 26);
            label.Location = new Point(0, 12);
            label.Font = new Font(FontFamily.GenericSansSerif, 11.0f);
            label.FontBold = true;
            label.TextAlignment = StringAlignment.Center;

            this.Controls.Add(label);
            label.Enabled = false;
            label.ForeColor = Color.Red;

            this.DoubleBuffered = true;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-11-30 ] ///
        /// @ OnNotifyMessage @                                                                                     ///
        ///     배경을 지우는 메시지는 처리하지 않도록하여 깜빡거림을 줄인다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="m"> Message : 이벤트 메시지 </param>                                                       ///
        ///=========================================================================================================///
        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x0014) // WM_ERASEBKGND == 0X0014
            {
                base.OnNotifyMessage(m);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-11-30 ] ///
        /// @ SetPanelLabel @                                                                                       ///
        ///     패널의 라벨에 매개변수로 전달된 값을 설정한다.                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="text"> string : 라벨 설정 값 </param>                                                      ///
        ///=========================================================================================================///
        public void SetPanelLabel(string text)
        {
            label.Text = text;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-11-30 ] ///
        /// @ SetLabelVisible @                                                                                     ///
        ///     패널 내부의 라벨 컨트롤의 Visible 속성을 설정한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="visible"> bool : 속성 값 </param>                                                          ///
        ///=========================================================================================================///
        public bool SetLabelVisible(bool visible)
        {
            label.Visible = visible;

            return label.Visible;
        }
        #endregion
    }
    ///=================================================================================== End of Class : AcePanel =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.04 / 2018-07-09 ] ///
    /// ▷ CommonBase : CommonVariables ◁                                                                          ///
    ///     전역 참조 함수 선언 클래스로 소프트웨어 구현 시 필요한 부가 기능들로 구성되었다.                        ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-03-28 ]                                                                                   ///
    ///     ▶ 소프트웨어 라이선스 확인 지원                                                                        ///
    ///     ▶ 중복 실행 방지 지원                                                                                  ///
    ///     ▶ 시스템 시작 시 자동 실행 지원                                                                        ///
    ///     ▶ 데이터의 특정 양식 문자열 변환                                                                       ///
    ///     ▶ 메일 전송 기능 지원                                                                                  ///
    ///     ▶ CRC 관련 기능 지원                                                                                   ///
    /// [ Ver 1.01 / 2014-05-22 ]                                                                                   ///
    ///     ▶ CRC16 확인 함수 수정                                                                                 ///
    /// [ Ver 1.02 / 2016-11-23 ]                                                                                   ///
    ///     ▶ CRC16 CCITT 기능 추가                                                                                ///
    /// [ Ver 1.03 / 2018-03-26 ]                                                                                   ///
    ///     ▶ 중복 프로세스 종료 기능 추가                                                                         ///
    /// [ Ver 1.04 / 2018-07-09 ]                                                                                   ///
    ///     ▶ 라이브러리 리소스 매니저 지원, 센서 타입 조회 기능 추가                                              ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class CommonBase : CommonVariables
    {
        #region [ # Defines & Variables ]
        static public string Message = string.Empty;
        static public StringBuilder MessageBuilder = new StringBuilder();
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ LimitConfirm @                                                                                        ///
        ///     제품의 라이선스 유효기간을 확인하여 사용 가능 여부를 반환한다.                                      ///
        /// </summary>                                                                                              ///
        /// <param name="Due_Start"> DateTime : 라이선스 사용 시작일 </param>                                       ///
        /// <param name="term"> int : 라이선스 사용 기간 </param>                                                   ///
        /// <returns> bool : 라이선스 유효 여부 </returns>                                                          ///
        ///=========================================================================================================///
        public static bool LimitConfirm(DateTime Due_Start, int term)
        {
            DateTime Today = DateTime.Today;

            TimeSpan check = Today - Due_Start;

            if (check.TotalDays >= term)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ DupleChecker @                                                                                        ///
        ///     매개변수로 전달된 이름을 가진 프로세스가 중복 실행인지 여부를 확인하여 결과를 반환한다.             ///
        /// </summary>                                                                                              ///
        /// <param name="procname"> string : 소프트웨어 실행 파일 이름 </param>                                     ///
        /// <returns> bool : 중복 실행 여부 </returns>                                                              ///
        ///=========================================================================================================///
        public static bool DupleCkecker(string procname)
        {
            bool result = false;

            try
            {
                Process[] info = Process.GetProcessesByName(procname);

                if (info.Length > 1)
                {
                    result = true;
                }
                /*
                foreach (Process p in info)
                {
                    if (p.ProcessName.Equals(procname) == true)
                    {
                        result = true;
                    }
                }*/
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.DupleChecker ]");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(procname) == true)
                {
                    MessageBuilder.AppendLine("▶ procname : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ procname : " + procname);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return result;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ SetAutoStart @                                                                                        ///
        ///     매개변수로 전달된 경로의 어셈블리를 자동실행하도록 레지스트리에 등록한다.                           ///
        /// </summary>                                                                                              ///
        /// <param name="keyName"> Registry Key Name</param>                                                        ///
        /// <param name="assemblyLocation"> Assembly location </param>                                              ///
        ///                                 (e.g. Assembly.GetExecutingAssembly().Location)                         ///
        ///=========================================================================================================///
        public static void SetAutoStart(string keyName, string assemblyLocation)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
                key.SetValue(keyName, assemblyLocation);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.SetAutoStart]");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(keyName) == true)
                    MessageBuilder.AppendLine("▶ keyName : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ keyName : " + keyName);
                
                if (string.IsNullOrEmpty(assemblyLocation) == true)
                    MessageBuilder.AppendLine("▶ assemblyLocation : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ assemblyLocation : " + assemblyLocation);

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ IsAutoStartEnabled @                                                                                  ///
        ///     매개변수로 지정한 경로의 어셈블리가 레지스트리에 등록 여부를 반환한다.                              ///
        /// </summary>                                                                                              ///
        /// <param name="keyName"> Registry Key Name </param>                                                       ///
        /// <param name="assemblyLocation"> Assembly location </param>                                              ///
        ///                                 (e.g. Assembly.GetExecutingAssembly().Location)                         ///
        ///=========================================================================================================///
        public static bool IsAutoStartEnabled(string keyName, string assemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);

            if (key == null) return false;

            string value = "";

            try
            {
                value = (string)key.GetValue(keyName);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.IsAutoStartEnabled ]");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(keyName) == true)
                    MessageBuilder.AppendLine("▶ keyName : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ keyName : " + keyName);
                
                if (string.IsNullOrEmpty(assemblyLocation) == true)
                    MessageBuilder.AppendLine("▶ assemblyLocation : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ assemblyLocation : " + assemblyLocation);

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            if (value == null) return false;

            return (value == assemblyLocation);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ UnSetAutoStart @                                                                                      ///
        ///     레지스트리에 등록된 항목 중 매개변수의 값과 동일한 항목을 삭제한다.                                 ///
        /// </summary>                                                                                              ///
        /// <param name="keyName"> Registry Key Name </param>                                                       ///
        ///=========================================================================================================///
        public static void UnSetAutoStart(string keyName)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
                key.DeleteValue(keyName);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.UnSetAutoStart ]");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(keyName) == true)
                    MessageBuilder.AppendLine("▶ keyName : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ keyName : " + keyName);

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ Hex2Str16 @                                                                                           ///
        ///     매개변수로 전달된 byte형 배열 데이터를 주어진 길이 만큼 16진수 문자열로 변환하여 반환한다.          ///
        /// </summary>                                                                                              ///
        /// <param name="command"> byte[] : 변환 대상 </param>                                                      ///
        /// <param name="packet_len"> int : 변환할 길이 </param>                                                    ///
        /// <returns> string : 16진수 문자열 </returns>                                                             ///
        ///=========================================================================================================///
        public static string Hex2Str16(byte[] command, int packet_len)
        {
            string hexstr = "";
            string str = "";

            try
            {
                for (int i = 0; i < packet_len; i++)
                {
                    str = command[i].ToString("X2");

                    hexstr += str;

                    if (i < (packet_len - 1)) hexstr += " ";
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.Hex2Str16 ]");
                MessageBuilder.AppendLine();

                if (command == null)
                    MessageBuilder.AppendLine("▶ command  : NULL");
                else
                {
                    MessageBuilder.Append("▶ command  : ");

                    foreach (byte b in command)
                        MessageBuilder.Append(Convert.ToChar(b).ToString() + " ");

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# packet_len : " + packet_len.ToString());
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return hexstr;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ Hex2Str16 @                                                                                           ///
        ///     매개변수로 전달된 byte형 배열 데이터를 16진수 문자열로 변환하여 반환한다.                           ///
        ///     배열 내의 시작 지점과 길이를 지정할 수 있다.                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="command"> byte[] : 변환 대상 </param>                                                      ///
        /// <param name="start"> int : 변환 시작 지점 </param>                                                      ///
        /// <param name="packet_len"> int : 변환할 길이 </param>                                                    ///
        /// <returns> string : 16진수 문자열 </returns>                                                             ///
        ///=========================================================================================================///
        public static string Hex2Str16(byte[] command, int start, int packet_len)
        {
            string hexstr = "";
            string str = "";

            try
            {
                for (int i = 0; i < packet_len; i++)
                {
                    str = command[start + i].ToString("X2");

                    hexstr += str;

                    if (i < (packet_len - 1)) hexstr += " ";
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.Hex2Str16 ]");
                MessageBuilder.AppendLine();

                if (command == null)
                    MessageBuilder.AppendLine("▶ command  : NULL");
                else
                {
                    MessageBuilder.Append("▶ command  : ");

                    foreach (byte b in command)
                        MessageBuilder.Append(Convert.ToChar(b).ToString() + " ");

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine("▶ start    : " + start);
                MessageBuilder.AppendLine("▶ packet_len : " + packet_len.ToString());
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return hexstr;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ Hex2Str16 @                                                                                           ///
        ///     매개변수로 전달된 byte형 데이터를 16진수 문자열로 변환하여 반환한다.                                ///
        /// </summary>                                                                                              ///
        /// <param name="command"> byte : 변환 대상 </param>                                                        ///
        /// <returns> string : 16진수 문자열 </returns>                                                             ///
        ///=========================================================================================================///
        public static string Hex2Str16(byte command)
        {
            string hexstr = "";

            try
            {
                hexstr = command.ToString("X2");
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.Hex2Str16 ]");
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine("▶ command  : " + Convert.ToChar(command).ToString());
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return hexstr;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ PaddingZero @                                                                                         ///
        ///     매개변수로 전달된 문자열에 지정된 길이 만큼 문자열 앞에 '0'을 덧붙인다.                             ///
        /// </summary>                                                                                              ///
        /// <param name="str"> string : 16진수 문자열 </param>                                                      ///
        /// <param name="packet_len"> int : 문자열 길이 </param>                                                    ///
        /// <returns> string : 처리된 문자열 </returns>                                                             ///
        ///=========================================================================================================///
        public static string PaddingZero(string str, int packet_len)
        {
            try
            {
                int len = packet_len - str.Length;

                for (int i = 0; i < len; i++)
                    str = "0" + str;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.PaddingZero ]");
                MessageBuilder.AppendLine();
                                
                if (string.IsNullOrEmpty(str) == true)
                    MessageBuilder.AppendLine("▶ str      : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ str      : " + str);

                MessageBuilder.AppendLine("▶ packet_len : " + packet_len);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return str;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ HexStringToByteArray @                                                                                ///
        ///     매개변수로 전달된 16진수 문자열을 byte형 배열로 변환하여 반환한다.                                  ///
        /// </summary>                                                                                              ///
        /// <param name="s"> string : 16진수 문자열 </param>                                                        ///
        /// <returns> byte[] : 변환된 byte형 배열 </returns>                                                        ///
        ///=========================================================================================================///
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");

            byte[] buffer = new byte[s.Length / 2];

            try
            {
                for (int i = 0; i < s.Length; i += 2)

                    buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.HexStringToByteArray ]");
                MessageBuilder.AppendLine();
                                
                if (string.IsNullOrEmpty(s) == true)
                    MessageBuilder.AppendLine("▶ string   : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ string   : " + s);

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return buffer;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ SendMail @                                                                                            ///
        ///     SMTP를 이용하여 메일을 전송한다.                                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="SMTPaddress"> string : SMTP 서버 주소 </param>                                             ///
        /// <param name="SMTPid"> string : SMTP 서버 접속 ID </param>                                               ///
        /// <param name="SMTPpass"> string : SMTP 서버 접속 암호 </param>                                           ///
        /// <param name="senderID"> string : 보내는 사람 ID </param>                                                ///
        /// <param name="senderNAME"> string : 보내는 사람 표시 이름 </param>                                       ///
        /// <param name="Tmail"> string[] : 받는 사람 메일 주소 </param>                                            ///
        /// <param name="TCC"> string[] : 참조 메일 주소 </param>                                                   ///
        /// <param name="Tsub"> string : 제목 </param>                                                              ///
        /// <param name="Tbody"> string : 본문 </param>                                                             ///
        /// <param name="AttachFiles"> string[] : 첨부 파일 </param>                                                ///
        /// <returns> bool : 메일 전송 여부 </returns>                                                              ///
        ///=========================================================================================================///
        public static bool SendMail(string SMTPaddress, string SMTPid, string SMTPpass, string senderID, 
            string senderNAME, string[] Tmail, string[] TCC, string Tsub, string Tbody, string[] AttachFiles)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(SMTPaddress);
                mail.From = new MailAddress(senderID, senderNAME, System.Text.Encoding.UTF8);

                foreach (string recv in Tmail)
                    mail.To.Add(new MailAddress(recv));

                foreach (string rcc in TCC)
                    mail.CC.Add(new MailAddress(rcc));

                mail.Subject = Tsub;
                mail.Body = Tbody; 
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                foreach (string FileName in AttachFiles)
                {
                    Attachment attachment;
                    attachment = new Attachment(FileName);
                    mail.Attachments.Add(attachment);
                }

                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential(SMTPid, SMTPpass);

                //SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                mail.Dispose();

                return true;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.SendMail ]");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(SMTPaddress) == true)
                    MessageBuilder.AppendLine("▶ SMTPaddress : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ SMTPaddress : " + SMTPaddress);

                if (string.IsNullOrEmpty(SMTPid) == true)
                    MessageBuilder.AppendLine("▶ SMTPid   : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ SMTPid   : " + SMTPid);

                if (string.IsNullOrEmpty(SMTPpass) == true)
                    MessageBuilder.AppendLine("▶ SMTPpass : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ SMTPpass : " + SMTPpass);

                if (string.IsNullOrEmpty(senderID) == true)
                    MessageBuilder.AppendLine("▶ senderID : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ senderID : " + senderID);

                if (string.IsNullOrEmpty(senderNAME) == true)
                    MessageBuilder.AppendLine("▶ senderNAME : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ senderNAME : " + senderNAME);

                if (Tmail.Length < 1)
                    MessageBuilder.AppendLine("▶ Tmail    : EMPTY");
                else
                    MessageBuilder.AppendLine("▶ Tmail    : " + Tmail.Length);

                if (TCC.Length < 1)
                    MessageBuilder.AppendLine("▶ TCC      : EMPTY");
                else
                    MessageBuilder.AppendLine("▶ TCC      : " + TCC.Length);

                if (string.IsNullOrEmpty(Tsub) == true)
                    MessageBuilder.AppendLine("▶ Tsub     : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ Tsub     : " + Tsub);

                if (string.IsNullOrEmpty(Tbody) == true)
                    MessageBuilder.AppendLine("▶ Tbody    : NULL / EMPTY");
                else
                    MessageBuilder.AppendLine("▶ Tbody    : " + Tbody);

                MessageBuilder.AppendLine("▶ AttachFiles");

                foreach (string file in AttachFiles)
                {
                    if (string.IsNullOrEmpty(file) == true)
                        MessageBuilder.AppendLine(" - NULL / EMPTY");
                    else
                        MessageBuilder.AppendLine(" - " + file);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ SetCRC16 @                                                                                            ///
        ///     매개변수로 주어진 프로토콜 패킷의 CRC를 계산하여 적용한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 </param>                                                   ///
        /// <param name="etx_len"> int : ETX 길이 </param>                                                          ///
        ///=========================================================================================================///
        static public void SetCRC16(byte[] packet, int etx_len)
        {
            try
            {
                UInt16 crc = CRC16(packet, Convert.ToByte(packet.Length - (2 + etx_len)));

                string tmp = Convert.ToString(crc, 16);
                tmp = PaddingZero(tmp, 4);

                byte[] calc = HexStringToByteArray(tmp);

                packet[packet.Length - (2 + etx_len)] = calc[1];
                packet[packet.Length - (1 + etx_len)] = calc[0];
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.SetCRC16 ]");
                MessageBuilder.AppendLine();

                if (packet == null)
                    MessageBuilder.AppendLine("▶ packet   : NULL");
                else
                {
                    MessageBuilder.AppendLine("▶ packet   : ");

                    foreach (byte b in packet)
                        MessageBuilder.Append(b.ToString("X2") + " ");

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine("▶ etx_len  : " + etx_len);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ CRC16 @                                                                                               ///
        ///     CRC 값을 계산하여 결과를 반환한다.                                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="ptr"> byte[] : CRC 계산 대상 </param>                                                      ///
        /// <param name="n"> byte : CRC 계산 범위 </param>                                                          ///
        /// <returns> UInt16 : CRC 값 </returns>                                                                    ///
        ///=========================================================================================================///
        static public UInt16 CRC16(byte[] ptr, byte n)
        {
            byte[] tmp = ptr;
            UInt16 crct = 0xFFFF;
            UInt16 uitmp;
            byte uctmp;

            for (uitmp = 0; uitmp < n; uitmp++)
            {
                crct = (UInt16)((crct & 0xFF00) | (crct ^ (UInt16)(tmp[uitmp])));

                for (uctmp = 0; uctmp < 8; uctmp++)
                {
                    if ((crct & 0x0001) > 0)
                        crct = (UInt16)((crct >> 1) ^ 0xA001);
                    else
                        crct >>= 1;
                }
            }

            return crct;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-31 ] ///
        /// @ CheckingCRC16 @                                                                                       ///
        ///     매개변수로 주어진 프로토콜 패킷의 CRC 값이 정확한 값인지 확인하여 결과를 반환한다.                  ///
        /// </summary>                                                                                              ///
        /// <param name="packet">프로토콜 패킷</param>                                                              ///
        /// <returns>CRC 정상 여부</returns>                                                                        ///
        ///=========================================================================================================///
        /*static public bool CheckingCRC16(byte[] packet)
        {
            byte[] tmp = new byte[2];
            tmp[0] = packet[packet.Length - 3];
            tmp[1] = packet[packet.Length - 2];

            int crc1 = BitConverter.ToInt16(tmp, 0);

            SetCRC16(packet, packet.Length);

            tmp[0] = packet[packet.Length - 3];
            tmp[1] = packet[packet.Length - 2];

            int crc2 = BitConverter.ToInt16(tmp, 0);

            if (crc1 == crc2) return true;
            else return false;
        }*/
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-05-22 ] ///
        /// @ CheckingCRC16 @                                                                                       ///
        ///     매개변수로 주어진 프로토콜 패킷의 CRC 값이 정확한 값인지 확인하여 결과를 반환한다.                  ///
        ///     패킷 길이는 CRC 이전 까지의 패킷 데이터를 포함한다.                                                 ///
        ///                                                                                                         ///
        /// [ Ver 1.01 ]                                                                                            ///
        ///     ▶ ETX 길이를 가변적으로 적용                                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷</param>                                                    ///
        /// <param name="etx_len"> int : ETX 길이</param>                                                           ///
        /// <returns> bool : CRC 정상 여부</returns>                                                                ///
        ///=========================================================================================================///
        static public bool CheckingCRC16(byte[] packet, int etx_len)
        {
            byte[] tmp = new byte[2];
            tmp[0] = packet[packet.Length - (etx_len + 2)];
            tmp[1] = packet[packet.Length - (etx_len + 1)];

            int crc1 = BitConverter.ToInt16(tmp, 0);

            SetCRC16(packet, etx_len);

            tmp[0] = packet[packet.Length - (etx_len + 2)];
            tmp[1] = packet[packet.Length - (etx_len + 1)];

            int crc2 = BitConverter.ToInt16(tmp, 0);

            if (crc1 == crc2) return true;
            else return false;
        }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2016-11-23 ] ///
        /// @ CRC16_CCITT (Kermit) @                                                                                ///
        ///     CRC 값을 계산하여 결과를 반환한다.                                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="data"> byte[] : CRC 계산 대상</param>                                                      ///
        /// <param name="len"> int : CRC 계산 범위</param>                                                          ///
        /// <returns> UInt16 : CRC 계산 결과 </returns>                                                             ///
        ///=========================================================================================================///
        static public UInt16 CRC16_CCITT(byte[] data, int len)
        {
            int i;
            UInt16 acc = 0;

            for (i = 1; i < len; ++i)
            {
                acc ^= data[i];
                acc = (UInt16)((acc >> 8) | (acc << 8));
                acc ^= (UInt16)((acc & 0xff00) << 4);
                acc ^= (UInt16)((acc >> 8) >> 4);
                acc ^= (UInt16)((acc & 0xff00) >> 5);
            }

            return acc;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2016-11-23 ] ///
        /// @ SetCRC16_CCITT (Kermit) @                                                                             ///
        ///     매개변수로 주어진 프로토콜 패킷의 CRC를 계산하여 적용한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 </param>                                                   ///
        /// <param name="etx_len"> int : ETX 길이 </param>                                                          ///
        ///=========================================================================================================///
        static public void SetCRC16_CCITT(byte[] packet, int etx_len)
        {
            try
            {
                UInt16 crc = CRC16_CCITT(packet, Convert.ToByte(packet.Length - (2 + etx_len)));

                string tmp = Convert.ToString(crc, 16);
                tmp = PaddingZero(tmp, 4);

                byte[] calc = HexStringToByteArray(tmp);

                packet[packet.Length - (2 + etx_len)] = calc[1];
                packet[packet.Length - (1 + etx_len)] = calc[0];
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.SetCRC16_CCITT ]");
                MessageBuilder.AppendLine();

                if (packet == null)
                    MessageBuilder.AppendLine("▶ packet   : NULL");
                else
                {
                    MessageBuilder.AppendLine("▶ packet   : ");

                    foreach (byte b in packet)
                        MessageBuilder.Append(b.ToString("X2") + " ");

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine("▶ etx_len  : " + etx_len);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2016-11-23 ] ///
        /// @ CheckingCRC16_CCITT (Kermit) @                                                                        ///
        ///     매개변수로 주어진 프로토콜 패킷의 CRC 값이 정확한 값인지 확인하여 결과를 반환한다.                  ///
        ///     패킷 길이는 CRC 이전 까지의 패킷 데이터를 포함한다.                                                 ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 </param>                                                   ///
        /// <param name="etx_len"> int : ETX 길이 </param>                                                          ///
        /// <returns> bool : CRC 정상 여부 </returns>                                                               ///
        ///=========================================================================================================///
        static public bool CheckingCRC16_CCITT(byte[] packet, int etx_len)
        {
            byte[] tmp = new byte[2];
            tmp[0] = packet[packet.Length - (etx_len + 2)];
            tmp[1] = packet[packet.Length - (etx_len + 1)];

            int crc1 = BitConverter.ToInt16(tmp, 0);

            SetCRC16_CCITT(packet, etx_len);

            tmp[0] = packet[packet.Length - (etx_len + 2)];
            tmp[1] = packet[packet.Length - (etx_len + 1)];

            int crc2 = BitConverter.ToInt16(tmp, 0);

            if (crc1 == crc2) return true;
            else return false;
        }
        #endregion

        #region [ # Ver 1.03 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2018-03-26 ] ///
        /// @ DupleClean @                                                                                          ///
        ///     매개변수로 전달한 동일한 이름의 프로세스 중 전달된 PID와 다른 모든 프로세스를 종료한다.             ///
        /// </summary>                                                                                              ///
        /// <param name="procname"> string : 소프트웨어 실행 파일 이름 </param>                                     ///
        /// <param name="PID"> int : 종료 제외 프로세스 ID </param>                                                 ///
        /// <returns> bool : 프로세스 종료 여부 </returns>                                                          ///
        ///=========================================================================================================///
        public static bool DupleClean(string procname, int PID)
        {
            bool result = false;

            try
            {
                Process[] info = Process.GetProcessesByName(procname);

                for (int i = 0; i < info.Length; i++)
                {
                    if (info[i].Id != PID)
                    {
                        info[i].Kill();
                    }
                }

                info = Process.GetProcessesByName(procname);

                if (info.Length == 1)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CommonBase.DupleClean ]");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(procname) == true)
                {
                    MessageBuilder.AppendLine("▶ procname : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ procname : " + procname);
                }

                MessageBuilder.AppendLine("▶ PID      : " + PID);

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return result;
        }
        #endregion

        #region [ # Ver 1.04 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2018-07-09 ] ///
        /// @ GetResourceManager @                                                                                  ///
        ///     APCL 라이브러리의 리소스 매니저를 반환한다.                                                         ///
        /// </summary>                                                                                              ///
        /// <returns> ResourceManager : APCL 라이브러리 리소스 매니저 </returns>                                    ///
        ///=========================================================================================================///
        static public ResourceManager GetResourceManager()
        {
            return Resources.ResourceManager;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2018-07-09 ] ///
        /// @ GetSensorType @                                                                                       ///
        ///     매개변수의 값에 해당하는 센서 타입 정의를 반환한다.                                                 ///
        /// </summary>                                                                                              ///
        /// <param name="key"> byte : 센서 타입 조회 값 </param>                                                    ///
        /// <returns> string : 센서 타입 정보 </returns>                                                            ///
        ///=========================================================================================================///
        static public string GetSensorType(byte key)
        {
            string type;

            if (SensorTypes.ContainsKey(key) == true)
            {
                type = SensorTypes[key];
            }
            else
            {
                type = "Not Exist";
            }

            return type;
        }
        #endregion

        #region [ # Working... ]
        ///=========================================================================================================///
        /// <summary>
        /// 
        /// </summary>
        ///=========================================================================================================///
        public static void PrintDocument()
        {
            PrintDocument docToPrint = new PrintDocument();

            PageSettings ps = new PageSettings();
            ps.Margins = new Margins(10, 10, 10, 10);

            docToPrint.DefaultPageSettings = ps;
            docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);

            //PrintPreviewDialog pd = new PrintPreviewDialog();
            //pd.ClientSize = new Size(500, 500);
            //pd.UseAntiAlias = true;

            PrintDialog pd = new PrintDialog();
            pd.Document = docToPrint;

            if (pd.ShowDialog() == DialogResult.OK)
            {
                docToPrint.Print();
            }
        }

        ///=========================================================================================================///
        /// <summary>
        /// @ docToPrint_PrintPage @                                                                                ///
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///=========================================================================================================///
        private static void docToPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            String line = null;

            Font printFont = new Font("Arial", 10);
            StreamReader streamToPrint = new StreamReader(Print_File_Doc);

            // Calculate the number of lines per page.
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);

            // Iterate over the file, printing each line.
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        public static string Print_File_Doc = @"F:\171025_일일업무일지(김건우).pdf";// string.Empty;
        public static string Print_File_Img = @"F:\20161115_104323.png";// string.Empty;

        ///=========================================================================================================///
        /// <summary>
        /// 
        /// </summary>
        ///=========================================================================================================///
        public static void PrintImage()
        {
            PrintDocument imgToPrint = new PrintDocument();

            PageSettings ps = new PageSettings();
            ps.Margins = new Margins(10, 10, 10, 10);

            imgToPrint.DefaultPageSettings = ps;

            PrintPreviewDialog pd = new PrintPreviewDialog();
            pd.ClientSize = new Size(500, 500);
            pd.UseAntiAlias = true;

            imgToPrint.PrintPage += new PrintPageEventHandler(imgToPrint_PrintPage);

            pd.Document = imgToPrint;
            pd.Show();
        }

        ///=========================================================================================================///
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///=========================================================================================================///
        private static void imgToPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image img = Image.FromFile(Print_File_Img);
            e.Graphics.DrawImage(img, 0, 0, 500, 500);
        }
        #endregion
    }
    ///================================================================================= End of Class : CommonBase =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-04-10 ] ///
    /// ▷ Modbus ◁                                                                                                ///
    ///     모드버스 프로토콜 지원 클래스이다.                                                                      ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-10 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class Modbus
    {
        #region [ # Defines & Variables ]
        private SerialPort sp = new SerialPort();
        public string modbusStatus;
        #endregion

        #region [ # Constructor / Deconstructor ]
        public Modbus()
        {
        }
        ~Modbus()
        {
        }
        #endregion

        #region [ # Open / Close Procedures ]
        public bool Open(string portName, int baudRate, int databits, Parity parity, StopBits stopBits)
        {
            //Ensure port isn't already opened:
            if (!sp.IsOpen)
            {
                //Assign desired settings to the serial port:
                sp.PortName = portName;
                sp.BaudRate = baudRate;
                sp.DataBits = databits;
                sp.Parity = parity;
                sp.StopBits = stopBits;
                //These timeouts are default and cannot be editted through the class at this point:
                sp.ReadTimeout = 1000;
                sp.WriteTimeout = 1000;

                try
                {
                    sp.Open();
                }
                catch (Exception err)
                {
                    modbusStatus = "Error opening " + portName + ": " + err.Message;
                    return false;
                }
                modbusStatus = portName + " opened successfully";
                return true;
            }
            else
            {
                modbusStatus = portName + " already opened";
                return false;
            }
        }
        public bool Close()
        {
            //Ensure port is opened before attempting to close:
            if (sp.IsOpen)
            {
                try
                {
                    sp.Close();
                }
                catch (Exception err)
                {
                    modbusStatus = "Error closing " + sp.PortName + ": " + err.Message;
                    return false;
                }
                modbusStatus = sp.PortName + " closed successfully";
                return true;
            }
            else
            {
                modbusStatus = sp.PortName + " is not open";
                return false;
            }
        }
        #endregion

        #region [ # CRC Computation ]
        public void GetCRC(byte[] message, ref byte[] CRC)
        {
            //Function expects a modbus message of any length as well as a 2 byte CRC array in which to 
            //return the CRC values:

            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;

            for (int i = 0; i < (message.Length) - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ message[i]);

                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }

            CRC[1] = CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRC[0] = CRCLow = (byte)(CRCFull & 0xFF);
        }
        #endregion

        #region [ # Build Message ]
        private void BuildMessage(byte address, byte type, ushort start, ushort registers, ref byte[] message)
        {
            //Array to receive CRC bytes:
            byte[] CRC = new byte[2];

            message[0] = address;
            message[1] = type;
            message[2] = (byte)(start >> 8);
            message[3] = (byte)start;
            message[4] = (byte)(registers >> 8);
            message[5] = (byte)registers;

            GetCRC(message, ref CRC);
            message[message.Length - 2] = CRC[0];
            message[message.Length - 1] = CRC[1];
        }
        #endregion

        #region [ # Check Response ]
        private bool CheckResponse(byte[] response)
        {
            //Perform a basic CRC check:
            byte[] CRC = new byte[2];
            GetCRC(response, ref CRC);
            if (CRC[0] == response[response.Length - 2] && CRC[1] == response[response.Length - 1])
                return true;
            else
                return false;
        }
        #endregion

        #region [ # Get Response ]
        private void GetResponse(ref byte[] response)
        {
            //There is a bug in .Net 2.0 DataReceived Event that prevents people from using this
            //event as an interrupt to handle data (it doesn't fire all of the time).  Therefore
            //we have to use the ReadByte command for a fixed length as it's been shown to be reliable.
            for (int i = 0; i < response.Length; i++)
            {
                response[i] = (byte)(sp.ReadByte());
            }
        }
        #endregion

        #region [ # Function 16 - Write Multiple Registers ]
        public bool SendFc16(byte address, ushort start, ushort registers, short[] values)
        {
            //Ensure port is open:
            if (sp.IsOpen)
            {
                //Clear in/out buffers:
                sp.DiscardOutBuffer();
                sp.DiscardInBuffer();
                //Message is 1 addr + 1 fcn + 2 start + 2 reg + 1 count + 2 * reg vals + 2 CRC
                byte[] message = new byte[9 + 2 * registers];
                //Function 16 response is fixed at 8 bytes
                byte[] response = new byte[8];

                //Add bytecount to message:
                message[6] = (byte)(registers * 2);
                //Put write values into message prior to sending:
                for (int i = 0; i < registers; i++)
                {
                    message[7 + 2 * i] = (byte)(values[i] >> 8);
                    message[8 + 2 * i] = (byte)(values[i]);
                }
                //Build outgoing message:
                BuildMessage(address, (byte)16, start, registers, ref message);

                //Send Modbus message to Serial Port:
                try
                {
                    sp.Write(message, 0, message.Length);
                    GetResponse(ref response);
                }
                catch (Exception err)
                {
                    modbusStatus = "Error in write event: " + err.Message;
                    return false;
                }
                //Evaluate message:
                if (CheckResponse(response))
                {
                    modbusStatus = "Write successful";
                    return true;
                }
                else
                {
                    modbusStatus = "CRC error";
                    return false;
                }
            }
            else
            {
                modbusStatus = "Serial port not open";
                return false;
            }
        }
        #endregion

        #region [ # Function 3 - Read Registers ]
        public bool SendFc3(byte address, ushort start, ushort registers, ref short[] values)
        {
            //Ensure port is open:
            if (sp.IsOpen)
            {
                //Clear in/out buffers:
                sp.DiscardOutBuffer();
                sp.DiscardInBuffer();
                //Function 3 request is always 8 bytes:
                byte[] message = new byte[8];
                //Function 3 response buffer:
                byte[] response = new byte[5 + 2 * registers];
                //Build outgoing modbus message:
                BuildMessage(address, (byte)3, start, registers, ref message);
                //Send modbus message to Serial Port:
                try
                {
                    sp.Write(message, 0, message.Length);
                    GetResponse(ref response);
                }
                catch (Exception err)
                {
                    modbusStatus = "Error in read event: " + err.Message;
                    return false;
                }
                //Evaluate message:
                if (CheckResponse(response))
                {
                    //Return requested register values:
                    for (int i = 0; i < (response.Length - 5) / 2; i++)
                    {
                        values[i] = response[2 * i + 3];
                        values[i] <<= 8;
                        values[i] += response[2 * i + 4];
                    }
                    modbusStatus = "Read successful";
                    return true;
                }
                else
                {
                    modbusStatus = "CRC error";
                    return false;
                }
            }
            else
            {
                modbusStatus = "Serial port not open";
                return false;
            }

        }
        #endregion

        #region [ # Test Function ]
        public bool Send(byte[] message, ref short[] values)
        {
            //Ensure port is open:
            if (sp.IsOpen)
            {
                //Clear in/out buffers:
                sp.DiscardOutBuffer();
                sp.DiscardInBuffer();

                //Function 16 response is fixed at 8 bytes
                byte[] response = new byte[8];

                //Send modbus message to Serial Port:
                try
                {
                    sp.Write(message, 0, message.Length);
                    GetResponse(ref response);
                }
                catch (Exception err)
                {
                    modbusStatus = "Error in read event: " + err.Message;
                    return false;
                }
                //Evaluate message:
                if (CheckResponse(response))
                {
                    //Return requested register values:
                    for (int i = 0; i < (response.Length - 5) / 2; i++)
                    {
                        values[i] = response[2 * i + 3];
                        values[i] <<= 8;
                        values[i] += response[2 * i + 4];
                    }
                    modbusStatus = "Read successful";
                    return true;
                }
                else
                {
                    modbusStatus = "CRC error";
                    return false;
                }
            }
            else
            {
                modbusStatus = "Serial port not open";
                return false;
            }

        }
        #endregion
    }
    ///===================================================================================== End of Class : Modbus =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-03-28 ] ///
    /// ▷ OSInfo ◁                                                                                                ///
    ///     Provides detailed information about the host operating system.                                          ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-03-28 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    static public class OSInfo
    {
        #region [ # Defines & Variables ]
        const int OS_ANYSERVER = 29;

        [DllImport("shlwapi.dll", SetLastError = true, EntryPoint = "#437")]
        static extern bool IsOS(int os);

        static bool isWindowsServer = IsOS(OS_ANYSERVER);
        #endregion

        #region [ # BITS ]

        /// <summary>
        /// Determines if the current application is 32 or 64-bit.
        /// </summary>
        static public int Bits
        {
            get
            {
                return IntPtr.Size * 8;
            }
        }
        #endregion BITS

        #region [ # EDITION ]
        static private string s_Edition;
        /// <summary>
        /// Gets the edition of the operating system running on this computer.
        /// </summary>
        static public string Edition
        {
            get
            {
                if (s_Edition != null)
                    return s_Edition;  //***** RETURN *****//

                string edition = String.Empty;

                OperatingSystem osVersion = Environment.OSVersion;
                OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX();
                osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX));

                if (GetVersionEx(ref osVersionInfo))
                {
                    int majorVersion = osVersion.Version.Major;
                    int minorVersion = osVersion.Version.Minor;
                    byte productType = osVersionInfo.wProductType;
                    short suiteMask = osVersionInfo.wSuiteMask;

                    #region VERSION 4
                    if (majorVersion == 4)
                    {
                        if (productType == VER_NT_WORKSTATION)
                        {
                            // Windows NT 4.0 Workstation
                            edition = "Workstation";
                        }
                        else if (productType == VER_NT_SERVER)
                        {
                            if ((suiteMask & VER_SUITE_ENTERPRISE) != 0)
                            {
                                // Windows NT 4.0 Server Enterprise
                                edition = "Enterprise Server";
                            }
                            else
                            {
                                // Windows NT 4.0 Server
                                edition = "Standard Server";
                            }
                        }
                    }
                    #endregion VERSION 4

                    #region VERSION 5
                    else if (majorVersion == 5)
                    {
                        if (productType == VER_NT_WORKSTATION)
                        {
                            if ((suiteMask & VER_SUITE_PERSONAL) != 0)
                            {
                                // Windows XP Home Edition
                                edition = "Home";
                            }
                            else
                            {
                                // Windows XP / Windows 2000 Professional
                                edition = "Professional";
                            }
                        }
                        else if (productType == VER_NT_SERVER)
                        {
                            if (minorVersion == 0)
                            {
                                if ((suiteMask & VER_SUITE_DATACENTER) != 0)
                                {
                                    // Windows 2000 Datacenter Server
                                    edition = "Datacenter Server";
                                }
                                else if ((suiteMask & VER_SUITE_ENTERPRISE) != 0)
                                {
                                    // Windows 2000 Advanced Server
                                    edition = "Advanced Server";
                                }
                                else
                                {
                                    // Windows 2000 Server
                                    edition = "Server";
                                }
                            }
                            else
                            {
                                if ((suiteMask & VER_SUITE_DATACENTER) != 0)
                                {
                                    // Windows Server 2003 Datacenter Edition
                                    edition = "Datacenter";
                                }
                                else if ((suiteMask & VER_SUITE_ENTERPRISE) != 0)
                                {
                                    // Windows Server 2003 Enterprise Edition
                                    edition = "Enterprise";
                                }
                                else if ((suiteMask & VER_SUITE_BLADE) != 0)
                                {
                                    // Windows Server 2003 Web Edition
                                    edition = "Web Edition";
                                }
                                else
                                {
                                    // Windows Server 2003 Standard Edition
                                    edition = "Standard";
                                }
                            }
                        }
                    }
                    #endregion VERSION 5

                    #region VERSION 6
                    else if ((majorVersion == 6) || (majorVersion == 10))
                    {
                        int ed;
                        if (GetProductInfo(majorVersion, minorVersion,
                            osVersionInfo.wServicePackMajor, osVersionInfo.wServicePackMinor,
                            out ed))
                        {
                            switch (ed)
                            {
                                case PRODUCT_BUSINESS:
                                    edition = "Business";
                                    break;
                                case PRODUCT_BUSINESS_N:
                                    edition = "Business N";
                                    break;
                                case PRODUCT_CLUSTER_SERVER:
                                    edition = "HPC Edition";
                                    break;
                                case PRODUCT_CLUSTER_SERVER_V:
                                    edition = "Server Hyper Core V";
                                    break;
                                case PRODUCT_CORE:
                                    edition = "Windows 10 Home";
                                    break;
                                case PRODUCT_CORE_COUNTRYSPECIFIC:
                                    edition = "Windows 10 Home China";
                                    break;
                                case PRODUCT_CORE_N:
                                    edition = "Windows 10 Home N";
                                    break;
                                case PRODUCT_CORE_SINGLELANGUAGE:
                                    edition = "Windows 10 Home Single Language";
                                    break;
                                case PRODUCT_DATACENTER_EVALUATION_SERVER:
                                    edition = "Server Datacenter (evaluation installation)";
                                    break;
                                case PRODUCT_DATACENTER_SERVER:
                                    edition = "Datacenter Server (full installation)";
                                    break;
                                case PRODUCT_DATACENTER_SERVER_CORE:
                                    edition = "Datacenter Server (core installation)";
                                    break;
                                case PRODUCT_DATACENTER_SERVER_CORE_V:
                                    edition = "Server Datacenter without Hyper-V (core installation)";
                                    break;
                                case PRODUCT_DATACENTER_SERVER_V:
                                    edition = "Server Datacenter without Hyper-V (full installation)";
                                    break;
                                case PRODUCT_EDUCATION:
                                    edition = "Education";
                                    break;
                                case PRODUCT_EDUCATION_N:
                                    edition = "Education N";
                                    break;
                                case PRODUCT_ENTERPRISE:
                                    edition = "Enterprise";
                                    break;
                                case PRODUCT_ENTERPRISE_E:
                                    edition = "Enterprise E";
                                    break;
                                case PRODUCT_ENTERPRISE_EVALUATION:
                                    edition = "Enterprise Evaluation";
                                    break;
                                case PRODUCT_ENTERPRISE_N:
                                    edition = "Enterprise N";
                                    break;
                                case PRODUCT_ENTERPRISE_N_EVALUATION:
                                    edition = "Enterprise N Evaluation";
                                    break;
                                case PRODUCT_ENTERPRISE_S:
                                    edition = "Enterprise 2015 LTSB";
                                    break;
                                case PRODUCT_ENTERPRISE_S_EVALUATION:
                                    edition = "Enterprise 2015 LTSB Evaluation";
                                    break;
                                case PRODUCT_ENTERPRISE_S_N:
                                    edition = "Enterprise 2015 LTSB N";
                                    break;
                                case PRODUCT_ENTERPRISE_S_N_EVALUATION:
                                    edition = "Enterprise 2015 LTSB N Evaluation";
                                    break;
                                case PRODUCT_ENTERPRISE_SERVER:
                                    edition = "Enterprise Server (full installation)";
                                    break;
                                case PRODUCT_ENTERPRISE_SERVER_CORE:
                                    edition = "Enterprise Server (core installation)";
                                    break;
                                case PRODUCT_ENTERPRISE_SERVER_CORE_V:
                                    edition = "Enterprise Server without Hyper-V (core installation)";
                                    break;
                                case PRODUCT_ENTERPRISE_SERVER_IA64:
                                    edition = "Enterprise Server for Itanium-based Systems";
                                    break;
                                case PRODUCT_ENTERPRISE_SERVER_V:
                                    edition = "Enterprise Server without Hyper-V (full installation)";
                                    break;
                                case PRODUCT_ESSENTIALBUSINESS_SERVER_ADDL:
                                    edition = "Essential Server Solution Additional";
                                    break;
                                case PRODUCT_ESSENTIALBUSINESS_SERVER_ADDLSVC:
                                    edition = "Essential Server Solution Additional SVC";
                                    break;
                                case PRODUCT_ESSENTIALBUSINESS_SERVER_MGMT:
                                    edition = "Essential Server Solution Management";
                                    break;
                                case PRODUCT_ESSENTIALBUSINESS_SERVER_MGMTSVC:
                                    edition = "Essential Server Solution Management SVC";
                                    break;
                                case PRODUCT_HOME_BASIC:
                                    edition = "Home Basic";
                                    break;
                                case PRODUCT_HOME_BASIC_E:
                                    edition = "Not supported";
                                    break;
                                case PRODUCT_HOME_BASIC_N:
                                    edition = "Home Basic N";
                                    break;
                                case PRODUCT_HOME_PREMIUM:
                                    edition = "Home Premium";
                                    break;
                                case PRODUCT_HOME_PREMIUM_E:
                                    edition = "Not supported";
                                    break;
                                case PRODUCT_HOME_PREMIUM_N:
                                    edition = "Home Premium N";
                                    break;
                                case PRODUCT_HOME_PREMIUM_SERVER:
                                    edition = "Home Server 2011";
                                    break;
                                case PRODUCT_HOME_SERVER:
                                    edition = "Storage Server 2008 R2 Essentials";
                                    break;
                                case PRODUCT_HYPERV:
                                    edition = "Microsoft Hyper-V Server";
                                    break;
                                case PRODUCT_IOTUAP:
                                    edition = "Windows 10 IoT Core";
                                    break;
                                case PRODUCT_IOTUAPCOMMERCIAL:
                                    edition = "Windows 10 IoT Core Commercial";
                                    break;
                                case PRODUCT_MEDIUMBUSINESS_SERVER_MANAGEMENT:
                                    edition = "Windows Essential Business Management Server";
                                    break;
                                case PRODUCT_MEDIUMBUSINESS_SERVER_MESSAGING:
                                    edition = "Windows Essential Business Messaging Server";
                                    break;
                                case PRODUCT_MEDIUMBUSINESS_SERVER_SECURITY:
                                    edition = "Windows Essential Business Security Server";
                                    break;
                                case PRODUCT_MOBILE_CORE:
                                    edition = "Windows 10 Mobile";
                                    break;
                                case PRODUCT_MOBILE_ENTERPRISE:
                                    edition = "Windows 10 Mobile Enterprise";
                                    break;
                                case PRODUCT_MULTIPOINT_PREMIUM_SERVER:
                                    edition = "MultiPoint Server Premium (full installation)";
                                    break;
                                case PRODUCT_MULTIPOINT_STANDARD_SERVER:
                                    edition = "MultiPoint Server Standard (full installation)";
                                    break;
                                case PRODUCT_PROFESSIONAL:
                                    edition = "Pro";
                                    break;
                                case PRODUCT_PROFESSIONAL_E:
                                    edition = "Not supported";
                                    break;
                                case PRODUCT_PROFESSIONAL_N:
                                    edition = "Pro N";
                                    break;
                                case PRODUCT_PROFESSIONAL_WMC:
                                    edition = "Professional with Media Center";
                                    break;
                                case PRODUCT_SB_SOLUTION_SERVER:
                                    edition = "Small Business Server 2011 Essentials";
                                    break;
                                case PRODUCT_SB_SOLUTION_SERVER_EM:
                                    edition = "Server For SB Solutions EM";
                                    break;
                                case PRODUCT_SERVER_FOR_SB_SOLUTIONS:
                                    edition = "Server For SB Solutions";
                                    break;
                                case PRODUCT_SERVER_FOR_SB_SOLUTIONS_EM:
                                    edition = "Server For SB Solutions EM";
                                    break;
                                case PRODUCT_SERVER_FOR_SMALLBUSINESS:
                                    edition = "Server 2008 for Windows Essential Server Solutions";
                                    break;
                                case PRODUCT_SERVER_FOR_SMALLBUSINESS_V:
                                    edition = "Windows Essential Server Solutions without Hyper-V";
                                    break;
                                case PRODUCT_SERVER_FOUNDATION:
                                    edition = "Server Foundation";
                                    break;
                                case PRODUCT_SMALLBUSINESS_SERVER:
                                    edition = "Windows Small Business Server";
                                    break;
                                case PRODUCT_SMALLBUSINESS_SERVER_PREMIUM:
                                    edition = "Small Business Server Premium";
                                    break;
                                case PRODUCT_SMALLBUSINESS_SERVER_PREMIUM_CORE:
                                    edition = "Small Business Server Premium (core installation)";
                                    break;
                                case PRODUCT_SOLUTION_EMBEDDEDSERVER:
                                    edition = "Windows MultiPoint Server";
                                    break;
                                case PRODUCT_STANDARD_EVALUATION_SERVER:
                                    edition = "Server Standard (evaluation installation)";
                                    break;
                                case PRODUCT_STANDARD_SERVER:
                                    edition = "Standard Server";
                                    break;
                                case PRODUCT_STANDARD_SERVER_CORE:
                                    edition = "Standard Server (core installation)";
                                    break;
                                case PRODUCT_STANDARD_SERVER_CORE_V:
                                    edition = "Standard Server without Hyper-V (core installation)";
                                    break;
                                case PRODUCT_STANDARD_SERVER_V:
                                    edition = "Standard Server without Hyper-V";
                                    break;
                                case PRODUCT_STANDARD_SERVER_SOLUTIONS:
                                    edition = "Server Solutions Premium";
                                    break;
                                case PRODUCT_STANDARD_SERVER_SOLUTIONS_CORE:
                                    edition = "Server Solutions Premium (core installation)";
                                    break;
                                case PRODUCT_STARTER:
                                    edition = "Starter";
                                    break;
                                case PRODUCT_STARTER_E:
                                    edition = "Not supported";
                                    break;
                                case PRODUCT_STARTER_N:
                                    edition = "Starter N";
                                    break;
                                case PRODUCT_STORAGE_ENTERPRISE_SERVER:
                                    edition = "Storage Server Enterprise";
                                    break;
                                case PRODUCT_STORAGE_ENTERPRISE_SERVER_CORE:
                                    edition = "Storage Server Enterprise (core installation)";
                                    break;
                                case PRODUCT_STORAGE_EXPRESS_SERVER:
                                    edition = "Express Storage Server";
                                    break;
                                case PRODUCT_STORAGE_EXPRESS_SERVER_CORE:
                                    edition = "Storage Server Express (core installation)";
                                    break;
                                case PRODUCT_STORAGE_STANDARD_EVALUATION_SERVER:
                                    edition = "Storage Server Standard (evaluation installation)";
                                    break;
                                case PRODUCT_STORAGE_STANDARD_SERVER:
                                    edition = "Storage Server Standard";
                                    break;
                                case PRODUCT_STORAGE_WORKGROUP_EVALUATION_SERVER:
                                    edition = "Storage Server Workgroup (evaluation installation)";
                                    break;
                                case PRODUCT_STORAGE_WORKGROUP_SERVER:
                                    edition = "Storage Server Workgroup";
                                    break;
                                case PRODUCT_STORAGE_WORKGROUP_SERVER_CORE:
                                    edition = "Storage Server Workgroup (core installation)";
                                    break;
                                case PRODUCT_ULTIMATE:
                                    edition = "Ultimate";
                                    break;
                                case PRODUCT_ULTIMATE_E:
                                    edition = "Not supported";
                                    break;
                                case PRODUCT_ULTIMATE_N:
                                    edition = "Ultimate N";
                                    break;
                                case PRODUCT_UNDEFINED:
                                    edition = "Unknown product";
                                    break;
                                case PRODUCT_WEB_SERVER:
                                    edition = "Web Server (full installation)";
                                    break;
                                case PRODUCT_WEB_SERVER_CORE:
                                    edition = "Web Server (core installation)";
                                    break;
                            }
                        }
                    }
                    #endregion VERSION 6
                }

                s_Edition = edition;
                return edition;
            }
        }
        #endregion EDITION

        #region [ # NAME ]
        static private string s_Name;
        /// <summary>
        /// Gets the name of the operating system running on this computer.
        /// </summary>
        static public string Name
        {
            get
            {
                if (s_Name != null)
                    return s_Name;  //***** RETURN *****//

                string name = "unknown";

                OperatingSystem osVersion = Environment.OSVersion;
                OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX();
                osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX));

                if (GetVersionEx(ref osVersionInfo))
                {
                    int majorVersion = osVersion.Version.Major;
                    int minorVersion = osVersion.Version.Minor;

                    switch (osVersion.Platform)
                    {
                        case PlatformID.Win32Windows:
                            {
                                if (majorVersion == 4)
                                {
                                    string csdVersion = osVersionInfo.szCSDVersion;
                                    switch (minorVersion)
                                    {
                                        case 0:
                                            if (csdVersion == "B" || csdVersion == "C")
                                                name = "Windows 95 OSR2";
                                            else
                                                name = "Windows 95";
                                            break;
                                        case 10:
                                            if (csdVersion == "A")
                                                name = "Windows 98 Second Edition";
                                            else
                                                name = "Windows 98";
                                            break;
                                        case 90:
                                            name = "Windows Me";
                                            break;
                                    }
                                }
                                break;
                            }

                        case PlatformID.Win32NT:
                            {
                                byte productType = osVersionInfo.wProductType;

                                switch (majorVersion)
                                {
                                    case 3:
                                        name = "Windows NT 3.51";
                                        break;
                                    case 4:
                                        switch (productType)
                                        {
                                            case 1:
                                                name = "Windows NT 4.0";
                                                break;
                                            case 3:
                                                name = "Windows NT 4.0 Server";
                                                break;
                                        }
                                        break;
                                    case 5:
                                        switch (minorVersion)
                                        {
                                            case 0:
                                                name = "Windows 2000";
                                                break;
                                            case 1:
                                                name = "Windows XP";
                                                break;
                                            case 2:
                                                name = "Windows Server 2003";
                                                break;
                                        }
                                        break;
                                    case 6:
                                        switch (minorVersion)
                                        {
                                            case 0:
                                                if (productType == VER_NT_SERVER)
                                                    name = "Windows Server 2008";
                                                else
                                                    name = "Windows Vista";
                                                break;
                                            case 1:
                                                if (productType == VER_NT_SERVER)
                                                    name = "Windows Server 2008 R2";
                                                else
                                                    name = "Windows 7";
                                                break;
                                            case 2:
                                                if (productType == VER_NT_SERVER)
                                                    name = "Windows Server 2012";
                                                else
                                                    name = "Windows 8";
                                                break;
                                            case 3:
                                                if (productType == VER_NT_SERVER)
                                                    name = "Windows Server 2012 R2";
                                                else
                                                    name = "Windows 8.1";
                                                break;
                                        }
                                        break;
                                    case 10:
                                        switch (minorVersion)
                                        {
                                            case 0:
                                                if (productType == VER_NT_SERVER)
                                                    name = "Windows Server 2016";
                                                else
                                                    name = "Windows 10";
                                                break;
                                        }
                                        break;
                                }
                                break;
                            }
                    }
                }

                s_Name = name;
                return name;
            }
        }
        #endregion NAME

        #region [ # PINVOKE ]
        #region GET
        #region PRODUCT INFO
        [DllImport("Kernel32.dll")]
        internal static extern bool GetProductInfo(
            int osMajorVersion,
            int osMinorVersion,
            int spMajorVersion,
            int spMinorVersion,
            out int edition);
        #endregion PRODUCT INFO

        #region VERSION
        [DllImport("kernel32.dll")]
        private static extern bool GetVersionEx(ref OSVERSIONINFOEX osVersionInfo);
        #endregion VERSION
        #endregion GET

        #region OSVERSIONINFOEX
        [StructLayout(LayoutKind.Sequential)]
        private struct OSVERSIONINFOEX
        {
            public int dwOSVersionInfoSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szCSDVersion;
            public short wServicePackMajor;
            public short wServicePackMinor;
            public short wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }
        #endregion OSVERSIONINFOEX

        #region PRODUCT
        private const int PRODUCT_BUSINESS = 0x00000006;
        private const int PRODUCT_BUSINESS_N = 0x00000010;
        private const int PRODUCT_CLUSTER_SERVER = 0x00000012;
        private const int PRODUCT_CLUSTER_SERVER_V = 0x00000040;
        private const int PRODUCT_CORE = 0x00000065;
        private const int PRODUCT_CORE_COUNTRYSPECIFIC = 0x00000063;
        private const int PRODUCT_CORE_N = 0x00000062;
        private const int PRODUCT_CORE_SINGLELANGUAGE = 0x00000064;
        private const int PRODUCT_DATACENTER_EVALUATION_SERVER = 0x00000050;
        private const int PRODUCT_DATACENTER_SERVER = 0x00000008;
        private const int PRODUCT_DATACENTER_SERVER_CORE = 0x0000000C;
        private const int PRODUCT_DATACENTER_SERVER_CORE_V = 0x00000027;
        private const int PRODUCT_DATACENTER_SERVER_V = 0x00000025;
        private const int PRODUCT_EDUCATION = 0x00000079;
        private const int PRODUCT_EDUCATION_N = 0x0000007A;
        private const int PRODUCT_ENTERPRISE = 0x00000004;
        private const int PRODUCT_ENTERPRISE_E = 0x00000046;
        private const int PRODUCT_ENTERPRISE_EVALUATION = 0x00000048;
        private const int PRODUCT_ENTERPRISE_N = 0x0000001B;
        private const int PRODUCT_ENTERPRISE_N_EVALUATION = 0x00000054;
        private const int PRODUCT_ENTERPRISE_S = 0x0000007D;
        private const int PRODUCT_ENTERPRISE_S_EVALUATION = 0x00000081;
        private const int PRODUCT_ENTERPRISE_S_N = 0x0000007E;
        private const int PRODUCT_ENTERPRISE_S_N_EVALUATION = 0x00000082;
        private const int PRODUCT_ENTERPRISE_SERVER = 0x0000000A;
        private const int PRODUCT_ENTERPRISE_SERVER_CORE = 0x0000000E;
        private const int PRODUCT_ENTERPRISE_SERVER_CORE_V = 0x00000029;
        private const int PRODUCT_ENTERPRISE_SERVER_IA64 = 0x0000000F;
        private const int PRODUCT_ENTERPRISE_SERVER_V = 0x00000026;
        private const int PRODUCT_ESSENTIALBUSINESS_SERVER_ADDL = 0x0000003C;
        private const int PRODUCT_ESSENTIALBUSINESS_SERVER_ADDLSVC = 0x0000003E;
        private const int PRODUCT_ESSENTIALBUSINESS_SERVER_MGMT = 0x0000003B;
        private const int PRODUCT_ESSENTIALBUSINESS_SERVER_MGMTSVC = 0x0000003D;
        private const int PRODUCT_HOME_BASIC = 0x00000002;
        private const int PRODUCT_HOME_BASIC_E = 0x00000043;
        private const int PRODUCT_HOME_BASIC_N = 0x00000005;
        private const int PRODUCT_HOME_PREMIUM = 0x00000003;
        private const int PRODUCT_HOME_PREMIUM_E = 0x00000044;
        private const int PRODUCT_HOME_PREMIUM_N = 0x0000001A;
        private const int PRODUCT_HOME_PREMIUM_SERVER = 0x00000022;
        private const int PRODUCT_HOME_SERVER = 0x00000013;
        private const int PRODUCT_HYPERV = 0x0000002A;
        private const int PRODUCT_IOTUAP = 0x0000007B;
        private const int PRODUCT_IOTUAPCOMMERCIAL = 0x00000083;
        private const int PRODUCT_MEDIUMBUSINESS_SERVER_MANAGEMENT = 0x0000001E;
        private const int PRODUCT_MEDIUMBUSINESS_SERVER_MESSAGING = 0x00000020;
        private const int PRODUCT_MEDIUMBUSINESS_SERVER_SECURITY = 0x0000001F;
        private const int PRODUCT_MOBILE_CORE = 0x00000068;
        private const int PRODUCT_MOBILE_ENTERPRISE = 0x00000085;
        private const int PRODUCT_MULTIPOINT_PREMIUM_SERVER = 0x0000004D;
        private const int PRODUCT_MULTIPOINT_STANDARD_SERVER = 0x0000004C;
        private const int PRODUCT_PROFESSIONAL = 0x00000030;
        private const int PRODUCT_PROFESSIONAL_E = 0x00000045;
        private const int PRODUCT_PROFESSIONAL_N = 0x00000031;
        private const int PRODUCT_PROFESSIONAL_WMC = 0x00000067;
        private const int PRODUCT_SB_SOLUTION_SERVER = 0x00000032;
        private const int PRODUCT_SB_SOLUTION_SERVER_EM = 0x00000036;
        private const int PRODUCT_SERVER_FOR_SB_SOLUTIONS = 0x00000033;
        private const int PRODUCT_SERVER_FOR_SB_SOLUTIONS_EM = 0x00000037;
        private const int PRODUCT_SERVER_FOR_SMALLBUSINESS = 0x00000018;
        private const int PRODUCT_SERVER_FOR_SMALLBUSINESS_V = 0x00000023;
        private const int PRODUCT_SERVER_FOUNDATION = 0x00000021;
        private const int PRODUCT_SMALLBUSINESS_SERVER = 0x00000009;
        private const int PRODUCT_SMALLBUSINESS_SERVER_PREMIUM = 0x00000019;
        private const int PRODUCT_SMALLBUSINESS_SERVER_PREMIUM_CORE = 0x0000003F;
        private const int PRODUCT_SOLUTION_EMBEDDEDSERVER = 0x00000038;
        private const int PRODUCT_STANDARD_EVALUATION_SERVER = 0x0000004F;
        private const int PRODUCT_STANDARD_SERVER = 0x00000007;
        private const int PRODUCT_STANDARD_SERVER_CORE = 0x0000000D;
        private const int PRODUCT_STANDARD_SERVER_CORE_V = 0x00000028;
        private const int PRODUCT_STANDARD_SERVER_V = 0x00000024;
        private const int PRODUCT_STANDARD_SERVER_SOLUTIONS = 0x00000034;
        private const int PRODUCT_STANDARD_SERVER_SOLUTIONS_CORE = 0x00000035;
        private const int PRODUCT_STARTER = 0x0000000B;
        private const int PRODUCT_STARTER_E = 0x00000042;
        private const int PRODUCT_STARTER_N = 0x0000002F;
        private const int PRODUCT_STORAGE_ENTERPRISE_SERVER = 0x00000017;
        private const int PRODUCT_STORAGE_ENTERPRISE_SERVER_CORE = 0x0000002E;
        private const int PRODUCT_STORAGE_EXPRESS_SERVER = 0x00000014;
        private const int PRODUCT_STORAGE_EXPRESS_SERVER_CORE = 0x0000002B;
        private const int PRODUCT_STORAGE_STANDARD_EVALUATION_SERVER = 0x00000060;
        private const int PRODUCT_STORAGE_STANDARD_SERVER = 0x00000015;
        private const int PRODUCT_STORAGE_STANDARD_SERVER_CORE = 0x0000002C;
        private const int PRODUCT_STORAGE_WORKGROUP_EVALUATION_SERVER = 0x0000005F;
        private const int PRODUCT_STORAGE_WORKGROUP_SERVER = 0x00000016;
        private const int PRODUCT_STORAGE_WORKGROUP_SERVER_CORE = 0x0000002D;
        private const int PRODUCT_ULTIMATE = 0x00000001;
        private const int PRODUCT_ULTIMATE_E = 0x00000047;
        private const int PRODUCT_ULTIMATE_N = 0x0000001C;
        private const int PRODUCT_UNDEFINED = 0x00000000;
        private const int PRODUCT_WEB_SERVER = 0x00000011;
        private const int PRODUCT_WEB_SERVER_CORE = 0x0000001D;
        #endregion PRODUCT

        #region VERSIONS
        private const int VER_NT_WORKSTATION = 1;
        private const int VER_NT_DOMAIN_CONTROLLER = 2;
        private const int VER_NT_SERVER = 3;
        private const int VER_SUITE_SMALLBUSINESS = 1;
        private const int VER_SUITE_ENTERPRISE = 2;
        private const int VER_SUITE_TERMINAL = 16;
        private const int VER_SUITE_DATACENTER = 128;
        private const int VER_SUITE_SINGLEUSERTS = 256;
        private const int VER_SUITE_PERSONAL = 512;
        private const int VER_SUITE_BLADE = 1024;
        #endregion VERSIONS
        #endregion PINVOKE

        #region [ # SERVICE PACK ]
        /// <summary>
        /// Gets the service pack information of the operating system running on this computer.
        /// </summary>
        static public string ServicePack
        {
            get
            {
                string servicePack = String.Empty;
                OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX();

                osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX));

                if (GetVersionEx(ref osVersionInfo))
                {
                    servicePack = osVersionInfo.szCSDVersion;
                }

                return servicePack;
            }
        }
        #endregion SERVICE PACK

        #region [ # VERSION ]
        #region BUILD
        /// <summary>
        /// Gets the build version number of the operating system running on this computer.
        /// </summary>
        static public int BuildVersion
        {
            get
            {
                return Environment.OSVersion.Version.Build;
            }
        }
        #endregion BUILD

        #region FULL
        #region STRING
        /// <summary>
        /// Gets the full version string of the operating system running on this computer.
        /// </summary>
        static public string VersionString
        {
            get
            {
                return Environment.OSVersion.Version.ToString();
            }
        }
        #endregion STRING

        #region VERSION
        /// <summary>
        /// Gets the full version of the operating system running on this computer.
        /// </summary>
        static public Version Version
        {
            get
            {
                return Environment.OSVersion.Version;
            }
        }
        #endregion VERSION
        #endregion FULL

        #region MAJOR
        /// <summary>
        /// Gets the major version number of the operating system running on this computer.
        /// </summary>
        static public int MajorVersion
        {
            get
            {
                return Environment.OSVersion.Version.Major;
            }
        }
        #endregion MAJOR

        #region MINOR
        /// <summary>
        /// Gets the minor version number of the operating system running on this computer.
        /// </summary>
        static public int MinorVersion
        {
            get
            {
                return Environment.OSVersion.Version.Minor;
            }
        }
        #endregion MINOR

        #region REVISION
        /// <summary>
        /// Gets the revision version number of the operating system running on this computer.
        /// </summary>
        static public int RevisionVersion
        {
            get
            {
                return Environment.OSVersion.Version.Revision;
            }
        }
        #endregion REVISION
        #endregion VERSION
    }
    ///===================================================================================== End of Class : OSInfo =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-03-28 ] ///
    /// ▷ PerformanceInfo ◁                                                                                       ///
    ///     로컬 시스템의 메모리 정보를 제공한다.                                                                   ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-03-28 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public static class PerformanceInfo
    {
        #region [ # Defines & Variables ]
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ GetPhysicalAvailableMemoryInMiB @                                                                     ///
        ///     로컬 시스템의 사용 가능 메모리 용량을 반환한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <returns> Int64 : 메모리 용량 </returns>                                                                ///
        ///=========================================================================================================///
        public static Int64 GetPhysicalAvailableMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
                return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ GetTotalMemoryInMiB @                                                                                 ///
        ///     로컬 시스템의 전체 메모리 용량을 반환한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <returns> Int64 : 메모리 용량 </returns>                                                                ///
        ///=========================================================================================================///
        public static Int64 GetTotalMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
                return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
    ///============================================================================ End of Class : PerformanceInfo =///

    #region [ # Data Sturcture ]
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2018-XX-XX ] ///
    /// ▷ GateInfo ◁                                                                                              ///
    ///     Gateway의 정보를 저장하는 구조체                                                                        ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2018-XX-XX ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public struct GateInfo
    {
        public int Idx;
        public string ID;
        public Point Location;
        public string Setup_X;
        public string Setup_Y;
        public string Power_Type;
        public string IP_Address;
        public string Port;
        public int State;
        public DateTime Last;
    }
    ///================================================================================== End of Struct : GateInfo =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2018-XX-XX ] ///
    /// ▷ BaseInfo ◁                                                                                              ///
    ///     Base Node의 정보를 저장하는 구조체                                                                      ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2018-XX-XX ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public struct BaseInfo
    {
        public int Idx;
        public int Gid;
        public string ID;
        public int Nodes;
        public int Channel;
        public int State;
        public DateTime Last;
    }
    ///================================================================================== End of Struct : BaseInfo =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2018-XX-XX ] ///
    /// ▷ NodeInfo ◁                                                                                              ///
    ///     Sensor Node의 정보를 저장하는 구조체                                                                    ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2018-XX-XX ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public struct NodeInfo
    {
        public int Bid;
        public int Tid;
        public int Idx;
        public string ID;
        public Point Location;
        public string Setup_X;
        public string Setup_Y;
        public string Power_Type;
        public int State;
        public DateTime Last;
        public int Alarms;
        public double Batt_Rate;
    }
    ///================================================================================== End of Struct : NodeInfo =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2018-XX-XX ] ///
    /// ▷ Alarms ◁                                                                                                ///
    ///     알람 정보를 저장하는 구조체                                                                             ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2018-XX-XX ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public struct Alarms
    {
        public int ID;
        public List<float[]> Levels;
    }
    ///==================================================================================== End of Struct : Alarms =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2018-XX-XX ] ///
    /// ▷ PumpInfo ◁                                                                                              ///
    ///     Pump 장비의 정보를 저장하는 구조체                                                                      ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2018-XX-XX ]                                                                                   ///
    ///     ▶ 초기버전 (For SK Hynix)                                                                              ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public struct TargetInfo
    {
        public int ID;
        public string Name;
        public string Type;
        public string Process;
        public string Gas;
        public string Maker;
        public string Model;
    }
    ///================================================================================== End of Struct : PumpInfo =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2018-XX-XX ] ///
    /// ▷ PacketTTag ◁                                                                                            ///
    ///     데이터 패킷과 수신 시간 정보 저장 구조체                                                                ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2018-XX-XX ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    ///=============================================================================================================///
    public struct PacketTTag
    {
        public byte[] packet;
        public DateTime TTag;
    }
    ///================================================================================== End of Struct : PumpInfo =///
    #endregion
}
