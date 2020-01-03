using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.Win32;
using System.Management;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.01 / 2016-11-21 ] ///
    /// ▷ Net_Manager : CommonVariables ◁                                                                         ///
    ///     네트워크 관련 기능 클래스로 연결 상태 확인이나 IP 조회 같은 부가 기능들을 지원한다.                     ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-03-28 ]                                                                                   ///
    ///     ▶ 특정 포트 연결 상태 확인 지원                                                                        ///
    ///     ▶ Ping 테스트 지원                                                                                     ///
    ///     ▶ IP 조회 기능 지원                                                                                    ///
    /// [ Ver 1.01 / 2016-11-21 ]                                                                                   ///
    ///     ▶ 데이터 처리 모드 설정 추가                                                                           ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class Net_Manager : CommonVariables
    {
        #region [ # Defines & Variables ]
        // 데이터 처리 모드
        public string TCM_Type = "A";

        // 로그 관련 변수
        static public string Message = string.Empty;
        static public StringBuilder MessageBuilder;
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ NetStat @                                                                                             ///
        ///     로컬 시스템의 네크워크 정보를 조회하여 그 결과를 반환한다.                                          ///
        ///     명령에 사용되는 argument를 매개변수로 전달할 수 있으며 반환된 결과는 부가적인 처리가 필요하다.      ///
        /// </summary>                                                                                              ///
        /// <param name="arg"> string : netstat 명령에 사용되는 argument </param>                                   ///
        /// <returns> StreamReader : netstat 명령 수행 결과 </returns>                                              ///
        ///=========================================================================================================///
        public static StreamReader NetStat(string arg)
        {
            Process p = new Process();
            StreamReader sr;
            ProcessStartInfo startinfo = new ProcessStartInfo("netstat");

            try
            {
                startinfo.Arguments = arg;
                startinfo.UseShellExecute = false;
                startinfo.RedirectStandardOutput = true;
                startinfo.CreateNoWindow = true;

                p.StartInfo = startinfo;
                p.Start();
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : NetStat ]");

                if (string.IsNullOrEmpty(arg) == true)
                {
                    MessageBuilder.AppendLine("# arg      : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# arg      : " + arg);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            sr = p.StandardOutput;
            return sr;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ ConnectionCheck @                                                                                     ///
        ///     매개변수로 지정한 로컬 시스템의 포트에 연결된 TCP/IP 연결 상태를 확인하여 결과를 반환한다.          ///
        /// </summary>                                                                                              ///
        /// <param name="Port"> int : 로컬 시스템의 포트 번호 </param>                                              ///
        /// <returns> bool : TCP/IP 연결 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public static bool ConnectionCheck(int Port)
        {
            bool result = false;

            try
            {
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();

                foreach (TcpConnectionInformation t in connections)
                {
                    IPEndPoint local = t.LocalEndPoint;
                    IPEndPoint remote = t.RemoteEndPoint;
                    TcpState state = t.State;

                    if (Port == local.Port)
                    {
                        if (state == TcpState.Established)
                        {
                            result = true;
                        }

                        break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ConnectionCheck ]");
                MessageBuilder.AppendLine("# port     : " + Port.ToString());
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return result;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ PingTest @                                                                                            ///
        ///     매개변수에서 지정한 주소로 Ping을 수행하여 결과를 반환한다.                                         ///
        ///     Ping 명령 실행에 필요한 argument를 매개변수를 통해 지정할 수 있다.                                  ///
        /// </summary>                                                                                              ///
        /// <param name="address"> string : ping을 전송할 대상의 IP 주소 </param>                                   ///
        /// <param name="arg"> string : ping 명령에 사용되는 argument </param>                                      ///
        /// <returns> StreamReader : ping 명령 수행 결과 </returns>                                                 ///
        ///=========================================================================================================///
        public static StreamReader PingTest(string address, string arg)
        {
            Process p = new Process();
            StreamReader sr;
            ProcessStartInfo startinfo = new ProcessStartInfo("ping");

            try
            {
                startinfo.Arguments = address + arg;
                startinfo.UseShellExecute = false;
                startinfo.RedirectStandardOutput = true;
                startinfo.CreateNoWindow = true;

                p.StartInfo = startinfo;
                p.Start();
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Funtion : PingTest ]");

                if (string.IsNullOrEmpty(address) == true)
                {
                    MessageBuilder.AppendLine("# address  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# address  : " + address);
                }

                if (string.IsNullOrEmpty(arg) == true)
                {
                    MessageBuilder.AppendLine(" arg      : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine(" arg      : " + arg);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            sr = p.StandardOutput;
            return sr;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ GetIPFromReg @                                                                                        ///
        ///     로컬 시스템의 레지스트리에서 IP 정보를 조회하여 결과를 반환한다.                                    ///
        /// </summary>                                                                                              ///
        /// <returns> string[] : 로컬 시스템 IP 리스트 </returns>                                                   ///
        ///=========================================================================================================///
        public static string[] GetIPFromReg()
        {
            List<string> Infos = new List<string>();
            string tmp_msg = string.Empty;
            string cap = "Warning";

            try
            {
                RegistryKey start = Registry.LocalMachine;
                RegistryKey cardServiceName, networkKey;
                string networkcardKey = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkCards";
                string serviceKey = "SYSTEM\\CurrentControlSet\\Services\\";
                string networkcardKeyName, deviceName;
                string deviceServiceName, serviceName;
                RegistryKey serviceNames = start.OpenSubKey(networkcardKey);

                if (serviceNames == null)
                {
                    tmp_msg = "Bad registry key";

                    WinForm_Message messageform = new WinForm_Message(tmp_msg, cap, true);
                    messageform.ShowDialog();
                }
                else
                {
                    string[] networkCards = serviceNames.GetSubKeyNames();
                    serviceNames.Close();

                    foreach (string keyName in networkCards)
                    {
                        networkcardKeyName = networkcardKey + "\\" + keyName;
                        cardServiceName = start.OpenSubKey(networkcardKeyName);

                        if (cardServiceName == null)
                        {
                            tmp_msg = "Bad registry key";

                            WinForm_Message messageform = new WinForm_Message(tmp_msg, cap, true);
                            messageform.ShowDialog();
                        }
                        else
                        {
                            deviceServiceName = (string)cardServiceName.GetValue("ServiceName");
                            deviceName = (string)cardServiceName.GetValue("Description");

                            Infos.Add(deviceName);

                            serviceName = serviceKey + deviceServiceName + "\\Parameters\\Tcpip";
                            networkKey = start.OpenSubKey(serviceName);

                            if (networkKey == null)
                            {
                                tmp_msg = "No IP configuration set";

                                WinForm_Message messageform = new WinForm_Message(tmp_msg, cap, true);
                                messageform.ShowDialog();
                            }
                            else
                            {
                                string[] ipaddresses =
                                    (string[])networkKey.GetValue("IPAddress");

                                if (ipaddresses != null)
                                {
                                    foreach (string ip in ipaddresses) Infos.Add(ip);
                                }

                                string[] defaultGateways =
                                    (string[])networkKey.GetValue("DefaultGateway");

                                if (defaultGateways != null)
                                {
                                    foreach (string gate in defaultGateways) Infos.Add(gate);
                                }

                                string[] subnetmasks =
                                    (string[])networkKey.GetValue("SubnetMask");

                                if (subnetmasks != null)
                                {
                                    foreach (string mask in subnetmasks) Infos.Add(mask);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : GetIPFromReg ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();
            }

            return Infos.ToArray();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ GetIPFromWMI @                                                                                        ///
        ///     로컬 시스템의 WMI에서 IP 정보를 조회하여 결과를 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <returns> string[] : 로컬 시스템 IP 리스트 </returns>                                                   ///
        ///=========================================================================================================///
        public static string[] GetIPFromWMI()
        {
            List<string> infos = new List<string>();

            try
            {
                ManagementObjectSearcher query = new ManagementObjectSearcher(
                    "SELECT * FROM ? Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TURE'");
                ManagementObjectCollection queryCollection = query.Get();

                foreach (ManagementObject mo in queryCollection)
                {
                    string networkcard = (string)mo["Description"];
                    infos.Add(networkcard);

                    string macaddress = (string)mo["MACAddress"];
                    infos.Add(macaddress);

                    string[] ipaddresses = (string[])mo["IPAddress"];

                    if (ipaddresses != null)
                    {
                        foreach (string ip in ipaddresses) infos.Add(ip);
                    }

                    string[] subnets = (string[])mo["IPSubnet"];

                    if (subnets != null)
                    {
                        foreach (string subnet in subnets) infos.Add(subnet);
                    }

                    string[] defaultGateways = (string[])mo["DefaultGateway"];

                    if (defaultGateways != null)
                    {
                        foreach (string gateway in defaultGateways) infos.Add(gateway);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : GetIPFromWMI ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return infos.ToArray();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ GetIPFromDNS @                                                                                        ///
        ///     로컬 시스템의 호스트 네임으로부터 IP 주소를 조회하여 반한환다.                                      ///
        /// </summary>                                                                                              ///
        /// <returns> string[] : 로컬 시스템 IP 리스트 </returns>                                                   ///
        ///=========================================================================================================///
        public static string[] GetIPFromDNS()
        {
            List<string> infos = new List<string>();

            try
            {
                string hostName = Dns.GetHostName();
                infos.Add(hostName);

                IPHostEntry ipaddresses = Dns.GetHostEntry(hostName);
                foreach (IPAddress ip in ipaddresses.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        infos.Add(ip.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : GetIPFromDNS ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return infos.ToArray();
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2016-11-21 ] ///
        /// @ SetTCMType @                                                                                          ///
        ///     수신 데이터를 처리하기 위해 사용할 처리 함수를 지정하는 정보를 매개변수로 넘겨받아 설정한다.        ///
        /// </summary>                                                                                              ///
        /// <param name="type"> string : 모드 데이터 </param>                                                       ///
        ///=========================================================================================================///
        public void SetTCMType(string type) { TCM_Type = type; }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2016-11-21 ] ///
        /// @ GetTCMType @                                                                                          ///
        ///     데이터 처리 함수 모드 정보를 반환한다.                                                              ///
        /// </summary>                                                                                              ///
        /// <returns> string : 모드 데이터 </returns>                                                               ///
        ///=========================================================================================================///
        public string GetTCMType() { return TCM_Type; }
        #endregion
    }
    ///================================================================================ End of Class : Net_Manager =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2017-11-30 ] ///
    /// ▷ ACE_TcpListener : TcpListener ◁                                                                         ///
    ///     TcpListener 상속 클래스                                                                                 ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2017-11-30 ]                                                                                   ///
    ///     ▶ 초기 버전                                                                                            ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class ACE_TcpListener : TcpListener
    {
        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-30 ] ///
        /// @ ACE_TcpListener @                                                                                     ///
        ///     생성자                                                                                              /// 
        /// </summary>                                                                                              ///
        /// <param name="address"> IPAddress : 서버 IP 주소 </param>                                                ///
        /// <param name="port"> int : 포트 번호 </param>                                                            ///
        ///=========================================================================================================///
        public ACE_TcpListener(IPAddress address, int port) : base(address, port){ }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2017-11-30 ] ///
        /// @ GetActive @                                                                                           ///
        ///     TcpListener의 포트 동작 상태를 반환한다.                                                            ///
        /// </summary>                                                                                              ///
        /// <returns> bool : 포트 동작 상태 </returns>                                                              ///
        ///=========================================================================================================///
        public bool GetActive()
        {
            return this.Active;
        }
        #endregion
    }
    ///================================================================================ End of Class : Net_Manager =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.02 / 2019-01-16 ] ///
    /// ▷ TCP_Comm_Server : Net_Manager ◁                                                                         ///
    ///     TCP/IP 통신 기반의 서버                                                                                 ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-07-08 ]                                                                                   ///
    ///     ▶ 클라이언트 비동기 접속 처리 및 동시 접속 수 제한                                                     ///
    ///     ▶ 데이터 패킷 전체 / 특정 클라이언트 전송                                                              ///
    ///     ▶ 로컬 시스템 IP 및 서버 포트 번호 조회 기능                                                           ///
    ///     ▶ 접속 클라이언트 및 서버 동작 상태 정보 조회 기능                                                     ///
    /// [ Ver 1.01 / 2014-07-16 ]                                                                                   ///
    ///     ▶ 최대 동시 접속 수 조회 기능                                                                          ///
    /// [ Ver 1.02 / 2019-01-16 ]                                                                                   ///
    ///     ▶ 스레드 동작 관련 제어 기능 추가                                                                      ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class TCP_Comm_Server : Net_Manager
    {
        #region [ # Defines & Variables ]
        // 사용자 정의 이벤트
        public static event SetLogHandler SetLogMsg;
        public delegate void SetLogHandler(int port, string msg);

        // 데이터 패킷 관련 상수
        private const int PacketSize = 25;

        // 클라이언트 관리 변수
        private ACE_TcpListener server;
        private List<TCP_Comm_Manager> clients;

        // 로컬 시스템 정보
        private int svr_port;
        private List<string> svr_ips;

        // 서버 동작 정보
        private bool running = false;

        // 로그 관련 변수
        private readonly new string ErrorLogName = "TCP Comm Server Error";

        // 동시 접속 제한 제어 변수
        private int MaxConn = 5, Connectors = 0;

        // 통신 객체 정보
        private int groupID = 255;
        public int GroupID
        {
            get { return groupID; }
            set { groupID = value; }
        }

        private int nodeID = 255;
        public int NodeID
        {
            get { return nodeID; }
            set { nodeID = value; }
        }
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ TCP_Comm_Server @                                                                                     ///
        ///     서버를 생성하며 매개변수로 서버가 사용할 포트 번호를 설정한다.                                      ///
        /// </summary>                                                                                              ///
        /// <param name="port"> int : 서버 포트 번호 </param>                                                       ///
        ///=========================================================================================================///
        public TCP_Comm_Server(int port)
        {
            TCP_Comm_Manager.NotifyDisconnect += NotifyDisconnect;
            TCP_Comm_Manager.NotifyMsg += NotifyMsg; 
            
            svr_port = port;
            Server_Init();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ TCP_Comm_Server @                                                                                     ///
        ///     서버를 생성하며 매개변수로 서버가 사용할 포트 번호와 동시 접속 제한 수를 설정한다.                  ///
        /// </summary>                                                                                              ///
        /// <param name="port"> int : 서버 포트 번호 </param>                                                       ///
        /// <param name="limit"> int : 동시 접속 제한 수 </param>                                                   ///
        ///=========================================================================================================///
        public TCP_Comm_Server(int port, int limit)
        {
            TCP_Comm_Manager.NotifyDisconnect += NotifyDisconnect;
            TCP_Comm_Manager.NotifyMsg += NotifyMsg; 
            
            svr_port = port;
            MaxConn = limit;
            Server_Init();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ Server_Init @                                                                                         ///
        ///     서버 관리에 사용되는 변수들을 초기화한다.                                                           ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void Server_Init()
        {
            TCP_Comm_Manager.NotifyDisconnect += NotifyDisconnect;

            clients = new List<TCP_Comm_Manager>();
            svr_ips = new List<string>();

            foreach (string ip in GetIPFromDNS())
            {
                svr_ips.Add(ip);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ ServerStart @                                                                                         ///
        ///     서버를 시작하여 클라이언트의 접속을 대기한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <returns> bool : 작업 성공 여부 </returns>                                                              ///
        ///=========================================================================================================///
        public bool ServerStart()
        {
            try
            {
                running = true;

                if (server == null)
                {
                    server = new ACE_TcpListener(IPAddress.Any, svr_port);
                }

                server.Start();
                Accept();

                SetLogMsg(svr_port, "TCP Server Started!!");

                return true;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ServerStart ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ ServerStop @                                                                                          ///
        ///     서버의 동작을 중지하고 모든 연결을 해제한다.                                                        ///
        /// </summary>                                                                                              ///
        /// <returns> bool : 작업 성공 여부 </returns>                                                              ///
        ///=========================================================================================================///
        public bool ServerStop()
        {
            try
            {
                running = false;

                server.Stop();
                DisconnectAll();

                SetLogMsg(svr_port, "TCP Server Stopped!!");

                return true;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ServerStop ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ DisconnectAll @                                                                                       ///
        ///     서버에 연결되어 있는 모든 Tcp 통신 객체의 연결을 해제한다.                                          ///
        /// </summary>                                                                                              ///
        /// <returns> bool : 연결 해제 성공 여부 </returns>                                                         ///
        ///=========================================================================================================///
        public bool DisconnectAll()
        {
            try
            {
                for (int i = (clients.Count - 1); i > -1 ; i--)
                {
                    //while (clients[i].GetConntected() == true)
                    {
                        clients[i].Close();
                        Thread.Sleep(100);
                    }
                }

                if (clients.Count > 0)
                {
                    clients.Clear();
                }

                Connectors = 0;

                return true;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : DisconnectAll ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ Disconnect @                                                                                          ///
        ///     매개변수로 지정한 ID 정보와 일치하는 Tcp 통신 객체의 연결을 해제한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="gid"> int : 그룹 ID </param>                                                               ///
        /// <param name="nid"> int : 노드 ID </param>                                                               ///
        /// <returns> bool : 연결 해제 성공 여부 </returns>                                                         ///
        ///=========================================================================================================///
        public bool Disconnect(int gid, int nid)
        {
            try
            {
                lock (clients)
                {
                    for (int i = 0; i < clients.Count; i++)
                    {
                        if ((clients[i].GroupID == gid) && (clients[i].NodeID == nid))
                        {
                            clients[i].Close();
                            Connectors--;
                            break;
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Disconnect ]");
                MessageBuilder.AppendLine("# gid     : " + gid);
                MessageBuilder.AppendLine("# nid     : " + nid); 
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ Accept @                                                                                              ///
        ///     비동기 방식으로 클라이언트의 접속을 대기한다.                                                       ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void Accept()
        {
            if (running == true)
            {
                server.BeginAcceptSocket(new AsyncCallback(Listening), server);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ Listening @                                                                                           ///
        ///     클라이언트로부터 접속이 시도되면 새로운 Tcp 통신 객체를 생성하여 연결한다.                          ///
        ///     접속 처리 과정이 완료되면 그 결과를 이벤트를 통해 전달한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="ar"> IAsyncResult : 비동기 상태 정보 </param>                                              ///
        ///=========================================================================================================///
        private void Listening(IAsyncResult ar)
        {
            try
            {
                if (running == true)
                {
                    TcpListener listener = (TcpListener)ar.AsyncState;
                    TcpClient client = new TcpClient();

                    if (ar.IsCompleted == true)
                    {
                        client = listener.EndAcceptTcpClient(ar);

                        if ((clients.Count + 1) > MaxConn)
                        {
                            clients[0].Close();
                        }

                        TCP_Comm_Manager tcm = new TCP_Comm_Manager(client, TCM_Type);
                        tcm.GroupID = GroupID;
                        tcm.NodeID = NodeID;
                        tcm.SetTCMType(TCM_Type);
                        clients.Add(tcm);
                    }
                }
            }
            catch (Exception e)
            {
                if (!(e is ObjectDisposedException))
                {
                    MessageBuilder = new StringBuilder();
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine("[ Function : Listening ]");

                    if (ar == null)
                    {
                        MessageBuilder.AppendLine("# IAsyncResult : NULL");
                    }
                    else
                    {
                        MessageBuilder.AppendLine("# IAsyncResult : " + ar.ToString());
                    }

                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine(e.Message);
                    MessageBuilder.AppendLine();

                    Message = MessageBuilder.ToString();

                    FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
                }
            }
            finally
            {
                Accept();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ Send @                                                                                                ///
        ///     매개변수로 전달된 패킷 데이터를 전송한다.                                                           ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 패킷 데이터 </param>                                                     ///
        ///=========================================================================================================///
        public void Send(byte[] packet)
        {
            try
            {
                if (packet != null)
                {
                    foreach (TCP_Comm_Manager tcm in clients)
                    {
                        tcm.Send(packet);
                    }

                    SetLogMsg(svr_port, "Sending Complete!!");
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Send ]");

                if (packet == null)
                {
                    MessageBuilder.AppendLine("# packet  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# packet  : " + CommonBase.Hex2Str16(packet, packet.Length));
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                SetLogMsg(svr_port, "Error Occured while Sending!!");
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ Send @                                                                                                ///
        ///     매개변수로 전달된 패킷 데이터를 지정된 ID를 가진 통신 객체로만 전송한다.                            ///
        /// </summary>                                                                                              ///
        /// <param name="packet"> byte[] : 패킷 데이터 </param>                                                     ///
        /// <param name="gid"> int : 그룹 ID </param>                                                               ///
        /// <param name="nid"> int : 노드 ID </param>                                                               ///
        ///=========================================================================================================///
        public void Send(byte[] packet, int gid, int nid)
        {
            try
            {
                if (packet != null)
                {
                    foreach (TCP_Comm_Manager tcm in clients)
                    {
                        if ((tcm.GroupID == gid) && (tcm.NodeID == nid))
                        {
                            tcm.Send(packet);
                        }
                    }

                    SetLogMsg(svr_port, "Sending Complete!!");
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Send ]");

                if (packet == null)
                {
                    MessageBuilder.AppendLine("# packet  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# packet  : " + CommonBase.Hex2Str16(packet, packet.Length));
                }

                MessageBuilder.AppendLine("# gid     : " + gid);
                MessageBuilder.AppendLine("# nid     : " + nid);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                SetLogMsg(svr_port, "Error Occured while Sending!!");
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ NotifyDisconnect @                                                                                    ///
        ///     Tcp 통신 객체에서 발생하는 이벤트의 핸들러로 연결이 해제된 객체를 리스트에서 찾아 제거한다.         ///
        /// </summary>                                                                                              ///
        /// <param name="port"> int : 통신 객체 식별 원격지 포트 번호 </param>                                      ///
        ///=========================================================================================================///
        private void NotifyDisconnect(int port)
        {
            for (int i = clients.Count; i > 0; i--)
            {
                if (clients[i - 1].GetRemotePort() == port)
                {
                    lock (clients)
                    {
                        clients.Remove(clients[i - 1]);
                    }

                    break;
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ NotifyMsg @                                                                                           ///
        ///     Not Used                                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="port"></param>                                                                             ///
        /// <param name="msg"></param>                                                                              ///
        ///=========================================================================================================///
        private void NotifyMsg(int port, string msg)
        {
            // Not Used
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ GetServerPort @                                                                                       ///
        ///     서버에서 사용 중인 로컬 시스템의 포트 번호를 반환한다.                                              ///
        /// </summary>                                                                                              ///
        /// <returns> int : 포트 번호 </returns>                                                                    ///
        ///=========================================================================================================///
        public int GetServerPort() { return svr_port; }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ GetServerIPs @                                                                                        ///
        ///     서버가 동작 중인 로컬 시스템의 IP 정보를 반환한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <returns> string[] : IP 리스트 </returns>                                                               ///
        ///=========================================================================================================///
        public string[] GetServerIPs() { return svr_ips.ToArray(); }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ GetClients @                                                                                          ///
        ///     서버에 접속되어 있는 모든 연결 객체를 반환한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <returns> TCP_Comm_Manager[] : Tcp 연결 객체 리스트 </returns>                                          ///
        ///=========================================================================================================///
        public TCP_Comm_Manager[] GetClients() { return clients.ToArray(); }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ GetServerStatus @                                                                                     ///
        ///     서버의 동작 상태를 반환한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <returns> bool : 서버의 동작 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool GetServerStatus()
        {
            bool active = false;

            if (server != null)
            {
                active = server.GetActive();
            }

            return active; 
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-07-16 ] ///
        /// @ GetLimitMaxConnection @                                                                               ///
        ///     서버에 동시 접속 가능한 최대 접속 제한 정보를 반환한다.                                             ///
        /// </summary>                                                                                              ///
        /// <returns> int : 동시 접속 최대 제한 수 </returns>                                                       ///
        ///=========================================================================================================///
        public int GetLimitMaxConnection() { return MaxConn; }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2019-01-16 ] ///
        /// @ SetDummyMode @                                                                                        ///
        ///     네트워크 연결 확인용 더미 패킷 전송 모드를 설정한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 더미 전송 모드 </param>                                                      ///
        ///=========================================================================================================///
        public void SetDummyMode(bool mode)
        {
            foreach (TCP_Comm_Manager tcm in clients)
            {
                tcm.SetDummyMode(mode);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2019-01-16 ] ///
        /// @ SetLoggingMode @                                                                                      ///
        ///     로그 파일 저장 모드를 설정한다.                                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 로그 파일 저장 모드 </param>                                                 ///
        ///=========================================================================================================///
        public void SetLoggingMode(bool mode)
        {
            foreach (TCP_Comm_Manager tcm in clients)
            {
                tcm.SetLoggingMode(mode);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2019-01-16 ] ///
        /// @ SetHighSpeedMode @                                                                                    ///
        ///     데이터 처리 모드를 설정한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 데이터 고속 처리 모드 </param>                                               ///
        ///=========================================================================================================///
        public void SetHighSpeedMode(bool mode)
        {
            foreach (TCP_Comm_Manager tcm in clients)
            {
                tcm.SetHighSpeedMode(mode);
            }
        }
        #endregion
    }
    ///============================================================================ End of Class : TCP_Comm_Server =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.05 / 2019-01-15 ] ///
    /// ▷ TCP_Comm_Manager : Net_Manager ◁                                                                        ///
    ///     TCP 통신 객체를 이용하여 데이터 패킷 송·수신을 처리한다.                                               ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-07-08 ]                                                                                   ///
    ///     ▶ TCP/IP 접속 연결 및 해제 기능                                                                        ///
    ///     ▶ 데이터 패킷 전송 기능                                                                                ///
    ///     ▶ 더미 패킷 전송 기능                                                                                  ///
    ///     ▶ 수신 데이터 패킷 버퍼링 기능 (더블 버퍼링)                                                           ///
    ///     ▶ RAW 데이터 파일 저장 기능                                                                            ///
    ///     ▶ 데이터 패킷 리스트 메인 클래스에서 요청 시 반환                                                      ///
    ///     ▶ 접속 상태 정보 조회 기능                                                                             ///
    ///     ▶ ID 조회 기능                                                                                         ///
    /// [ Ver 1.01 / 2014-07-08 ]                                                                                   ///
    ///     ▶ 원격 접속 IP 정보 조회 기능                                                                          ///
    /// [ Ver 1.02 / 2016-11-21 ]                                                                                   ///
    ///     ▶ 데이터 처리 함수 추가                                                                                ///
    /// [ Ver 1.03 / 2016-12-14 ]                                                                                   ///
    ///     ▶ ETX 조회 / 설정 함수 추가                                                                            ///
    /// [ Ver 1.04 / 2017-01-17 ]                                                                                   ///
    ///     ▶ 데이터 by pass를 위한 처리 스레드 함수 추가                                                          ///
    /// [ Ver 1.05 / 2019-01-15 ]                                                                                   ///
    ///     ▶ 스레드 동작 관련 제어 기능 추가                                                                      ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class TCP_Comm_Manager : Net_Manager
    {
        #region [ # Defines & Variables ]
        // 사용자 정의 이벤트
        public static event SetLogHandler NotifyMsg;
        public delegate void SetLogHandler(int port, string msg);

        public static event ConnectHandler NotifyDisconnect;
        public delegate void ConnectHandler(int port);

        public static event DisConnHandler DisConnecting;
        public delegate void DisConnHandler(string ip, int port);

        public static event DataHandler NotifyData;
        public delegate void DataHandler(int port, byte[] buff);

        // 로그 관련 변수
        private readonly new string ErrorLogName = "TCP Comm Manager Error";

        // 원격지 및 로컬 정보
        private string Remote_IP = string.Empty;
        private int Remote_port = 0;
        private string Local_IP = string.Empty;
        private int Local_port = 0;

        // 통신 객체 정보
        private TcpClient client;

        private int groupID = 255;
        public int GroupID
        {
            get { return groupID; }
            set { groupID = value; }
        }

        private int nodeID = 255;
        public int NodeID
        {
            get { return nodeID; }
            set { nodeID = value; }
        }

        // 스레드 변수 및 제어 플래그
        private Thread Graber, File_Writer, Dummy;
        private bool is_terminate = false;
        private bool is_HighSpeed = false;
        private bool DummyMode = true;
        private bool Logging = true;

        // RAW 데이터 저장 버퍼
        private List<string> PacketData = new List<string>();

        private NetworkStream NS;

        // 패킷 데이터 저장 버퍼
        private List<byte> PacketBuffer = new List<byte>();
        private List<byte[]> PacketBuffer1 = new List<byte[]>();
        private List<byte[]> PacketBuffer2 = new List<byte[]>();
        private bool isBuffer1 = true;

        private string FileName = string.Empty;

        // Packet 처리 공통 변수
        private const int PacketSize = 25;
        private const int MinimumPacket = 13;
        private byte STX = 0x40;
        private byte ETX = 0x00;
        private int ValidLimit = 255;
        private int ReadMin = 1;
        
        // Type-A Data 처리 기분
        private byte[] ETXA = new byte[] { 0x0A, 0x0D };

        // Type-C Data 처리 기준
        private int DataFire = 200;

        // Lock Object
        private object lockObject = new object();
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-22 ] ///
        /// @ TCP_Comm_Manager @                                                                                    ///
        ///     TCP 통신 객체 생성자로 매개변수로 원격지 IP와 포트 번호를 넘겨받아 접속을 시도한다.                 ///
        /// </summary>                                                                                              ///
        /// <param name="ip">stirng : 원격지 접속 IP 주소</param>                                                   ///
        /// <param name="port">int : 원격지 접속 포트 번호</param>                                                  ///
        ///=========================================================================================================///
        public TCP_Comm_Manager(string ip, int port)
        {
            try
            {
                client = new TcpClient(ip, port);
            }
            catch (Exception e)
            {
                MessageBox.Show("접속에 실패했습니다.", "Connect Failed");

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : TCP_Comm_Manager ]");

                if (string.IsNullOrEmpty(ip) == true)
                {
                    MessageBuilder.AppendLine("# ip      : NULL / Empty");
                }
                else
                {
                    MessageBuilder.AppendLine("# ip      : " + ip);
                }

                MessageBuilder.AppendLine("# port    : " + port);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Init();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-22 ] ///
        /// @ TCP_Comm_Manager @                                                                                    ///
        ///     TCP 통신 객체 생성자로 매개변수로 TcpClient를 넘겨받는다.                                           ///
        ///     원격지 서버와 연결이 완료된 객체를 이용하여 데이터 통신을 수행할 준비를 한다.                       ///
        /// </summary>                                                                                              ///
        /// <param name="tc">TcpClient : 원격지 접속 Tcp 통신 객체</param>                                          ///
        ///=========================================================================================================///
        public TCP_Comm_Manager(TcpClient tc)
        {
            client = tc;

            Init();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-22 ] ///
        /// @ Init @                                                                                                ///
        ///     변수들을 초기화하고 수신 데이터 처리를 위한 스레드를 생성한다.                                      ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void Init()
        {
            string info = string.Empty;
            string[] sub;
            
            try
            {
                info = client.Client.LocalEndPoint.ToString();

                if (info.Equals(string.Empty) != true)
                {
                    sub = info.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    Local_IP = sub[0];
                    int.TryParse(sub[1], out Local_port);
                }

                info = client.Client.RemoteEndPoint.ToString();

                if (info.Equals(string.Empty) != true)
                {
                    sub = info.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    Remote_IP = sub[0];
                    int.TryParse(sub[1], out Remote_port);
                }

                NotifyMsg(Remote_port, Local_IP + ":" + Local_port + " <----> " + Remote_IP + ":" + Remote_port);

                if (Graber == null)
                {
                    switch (GetTCMType())
                    {
                        case "B" : Graber = new Thread(new ThreadStart(BufferingThreadB));
                            ReadMin = 3;
                            ETX = 0x7D;
                            break;
                        case "C" : Graber = new Thread(new ThreadStart(BufferingThreadC));
                            ReadMin = 200;
                            ETX = (byte)'\n';
                            break;
                        case "D": Graber = new Thread(new ThreadStart(BufferingThreadD));
                            ETX = 0x7D;
                            break;
                        case "P": Graber = new Thread(new ThreadStart(BufferingThreadP));
                            break;
                        default : Graber = new Thread(new ThreadStart(BufferingThreadA));
                            ReadMin = MinimumPacket;
                            break;
                    }

                    Graber.Start();
                }

                DummySender();

                if (File_Writer == null)
                {
                    File_Writer = new Thread(new ThreadStart(WritingThread));
                    File_Writer.Start();
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Init ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-22 ] ///
        /// @ Connect @                                                                                             ///
        ///     원격지로 접속을 시도하고 그 결과를 반환한다.                                                        ///
        ///     기존의 연결이 있는 경우 해제하고 원격지로 연결을 시도한다.                                          ///
        /// </summary>                                                                                              ///
        /// <returns>bool : 원격지 접속 여부</returns>                                                              ///
        ///=========================================================================================================///
        public bool Connect()
        {
            try
            {
                if (client.Connected == true)
                {
                    client.Close();
                }

                client = new TcpClient(Remote_IP, Remote_port);

                if (client.Connected == false)
                {
                    client.Connect(Remote_IP, Remote_port);
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Connect ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return client.Connected;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-22 ] ///
        /// @ Close @                                                                                               ///
        ///     현재 원격지에 접속 중인 연결을 해제한다.                                                            ///
        ///     동작 중인 스레드를 모두 중단하고 사용 중인 자원을 반환한다.                                         ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void Close()
        {
            try
            {
                if (client != null)
                {
                    while (client.Client.Connected == true)
                    {
                        client.Client.Close();
                        Thread.Sleep(100);
                    }
                }

                NotifyMsg(Remote_port, Local_IP + ":" + Local_port + " --//-- " + Remote_IP + ":" + Remote_port);
                NotifyDisconnect(Remote_port);

                is_terminate = true;

                Send(Command_Manager.DisConnect());

                if ((Graber != null) && (Graber.IsAlive == true))
                {
                    try
                    {
                        //Graber.Join();
                        //Graber.Interrupt();
                        Graber.Abort();
                    }
                    catch (Exception e)
                    {
                        if (!(e is ThreadAbortException) == true)
                        {
                            MessageBuilder = new StringBuilder();
                            MessageBuilder.AppendLine();
                            MessageBuilder.AppendLine("[ Function : Close #1408 ]");
                            MessageBuilder.AppendLine();
                            MessageBuilder.AppendLine(e.Message);
                            MessageBuilder.AppendLine();

                            Message = MessageBuilder.ToString();

                            FileManager.SetFileExtension(".dat");
                            FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);
                        }
                    }
                }

                if ((File_Writer != null) && (File_Writer.IsAlive == true))
                {
                    try
                    {
                        //Graber.Join();
                        //Graber.Interrupt();
                        Graber.Abort();
                    }
                    catch (Exception e)
                    {
                        if (!(e is ThreadAbortException) == true)
                        {
                            MessageBuilder = new StringBuilder();
                            MessageBuilder.AppendLine();
                            MessageBuilder.AppendLine("[ Function : Close #1435 ]");
                            MessageBuilder.AppendLine();
                            MessageBuilder.AppendLine(e.Message);
                            MessageBuilder.AppendLine();

                            Message = MessageBuilder.ToString();

                            FileManager.SetFileExtension(".dat");
                            FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);
                        }
                    }
                }

                if ((Dummy != null) && (Dummy.IsAlive == true))
                {
                    try
                    {
                        Graber.Join();
                        //Graber.Interrupt();
                        //Graber.Abort();
                    }
                    catch (Exception e)
                    {
                        if (!(e is ThreadAbortException) == true)
                        {
                            MessageBuilder = new StringBuilder();
                            MessageBuilder.AppendLine();
                            MessageBuilder.AppendLine("[ Function : Close #1462 ]");
                            MessageBuilder.AppendLine();
                            MessageBuilder.AppendLine(e.Message);
                            MessageBuilder.AppendLine();

                            Message = MessageBuilder.ToString();

                            FileManager.SetFileExtension(".dat");
                            FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);
                        }
                    }
                }

                //MessageBox.Show(Graber.IsAlive + " " + File_Writer.IsAlive + " " + Dummy.IsAlive);

                PacketData.Clear();
                PacketBuffer1.Clear();
                PacketBuffer2.Clear();
            }
            catch (Exception e)
            {
                if (!(e is ThreadAbortException) == true)
                {
                    MessageBuilder = new StringBuilder();
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine("[ Function : Close ]");
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine(e.Message);
                    MessageBuilder.AppendLine();

                    Message = MessageBuilder.ToString();

                    FileManager.SetFileExtension(".dat");
                    FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-22 ] ///
        /// @ Send @                                                                                                ///
        ///     매개변수로 전달된 패킷 데이터를 원격지로 전송한다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="packet">byte[] : 전송 패킷 데이터</param>                                                  ///
        /// <returns>int : 전송된 데이터 길이</returns>                                                             ///
        ///=========================================================================================================///
        public int Send(byte[] packet)
        {
            int sended = 0;

            try
            {
                if (client != null)
                {
                    if (client.Connected == true)
                    {
                        NS = client.GetStream();

                        if (NS.CanWrite == true)
                        {
                            NS.Write(packet, 0, packet.Length);
                            sended = packet.Length;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Close();

                if (!((e.InnerException is SocketException)) || (e is ThreadAbortException))
                {
                    MessageBuilder = new StringBuilder();
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine("[ Function : Send ]");

                    if (packet == null)
                    {
                        MessageBuilder.AppendLine("# packet   : NULL");
                    }
                    else
                    {
                        MessageBuilder.AppendLine("# packet   : " + packet.Length);
                    }

                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine(e.Message);
                    MessageBuilder.AppendLine();

                    Message = MessageBuilder.ToString();

                    FileManager.SetFileExtension(".dat");
                    FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
                }
            }

            return sended;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-22 ] ///
        /// @ DummySend @                                                                                           ///
        ///     임의의 데이터 패킷을 매개변수로 전달된 길이만큼 생성하여 원격지로 전송한다.                         ///
        ///     통신 연결 유지 또는 상태 점검을 위해 활용한다.                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="pack_len">int : 데이터 패킷 길이</param>                                                   ///
        ///=========================================================================================================///
        public void DummySend(object pack_len)
        {
            while (is_terminate == false)
            {
                if (DummyMode == true)
                {
                    if ((DateTime.Now.Second % 10) == 0)
                    {
                        try
                        {
                            byte[] dummy = new byte[(int)pack_len];

                            for (int i = 0; i < (int)pack_len; i++)
                            {
                                dummy[i] = (byte)(i + 1);
                            }

                            Send(dummy);
                        }
                        catch (Exception e)
                        {
                            if (!(e is ThreadAbortException) == true)
                            {
                                MessageBuilder = new StringBuilder();
                                MessageBuilder.AppendLine();
                                MessageBuilder.AppendLine("[ Function : DummySend ]");
                                MessageBuilder.AppendLine("# pack_len : " + pack_len);
                                MessageBuilder.AppendLine();
                                MessageBuilder.AppendLine(e.Message);
                                MessageBuilder.AppendLine();

                                Message = MessageBuilder.ToString();

                                FileManager.SetFileExtension(".dat");
                                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);
                            }
                        }
                    }
                }

                Thread.Sleep(1000);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-07 ] ///
        /// @ BufferingThreadA @                                                                                    ///
        ///     수신되는 데이터에서 프로토콜 패킷을 식별하여 버퍼에 삽입한다.                                       ///
        ///     ※ ETX가 2바이트인 경우 사용                                                                        ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void BufferingThreadA()
        {
            byte[] len = new byte[2];
            byte[] buff = new byte[MinimumPacket];
            string data = string.Empty;
            bool valid = false;

            while (!valid)
            {
                try
                {
                    NS = client.GetStream();
                    valid = true;
                }
                catch (Exception e)
                {
                    MessageBuilder = new StringBuilder();
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine("[ Function : BufferingThreadA_1 ]");
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine(e.Message);
                    MessageBuilder.AppendLine();

                    Message = MessageBuilder.ToString();

                    FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);
                }

                Thread.Sleep(10);
            }

            while (is_terminate == false)
            {
                try
                {
                    if (is_terminate == true)
                    {
                        break;
                    }

                    if (client.Connected == true)
                    {
                        if (client.Available >= ReadMin)
                        {
                            byte stx;

                            stx = (byte)NS.ReadByte();

                            if (stx == STX)
                            {
                                NS.Read(len, 0, 2);

                                int pack_len = BitConverter.ToInt16(len, 0);

                                if (pack_len < ValidLimit)
                                {
                                    while (client.Available < pack_len) ;

                                    buff = new byte[pack_len + 3];

                                    buff[0] = stx;
                                    buff[1] = len[0]; buff[2] = len[1];

                                    NS.Read(buff, 3, pack_len);

                                    if ((buff[buff.Length - 2] == ETXA[0]) && (buff[buff.Length - 1] == ETXA[1]))
                                    {
                                        PacketData.Add(CommonBase.Hex2Str16(buff, buff.Length));

                                        if ((buff[6] == 'X') && (buff[7] == 'X') && (buff[8] == 'X'))
                                        {
                                            DisConnecting(Remote_IP, Remote_port);
                                        }
                                        else
                                        {
                                            if (isBuffer1 == true)
                                            {
                                                PacketBuffer1.Add(buff);
                                            }
                                            else
                                            {
                                                PacketBuffer2.Add(buff);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        is_terminate = true;
                    }
                }
                catch (Exception e)
                {
                    if (!(e is ThreadAbortException))
                    {
                        MessageBuilder = new StringBuilder();
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine("[ Function : BufferingThreadA_2 ]");
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine(e.Message);
                        MessageBuilder.AppendLine();

                        Message = MessageBuilder.ToString();

                        FileManager.SetFileExtension(".dat");
                        FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);

                        if (NS != null)
                        {
                            NS.Close();
                        }

                        Close();
                    }
                }

                if (is_HighSpeed == false)
                {
                    Thread.Sleep(5);
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-07 ] ///
        /// @ WritingThread @                                                                                       ///
        ///     저장 플래그가 설정되면 버퍼에 저장된 데이터를 파일로 저장한다.                                      ///
        ///     Tcp 연결이 유효한 동안 계속 수행되므로 스레드 함수로 사용해야 메인 스레드에 영향을 주지 않는다.     ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================/// 
        private void WritingThread()
        {
            while (is_terminate == false)
            {
                if (Logging == true)
                {
                    try
                    {
                        DateTime now = DateTime.Now;

                        string today = now.Year.ToString("0000") + now.Month.ToString("00") + now.Day.ToString("00");

                        FileManager.MakeDir(Application.StartupPath + "\\" + DataPath, "Data_" + today);

                        StreamWriter sw = new StreamWriter(DataPath + "\\Data_" + today +
                            "\\Datas_" + now.Hour.ToString("00") + "_" + Remote_IP + "_" + Remote_port + ".dat", true);

                        string[] packet = PacketData.ToArray();
                        PacketData.Clear();
                        StringBuilder sb = new StringBuilder();

                        foreach (string data in packet)
                        {
                            sb.AppendLine(data);
                        }

                        sw.Write(sb.ToString());
                        sw.Flush();
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBuilder = new StringBuilder();
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine("[ Function : WritingThread ]");
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine(e.Message);
                        MessageBuilder.AppendLine();

                        Message = MessageBuilder.ToString();

                        FileManager.SetFileExtension(".dat");
                        FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
                    }
                }

                Thread.Sleep(10000);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-07 ] ///
        /// @ DummySender @                                                                                         ///
        ///     더미 패킷을 60초 주기로 전송한다.                                                                   ///
        ///     Tcp 연결이 유효한 동안 계속 수행되므로 스레드 함수로 사용해야 메인 스레드에 영향을 주지 않는다.     ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void DummySender()
        {
            try
            {
                Dummy = new Thread(new ParameterizedThreadStart(DummySend));
                Dummy.Start(MinimumPacket);
            }
            catch (Exception e)
            {
                if (!(e is ThreadAbortException) == true)
                {
                    MessageBuilder = new StringBuilder();
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine("[ Function : DummySender ]");
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine(e.Message);
                    MessageBuilder.AppendLine();

                    Message = MessageBuilder.ToString();

                    FileManager.SetFileExtension(".dat");
                    FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-07 ] ///
        /// @ GetPackets @                                                                                          ///
        ///     데이터 버퍼에 저장된 패킷을 반환한다.                                                               ///
        /// </summary>                                                                                              ///
        /// <returns>List<byte[]> : 데이터 패킷 리스트</returns>                                                    ///
        ///=========================================================================================================///
        public List<byte[]> GetPackets()
        {
            List<byte[]> CopyBuffer = new List<byte[]>();

            if (isBuffer1 == true)
            {
                isBuffer1 = false;

                lock (PacketBuffer1)
                {
                    CopyBuffer = PacketBuffer1.GetRange(0, PacketBuffer1.Count);
                    PacketBuffer1.Clear();
                }
            }
            else
            {
                isBuffer1 = true;

                lock (PacketBuffer2)
                {
                    CopyBuffer = PacketBuffer2.GetRange(0, PacketBuffer2.Count);
                    PacketBuffer2.Clear();
                }
            }

            return CopyBuffer;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-07 ] ///
        /// @ GetConntected @                                                                                       ///
        ///     Tcp 통신 객체의 연결 여부를 반환한다.                                                               ///
        /// </summary>                                                                                              ///
        /// <returns>bool : Tcp 연결 여부</returns>                                                                 ///
        ///=========================================================================================================///
        public bool GetConntected() 
        {
            if (client != null)
            {
                return client.Connected;
            }
            else
            {
                return false;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-08 ] ///
        /// @ GetRemotePort @                                                                                       ///
        ///     현재 연결된 원격지의 포트 정보를 반환한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <returns>int : 포트 번호</returns>                                                                      ///
        ///=========================================================================================================///
        public int GetRemotePort() { return Remote_port; }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-07-08 ] ///
        /// @ GetRemoteIP @                                                                                         ///
        ///     현재 연결된 원격지의 IP 정보를 반환한다.                                                            ///
        /// </summary>                                                                                              ///
        /// <returns>string : IP 주소</returns>                                                                     ///
        ///=========================================================================================================///
        public string GetRemoteIP() { return Remote_IP; }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2016-11-21 ] ///
        /// @ BufferingThreadB @                                                                                    ///
        ///     수신되는 데이터에서 프로토콜 패킷을 식별하여 버퍼에 삽입한다.                                       ///
        ///     ※ ETX가 1바이트인 경우 사용                                                                        ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void BufferingThreadB()
        {
            byte[] len = new byte[2];
            byte[] buff = new byte[MinimumPacket];
            string data = string.Empty;
            bool valid = false;

            while (!valid)
            {
                try
                {
                    NS = client.GetStream();
                    valid = true;
                }
                catch (Exception e)
                {
                    MessageBuilder = new StringBuilder();
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine("[ Function : BufferingThreadB_1 ]");
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine(e.Message);
                    MessageBuilder.AppendLine();

                    Message = MessageBuilder.ToString();

                    FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);
                }

                Thread.Sleep(10);
            }

            while (is_terminate == false)
            {
                try
                {
                    if (is_terminate == true)
                    {
                        break;
                    }

                    if (client.Connected == true)
                    {
                        if (client.Available >= ReadMin)
                        {
                            byte stx;

                            stx = (byte)NS.ReadByte();

                            if (stx == STX)
                            {
                                NS.Read(len, 1, 1);
                                NS.Read(len, 0, 1);

                                int pack_len = BitConverter.ToInt16(len, 0);

                                if (pack_len < ValidLimit)
                                {
                                    while (client.Available < (pack_len - 1)) ;

                                    buff = new byte[pack_len + 2];

                                    buff[0] = stx;
                                    buff[1] = len[1]; buff[2] = len[0];

                                    NS.Read(buff, 3, pack_len - 1);

                                    if (buff[buff.Length - 1] == ETX)
                                    {
                                        PacketData.Add(CommonBase.Hex2Str16(buff, buff.Length));

                                        if ((buff[6] == 'X') && (buff[7] == 'X') && (buff[8] == 'X'))
                                        {
                                            DisConnecting(Remote_IP, Remote_port);
                                        }
                                        else
                                        {
                                            if (isBuffer1 == true)
                                            {
                                                PacketBuffer1.Add(buff);
                                            }
                                            else
                                            {
                                                PacketBuffer2.Add(buff);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        is_terminate = true;
                    }
                }
                catch (Exception e)
                {
                    if (!(e is ThreadAbortException))
                    {
                        MessageBuilder = new StringBuilder();
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine("[ Function : BufferingThreadB_2 ]");
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine(e.Message);
                        MessageBuilder.AppendLine();

                        Message = MessageBuilder.ToString();

                        FileManager.SetFileExtension(".dat");
                        FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);

                        if (NS != null)
                        {
                            NS.Close();
                        }

                        Close();
                    }
                }

                if (is_HighSpeed == false)
                {
                    Thread.Sleep(5);
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2016-11-21 ] ///
        /// @ BufferingThreadC @                                                                                    ///
        ///     수신되는 데이터에서 프로토콜 패킷을 식별하여 버퍼에 삽입한다.                                       ///
        ///     ※ SKT - PDM 프로젝트의 프로토콜 전용                                                               ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void BufferingThreadC()
        {
            byte[] len = new byte[2];
            byte[] buff = new byte[MinimumPacket];
            string data = string.Empty;
            bool valid = false;

            while (!valid)
            {
                try
                {
                    NS = client.GetStream();
                    valid = true;
                }
                catch (Exception e)
                {
                    MessageBuilder = new StringBuilder();
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine("[ Function : BufferingThreadC_1 ]");
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine(e.Message);
                    MessageBuilder.AppendLine();

                    Message = MessageBuilder.ToString();

                    FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);
                }

                Thread.Sleep(10);
            }

            while (is_terminate == false)
            {
                try
                {
                    if (is_terminate == true)
                    {
                        break;
                    }

                    if (client.Connected == true)
                    {
                        if (client.Available > ReadMin)
                        {
                            int limit = client.Available;
                            bool end_ck = false;

                            for (int i = 0; i < limit; i++)
                            {
                                byte b = (byte)NS.ReadByte();

                                if (b == ETX)
                                {
                                    if (end_ck == false)
                                    {
                                        end_ck = true;
                                    }
                                    else
                                    {
                                        if (PacketBuffer.Count > DataFire)
                                        {
                                            string val = Encoding.ASCII.GetString(PacketBuffer.ToArray());

                                            NotifyData(Local_port, PacketBuffer.ToArray());
                                            PacketBuffer.Clear();
                                        }

                                        end_ck = false;
                                    }
                                }
                                else
                                {
                                    end_ck = false;
                                }

                                PacketBuffer.Add(b);
                            }
                        }
                    }
                    else
                    {
                        is_terminate = true;
                    }
                }
                catch (Exception e)
                {
                    if (!(e is ThreadAbortException))
                    {
                        MessageBuilder = new StringBuilder();
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine("[ Function : BufferingThreadC_2 ]");
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine(e.Message);
                        MessageBuilder.AppendLine();

                        Message = MessageBuilder.ToString();

                        FileManager.SetFileExtension(".dat");
                        FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);

                        if (NS != null)
                        {
                            NS.Close();
                        }

                        Close();
                    }
                }

                Thread.Sleep(500);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2016-11-21 ] ///
        /// @ BufferingThreadD @                                                                                    ///
        ///     수신되는 데이터에서 프로토콜 패킷을 식별하여 버퍼에 삽입한다.                                       ///
        ///     ※ SKT - AI-LEMS 프로젝트의 프로토콜 대응                                                           ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void BufferingThreadD()
        {
            byte Length;
            byte MsgType;
            byte[] buff = new byte[MinimumPacket];
            string data = string.Empty;
            bool valid = false;

            while (!valid)
            {
                try
                {
                    NS = client.GetStream();
                    valid = true;
                }
                catch (Exception e)
                {
                    MessageBuilder = new StringBuilder();
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine("[ Function : BufferingThreadD_1 ]");
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine(e.Message);
                    MessageBuilder.AppendLine();

                    Message = MessageBuilder.ToString();

                    FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);
                }

                Thread.Sleep(10);
            }

            while (is_terminate == false)
            {
                try
                {
                    if (is_terminate == true)
                    {
                        break;
                    }

                    if (client.Connected == true)
                    {
                        if (client.Available >= ReadMin)
                        {
                            byte stx;

                            stx = (byte)NS.ReadByte();

                            if (stx == STX)
                            {
                                Length = (byte)NS.ReadByte();
                                MsgType = (byte)NS.ReadByte();

                                int pack_len = Convert.ToInt32(Length);

                                if (pack_len < ValidLimit)
                                {
                                    while (client.Available < (pack_len - 1)) ;

                                    buff = new byte[pack_len + 2];

                                    buff[0] = stx;
                                    buff[1] = Length;
                                    buff[2] = MsgType;

                                    NS.Read(buff, 3, pack_len - 1);

                                    if (buff[buff.Length - 1] == ETX)
                                    {
                                        PacketData.Add(CommonBase.Hex2Str16(buff, buff.Length));

                                        if ((buff[6] == 'X') && (buff[7] == 'X') && (buff[8] == 'X'))
                                        {
                                            DisConnecting(Remote_IP, Remote_port);
                                        }
                                        else
                                        {
                                            if (isBuffer1 == true)
                                            {
                                                lock (PacketBuffer1)
                                                {
                                                    PacketBuffer1.Add(buff);
                                                }
                                            }
                                            else
                                            {
                                                lock (PacketBuffer2)
                                                {
                                                    PacketBuffer2.Add(buff);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        is_terminate = true;
                    }
                }
                catch (Exception e)
                {
                    if (!(e is ThreadAbortException))
                    {
                        MessageBuilder = new StringBuilder();
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine("[ Function : BufferingThreadD_2 ]");
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine(e.Message);
                        MessageBuilder.AppendLine();

                        Message = MessageBuilder.ToString();

                        FileManager.SetFileExtension(".dat");
                        FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);

                        if (NS != null)
                        {
                            NS.Close();
                        }

                        is_terminate = true;
                    }
                }

                if (is_HighSpeed == false)
                {
                    Thread.Sleep(5);
                }
            }
        }
        #endregion

        #region [ # Ver 1.03 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2014-12-14 ] ///
        /// @ GetETX @                                                                                              ///
        ///     ETX 값을 반환한다.                                                                                  ///
        /// </summary>                                                                                              ///
        /// <returns> byte : ETX 값 </returns>                                                                      ///
        ///=========================================================================================================///
        public byte GetETX() { return ETX; }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2014-12-14 ] ///
        /// @ SetETX @                                                                                              ///
        ///     매개변수로 전달된 값을 ETX 값으로 설정한다.                                                         ///
        /// </summary>                                                                                              ///
        /// <param name="etx"> byte : ETX 값 </param>                                                               ///
        ///=========================================================================================================///
        public void SetETX(byte etx) { ETX = etx; }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2014-12-14 ] ///
        /// @ GetETXs @                                                                                             ///
        ///     2 byte로 구성된 ETX를 반환한다.                                                                     ///
        /// </summary>                                                                                              ///
        /// <returns> byte[] : ETX 값 배열 </returns>                                                               ///
        ///=========================================================================================================///
        public byte[] GetETXs() { return ETXA; }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2016-12-14 ] ///
        /// @ SetETX @                                                                                              ///
        ///     매개변수로 전달된 값(2 byte)을 ETX 값으로 설정한다.                                                 ///
        /// </summary>                                                                                              ///
        /// <param name="etx"> byte[] : ETX 값 </param>                                                             ///
        ///=========================================================================================================///
        public void SetETX(byte[] etx)
        {
            if (etx.Length >= 2)
            {
                ETXA[0] = etx[0];
                ETXA[1] = etx[1];
            }
        }
        #endregion

        #region [ # Ver 1.04 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2017-04-11 ] ///
        /// @ TCP_Comm_Manager @                                                                                    ///
        ///     TCP 통신 객체 생성자로 매개변수로 원격지 IP와 포트 번호를 넘겨받아 접속을 시도한다.                 ///
        /// </summary>                                                                                              ///
        /// <param name="ip"> stirng : 원격지 접속 IP 주소 </param>                                                 ///
        /// <param name="port" >int : 원격지 접속 포트 번호 </param>                                                ///
        /// <param name="TCM"> string : 데이터 처리 방식 </param>                                                   ///
        ///=========================================================================================================///
        public TCP_Comm_Manager(string ip, int port, string TCM)
        {
            try
            {
                client = new TcpClient(ip, port);

                TCM_Type = TCM;
            }
            catch (Exception e)
            {
                MessageBox.Show("접속에 실패했습니다.", "Connect Failed");

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : TCP_Comm_Manager ]");

                if (string.IsNullOrEmpty(ip) == true)
                {
                    MessageBuilder.AppendLine("# ip      : NULL / Empty");
                }
                else
                {
                    MessageBuilder.AppendLine("# ip      : " + ip);
                }

                MessageBuilder.AppendLine("# port    : " + port);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            Init();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2017-04-11 ] ///
        /// @ TCP_Comm_Manager @                                                                                    ///
        ///     TCP 통신 객체 생성자로 매개변수로 TcpClient를 넘겨받는다.                                           ///
        ///     원격지 서버와 연결이 완료된 객체를 이용하여 데이터 통신을 수행할 준비를 한다.                       ///
        /// </summary>                                                                                              ///
        /// <param name="tc">TcpClient : 원격지 접속 Tcp 통신 객체</param>                                          ///
        /// <param name="TCM"> string : 데이터 처리 방식 </param>                                                   ///
        ///=========================================================================================================///
        public TCP_Comm_Manager(TcpClient tc, string TCM)
        {
            client = tc;
            TCM_Type = TCM;

            Init();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2017-01-17 ] ///
        /// @ BufferingThreadP @                                                                                    ///
        ///     수신되는 데이터를 버퍼에 삽입한다.                                                                  ///
        ///     ※ 데이터 by pass                                                                                   ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void BufferingThreadP()
        {
            byte[] buff = new byte[MinimumPacket];
            string data = string.Empty;
            bool valid = false;

            while (!valid)
            {
                try
                {
                    NS = client.GetStream();
                    valid = true;
                }
                catch (Exception e)
                {
                    MessageBuilder = new StringBuilder();
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine("[ Function : BufferingThreadP_1 ]");
                    MessageBuilder.AppendLine();
                    MessageBuilder.AppendLine(e.Message);
                    MessageBuilder.AppendLine();

                    Message = MessageBuilder.ToString();

                    FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);
                }

                Thread.Sleep(10);
            }

            while (is_terminate == false)
            {
                try
                {
                    if (is_terminate == true)
                    {
                        break;
                    }

                    if (client.Connected == true)
                    {
                        if (client.Available > 0)
                        {
                            buff = new byte[client.Available];

                            NS.Read(buff, 0, buff.Length);

                            PacketData.Add(CommonBase.Hex2Str16(buff, buff.Length));

                            if (isBuffer1 == true)
                            {
                                PacketBuffer1.Add(buff);
                            }
                            else
                            {
                                PacketBuffer2.Add(buff);
                            }
                        }
                    }
                    else
                    {
                        is_terminate = true;
                    }
                }
                catch (Exception e)
                {
                    if (!(e is ThreadAbortException))
                    {
                        MessageBuilder = new StringBuilder();
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine("[ Function : BufferingThreadP_2 ]");
                        MessageBuilder.AppendLine();
                        MessageBuilder.AppendLine(e.Message);
                        MessageBuilder.AppendLine();

                        Message = MessageBuilder.ToString();

                        FileManager.SetFileExtension(".dat");
                        FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, false, false, true);

                        if (NS != null)
                        {
                            NS.Close();
                        }

                        Close();
                    }
                }

                if (is_HighSpeed == false)
                {
                    Thread.Sleep(5);
                }
            }
        }
        #endregion

        #region [ # Ver 1.05 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.05 / 2019-01-15 ] ///
        /// @ SetDummyMode @                                                                                        ///
        ///     네트워크 연결 확인용 더미 패킷 전송 모드를 설정한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 더미 전송 모드 </param>                                                      ///
        ///=========================================================================================================///
        public void SetDummyMode(bool mode)
        {
            DummyMode = mode;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.05 / 2019-01-15 ] ///
        /// @ SetLoggingMode @                                                                                      ///
        ///     로그 파일 저장 모드를 설정한다.                                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 로그 파일 저장 모드 </param>                                                 ///
        ///=========================================================================================================///
        public void SetLoggingMode(bool mode)
        {
            Logging = mode;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.05 / 2019-01-15 ] ///
        /// @ SetHighSpeedMode @                                                                                    ///
        ///     데이터 처리 모드를 설정한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> bool : 데이터 고속 처리 모드 </param>                                               ///
        ///=========================================================================================================///
        public void SetHighSpeedMode(bool mode)
        {
            is_HighSpeed = mode;
        }
        #endregion
    }
    ///=========================================================================== End of Class : TCP_Comm_Manager =///
}
