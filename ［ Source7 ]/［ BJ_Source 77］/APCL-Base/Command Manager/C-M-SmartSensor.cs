using System;
using System.Text;
using System.Windows.Forms;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2017-11-06 ] ///
    /// ▷ SmartSensor : Command_Manager ◁                                                                         ///
    ///     APROS의 SmartSensor 제어를 위한 프로토콜을 지원한다.                                                    ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2017-11-06 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2017-11-06 ]                                                                                   ///
    ///     ▶ 주기, 임계 범위 설정 추가                                                                            ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class SmartSensor : Command_Manager
    {
        #region [ # Defines & Variables ]
        static public string tmp_str;
        static public byte[] tmp_Abuff;
        static public byte[] tmp_Bbuff;
        static public byte tmp;
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ BaseReset @                                                                                           ///
        ///     베이스 노드의 리셋 명령 패킷을 생성하여 반환한다.                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="BID"> string : Base Node ID </param>                                                       ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] BaseReset(string BID)
        {
            Buffer.Clear();

            tmp_str = BID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x70);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ SetBaseChannel @                                                                                      ///
        ///     베이스 노드의 통신 채널 설정 명령 패킷을 생성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="BID"> string : Base Node ID </param>                                                       ///
        /// <param name="ch"> int : 통신 채널 번호 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SetBaseChannel(string BID, int ch)
        {
            Buffer.Clear();

            tmp_str = BID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);
            tmp = Convert.ToByte(ch);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x76);       // Type   - Command
                Buffer.Add(0x01);       // Length - Command
                Buffer.Add(tmp);        // Value  - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ GetBaseChannel @                                                                                      ///
        ///     베이스 노드의 통신 채널 조회 명령 패킷을 생성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="BID"> string : Base Node ID </param>                                                       ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetBaseChannel(string BID)
        {
            Buffer.Clear();

            tmp_str = BID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x77);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ GetBaseID @                                                                                           ///
        ///     베이스 노드의 ID 조회 명령 패킷을 생성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetBaseID()
        {
            Buffer.Clear();

            Buffer.Add(STX);        // STX
            Buffer.Add(0x00);       // Packet Length
            Buffer.Add(0x01);       // Message Type
            Buffer.Add(0x01);       // Type   - ID
            Buffer.Add(0x08);       // Length - ID
            Buffer.Add(0xFF);       // Value  - ID (1/8)
            Buffer.Add(0xFF);       // Value  - ID (2/8)
            Buffer.Add(0xFF);       // Value  - ID (3/8)
            Buffer.Add(0xFF);       // Value  - ID (4/8)
            Buffer.Add(0xFF);       // Value  - ID (5/8)
            Buffer.Add(0xFF);       // Value  - ID (6/8)
            Buffer.Add(0xFF);       // Value  - ID (7/8)
            Buffer.Add(0xFF);       // Value  - ID (8/8)
            Buffer.Add(0x78);       // Type   - Command
            Buffer.Add(0x00);       // Length - Command
            Buffer.Add(0x00);       // CRC (1/2)
            Buffer.Add(0x00);       // CRC (2/2)
            Buffer.Add(ETX);        // ETX

            Packet = Buffer.ToArray();

            Packet[1] = Convert.ToByte(Packet.Length - 2);
            CommonBase.SetCRC16_CCITT(Packet, 1);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ SetBaseCCA @                                                                                          ///
        ///     베이스 노드의 CCA를 설정하는 명령 패킷을 생성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="BID"> string : Base Node ID </param>                                                       ///
        /// <param name="threshold"> byte : CCA 설정 값 </param>                                                    ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SetBaseCCA(string BID, byte threshold)
        {
            byte CCA = Convert.ToByte(threshold);

            Buffer.Clear();

            tmp_str = BID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            Buffer.Add(STX);        // STX
            Buffer.Add(0x00);       // Packet Length
            Buffer.Add(0x01);       // Message Type
            Buffer.Add(0x01);       // Type   - ID
            Buffer.Add(0x08);       // Length - ID

            for (int i = 0; i < tmp_Abuff.Length; i++)
            {
                Buffer.Add(tmp_Abuff[i]);    // Value - BID
            }

            Buffer.Add(0x79);       // Type   - Command
            Buffer.Add(0x01);       // Length - Command
            Buffer.Add(CCA);        // Value  - Command
            Buffer.Add(0x00);       // CRC (1/2)
            Buffer.Add(0x00);       // CRC (2/2)
            Buffer.Add(ETX);        // ETX

            Packet = Buffer.ToArray();

            Packet[1] = Convert.ToByte(Packet.Length - 2);
            CommonBase.SetCRC16_CCITT(Packet, 1);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ GetBaseCCA @                                                                                          ///
        ///     베이스 노드의 CCA를 조회하는 명령 패킷을 생성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetBaseCCA(string BID)
        {
            Buffer.Clear();

            tmp_str = BID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            Buffer.Add(STX);        // STX
            Buffer.Add(0x00);       // Packet Length
            Buffer.Add(0x01);       // Message Type
            Buffer.Add(0x01);       // Type   - ID
            Buffer.Add(0x08);       // Length - ID

            for (int i = 0; i < tmp_Abuff.Length; i++)
            {
                Buffer.Add(tmp_Abuff[i]);    // Value - BID
            }

            Buffer.Add(0x7A);       // Type   - Command
            Buffer.Add(0x00);       // Length - Command
            Buffer.Add(0x00);       // CRC (1/2)
            Buffer.Add(0x00);       // CRC (2/2)
            Buffer.Add(ETX);        // ETX

            Packet = Buffer.ToArray();

            Packet[1] = Convert.ToByte(Packet.Length - 2);
            CommonBase.SetCRC16_CCITT(Packet, 1);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ DeviceReset @                                                                                         ///
        ///     센서 노드의 리셋 명령 패킷을 생성하여 반환한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] DeviceReset(string SID)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x80);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ FactoryReset @                                                                                        ///
        ///     센서 노드의 속성을 초기화하는 명령 패킷을 생성하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] FactoryReset(string SID)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x84);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ RegisterNode @                                                                                        ///
        ///     센서 노드를 베이스 노드에 등록하는 명령 패킷을 생성하여 반환한다.                                   ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="BID"> string : Base Node ID </param>                                                       ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] RegisterNode(string SID, string BID)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            tmp_str = BID.Replace(":", "");
            tmp_Bbuff = CommonBase.HexStringToByteArray(tmp_str);

            if ((tmp_Abuff.Length != 8) || (tmp_Bbuff.Length != 8))
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0x85);       // Type   - Command
                Buffer.Add(0x08);       // Length - Command

                for (int i = 0; i < tmp_Bbuff.Length; i++)
                {
                    Buffer.Add(tmp_Bbuff[i]);    // Value - Command
                }

                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ SetNodeChannel @                                                                                      ///
        ///     센서 노드의 통신 채널 설정 명령 패킷을 생성하여 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="ch"> int : 통신 채널 번호 </param>                                                         ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SetNodeChannel(string SID, int ch)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);
            tmp = Convert.ToByte(ch);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x86);       // Type   - Command
                Buffer.Add(0x01);       // Length - Command
                Buffer.Add(tmp);        // Value  - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ GetNodeChannel @                                                                                      ///
        ///     센서 노드의 통신 채널 조회 명령 패킷을 생성하여 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetNodeChannel(string SID)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x87);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ SetVendor @                                                                                           ///
        ///     센서 노드에 공급자 정보를 설정하는 명령 패킷을 생성하여 반환한다.                                   ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="Vendor"> string : 공급자 정보 </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SetVendor(string SID, string Vendor)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);
            tmp_Bbuff = Encoding.ASCII.GetBytes(Vendor);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x88);       // Type   - Command
                Buffer.Add(0x10);       // Length - Command

                if (tmp_Bbuff.Length < 16)
                {
                    for (int i = 0; i < tmp_Bbuff.Length; i++)
                    {
                        Buffer.Add(tmp_Bbuff[i]);   // Value - Command
                    }

                    for (int i = tmp_Bbuff.Length; i < (16 - tmp_Bbuff.Length); i++)
                    {
                        Buffer.Add(0x00);   // Value - Command
                    }
                }
                else
                {
                    for (int i = 0; i < 16; i++)
                    {
                        Buffer.Add(tmp_Bbuff[i]);   // Value - Command
                    }
                }

                int tmp = 16 - tmp_Bbuff.Length;

                if (tmp > 0)
                {
                    for (int i = 0; i < tmp; i++)
                    {
                        Buffer.Add(0x00);       // Value - Command
                    }
                }

                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ GetVendor @                                                                                           ///
        ///     센서 노드의 공급자 정보를 조회하는 명령 패킷을 생성하여 반환한다.                                   ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetVendor(string SID)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x89);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ GetNodeInfo @                                                                                         ///
        ///     센서 노드의 정보를 조회하는 명령 패킷을 생성하여 반환한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetNodeInfo(string SID)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x8A);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ SetNodeCCA @                                                                                          ///
        ///     센서 노드의 CCA를 설정하는 명령 패킷을 생성하여 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="threshold"> byte : CCA 설정 값 </param>                                                    ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SetNodeCCA(string SID, byte threshold)
        {
            byte CCA = Convert.ToByte(threshold);

            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x8B);       // Type   - Command
                Buffer.Add(0x01);       // Length - Command
                Buffer.Add(CCA);        // Value  - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ GetNodeCCA @                                                                                          ///
        ///     센서 노드의 CCA를 조회하는 명령 패킷을 생성하여 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetNodeCCA(string SID)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x8C);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ SetOffset @                                                                                           ///
        ///     센서 노드에 Offset을 설정하는 명령 패킷을 생성하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="offset"> int : Offset 설정 값 </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SetOffset(string SID, int offset)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);
            tmp_Bbuff = BitConverter.GetBytes(offset);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0xA7);       // Type   - Command
                Buffer.Add(0x04);       // Length - Command

                for (int i = 0; i < tmp_Bbuff.Length; i++)
                {
                    Buffer.Add(tmp_Bbuff[i]);   // Value - Command
                }

                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ GetOffset @                                                                                           ///
        ///     센서 노드에 설정된 Offset을 조회하는 명령 패킷을 생성하여 반환한다.                                 ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetOffset(string SID)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0xA8);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ AutoOffset @                                                                                          ///
        ///     센서 노드에 자동으로 Offset 보정을 요청하는 명령 패킷을 생성하여 반환한다.                          ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] AutoOffset(string SID)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0xA9);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2017-11-09 ] ///
        /// @ Report_Period @                                                                                       ///
        ///     센서 노드의 계측 주기를 설정하는 명령 패킷을 생성하여 반환한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="period"> int ; time (second) </param>                                                      ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Report_Period(string SID, int period)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x81);       // Type   - Command
                Buffer.Add(0x02);       // Length - Command

                byte[] tmp = BitConverter.GetBytes(period);

                Buffer.Add(tmp[0]);     // Value  = Command
                Buffer.Add(tmp[1]);
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2017-11-09 ] ///
        /// @ Prompt_Report @                                                                                       ///
        ///     센서 노드에 데이터를 요청하는 명령 패킷을 생성하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Prompt_Report(string SID)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x82);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2017-11-09 ] ///
        ///     센서 노드의 임계값 범위를 설정하는 명령 패킷을 생성하여 반환한다.                                   ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="bound"> int[] : 설정 임계값 </param>                                                       ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Set_Boundary(string SID, int[] bounds)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x8D);       // Type   - Command
                Buffer.Add(0x0C);       // Length - Command

                for (int i=0; i<6; i++)
                {
                    byte[] tmp = BitConverter.GetBytes(bounds[i]);
                    Buffer.Add(tmp[0]);
                    Buffer.Add(tmp[1]);
                }

                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;

        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2017-11-09 ] ///
        /// @ Get_Bounday @                                                                                         ///
        ///     센서 노드의 임계값 범위를 조회하는 명령 패킷을 생성하여 반환한다.                                   ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Get_Bounday(string SID)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);

            if (tmp_Abuff.Length != 8)
            {
                MessageBox.Show("ID의 길이가 일치하지 않습니다.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Packet = Buffer.ToArray();
            }
            else
            {
                Buffer.Add(STX);        // STX
                Buffer.Add(0x00);       // Packet Length
                Buffer.Add(0x01);       // Message Type
                Buffer.Add(0x01);       // Type   - ID
                Buffer.Add(0x08);       // Length - ID

                for (int i = 0; i < tmp_Abuff.Length; i++)
                {
                    Buffer.Add(tmp_Abuff[i]);    // Value - BID
                }

                Buffer.Add(0x8E);       // Type   - Command
                Buffer.Add(0x00);       // Length - Command
                Buffer.Add(0x00);       // CRC (1/2)
                Buffer.Add(0x00);       // CRC (2/2)
                Buffer.Add(ETX);        // ETX

                Packet = Buffer.ToArray();

                Packet[1] = Convert.ToByte(Packet.Length - 2);
                CommonBase.SetCRC16_CCITT(Packet, 1);
            }

            return Packet;

        }
        #endregion
    }
    ///================================================================================ End of Class : SmartSensor =///
}
