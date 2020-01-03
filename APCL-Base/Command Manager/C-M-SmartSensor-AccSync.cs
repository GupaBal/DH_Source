using System;
using System.Text;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2017-10-23 ] ///
    /// ▷ C_M_SmartSensor_AccSync : Command_Manager ◁                                                             ///
    ///     APROS의 SmartSensor(진동) 동기화 버전의 제어를 위한 프로토콜을 지원한다.                                ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2017-xx-xx ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class SmartSensor_AccSync : SmartSensor
    {
        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ SetDate @                                                                                             ///
        ///     로컬시스템의 현재 시간 정보를 byte 배열로 변환하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="dt"> DateTime : 시간 정보 </param>                                                         ///
        /// <returns> byte[] : 시간 정보 데이터 </returns>                                                          ///
        ///=========================================================================================================///
        static protected byte[] SetDate(DateTime dt)
        {
            byte[] date = new byte[14];

            try
            {
                string tmp = string.Empty;

                tmp = dt.Year.ToString("0000");
                tmp += dt.Month.ToString("00");
                tmp += dt.Day.ToString("00");
                tmp += dt.Hour.ToString("00");
                tmp += dt.Minute.ToString("00");
                tmp += dt.Second.ToString("00");

                for (int i = 0; i < 14; i++)
                {
                    date[i] = Convert.ToByte(Convert.ToChar(tmp.Substring(i, 1)));
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ SetDate ]");
                MessageBuilder.AppendLine(" DateTime : NULL");
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return date;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ SetDate @                                                                                             ///
        ///     로컬시스템의 현재 시간 정보를 byte 배열로 변환하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="dt"> string : 시간 정보 </param>                                                           ///
        /// <returns> byte[] : 시간 정보 데이터 </returns>                                                          ///
        ///=========================================================================================================///
        static protected byte[] SetDate(string dt)
        {
            byte[] date = new byte[14];

            try
            {
                for (int i = 0; i < 14; i++)
                {
                    date[i] = Convert.ToByte(Convert.ToChar(dt.Substring(i, 1)));
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ SetDate ]");
                MessageBuilder.Append(" DateTime : ");

                if (string.IsNullOrEmpty(dt) == true)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    MessageBuilder.AppendLine(dt);
                }

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return date;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ Ready @                                                                                               ///
        ///     계측 준비 명령 패킷을 생성하여 반환한다.                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : ID 정보 </param>                                                              ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Ready(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'D'); Buffer.Add((byte)'R');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ Ready ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine(Environment.NewLine);
                }

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ Start @                                                                                               ///
        ///     계측 시작 명령 패킷을 생성하여 반환한다.                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : ID 정보 </param>                                                              ///
        /// <param name="dt"> DateTime : 시작 시간 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Start(int[] id, DateTime dt)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);
                Data = SetDate(dt);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'T'); Buffer.Add((byte)'S');   // Parameter

                for (int i = 0; i < Data.Length; i++)           // Data
                {
                    Buffer.Add(Data[i]);
                }

                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ Start ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                if (dt == null)
                {
                    MessageBuilder.AppendLine("DateTime : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine(dt.ToString("yyyyMMddhhmmss"));
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ Stop @                                                                                                ///
        ///     계측 중지 명령 패킷을 생성하여 반환한다.                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : ID 정보 </param>                                                              ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Stop(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'D'); Buffer.Add((byte)'E');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ Stop ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ Reboot @                                                                                              ///
        ///     스마트 로거를 재부팅하는 명령 패킷을 생성하여 반환한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : ID 정보 </param>                                                              ///
        /// <param name="mode"> int : 부팅 모드 </param>                                                            ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Reboot(int[] id, int mode)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'B'); Buffer.Add((byte)'R');   // Parameter
                Buffer.Add(Convert.ToByte(mode));               // Data
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ Reboot ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine("Mode : " + mode);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ Alive @                                                                                               ///
        ///     스마트 로거의 동작 여부를 조회하는 명령 패킷을 생성하여 반환한다.                                   ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : ID 정보 </param>                                                              ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Alive(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'L'); Buffer.Add((byte)'A');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ Alive ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ GetEnvironment @                                                                                      ///
        ///     스마트 로거의 속성 정보를 조회하는 명령 패킷을 생성하여 반환한다.                                   ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : ID 정보 </param>                                                              ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetEnvironment(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'E'); Buffer.Add((byte)'G');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ GetEnvironment ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ SetGroupID @                                                                                          ///
        ///     스마트 로거의 그룹 ID를 설정하는 명령 패킷을 생성하여 반환한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : ID 정보 </param>                                                              ///
        /// <param name="gid"> int : 그룹 ID </param>                                                               ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        public static byte[] SetGroupID(int[] id, int gid)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'G'); Buffer.Add((byte)'I');   // Parameter
                Buffer.Add(Convert.ToByte(id[0]));              // Data
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ SetGroupID ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine("GID : " + gid);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ SetNodeID @                                                                                           ///
        ///     스마트 로거의 노드 ID를 설정하는 명령 패킷을 생성하여 반환한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : ID 정보 </param>                                                              ///
        /// <param name="nid"> int : 노드 ID </param>                                                               ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        public static byte[] SetNodeID(int[] id, int nid)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);
                Data = BitConverter.GetBytes(nid);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[1]); Buffer.Add(NodeID[0]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'N'); Buffer.Add((byte)'I');   // Parameter
                Buffer.Add(Data[0]); Buffer.Add(Data[1]);       // Data
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ SetNodeID ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine("NID : " + nid);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ RTC @                                                                                                 ///
        ///     스마트 로거의 시간을 설정하는 명령 패킷을 생성하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="fname"> string : 파일 이름 </param>                                                        ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        public static byte[] RTC(int[] id, string filename)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                if (filename == string.Empty)
                {
                    Data = SetDate(DateTime.Now);
                }
                else
                {
                    Data = SetDate(filename);
                }

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'S'); Buffer.Add((byte)'T');   // Parameter

                for (int i = 0; i < Data.Length; i++)           // Data
                {
                    Buffer.Add(Data[i]);
                }

                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ RTC ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.Append("File Name : ");

                if (string.IsNullOrEmpty(filename) == true)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    MessageBuilder.AppendLine(filename);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ Gain @                                                                                                ///
        ///     계측 데이터의 Gain 정보를 설정하는 명령 패킷을 생성하여 반환한다.                                   ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="idx"> int : Gain 값 </param>                                                               ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Gain(int[] id, int idx)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'G'); Buffer.Add((byte)'E');   // Parameter
                Buffer.Add(Convert.ToByte(idx));                // Data
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ Gain ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.Append("Index : " + idx);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ Filter @                                                                                              ///
        ///     계측 데이터의 필터링 정보를 설정하는 명령 패킷을 생성하여 반환한다.                                 ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="filter"> int : 계측 필터 인덱스 </param>                                                   ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Filter(int[] id, int filter)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'F'); Buffer.Add((byte)'E');   // Parameter
                Buffer.Add(Convert.ToByte(filter));             // Data
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ Filter ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.Append("Filter : " + filter);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ SamplingRate @                                                                                        ///
        ///     계측 샘플링 정보를 설정하는 명령 패킷을 생성하여 반환한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="sampling"> int : 계측 샘플링 수 </param>                                                   ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SamplingRate(int[] id, int sampling)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);
                Data = BitConverter.GetBytes(sampling);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[1]); Buffer.Add(NodeID[0]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'R'); Buffer.Add((byte)'E');   // Parameter
                Buffer.Add(Convert.ToByte(sampling));           // Data
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ SamplingRate ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.Append("Sampling : " + sampling);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ FileList @                                                                                            ///
        ///     MicroSD 메모리에 저장된 데이터 파일 리스트를 요청하는 명령 패킷을 생성하여 반환한다.                ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="date"> string : 조회 일자 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] FileList(int[] id, string date)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                if (date.Equals("ALL") == true)
                {
                    Data = new byte[3];
                    Data[0] = (byte)'A';
                    Data[1] = (byte)'L';
                    Data[2] = (byte)'L';
                }
                else
                {
                    Data = SetDate(date);
                }

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'L'); Buffer.Add((byte)'F');   // Parameter

                for (int i = 0; i < Data.Length; i++)           // Data
                {
                    Buffer.Add(Data[i]);
                }

                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ FileList ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.Append("Date : " + date);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ FileSize @                                                                                            ///
        ///     데이터 파일의 크기를 조회하는 명령 패킷을 생성하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="fname"> string : 전송 대상 파일 이름 </param>                                              ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] FileSize(int[] id, string filename)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);
                Data = SetDate(filename);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'S'); Buffer.Add((byte)'F');   // Parameter

                for (int i = 0; i < Data.Length; i++)           // Data
                {
                    Buffer.Add(Data[i]);
                }

                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ FileSize ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.Append(" File Name : ");

                if (filename == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    MessageBuilder.Append(filename);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ FileTrans @                                                                                           ///
        ///     데이터 파일의 전송을 요청하는 명령 패킷을 생성하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="fname"> string : 전송 대상 파일 이름 </param>                                              ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] FileTrans(int[] id, string filename)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);
                Data = SetDate(filename);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'T'); Buffer.Add((byte)'F');   // Parameter

                for (int i = 0; i < Data.Length; i++)           // Data
                {
                    Buffer.Add(Data[i]);
                }

                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ FileTrans ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.Append(" File Name : ");

                if (filename == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    MessageBuilder.Append(filename);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ FileReTrans @                                                                                         ///
        ///     데이터 파일의 일부를 재전송 요청하는 명령 패킷을 생성하여 반환한다.                                 ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="fname"> string : 전송 대상 파일 이름 </param>                                              ///
        /// <param name="block"> int : 재전송 대상 파일 블록 </param>                                               ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] FileReTrans(int[] id, string filename, int block)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);
                Data = BitConverter.GetBytes(block);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'R'); Buffer.Add((byte)'F');   // Parameter

                for (int i = 0; i < Data.Length; i++)           // Data
                {
                    Buffer.Add(Data[Data.Length - (1 + i)]);
                }

                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ FileReTrans ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.Append(" File Name : ");

                if (filename == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    MessageBuilder.Append(filename);
                }

                MessageBuilder.AppendLine("Block : " + block);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ FileDelete @                                                                                          ///
        ///     MicroSD 메모리에 저장된 파일을 삭제하는 명령 패킷을 생성하여 반환한다.                              ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="fname"> string : 삭제 대상 파일 이름 </param>                                              ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] FileDelete(int[] id, string filename)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                if (filename.Equals("ALL") == true)
                {
                    Data = new byte[3];
                    Data[0] = (byte)'A';
                    Data[1] = (byte)'L';
                    Data[2] = (byte)'L';
                }
                else
                {
                    Data = SetDate(filename);
                }

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'D'); Buffer.Add((byte)'F');   // Parameter

                for (int i = 0; i < Data.Length; i++)           // Data
                {
                    Buffer.Add(Data[Data.Length - (1 + i)]);
                }

                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ FileDelete ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.Append(" File Name : ");

                if (filename == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    MessageBuilder.Append(filename);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ FileSave @                                                                                            ///
        ///     데이터 파일 저장 모드를 설정하는 명령 패킷을 생성하여 반환한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="idx"> int : 파일 저장 모드 </param>                                                        ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] FileSave(int[] id, int idx)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'V'); Buffer.Add((byte)'F');   // Parameter
                Buffer.Add(Convert.ToByte(idx));                // Data
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ FileSave ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine("Index : " + idx);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ TransmitMethod @                                                                                      ///
        ///     데이터 패킷의 무선 전송 모드를 설정하는 명령 패킷을 생성하여 반환한다.                              ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="idx"> int : 무선 전송 모드 </param>                                                        ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] TransmitMethod(int[] id, int idx)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'M'); Buffer.Add((byte)'S');   // Parameter
                Buffer.Add(Convert.ToByte(idx));                // Data
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ TransmitMethod ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine("Index : " + idx);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ FirmwareVersion @                                                                                     ///
        ///     스마트 로거의 펌웨어 정보를 조회하는 명령 패킷을 생성하여 반환한다.                                 ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] FirmwareVersion(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'V'); Buffer.Add((byte)'M');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ FirmwareVersion ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ CycleMeasure @                                                                                        ///
        ///     센서의 계측 시간을 설정하는 명령 패킷을 생성하여 반환한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="min"> int : 계측 시간(분) </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] CycleMeasure(int[] id, int min)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'M'); Buffer.Add((byte)'C');   // Parameter
                Buffer.Add(Convert.ToByte(min));                // Data
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ CycleMeasure ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine("Time : " + min);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ RSSI @                                                                                                ///
        ///     통신 감도를 조회하는 명령 패킷을 생성하여 반환한다.                                                 ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] RSSI(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'S'); Buffer.Add((byte)'I');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ RSSI ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ SDSize @                                                                                              ///
        ///     MicroSD의 용량을 조회하는 명령 패킷을 생성하여 반환한다.                                            ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SDSize(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'S'); Buffer.Add((byte)'D');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ SDSize ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ SDInfo @                                                                                              ///
        ///     MicroSD의 정보를 조회하는 명령 패킷을 생성하여 반환한다.                                            ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SDInfo(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'I'); Buffer.Add((byte)'D');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ SDInfo ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ ResetPower @                                                                                          ///
        ///     스마트 로거의 전원 공급 모드를 설정하는 명령 패킷을 생성하여 반환한다.                              ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="mode"> int : 전원 공급 모드 </param>                                                       ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] ResetPower(int[] id, int mode)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'P'); Buffer.Add((byte)'S');   // Parameter
                Buffer.Add(Convert.ToByte(mode));               // Data
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ SDInfo ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine("Mode : " + mode);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ ModuleInfo @                                                                                          ///
        ///     스마트 로거의 통신 모듈 정보를 조회하는 명령 패킷을 생성하여 반환한다.                              ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] ModuleInfo(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'I'); Buffer.Add((byte)'M');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ ModuleInfo ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ FileFormat @                                                                                          ///
        ///     스마트 로거 내부의 MicroSD 메모리를 포맷하는 명령 패킷을 생성하여 반환한다.                         ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <param name="mode"> int : MicroSD 메모리 포맷 모드 </param>                                             ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] FileFormat(int[] id, int mode)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'F'); Buffer.Add((byte)'F');   // Parameter
                Buffer.Add(Convert.ToByte(mode));               // Data
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ FileFormat ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine("Mode : " + mode);
                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ GetBattery @                                                                                          ///
        ///     스마트 로거의 배터리 용량을 조회하는 명령 패킷을 생성하여 반환한다.                                 ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        public static byte[] GetBattery(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'V'); Buffer.Add((byte)'B');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ GetBattery ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ GetTemperature @                                                                                      ///
        ///     스마트 로거의 온도를 조회하는 명령 패킷을 생성하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetTemperature(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'W');                          // Function
                Buffer.Add((byte)'P'); Buffer.Add((byte)'T');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                string info = " ID : ";

                if (id == null) info += "NULL";
                else
                {
                    foreach (int i in id)
                        info += (i.ToString() + ", ");

                    info += "done";
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ GetBattery ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-10-23 ] ///
        /// @ SetUSBDriveMode @                                                                                     ///
        ///     스마트 로거의 MicroSD를 USB 외장 드라이브 모드로 변환하는 명령 패킷을 생성하여 반환한다.            ///
        /// </summary>                                                                                              ///
        /// <param name="id"> int[] : 노드 ID 정보 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SetUSBDriveMode(int[] id)
        {
            Packet = new byte[0];

            try
            {
                NodeID = BitConverter.GetBytes(id[1]);

                Buffer.Add(0x02);                               // STX
                Buffer.Add(0x00); Buffer.Add(0x00);             // Length
                Buffer.Add(Convert.ToByte(id[0]));              // Group ID
                Buffer.Add(NodeID[0]); Buffer.Add(NodeID[1]);   // Node ID
                Buffer.Add((byte)'Q');                          // Function
                Buffer.Add((byte)'C'); Buffer.Add((byte)'U');   // Parameter
                Buffer.Add(0x00); Buffer.Add(0x00);             // CRC
                Buffer.Add(0x03);                               // ETX

                Packet = Buffer.ToArray();

                Data = BitConverter.GetBytes(Packet.Length - 3);
                Packet[1] = Data[0]; Packet[2] = Data[1];

                CommonBase.SetCRC16_CCITT(Packet, 1);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine("[ SetUSBDriveMode ]");
                MessageBuilder.Append(" ID : ");

                if (id == null)
                {
                    MessageBuilder.AppendLine("NULL");
                }
                else
                {
                    foreach (int n in id)
                    {
                        MessageBuilder.Append(n.ToString() + ", ");
                    }

                    MessageBuilder.AppendLine();
                }

                MessageBuilder.AppendLine();

                MessageBuilder.AppendLine(e.ToString() + Environment.NewLine);
                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Buffer.Clear();

            return Packet;
        }
        #endregion
    }
    ///============================================================================ End of Class : SmartSensor_Acc =///
}
