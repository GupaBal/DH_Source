
using System;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-04-23 ] ///
    /// ▷ HybridController : Command_Manager ◁                                                                    ///
    ///     APROS의 Hybrid Controller의 제어를 위한 프로토콜을 지원한다.                                            ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-23 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2014-07-21 ]                                                                                   ///
    ///     ▶ 부가 기능 추가                                                                                       ///
    /// [ Ver 1.02 / 2014-08-01 ]                                                                                   ///
    ///     ▶ 이력 조회 추가                                                                                       ///
    /// [ Ver 1.03 / 2014-08-05 ]                                                                                   ///
    ///     ▶ 램프 밝기, 데이터 파일 관련 추가                                                                     ///
    /// [ Ver 1.04 / 2014-08-27 ]                                                                                   ///
    ///     ▶ 램프 관련, 발전 충전 여부 추가                                                                       ///
    /// [ Ver 1.05 / 2014-11-13 ]                                                                                   ///
    ///     ▶ Offset 관련 추가                                                                                     ///
    /// [ Ver 1.06 / 2014-12-01 ]                                                                                   ///
    ///     ▶ 배터리 방전 방지 관련 추가                                                                           ///
    /// [ Ver 1.07 / 2015-01-13 ]                                                                                   ///
    ///     ▶ 하드웨어, 출고일자, 모델 정보 조회, Relay(Lamp 2) 관련 추가                                          ///
    /// [ Ver 1.08 / 2015-03-20 ]                                                                                   ///
    ///     ▶ 컨트롤러 재부팅 추가                                                                                 ///
    /// [ Ver 1.09 / 2016-11-24 ]                                                                                   ///
    ///     ▶ 컨트롤러 속성 설정 초기화 추가                                                                       ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class HybridController : Command_Manager
    {
        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadBatteryVoltage @                                                                                  ///
        ///     배터리 전압 조회 명령 패킷을 구성하여 반환한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 배터리 전압 조회 명령 패킷 </returns>                                                ///
        ///=========================================================================================================///
        static public byte[] ReadBatteryVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'B';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadBatteryCurrent @                                                                                  ///
        ///     배터리 전류 조회 명령 패킷을 구성하여 반환한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 배터리 전류 조회 명령 패킷 </returns>                                                ///
        ///=========================================================================================================///
        static public byte[] ReadBatteryCurrent(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'A';
            Packet[8] = (byte)'B';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadSolarVoltage @                                                                                    ///
        ///     태양광 발전 전압 조회 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 태양광 발전 전압 조회 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] ReadSolarVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'S';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadSolarCurrent @                                                                                    ///
        ///     태양광 발전 전류 조회 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 태양광 발전 전류 조회 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] ReadSolarCurrent(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'A';
            Packet[8] = (byte)'S';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-06-05 ] ///
        /// @ ReadSolarPowerTotal @                                                                                 ///
        ///     태양광 발전을 통해 생산된 일간, 월간, 전체 발전량 정보 조회 명령 패킷을 구성하여 반환한다.          ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 태양광 발전량 정보 조회 명령 패킷 </returns>                                         ///
        ///=========================================================================================================///
        static public byte[] ReadSolarPowerTotal(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'T';
            Packet[8] = (byte)'S';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadWindVoltage @                                                                                     ///
        ///     풍력 발전 전압 조회 명령 패킷을 구성하여 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 풍력 발전 전압 조회 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] ReadWindVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'W';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadWindCurrent @                                                                                     ///
        ///     풍력 발전 전류 조회 명령 패킷을 구성하여 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 풍력 발전 전류 조회 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] ReadWindCurrent(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'A';
            Packet[8] = (byte)'W';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-06-05 ] ///
        /// @ ReadWindCurrent @                                                                                     ///
        ///     풍력 발전을 통해 생산된 일간, 월간, 전체 발전량 정보 조회 명령 패킷을 구성하여 반환한다.            ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 풍력 발전량 정보 조회 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] ReadWindPowerTotal(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'T';
            Packet[8] = (byte)'W';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadLoadVoltage @                                                                                     ///
        ///     로드 전압 조회 명령 패킷을 구성하여 반환한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 로드 전압 조회 명령 패킷 </returns>                                                  ///
        ///=========================================================================================================///
        static public byte[] ReadLoadVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'L';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadLoadCurrent @                                                                                     ///
        ///     로드 전류 조회 명령 패킷을 구성하여 반환한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 로드 전류 조회 명령 패킷 </returns>                                                  ///
        ///=========================================================================================================///
        static public byte[] ReadLoadCurrent(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'A';
            Packet[8] = (byte)'L';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadWindRotate @                                                                                      ///
        ///     풍력 터빈 회전 속도 조회 명령 패킷을 구성하여 반환한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 풍력 터빈 회전 속도 조회 명령 패킷 </returns>                                        ///
        ///=========================================================================================================///
        static public byte[] ReadWindRotate(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'W';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadWindRotate @                                                                                      ///
        ///     풍향풍속 조회 명령 패킷을 구성하여 반환한다.                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 풍향풍속 조회 명령 패킷 </returns>                                                   ///
        ///=========================================================================================================///
        static public byte[] ReadWindSpeed(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'S';
            Packet[8] = (byte)'W';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadMagneticPoleNumber @                                                                              ///
        ///     마크네틱 폴 번호 조회 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 마크네틱 폴 번호 조회 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] ReadMagneticPoleNumber(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'P';
            Packet[8] = (byte)'M';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadRPMControl @                                                                                      ///
        ///     RPM 제어 여부 조회 명령 패킷을 구성하여 반환한다.                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : RPM 제어 여부 조회 명령 패킷 </returns>                                              ///
        ///=========================================================================================================///
        static public byte[] ReadRPMControl(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'R';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadRPMValue @                                                                                        ///
        ///     RPM 제어 값 조회 명령 패킷을 구성하여 반환한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : RPM 제어 값 조회 명령 패킷 </returns>                                                ///
        ///=========================================================================================================///
        /*static public byte[] ReadRPMValue(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'R';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadBoostStartVoltage @                                                                               ///
        ///     부스트 시작 전압 조회 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 부스트 시작 전압 조회 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] ReadBoostStartVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'S';
            Packet[8] = (byte)'B';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadAutoDumpTime @                                                                                    ///
        ///     자동 저장 주기 시간(분) 조회 명령 패킷을 구성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 자동 저장 주기 시간(분) 조회 명령 패킷 </returns>                                    ///
        ///=========================================================================================================///
        /*static public byte[] ReadAutoDumpTime(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'D';
            Packet[8] = (byte)'A';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadManualBreak @                                                                                     ///
        ///     수동 정지 적용 여부 조회 명령 패킷을 구성하여 반환한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 수동 정지 적용 여부 조회 명령 패킷 </returns>                                        ///
        ///=========================================================================================================///
        static public byte[] ReadManualBreak(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'B';
            Packet[8] = (byte)'M';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadMaxLimitVoltage @                                                                                 ///
        ///     최대 제한 전압 조회 명령 패킷을 구성하여 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 최대 제한 전압 조회 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] ReadMaxLimitVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'M';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadMaxLimitRPM @                                                                                     ///
        ///     최대 제한 회전 속도 조회 명령 패킷을 구성하여 반환한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 최대 제한 회전 속도 조회 명령 패킷 </returns>                                        ///
        ///=========================================================================================================///
        static public byte[] ReadMaxLimitRPM(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'M';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadMaxLimitCurrent @                                                                                 ///
        ///     최대 제한 전류 조회 명령 패킷을 구성하여 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 최대 제한 전류 조회 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] ReadMaxLimitCurrent(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'M';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadLightOnVoltage @                                                                                  ///
        ///     전등의 점등 전압 조회 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 전등의 점등 전압 조회 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] ReadLightOnVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'N';
            Packet[8] = (byte)'L';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadLightOffVoltage @                                                                                 ///
        ///     전등의 소등 전압 조회 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 전등의 소등 전압 조회 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] ReadLightOffVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'F';
            Packet[8] = (byte)'L';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadOutputMode @                                                                                      ///
        ///     출력 모드 조회 명령 패킷을 구성하여 반환한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 출력 모드 조회 명령 패킷 </returns>                                                  ///
        ///=========================================================================================================///
        static public byte[] ReadOutputMode(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'M';
            Packet[8] = (byte)'O';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadDimmingOnDelay @                                                                                  ///
        ///     점등 지연 시간 조회 명령 패킷을 구성하여 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 점등 지연 시간 조회 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] ReadDimmingOnDelay(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'N';
            Packet[8] = (byte)'D';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadDelayOffTime @                                                                                    ///
        ///     소등 지연 시간 조회 명령 패킷을 구성하여 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 소등 지연 시간 조회 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        /*static public byte[] ReadDelayOffTime(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'F';
            Packet[8] = (byte)'D';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadBatteryKind @                                                                                     ///
        ///     배터리 종류 조회 명령 패킷을 구성하여 반환한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 배터리 종류 조회 명령 패킷 </returns>                                                ///
        ///=========================================================================================================///
        static public byte[] ReadBatteryKind(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'K';
            Packet[8] = (byte)'B';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadBatteryRatedCapacity @                                                                            ///
        ///     배터리 정격 용량 조회 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 배터리 정격 용량 조회 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] ReadBatteryRatedCapacity(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'B';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadFloatVoltage @                                                                                    ///
        ///     부동 전압 조회 명령 패킷을 구성하여 반환한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 부동 전압 조회 명령 패킷 </returns>                                                  ///
        ///=========================================================================================================///
        static public byte[] ReadFloatVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'F';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadLampCutoffVoltage @                                                                               ///
        ///     배터리 방전 방지 전압 조회 명령 패킷을 구성하여 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 배터리 방전 방지 전압 조회 명령 패킷 </returns>                                      ///
        ///=========================================================================================================///
        static public byte[] ReadLampCutoffVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'L';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadHighLimitVoltage @                                                                                ///
        ///     배터리 충전 중단 전압 조회 명령 패킷을 구성하여 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 배터리 충전 중단 전압 조회 명령 패킷 </returns>                                      ///
        ///=========================================================================================================///
        static public byte[] ReadHighLimitVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'F';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadLampRecoveryVoltage @                                                                             ///
        ///     배터리 전력 소모 재개 전압 조회 명령 패킷을 구성하여 반환한다.                                      ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 배터리 전력 소모 재개 전압 조회 명령 패킷 </returns>                                 ///
        ///=========================================================================================================///
        static public byte[] ReadLampRecoveryVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'L';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadFullRecoveryVoltage @                                                                             ///
        ///     배터리 충전 재개 전압 조회 명령 패킷을 구성하여 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 배터리 충전 재개 전압 조회 명령 패킷 </returns>                                      ///
        ///=========================================================================================================///
        /*static public byte[] ReadFullRecoveryVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'F';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadOverloadProtectVoltage @                                                                          ///
        ///     로드(LED Lamp)로의 공급 제한 전압 조회 명령 패킷을 구성하여 반환한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 로드(LED Lamp)로의 공급 제한 전압 조회 명령 패킷 </returns>                          ///
        ///=========================================================================================================///
        /*static public byte[] ReadOverloadProtectVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'O';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadOverloadRecoverVoltage @                                                                          ///
        ///     로드(LED Lamp)로의 공급 재개 전압 조회 명령 패킷을 구성하여 반환한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 로드(LED Lamp)로의 공급 재개 전압 조회 명령 패킷 </returns>                          ///
        ///=========================================================================================================///
        /*static public byte[] ReadOverloadRecoverVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'O';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadRTC @                                                                                             ///
        ///     RTC 정보를 조회 명령 패킷을 구성하여 반환한다.                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : RTC 정보를 조회 명령 패킷 </returns>                                                 ///
        ///=========================================================================================================///
        static public byte[] ReadRTC(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'T';
            Packet[8] = (byte)'R';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-29 ] ///
        /// @ ReadDisplayTime @                                                                                     ///
        ///     하이브리드 컨트롤러의 LCD 표시 시간의 조회 명령 패킷을 구성하여 반환한다.                           ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : LCD 표시 시간 조회 명령 패킷 </returns>                                              ///
        ///=========================================================================================================///
        static public byte[] ReadDisplayTime(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'T';
            Packet[8] = (byte)'D';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetMagneticPoleNumber @                                                                               ///
        ///     마그네틱 폴 번호 설정 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="num"> int : 마그네틱 폴 번호 </param>                                                      ///
        /// <returns> byte[] : 마그네틱 폴 번호 설정 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] SetMagneticPoleNumber(int gid, int nid, float poles)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            Data = BitConverter.GetBytes(poles);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'P';
            Packet[8] = (byte)'M';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetRPMControl @                                                                                       ///
        ///     RPM 제어 여부 설정 명령 패킷을 구성하여 반환한다.                                                   ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="set"> int : 설정(1) / 비설정(0) </param>                                                   ///
        /// <returns> byte[] : RPM 제어 여부 설정 명령 패킷 </returns>                                              ///
        ///=========================================================================================================///
        static public byte[] SetRPMControl(int gid, int nid, int set)
        {
            Packet = new byte[BaseLength + 1];

            Len_Pack = BitConverter.GetBytes(BaseLength + 1 - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'R';
            Packet[9] = (byte)set;
            Packet[12] = ETX1;
            Packet[13] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetRPMValue @                                                                                         ///
        ///     RPM 제어 값 설정 명령 패킷을 구성하여 반환한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="rpm"> int : RPM 값 </param>                                                                ///
        /// <returns> byte[] : RPM 제어 값 설정 명령 패킷 </returns>                                                ///
        ///=========================================================================================================///
        /*static public byte[] SetRPMValue(int gid, int nid, float rpm)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            Data = BitConverter.GetBytes(rpm);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'R';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetBoostStartVoltage @                                                                                ///
        ///     부스트 시작 전압 설정 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 부스트 볼트 </param>                                                        ///
        /// <returns> byte[] : 부스트 시작 전압 설정 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] SetBoostStartVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            Data = BitConverter.GetBytes(volt);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'S';
            Packet[8] = (byte)'B';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetAutoDumpTime @                                                                                     ///
        ///     자동 저장 주기 시간(분) 설정 명령 패킷을 구성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="min"> int : 시간(분) </param>                                                              ///
        /// <returns> byte[] : 자동 저장 주기 시간(분) 설정 명령 패킷 </returns>                                    ///
        ///=========================================================================================================///
        /*static public byte[] SetAutoDumpTime(int gid, int nid, float min)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            Data = BitConverter.GetBytes(min);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'D';
            Packet[8] = (byte)'A';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetManualBreak @                                                                                      ///
        ///     수동 정지 적용 여부 설정 명령 패킷을 구성하여 반환한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="set"> int : 설정(1) / 비설정(0) </param>                                                   ///
        /// <returns> byte[] : 수동 정지 적용 여부 설정 명령 패킷 </returns>                                        ///
        ///=========================================================================================================///
        static public byte[] SetManualBreak(int gid, int nid, int set)
        {
            Packet = new byte[BaseLength + 1];

            Len_Pack = BitConverter.GetBytes(BaseLength + 1 - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'B';
            Packet[8] = (byte)'M';
            Packet[9] = (byte)set;
            Packet[12] = ETX1;
            Packet[13] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetMaxLimitVoltage @                                                                                  ///
        ///     최대 제한 전압 조회 설정 패킷을 구성하여 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> int : 최대 제한 전압 </param>                                                       ///
        /// <returns> byte[] : 최대 제한 전압 설정 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] SetMaxLimitVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'M';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetMaxLimitRPM @                                                                                      ///
        ///     최대 제한 회전 속도 설정 명령 패킷을 구성하여 반환한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="rotate"> int : 최대 제한 회전 속도 </param>                                                ///
        /// <returns> byte[] : 최대 제한 회전 속도 설정 명령 패킷 </returns>                                        ///
        ///=========================================================================================================///
        static public byte[] SetMaxLimitRPM(int gid, int nid, float rotate)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(rotate);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'M';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetMaxLimitCurrent @                                                                                  ///
        ///     최대 제한 전류 설정 명령 패킷을 구성하여 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="current"> int : 최대 제한 전류 </param>                                                    ///
        /// <returns> byte[] : 최대 제한 전류 설정 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] SetMaxLimitCurrent(int gid, int nid, float current)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(current);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'M';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetLightOnVoltage @                                                                                   ///
        ///     전등의 점등 전압 설정 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 설정 전압 </param>                                                          ///
        /// <returns> byte[] : 전등의 점등 전압 설정 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] SetLightOnVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'N';
            Packet[8] = (byte)'L';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetLightOffVoltage @                                                                                  ///
        ///     전등의 소등 전압 설정 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 설정 전압 </param>                                                          ///
        /// <returns> byte[] : 전등의 소등 전압 설정 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] SetLightOffVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'F';
            Packet[8] = (byte)'L';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetOutputMode @                                                                                       ///
        ///     출력 모드 설정 명령 패킷을 구성하여 반환한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="mode"> int : 출력 모드 </param>                                                            ///
        /// <returns> byte[] : 출력 모드 설정 명령 패킷 </returns>                                                  ///
        ///=========================================================================================================///
        static public byte[] SetOutputMode(int gid, int nid, int mode)
        {
            Packet = new byte[BaseLength + 1];

            Len_Pack = BitConverter.GetBytes(BaseLength + 1 - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'M';
            Packet[8] = (byte)'O';
            Packet[9] = (byte)mode;
            Packet[12] = ETX1;
            Packet[13] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetDimmingOnDelay @                                                                                   ///
        ///     점등 지연 시간 설정 명령 패킷을 구성하여 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="hour"> int : 설정 시간(시) </param>                                                        ///
        /// <returns> byte[] : 점등 지연 시간 설정 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] SetDimmingOnDelay(int gid, int nid, int hour)
        {
            Packet = new byte[BaseLength + 1];

            Len_Pack = BitConverter.GetBytes(BaseLength + 1 - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'N';
            Packet[8] = (byte)'D';
            Packet[9] = (byte)hour;
            Packet[12] = ETX1;
            Packet[13] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetDelayOffTime @                                                                                     ///
        ///     소등 지연 시간 설정 명령 패킷을 구성하여 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="hour"> int : 설정 시간(시) </param>                                                        ///
        /// <returns> byte[] : 소등 지연 시간 설정 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        /*static public byte[] SetDelayOffTime(int gid, int nid, int hour)
        {
            Packet = new byte[BaseLength + 1];

            Len_Pack = BitConverter.GetBytes(BaseLength + 1 - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'F';
            Packet[8] = (byte)'D';
            Packet[9] = (byte)hour;
            Packet[12] = ETX1;
            Packet[13] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetBatteryKint @                                                                                      ///
        ///     배터리 종류 설정 명령 패킷을 구성하여 반환한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="kind"> int : 배터리 종류 </param>                                                          ///
        /// <returns> byte[] : 배터리 종류 설정 명령 패킷 </returns>                                                ///
        ///=========================================================================================================///
        static public byte[] SetBatteryKind(int gid, int nid, int kind)
        {
            Packet = new byte[BaseLength + 1];

            Len_Pack = BitConverter.GetBytes(BaseLength + 1 - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'K';
            Packet[8] = (byte)'B';
            Packet[9] = (byte)kind;
            Packet[12] = ETX1;
            Packet[13] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetBatteryRatedCapacity @                                                                             ///
        ///     배터리 정격 용량 설정 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="capacity"> float : 설정 용량 </param>                                                      ///
        /// <returns> byte[] : 배터리 정격 용량 설정 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] SetBatteryRatedCapacity(int gid, int nid, float capacity)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(capacity);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'B';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetFloatVoltage @                                                                                     ///
        ///     부동 전압 설정 명령 패킷을 구성하여 반환한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 설정 전압 </param>                                                          ///
        /// <returns> byte[] : 부동 전압 설정 명령 패킷 </returns>                                                  ///
        ///=========================================================================================================///
        static public byte[] SetFloatVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'F';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetLampCutoffVoltage @                                                                                ///
        ///     램프 과전압 방지 전압 설정 명령 패킷을 구성하여 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 설정 전압 </param>                                                          ///
        /// <returns> byte[] : 램프 과전압 방지 전압 설정 명령 패킷 </returns>                                      ///
        ///=========================================================================================================///
        static public byte[] SetLampCutoffVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'L';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetHighLimitVoltage @                                                                                 ///
        ///     배터리 과충전 방지 전압 설정 명령 패킷을 구성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 설정 전압 </param>                                                          ///
        /// <returns> byte[] : 배터리 과충전 방지 전압 설정 명령 패킷 </returns>                                    ///
        ///=========================================================================================================///
        static public byte[] SetHighLimitVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'F';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetLampRecoveryVoltage @                                                                              ///
        ///     램프 전류 공급 재개 전압 조회 명령 패킷을 구성하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 설정 전압 </param>                                                          ///
        /// <returns> byte[] : 배터리 전류 공급 재개 전압 조회 명령 패킷 </returns>                                 ///
        ///=========================================================================================================///
        static public byte[] SetLampRecoveryVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'L';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ ReadFullRecoveryVoltage @                                                                             ///
        ///     배터리 충전 재개 전압 설정 명령 패킷을 구성하여 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 설정 전압 </param>                                                          ///
        /// <returns> byte[] : 배터리 충전 재개 전압 설정 명령 패킷 </returns>                                      ///
        ///=========================================================================================================///
        /*static public byte[] SetFullRecoveryVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'F';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetOverloadProtectVoltage @                                                                           ///
        ///     로드(LED Lamp)로의 공급 제한 전압 설정 명령 패킷을 구성하여 반환한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 설정 전압 </param>                                                          ///
        /// <returns> byte[] : 로드(LED Lamp)로의 공급 제한 전압 설정 명령 패킷 </returns>                          ///
        ///=========================================================================================================///
        /*static public byte[] SetOverloadProtectVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'O';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetOverloadRecoveryVoltage @                                                                          ///
        ///     로드(LED Lamp)로의 공급 재개 전압 설정 명령 패킷을 구성하여 반환한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 설정 전압 </param>                                                          ///
        /// <returns> byte[] : 로드(LED Lamp)로의 공급 재개 전압 설정 명령 패킷 </returns>                          ///
        ///=========================================================================================================///
        /*static public byte[] SetOverloadRecoveryVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'O';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-23 ] ///
        /// @ SetRTC @                                                                                              ///
        ///     RTC 정보를 설정 명령 패킷을 구성하여 반환한다.                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="rtc"> DateTime : 설정 RTC 시간 </param>                                                    ///
        /// <returns> byte[] : RTC 정보를 설정 명령 패킷 </returns>                                                 ///
        ///=========================================================================================================///
        static public byte[] SetRTC(int gid, int nid, DateTime rtc)
        {
            Packet = new byte[BaseLength + 14];

            Len_Pack = BitConverter.GetBytes(BaseLength + 14 - 3);
            NodeID = BitConverter.GetBytes(nid);

            int year = rtc.Year;
            int mon = rtc.Month;
            int day = rtc.Day;
            int hour = rtc.Hour;
            int min = rtc.Minute;
            int sec = rtc.Second;

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'T';
            Packet[8] = (byte)'R';
            Packet[9] = (byte)((year / 1000) + '0');
            Packet[10] = (byte)(((year / 100) % 10) + '0');
            Packet[11] = (byte)(((year / 10) % 100) + '0');
            Packet[12] = (byte)((year % 10) + '0');
            Packet[13] = (byte)((mon / 10) + '0');
            Packet[14] = (byte)((mon % 10) + '0');
            Packet[15] = (byte)((day / 10) + '0');
            Packet[16] = (byte)((day % 10) + '0');
            Packet[17] = (byte)((hour / 10) + '0');
            Packet[18] = (byte)((hour % 10) + '0');
            Packet[19] = (byte)((min / 10) + '0');
            Packet[20] = (byte)((min % 10) + '0');
            Packet[21] = (byte)((sec / 10) + '0');
            Packet[22] = (byte)((sec % 10) + '0');
            Packet[25] = ETX1;
            Packet[26] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-29 ] ///
        /// @ SetDisplayTime @                                                                                      ///
        ///     하이브리드 컨트롤러의 LCD 표시 시간 설정 명령 패킷을 구성하여 반환한다.                             ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="time"> float : 표시 시간 (초 단위) </param>                                                ///
        /// <returns> byte[] : LCD 표시 시간 설정 명령 패킷 </returns>                                              ///
        ///=========================================================================================================///
        static public byte[] SetDisplayTime(int gid, int nid, float time)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(time);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'T';
            Packet[8] = (byte)'D';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-07-21 ] ///
        /// @ WindChargeSwitch @                                                                                    ///
        ///     풍력 발전을 통한 배터리 충전 여부를 설정하는 명령 패킷을 구성하여 반환한다.                         ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="set"> bool : 배터리 충전 여부 </param>                                                     ///
        /// <returns> byte[] : 풍력 발전 배터리 충전 여부 설정 명령 패킷 </returns>                                 ///
        ///=========================================================================================================///
        static public byte[] SetWindChargeSwitch(int gid, int nid, bool set)
        {
            Packet = new byte[BaseLength + 1];

            Len_Pack = BitConverter.GetBytes(BaseLength + 1 - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'W';
            Packet[9] = Convert.ToByte(set);
            Packet[12] = ETX1;
            Packet[13] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-07-21 ] ///
        /// @ SolarChargeSwitch @                                                                                   ///
        ///     태양광 발전을 통한 배터리 충전 여부를 설정하는 명령 패킷을 구성하여 반환한다.                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="set"> bool : 배터리 충전 여부 </param>                                                     ///
        /// <returns> byte[] : 태양광 발전 배터리 충전 여부 설정 명령 패킷 </returns>                               ///
        ///=========================================================================================================///
        static public byte[] SetSolarChargeSwitch(int gid, int nid, bool set)
        {
            Packet = new byte[BaseLength + 1];

            Len_Pack = BitConverter.GetBytes(BaseLength + 1 - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'S';
            Packet[9] = Convert.ToByte(set);
            Packet[12] = ETX1;
            Packet[13] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-07-21 ] ///
        /// @ LampSwitch @                                                                                          ///
        ///     램프(로드) 전원 On/Off를 설정하는 명령 패킷을 구성하여 반환한다.                                    ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="set"> bool : 전원 On/Off 여부 </param>                                                     ///
        /// <returns> byte[] : 램프(로드) 전원 On/Off 설정 명령 패킷 </returns>                                     ///
        ///=========================================================================================================///
        static public byte[] SetLampSwitch(int gid, int nid, bool set)
        {
            Packet = new byte[BaseLength + 1];

            Len_Pack = BitConverter.GetBytes(BaseLength + 1 - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'P';
            Packet[8] = (byte)'L';
            Packet[9] = Convert.ToByte(set);
            Packet[12] = ETX1;
            Packet[13] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-07-21 ] ///
        /// @ ClearTotalPower @                                                                                     ///
        ///     컨트롤러에 저장되어 있는 발전량 정보 초기화 명령 패킷을 구성하여 반환한다.                          ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 발전량 정보 초기화 명령 패킷 </returns>                                              ///
        ///=========================================================================================================///
        static public byte[] ClearTotalPower(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'P';
            Packet[8] = (byte)'C';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2014-08-01 ] ///
        /// @ SolarHistory @                                                                                        ///
        ///     태양광 발전 이력 조회 명령 패킷을 구성하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="day"> DateTime : 이력 조회 일자 </param>                                                   ///
        /// <param name="time"> DateTime : 이력 조회 시각 </param>                                                  ///
        /// <returns> byte[] : 발전량 이력 조회 명령 패킷 </returns>                                                ///
        ///=========================================================================================================///
        static public byte[] SolarHistory(int gid, int nid, DateTime date, DateTime time, int gap)
        {
            Packet = new byte[BaseLength + 15];

            Len_Pack = BitConverter.GetBytes(BaseLength + 15 - 3);
            NodeID = BitConverter.GetBytes(nid);

            int year = date.Year;
            int mon = date.Month;
            int day = date.Day;
            int hour = time.Hour;
            int min = time.Minute;
            int sec = time.Second;

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'H';
            Packet[8] = (byte)'S';
            Packet[9] = Convert.ToByte(gap);
            Packet[10] = (byte)((year / 1000) + '0');
            Packet[11] = (byte)(((year / 100) % 10) + '0');
            Packet[12] = (byte)(((year / 10) % 100) + '0');
            Packet[13] = (byte)((year % 10) + '0');
            Packet[14] = (byte)((mon / 10) + '0');
            Packet[15] = (byte)((mon % 10) + '0');
            Packet[16] = (byte)((day / 10) + '0');
            Packet[17] = (byte)((day % 10) + '0');
            Packet[18] = (byte)((hour / 10) + '0');
            Packet[19] = (byte)((hour % 10) + '0');
            Packet[20] = (byte)((min / 10) + '0');
            Packet[21] = (byte)((min % 10) + '0');
            Packet[22] = (byte)((sec / 10) + '0');
            Packet[23] = (byte)((sec % 10) + '0');
            Packet[26] = ETX1;
            Packet[27] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2014-08-01 ] ///
        /// @ WindHistory @                                                                                         ///
        ///     풍력 발전 이력 조회 명령 패킷을 구성하여 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="day"> DateTime : 이력 조회 일자 </param>                                                   ///
        /// <param name="time"> DateTime : 이력 조회 시각 </param>                                                  ///
        /// <returns> byte[] : 발전량 이력 조회 명령 패킷 </returns>                                                ///
        ///=========================================================================================================///
        static public byte[] WindHistory(int gid, int nid, DateTime date, DateTime time, int gap)
        {
            Packet = new byte[BaseLength + 15];

            Len_Pack = BitConverter.GetBytes(BaseLength + 15 - 3);
            NodeID = BitConverter.GetBytes(nid);

            int year = date.Year;
            int mon = date.Month;
            int day = date.Day;
            int hour = time.Hour;
            int min = time.Minute;
            int sec = time.Second;

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'H';
            Packet[8] = (byte)'S';
            Packet[9] = Convert.ToByte(gap);
            Packet[10] = (byte)((year / 1000) + '0');
            Packet[11] = (byte)(((year / 100) % 10) + '0');
            Packet[12] = (byte)(((year / 10) % 100) + '0');
            Packet[13] = (byte)((year % 10) + '0');
            Packet[14] = (byte)((mon / 10) + '0');
            Packet[15] = (byte)((mon % 10) + '0');
            Packet[16] = (byte)((day / 10) + '0');
            Packet[17] = (byte)((day % 10) + '0');
            Packet[18] = (byte)((hour / 10) + '0');
            Packet[19] = (byte)((hour % 10) + '0');
            Packet[20] = (byte)((min / 10) + '0');
            Packet[21] = (byte)((min % 10) + '0');
            Packet[22] = (byte)((sec / 10) + '0');
            Packet[23] = (byte)((sec % 10) + '0');
            Packet[26] = ETX1;
            Packet[27] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }
        #endregion

        #region [ # Ver 1.03 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2014-08-05 ] ///
        /// @ PWM @                                                                                                 ///
        ///     램프 밝기 조절 명령 패킷을 구성하여 반환한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="percent"> float : 밝기 비율 </param>                                                       ///
        /// <returns> byte[] : 밝기 조절 명령 패킷 </returns>                                                       ///
        ///=========================================================================================================///
        static public byte[] SetPWM(int gid, int nid, float percent)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(percent);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'W';
            Packet[8] = (byte)'P';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2014-08-05 ] ///
        /// @ ReadPWM @                                                                                             ///
        ///     램프 밝기 정보를 조회하는 명령 패킷을 구성하여 반환한다.                                            ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 밝기 조회 명령 패킷 </returns>                                                       ///
        ///=========================================================================================================///
        static public byte[] ReadPWM(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'W';
            Packet[8] = (byte)'P';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2014-08-06 ] ///
        /// @ TransFile @                                                                                           ///
        ///     매개변수로 지정된 일자의 데이터 파일 전송 명령 패킷을 구성하여 반환한다.                            ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="date"> DateTime : 일자 </param>                                                            ///
        /// <returns> byte[] : 데이터 파일 전송 명령 패킷 </returns>                                                ///
        ///=========================================================================================================///
        static public byte[] TransFile(int gid, int nid, DateTime date)
        {
            Packet = new byte[BaseLength + 14];

            Len_Pack = BitConverter.GetBytes(BaseLength + 14 - 3);
            NodeID = BitConverter.GetBytes(nid);

            int year = date.Year;
            int mon = date.Month;
            int day = date.Day;
            int hour = date.Hour;
            int min = date.Minute;
            int sec = date.Second;

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'T';
            Packet[8] = (byte)'F';
            Packet[9] = (byte)((year / 1000) + '0');
            Packet[10] = (byte)(((year / 100) % 10) + '0');
            Packet[11] = (byte)(((year / 10) % 100) + '0');
            Packet[12] = (byte)((year % 10) + '0');
            Packet[13] = (byte)((mon / 10) + '0');
            Packet[14] = (byte)((mon % 10) + '0');
            Packet[15] = (byte)((day / 10) + '0');
            Packet[16] = (byte)((day % 10) + '0');
            Packet[17] = (byte)((hour / 10) + '0');
            Packet[18] = (byte)((hour % 10) + '0');
            Packet[19] = (byte)((min / 10) + '0');
            Packet[20] = (byte)((min % 10) + '0');
            Packet[21] = (byte)((sec / 10) + '0');
            Packet[22] = (byte)((sec % 10) + '0');
            Packet[25] = ETX1;
            Packet[26] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2014-08-06 ] ///
        /// @ FileSize @                                                                                            ///
        ///     데이터 파일의 크기 정보를 조회하는 명령 패킷을 구성하여 반환한다.                                   ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="date"> DateTime : 일자 </param>                                                            ///
        /// <returns> byte[] : 데이터 파일 크기 정보 조회 명령 패킷 </returns>                                      ///
        ///=========================================================================================================///
        static public byte[] FileSize(int gid, int nid, DateTime date)
        {
            Packet = new byte[BaseLength + 14];

            Len_Pack = BitConverter.GetBytes(BaseLength + 14 - 3);
            NodeID = BitConverter.GetBytes(nid);

            int year = date.Year;
            int mon = date.Month;
            int day = date.Day;
            int hour = date.Hour;
            int min = date.Minute;
            int sec = date.Second;

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'S';
            Packet[8] = (byte)'F';
            Packet[9] = (byte)((year / 1000) + '0');
            Packet[10] = (byte)(((year / 100) % 10) + '0');
            Packet[11] = (byte)(((year / 10) % 100) + '0');
            Packet[12] = (byte)((year % 10) + '0');
            Packet[13] = (byte)((mon / 10) + '0');
            Packet[14] = (byte)((mon % 10) + '0');
            Packet[15] = (byte)((day / 10) + '0');
            Packet[16] = (byte)((day % 10) + '0');
            Packet[17] = (byte)((hour / 10) + '0');
            Packet[18] = (byte)((hour % 10) + '0');
            Packet[19] = (byte)((min / 10) + '0');
            Packet[20] = (byte)((min % 10) + '0');
            Packet[21] = (byte)((sec / 10) + '0');
            Packet[22] = (byte)((sec % 10) + '0');
            Packet[25] = ETX1;
            Packet[26] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }
        #endregion

        #region [ # Ver 1.04 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2014-08-27 ] ///
        /// @ ReadTurnOffTime @                                                                                     ///
        ///     램프 소등 시각 정보를 조회하는 명령 패킷을 구성하여 반환한다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 램프 소등 시각 정보 조회 명령 패킷 </returns>                                        ///
        ///=========================================================================================================///
        static public byte[] ReadTurnOffTime(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'F';
            Packet[8] = (byte)'T';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2014-08-27 ] ///
        /// @ ReadTurnOnTime @                                                                                      ///
        /// </summary>                                                                                              ///
        ///     램프 점등 시각 정보를 조회하는 명령 패킷을 구성하여 반환한다.                                       ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 램프 점등 시각 정보 조회 명령 패킷 </returns>                                        ///
        ///=========================================================================================================///
        static public byte[] ReadTurnOnTime(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'N';
            Packet[8] = (byte)'T';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2014-08-27 ] ///
        /// @ SetTurnOffTime @                                                                                      ///
        ///     램프 소등 시각 정보를 조회하는 명령 패킷을 구성하여 반환한다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="time"> DateTime : 램프 소등 시각 </param>                                                  ///
        /// <returns> byte[] : 램프 소등 시각 설정 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] SetTurnOffTime(int gid, int nid, DateTime date)
        {
            Packet = new byte[BaseLength + 6];

            Len_Pack = BitConverter.GetBytes(BaseLength + 6 - 3);
            NodeID = BitConverter.GetBytes(nid);

            int hour = date.Hour;
            int min = date.Minute;
            int sec = date.Second;

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'F';
            Packet[8] = (byte)'T';
            Packet[9] = (byte)((hour / 10) + '0');
            Packet[10] = (byte)((hour % 10) + '0');
            Packet[11] = (byte)((min / 10) + '0');
            Packet[12] = (byte)((min % 10) + '0');
            Packet[13] = (byte)((sec / 10) + '0');
            Packet[14] = (byte)((sec % 10) + '0');
            Packet[17] = ETX1;
            Packet[18] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2014-08-27 ] ///
        /// @ SetTurnOnTime @                                                                                       ///
        ///     램프 점등 시각 정보를 조회하는 명령 패킷을 구성하여 반환한다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="time"> DateTime : 램프 점등 시각 </param>                                                  ///
        /// <returns> byte[] : 램프 점등 시각 설정 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] SetTurnOnTime(int gid, int nid, DateTime date)
        {
            Packet = new byte[BaseLength + 6];

            Len_Pack = BitConverter.GetBytes(BaseLength + 6 - 3);
            NodeID = BitConverter.GetBytes(nid);

            int hour = date.Hour;
            int min = date.Minute;
            int sec = date.Second;

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'N';
            Packet[8] = (byte)'T';
            Packet[9] = (byte)((hour / 10) + '0');
            Packet[10] = (byte)((hour % 10) + '0');
            Packet[11] = (byte)((min / 10) + '0');
            Packet[12] = (byte)((min % 10) + '0');
            Packet[13] = (byte)((sec / 10) + '0');
            Packet[14] = (byte)((sec % 10) + '0');
            Packet[17] = ETX1;
            Packet[18] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2014-08-27 ] ///
        /// @ ReadWindChargeSwitch @                                                                                ///
        ///     풍력 발전 충전 여부를 조회하는 명령 패킷을 구성하여 반환한다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 풍력 발전 여부 조회 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] ReadWindChargeSwitch(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'W';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2014-08-27 ] ///
        /// @ ReadSolarChargeSwitch @                                                                               ///
        ///     태양광 발전 충전 여부를 조회하는 명령 패킷을 구성하여 반환한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 태양광 발전 여부 조회 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] ReadSolarChargeSwitch(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'C';
            Packet[8] = (byte)'S';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2014-08-27 ] ///
        /// @ ReadLampSwitch @                                                                                      ///
        ///     램프 점등 여부를 조회하는 명령 패킷을 구성하여 반환한다.                                            ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 램프 점등 여부 조회 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] ReadLampSwitch(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'P';
            Packet[8] = (byte)'L';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2014-08-27 ] ///
        /// @ ReadFirmwareVersion @                                                                                 ///
        ///     컨트롤러의 펌웨어 버전을 조회하는 명령 패킷을 구성하여 반환한다.                                    ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 컨트롤러 펌웨어 조회 명령 패킷 </returns>                                            ///
        ///=========================================================================================================///
        static public byte[] ReadFirmwareVersion(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'C';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2014-08-27 ] ///
        /// @ ReadLampRatedCurrent @                                                                                ///
        ///     램프의 정격 전류 정보를 조회하는 명령 패킷을 구성하여 반환한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 램프 정격 전류 조회 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] ReadLampRatedCurrent(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'W';
            Packet[8] = (byte)'L';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2014-08-27 ] ///
        /// @ SetLampRatedCurrent @                                                                                 ///
        ///     램프의 정격 전류 정보를 설정하는 명령 패킷을 구성하여 반환한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="current"> float : 램프 정격 전류 </param>                                                  ///
        /// <returns> byte[] : 램프 정격 전류 설정 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] SetLampRatedCurrent(int gid, int nid, float current)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(current);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'W';
            Packet[8] = (byte)'L';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }
        #endregion

        #region [ # Ver 1.05 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.05 / 2014-10-02 ] ///
        /// @ ReadAllData @                                                                                         ///
        ///     컨트롤러에 조회 가능한 모든 데이터를 조회하는 명령 패킷을 구성하여 반환한다.                        ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 배터리 전압 조회 명령 패킷 </returns>                                                ///
        ///=========================================================================================================///
        static public byte[] ReadAllData(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'A';
            Packet[8] = (byte)'D';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.05 / 2014-11-13 ] ///
        /// @ ReadAllOffsets @                                                                                      ///
        ///     하이브리드 컨트롤러에 설정된 모든 Offset 정보를 조회하는 명령 패킷을 구성하여 반환한다.             ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : Offset 조회 명령 패킷 </returns>                                                     ///
        ///=========================================================================================================///
        static public byte[] ReadAllOffsets(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'A';
            Packet[8] = (byte)'F';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.05 / 2014-11-13 ] ///
        /// @ SetAllOffsets @                                                                                       ///
        ///     하이브리드 컨트롤러에 모든 Offset 정보를 설정하는 명령 패킷을 구성하여 반환한다.                    ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="offsets"> float[] : Offset 정보 </param>                                                   ///
        /// <returns> byte[] : Offset 설정 명령 패킷 </returns>                                                     ///
        ///=========================================================================================================///
        /*static public byte[] SetAllOffsets(int gid, int nid, float[] offsets)
        {
            if (offsets.Length < 8)
            {
                Packet = new byte[0];
            }
            else
            {
                Packet = new byte[BaseLength + 32];

                Len_Pack = BitConverter.GetBytes(BaseLength + 32 - 3);
                NodeID = BitConverter.GetBytes(nid);

                Packet[0] = STX;
                Packet[1] = Len_Pack[0];
                Packet[2] = Len_Pack[1];
                Packet[3] = Convert.ToByte(gid);
                Packet[4] = NodeID[0];
                Packet[5] = NodeID[1];
                Packet[6] = (byte)'Q';
                Packet[7] = (byte)'A';
                Packet[8] = (byte)'F';

                Data = BitConverter.GetBytes(offsets[0]);
                Packet[9] = Data[3];
                Packet[10] = Data[2];
                Packet[11] = Data[1];
                Packet[12] = Data[0];

                Data = BitConverter.GetBytes(offsets[1]);
                Packet[13] = Data[3];
                Packet[14] = Data[2];
                Packet[15] = Data[1];
                Packet[16] = Data[0];

                Data = BitConverter.GetBytes(offsets[2]);
                Packet[17] = Data[3];
                Packet[18] = Data[2];
                Packet[19] = Data[1];
                Packet[20] = Data[0];

                Data = BitConverter.GetBytes(offsets[3]);
                Packet[21] = Data[3];
                Packet[22] = Data[2];
                Packet[23] = Data[1];
                Packet[24] = Data[0];

                Data = BitConverter.GetBytes(offsets[4]);
                Packet[25] = Data[3];
                Packet[26] = Data[2];
                Packet[27] = Data[1];
                Packet[28] = Data[0];

                Data = BitConverter.GetBytes(offsets[5]);
                Packet[29] = Data[3];
                Packet[30] = Data[2];
                Packet[31] = Data[1];
                Packet[32] = Data[0];

                Data = BitConverter.GetBytes(offsets[6]);
                Packet[33] = Data[3];
                Packet[34] = Data[2];
                Packet[35] = Data[1];
                Packet[36] = Data[0];

                Data = BitConverter.GetBytes(offsets[7]);
                Packet[37] = Data[3];
                Packet[38] = Data[2];
                Packet[39] = Data[1];
                Packet[40] = Data[0];

                Packet[43] = ETX1;
                Packet[44] = ETX2;

                CommonBase.SetCRC16(Packet, 2);
            }

            return Packet;
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.05 / 2014-11-13 ] ///
        /// @ SetBattOffsets @                                                                                      ///
        ///     하이브리드 컨트롤러의 Battery 전압, 전류의 Offset 정보를 설정 하는 명령 패킷을 구성하여 반환한다.   ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="offsets"> float[] : Offset 정보 </param>                                                   ///
        /// <returns> byte[] : Offset 설정 명령 패킷 </returns>                                                     ///
        ///=========================================================================================================///
        static public byte[] SetBattOffsets(int gid, int nid, float[] offsets)
        {
            if (offsets.Length < 2)
            {
                Packet = new byte[0];
            }
            else
            {
                Packet = new byte[BaseLength + 8];

                Len_Pack = BitConverter.GetBytes(BaseLength + 8 - 3);
                NodeID = BitConverter.GetBytes(nid);

                Packet[0] = STX;
                Packet[1] = Len_Pack[0];
                Packet[2] = Len_Pack[1];
                Packet[3] = Convert.ToByte(gid);
                Packet[4] = NodeID[0];
                Packet[5] = NodeID[1];
                Packet[6] = (byte)'Q';
                Packet[7] = (byte)'B';
                Packet[8] = (byte)'F';

                Data = BitConverter.GetBytes(offsets[4]);
                Packet[9] = Data[3];
                Packet[10] = Data[2];
                Packet[11] = Data[1];
                Packet[12] = Data[0];

                Data = BitConverter.GetBytes(offsets[5]);
                Packet[13] = Data[3];
                Packet[14] = Data[2];
                Packet[15] = Data[1];
                Packet[16] = Data[0];

                Packet[19] = ETX1;
                Packet[20] = ETX2;

                CommonBase.SetCRC16(Packet, 2);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.05 / 2014-11-13 ] ///
        /// @ SetLampOffsets @                                                                                      ///
        ///     하이브리드 컨트롤러의 Lamp 전압, 전류의 Offset 정보를 설정 하는 명령 패킷을 구성하여 반환한다.      ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="offsets"> float[] : Offset 정보 </param>                                                   ///
        /// <returns> byte[] : Offset 설정 명령 패킷 </returns>                                                     ///
        ///=========================================================================================================///
        static public byte[] SetLampOffsets(int gid, int nid, float[] offsets)
        {
            if (offsets.Length < 2)
            {
                Packet = new byte[0];
            }
            else
            {
                Packet = new byte[BaseLength + 8];

                Len_Pack = BitConverter.GetBytes(BaseLength + 8 - 3);
                NodeID = BitConverter.GetBytes(nid);

                Packet[0] = STX;
                Packet[1] = Len_Pack[0];
                Packet[2] = Len_Pack[1];
                Packet[3] = Convert.ToByte(gid);
                Packet[4] = NodeID[0];
                Packet[5] = NodeID[1];
                Packet[6] = (byte)'Q';
                Packet[7] = (byte)'L';
                Packet[8] = (byte)'F';

                Data = BitConverter.GetBytes(offsets[6]);
                Packet[9] = Data[3];
                Packet[10] = Data[2];
                Packet[11] = Data[1];
                Packet[12] = Data[0];

                Data = BitConverter.GetBytes(offsets[7]);
                Packet[13] = Data[3];
                Packet[14] = Data[2];
                Packet[15] = Data[1];
                Packet[16] = Data[0];

                Packet[19] = ETX1;
                Packet[20] = ETX2;

                CommonBase.SetCRC16(Packet, 2);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.05 / 2014-11-13 ] ///
        /// @ SetSolarOffsets @                                                                                     ///
        ///     하이브리드 컨트롤러의 Solar 전압, 전류의 Offset 정보를 설정 하는 명령 패킷을 구성하여 반환한다.     ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="offsets"> float[] : Offset 정보 </param>                                                   ///
        /// <returns> byte[] : Offset 설정 명령 패킷 </returns>                                                     ///
        ///=========================================================================================================///
        static public byte[] SetSolarOffsets(int gid, int nid, float[] offsets)
        {
            if (offsets.Length < 2)
            {
                Packet = new byte[0];
            }
            else
            {
                Packet = new byte[BaseLength + 8];

                Len_Pack = BitConverter.GetBytes(BaseLength + 8 - 3);
                NodeID = BitConverter.GetBytes(nid);

                Packet[0] = STX;
                Packet[1] = Len_Pack[0];
                Packet[2] = Len_Pack[1];
                Packet[3] = Convert.ToByte(gid);
                Packet[4] = NodeID[0];
                Packet[5] = NodeID[1];
                Packet[6] = (byte)'Q';
                Packet[7] = (byte)'S';
                Packet[8] = (byte)'F';

                Data = BitConverter.GetBytes(offsets[0]);
                Packet[9] = Data[3];
                Packet[10] = Data[2];
                Packet[11] = Data[1];
                Packet[12] = Data[0];

                Data = BitConverter.GetBytes(offsets[1]);
                Packet[13] = Data[3];
                Packet[14] = Data[2];
                Packet[15] = Data[1];
                Packet[16] = Data[0];

                Packet[19] = ETX1;
                Packet[20] = ETX2;

                CommonBase.SetCRC16(Packet, 2);
            }

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.05 / 2014-11-13 ] ///
        /// @ SetWindOffsets @                                                                                      ///
        ///     하이브리드 컨트롤러의 Wind 전압, 전류의 Offset 정보를 설정 하는 명령 패킷을 구성하여 반환한다.      ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="offsets"> float[] : Offset 정보 </param>                                                   ///
        /// <returns> byte[] : Offset 설정 명령 패킷 </returns>                                                     ///
        ///=========================================================================================================///
        static public byte[] SetWindOffsets(int gid, int nid, float[] offsets)
        {
            if (offsets.Length < 2)
            {
                Packet = new byte[0];
            }
            else
            {
                Packet = new byte[BaseLength + 8];

                Len_Pack = BitConverter.GetBytes(BaseLength + 8 - 3);
                NodeID = BitConverter.GetBytes(nid);

                Packet[0] = STX;
                Packet[1] = Len_Pack[0];
                Packet[2] = Len_Pack[1];
                Packet[3] = Convert.ToByte(gid);
                Packet[4] = NodeID[0];
                Packet[5] = NodeID[1];
                Packet[6] = (byte)'Q';
                Packet[7] = (byte)'W';
                Packet[8] = (byte)'F';

                Data = BitConverter.GetBytes(offsets[2]);
                Packet[9] = Data[3];
                Packet[10] = Data[2];
                Packet[11] = Data[1];
                Packet[12] = Data[0];

                Data = BitConverter.GetBytes(offsets[3]);
                Packet[13] = Data[3];
                Packet[14] = Data[2];
                Packet[15] = Data[1];
                Packet[16] = Data[0];

                Packet[19] = ETX1;
                Packet[20] = ETX2;

                CommonBase.SetCRC16(Packet, 2);
            }

            return Packet;
        }
        #endregion

        #region [ # Ver 1.06 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.06 / 2014-12-01 ] ///
        /// @ SetLowLimitVoltage @                                                                                  ///
        ///     배터리 방전 방지 전압 설정 명령 패킷을 구성하여 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 설정 Voltage 값 </param>                                                    ///
        /// <returns> byte[] : 배터리 방전 방지 전압 설정 명령 패킷 </returns>                                      ///
        ///=========================================================================================================///
        static public byte[] SetLowLimitVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'L';
            Packet[8] = (byte)'B';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.06 / 2014-12-01 ] ///
        /// @ ReadLowLimitVoltage @                                                                                 ///
        ///     배터리 Low Cutoff Voltage 조회 명령 패킷을 구성하여 반환한다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 배터리 Low Cutoff Voltage 조회 명령 패킷 </returns>                                  ///
        ///=========================================================================================================///
        static public byte[] ReadLowLimitVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'L';
            Packet[8] = (byte)'B';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }
        #endregion

        #region [ # Ver 1.07 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ ReadHardwareVersion @                                                                                 ///
        ///     컨트롤러의 하드웨어 버전 조회 명령 패킷을 구성하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 하드웨어 버전 조회 명령 패킷 </returns>                                              ///
        ///=========================================================================================================///
        static public byte[] ReadHardwareVersion(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'H';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ ReadProductDate @                                                                                     ///
        ///     컨트롤러 제품의 출고일자 조회 명령 패킷을 구성하여 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 출고일자 조회 명령 패킷 </returns>                                                   ///
        ///=========================================================================================================///
        static public byte[] ReadProductDate(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'D';
            Packet[8] = (byte)'P';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ ReadProductModel @                                                                                    ///
        ///     컨트롤러 제품의 모델 정보 조회 명령 패킷을 구성하여 반환한다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 제품 모델 정보 조회 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] ReadProductModel(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'M';
            Packet[8] = (byte)'P';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ ReadRelayOffTime @                                                                                    ///
        ///     Relay(Lamp 2) 소등 시간 조회 명령 패킷을 구성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : Relay 소등 시간 조회 명령 패킷 </returns>                                            ///
        ///=========================================================================================================///
        static public byte[] ReadRelayOffTime(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'F';
            Packet[8] = (byte)'R';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ ReadRelayOnTime @                                                                                     ///
        ///     Relay(Lamp 2) 점등 시간 조회 명령 패킷을 구성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : Relay 점등 시간 조회 명령 패킷 </returns>                                            ///
        ///=========================================================================================================///
        static public byte[] ReadRelayOnTime(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'N';
            Packet[8] = (byte)'R';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ ReadRelay @                                                                                           ///
        ///     Relay(Lamp 2) On / Off 조회 명령 패킷을 구성하여 반환한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : Relay On / Off 조회 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] ReadRelay(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'P';
            Packet[8] = (byte)'R';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ ReadRelayRecoveryVoltage @                                                                            ///
        ///     Relay(Lamp 2) 전류 공급 재개 전압 조회 명령 패킷을 구성하여 반환한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : Relay 전류 공급 재개 전압 조회 명령 패킷 </returns>                                  ///
        ///=========================================================================================================///
        static public byte[] ReadRelayRecoveryVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'R';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ ReadRelayCutoffVoltage @                                                                              ///
        ///     Relay(Lamp 2) 과전압 방지 전압 조회 명령 패킷을 구성하여 반환한다.                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : Relay 과전압 방지 전압 조회 명령 패킷 </returns>                                     ///
        ///=========================================================================================================///
        static public byte[] ReadRelayCutoffVoltage(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'W';
            Packet[7] = (byte)'U';
            Packet[8] = (byte)'R';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ SetFirmwareVersion @                                                                                  ///
        ///     컨트롤러 제품의 펌웨어 버전 정보 설정 명령 패킷을 구성하여 반환한다.                                ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="version"> float : 펌웨어 버전 </param>                                                     ///
        /// <returns> byte[] : 펌웨어 버전 정보 설정 명령 패킷 </returns>                                           ///
        ///=========================================================================================================///
        static public byte[] SetFirmwareVersion(int gid, int nid, float version)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(version);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'C';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ SetHardwareVersion @                                                                                  ///
        ///     컨트롤러 제품의 하드웨어 버전 정보 설정 명령 패킷을 구성하여 반환한다.                              ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="version"> float : 하드웨어 버전 </param>                                                   ///
        /// <returns> byte[] : 하드웨어 버전 정보 설정 명령 패킷 </returns>                                         ///
        ///=========================================================================================================///
        static public byte[] SetHardwareVersion(int gid, int nid, float version)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(version);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'V';
            Packet[8] = (byte)'H';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ SetProductDate @                                                                                      ///
        ///     컨트롤러 제품 출고일자 정보 설정 명령 패킷을 구성하여 반환한다.                                     ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="date"> float : 제품 출고일자(ex. 2015년 1월 13일 => 20150113) </param>                     ///
        /// <returns> byte[] : 제품 출고일자 정보 설정 명령 패킷 </returns>                                         ///
        ///=========================================================================================================///
        static public byte[] SetProductDate(int gid, int nid, float date)
        {
            Packet = new byte[BaseLength + 6];

            Len_Pack = BitConverter.GetBytes(BaseLength + 6 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(date);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'D';
            Packet[8] = (byte)'P';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[17] = ETX1;
            Packet[18] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ SetProductModel @                                                                                     ///
        ///     컨트롤러 제품 모델 정보 설정 명령 패킷을 구성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="model"> float : 모델 정보 </param>                                                         ///
        /// <returns> byte[] : 제품 모델 정보 설정 명령 패킷 </returns>                                             ///
        ///=========================================================================================================///
        static public byte[] SetProductModel(int gid, int nid, float model)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(model);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'M';
            Packet[8] = (byte)'P';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ SetRelayOffTime @                                                                                     ///
        ///     Relay(Lamp 2) 소등 시간 설정 명령 패킷을 구성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="date"> DateTime : 소등 시간 </param>                                                       ///
        /// <returns> byte[] : Relay 소등 시간 설정 명령 패킷 </returns>                                            ///
        ///=========================================================================================================///
        static public byte[] SetRelayOffTime(int gid, int nid, DateTime date)
        {
            Packet = new byte[BaseLength + 6];

            Len_Pack = BitConverter.GetBytes(BaseLength + 6 - 3);
            NodeID = BitConverter.GetBytes(nid);

            int hour = date.Hour;
            int min = date.Minute;
            int sec = date.Second;

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'F';
            Packet[8] = (byte)'R';
            Packet[9] = (byte)((hour / 10) + '0');
            Packet[10] = (byte)((hour % 10) + '0');
            Packet[11] = (byte)((min / 10) + '0');
            Packet[12] = (byte)((min % 10) + '0');
            Packet[13] = (byte)((sec / 10) + '0');
            Packet[14] = (byte)((sec % 10) + '0');
            Packet[17] = ETX1;
            Packet[18] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ SetRelayOnTime @                                                                                      ///
        ///     Relay(Lamp 2) 점등 시간 설정 명령 패킷을 구성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="date"> DateTime : 점등 시간 </param>                                                       ///
        /// <returns> byte[] : Relay 점등 시간 설정 명령 패킷 </returns>                                            ///
        ///=========================================================================================================///
        static public byte[] SetRelayOnTime(int gid, int nid, DateTime date)
        {
            Packet = new byte[BaseLength + 6];

            Len_Pack = BitConverter.GetBytes(BaseLength + 6 - 3);
            NodeID = BitConverter.GetBytes(nid);

            int hour = date.Hour;
            int min = date.Minute;
            int sec = date.Second;

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'N';
            Packet[8] = (byte)'R';
            Packet[9] = (byte)((hour / 10) + '0');
            Packet[10] = (byte)((hour % 10) + '0');
            Packet[11] = (byte)((min / 10) + '0');
            Packet[12] = (byte)((min % 10) + '0');
            Packet[13] = (byte)((sec / 10) + '0');
            Packet[14] = (byte)((sec % 10) + '0');
            Packet[17] = ETX1;
            Packet[18] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ SetRelay @                                                                                            ///
        ///     Relay(Lamp 2) On / Off 설정 명령 패킷을 구성하여 반환한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="mode"> int : On/Off </param>                                                               ///
        /// <returns> byte[] : Relay On/Off 설정 명령 패킷 </returns>                                               ///
        ///=========================================================================================================///
        static public byte[] SetRelay(int gid, int nid, int mode)
        {
            Packet = new byte[BaseLength + 1];

            Len_Pack = BitConverter.GetBytes(BaseLength + 1 - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'P';
            Packet[8] = (byte)'R';
            Packet[9] = Convert.ToByte(mode);
            Packet[12] = ETX1;
            Packet[13] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ SetRelayRecoveryVoltage @                                                                             ///
        ///     Relay(Lamp 2) 전류 공급 재개 전압 설정 명령 패킷을 구성하여 반환한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 전류 공급 재개 전압 </param>                                                ///
        /// <returns> byte[] : Relay 전류 공급 재개 전압 설정 명령 패킷 </returns>                                  ///
        ///=========================================================================================================///
        static public byte[] SetRelayRecoveryVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'R';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.07 / 2015-01-13 ] ///
        /// @ SetRelayCutoffVoltage @                                                                               ///
        ///     Relay(Lamp 2) 과전압 방지 전압 설정 명령 패킷을 구성하여 반환한다.                                  ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="volt"> float : 과전압 방지 전압 </param>                                                   ///
        /// <returns> byte[] : Relay 과전압 방지 전압 설정 명령 패킷 </returns>                                     ///
        ///=========================================================================================================///
        static public byte[] SetRelayCutoffVoltage(int gid, int nid, float volt)
        {
            Packet = new byte[BaseLength + 4];

            Len_Pack = BitConverter.GetBytes(BaseLength + 4 - 3);
            NodeID = BitConverter.GetBytes(nid);
            Data = BitConverter.GetBytes(volt);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'U';
            Packet[8] = (byte)'R';
            Packet[9] = Data[3];
            Packet[10] = Data[2];
            Packet[11] = Data[1];
            Packet[12] = Data[0];
            Packet[15] = ETX1;
            Packet[16] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }
        #endregion

        #region [ # Ver 1.08 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.08 / 2015-03-20 ] ///
        /// @ ResetController @                                                                                     ///
        ///     컨트롤러 장비 재부팅 명령 패킷을 구성하여 반환한다.                                                 ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <returns> byte[] : 컨트롤러 장비 재부팅 명령 패킷 </returns>                                            ///
        ///=========================================================================================================///
        static public byte[] ResetController(int gid, int nid)
        {
            Packet = new byte[BaseLength];

            Len_Pack = BitConverter.GetBytes(BaseLength - 3);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'S';
            Packet[8] = (byte)'R';
            Packet[11] = ETX1;
            Packet[12] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }
        #endregion

        #region [ # Ver 1.09 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.09 / 2016-11-24 ] ///
        /// @ FactoryResetController @                                                                              ///
        ///     컨트롤러의 속성을 초기화하는 명령 패킷을 구성하여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : Group ID </param>                                                              ///
        /// <param name="nid"> int : Node ID </param>                                                               ///
        /// <param name="mode"> int : 초기화 Mode </param>                                                          ///
        /// <returns> byte[] : 컨트롤러 장비 설정 초기화 명령 패킷 </returns>                                       ///
        ///=========================================================================================================///
        static public byte[] FactoryResetController(int gid, int nid, int mode)
        {
            Packet = new byte[BaseLength + 1];

            Len_Pack = BitConverter.GetBytes(BaseLength - 2);
            NodeID = BitConverter.GetBytes(nid);

            Packet[0] = STX;
            Packet[1] = Len_Pack[0];
            Packet[2] = Len_Pack[1];
            Packet[3] = Convert.ToByte(gid);
            Packet[4] = NodeID[0];
            Packet[5] = NodeID[1];
            Packet[6] = (byte)'Q';
            Packet[7] = (byte)'R';
            Packet[8] = (byte)'V';
            Packet[9] = Convert.ToByte(mode);
            Packet[12] = ETX1;
            Packet[13] = ETX2;

            CommonBase.SetCRC16(Packet, 2);

            return Packet;
        }
        #endregion
    }
    ///=========================================================================== End of Class : HybridController =///
}
