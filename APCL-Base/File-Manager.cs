using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.02 / 2019-03-20 ] ///
    /// ▷ FileManager : CommonVariables ◁                                                                         ///
    ///     파일 기능 관련 클래스로 파일 입출력 기능을 지원하며 경로 생성 등의 부가 기능을 지원한다.                ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-03-28 ]                                                                                   ///
    ///     ▶ 경로 생성 기능 지원                                                                                  ///
    ///     ▶ 파일 사용 여부 확인, 확장자 변경 지원                                                                ///
    ///     ▶ 파일 단일 / 다중 데이터 파일 저장 지원                                                               ///
    ///     ▶ 비동기 방식 파일 저장 지원                                                                           ///
    ///     ▶ 이진 파일 입출력 지원                                                                                ///
    /// [ Ver 1.01 / 2014-09-30 ]                                                                                   ///
    ///     ▶ 파일 확장자 변경 기능                                                                                ///
    /// [ Ver 1.02 / 2019-03-20 ]                                                                                   ///
    ///     ▶ 압축 / 헤제 기능                                                                                     ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class FileManager : CommonVariables
    {
        #region [ # Defines & Variables ]
        static private string FileExtension = ".dat";
        static private string FileName = string.Empty;
        static private string DefaultName = "Default";
        static private string FilePath = string.Empty;
        static private string DefaultPath = string.Empty;
        static private string FullName = string.Empty;

        static private Mutex mutex = new Mutex();
        static private StreamWriter SW = null;
        static private readonly int BuffSize = 4096;

        static private string Message = string.Empty;
        static private StringBuilder MessageBuilder;

        static private FileStream FStream;
        static private BinaryFormatter BinFormatter;
        static private List<object> BinBuffer;
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ MakePath @                                                                                            ///
        ///     매개변수로 지정한 경로의 하위에 기본 설정 폴더들을 생성한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="home"> string : 기본 설정 폴더 생성 경로 </param>                                          ///
        ///=========================================================================================================///
        public static void MakePath(string home)
        {
            try
            {
                if (home.Equals(string.Empty) == false)
                {
                    DefaultPath = home;

                    MakeDir(home, AlarmPath);
                    MakeDir(home, ConfigPath);
                    MakeDir(home, CRCPath);
                    MakeDir(home, DataPath);
                    MakeDir(home, DownPath);
                    MakeDir(home, ErrorPath);
                    MakeDir(home, LogPath);
                }
                else
                {
                    DefaultPath = "C:";
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.MakePath ] ");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(home) == true)
                {
                    MessageBuilder.AppendLine("▶ home     : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ home     : " + home);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ MakePath @                                                                                            ///
        ///     매개변수로 지정한 경로의 하위에 기본 설정 폴더를 생성한다.                                          ///
        ///     기본 설정 폴더 중 선택 생성이 가능하다.                                                             ///
        /// </summary>                                                                                              ///
        /// <param name="home"> string : 기본 설정 폴더 생성 경로 </param>                                          ///
        /// <param name="selection"> BitArray : 생성 폴더 설정 변수 </param>                                        ///
        ///=========================================================================================================///
        public static void MakePath(string home, BitArray selection)
        {
            try
            {
                if (home.Equals(string.Empty) == false)
                {
                    DefaultPath = home;

                    if (selection[0] == true) MakeDir(home, AlarmPath);
                    if (selection[1] == true) MakeDir(home, ConfigPath);
                    if (selection[2] == true) MakeDir(home, CRCPath);
                    if (selection[3] == true) MakeDir(home, DataPath);
                    if (selection[4] == true) MakeDir(home, DownPath);
                    if (selection[5] == true) MakeDir(home, ErrorPath);
                    if (selection[6] == true) MakeDir(home, LogPath);
                }
                else
                {
                    DefaultPath = "C:";
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.MakePath ]");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(home) == true)
                {
                    MessageBuilder.AppendLine("▶ home     : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ home     : " + home);
                }
                
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ MakeDir @                                                                                             ///
        ///     매개변수로 지정된 경로에 지정된 이름의 하위 폴더를 생성하고 생성 여부를 반환한다.                   ///
        /// </summary>                                                                                              ///
        /// <param name="parent"> string : 하위 폴더를 생성할 경로 </param>                                         ///
        /// <param name="sub"> string : 생성할 하위 폴더의 이름 </param>                                            ///
        /// <returns> bool : 폴더 생성 결과 </returns>                                                              ///
        ///=========================================================================================================///
        public static bool MakeDir(string parent, string sub)
        {
            try
            {
                string path = Path.Combine(parent, sub);
                DirectoryInfo di = new DirectoryInfo(parent);

                if (!Directory.Exists(path) == true)
                {
                    di = Directory.CreateDirectory(path);
                }

                if (di.FullName == path)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.MakeDir ]");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(parent) == true)
                {
                    MessageBuilder.AppendLine("▶ parent   : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ parent   : " + parent);
                }

                if (string.IsNullOrEmpty(sub) == true)
                {
                    MessageBuilder.AppendLine("▶ sub      : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ sub      : " + sub);
                }
                
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ IsFileLocked @                                                                                        ///
        ///     매개변수로 지정한 경로의 파일이 다른 프로세스에서 사용 중인지 확인하여 그 여부를 반환한다.          ///
        /// </summary>                                                                                              ///
        /// <param name="filefullname"> string : 사용 여부 확인 파일 경로 </param>                                  ///
        /// <returns> bool : 파일 사용 여부 확인 결과 </returns>                                                    ///
        ///=========================================================================================================///
        public static bool IsFileLocked(string filefullname)
        {
            FileInfo fi = new FileInfo(filefullname);
            FileStream stream = null;

            try
            {
                if (fi.Exists == true)
                {
                    stream = fi.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                else
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null) stream.Close();
            }

            return false;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ SetFileExtension @                                                                                    ///
        ///     파일 저장에 사용되는 확장자를 매개변수로 지정한 확장자로 변경한다.                                  ///
        /// </summary>                                                                                              ///
        /// <param name="extension"> string : 변경할 파일 확장자 </param>                                           ///
        ///=========================================================================================================///
        public static void SetFileExtension(string extension)
        {
            if (extension.Contains('.') == true)
            {
                FileExtension = extension;
            }
            else
            {
                FileExtension = "." + extension;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ LogWriter @                                                                                           ///
        ///     매개 변수로 전달된 내용을 지정된 경로의 파일로 저장한다.                                            ///
        ///     파일명에 일자나 내용에 시간 기재를 선택할 수 있다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="msg"> string : 파일에 저장할 내용 </param>                                                 ///
        /// <param name="filepath"> string : 파일을 저장할 경로 </param>                                            ///
        /// <param name="filename"> string : 파일 이름 </param>                                                     ///
        /// <param name="time"> bool : 파일에 시간 표시 여부 </param>                                               ///
        /// <param name="colone"> bool : 시간에 ':' 표시 여부 </param>                                              ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        public static void LogWriter(string msg, string filepath, string filename,
            bool time, bool colone, bool longdate, bool dash, bool append)
        {
            if (string.IsNullOrEmpty(filepath) == true)
            {
                FilePath = DefaultPath;
            }
            else
            {
                FilePath = filepath;
            }

            if (string.IsNullOrEmpty(filename) == true)
            {
                FileName = DefaultName;
            }
            else
            {
                FileName = filename;
            }

            Writing(msg, time, colone, true, longdate, dash, append);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ LogWriter @                                                                                           ///
        ///     매개 변수로 전달된 내용을 지정된 경로의 파일로 저장한다.                                            ///
        ///     파일명에 일자나 내용에 시간 기재를 선택할 수 있다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object[] : 파일에 저장할 데이터 배열 </param>                                       ///
        /// <param name="filepath"> string : 파일을 저장할 경로 </param>                                            ///
        /// <param name="filename"> string : 파일 이름 </param>                                                     ///
        /// <param name="time"> bool : 파일에 시간 표시 여부 </param>                                               ///
        /// <param name="colone"> bool : 시간에 ':' 표시 여부 </param>                                              ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        public static void LogWriter(object[] msg, string filepath, string filename,
            bool time, bool colone, bool longdate, bool dash, bool append)
        {
            if (string.IsNullOrEmpty(filepath) == true)
            {
                FilePath = DefaultPath;
            }
            else
            {
                FilePath = filepath;
            }

            if (string.IsNullOrEmpty(filename) == true)
            {
                FileName = DefaultName;
            }
            else
            {
                FileName = filename;
            }

            Writing(msg, true, time, colone, true, longdate, dash, append);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ DataWriter @                                                                                          ///
        ///     매개 변수로 전달된 데이터를 지정된 경로의 파일로 저장한다.                                          ///
        ///     파일명에 일자나 내용에 시간 기재를 선택할 수 있다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object : 파일에 저장할 데이터 </param>                                              ///
        /// <param name="filepath"> string : 파일을 저장할 경로 </param>                                            ///
        /// <param name="filename"> string : 파일 이름 </param>                                                     ///
        /// <param name="time"> bool : 파일에 시간 표시 여부 </param>                                               ///
        /// <param name="colone"> bool : 시간에 ':' 표시 여부 </param>                                              ///
        /// <param name="date"> bool : 파일 이름에 일자 표시 여부 </param>                                          ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        public static void DataWriter(object data, string filepath, string filename,
            bool time, bool colone, bool date, bool longdate, bool dash, bool append)
        {
            if (string.IsNullOrEmpty(filepath) == true)
            {
                FilePath = DefaultPath;
            }
            else
            {
                FilePath = filepath;
            }

            if (string.IsNullOrEmpty(filename) == true)
            {
                FileName = DefaultName;
            }
            else
            {
                FileName = filename;
            }

            Writing(data, time, colone, date, longdate, dash, append);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ DataWriter @                                                                                          ///
        ///     매개 변수로 전달된 데이터(배열)를 지정된 경로의 파일로 저장한다.                                    ///
        ///     데이터를 한 줄로 저장하거나 데이터 사이에 줄 간격 설정을 선택할 수 있다.                            ///
        ///     파일명에 일자나 내용에 시간 기재를 선택할 수 있다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object[] : 파일에 저장할 데이터 배열 </param>                                       ///
        /// <param name="oneline"> bool : 데이터를 한 줄로 저장 여부 </param>                                       ///
        /// <param name="filepath"> string : 파일을 저장할 경로 </param>                                            ///
        /// <param name="time"> bool : 파일에 시간 표시 여부 </param>                                               ///
        /// <param name="colone"> bool : 시간에 ':' 표시 여부 </param>                                              ///
        /// <param name="date"> bool : 파일 이름에 일자 표시 여부 </param>                                          ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        public static void DataWriter(object[] data, bool oneline, string filepath, string filename,
            bool time, bool colone, bool date, bool longdate, bool dash, bool append)
        {
            if (string.IsNullOrEmpty(filepath) == true)
            {
                FilePath = DefaultPath;
            }
            else
            {
                FilePath = filepath;
            }

            if (string.IsNullOrEmpty(filename) == true)
            {
                FileName = DefaultName;
            }
            else
            {
                FileName = filename;
            }

            Writing(data, oneline, time, colone, date, longdate, dash, append);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ Writing @                                                                                             ///
        ///     매개변수로 전달된 데이터를 지정된 양식에 따라 파일로 저장한다.                                      ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object : 파일에 저장할 데이터 </param>                                              ///
        /// <param name="time"> bool : 파일에 시간 표시 여부 </param>                                               ///
        /// <param name="colone"> bool : 시간에 ':' 표시 여부 </param>                                              ///
        /// <param name="date"> bool : 파일 이름에 일자 표시 여부 </param>                                          ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        private static void Writing(object data, bool time, bool colone, bool date, bool longdate, bool dash, bool append)
        {
            try
            {
                mutex.WaitOne();

                if (date == true)
                {
                    FullName = FilePath + "\\" + FileName + "(" + GetDay(longdate, dash) + ")" + FileExtension;
                }
                else
                {
                    FullName = FilePath + "\\" + FileName + FileExtension;
                }

                while (IsFileLocked(FilePath) == true)
                {
                    Thread.Sleep(100);
                }

                using (StreamWriter sWriter = new StreamWriter(FullName, append))
                {
                    string data_str = string.Empty;

                    if (time == true)
                    {
                        data_str = GetTime(colone) + " : ";
                    }

                    sWriter.WriteLine(data_str + data);
                    sWriter.Flush();
                    sWriter.Close();
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.Writing ]");
                MessageBuilder.AppendLine();

                if (data == null)
                {
                    MessageBuilder.AppendLine("▶ data     : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ data     : " + data);
                }

                MessageBuilder.AppendLine("▶ time     : " + time.ToString());
                MessageBuilder.AppendLine("▶ colone   : " + colone.ToString());
                MessageBuilder.AppendLine("▶ date     : " + date.ToString());
                MessageBuilder.AppendLine("▶ longdate : " + longdate.ToString());
                MessageBuilder.AppendLine("▶ dash     : " + dash.ToString());
                MessageBuilder.AppendLine("▶ append   : " + append.ToString());
                MessageBuilder.AppendLine();

                if (mutex == null)
                {
                    MessageBuilder.AppendLine("▷ Mutex    : NULL");
                }

                if (string.IsNullOrEmpty(FullName) == true)
                {
                    MessageBuilder.AppendLine("▷ FullName : NULL / Empty");
                }
                else
                {
                    MessageBuilder.AppendLine("▷ FullName : " + FullName);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FilePath = ErrorPath + @"\" + ErrorLogName + "(" + GetDay(true, true) + ").dat";

                while (IsFileLocked(FilePath) == true)
                {
                    Thread.Sleep(100);
                }

                using (StreamWriter sWriter = new StreamWriter(FilePath, append))
                {
                    sWriter.WriteLine(Message);
                    sWriter.Flush();
                    sWriter.Close();
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ Writing @                                                                                             ///
        ///     매개변수로 전달된 데이터(배열)를 지정된 양식에 따라 파일로 저장한다.                                ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object[] : 파일에 저장할 데이터 </param>                                            ///
        /// <param name="oneline"> bool : 데이터를 한 줄로 저장할 지 여부 </param>                                  ///
        /// <param name="time"> bool : 파일에 시간 표시 여부 </param>                                               ///
        /// <param name="colone"> bool : 시간에 ':' 표시 여부 </param>                                              ///
        /// <param name="date"> bool : 파일 이름에 일자 표시 여부 </param>                                          ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        private static void Writing(object[] data, bool oneline, bool time, bool colone, bool date, bool longdate, bool dash, bool append)
        {
            try
            {
                mutex.WaitOne();

                if (date == true)
                {
                    FullName = FilePath + "\\" + FileName + "(" + GetDay(longdate, dash) + ")" + FileExtension;
                }
                else
                {
                    FullName = FilePath + "\\" + FileName + FileExtension;
                }

                while (IsFileLocked(FilePath) == true)
                {
                    Thread.Sleep(100);
                }

                using (StreamWriter sWriter = new StreamWriter(FullName, append))
                {
                    StringBuilder data_str = new StringBuilder();

                    if (time == true) data_str.Append(GetTime(colone) + " : ");

                    if (data != null)
                    {
                        if (oneline == true)
                        {
                            for (int i = 0; i < data.Length; i++)
                                data_str.Append(data[i].ToString() + ",");

                            sWriter.WriteLine(data_str);
                        }
                        else
                        {
                            for (int i = 0; i < data.Length; i++)
                                data_str.AppendLine(data[i].ToString());

                            sWriter.WriteLine(data_str.ToString());
                        }
                    }

                    sWriter.Flush();
                    sWriter.Close();
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.Writing ]");
                MessageBuilder.AppendLine();

                if (data == null)
                {
                    MessageBuilder.AppendLine("▶ data     : NULL");
                }
                else
                {
                    int cnt = 0;

                    foreach (object o in data)
                    {
                        if (o == null)
                        {
                            cnt++;
                        }
                    }

                    MessageBuilder.AppendLine("▶ data     : " + cnt + " nulls / " + data.Length);
                }

                MessageBuilder.AppendLine("▶ oneline  : " + oneline.ToString());
                MessageBuilder.AppendLine("▶ time     : " + time.ToString());
                MessageBuilder.AppendLine("▶ colone   : " + colone.ToString());
                MessageBuilder.AppendLine("▶ date     : " + date.ToString());
                MessageBuilder.AppendLine("▶ longdate : " + longdate.ToString());
                MessageBuilder.AppendLine("▶ dash     : " + dash.ToString());
                MessageBuilder.AppendLine("▶ append   : " + append.ToString());
                MessageBuilder.AppendLine();

                if (mutex == null)
                {
                    MessageBuilder.AppendLine("▷ Mutex    : NULL");
                }

                if (string.IsNullOrEmpty(FullName) == true)
                {
                    MessageBuilder.AppendLine("▷ FullName : NULL / Empty");
                }
                else
                {
                    MessageBuilder.AppendLine("▷ FullName : " + FullName);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FilePath = ErrorPath + @"\" + ErrorLogName + "(" + GetDay(true, true) + ").dat";

                while (IsFileLocked(FilePath) == true)
                {
                    Thread.Sleep(100);
                }

                using (StreamWriter sWriter = new StreamWriter(FilePath, append))
                {
                    sWriter.WriteLine(Message + e.ToString() + Environment.NewLine);
                    sWriter.Flush();
                    sWriter.Close();
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ GetTime @                                                                                             ///
        ///     함수가 호출된 시점의 시간을 지정된 양식의 문자열로 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="colone"> bool : 시간에 ':' 표시 여부 </param>                                              ///
        /// <returns> string : 시간 문자열 </returns>                                                               ///
        ///=========================================================================================================///
        public static string GetTime(bool colone)
        {
            string result = string.Empty;
            string hour = string.Empty, minute = string.Empty, second = string.Empty;

            hour = DateTime.Now.Hour.ToString("00");
            minute = DateTime.Now.Minute.ToString("00");
            second = DateTime.Now.Second.ToString("00");

            if (colone == true)
            {
                result = hour + ":" + minute + ":" + second;
            }
            else
            {
                result = hour + minute + second;
            }

            return result;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-26 ] ///
        /// @ GetDay @                                                                                              ///
        ///     함수가 호출된 시점의 일자를 지정된 양식의 문자열로 반환한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="full"> bool : 일자에 연도 포함 여부 </param>                                               ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <returns> string : 일자 문자열 </returns>                                                               ///
        ///=========================================================================================================///
        public static string GetDay(bool full, bool dash)   
        {
            string result = string.Empty;
            string year = string.Empty, month = string.Empty, day = string.Empty;

            year = DateTime.Now.Year.ToString("0000");
            month = DateTime.Now.Month.ToString("00");
            day = DateTime.Now.Day.ToString("00");

            if ((full == true) && (dash == true))
            {
                result = year + "-" + month + "-" + day;
            }
            else if ((full == true) && (dash == false))
            {
                result = year + month + day;
            }
            else if ((full == false) && (dash == true))
            {
                result = month + "-" + day;
            }
            else
            {
                result = month + day;
            }

            return result;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-27 ] ///
        /// @ BeginWrite @                                                                                          ///
        ///     매개변수로 전달된 데이터를 지정된 경로의 파일로 저장한다.                                           ///
        ///     파일명에 일자나 내용에 시간 기재를 선택할 수 있다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object : 파일에 저장할 데이터 </param>                                              ///
        /// <param name="filepath"> string : 파일을 저장할 경로 </param>                                            ///
        /// <param name="filename"> string : 파일 이름 </param>                                                     ///
        /// <param name="time"> bool : 파일에 시간 표시 여부 </param>                                               ///
        /// <param name="colone"> bool : 시간에 ':' 표시 여부 </param>                                              ///
        /// <param name="date"> bool : 파일 이름에 일자 표시 여부 </param>                                          ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        public static void BeginWrite(object data, string filepath, string filename, 
            bool time, bool colone, bool date, bool longdate, bool dash, bool append)
        {
            if (string.IsNullOrEmpty(filepath) == true)
            {
                FilePath = DefaultPath;
            }
            else
            {
                FilePath = filepath;
            }

            if (string.IsNullOrEmpty(filename) == true)
            {
                FileName = DefaultName;
            }
            else
            {
                FileName = filename;
            }

            AsyncWriting(data, time, colone, date, longdate, dash, append);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-27 ] ///
        /// @ BeginWrite @                                                                                          ///
        ///     매개변수로 전달된 데이터를 지정된 경로의 파일로 저장한다.                                           ///
        ///     데이터를 한 줄로 저장하거나 데이터 사이에 줄 간격 설정을 선택할 수 있다.                            ///
        ///     파일명에 일자나 내용에 시간 기재를 선택할 수 있다.                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object : 파일에 저장할 데이터 </param>                                              ///
        /// <param name="filepath"> string : 파일을 저장할 경로 </param>                                            ///
        /// <param name="filename"> string : 파일 이름 </param>                                                     ///
        /// <param name="time"> bool : 파일에 시간 표시 여부 </param>                                               ///
        /// <param name="colone"> bool : 시간에 ':' 표시 여부 </param>                                              ///
        /// <param name="date"> bool : 파일 이름에 일자 표시 여부 </param>                                          ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        public static void BeginWrite(object[] data, bool oneline, string filepath, string filename,
            bool time, bool colone, bool date, bool longdate, bool dash, bool append)
        {
            if (string.IsNullOrEmpty(filepath) == true)
            {
                FilePath = DefaultPath;
            }
            else
            {
                FilePath = filepath;
            }

            if (string.IsNullOrEmpty(filename) == true)
            {
                FileName = DefaultName;
            }
            else
            {
                FileName = filename;
            }

            AsyncWriting(data, oneline, time, colone, date, longdate, dash, append);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-27 ] ///
        /// @ AsyncWriting @                                                                                        ///
        ///     매개변수로 전달된 데이터를 지정된 양식에 따라 파일로 저장한다.                                      ///
        ///     데이터 저장 후 파일스트림을 닫지 않고 유지한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object : 파일에 저장할 데이터 </param>                                              ///
        /// <param name="time"> bool : 파일에 시간 표시 여부 </param>                                               ///
        /// <param name="colone"> bool : 시간에 ':' 표시 여부 </param>                                              ///
        /// <param name="date"> bool : 파일 이름에 일자 표시 여부 </param>                                          ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        private static void AsyncWriting(object data, bool time, bool colone, bool date, bool longdate, bool dash, bool append)
        {
            try
            {
                if (SW == null)
                {
                    if (date == true)
                    {
                        FullName = FilePath + "\\" + FileName + "(" + GetDay(longdate, dash) + ")" + FileExtension;
                    }
                    else
                    {
                        FullName = FilePath + "\\" + FileName + FileExtension;
                    }

                    if (append == true)
                    {
                        FStream = new FileStream(FullName, FileMode.Append, FileAccess.Write, FileShare.None);
                    }
                    else
                    {
                        FStream = new FileStream(FullName, FileMode.Create, FileAccess.Write, FileShare.None);
                    }

                    SW = new StreamWriter(FStream, Encoding.GetEncoding("ks_c_5601-1987"), BuffSize);
                    SW.AutoFlush = true;
                    FStream.Close();
                }

                object buff = string.Empty;

                if (time == true)
                {
                    buff = GetTime(colone) + " : " + data;
                }
                else
                {
                    buff = data;
                }

                SW.WriteLine(buff);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.AsyncWriting ]");
                MessageBuilder.AppendLine();

                if (data == null)
                {
                    MessageBuilder.AppendLine("▶ data     : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ data     : " + data);
                }

                MessageBuilder.AppendLine("▶ time     : " + time.ToString());
                MessageBuilder.AppendLine("▶ colone   : " + colone.ToString());
                MessageBuilder.AppendLine("▶ date     : " + date.ToString());
                MessageBuilder.AppendLine("▶ longdate : " + longdate.ToString());
                MessageBuilder.AppendLine("▶ dash     : " + dash.ToString());
                MessageBuilder.AppendLine("▶ append   : " + append.ToString());
                MessageBuilder.AppendLine();

                if (SW == null)
                {
                    MessageBuilder.AppendLine("▷ StreamWriter : NULL");
                }

                if (string.IsNullOrEmpty(FullName) == true)
                {
                    MessageBuilder.AppendLine("▷ FullName : NULL / Empty");
                }
                else
                {
                    MessageBuilder.AppendLine("▷ FullName : " + FullName);
                }

                if (FStream == null)
                {
                    MessageBuilder.AppendLine("▷ FileStream : NULL");
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FilePath = ErrorPath + @"\" + ErrorLogName + "(" + GetDay(true, true) + ").dat";

                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-27 ] ///
        /// @ AsyncWriting @                                                                                        ///
        ///     매개변수로 전달된 데이터(배열)를 지정된 양식에 따라 파일로 저장한다.                                ///
        ///     데이터 저장 후 파일스트림을 닫지 않고 유지한다.                                                     ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object[] : 파일에 저장할 데이터 </param>                                            ///
        /// <param name="oneline"> bool : 데이터를 한 줄로 저장할 지 여부 </param>                                  ///
        /// <param name="time"> bool : 파일에 시간 표시 여부 </param>                                               ///
        /// <param name="colone"> bool : 시간에 ':' 표시 여부 </param>                                              ///
        /// <param name="date"> bool : 파일 이름에 일자 표시 여부 </param>                                          ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        private static void AsyncWriting(object[] data, bool oneline, bool time, bool colone, bool date, bool longdate, bool dash, bool append)
        {
            try
            {
                if (SW == null)
                {
                    if (date == true)
                    {
                        FullName = FilePath + "\\" + FileName + "(" + GetDay(longdate, dash) + ")" + FileExtension;
                    }
                    else
                    {
                        FullName = FilePath + "\\" + FileName + FileExtension;
                    }

                    if (append == true)
                    {
                        FStream = new FileStream(FullName, FileMode.Append, FileAccess.Write, FileShare.None);
                    }
                    else
                    {
                        FStream = new FileStream(FullName, FileMode.Create, FileAccess.Write, FileShare.None);
                    }

                    SW = new StreamWriter(FStream, Encoding.GetEncoding("ks_c_5601-1987"), BuffSize);
                    SW.AutoFlush = true;
                    FStream.Close();
                }

                foreach (object obj in data)
                {
                    object buff = string.Empty;

                    if (time == true)
                    {
                        buff = GetTime(colone) + " : " + obj;
                    }
                    else
                    {
                        buff = data;
                    }

                    if (oneline == true)
                    {
                        SW.Write(buff);
                    }
                    else
                    {
                        SW.WriteLine(buff);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.BeginWrite ]");
                MessageBuilder.AppendLine();

                if (data == null)
                {
                    MessageBuilder.AppendLine("# data     : NULL");
                }
                else
                {
                    int cnt = 0;

                    foreach (object o in data)
                    {
                        if (o == null) cnt++;
                    }

                    MessageBuilder.AppendLine("▶ data     : " + cnt + " nulls / " + data.Length);
                }

                MessageBuilder.AppendLine("▶ oneline  : " + oneline.ToString());
                MessageBuilder.AppendLine("▶ time     : " + time.ToString());
                MessageBuilder.AppendLine("▶ colone   : " + colone.ToString());
                MessageBuilder.AppendLine("▶ date     : " + date.ToString());
                MessageBuilder.AppendLine("▶ longdate : " + longdate.ToString());
                MessageBuilder.AppendLine("▶ dash     : " + dash.ToString());
                MessageBuilder.AppendLine("▶ append   : " + append.ToString());
                MessageBuilder.AppendLine();

                if (SW == null)
                {
                    MessageBuilder.AppendLine("▷ StreamWriter : NULL");
                }

                if (string.IsNullOrEmpty(FullName) == true)
                {
                    MessageBuilder.AppendLine("▷ FullName : NULL / Empty");
                }
                else
                {
                    MessageBuilder.AppendLine("▷ FullName : " + FullName);
                }

                if (FStream == null)
                {
                    MessageBuilder.AppendLine("▷ FileStream : NULL");
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FilePath = ErrorPath + @"\" + ErrorLogName + "(" + GetDay(true, true) + ").dat";

                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-27 ] ///
        /// @ EndWrite @                                                                                            ///
        ///     AsyncWriting에서 유지하고 있는 파일스트림의 버퍼 데이터를 파일로 저장하고 닫는다.                   ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public static void EndWrite()
        {
            try
            {
                SW.Flush();
                SW.Close();
                SW.Dispose();
                SW = null;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.EndWrite ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();
                
                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        ///     매개변수로 전달된 데이터를 지정된 경로의 파일에 이진화하여 저장한다.                                ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object : 파일에 저장할 데이터 </param>                                              ///
        /// <param name="filepath"> string : 파일을 저장할 경로 </param>                                            ///
        /// <param name="filename"> string : 파일 이름 </param>                                                     ///
        /// <param name="date"> bool : 파일 이름에 일자 표시 여부 </param>                                          ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        public static void BinaryWriter(object data, string filepath, string filename, bool date, bool longdate, bool dash, bool append)
        {
            if (string.IsNullOrEmpty(filepath) == true)
            {
                FilePath = DefaultPath;
            }
            else
            {
                FilePath = filepath;
            }

            if (string.IsNullOrEmpty(filename) == true)
            {
                FileName = DefaultName;
            }
            else
            {
                FileName = filename;
            }

            BinaryWriting(data, date, longdate, dash, append);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ BinaryWriting @                                                                                       ///
        ///     매개변수로 전달된 데이터를 지정된 양식으로 파일에 이진화하여 저장한다.                              ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object : 파일에 저장할 데이터 </param>                                              ///
        /// <param name="date"> bool : 파일 이름에 일자 표시 여부 </param>                                          ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        public static void BinaryWriting(object data, bool date, bool longdate, bool dash, bool append)
        {
            try
            {
                if (date == true)
                {
                    FullName = FilePath + "\\" + FileName + "(" + GetDay(longdate, dash) + ")" + FileExtension;
                }
                else
                {
                    FullName = FilePath + "\\" + FileName + FileExtension;
                }

                if (append == true)
                {
                    FStream = new FileStream(FullName, FileMode.Append, FileAccess.Write, FileShare.None);
                }
                else
                {
                    FStream = new FileStream(FullName, FileMode.Create, FileAccess.Write, FileShare.None);
                }

                BinFormatter = new BinaryFormatter();

                BinFormatter.Serialize(FStream, data);

                FStream.Close();
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.BinaryWriting ]");
                MessageBuilder.AppendLine();

                if (data == null)
                {
                    MessageBuilder.AppendLine("▶ data     : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ data     : " + data);
                }

                MessageBuilder.AppendLine("▶ date     : " + date.ToString());
                MessageBuilder.AppendLine("▶ longdate : " + longdate.ToString());
                MessageBuilder.AppendLine("▶ dash     : " + dash.ToString());
                MessageBuilder.AppendLine("▶ append   : " + append.ToString());
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(FullName) == true)
                {
                    MessageBuilder.AppendLine("▷ FullName : NULL / Empty");
                }
                else
                {
                    MessageBuilder.AppendLine("▷ FullName : " + FullName);
                }

                if (FStream == null)
                {
                    MessageBuilder.AppendLine("▷ FileStream : NULL");
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FilePath = ErrorPath + @"\" + ErrorLogName + "(" + GetDay(true, true) + ").dat";

                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ BinaryWriting @                                                                                       ///
        ///     매개변수로 전달된 데이터(배열)를 지정된 양식으로 파일에 이진화하여 저장한다.                        ///
        /// </summary>                                                                                              ///
        /// <param name="data"> object : 파일에 저장할 데이터 </param>                                              ///
        /// <param name="date"> bool : 파일 이름에 일자 표시 여부 </param>                                          ///
        /// <param name="longdate"> bool : 일자에 연도 포함 여부 </param>                                           ///
        /// <param name="dash"> bool : 일자에 '-' 표시 여부 </param>                                                ///
        /// <param name="append"> bool : 기존 파일에 이어쓰기 여부 </param>                                         ///
        ///=========================================================================================================///
        public static void BinaryWriting(object[] data, bool date, bool longdate, bool dash, bool append)
        {
            try
            {
                if (date == true)
                {
                    FullName = FilePath + "\\" + FileName + "(" + GetDay(longdate, dash) + ")" + FileExtension;
                }
                else
                {
                    FullName = FilePath + "\\" + FileName + FileExtension;
                }

                if (append == true)
                {
                    FStream = new FileStream(FullName, FileMode.Append, FileAccess.Write, FileShare.None);
                }
                else
                {
                    FStream = new FileStream(FullName, FileMode.Create, FileAccess.Write, FileShare.None);
                }

                BinFormatter = new BinaryFormatter();

                for (int i = 0; i < data.Length; i++)
                {
                    BinFormatter.Serialize(FStream, data);
                }

                FStream.Close();
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.BinaryWriting ]");
                MessageBuilder.AppendLine();

                if (data == null)
                {
                    MessageBuilder.AppendLine("▶ data     : NULL");
                }
                else
                {
                    int cnt = 0;

                    foreach (object o in data)
                    {
                        if (o == null) cnt++;
                    }

                    MessageBuilder.AppendLine("▶ data     : " + cnt + " nulls / " + data.Length);
                }

                MessageBuilder.AppendLine("▶ date     : " + date.ToString());
                MessageBuilder.AppendLine("▶ longdate : " + longdate.ToString());
                MessageBuilder.AppendLine("▶ dash     : " + dash.ToString());
                MessageBuilder.AppendLine("▶ append   : " + append.ToString());
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(FullName) == true)
                {
                    MessageBuilder.AppendLine("▷ FullName : NULL / Empty");
                }
                else
                {
                    MessageBuilder.AppendLine("▷ FullName : " + FullName);
                }

                if (FStream == null)
                {
                    MessageBuilder.AppendLine("▷ FileStream : NULL");
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FilePath = ErrorPath + @"\" + ErrorLogName + "(" + GetDay(true, true) + ").dat";

                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message + e.ToString() + Environment.NewLine, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-03-28 ] ///
        /// @ BinaryRead @                                                                                          ///
        ///     매개변수로 지정된 파일에서 이진 데이터를 읽어들여 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="filepath"> string : 파일 경로 </param>                                                     ///
        /// <returns> object[] : 파일 내용 </returns>                                                               ///
        ///=========================================================================================================///
        public static object[] BinaryRead(string filepath)
        {
            FStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinFormatter = new BinaryFormatter();
            BinBuffer = new List<object>();

            while (FStream.Position != FStream.Length)
            {
                BinBuffer.Add(BinFormatter.Deserialize(FStream));
            }

            FStream.Close();

            return BinBuffer.ToArray();
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-09-30 ] ///
        /// @ ChangeFileExtension @                                                                                 ///
        ///     파일 확장자를 변경한다.                                                                             ///
        /// </summary>                                                                                              ///
        /// <param name="fileextension"> string : 파일 확장자 </param>                                              ///
        ///=========================================================================================================///
        public static void ChangeFileExtension(string fileextension)
        {
            if (string.IsNullOrEmpty(fileextension) == false)
            {
                if (fileextension.Contains(".") == true)
                {
                    FileExtension = fileextension;
                }
                else
                {
                    FileExtension = ("." + fileextension);
                }
            }
        }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2019-03-20 ] ///
        /// @ CreateZIPFile @                                                                                       ///
        ///     매개변수로 지정된 경로의 파일을 압축한다.                                                           ///
        /// </summary>                                                                                              ///
        /// <param name="sourceFolder"> string : 압축 대상 경로 </param>                                            ///
        /// <param name="zipFilePath"> string : 압축 파일 저장 경로 </param>                                        ///
        ///=========================================================================================================///
        public static void CreateZIPFile(string sourceFolder, string zipFilePath)
        {
            try
            {
                ZipFile.CreateFromDirectory(sourceFolder, zipFilePath, CompressionLevel.Optimal, true);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.CreateZIPFile ] ");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(sourceFolder) == true)
                {
                    MessageBuilder.AppendLine("▶ sourceFolder : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ sourceFolder : " + sourceFolder);
                }

                if (string.IsNullOrEmpty(zipFilePath) == true)
                {
                    MessageBuilder.AppendLine("▶ zipFilePath : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ zipFilePath : " + sourceFolder);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2019-03-20 ] ///
        /// @ CreateZIPFile @                                                                                       ///
        ///     매개변수로 지정된 경로의 파일을 압축한다.                                                           ///
        /// </summary>                                                                                              ///
        /// <param name="sourceFolder"> string : 압축 대상 경로 </param>                                            ///
        /// <param name="zipFilePath"> string : 압축 파일 저장 경로 </param>                                        ///
        /// <param name="encode"> Encoding : 인코딩 방식 (기본 방식 UTF-8) </param>                                 ///
        ///=========================================================================================================///
        public static void CreateZIPFile(string sourceFolder, string zipFilePath, Encoding encode)
        {
            try
            {
                ZipFile.CreateFromDirectory(sourceFolder, zipFilePath, CompressionLevel.Optimal, true, encode);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.CreateZIPFile ] ");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(sourceFolder) == true)
                {
                    MessageBuilder.AppendLine("▶ sourceFolder : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ sourceFolder : " + sourceFolder);
                }

                if (string.IsNullOrEmpty(zipFilePath) == true)
                {
                    MessageBuilder.AppendLine("▶ zipFilePath : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ zipFilePath : " + sourceFolder);
                }

                MessageBuilder.AppendLine("▶ Encoding : " + encode);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2019-03-20 ] ///
        /// @ ExtractZIPFile @                                                                                      ///
        ///     매개변수로 지정된 경로에 압축 파일을 추출한다.                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="zipPath"> string : 압축 파일 경로 </param>                                                 ///
        /// <param name="extractPath"> string : 압축 해제 경로 </param>                                             ///
        ///=========================================================================================================///
        public static void ExtractZIPFile(string zipPath, string extractPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.CreateZIPFile ] ");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(zipPath) == true)
                {
                    MessageBuilder.AppendLine("▶ zipPath  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ zipPath  : " + zipPath);
                }

                if (string.IsNullOrEmpty(extractPath) == true)
                {
                    MessageBuilder.AppendLine("▶ extractPath : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ extractPath : " + extractPath);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2019-03-20 ] ///
        /// @ ExtractZIPFile @                                                                                      ///
        ///     매개변수로 지정된 경로에 압축 파일을 추출한다.                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="zipPath"> string : 압축 파일 경로 </param>                                                 ///
        /// <param name="extractPath"> string : 압축 해제 경로 </param>                                             ///
        /// <param name="encode"> Encoding : 인코딩 방식 (기본 방식 UTF-8) </param>                                 ///
        ///=========================================================================================================///
        public static void ExtractZIPFile(string zipPath, string extractPath, Encoding encode)
        {
            try
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath, encode);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileManager.CreateZIPFile ] ");
                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(zipPath) == true)
                {
                    MessageBuilder.AppendLine("▶ zipPath  : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ zipPath  : " + zipPath);
                }

                if (string.IsNullOrEmpty(extractPath) == true)
                {
                    MessageBuilder.AppendLine("▶ extractPath : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("▶ extractPath : " + extractPath);
                }

                MessageBuilder.AppendLine("▶ Encoding : " + encode);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                SetFileExtension(".dat");
                LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }
        #endregion
    }
    ///================================================================================ End of Class : FileManager =///
}
