using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Apros_Class_Library_Base
{
    #region [ # Data Structure ]
    #region [ # Dynamic_Union ]
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2017-03-14 ] ///
    /// ▷ Dynamic_Union ◁                                                                                         ///
    ///     센서 데이터 처리용 구조체                                                                               ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    [StructLayout(LayoutKind.Explicit)]
    public struct Dynamic_Union
    {
        [FieldOffset(0)]    //메모리내 시작 위치
        public int data;
        [FieldOffset(0)]    //0에서 시작
        public byte d1;
        [FieldOffset(1)]    //1에서 시작
        public byte d2;
        [FieldOffset(2)]    //2에서 시작
        public byte d3;
        [FieldOffset(3)]    //3에서 시작
        public byte d4;
    }
    #endregion
    #endregion

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-04-23 ] ///
    /// ▷ Command_Manager : CommonVariables ◁                                                                     ///
    ///     프로토콜 클래스에서 공통적으로 사용할 변수를 선언한다.                                                  ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-23 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.10 / 2017-11-06 ]                                                                                   ///
    ///     ▶ TLV 형태 기반의 프로토콜 지원                                                                        ///
    /// [ Ver 1.11 / 2017-12-18 ]                                                                                   ///
    ///     ▶ 데이터 비트 수에 따른 연산 지원                                                                      ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class Command_Manager : CommonVariables
    {
        #region [ # Defines & Variables ]
        static public string Message = string.Empty;
        static public StringBuilder MessageBuilder;

        //static private DateTime LastParsing = new DateTime();

        // Old Ver. Packet Structure
        static public byte[] Packet;
        static public byte[] Data;
        static public byte[] Len_Pack = new byte[2];
        static public byte[] NodeID = new byte[2];

        static public readonly byte STX = 0x40;
        static public readonly byte ETX1 = 0x0A;
        static public readonly byte ETX2 = 0x0D;

        // TLV based Packet Structure
        static public List<byte> Buffer = new List<byte>();
        static public readonly byte ETX = 0x7D;

        static public readonly int BaseLength = 13;

        static public Dynamic_Union du;

        //
        static public bool use_milisec; 

        static private readonly int Len_ID = 8;
        static private readonly int Len_FV = 4;
        static private readonly int Len_VN = 16;

        // 2018.02.28 - MWC 출품용 Wifi 대응을 위해 1 -> 3 으로 변경
        static private int ByteUnit = 3;
        static private int Axis = 1;

        // 스마트센서-V 프로토콜
        static public string[] Commands = new string[] 
        {
            "Base Reset",        "Device Reset",  "Factory Reset",    "Get Base ID",      "Get Base Channel",   // 1
            "Set Base Channel",  "Get Node Info", "Get Node Channel", "Set Node Channel", "Register Node",      // 2
            "Get Sampling",      "Set Sampling",  "Capture",          "Data Fetch Ready", "Data Fetch Start",   // 3
            "Retransmit Packet", "Get Vendor",    "Set Vendor",       "Auto Offset",      "Get Offset",         // 4
            "Set Offset",        "Set Base CCA",  "Get Base CCA",     "Set Node CCA",     "Get Node CCA",       // 5
            "Report Period",     "Prompt Report", "Set Boundary",     "Get Boundary",     "Set DFetch Period",  // 6
            "Get DFetch Period" 
        };

        // 송수신 데이터 패킷 보관 버퍼
        //static private List<string> RawPackets = new List<string>();
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-20 ] ///
        /// @ Set_ByteUnit @                                                                                        ///
        ///     데이터 단위 바이트 수를 설정한다.                                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="val"> int : 설정 값 </param>                                                               ///
        /// <returns> int : 설정된 값 </returns>                                                                    ///
        ///=========================================================================================================///
        static public int Set_ByteUnit(int val)
        {
            ByteUnit = val;

            return ByteUnit;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-20 ] ///
        /// @ Set_Axis @                                                                                            ///
        ///     센서의 축 개수를 설정한다.                                                                          ///
        /// </summary>                                                                                              ///
        /// <param name="val"> int : 설정 값 </param>                                                               ///
        /// <returns> int : 설정된 값 </returns>                                                                    ///
        ///=========================================================================================================///
        static public int Set_Axis(int val)
        {
            Axis = val;

            return Axis;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2018-02-20 ] ///
        /// @ DumpRawPackets @                                                                                      ///
        ///     버퍼에 보관된 데이터를 파일로 저장하고 버퍼를 초기화한다.                                           ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        /*static public void DumpRawPackets()
        {
            if (RawPackets.Count > 0)
            {
                FileManager.SetFileExtension(".dat");
                FileManager.DataWriter(RawPackets.ToArray(), false, DataPath, "Serial", true, true, true, true, true, true);
                RawPackets.Clear();
            }
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-09-15 ] ///
        /// @ DisConnect @                                                                                          ///
        ///     연결 해제 알림용 패킷을 생성하여 반환한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <returns> byte[] : 연결 해제 알림 패킷 </returns>                                                       ///
        ///=========================================================================================================///
        static public byte[] DisConnect()
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(0);
            Packet[4] = Packet[3] = Convert.ToByte(0);
            Packet[5] = Packet[3] = Convert.ToByte(0);
            Packet[6] = (byte)'X';
            Packet[7] = (byte)'X';
            Packet[8] = (byte)'X';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }
        #endregion

        #region [ # Ver 1.10 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2017-11-06 ] ///
        /// @ PacketParsing @                                                                                       ///
        ///     프로토콜에 따라 패킷을 처리하여 결과를 반환한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 데이터 </param>                                            ///
        /// <returns> string : 처리 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        static public string PacketParsing(byte[] packet)
        {
            string result = string.Empty;

            if (packet != null)
            {
                try
                {
                    if (CommonBase.CheckingCRC16_CCITT(packet, 1) == true)
                    {
                        string pack = CommonBase.Hex2Str16(packet, packet.Length);

                        switch (packet[2])
                        {
                            case 0x00:
                                {
                                    result = ("Packet : " + pack) + Environment.NewLine + ParsingConversionData(packet);
                                }
                                break;
                            case 0x01:
                                {
                                    result = ("Packet : " + pack) + Environment.NewLine + ParsingControlData(packet);
                                }
                                break;
                            case 0x02:
                                {
                                    result = ("Packet : " + pack) + Environment.NewLine + ParsingRAWData(packet);
                                }
                                break;
                            default:
                                {
                                    result = "* Not Supported Protocol !!" + Environment.NewLine + ("Packet : " + pack);
                                    //pack = "▷ " + pack + " ◁";
                                }
                                break;
                        }

                        /*
                        RawPackets.Add(CommonBase.Hex2Str16(packet, packet.Length));

                        if (LastParsing.Year == 1)
                        {
                            LastParsing = DateTime.Now;
                        }

                        //if (RawPackets.Count > 100)
                        if (DateTime.Now.Subtract(LastParsing).TotalSeconds >= 1)
                        {
                            FileManager.SetFileExtension(".dat");
                            FileManager.DataWriter(RawPackets.ToArray(), false, DataPath, "Serial", true, true, true, true, true, true);
                            RawPackets.Clear();
                            LastParsing = DateTime.Now;
                        }*/
                    }
                    else
                    {
                        FileManager.LogWriter(CommonBase.Hex2Str16(packet, packet.Length), CommonBase.CRCPath, "CRC_Error", true, true, true, true, true);
                    }
                }
                catch (Exception ex)
                {
                    FileManager.LogWriter(ex.Message, ErrorPath, ErrorLogName, true, true, true, true, true);
                }
            }

            return result;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2017-11-06 ] ///
        /// @ GetTLVLength @                                                                                        ///
        ///     프로토콜 패킷 내부의 Payload의 세부 항목의 데이터 길이를 반환한다.                                  ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 데이터 </param>                                            ///
        /// <param name="idx"> int : Payload 세부 항목 위치 </param>                                                ///
        /// <returns> string : 처리 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        static private int GetTLVLength(byte[] packet, int idx)
        {
            return Convert.ToInt32(packet[idx]);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2017-11-06 ] ///
        /// @ ParsingConversionData @                                                                               ///
        ///     계측 데이터 패킷을 처리하여 결과를 반환한다.                                                        ///
        ///     ( * Conversion 데이터 - 센서 노드에서 환산 데이터를 전송 )                                          ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 데이터 </param>                                            ///
        /// <returns> string : 처리 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        static private string ParsingConversionData(byte[] packet)
        {
            StringBuilder sb = new StringBuilder();

            int len = packet.Length;
            int D_len;
            string id = string.Empty;

            Int16 val = 0;
            DateTime now = DateTime.Now;
            string recv_time = now.ToString("HH:mm:ss");

            if (use_milisec == true)
            {
                recv_time += ("." + now.Millisecond.ToString("000"));
            }

            int limit = (len - 3);

            for (int i = 3; i < limit; i++)
            {
                switch (packet[i])
                {
                    case 0x01:
                        {
                            D_len = Convert.ToInt32(packet[i + 1]);

                            if ((i + 1 + D_len) < limit)
                            {
                                for (int j = 0; j < D_len; j++)
                                {
                                    id += packet[i + 2 + j].ToString("x02");

                                    if (j < (D_len - 1))
                                    {
                                        id += ":";
                                    }
                                }

                                sb.AppendLine("ID : " + id.ToUpper());

                                i += (1 + D_len);
                            }
                        }
                        break;
                    case 0x02:
                        {
                            D_len = Convert.ToInt16(packet[i + 1]);

                            if ((i + 1 + D_len) < limit)
                            {
                                val = BitConverter.ToInt16(packet, i + 2);

                                double battV = 4.3 * (val / 4095.0) * (2.8 / 1.2);

                                sb.AppendLine("Battery Voltage");
                                sb.AppendLine("Recv : " + recv_time);
                                sb.AppendLine("Val : " + val.ToString());
                                sb.AppendLine("Batt : " + battV.ToString("#0.000"));

                                i += (1 + D_len);
                            }
                        }
                        break;
                    case 0x10:
                        {
                            D_len = Convert.ToInt16(packet[i + 1]);

                            if ((i + 1 + D_len) < limit)
                            {
                                val = Convert.ToInt16(packet[i + 2]);

                                sb.AppendLine("PIR Sensor");
                                sb.AppendLine("Recv : " + recv_time);
                                sb.AppendLine("Val : " + val.ToString());
                                sb.AppendLine("PIR : " + val.ToString());

                                i += (1 + D_len);
                            }
                        }
                        break;
                    case 0x11:
                        {
                            D_len = Convert.ToInt16(packet[i + 1]);

                            if ((i + 1 + D_len) < limit)
                            {
                                val = BitConverter.ToInt16(packet, i + 2);

                                double temp = val / 100.0;

                                sb.AppendLine("Temperature Sensor");
                                sb.AppendLine("Recv : " + recv_time);
                                sb.AppendLine("Val : " + val.ToString());
                                sb.AppendLine("Temp : " + temp);

                                i += (1 + D_len);
                            }
                        }
                        break;
                    case 0x12:
                        {
                            D_len = Convert.ToInt16(packet[i + 1]);

                            if ((i + 1 + D_len) < limit)
                            {
                                val = BitConverter.ToInt16(packet, i + 2);

                                double hum = val / 100.0;

                                sb.AppendLine("Humidity Sensor");
                                sb.AppendLine("Recv : " + recv_time);
                                sb.AppendLine("Val : " + val.ToString());
                                sb.AppendLine("Hum : " + hum);

                                i += (1 + D_len);
                            }
                        }
                        break;
                    case 0x14:
                        {
                            D_len = Convert.ToInt16(packet[i + 1]);

                            if ((i + 1 + D_len) < limit)
                            {
                                ushort lval = BitConverter.ToUInt16(packet, i + 2);

                                int lux = lval;

                                sb.AppendLine("Illuminance Sensor");
                                sb.AppendLine("Recv : " + recv_time);
                                sb.AppendLine("Val : " + lval.ToString());
                                sb.AppendLine("Lux : " + lux);

                                i += (1 + D_len);
                            }
                        }
                        break;
                    case 0x21:
                        {
                            D_len = Convert.ToInt16(packet[i + 1]);

                            if ((i + 1 + D_len) < limit)
                            {
                                ushort lval = BitConverter.ToUInt16(packet, i + 2);

                                int ppm = lval;

                                sb.AppendLine("CO2 Sensor");
                                sb.AppendLine("Recv : " + recv_time);
                                sb.AppendLine("Val : " + lval.ToString());
                                sb.AppendLine("CO2 : " + ppm);

                                i += (1 + D_len);
                            }
                        }
                        break;
                    case 0x32:
                        {
                            D_len = Convert.ToInt16(packet[i + 1]);

                            if ((i + 1 + D_len) < limit)
                            {
                                val = BitConverter.ToInt16(packet, i + 2);

                                sb.AppendLine("CT(RMS) Sensor");
                                sb.AppendLine("Recv : " + recv_time);
                                sb.AppendLine("Val : " + val.ToString());

                                i += (1 + D_len);
                            }
                        }
                        break;
                    case 0x35:
                        {
                            D_len = Convert.ToInt16(packet[i + 1]);

                            if ((i + 1 + D_len) < limit)
                            {
                                sb.AppendLine("CT(Wave) Sensor");
                                sb.AppendLine("Recv : " + recv_time);
                                sb.Append("Val : ");

                                if (D_len <= 64)
                                {
                                    int cnt = D_len / ByteUnit;

                                    for (int j = 0; j < cnt; j++)
                                    {
                                        int sidx = i + 2 + (j * ByteUnit);

                                        sb.Append(BitConverter.ToInt16(packet, sidx));

                                        if (j < (cnt - 1))
                                        {
                                            sb.Append(",");
                                        }
                                    }
                                }

                                i += (1 + D_len);
                            }
                        }
                        break;
                    case 0x46:
                        {
                            D_len = Convert.ToInt16(packet[i + 1]);

                            sb.AppendLine("Magnetometer");
                            sb.AppendLine("Mag1X : " + BitConverter.ToInt16(packet, i + 2));
                            sb.AppendLine("Mag1Y : " + BitConverter.ToInt16(packet, i + 4));
                            sb.AppendLine("Mag1Z : " + BitConverter.ToInt16(packet, i + 6));
                            sb.AppendLine("Mag2X : " + BitConverter.ToInt16(packet, i + 8));
                            sb.AppendLine("Mag2Y : " + BitConverter.ToInt16(packet, i + 10));
                            sb.AppendLine("Mag2Z : " + BitConverter.ToInt16(packet, i + 12));
                            sb.AppendLine("Mag3X : " + BitConverter.ToInt16(packet, i + 14));
                            sb.AppendLine("Mag3Y : " + BitConverter.ToInt16(packet, i + 16));
                            sb.AppendLine("Mag3Z : " + BitConverter.ToInt16(packet, i + 18));
                            sb.AppendLine("Mag4X : " + BitConverter.ToInt16(packet, i + 20));
                            sb.AppendLine("Mag4Y : " + BitConverter.ToInt16(packet, i + 22));
                            sb.AppendLine("Mag4Z : " + BitConverter.ToInt16(packet, i + 24));

                            i += (1 + D_len);
                        }
                        break;
                    case 0xAF:
                        {
                            D_len = Convert.ToInt32(packet[i + 1]);

                            if ((i + 1 + D_len) < limit)
                            {
                                byte[] buff = new byte[2];
                                buff[0] = packet[i + 2];
                                buff[1] = packet[i + 3];

                                sb.AppendLine("Packet Index : " + BitConverter.ToInt16(buff, 0));

                                i += (1 + D_len);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            sb.AppendLine();

            return sb.ToString();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2017-11-06 ] ///
        /// @ ParsingControlData @                                                                                  ///
        ///     프로토콜 패킷 중 제어 관련 패킷을 처리하여 결과를 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 데이터 </param>                                            ///
        /// <returns> string : 처리 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        static private string ParsingControlData(byte[] packet)
        {
            StringBuilder sb = new StringBuilder();

            int len = packet.Length;
            int D_len;
            string id = string.Empty;
            int limit = (len - 3); 

            for (int i = 3; i < limit; i++)
            {
                if (packet[i] >= 0xA1)
                {
                    D_len = GetTLVLength(packet, i + 1);

                    sb.Append(ParsingControlDProperty(packet, i));

                    i += (1 + D_len);
                }
                else if (packet[i] >= 0x80)
                {
                    D_len = GetTLVLength(packet, i + 1);

                    sb.Append(ParsingControlNode(packet, i));

                    i += (1 + D_len);
                }
                else if (packet[i] >= 0x70)
                {
                    D_len = GetTLVLength(packet, i + 1);

                    sb.Append(ParsingControlBase(packet, i));

                    i += (1 + D_len);
                }
                else
                {
                    D_len = Convert.ToInt32(packet[i + 1]);

                    switch (packet[i])
                    {
                        case 0x01:
                            {
                                if ((i + 1 + D_len) < limit)
                                {
                                    for (int j = 0; j < D_len; j++)
                                    {
                                        id += packet[i + 2 + j].ToString("x02");

                                        if (j < (D_len - 1))
                                        {
                                            id += ":";
                                        }
                                    }

                                    sb.AppendLine("ID : " + id.ToUpper());

                                    i += (1 + D_len);
                                }
                            }
                            break;
                        case 0x06:
                            {
                                sb.AppendLine("Sensor Status");
                                D_len = Convert.ToInt32(packet[i + 1]);

                                if ((i + 1 + D_len) < limit)
                                {
                                    int mode = Convert.ToInt32(packet[i + 2]);
                                    sb.AppendLine("Value : " + mode);

                                    int tmp = BitConverter.ToInt16(packet, i + 3);
                                    double batt = 4.3 * tmp / 4095 * 2.8 / 1.2;
                                    sb.Append("Battery Voltage : " + batt);

                                    i += (1 + D_len);
                                }
                            }
                            break;
                        case 0x07:
                            {
                                sb.Append(ParsingRAWData(packet));
                            }
                            break;
                        case 0x50:
                            {
                                sb.Append("* " + Commands[29] + " : ");
                                D_len = Convert.ToInt32(packet[i + 1]);

                                if ((i + 1 + D_len) < limit)
                                {
                                    if (packet[i + 2] == 0x01)
                                    {
                                        sb.AppendLine("Success");
                                    }
                                    else
                                    {
                                        sb.AppendLine("Failed");
                                        sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                                    }

                                    i += (1 + D_len);
                                }
                            }
                            break;
                        case 0x51:
                            {
                                sb.Append("* " + Commands[30] + " : ");
                                D_len = Convert.ToInt32(packet[i + 1]);

                                if ((i + 1 + D_len) < limit)
                                {
                                    byte[] tmp = new byte[4];
                                    tmp[0] = packet[i + 5];
                                    tmp[1] = packet[i + 4];
                                    tmp[2] = packet[i + 3];
                                    tmp[3] = packet[i + 2];

                                    int val = BitConverter.ToInt32(tmp, 0);

                                    if (val > 0)
                                    {
                                        sb.AppendLine("Success");
                                        sb.AppendLine("Period : " + val + " sec");
                                    }
                                    else
                                    {
                                        sb.AppendLine("Failed");
                                    }

                                    i += (1 + D_len);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            sb.AppendLine();

            return sb.ToString();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2017-11-06 ] ///
        /// @ ParsingControlBase @                                                                                  ///
        ///     베이스 노드 관련 프로토콜 패킷을 처리하여 결과를 반환한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 데이터 </param>                                            ///
        /// <param name="idx"> int : Payload 세부 항목 위치 </param>                                                ///
        /// <returns> string : 처리 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        static private string ParsingControlBase(byte[] packet, int i)
        {
            StringBuilder sb = new StringBuilder();

            int len = packet.Length;
            int D_len;
            int limit = len - 3;

            switch (packet[i])
            {
                // Base Reset Response
                case 0x70:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[0] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Set Base Channel Response
                case 0x76:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[5] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Get Base Channel Response
                case 0x77:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[4] + " : ");

                        int ch = Convert.ToInt16(packet[i + 2]);

                        if ((0 < ch) && (ch < 25))
                        {
                            sb.AppendLine("Success");
                            sb.AppendLine(ch.ToString());
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Get Base ID
                case 0x78:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[3] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Set Base CCA
                case 0x79:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[21] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Get Base CCA
                case 0x7A:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[22] + " : ");

                        byte cca = packet[i + 2];

                        if ((0x88 <= cca) && (cca <= 0xC4))
                        {
                            int val = Convert.ToInt32(0xFF - packet[i + 2]) + 1;

                            sb.AppendLine("Success");
                            sb.AppendLine("CCA : -" + val + " dBm");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                default:
                    break;
            }

            return sb.ToString();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2017-11-06 ] ///
        /// @ ParsingControlNode @                                                                                  ///
        ///     센서 노드 관련 프로토콜 패킷을 처리하여 결과를 반환한다.                                            ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 데이터 </param>                                            ///
        /// <param name="idx"> int : Payload 세부 항목 위치 </param>                                                ///
        /// <returns> string : 처리 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        static private string ParsingControlNode(byte[] packet, int i)
        {
            StringBuilder sb = new StringBuilder();

            int len = packet.Length;
            int D_len;
            int limit = len - 3;

            switch (packet[i])
            {
                // Device Reset Response
                case 0x80:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[1] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Report Reriod
                case 0x81:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[25] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Prompt Report
                case 0x82:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[26] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Factory Reset Response
                case 0x84:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[2] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Register Node Response
                case 0x85:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[9] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Set Node Channel Response
                case 0x86:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[8] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Get Node Channel Response
                case 0x87:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[7] + " : ");

                        int ch = Convert.ToInt16(packet[i + 2]);

                        if ((0 < ch) && (ch < 25))
                        {
                            sb.AppendLine("Success");
                            sb.AppendLine(ch.ToString());
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Set Vendor Response
                case 0x88:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[17] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Get Vendor Response
                case 0x89:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[16] + " : ");

                        if (packet[i + 1] == 0x10)
                        {
                            if (packet[i + 2] >= 0xF7)
                            {
                                sb.AppendLine("Failed");
                                sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                            }
                            else
                            {
                                string vendor = Encoding.UTF8.GetString(packet, i + 2, D_len);
                                sb.AppendLine("Success");
                                sb.AppendLine(vendor);
                            }
                        }
                    }
                    break;
                // Get Node Info
                case 0x8A:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.AppendLine("* " + Commands[6] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            int tmp_val;

                            sb.AppendLine("Status : Success");

                            if (packet[i + 3] == 0xff)
                            {
                                sb.AppendLine("Available Sampling : Fail");
                            }
                            else
                            {
                                tmp_val = Convert.ToInt16(packet[i + 3]);
                                int minS = Convert.ToInt32(Math.Pow(2, tmp_val / 16));
                                int maxS = Convert.ToInt32(Math.Pow(2, tmp_val % 16));
                                sb.AppendLine("Available Sampling : " + minS + " Hz ~ " + maxS + " Hz");
                            }

                            if (packet[i + 4] == 0xff)
                            {
                                sb.AppendLine("Sampling : Fail");
                            }
                            else
                            {
                                tmp_val = Convert.ToInt16(packet[i + 4]);
                                sb.AppendLine("Sampling : " + Convert.ToInt32(Math.Pow(2, tmp_val)) + " Hz");
                            }

                            if (packet[i + 5] == 0xff)
                            {
                                sb.AppendLine("Byte Unit : Fail");
                            }
                            else
                            {
                                sb.AppendLine("Byte Unit : " + Convert.ToInt32(packet[i + 5]) + " byte");
                            }

                            if (packet[i + 6] == 0xff)
                            {
                                sb.AppendLine("Available Shaft : Fail");
                            }
                            else
                            {
                                tmp_val = Convert.ToInt16(packet[i + 6]);
                                int minS = Convert.ToInt32(tmp_val / 16);
                                int maxS = Convert.ToInt32(tmp_val % 16);
                                sb.AppendLine("Available Shaft : " + minS + " ~ " + maxS);
                            }

                            string tmp = string.Empty;

                            for (int j = 0; j < 4; j++)
                            {
                                tmp += (CommonBase.Hex2Str16(packet[i + 10 - j]) + " ");
                            }

                            sb.AppendLine("Available Channel : " + tmp);

                            if (packet[i + 11] == 0xff)
                            {
                                sb.AppendLine("Channel : Fail");
                            }
                            else
                            {
                                tmp_val = Convert.ToInt16(packet[i + 11]);
                                sb.AppendLine("Channel : " + tmp_val);
                            }

                            if (packet[i + 12] == 0xff)
                            {
                                sb.AppendLine("Offset : Fail");
                            }
                            else
                            {
                                tmp_val = BitConverter.ToInt32(packet, i + 13);

                                //if (tmp_val >= 0x800000)
                                //{
                                //    tmp_val -= 0xFFFFFF;
                                //}

                                sb.AppendLine("Offset : " + tmp_val);
                            }

                            tmp = CommonBase.Hex2Str16(packet, i + 17, Len_ID);
                            tmp = tmp.Replace(" ", ":");
                            sb.AppendLine("Base ID : " + tmp.ToUpper());

                            tmp = Encoding.UTF8.GetString(packet, i + 25, Len_VN).Trim('\0');
                            sb.AppendLine("Vendor : " + tmp);

                            byte[] tmp_buff = new byte[4];
                            tmp_buff[0] = packet[i + 44];
                            tmp_buff[1] = packet[i + 43];
                            tmp_buff[2] = packet[i + 42];
                            tmp_buff[3] = packet[i + 41];

                            tmp = CommonBase.Hex2Str16(tmp_buff, 0, Len_FV);
                            sb.AppendLine("Firmware Version : " + tmp);

                            tmp_val = BitConverter.ToInt32(packet, i + 45);
                            sb.AppendLine("Battery Voltage : " + tmp_val);

                            tmp_val = BitConverter.ToInt32(packet, i + 47);
                            sb.AppendLine("Temperature : " + tmp_val);
                        }
                        else
                        {
                            sb.AppendLine("Status : Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Set Node CCA
                case 0x8B:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[23] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Get Node CCA
                case 0x8C:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[24] + " : ");

                        byte cca = packet[i + 2];

                        if ((0x88 <= cca) && (cca <= 0xC4))
                        {
                            int val = Convert.ToInt32(0xFF - packet[i + 2]) + 1;

                            sb.AppendLine("Success");
                            sb.AppendLine("CCA : -" + val + "dBm");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Set Boundary
                case 0x8D:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[27] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Get Boundary
                case 0x8E:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[28] + " : ");

                        if (D_len == 12)
                        {
                            sb.AppendLine("Success");
                            sb.Append("Bounds : ");

                            for (int j = 0; j < 6; j++)
                            {
                                sb.Append(Convert.ToInt16(packet[(i + 2) + (j * 2)]).ToString());

                                if (j < 5)
                                {
                                    sb.Append(", ");
                                }
                            }

                            sb.AppendLine();
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                default:
                    break;
            }

            return sb.ToString();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2017-11-06 ] ///
        /// @ ParsingControlDProperty @                                                                             ///
        ///     센서 계측 속성 관련 프로토콜 패킷을 처리하여 결과를 반환한다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 데이터 </param>                                            ///
        /// <param name="idx"> int : Payload 세부 항목 위치 </param>                                                ///
        /// <returns> string : 처리 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        static private string ParsingControlDProperty(byte[] packet, int i)
        {
            StringBuilder sb = new StringBuilder();

            int len = packet.Length;
            int D_len;
            int val;
            int limit = len - 3;

            switch (packet[i])
            {
                // Set Sampling
                case 0xA1:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[11] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Get Sampling
                case 0xA2:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[10] + " : ");

                        val = Convert.ToInt16(packet[i + 2]);

                        if ((0 <= val) && (val < 16))
                        {
                            sb.AppendLine("Success");
                            sb.AppendLine(val.ToString());
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Capture
                case 0xA3:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[12] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Data Fetch Ready Response
                case 0xA4:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[13] + " : ");

                        if (D_len == 11)
                        {
                            if (packet[i + 2] == 0x00)
                            {
                                sb.AppendLine("Success");

                                val = Convert.ToInt32(packet[i + 3]);
                                sb.Append("Identificaion Number : ");

                                if (val == 255)
                                {
                                    sb.AppendLine("Failed");
                                }
                                else
                                {
                                    sb.AppendLine(val.ToString());
                                }

                                val = Convert.ToInt16(packet[i + 4]);
                                sb.AppendLine("Sampling : " + val);

                                val = Convert.ToInt32(packet[i + 5]);
                                sb.AppendLine("Byte Unit : " + val);
                                ByteUnit = val;

                                val = Convert.ToInt32(packet[i + 6]);
                                sb.AppendLine("Axis : " + val);
                                Axis = val;

                                val = BitConverter.ToInt16(packet, i + 7);
                                sb.AppendLine("Max Index : " + val);

                                val = BitConverter.ToInt16(packet, i + 9);
                                sb.AppendLine("Battery Voltage : " + val);

                                val = BitConverter.ToInt16(packet, i + 11);
                                sb.AppendLine("Temperature : " + val);
                            }
                            else
                            {
                                sb.AppendLine("Failed");
                                sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                            }
                        }
                        else if(D_len == 6)
                        {
                            if (packet[i + 2] == 0x00)
                            {
                                sb.AppendLine("Success");

                                val = Convert.ToInt16(packet[i + 3]);
                                sb.AppendLine("Sampling : " + val);

                                val = Convert.ToInt32(packet[i + 4]);
                                sb.AppendLine("Byte Unit : " + val);
                                ByteUnit = val;

                                val = Convert.ToInt32(packet[i + 5]);
                                sb.AppendLine("Axis : " + val);
                                Axis = val;

                                val = BitConverter.ToInt16(packet, i + 6);
                                sb.AppendLine("Max Index : " + val);
                            }
                            else
                            {
                                sb.AppendLine("Failed");
                                sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                            }
                        }
                    }
                    break;
                // Data Fetch Start Response
                case 0xA5:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[14] + " : ");

                        if (D_len == 2)
                        {
                            if (packet[i + 2] == 0x00)
                            {
                                sb.AppendLine("Success");

                                val = Convert.ToInt16(packet[i + 3]);
                                sb.AppendLine("Identificaion Number : " + val);

                                if (val == 255)
                                {
                                    sb.AppendLine("Failed");
                                }
                                else
                                {
                                    sb.AppendLine(val.ToString());
                                }
                            }
                            else
                            {
                                sb.AppendLine("Failed");
                                sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                            }
                        }
                    }
                    break;
                // Retransmit Packet Response
                case 0xA6:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[15] + " : ");

                        if (D_len == 6)
                        {
                            sb = new StringBuilder();

                            if (packet[i + 2] == 0x00)
                            {
                                sb.AppendLine("Success");

                                val = Convert.ToInt16(packet[i + 3]);
                                sb.AppendLine("Sampling : " + val);

                                val = Convert.ToInt32(packet[i + 4]);
                                sb.AppendLine("Byte Unit : " + val);

                                val = Convert.ToInt32(packet[i + 5]);
                                sb.AppendLine("Shaft : " + val);

                                val = BitConverter.ToInt16(packet, i + 6);
                                sb.AppendLine("Max Index : " + val);
                            }
                            else
                            {
                                sb.AppendLine("Failed");
                                sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                            }
                        }
                    }
                    break;
                // Set Offset
                case 0xA7:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[20] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Get Offset
                case 0xA8:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[19] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");

                            val = BitConverter.ToInt32(packet, i + 3);
                            sb.AppendLine("Offset Val : " + val);
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Auto Offset
                case 0xA9:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* " + Commands[18] + " : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Set ODR
                case 0xAD:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* Set ODR : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                // Set Filter
                case 0xAF:
                    D_len = Convert.ToInt32(packet[i + 1]);

                    if ((i + 1 + D_len) < limit)
                    {
                        sb.Append("* Set Filter : ");

                        if (packet[i + 2] == 0x00)
                        {
                            sb.AppendLine("Success");
                        }
                        else
                        {
                            sb.AppendLine("Failed");
                            sb.AppendLine("Error : " + ControlErrorMessage(packet[i + 2]));
                        }
                    }
                    break;
                default:
                    break;
            }

            return sb.ToString();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2017-11-06 ] ///
        /// @ ControlErrorMessage @                                                                                 ///
        ///     에러 코드에 해당하는 에러 메시지를 반환한다.                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="Ecode"> byte : 에러 코드 </param>                                                          ///
        /// <returns> string : 처리 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        static private string ControlErrorMessage(byte Ecode)
        {
            string err_msg = "Unknown Error";

            switch (Ecode)
            {
                case 0xF7: err_msg = "Flash Error"; break;
                case 0xF8: err_msg = "Not Supported Block Type"; break;
                case 0xF9: err_msg = "Not Supported Channel"; break;
                case 0xFA: err_msg = "Not Fetch Ready"; break;
                case 0xFB: err_msg = "Not Exist Capture"; break;
                case 0xFC: err_msg = "Node Busy"; break;
                case 0xFD: err_msg = "Already Exist"; break;
                case 0xFE: err_msg = "Timeout"; break;
                case 0xFF: err_msg = "Invalid Argument"; break;
                default: break;
            }

            return err_msg;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2017-11-06 ] ///
        /// @ ParsingRAWData @                                                                                      ///
        ///     계측 데이터 패킷을 처리하여 결과를 반환한다.                                                        ///
        ///     ( * RAW 데이터 - 환산이 필요한 계측 데이터 )                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 데이터 </param>                                            ///
        /// <returns> string : 처리 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        static private string ParsingRAWData(byte[] packet)
        {
            StringBuilder sb = new StringBuilder();

            int len = packet.Length;
            int D_len;
            string id = string.Empty;
            int limit = (len - 3);

            for (int i = 3; i < limit; i++)
            {
                switch (packet[i])
                {
                    case 0x01:
                        D_len = Convert.ToInt32(packet[i + 1]);

                        if ((i + 1 + D_len) < limit)
                        {
                            for (int j = 0; j < D_len; j++)
                            {
                                id += packet[i + 2 + j].ToString("x02");

                                if (j < (D_len - 1))
                                {
                                    id += ":";
                                }
                            }

                            sb.AppendLine("ID : " + id.ToUpper());

                            i += (1 + D_len);
                        }
                        break;
                    case 0xA0:
                        D_len = Convert.ToInt32(packet[i + 1]);

                        if ((i + 1 + D_len) < limit)
                        {
                            if (D_len <= 48)
                            {
                                int cnt = D_len / (ByteUnit * Axis);
                                sb.AppendLine("ACC 3-Axis Data : " + cnt);

                                for (int j = 0; j < cnt; j++)
                                {
                                    int sidx = i + 2 + (j * Axis * ByteUnit);

                                    for (int k = 0; k < Axis; k++)
                                    {
                                        switch (ByteUnit)
                                        {
                                            case 1:
                                                du.d1 = packet[sidx + (k * Axis) + 0];
                                                du.d2 = 0x00;
                                                du.d3 = 0x00;
                                                du.d4 = 0x00;
                                                break;
                                            case 2:
                                                du.d1 = packet[sidx + (k * Axis) + 0];
                                                du.d2 = packet[sidx + (k * Axis) + 1];
                                                du.d3 = 0x00;
                                                du.d4 = 0x00;
                                                break;
                                            case 3:
                                                du.d1 = packet[sidx + (k * Axis) + 0];
                                                du.d2 = packet[sidx + (k * Axis) + 1];
                                                du.d3 = packet[sidx + (k * Axis) + 2];
                                                du.d4 = 0x00;

                                                if (du.data >= 0x800000)
                                                {
                                                    du.data -= 0xFFFFFF;
                                                }
                                                break;
                                            default:
                                                du.d1 = packet[sidx + (k * Axis) + 0];
                                                du.d2 = packet[sidx + (k * Axis) + 1];
                                                du.d3 = packet[sidx + (k * Axis) + 2];
                                                du.d4 = packet[sidx + (k * Axis) + 3];
                                                break;
                                        }

                                        sb.Append(du.data);

                                        if (k < (Axis - 1))
                                        {
                                            sb.Append(",");
                                        }
                                        else
                                        {
                                            sb.AppendLine("");
                                        }
                                    }
                                }
                            }

                            i += (1 + D_len);
                        }
                        break;
                    case 0xA1:
                        break;
                    case 0xA2:
                        break;
                    case 0xA3:
                        D_len = Convert.ToInt32(packet[i + 1]);

                        if ((i + 1 + D_len) < limit)
                        {
                            sb.Append("ACC 3-Axis : ");
                            sb.Append(BitConverter.ToInt16(packet, i + 2) + ",");
                            sb.Append(BitConverter.ToInt16(packet, i + 4) + ",");
                            sb.AppendLine(BitConverter.ToInt16(packet, i + 6) + "");

                            i += (1 + D_len);
                        }
                        break;
                    case 0xA4:
                        D_len = Convert.ToInt32(packet[i + 1]);

                        if ((i + 1 + D_len) < limit)
                        {
                            sb.Append("Gyro 3-Axis : ");
                            sb.Append(BitConverter.ToInt16(packet, i + 2) + ",");
                            sb.Append(BitConverter.ToInt16(packet, i + 4) + ",");
                            sb.AppendLine(BitConverter.ToInt16(packet, i + 6) + "");

                            i += (1 + D_len);
                        }
                        break;
                    case 0xAF:
                        D_len = Convert.ToInt32(packet[i + 1]);

                        if ((i + 1 + D_len) < limit)
                        {
                            byte[] buff = new byte[2];
                            buff[0] = packet[i + 2];
                            buff[1] = packet[i + 3];

                            sb.AppendLine("Packet Index : " + BitConverter.ToInt16(buff, 0));

                            i += (1 + D_len);
                        }
                        break;
                    case 0x35:
                        {
                            D_len = Convert.ToInt16(packet[i + 1]);
                            string recv_time = DateTime.Now.ToString("HH:mm:ss");

                            if ((i + 1 + D_len) < limit)
                            {
                                sb.AppendLine("CT(Wave) Sensor");
                                sb.AppendLine("Recv : " + recv_time);
                                sb.Append("Val : ");

                                if (D_len <= 64)
                                {
                                    int cnt = D_len / ByteUnit;

                                    for (int j = 0; j < cnt; j++)
                                    {
                                        int sidx = i + 2 + (j * ByteUnit);

                                        sb.Append(BitConverter.ToInt16(packet, sidx));

                                        if (j < (cnt - 1))
                                        {
                                            sb.Append(",");
                                        }
                                    }
                                }

                                i += (1 + D_len);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return sb.ToString();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.10 / 2017-11-06 ] ///
        /// @ ParsingRAWData @                                                                                      ///
        ///     계측 데이터 패킷을 처리하여 결과를 반환한다.                                                        ///
        ///     ( * RAW 데이터 - 환산이 필요한 계측 데이터 )                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 데이터 </param>                                            ///
        /// <param name="bits"> int : 데이터 유효 비트 수 </param>                                                  ///
        /// <returns> string : 처리 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        static private string ParsingRAWData(byte[] packet, int bits)
        {
            StringBuilder sb = new StringBuilder();

            int len = packet.Length;
            int D_len;
            string id = string.Empty;
            int limit = (len - 3);

            for (int i = 3; i < limit; i++)
            {
                switch (packet[i])
                {
                    case 0x01:
                        D_len = Convert.ToInt32(packet[i + 1]);

                        if ((i + 1 + D_len) < limit)
                        {
                            for (int j = 0; j < D_len; j++)
                            {
                                id += packet[i + 2 + j].ToString("x02");

                                if (j < (D_len - 1))
                                {
                                    id += ":";
                                }
                            }

                            sb.AppendLine("ID : " + id.ToUpper());

                            i += (1 + D_len);
                        }
                        break;
                    case 0xA0:
                        D_len = Convert.ToInt32(packet[i + 1]);

                        if ((i + 1 + D_len) < limit)
                        {
                            if (D_len <= 48)
                            {
                                int cnt = D_len / (ByteUnit * Axis);
                                sb.AppendLine("ACC 3-Axis Data : " + cnt);

                                for (int j = 0; j < cnt; j++)
                                {
                                    int sidx = i + 2 + (j * Axis * ByteUnit);

                                    for (int k = 0; k < Axis; k++)
                                    {
                                        switch (ByteUnit)
                                        {
                                            case 1:
                                                du.d1 = packet[sidx + (k * Axis) + 0];
                                                du.d2 = 0x00;
                                                du.d3 = 0x00;
                                                du.d4 = 0x00;
                                                break;
                                            case 2:
                                                du.d1 = packet[sidx + (k * Axis) + 0];
                                                du.d2 = packet[sidx + (k * Axis) + 1];
                                                du.d3 = 0x00;
                                                du.d4 = 0x00;
                                                break;
                                            case 3:
                                                du.d1 = packet[sidx + (k * Axis) + 0];
                                                du.d2 = packet[sidx + (k * Axis) + 1];
                                                du.d3 = packet[sidx + (k * Axis) + 2];
                                                du.d4 = 0x00;

                                                if (du.data >= Convert.ToInt32(Math.Pow(2, (bits - 1))))
                                                {
                                                    du.data -= (Convert.ToInt32(Math.Pow(2, bits)) - 1);
                                                }
                                                break;
                                            default:
                                                du.d1 = packet[sidx + (k * Axis) + 0];
                                                du.d2 = packet[sidx + (k * Axis) + 1];
                                                du.d3 = packet[sidx + (k * Axis) + 2];
                                                du.d4 = packet[sidx + (k * Axis) + 3];
                                                break;
                                        }

                                        sb.Append(du.data);

                                        if (k < (Axis - 1))
                                        {
                                            sb.Append(",");
                                        }
                                        else
                                        {
                                            sb.AppendLine("");
                                        }
                                    }
                                }
                            }

                            i += (1 + D_len);
                        }
                        break;
                    case 0xA1:
                        break;
                    case 0xA2:
                        break;
                    case 0xA3:
                        D_len = Convert.ToInt32(packet[i + 1]);

                        if ((i + 1 + D_len) < limit)
                        {
                            sb.Append("ACC 3-Axis : ");

                            sb.Append(BitConverter.ToInt16(packet, i + 2) + ",");
                            sb.Append(BitConverter.ToInt16(packet, i + 4) + ",");
                            sb.AppendLine(BitConverter.ToInt16(packet, i + 6) + "");

                            i += (1 + D_len);
                        }
                        break;
                    case 0xA4:
                        D_len = Convert.ToInt32(packet[i + 1]);

                        if ((i + 1 + D_len) < limit)
                        {
                            sb.Append("Gyro 3-Axis : ");
                            sb.Append(BitConverter.ToInt16(packet, i + 2) + ",");
                            sb.Append(BitConverter.ToInt16(packet, i + 4) + ",");
                            sb.AppendLine(BitConverter.ToInt16(packet, i + 6) + "");

                            i += (1 + D_len);
                        }
                        break;
                    case 0xAF:
                        D_len = Convert.ToInt32(packet[i + 1]);

                        if ((i + 1 + D_len) < limit)
                        {
                            byte[] buff = new byte[2];
                            buff[0] = packet[i + 2];
                            buff[1] = packet[i + 3];

                            sb.AppendLine("Packet Index : " + BitConverter.ToInt16(buff, 0));

                            i += (1 + D_len);
                        }
                        break;
                    default:
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region [ # Ver 1.11 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.11 / 2017-12-18 ] ///
        /// @ PacketParsing @                                                                                       ///
        ///     프로토콜에 따라 패킷을 처리하여 결과를 반환한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 프로토콜 패킷 데이터 </param>                                            ///
        /// <param name="bits"> int : 데이터 유효 비트 수 </param>                                                  ///
        /// <returns> string : 처리 결과 </returns>                                                                 ///
        ///=========================================================================================================///
        static public string PacketParsing(byte[] packet, int bits)
        {
            string result = string.Empty;

            if (packet != null)
            {
                try
                {
                    if (CommonBase.CheckingCRC16_CCITT(packet, 1) == true)
                    {
                        string pack = CommonBase.Hex2Str16(packet, packet.Length);

                        switch (packet[2])
                        {
                            case 0x00:
                                {
                                    result = ("Packet : " + pack) + Environment.NewLine + ParsingConversionData(packet);
                                }
                                break;
                            case 0x01:
                                {
                                    result = ("Packet : " + pack) + Environment.NewLine + ParsingControlData(packet);
                                }
                                break;
                            case 0x02:
                                {
                                    result = ("Packet : " + pack) + Environment.NewLine + ParsingRAWData(packet, bits);
                                }
                                break;
                            default:
                                {
                                    result = "* Not Supported Protocol !!" + Environment.NewLine + ("Packet : " + pack);
                                    //pack = "▷ " + pack + " ◁";
                                }
                                break;
                        }

                        /*
                        RawPackets.Add(CommonBase.Hex2Str16(packet, packet.Length));

                        if (RawPackets.Count > 100)
                        {
                            FileManager.SetFileExtension(".dat");
                            FileManager.DataWriter(RawPackets.ToArray(), false, DataPath, "Serial", true, true, true, true, true, true);
                            RawPackets.Clear();
                        }*/
                    }
                    else
                    {
                        FileManager.LogWriter(CommonBase.Hex2Str16(packet, packet.Length), CommonBase.CRCPath, "CRC_Error", true, true, true, true, true);
                    }
                }
                catch (Exception ex)
                {
                    FileManager.LogWriter(ex.Message, ErrorPath, ErrorLogName, true, true, true, true, true);
                }
            }

            return result;
        }
        #endregion
    }
    ///============================================================================ End of Class : Command_Manager =///
}
