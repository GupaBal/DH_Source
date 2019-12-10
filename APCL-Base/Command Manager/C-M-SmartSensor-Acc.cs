using System;
using System.Windows.Forms;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.01 / 2018-02-20 ] ///
    /// ▷ SmartSensor_Acc : Command_Manager ◁                                                                     ///
    ///     APROS의 SmartSensor(진동)의 제어를 위한 프로토콜을 지원한다.                                            ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2017-11-06 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2018-02-20 ]                                                                                   ///
    ///     ▶ 계측 주기 설정 기능 추가                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class SmartSensor_Acc : SmartSensor
    {
        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-06 ] ///
        /// @ GetNodeData @                                                                                         ///
        ///     센서 노드의 최근 계측 데이터를 요청하는 명령 패킷을 생성하여 반환한다.                              ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetNodeData(string SID)
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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0x07);       // Type   - Command
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
        /// @ SetSampling @                                                                                         ///
        ///     센서 노드의 계측 샘플링 정보를 설정하는 명령 패킷을 생성하여 반환한다.                              ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="exponent"> int : 샘플링 지수 정보 </param>                                                 ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SetSampling(string SID, int exponent)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);
            tmp = Convert.ToByte(exponent);

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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0xA1);       // Type   - Command
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
        /// @ GetSampling @                                                                                         ///
        ///     센서 노드의 계측 샘플링 정보를 조회하는 명령 패킷을 생성하여 반환한다.                              ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetSampling(string SID)
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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0xA2);       // Type   - Command
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
        /// @ Capture @                                                                                             ///
        ///     센서 노드에 계측 시작을 요청하는 명령 패킷을 생성하여 반환한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] Capture(string SID)
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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0xA3);       // Type   - Command
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
        /// @ DataFetchReady @                                                                                      ///
        ///     센서 노드에 데이터 전송 준비 명령 패킷을 생성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="axis"> int : 진동 센서의 축 개수 </param>                                                  ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] DataFetchReady(string SID, int axis)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);
            tmp = Convert.ToByte(axis);

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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0xA4);       // Type   - Command
                Buffer.Add(0x02);       // Length - Command
                Buffer.Add(tmp);        // Value  - Command (Shaft)
                Buffer.Add(0x00);       // Value  - Command (Identification Number}
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
        /// @ DataFetchStart @                                                                                      ///
        ///     센서 노드에 데이터 전송 요청 명령 패킷을 생성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] DataFetchStart(string SID)
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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0xA5);       // Type   - Command
                Buffer.Add(0x01);       // Length - Command
                Buffer.Add(0x00);       // Value  - Command
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
        /// @ RetransmitPacket @                                                                                    ///
        ///     센서 노드에 특정 데이터 패킷의 재전송을 요청하는 명령 패킷을 생성하여 반환한다.                     ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="idx"> Int16 : 재전송 패킷 인덱스 </param>                                                  ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] RetransmitPacket(string SID, Int16 idx)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);
            tmp_Bbuff = BitConverter.GetBytes(idx);

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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0xA6);       // Type   - Command
                Buffer.Add(0x02);       // Length - Command

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
        /// @ SetFilter @                                                                                           ///
        ///     센서 노드의 적용할 필터의 값을 설정하는 명령 패킷을 생성하여 반환한다.                              ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="filter"> Int16 : 필터 값 </param>                                                          ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SetFilter(string SID, Int16 filter)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);
            tmp_Bbuff = BitConverter.GetBytes(filter);

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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0xAF);       // Type   - Command
                Buffer.Add(0x02);       // Length - Command

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
        /// @ SetODR @                                                                                              ///
        ///     센서 노드의 ODR(output data rate)의 값을 설정하는 명령 패킷을 생성하여 반환한다.                    ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="odr"> Int16 : ODR 값 </param>                                                              ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SetODR(string SID, Int16 odr)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);
            tmp_Bbuff = BitConverter.GetBytes(odr);

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

                Buffer.Add(0xAD);       // Type   - Command
                Buffer.Add(0x02);       // Length - Command

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
        /// @ MeasureStart @                                                                                        ///
        ///     센서 노드의 계측 시작 명령 패킷을 생성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] MeasureStart(string SID)
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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0x01);       // Type   - Command
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
        /// @ MeasureStop @                                                                                         ///
        ///     센서 노드의 계측 중지 명령 패킷을 생성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] MeasureStop(string SID)
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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0x02);       // Type   - Command
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
        /// <summary>                                                                     [ Ver 1.01 / 2018-02-20 ] ///
        /// @ SetDataFetchPeriod @                                                                                  ///
        ///     센서 노드의 계측 주기를 설정하는 명령 패킷을 생성하여 반환한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <param name="sec"> int : 계측 주기 </param>                                                             ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] SetDataFetchPeriod(string SID, int sec)
        {
            Buffer.Clear();

            tmp_str = SID.Replace(":", "");
            tmp_Abuff = CommonBase.HexStringToByteArray(tmp_str);
            tmp_Bbuff = BitConverter.GetBytes(sec);

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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0x50);       // Type   - Command
                Buffer.Add(0x04);       // Length - Command

                for (int i = (tmp_Bbuff.Length - 1); i > -1; i--)
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
        /// <summary>                                                                     [ Ver 1.01 / 2018-02-20 ] ///
        /// @ GetDataFetchPeriod @                                                                                  ///
        ///     센서 노드의 계측 주기를 조회하는 명령 패킷을 생성하여 반환한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="SID"> string : Sensor Node ID </param>                                                     ///
        /// <returns> byte[] : 명령 패킷 </returns>                                                                 ///
        ///=========================================================================================================///
        static public byte[] GetDataFetchPeriod(string SID)
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
                    Buffer.Add(tmp_Abuff[i]);    // Value - SID
                }

                Buffer.Add(0x51);       // Type   - Command
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
    ///============================================================================ End of Class : SmartSensor_Acc =///
}
