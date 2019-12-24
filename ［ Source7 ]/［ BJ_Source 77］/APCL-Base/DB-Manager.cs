using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2019-04-24 ] ///
    /// ▷ DB_Result ◁                                                                                             ///
    ///     
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2019-04-24 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public struct DB_Result
    {
        public object data;
        public Type type; 
    }

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.02 / 2019-04-24 ] ///
    /// ▷ DB_Manager : CommonVariables ◁                                                                          ///
    ///     DB 관리자에서 공통적으로 사용하는 변수 선언 및 SQL 쿼리문 생성 함수 정의                                ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-07-10 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2017-04-10 ]                                                                                   ///
    ///     ▶ 다중 서버 환경 접속 기능                                                                             ///
    /// [ Ver 1.02 / 2019-04-24 ]                                                                                   ///
    ///     ▶ SQL 쿼리문 생성 시 파라미터 이용 값 설정                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class DB_Manager : CommonVariables
    {
        #region [ # Defines & Variables ]
        static public string Message = string.Empty;
        static public StringBuilder MessageBuilder;
        static public StringBuilder QueryBuilder;

        public string Source = string.Empty;
        public int Port = 0;
        public string Catalog = string.Empty;
        public string ID = string.Empty;
        public string PW = string.Empty;
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ SetConnector @                                                                                        ///
        ///     매개변수로 전달된 정보를 기반으로 DB 접속 쿼리문을 작성하여 반환한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="source"> string : DB 서버 주소 </param>                                                    ///
        /// <param name="ID"> string : DB 접속 ID </param>                                                          ///
        /// <param name="PW"> string : DB 접속 암호 </param>                                                        ///
        /// <returns> string : DB 접속 쿼리문 </returns>                                                            ///
        ///=========================================================================================================///
        public string SetConnector(string source, string ID, string PW)
        {
            string conn = "Data Source=" + source + ";User ID=" + ID + ";Password=" + PW;

            return conn;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ SetConnector @                                                                                        ///
        ///     매개변수로 전달된 정보를 기반으로 DB 접속 쿼리문을 작성하여 반환한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="source"> string : DB 서버 주소 </param>                                                    ///
        /// <param name="port"> int : DB Port 번호 </param>                                                         ///
        /// <param name="ID"> string : DB 접속 ID </param>                                                          ///
        /// <param name="PW"> string : DB 접속 암호 </param>                                                        ///
        /// <returns> string : DB 접속 쿼리문 </returns>                                                            ///
        ///=========================================================================================================///
        public string SetConnector(string source, int port, string ID, string PW)
        {
            string conn = "Data Source=" + source + "; Port=" + port + ";User ID=" + ID + ";Password=" + PW;

            return conn;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ SetConnector @                                                                                        ///
        ///     매개변수로 전달된 정보를 기반으로 DB 접속 쿼리문을 작성하여 반환한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="source"> string : DB 서버 주소 </param>                                                    ///
        /// <param name="catalog"> string : DB 목록 </param>                                                        ///
        /// <param name="ID"> string : DB 접속 ID </param>                                                          ///
        /// <param name="PW"> string : DB 접속 암호 </param>                                                        ///
        /// <returns> string : DB 접속 쿼리문 </returns>                                                            ///
        ///=========================================================================================================///
        public string SetConnector(string source, string catalog, string ID, string PW)
        {
            string conn = "Data Source=" + source + ";Initial Catalog=" + catalog + ";User ID=" + ID + ";Password=" + PW;

            return conn;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ Insert_Query @                                                                                        ///
        ///     DB 테이블에 데이터를 삽입하는 쿼리문을 작성하여 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="data"> string[] : DB 삽입 데이터 </param>                                                  ///
        /// <returns> string : DB 삽입 쿼리문 </returns>                                                            ///
        ///=========================================================================================================///
        public string Insert_Query(string table, string[] data)
        {
            QueryBuilder = new StringBuilder();
            QueryBuilder.Append("INSERT INTO ");
            QueryBuilder.Append(table);
            QueryBuilder.Append(" VALUES(");

            for (int i = 0; i < data.Length; i++)
            {
                QueryBuilder.Append("'" + data[i] + "'");

                if (i < (data.Length - 1))
                {
                    QueryBuilder.Append(", ");
                }
            }

            QueryBuilder.Append(")");

            string insert_sql = QueryBuilder.ToString();
            
            return insert_sql;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ Select_Query @                                                                                        ///
        ///     DB 테이블의 데이터를 조회하는 쿼리문을 작성하여 반환한다.                                           ///
        ///     (* fields와 condition 항목은 비어있을 수 있음)                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="fields"> string : 데이터 조회 필드 </param>                                                ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> string : 데이터 조회 쿼리문 </returns>                                                        ///
        ///=========================================================================================================///
        public string Select_Query(string table, string fields, string condition)
        {
            QueryBuilder = new StringBuilder();
            QueryBuilder.Append("SELECT ");

            if (string.IsNullOrEmpty(fields) == true)
            {
                QueryBuilder.Append("*");
            }
            else
            {
                if (fields.Equals("*") == false)
                {
                    QueryBuilder.Append("`" + fields + "`");
                }
                else
                {
                    QueryBuilder.Append(fields);
                }
            }

            QueryBuilder.Append(" FROM ");
            QueryBuilder.Append(table);

            if (string.IsNullOrEmpty(condition) == false)
            {
                QueryBuilder.Append(" WHERE ");
                QueryBuilder.Append(condition);
            }

            string select_sql = QueryBuilder.ToString();

            return select_sql;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ Update_Query @                                                                                        ///
        ///     DB에서 매개변수로 지정한 조건에 만족하는 필드의 값을 변경하는 쿼리문을 작성하여 반환한다.           ///
        ///     (* condition 항목은 비어있을 수 있음)                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="field"> string : 데이터 조회 필드 </param>                                                 ///
        /// <param name="value"> string : 변경할 값 </param>                                                        ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> string : 데이터 업데이트 쿼리문 </returns>                                                    ///
        ///=========================================================================================================///
        public string Update_Query(string table, string field, string value, string condition)
        {
            QueryBuilder = new StringBuilder();
            QueryBuilder.Append("UPDATE ");
            QueryBuilder.Append(table);
            QueryBuilder.Append(" SET ");
            QueryBuilder.Append("`" + field + "`");
            QueryBuilder.Append(" = '");
            QueryBuilder.Append(value + "'");

            if (string.IsNullOrEmpty(condition) == false)
            {
                QueryBuilder.Append(" WHERE ");
                QueryBuilder.Append(condition);
            }

            string update_sql = QueryBuilder.ToString();

            return update_sql;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ Update_Query @                                                                                        ///
        ///     DB에서 매개변수로 지정한 조건에 만족하는 필드의 값을 변경하는 쿼리문을 작성하여 반환한다.           ///
        ///     (* condition 항목은 비어있을 수 있음)                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="field"> string[] : 데이터 조회 필드 </param>                                               ///
        /// <param name="value"> string[] : 변경할 값 </param>                                                      ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> string : 데이터 업데이트 쿼리문 </returns>                                                    ///
        ///=========================================================================================================///
        public string Update_Query(string table, string[] field, string[] value, string condition)
        {
            QueryBuilder = new StringBuilder();
            QueryBuilder.Append("UPDATE ");
            QueryBuilder.Append(table);
            QueryBuilder.Append(" SET ");

            for (int i = 0; i < field.Length; i++)
            {
                QueryBuilder.Append("`" + field[i] + "`");
                QueryBuilder.Append(" = '");
                QueryBuilder.Append(value[i] + "'");

                if (i < (field.Length - 1))
                {
                    QueryBuilder.Append(", ");
                }
            }

            if (string.IsNullOrEmpty(condition) == false)
            {
                QueryBuilder.Append(" WHERE ");
                QueryBuilder.Append(condition);
            }

            string update_sql = QueryBuilder.ToString();

            return update_sql;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ Delete_Query @                                                                                        ///
        ///     DB에서 지정한 조건에 해당하는 항목을 삭제하는 쿼리문을 작성하여 반환한다.                           ///
        ///     (* condition 항목은 비어있을 수 있음)                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="condition"> string : 데이터 삭제 조건 </param>                                             ///
        /// <returns> string : 데이터 삭제 쿼리문 </returns>                                                        ///
        ///=========================================================================================================///
        public string Delete_Query(string table, string condition)
        {
            QueryBuilder = new StringBuilder();
            QueryBuilder.Append("DELETE FROM ");
            QueryBuilder.Append(table);

            if (string.IsNullOrEmpty(condition) == false)
            {
                QueryBuilder.Append(" WHERE ");
                QueryBuilder.Append(condition);
            }

            string delete_sql = QueryBuilder.ToString();

            return delete_sql;
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2017-04-10 ] ///
        /// @ SetConnector @                                                                                        ///
        ///     매개변수로 전달된 정보를 기반으로 DB 접속 쿼리문을 작성하여 반환한다.                               ///
        /// </summary>                                                                                              ///
        /// <param name="source"> string : DB 서버 주소 </param>                                                    ///
        /// <param name="port"> int : DB Port 번호 </param>                                                         ///
        /// <param name="catalog"> string : DB 목록 </param>                                                        ///
        /// <param name="ID"> string : DB 접속 ID </param>                                                          ///
        /// <param name="PW"> string : DB 접속 암호 </param>                                                        ///
        /// <returns> string : DB 접속 쿼리문 </returns>                                                            ///
        ///=========================================================================================================///
        public string SetConnector(string source, int port, string catalog, string ID, string PW)
        {
            string conn = "Data Source=" + source + "; Port=" + port + ";Initial Catalog=" + catalog + ";User ID=" + ID + ";Password=" + PW;

            return conn;
        }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2019-04-24 ] ///
        /// @ Insert_Command @                                                                                      ///
        ///     DB 테이블에 데이터를 삽입하는 쿼리문을 작성하여 반환한다.                                           ///
        ///     (* 커맨드의 파라미터에 값을 설정하는 방식)                                                          ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="field"> string[] : DB 테이블 필드 정보 </param>                                            ///
        /// <returns> string : DB 삽입 쿼리문 </returns>                                                            ///
        ///=========================================================================================================///
        public string Insert_Command(string table, string[] field)
        {
            QueryBuilder = new StringBuilder();
            QueryBuilder.Append("INSERT INTO ");
            QueryBuilder.Append(table + "(");

            for (int i = 0; i < field.Length; i++)
            {
                QueryBuilder.Append("'" + field[i] + "'");

                if (i < (field.Length - 1))
                {
                    QueryBuilder.Append(", ");
                }
            }

            QueryBuilder.Append(" VALUES(");

            for (int i = 0; i < field.Length; i++)
            {
                QueryBuilder.Append("@" + field[i]);

                if (i < (field.Length - 1))
                {
                    QueryBuilder.Append(", ");
                }
            }

            QueryBuilder.Append(")");

            return QueryBuilder.ToString();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2019-04-24 ] ///
        /// @ Update_Command @                                                                                      ///
        ///     DB에서 매개변수로 지정한 조건에 만족하는 필드의 값을 변경하는 쿼리문을 작성하여 반환한다.           ///
        ///     (* condition 항목은 비어있을 수 있음)                                                               ///
        ///     (* 커맨드의 파라미터에 값을 설정하는 방식)                                                          ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="field"> string[] : 데이터 조회 필드 </param>                                               ///
        /// <param name="value"> string[] : 변경할 값 </param>                                                      ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> string : 데이터 업데이트 쿼리문 </returns>                                                    ///
        ///=========================================================================================================///
        public string Update_Command(string table, string[] field, string condition)
        {
            QueryBuilder = new StringBuilder();
            QueryBuilder.Append("UPDATE ");
            QueryBuilder.Append(table);
            QueryBuilder.Append(" SET ");

            for (int i = 0; i < field.Length; i++)
            {
                QueryBuilder.Append("`" + field[i] + "`");
                QueryBuilder.Append(" = @" + field[i]);

                if (i < (field.Length - 1))
                {
                    QueryBuilder.Append(", ");
                }
            }

            if (string.IsNullOrEmpty(condition) == false)
            {
                QueryBuilder.Append(" WHERE ");
                QueryBuilder.Append(condition);
            }

            return QueryBuilder.ToString();
        }

        #endregion
    }
    ///================================================================================= End of Class : DB_Manager =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.02 / 2017-11-24 ] ///
    /// ▷ SQLite_Controller : DB_Manager ◁                                                                        ///
    ///     MySQL에 대응하여 DB 작업을 수행하는 클래스                                                              ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-07-10]                                                                                    ///
    ///     ▶ 데이터 삽입, 조회, 수정, 삭제 기능                                                                   ///
    ///     ▶ 파일 데이터 삽입, 조회 기능                                                                          ///
    /// [ Ver 1.01 / 2014-11-25 ]                                                                                   ///
    ///     ▶ 테이블 추가, 삭제 기능                                                                               ///
    /// [ Ver 1.02 / 2017-11-24 ]                                                                                   ///
    ///     ▶ DB 쿼리문 매개변수 이용 함수 추가                                                                    ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class SQLite_Controller : DB_Manager
    {
        #region [ # Defines & Variables ]
        private SQLiteConnection sqConn;
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ SQLite_Controller @                                                                                   ///
        ///     매개변수로 전달된 정보를 이용하여 SQLite DB 서버와의 작업 관리 객체를 생성한다.                     ///
        ///=========================================================================================================///
        public SQLite_Controller()
        {
            sqConn = new SQLiteConnection();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ Connection @                                                                                          ///
        ///     DB 서버로 접속을 시도하며 그 결과를 반환한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="Srouce"> string : DB 파일 이름 </param>                                                    ///
        /// <returns> bool : DB 서버 접속 여부 </returns>                                                           ///
        ///=========================================================================================================///
        public bool Connection(string source)
        {
            try
            {
                string db;

                if (source.Contains(".db") == true)
                {
                    db = source;
                }
                else
                {
                    db = source + ".db";
                }

                sqConn.ConnectionString = "Data Source=" + db + ";Pooling=true;";
                sqConn.Open();

                if (sqConn.State == ConnectionState.Open)
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
                MessageBuilder.AppendLine("[ Function : Connection ]");

                if (string.IsNullOrEmpty(Source) == true)
                {
                    MessageBuilder.AppendLine("# Source  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# Source  : " + Source);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ DisConnection @                                                                                       ///
        ///     DB 서버와의 연결 해제를 시도하며 그 결과를 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <returns> bool : 접속 해제 여부 </returns>                                                              ///
        ///=========================================================================================================///
        public bool DisConnection()
        {
            try
            {
                sqConn.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : DisConnection ]");
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ Select @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 데이터를 DB 서버에서 조회하여 그 결과를 반환한다.                 ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="fields"> string : 데이터 조회 필드 </param>                                                ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> DataTable : DB 서버 조회 결과 </returns>                                                      ///
        ///=========================================================================================================///
        public DataTable Select(string table, string fields, string condition)
        {
            DataTable dt = new DataTable();
            string select_sql = Select_Query(table, fields, condition);

            try
            {
                SQLiteCommand sqCommnad = new SQLiteCommand(sqConn);
                sqCommnad.CommandType = CommandType.Text;
                sqCommnad.CommandText = select_sql;

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqCommnad);
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Fucntion : Select ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (string.IsNullOrEmpty(fields) == true)
                {
                    MessageBuilder.AppendLine("# fields  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# fields  : " + fields);
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + select_sql);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return dt;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ Insert @                                                                                              ///
        ///     DB 서버에 신규 데이터의 삽입을 시도하여 그 결과를 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="data"> string[] : DB 삽입 데이터 </param>                                                  ///
        /// <returns> bool : 데이터 삽입 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Insert(string table, string[] data)
        {
            string insert_sql = Insert_Query(table, data);

            try
            {
                SQLiteCommand sqCommand = new SQLiteCommand(sqConn);
                sqCommand.CommandType = CommandType.Text;
                sqCommand.CommandText = insert_sql;

                if (sqCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Insert ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (data == null)
                {
                    MessageBuilder.AppendLine("# data    : NULL");
                }
                else
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        MessageBuilder.AppendLine("# data(" + i + ") : " + data[i]);
                    }
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + insert_sql);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ Update @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 항목의 값을 업데이트하고 그 결과를 반환한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="field"> string : 데이터 조회 필드 </param>                                                 ///
        /// <param name="value"> string : 변경할 값 </param>                                                        ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> bool : DB 업데이트 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Update(string table, string field, string value, string condition)
        {
            string update_sql = Update_Query(table, field, value, condition);

            try
            {
                SQLiteCommand sqCommand = new SQLiteCommand(sqConn);
                sqCommand.CommandType = CommandType.Text;
                sqCommand.CommandText = update_sql;

                if (sqCommand.ExecuteNonQuery() > 0)
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
                MessageBuilder.AppendLine("[ Function : Update ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (string.IsNullOrEmpty(field) == true)
                {
                    MessageBuilder.AppendLine("# field   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# field   : " + field);
                }

                if (string.IsNullOrEmpty(value) == true)
                {
                    MessageBuilder.AppendLine("# value   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# value   : " + value);
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + update_sql);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ Delete @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 항목을 DB에서 삭제하고 그 결과를 반환한다.                        ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="condition"> string : 데이터 삭제 조건 </param>                                             ///
        /// <returns> bool : 데이터 삭제 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Delete(string table, string condition)
        {
            string delete_sql = Delete_Query(table, condition);

            try
            {
                SQLiteCommand sqCommand = new SQLiteCommand(sqConn);
                sqCommand.CommandType = CommandType.Text;
                sqCommand.CommandText = delete_sql;

                if (sqCommand.ExecuteNonQuery() > 0)
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
                MessageBuilder.AppendLine("[ Function : Delete ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + delete_sql);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-11-25 ] ///
        /// @ CreateTable @                                                                                         ///
        ///     DB에 신규 테이블을 생성한다. 동일 이름의 테이블이 존재 시에는 테이블을 생성하지 않는다.             ///
        /// </summary>                                                                                              ///
        /// <param name="name"> string : DB 테이블 이름 </param>                                                    ///
        /// <param name="column"> string : DB에 추가할 필드 </param>                                                ///
        /// <returns> bool : 테이블 생성 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool CreateTable(string name, string column)
        {
            string create_sql = "CREATE TABLE IF NOT EXISTS " + name + " " + column + ";";
                        
            try
            {
                SQLiteCommand sqCommand = new SQLiteCommand(sqConn);
                sqCommand.CommandType = CommandType.Text;
                sqCommand.CommandText = create_sql;

                if (sqCommand.ExecuteNonQuery() > 0)
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
                MessageBuilder.AppendLine("[ Function : CreateTable ]");

                if (string.IsNullOrEmpty(name) == true)
                {
                    MessageBuilder.AppendLine("# name    : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# name    : " + name);
                }

                if (string.IsNullOrEmpty(column) == true)
                {
                    MessageBuilder.AppendLine("# column  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# column  : " + column);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + create_sql);
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
        /// <summary>                                                                     [ Ver 1.01 / 2014-11-25 ] ///
        /// @ DeleteTable @                                                                                         ///
        ///     매개변수로 전달된 이름과 동일한 테이블을 DB에서 삭제한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="name"> string : DB 테이블 이름 </param>                                                    ///
        /// <returns> bool : 테이블 삭제 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool DeleteTable(string name)
        {
            string create_sql = "DROP TABLE " + name;

            try
            {
                SQLiteCommand sqCommand = new SQLiteCommand(sqConn);
                sqCommand.CommandType = CommandType.Text;
                sqCommand.CommandText = create_sql;

                if (sqCommand.ExecuteNonQuery() > 0)
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
                MessageBuilder.AppendLine("[ Function : CreateTable ]");

                if (string.IsNullOrEmpty(name) == true)
                {
                    MessageBuilder.AppendLine("# name    : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# name    : " + name);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + create_sql);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }
        }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2017-11-24 ] ///
        /// @ Select @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 데이터를 DB 서버에서 조회하여 그 결과를 반환한다.                 ///
        /// </summary>                                                                                              ///
        /// <param name="query"> string : DB 쿼리문 </param>                                                        ///
        /// <returns> DataTable : DB 서버 조회 결과 </returns>                                                      ///
        ///=========================================================================================================///
        public DataTable Select(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand sqCommnad = new SQLiteCommand(sqConn);
                sqCommnad.CommandType = CommandType.Text;
                sqCommnad.CommandText = query;

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqCommnad);
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Fucntion : Select ]");

                if (string.IsNullOrEmpty(query) == true)
                {
                    MessageBuilder.AppendLine("# query   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# query   : " + query);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return dt;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2017-11-24 ] ///
        /// @ Insert @                                                                                              ///
        ///     DB 서버에 신규 데이터의 삽입을 시도하여 그 결과를 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="query"> string : DB 쿼리문 </param>                                                        ///
        /// <returns> bool : 데이터 삽입 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Insert(string query)
        {
            try
            {
                SQLiteCommand sqCommand = new SQLiteCommand(sqConn);
                sqCommand.CommandType = CommandType.Text;
                sqCommand.CommandText = query;

                if (sqCommand.ExecuteNonQuery() > 0)
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
                MessageBuilder.AppendLine("[ Function : Insert ]");

                if (string.IsNullOrEmpty(query) == true)
                {
                    MessageBuilder.AppendLine("# query   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# query   : " + query);
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
        /// <summary>                                                                     [ Ver 1.02 / 2017-11-24 ] ///
        /// @ Update @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 항목의 값을 업데이트하고 그 결과를 반환한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="query"> string : DB 쿼리문 </param>                                                        ///
        /// <returns> bool : DB 업데이트 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Update(string query)
        {
            try
            {
                SQLiteCommand sqCommand = new SQLiteCommand(sqConn);
                sqCommand.CommandType = CommandType.Text;
                sqCommand.CommandText = query;

                if (sqCommand.ExecuteNonQuery() > 0)
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
                MessageBuilder.AppendLine("[ Function : Update ]");

                if (string.IsNullOrEmpty(query) == true)
                {
                    MessageBuilder.AppendLine("# query   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# query   : " + query);
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
        /// <summary>                                                                     [ Ver 1.02 / 2017-11-24 ] ///
        /// @ Delete @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 항목을 DB에서 삭제하고 그 결과를 반환한다.                        ///
        /// </summary>                                                                                              ///
        /// <param name="query"> string : DB 쿼리문 </param>                                                        ///
        /// <returns> bool : 데이터 삭제 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Delete(string query)
        {
            try
            {
                SQLiteCommand sqCommand = new SQLiteCommand(sqConn);
                sqCommand.CommandType = CommandType.Text;
                sqCommand.CommandText = query;

                if (sqCommand.ExecuteNonQuery() > 0)
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
                MessageBuilder.AppendLine("[ Function : Delete ]");

                if (string.IsNullOrEmpty(query) == true)
                {
                    MessageBuilder.AppendLine("# query   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# query   : " + query);
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
        #endregion
    }
    ///========================================================================== End of Class : SQLite_Controller =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.01 / 2016-11-23 ] ///
    /// ▷ MySQL_Controller : DB_Manager ◁                                                                         ///
    ///     MySQL에 대응하여 DB 작업을 수행하는 클래스                                                              ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-07-09 ]                                                                                   ///
    ///     ▶ 데이터 삽입, 조회, 수정, 삭제 기능                                                                   ///
    ///     ▶ 파일 데이터 삽입, 조회 기능                                                                          ///
    /// [ Ver 1.01 / 2016-11-23 ]                                                                                   ///
    ///     ▶ 데이터 삽입, 조회, 수정, 삭제 기능                                                                   ///
    /// [ Ver 1.02 / 2017-04-10 ]                                                                                   ///
    ///     ▶ 다중 서버 환경 접속 기능                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class MySQL_Controller : DB_Manager
    {
        #region [ # Defines & Variables ]
        private MySqlConnection connector;
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ MySQL_Controller @                                                                                    ///
        ///     매개변수로 전달된 정보를 이용하여 MySQL DB 서버와의 작업 관리 객체를 생성한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="s"> string : DB 서버 주소 </param>                                                         ///
        /// <param name="i"> string : DB 접속 ID </param>                                                           ///
        /// <param name="p"> string : DB 접속 암호 </param>                                                         ///
        ///=========================================================================================================///
        public MySQL_Controller(string s, string i, string p)
        {
            try
            {
                Source = s;
                ID = i;
                PW = p;

                connector = new MySqlConnection(SetConnector(Source, ID, PW));
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : MySQL_Controller ]");

                if (string.IsNullOrEmpty(s) == true)
                {
                    MessageBuilder.AppendLine("# source  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# source  : " + s);
                }

                if (string.IsNullOrEmpty(i) == true)
                {
                    MessageBuilder.AppendLine("# id      : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# id      : " + i);
                }

                if (string.IsNullOrEmpty(p) == true)
                {
                    MessageBuilder.AppendLine("# pass    : NULL/ EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# pass    : " + p);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ MySQL_Controller @                                                                                    ///
        ///     매개변수로 전달된 정보를 이용하여 MySQL DB 서버와의 작업 관리 객체를 생성한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="s"> string : DB 서버 주소 </param>                                                         ///
        /// <param name="n"> int : DB 접속 Port 번호 </param>                                                       ///
        /// <param name="i"> string : DB 접속 ID </param>                                                           ///
        /// <param name="p"> string : DB 접속 암호 </param>                                                         ///
        ///=========================================================================================================///
        public MySQL_Controller(string s, int n, string i, string p)
        {
            try
            {
                Source = s;
                Port = n;
                ID = i;
                PW = p;

                connector = new MySqlConnection(SetConnector(Source, Port, ID, PW));
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : MySQL_Controller ]");

                if (string.IsNullOrEmpty(s) == true)
                {
                    MessageBuilder.AppendLine("# source  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# source  : " + s);
                }

                MessageBuilder.AppendLine("# port  : " + n);

                if (string.IsNullOrEmpty(i) == true)
                {
                    MessageBuilder.AppendLine("# id      : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# id      : " + i);
                }

                if (string.IsNullOrEmpty(p) == true)
                {
                    MessageBuilder.AppendLine("# pass    : NULL/ EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# pass    : " + p);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ MySQL_Controller @                                                                                    ///
        ///     매개변수로 전달된 정보를 이용하여 MySQL DB 서버와의 작업 관리 객체를 생성한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="s"> string : DB 서버 주소 </param>                                                         ///
        /// <param name="c"> string : DB 목록 </param>                                                              ///
        /// <param name="i"> string : DB 접속 ID </param>                                                           ///
        /// <param name="p"> string : DB 접속 암호 </param>                                                         ///
        ///=========================================================================================================///
        public MySQL_Controller(string s, string c, string i, string p)
        {
            try
            {
                Source = s;
                Catalog = c;
                ID = i;
                PW = p;

                connector = new MySqlConnection(SetConnector(Source, Catalog, ID, PW));
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : MySQL_Controller ]");

                if (string.IsNullOrEmpty(s) == true)
                {
                    MessageBuilder.AppendLine("# source  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# source  : " + s);
                }

                if (string.IsNullOrEmpty(c) == true)
                {
                    MessageBuilder.AppendLine("# catalog : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# catalog : " + c);
                }

                if (string.IsNullOrEmpty(i) == true)
                {
                    MessageBuilder.AppendLine("# id      : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# id      : " + i);
                }

                if (string.IsNullOrEmpty(p) == true)
                {
                    MessageBuilder.AppendLine("# pass    : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# pass    : " + p);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ Connection @                                                                                          ///
        ///     DB 서버로 접속을 시도하며 그 결과를 반환한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <returns> bool : DB 서버 접속 여부 </returns>                                                           ///
        ///=========================================================================================================///
        public bool Connection()
        {
            try
            {
                if (connector.State == ConnectionState.Closed)
                {
                    connector.Open();
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Connection ]");
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ DisConnection @                                                                                       ///
        ///     DB 서버와의 연결 해제를 시도하며 그 결과를 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <returns> bool : 접속 해제 여부 </returns>                                                              ///
        ///=========================================================================================================///
        public bool DisConnection()
        {
            try
            {
                if (connector.State == ConnectionState.Open)
                {
                    connector.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : DisConnection ]");
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ Insert @                                                                                              ///
        ///     DB 서버에 신규 데이터의 삽입을 시도하여 그 결과를 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="data"> string[] : DB 삽입 데이터 </param>                                                  ///
        /// <returns> bool : 데이터 삽입 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Insert(string table, string[] data)
        {
            string insert_sql = Insert_Query(table, data);

            try
            {
                int res;

                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(insert_sql, connector);
                res = command.ExecuteNonQuery();

                DisConnection();

                if (res > 0)
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
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Insert ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (data == null)
                {
                    MessageBuilder.AppendLine("# data    : NULL");
                }
                else
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        MessageBuilder.AppendLine("# data(" + i + ") : " + data[i]);
                    }
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + insert_sql);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ Select @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 데이터를 DB 서버에서 조회하여 그 결과를 반환한다.                 ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="fields"> string : 데이터 조회 필드 </param>                                                ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> List<string[]> : DB 서버 조회 결과 </returns>                                                 ///
        ///=========================================================================================================///
        public List<string[]> Select(string table, string fields, string condition)
        {
            string select_sql = Select_Query(table, fields, condition);
            List<string[]> results = new List<string[]>();

            try
            {
                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(select_sql, connector);
                MySqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    string[] data = new string[read.FieldCount];

                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        data[i] = read[i].ToString();
                    }

                    results.Add(data);
                }

                read.Close();
                DisConnection();
            }
            catch (Exception e)
            {
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Select ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (string.IsNullOrEmpty(fields) == true)
                {
                    MessageBuilder.AppendLine("# fields  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# fields  : " + fields);
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + select_sql);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return results;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ Update @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 항목의 값을 업데이트하고 그 결과를 반환한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="field"> string : 데이터 조회 필드 </param>                                                 ///
        /// <param name="value"> string : 변경할 값 </param>                                                        ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> bool : DB 업데이트 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Update(string table, string field, string value, string condition)
        {
            string update_sql = Update_Query(table, field, value, condition);

            try
            {
                int res = 0;

                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(update_sql, connector);
                res = command.ExecuteNonQuery();

                DisConnection();

                if (res > 0)
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
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Update ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (string.IsNullOrEmpty(field) == true)
                {
                    MessageBuilder.AppendLine("# field   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# field   : " + field);
                }

                if (string.IsNullOrEmpty(value) == true)
                {
                    MessageBuilder.AppendLine("# value   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# value   : " + value);
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + update_sql);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ Update @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 항목의 값을 업데이트하고 그 결과를 반환한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="field"> string[] : 데이터 조회 필드 </param>                                               ///
        /// <param name="value"> string[] : 변경할 값 </param>                                                      ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> bool : DB 업데이트 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Update(string table, string[] field, string[] value, string condition)
        {
            string update_sql = Update_Query(table, field, value, condition);

            try
            {
                int res = 0;

                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(update_sql, connector);
                res = command.ExecuteNonQuery();

                DisConnection();

                if (res > 0)
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
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Update ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (field.Length < 1)
                {
                    MessageBuilder.AppendLine("# field   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# field   : ");

                    for (int i = 0; i < field.Length; i++)
                    {
                        MessageBuilder.AppendLine(field[i] + ", ");
                    }
                }

                if (value.Length < 1)
                {
                    MessageBuilder.AppendLine("# value   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# value   : ");

                    for (int i = 0; i < value.Length; i++)
                    {
                        MessageBuilder.AppendLine(value[i] + ", ");
                    }
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + update_sql);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-09 ] ///
        /// @ Delete @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 항목을 DB에서 삭제하고 그 결과를 반환한다.                        ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="condition"> string : 데이터 삭제 조건 </param>                                             ///
        /// <returns> bool : 데이터 삭제 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Delete(string table, string condition)
        {
            string delete_sql = Delete_Query(table, condition);

            try
            {
                int res = 0;

                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(delete_sql, connector);
                res = command.ExecuteNonQuery();

                DisConnection();

                if (res > 0)
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
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Delete ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPLTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + delete_sql);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ FileInsert @                                                                                          ///
        ///     DB에 파일을 삽입한다. 소프트웨어의 버전 관리 및 자동 업데이트에 활용할 수 있다.                     ///
        /// </summary>                                                                                              ///
        /// <param name="filepath"> string : 파일 경로 </param>                                                     ///
        /// <param name="version"> string : 파일 버전 </param>                                                      ///
        /// <param name="table"> string : 파일 삽입 테이블 </param>                                                 ///
        /// <returns> bool : 파일 삽입 여부 </returns>                                                              ///
        ///=========================================================================================================///
        public bool FileInsert(string filepath, string version, string table)
        {
            int res = 0;
            string insert_sql = string.Empty;

            try
            {
                FileInfo fi = new FileInfo(filepath);

                MySqlParameter prm = new MySqlParameter();

                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                string sql_query = "SELECT COUNT(*) FROM " + table;
                MySqlCommand command = new MySqlCommand(sql_query, connector);
                MySqlDataReader reader = command.ExecuteReader();

                string index = string.Empty;
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        index += reader[i];
                    }
                }

                reader.Close();

                command = new MySqlCommand(sql_query + " WHERE name='" + fi.Name + "' AND version='" + version + "'", connector);

                reader = command.ExecuteReader();

                if (reader.Read() == true)
                {
                    res = Convert.ToInt32(reader[0]);
                }

                reader.Close();

                if (res > 0)
                {
                    Message = "동일 Version 존재";

                    FileManager.SetFileExtension(".dat");
                    FileManager.LogWriter(Message, LogPath, "DB Log", true, true, true, true, true);
                }
                else
                {
                    insert_sql = "INSERT INTO ace_dll VALUES(@index, @name, @file, @size, @date, @version)";

                    command = new MySqlCommand(insert_sql, connector);

                    prm = command.Parameters.AddWithValue("@index", Convert.ToInt32(index));
                    prm = command.Parameters.AddWithValue("@name", fi.Name);

                    FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);

                    prm = command.Parameters.AddWithValue("@file", buffer);
                    prm = command.Parameters.AddWithValue("@size", fi.Length);

                    DateTime made = fi.LastWriteTime;
                    string datetime = made.Year.ToString("0000") + "-" + made.Month.ToString("00")
                        + "-" + made.Day.ToString("00") + " " + made.Hour.ToString("00")
                        + ":" + made.Minute.ToString("00") + ":" + made.Second.ToString("00");

                    prm = command.Parameters.AddWithValue("@date", datetime);
                    prm = command.Parameters.AddWithValue("@version", version);

                    res = command.ExecuteNonQuery();

                    if (res > 0)
                    {
                        Message = "DB Insert Success!";

                        FileManager.SetFileExtension(".dat");
                        FileManager.LogWriter(Message, LogPath, "DB Log", true, true, true, true, true);
                    }
                    else
                    {
                        Message = "DB Insert Failed!!";
                        FileManager.SetFileExtension(".dat");
                        FileManager.LogWriter(Message, LogPath, "DB Log", true, true, true, true, true);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileInsert ]");

                if (string.IsNullOrEmpty(filepath) == true)
                {
                    MessageBuilder.AppendLine("# filepath : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# filepath : " + filepath);
                }

                if (string.IsNullOrEmpty(version) == true)
                {
                    MessageBuilder.AppendLine("# version : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# version : " + version);
                }

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ GetFile @                                                                                             ///
        ///     매개변수로 전달된 조건에 해당하는 파일 데이터를 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="filepath"> string : 파일 경로 </param>                                                     ///
        /// <param name="condition"> string : 파일 검색 조건 </param>                                               ///
        /// <returns> byte[] : 파일 데이터 </returns>                                                               ///
        ///=========================================================================================================///
        public byte[] GetFile(string table, string condition)
        {
            byte[] file_buffer = new byte[0];

            if (connector.State == ConnectionState.Closed)
            {
                Connection();
            }

            string select_sql = "SELECT * FROM " + table + " WHERE " + condition;

            try
            {
                MySqlCommand command = new MySqlCommand(select_sql, connector);
                MySqlDataReader read = command.ExecuteReader();

                if (read.Read() == true)
                {
                    file_buffer = (byte[])read[2];
                }

                read.Close();
                DisConnection();
            }
            catch (Exception e)
            {
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : GetFile ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table     : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table     : " + table);
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return file_buffer;
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2016-11-23 ] ///
        /// @ Insert @                                                                                              ///
        ///     DB 서버에 신규 데이터의 삽입을 시도하여 그 결과를 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="query"> string : 쿼리문 데이터 </param>                                                    ///
        /// <returns> bool : 데이터 삽입 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Insert(string query)
        {
            try
            {
                int res;

                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(query, connector);
                res = command.ExecuteNonQuery();

                DisConnection();

                if (res > 0)
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
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Insert ]");
                MessageBuilder.AppendLine("# Query : " + query);
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
        /// <summary>                                                                     [ Ver 1.01 / 2016-11-23 ] ///
        /// @ Select @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 데이터를 DB 서버에서 조회하여 그 결과를 반환한다.                 ///
        /// </summary>                                                                                              ///
        /// <param name="query"> string : 쿼리문 데이터 </param>                                                    ///
        /// <returns> List<string[]> : DB 서버 조회 결 과</returns>                                                 ///
        ///=========================================================================================================///
        public List<string[]> Select(string query)
        {
            List<string[]> results = new List<string[]>();

            try
            {
                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(query, connector);
                MySqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    string[] data = new string[read.FieldCount];

                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        data[i] = read[i].ToString();
                    }

                    results.Add(data);
                }

                read.Close();
                DisConnection();
            }
            catch (Exception e)
            {
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Select ]");

                MessageBuilder.AppendLine("# Query : " + query);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return results;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2016-11-23 ] ///
        /// @ Update @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 항목의 값을 업데이트하고 그 결과를 반환한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="query"> string : 쿼리문 데이터 </param>                                                    ///
        /// <returns> bool : DB 업데이트 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Update(string query)
        {
            try
            {
                int res = 0;

                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(query, connector);
                res = command.ExecuteNonQuery();

                DisConnection();

                if (res > 0)
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
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Update ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + query);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }
        }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2017-04-10 ] ///
        /// @ MySQL_Controller @                                                                                    ///
        ///     매개변수로 전달된 정보를 이용하여 MySQL DB 서버와의 작업 관리 객체를 생성한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="s"> string : DB 서버 주소 </param>                                                         ///
        /// <param name="n"> int : DB 접속 Port 번호 </param>                                                       ///
        /// <param name="c"> string : DB 목록 </param>                                                              ///
        /// <param name="i"> string : DB 접속 ID </param>                                                           ///
        /// <param name="p"> string : DB 접속 암호 </param>                                                         ///
        ///=========================================================================================================///
        public MySQL_Controller(string s, int n, string c, string i, string p)
        {
            try
            {
                Source = s;
                Port = n;
                Catalog = c;
                ID = i;
                PW = p;

                connector = new MySqlConnection(SetConnector(Source, Port, Catalog, ID, PW));
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : MySQL_Controller ]");

                if (string.IsNullOrEmpty(s) == true)
                {
                    MessageBuilder.AppendLine("# source  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# source  : " + s);
                }

                MessageBuilder.AppendLine("# port  : " + n);

                if (string.IsNullOrEmpty(c) == true)
                {
                    MessageBuilder.AppendLine("# catalog : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# catalog : " + c);
                }

                if (string.IsNullOrEmpty(i) == true)
                {
                    MessageBuilder.AppendLine("# id      : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# id      : " + i);
                }

                if (string.IsNullOrEmpty(p) == true)
                {
                    MessageBuilder.AppendLine("# pass    : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# pass    : " + p);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }
        #endregion

        #region [ # Ver 1.03 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2019-03-20 ] ///
        /// @ Excute_Query @                                                                                        ///
        ///     매개변수로 전달된 SQL 쿼리 구문을 실행하여 결과를 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="query"> string : 쿼리문 </param>                                                           ///
        /// <returns> List<string[]> : 쿼리 결과 </returns>                                                         ///
        ///=========================================================================================================///
        public List<string[]> Excute_Query(string query)
        {
            List<string[]> results = new List<string[]>();

            try
            {
                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(query, connector);
                //res = command.ExecuteNonQuery();
                MySqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    string[] data = new string[read.FieldCount];

                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        data[i] = read[i].ToString();
                    }

                    results.Add(data);
                }

                read.Close();
                DisConnection();
            }
            catch (Exception e)
            {
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Excute_Query ]");

                if (string.IsNullOrEmpty(query) == true)
                {
                    MessageBuilder.AppendLine("# query   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# query   : " + query);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return results;
        }
        #endregion

        #region [ # Ver 1.04 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2019-04-24 ] ///
        /// @ Insert @                                                                                              ///
        ///     DB 서버에 신규 데이터의 삽입을 시도하여 그 결과를 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="fields"> string[] : DB 테이블 필드 이름 </param>                                           ///
        /// <param name="data"> object[] : DB 삽입 데이터 </param>                                                  ///
        /// <returns> bool : 데이터 삽입 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Insert(string table, string[] fields, object[] data)
        {
            string insert_sql = Insert_Command(table, fields);

            try
            {
                int res;

                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(insert_sql, connector);

                for (int i = 0; i < fields.Length; i++)
                {
                    command.Parameters.AddWithValue("@" + fields[i], data[i]);
                }

                res = command.ExecuteNonQuery();

                DisConnection();

                if (res > 0)
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
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Insert ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (fields == null)
                {
                    MessageBuilder.AppendLine("# fields  : NULL");
                }
                else
                {
                    for (int i = 0; i < fields.Length; i++)
                    {
                        MessageBuilder.AppendLine("# fields(" + i + ") : " + fields[i]);
                    }
                }

                if (data == null)
                {
                    MessageBuilder.AppendLine("# data    : NULL");
                }
                else
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        MessageBuilder.AppendLine("# data(" + i + ") : " + data[i]);
                    }
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + insert_sql);
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
        /// <summary>                                                                     [ Ver 1.04 / 2019-04-24 ] ///
        /// @ Select @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 데이터를 DB 서버에서 조회하여 그 결과를 반환한다.                 ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="fields"> string : 데이터 조회 필드 </param>                                                ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> List<DB_Result[]> : DB 서버 조회 결과 </returns>                                              ///
        ///=========================================================================================================///
        public List<DB_Result[]> SelectwithTypes(string table, string fields, string condition)
        {
            string select_sql = Select_Query(table, fields, condition);
            List<DB_Result[]> results = new List<DB_Result[]>();

            try
            {
                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(select_sql, connector);
                MySqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    DB_Result[] data = new DB_Result[read.FieldCount];

                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        data[i].data = read[i];
                        data[i].type = read[i].GetType();
                    }

                    results.Add(data);
                }

                read.Close();
                DisConnection();
            }
            catch (Exception e)
            {
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Select ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (fields == null)
                {
                    MessageBuilder.AppendLine("# fields  : NULL");
                }
                else
                {
                    for (int i = 0; i < fields.Length; i++)
                    {
                        MessageBuilder.AppendLine("# fields(" + i + ") : " + fields[i]);
                    }
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + select_sql);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return results;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2019-04-24 ] ///
        /// @ Update @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 항목의 값을 업데이트하고 그 결과를 반환한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="field"> string[] : 데이터 조회 필드 </param>                                               ///
        /// <param name="value"> string[] : 변경할 값 </param>                                                      ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> bool : DB 업데이트 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Update(string table, string[] field, object[] value, string condition)
        {
            string update_sql = Update_Command(table, field, condition);

            try
            {
                int res = 0;

                if (connector.State == ConnectionState.Closed)
                {
                    Connection();
                }

                MySqlCommand command = new MySqlCommand(update_sql, connector);

                for (int i = 0; i < field.Length; i++)
                {
                    command.Parameters.AddWithValue("@" + field[i], value[i]);
                }

                res = command.ExecuteNonQuery();

                DisConnection();

                if (res > 0)
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
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Update ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (field.Length < 1)
                {
                    MessageBuilder.AppendLine("# field   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# field   : ");

                    for (int i = 0; i < field.Length; i++)
                    {
                        MessageBuilder.AppendLine(field[i] + ", ");
                    }
                }

                if (value.Length < 1)
                {
                    MessageBuilder.AppendLine("# value   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# value   : ");

                    for (int i = 0; i < value.Length; i++)
                    {
                        MessageBuilder.AppendLine(value[i] + ", ");
                    }
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + update_sql);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }
        }
        #endregion
    }
    ///=========================================================================== End of Class : MySQL_Controller =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-07-10 ] ///
    /// ▷ MSSQL_Controller : DB_Manager ◁                                                                         ///
    ///     MySQL에 대응하여 DB 작업을 수행하는 클래스                                                              ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-07-10 ]                                                                                   ///
    ///     ▶ 데이터 삽입, 조회, 수정, 삭제 기능                                                                   ///
    ///     ▶ 파일 데이터 삽입, 조회 기능                                                                          ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class MSSQL_Controller : DB_Manager
    {
        #region [ # Defines & Variables ]
        private SqlConnection connector;
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ MSSQL_Controller @                                                                                    ///
        ///      매개변수로 전달된 정보를 이용하여 MSSQL DB 서버와의 작업 관리 객체를 생성한다.                     ///
        /// </summary>                                                                                              ///
        /// <param name="s"> string : DB 서버 주소 </param>                                                         ///
        /// <param name="c"> string : DB 목록 </param>                                                              ///
        /// <param name="i"> string : DB 접속 ID </param>                                                           ///
        /// <param name="p"> string : DB 접속 암호 </param>                                                         ///
        ///=========================================================================================================///
        public MSSQL_Controller(string s, string c, string i, string p)
        {
            Source = s;
            Catalog = c;
            ID = i;
            PW = p;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ Connection @                                                                                          ///
        ///     DB 서버로 접속을 시도하며 그 결과를 반환한다.                                                       ///
        /// </summary>                                                                                              ///
        /// <param name="Source"> string : DB 서버 주소 </param>                                                    ///
        /// <param name="Catalog"> string : DB 목록 </param>                                                        ///
        /// <param name="id"> string : DB 접속 ID </param>                                                          ///
        /// <param name="pw"> string : DB 접속 암호 </param>                                                        ///
        /// <returns> bool : DB 서버 접속 여부 </returns>                                                           ///
        ///=========================================================================================================///
        public bool Connection(string Source, string Catalog, string id, string pw)
        {
            try
            {
                connector = new SqlConnection(SetConnector(Source, Catalog, id, pw));
                connector.Open();
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Connection ]");

                if (string.IsNullOrEmpty(Source) == true)
                {
                    MessageBuilder.AppendLine("# source  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# source  : " + Source);
                }

                if (string.IsNullOrEmpty(Catalog) == true)
                {
                    MessageBuilder.AppendLine("# catalog : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# catalog : " + Catalog);
                }

                if (string.IsNullOrEmpty(id) == true)
                {
                    MessageBuilder.AppendLine("# id      : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# id      : " + id);
                }

                if (string.IsNullOrEmpty(pw) == true)
                {
                    MessageBuilder.AppendLine("# pass    : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# pass    : " + pw);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }

            return true;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ DisConnection @                                                                                       ///
        ///     DB 서버와의 연결 해제를 시도하며 그 결과를 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <returns> bool : 접속 해제 여부 </returns>                                                              ///
        ///=========================================================================================================///
        public bool DisConnection()
        {
            try
            {
                connector.Close();
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : DisConnection ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }

            return true;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ Insert @                                                                                              ///
        ///     DB 서버에 신규 데이터의 삽입을 시도하여 그 결과를 반환한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="data"> string[] : DB 삽입 데이터 </param>                                                  ///
        /// <returns> bool : 데이터 삽입 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Insert(string table, string[] data)
        {
            string insert_sql = Insert_Query(table, data);

            try
            {
                int res;

                if (connector.State == ConnectionState.Closed)
                {
                    Connection(Source, Catalog, ID, PW);
                }

                SqlCommand command = new SqlCommand(insert_sql, connector);
                res = command.ExecuteNonQuery();

                if (res > 0)
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
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Insert ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (data == null)
                {
                    MessageBuilder.AppendLine("# data    : NULL");
                }
                else
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        MessageBuilder.AppendLine("# data(" + i + ") : " + data[i]);
                    }
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + insert_sql);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ Select @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 데이터를 DB 서버에서 조회하여 그 결과를 반환한다.                 ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="fields"> string : 데이터 조회 필드 </param>                                                ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> List<string[]> : DB 서버 조회 결과 </returns>                                                 ///
        ///=========================================================================================================///
        public List<string[]> Select(string table, string fields, string condition)
        {
            string select_sql = Select_Query(table, fields, condition);
            List<string[]> results = new List<string[]>();

            try
            {
                if (connector.State == ConnectionState.Closed)
                {
                    Connection(Source, Catalog, ID, PW);
                }

                SqlCommand command = new SqlCommand(select_sql, connector);
                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    string[] data = new string[read.FieldCount];

                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        data[i] = read[i].ToString();
                    }

                    results.Add(data);
                }

                read.Close();
                DisConnection();
            }
            catch (Exception e)
            {
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Select ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (string.IsNullOrEmpty(fields) == true)
                {
                    MessageBuilder.AppendLine("# fields  : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# fields  : " + fields);
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + select_sql);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return results;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ Update @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 항목의 값을 업데이트하고 그 결과를 반환한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="field"> string : 데이터 조회 필드 </param>                                                 ///
        /// <param name="value"> string : 변경할 값 </param>                                                        ///
        /// <param name="condition"> string : 데이터 조회 조건 </param>                                             ///
        /// <returns> bool : DB 업데이트 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Update(string table, string field, string value, string condition)
        {
            string update_sql = Update_Query(table, field, value, condition);

            try
            {
                int res = 0;

                if (connector.State == ConnectionState.Closed)
                {
                    Connection(Source, Catalog, ID, PW);
                }

                SqlCommand command = new SqlCommand(update_sql, connector);
                res = command.ExecuteNonQuery();

                DisConnection();

                if (res > 0)
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
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Update ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (string.IsNullOrEmpty(field) == true)
                {
                    MessageBuilder.AppendLine("# field   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# field   : " + field);
                }

                if (string.IsNullOrEmpty(value) == true)
                {
                    MessageBuilder.AppendLine("# value   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# value   : " + value);
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + update_sql);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ Delete @                                                                                              ///
        ///     매개변수로 전달한 조건을 만족하는 항목을 DB에서 삭제하고 그 결과를 반환한다.                        ///
        /// </summary>                                                                                              ///
        /// <param name="table"> string : DB 테이블 이름 </param>                                                   ///
        /// <param name="condition"> string : 데이터 삭제 조건 </param>                                             ///
        /// <returns> bool : 데이터 삭제 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool Delete(string table, string condition)
        {
            string delete_sql = Delete_Query(table, condition);

            try
            {
                int res = 0;

                if (connector.State == ConnectionState.Closed)
                {
                    Connection(Source, Catalog, ID, PW);
                }

                SqlCommand command = new SqlCommand(delete_sql, connector);
                res = command.ExecuteNonQuery();

                DisConnection();

                if (res > 0)
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
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Delete ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPLTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("# Query : " + delete_sql);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ FileInsert @                                                                                          ///
        ///     DB에 파일을 삽입한다. 소프트웨어의 버전 관리 및 자동 업데이트에 활용할 수 있다.                     ///
        /// </summary>                                                                                              ///
        /// <param name="filepath"> string : 파일 경로 </param>                                                     ///
        /// <param name="version"> string : 파일 버전 </param>                                                      ///
        /// <param name="table"> string : 파일 삽입 테이블 </param>                                                 ///
        /// <returns> bool : 파일 삽입 여부 </returns>                                                              ///
        ///=========================================================================================================///
        public bool FileInsert(string filepath, string version, string table)
        {
            int res = 0;
            string insert_sql = string.Empty;

            try
            {
                FileInfo fi = new FileInfo(filepath);

                SqlParameter prm = new SqlParameter();

                if (connector.State == ConnectionState.Closed)
                {
                    Connection(Source, Catalog, ID, PW);
                }

                string sql_query = "SELECT COUNT(*) FROM " + table;
                SqlCommand command = new SqlCommand(sql_query, connector);
                SqlDataReader reader = command.ExecuteReader();

                string index = string.Empty;
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        index += reader[i];
                    }
                }

                reader.Close();

                command = new SqlCommand(sql_query + " WHERE name='" + fi.Name + "' AND version='" + version + "'", connector);

                reader = command.ExecuteReader();

                if (reader.Read() == true)
                {
                    res = Convert.ToInt32(reader[0]);
                }

                reader.Close();

                if (res > 0)
                {
                    Message = "동일 Version 존재";

                    FileManager.SetFileExtension(".dat");
                    FileManager.LogWriter(Message, LogPath, "DB Log", true, true, true, true, true);
                }
                else
                {
                    insert_sql = "INSERT INTO ace_dll VALUES(@index, @name, @file, @size, @date, @version)";

                    command = new SqlCommand(insert_sql, connector);

                    prm = command.Parameters.AddWithValue("@index", Convert.ToInt32(index));
                    prm = command.Parameters.AddWithValue("@name", fi.Name);

                    FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);

                    prm = command.Parameters.AddWithValue("@file", buffer);
                    prm = command.Parameters.AddWithValue("@size", fi.Length);

                    DateTime made = fi.LastWriteTime;
                    string datetime = made.Year.ToString("0000") + "-" + made.Month.ToString("00")
                        + "-" + made.Day.ToString("00") + " " + made.Hour.ToString("00")
                        + ":" + made.Minute.ToString("00") + ":" + made.Second.ToString("00");

                    prm = command.Parameters.AddWithValue("@date", datetime);
                    prm = command.Parameters.AddWithValue("@version", version);

                    res = command.ExecuteNonQuery();

                    if (res > 0)
                    {
                        Message = "DB Insert Success!";

                        FileManager.SetFileExtension(".dat");
                        FileManager.LogWriter(Message, LogPath, "DB Log", true, true, true, true, true);
                    }
                    else
                    {
                        Message = "DB Insert Failed!!";

                        FileManager.SetFileExtension(".dat");
                        FileManager.LogWriter(Message, LogPath, "DB Log", true, true, true, true, true);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : FileInsert ]");

                if (string.IsNullOrEmpty(filepath) == true)
                {
                    MessageBuilder.AppendLine("# filepath : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# filepath : " + filepath);
                }

                if (string.IsNullOrEmpty(version) == true)
                {
                    MessageBuilder.AppendLine("# version : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# version : " + version);
                }

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
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
        /// <summary>                                                                     [ Ver 1.00 / 2014-07-10 ] ///
        /// @ GetFile @                                                                                             ///
        ///     매개변수로 전달된 조건에 해당하는 파일 데이터를 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="filepath"> string : 파일 경로 </param>                                                     ///
        /// <param name="condition"> string : 파일 검색 조건 </param>                                               ///
        /// <returns> byte[] : 파일 데이터 </returns>                                                               ///
        ///=========================================================================================================///
        public byte[] GetFile(string table, string condition, string filepath)
        {
            byte[] file_buffer = new byte[0];

            FileInfo fi = new FileInfo(filepath);

            if (connector.State == ConnectionState.Closed)
            {
                Connection(Source, Catalog, ID, PW);
            }

            string select_sql = "SELECT * FROM " + table + " WHERE " + condition;

            try
            {
                SqlCommand command = new SqlCommand(select_sql, connector);
                SqlDataReader read = command.ExecuteReader();

                if (read.Read() == true)
                {
                    file_buffer = (byte[])read[2];
                }

                read.Close();
                DisConnection();
            }
            catch (Exception e)
            {
                if (connector.State == ConnectionState.Open)
                {
                    DisConnection();
                }

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : GetFile ]");

                if (string.IsNullOrEmpty(table) == true)
                {
                    MessageBuilder.AppendLine("# table   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# table   : " + table);
                }

                if (string.IsNullOrEmpty(condition) == true)
                {
                    MessageBuilder.AppendLine("# condition : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# condition : " + condition);
                }

                if (string.IsNullOrEmpty(filepath) == true)
                {
                    MessageBuilder.AppendLine("# filepath : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# filepath : " + filepath);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.SetFileExtension(".dat");
                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return file_buffer;
        }
        #endregion
    }
    ///=========================================================================== End of Class : MSSQL_Controller =///
}
