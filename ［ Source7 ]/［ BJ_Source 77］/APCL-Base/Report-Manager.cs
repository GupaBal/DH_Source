using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.04 / 2019-03-07 ] ///
    /// ▷ Report_Manager : CommonVariables ◁                                                                      ///
    ///     보고서 생성 기능 지원 클래스로 지정된 양식의 보고서 파일을 이용하여                                     ///
    ///     데이터 삽입 및 보고서 생성을 수행한다.                                                                  ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-01 ]                                                                                   ///
    ///     ▶ Excel 양식 지원 및 PDF 변환 가능                                                                     ///
    /// [ Ver 1.01 / 2017-11-30 ]                                                                                   ///
    ///     ▶ Worksheet 변경 지원                                                                                  ///
    /// [ Ver 1.02 / 2019-01-16 ]                                                                                   ///
    ///     ▶ Worksheet의 데이터 조회 기능 수정                                                                    ///
    /// [ Ver 1.03 / 2019-02-25 ]                                                                                   ///
    ///     ▶ 행, 열 추가/삭제/숨김 기능 추가                                                                      ///
    /// [ Ver 1.04 / 2019-03-07 ]                                                                                   ///
    ///     ▶ 키워드 검색 기능 추가                                                                                ///
    ///                                                                                                             ///
    ///     ※ Shape 관련 기능 구현 중                                                                              ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class Report_Manager : CommonVariables
    {
        #region [ # Defines & Variables ]
        private string Message = string.Empty;
        private StringBuilder MessageBuilder;

        private List<int> BeforeExcelProcessID = new List<int>();

        public Excel.Application exlApp = null;
        public Excel.Workbook exlWorkBook = null;
        public Excel.Worksheet exlWorkSheet = null;
        public Excel.Sheets exlSheets = null;
        public Excel.Range exlRange = null;

        private string strExcelFile;
        private bool bConnectExcel = false;

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        uint iProcessId = 0;
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ Init_Excel_Report @                                                                                   ///
        ///     매개변수로 주어진 엑셀 파일에서 지정된 이름을 가진 시트를 활성화하여 초기화한다.                    ///
        /// </summary>                                                                                              ///
        /// <param name="filepath"> string : 엑셀 파일 경로 </param>                                                ///
        /// <param name="sheet"> string : 사용할 엑셀 시트 이름 </param>                                            ///
        /// <returns> bool : 초기화 여부 </returns>                                                                 ///
        ///=========================================================================================================///
        public bool Init_Excel_Report(string filepath, string sheet)
        {
            BeforeExcelProcessID.Clear();
            Process[] BeforeExcelProcess = Process.GetProcessesByName("EXCEL");

            for (int i = 0; i < BeforeExcelProcess.Length; i++)
            {
                BeforeExcelProcessID.Add(BeforeExcelProcess[i].Id);
            }

            strExcelFile = filepath;
            exlApp = new Excel.Application();

            GetWindowThreadProcessId((IntPtr)exlApp.Hwnd, out iProcessId);

            try
            {
                exlWorkBook = (Excel.Workbook)(exlApp.Workbooks.Open(strExcelFile, Type.Missing,
                               Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                               Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                               Type.Missing, Type.Missing, Type.Missing));
                bConnectExcel = true;

            }
            catch (Exception e)
            {
                bConnectExcel = false;

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Init_Excel_Report ]");

                if (string.IsNullOrEmpty(filepath) == true)
                {
                    MessageBuilder.AppendLine("# filepath : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# filepath : " + filepath);
                }

                if (string.IsNullOrEmpty(sheet) == true)
                {
                    MessageBuilder.AppendLine("# sheet    : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# sheet    : " + sheet);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            if (!bConnectExcel)
            {
                string msg = "해당 Excel파일을 열수 없습니다.!!";
                string cap = "Error";

                WinForm_Message messagebox = new WinForm_Message(msg, cap, true);
                messagebox.ShowDialog();
                exlApp.Quit();
                //Application.Exit();

                return false;
            }
            else
            {
                exlSheets = exlWorkBook.Sheets;
                exlWorkSheet = (Excel.Worksheet)exlSheets.get_Item(sheet);


                return true;
            }
        }


        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ Init_Excel_Report @                                                                                   ///
        ///     매개변수로 주어진 엑셀 파일에서 지정된 이름을 가진 시트의 복사복을 생성하여 초기화한다.             ///
        /// <param name="filepath"> string : 엑셀 파일 경로 </param>                                                ///
        /// <param name="sheet"> string : 사용할 엑셀 시트 이름 </param>                                            ///
        /// <param name="copy_sheet"> string : 복사본 엑셀 시트 이름 </param>                                       ///
        /// <returns> bool : 초기화 여부 </returns>                                                                 ///
        ///=========================================================================================================///
        public bool Init_Excel_Report(string filepath, string sheet, string copy_sheet)
        {
            BeforeExcelProcessID.Clear();
            Process[] BeforeExcelProcess = Process.GetProcessesByName("EXCEL");

            for (int i = 0; i < BeforeExcelProcess.Length; i++)
            {
                BeforeExcelProcessID.Add(BeforeExcelProcess[i].Id);
            }

            strExcelFile = filepath;
            exlApp = new Excel.Application();

            try
            {
                exlWorkBook = (Excel.Workbook)(exlApp.Workbooks.Open(strExcelFile, Type.Missing,
                               Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                               Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                               Type.Missing, Type.Missing, Type.Missing));
                bConnectExcel = true;

            }
            catch (Exception e)
            {
                bConnectExcel = false;

                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Init_Excel_Report ]");

                if (string.IsNullOrEmpty(filepath) == true)
                {
                    MessageBuilder.AppendLine("# filepath : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# filepath : " + filepath);
                }

                if (string.IsNullOrEmpty(sheet) == true)
                {
                    MessageBuilder.AppendLine("# sheet    : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# sheet    : " + sheet);
                }

                if (string.IsNullOrEmpty(copy_sheet) == true)
                {
                    MessageBuilder.Append(" copy_sheet : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.Append(" copy_sheet : " + copy_sheet);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            if (!bConnectExcel)
            {
                string msg = "해당 Excel파일을 열수 없습니다.!!";
                string cap = "Error";

                WinForm_Message messagebox = new WinForm_Message(msg, cap, true);
                messagebox.ShowDialog();
                exlApp.Quit();
                //Application.Exit();

                return false;
            }
            else
            {
                exlSheets = exlWorkBook.Sheets;
                exlWorkSheet = (Excel.Worksheet)exlSheets.get_Item(sheet);
                Copy_Worksheet(exlWorkSheet, copy_sheet);

                return true;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ Existing_Sheet @                                                                                      ///
        ///     매개변수와 동일한 이름의 엑셀 시트가 존재하는지 여부를 반환한다.                                    ///
        /// </summary>                                                                                              ///
        /// <param name="sheet_name"> string : 엑셀 시트 이름 </param>                                              ///
        /// <returns>bool : 엑셀 시트 존재 여부 </returns>                                                          ///
        ///=========================================================================================================///
        public bool Existing_Sheet(string sheet_name)
        {
            try
            {
                foreach (Excel.Worksheet shit in exlSheets)
                {
                    if (shit.Name == sheet_name)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Existing_Sheet ]");

                if (string.IsNullOrEmpty(sheet_name) == true)
                {
                    MessageBuilder.AppendLine("# sheet_name : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# sheet_name : " + sheet_name);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return false;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ Make_New_WorkSheet @                                                                                  ///
        ///     새로운 엑셀 시트를 생성하여 현재 활성화된 엑셀 파일에 삽입한다.                                     ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void Make_New_WorkSheet()
        {
            try
            {
                exlWorkSheet = (Excel.Worksheet)exlWorkBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Make_New_WorkSheet ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ Copy_Worksheet @                                                                                      ///
        ///     매개변수로 지정된 이름으로 엑셀시트의 복사본을 생성한다.                                            ///
        /// </summary>                                                                                              ///
        /// <param name="src"> Worksheet : 원본 엑셀 시트 </param>                                                  ///
        /// <param name="rename"> string : 복사본 엑셀 시트 이름 </param>                                           ///
        ///=========================================================================================================///
        public void Copy_Worksheet(Worksheet src, string rename)
        {
            bool exit = Existing_Sheet(rename);

            try
            {
                if (exit == false)
                {
                    int test = exlSheets.Count;
                    src.Copy(Type.Missing, (Excel.Worksheet)exlSheets.get_Item(exlSheets.Count));
                    exlSheets = exlWorkBook.Worksheets;
                    test = exlSheets.Count;
                    exlWorkSheet = (Excel.Worksheet)exlSheets.get_Item(exlSheets.Count);
                    exlWorkSheet.Name = rename;
                }
                else
                {
                    exlWorkSheet = (Excel.Worksheet)exlSheets.get_Item(rename);
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Copy_Worksheet ]");

                if (src == null)
                {
                    MessageBuilder.AppendLine("# src      : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# src      :  " + src.Name);
                }

                if (string.IsNullOrEmpty(rename) == true)
                {
                    MessageBuilder.AppendLine("# rename   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# rename   : " + rename);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                FileManager.LogWriter(Message + e.ToString() + e.ToString(), ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ Save_Excel @                                                                                          ///
        ///     엑셀 파일을 저장한다.                                                                               ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void Save_Excel()
        {
            try
            {
                string msg = "저장경로를 설정해주세요";
                string cap = "Warning";

                if (strExcelFile == null)
                {
                    WinForm_Message messagebox = new WinForm_Message(msg, cap, true);
                    messagebox.ShowDialog();
                }
                else
                {
                    exlApp.DisplayAlerts = false;
                    exlWorkBook.Save();
                    exlApp.DisplayAlerts = true;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Save_Excel ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ SaveAs_Excel @                                                                                        ///
        ///     엑셀 파일을 매개변수로 지정한 경로에 파일명을 변경하여 저장한다.                                    ///
        /// </summary>                                                                                              ///
        /// <param name="folder"> string : 엑셀 파일 저장 경로 </param>                                             ///
        /// <param name="filename"> string : 엑셀 파일명 </param>                                                   ///
        ///=========================================================================================================///
        public void SaveAs_Excel(string folder, string filename)
        {
            try
            {
                string msg = "저장경로를 설정해주세요";
                string cap = "Warning";

                if (string.IsNullOrEmpty(strExcelFile) == true)
                {
                    WinForm_Message messagebox = new WinForm_Message(msg, cap, true);
                    messagebox.ShowDialog();
                }
                else
                {
                    exlWorkBook.SaveAs(folder + "\\" + filename, Excel.XlFileFormat.xlWorkbookDefault,
                    null, null, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                    false, false, null, null, null);
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SaveAs_Excel ]");

                if (string.IsNullOrEmpty(folder) == true)
                {
                    MessageBuilder.AppendLine("# folder   : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# folder   : " + folder);
                }

                MessageBuilder.AppendLine();

                if (string.IsNullOrEmpty(filename) == true)
                {
                    MessageBuilder.AppendLine("# filename : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# filename : " + filename);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ SearchExcel @                                                                                         ///
        ///     매개변수로 지정한 셀의 범위를 가져와 변수에 설정한다.                                               ///
        /// </summary>                                                                                              ///
        /// <param name="strPCell"> string : 범위를 지정할 셀 </param>                                              ///
        ///=========================================================================================================///
        public void SearchExcel(string strPCell)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range(strPCell, Type.Missing);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SearchExcel ]");

                if (string.IsNullOrEmpty(strPCell) == true)
                {
                    MessageBuilder.AppendLine("# strPCell : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# strPCell : " + strPCell);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ InsertExcel @                                                                                         ///
        ///     매개변수로 지정한 위치의 셀에 데이터를 삽입한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="intPRow"> int : 엑셀 시트 열 위치 </param>                                                 ///
        /// <param name="intPColumn"> int : 엑셀 시트 행 위치 </param>                                              ///
        /// <param name="Value"> object : 엑셀 시트 삽입 데이터 </param>                                            ///
        ///=========================================================================================================///
        public void InsertExcel(int intPRow, int intPColumn, object Value)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range("A1", Type.Missing);
                exlRange.Cells.set_Item(intPRow, intPColumn, Value);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : InsertExcel ]");
                MessageBuilder.AppendLine("# intPRow  : " + intPRow.ToString());
                MessageBuilder.AppendLine("# intPColumn : " + intPColumn.ToString());

                if (Value == null)
                {
                    MessageBuilder.AppendLine("# value    : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# value    : " + Value.ToString());
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ InsertExcel @                                                                                         ///
        ///     매개변수로 지정한 위치의 셀부터 데이터의 수만큼 삽입한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="strPCell"> string : 엑셀 시트 데이터 삽입 시작 위치 </param>                               ///
        /// <param name="Value"> object : 엑셀 시트 삽입 데이터 </param>                                            ///
        ///=========================================================================================================///
        public void InsertExcel(string strPCell, object Value)
        {
            try
            {
                Excel.Range range = exlWorkSheet.get_Range(strPCell, Missing.Value);
                range.set_Value(Missing.Value, Value);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : InsertExcel ]");
                MessageBuilder.AppendLine("# strPCell : " + strPCell);

                if (Value == null)
                {
                    MessageBuilder.AppendLine("# Value    : NULL");
                }
                else
                {
                    MessageBuilder.AppendLine("# Value    : " + Value.ToString());
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ InsertExcel @                                                                                         ///
        ///     매개변수로 지정한 위치의 셀부터 데이터의 수만큼 삽입한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="strPCell"> string : 엑셀 시트 데이터 삽입 시작 위치 </param>                               ///
        /// <param name="Values"> object[] : 엑셀 시트 삽입 데이터 </param>                                         ///
        ///=========================================================================================================///
        public void InsertExcel(string strPCell, object[] Values)
        {
            try
            {
                Excel.Range range = exlWorkSheet.get_Range(strPCell, Missing.Value);
                range = range.get_Resize(1, Values.Length);
                range.set_Value(Missing.Value, Values);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : InsertExcel ]");
                MessageBuilder.AppendLine("# strPCell : " + strPCell);

                if (Values == null)
                {
                    MessageBuilder.AppendLine("# values   : NULL");
                }
                else
                {
                    int cnt = 0;

                    foreach (object o in Values)
                    {
                        if (o == null) cnt++;
                    }

                    MessageBuilder.AppendLine("# values   : " + cnt.ToString() + " / " + Values.Length.ToString() + " NULL");
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        /*
        ///=========================================================================================================///
        /// <summary>                                                                      
        /// @ GetShape @                                                                                            ///
        ///     
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        ///=========================================================================================================///
        static public object GetShape(int height)
        {
            Image Shape = null;

            for (int i = 0; i < exlWorkSheet.Shapes.Count; i++)
            {
                Excel.Shape oShape = exlWorkSheet.Shapes.Item(i + 1);

                if (oShape.Type == MsoShapeType.msoPicture)
                {
                    if (oShape.Height >= height)
                    {
                        Excel.Picture pic = exlWorkSheet.Pictures(oShape.Name) as Excel.Picture;
                        pic.CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap);
                    }
                }

                try
                {
                    if (Clipboard.ContainsImage() == true)
                    {
                        Shape = Clipboard.GetImage();
                        Clipboard.Clear();
                    }
                }
                catch (Exception e)
                {
                    sb = new StringBuilder();
                    sb.AppendLine(e.ToString());

                    Message = sb.ToString();

                    FileWriter.LogWriter(
                        ErrorTag[(int)ErrorID.E13] + Message + Environment.NewLine + e.ToString(),
                        ErrorLogPath, ErrorLogName, true, true, true, true, true);
                }
            }

            return Shape;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ImgPath"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        static public void SetShape(string ImgPath, int left, int top, int width, int height)
        {
            try
            {
                exlWorkSheet.Shapes.AddPicture(ImgPath,
                    MsoTriState.msoCTrue, MsoTriState.msoCTrue, left, top, width, height);
            }
            catch (Exception e)
            {
                sb = new StringBuilder();
                sb.AppendLine(" Path : " + ImgPath);

                Message = sb.ToString();

                FileWriter.LogWriter(
                    ErrorTag[(int)ErrorID.E15] + Message + Environment.NewLine + e.ToString(),
                    ErrorLogPath, ErrorLogName, true, true, true, true, true);
            }
        }*/

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ ExportToPDF @                                                                                         ///
        ///     매개변수로 지정한 경로에 엑셀 파일을 PDF 양식으로 저장한다.                                         ///
        /// </summary>                                                                                              ///
        /// <param name="path"> string : PDF 저장 경로 </param>                                                     ///
        ///=========================================================================================================///
        public void ExportToPDF(string path)
        {
            try
            {
                exlWorkBook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : ExportToPDF ]");

                if (string.IsNullOrEmpty(path) == true)
                {
                    MessageBuilder.AppendLine("# path     : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# Path     : " + path);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-01 ] ///
        /// @ CloseExcel @                                                                                          ///
        ///     작업 중인 엑셀 파일을 저장한 후 닫고 엑셀을 종료한다.                                               ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void CloseExcel()
        {
            try
            {
                Save_Excel();

                if (exlApp != null)
                {
                    exlApp.Quit();
                }

                if (exlRange != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(exlRange);
                }

                if (exlWorkSheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(exlWorkSheet);
                }

                if (exlSheets != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(exlSheets);
                }

                if (exlWorkBook != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(exlWorkBook);
                }
                
                if (exlApp != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(exlApp);
                }

                exlApp = null;
                exlWorkBook = null;
                exlSheets = null;
                exlWorkSheet = null;

                //Process pProcess = Process.GetProcessById((int)iProcessId);
                //pProcess.Kill();
                /*
                System.Threading.Thread.Sleep(5000);

                System.Diagnostics.Process[] excelProcess;
                excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");

                foreach (System.Diagnostics.Process process in excelProcess)
                {
                    if (BeforeExcelProcessID.Contains(process.Id) == false)
                    {
                        process.Kill();
                    }
                }
                */

                GC.Collect();
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : CloseExcel ]");

                if (e.Message.Contains("NullReference") == true)
                {
                    if (exlApp == null) MessageBuilder.AppendLine("# exlApp   : NULL");
                    else if (exlRange == null) MessageBuilder.AppendLine("# exlRange : NULL");
                    else if (exlSheets == null) MessageBuilder.AppendLine("# exlSheets : NULL");
                    else if (exlWorkBook == null) MessageBuilder.AppendLine("# exlWorkBook : NULL");
                    else if (exlWorkSheet == null) MessageBuilder.AppendLine("# exlWorkSheet : NULL");
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2017-11-30 ] ///
        /// @ Change_Worksheet @                                                                                    ///
        ///     워크 시트를 변경한다.                                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="sheet"> string : 워크시트 이름 </param>                                                    ///
        ///=========================================================================================================///
        public bool Change_Worksheet(string sheet)
        {
            try
            {
                if (Existing_Sheet(sheet) == true)
                {
                    exlWorkSheet = (Excel.Worksheet)exlSheets.get_Item(sheet);
                    exlWorkSheet.Select(Type.Missing);
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
                MessageBuilder.AppendLine("[ Function : Change_Worksheet ]");

                if (string.IsNullOrEmpty(sheet) == true)
                {
                    MessageBuilder.AppendLine("# src      : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# src      :  " + sheet);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                FileManager.LogWriter(Message + e.ToString() + e.ToString(), ErrorPath, ErrorLogName, true, true, true, true, true);

                return false;
            }
        }
        #endregion

        #region [ # Ver 1.02 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2019-01-16 ] ///
        /// @ GetData @                                                                                             ///
        ///     엑셀 시트에서 매개변수로 지정한 위치의 데이터를 반환한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="intPRow"> int : 엑셀 시트 열 위치 </param>                                                 ///
        /// <param name="intPColumn"> int : 엑셀 시트 행 위치 </param>                                              ///
        /// <returns> object : 지정된 위치의 데이터 </returns>                                                      ///
        ///=========================================================================================================///
        public object GetData(int intPRow, int intPColumn)
        {
            object data = null;

            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range("A1", Type.Missing);
                Range tmp = exlRange.Cells.get_Item(intPRow, intPColumn);

                if (tmp.Value2 != null)
                {
                    data = tmp.Value2.ToString();
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : GetData ]");
                MessageBuilder.AppendLine("# Row      : " + intPRow.ToString());
                MessageBuilder.AppendLine("# Col      : " + intPColumn.ToString());
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return data;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.02 / 2019-01-16 ] ///
        /// @ GetData @                                                                                             ///
        ///     엑셀 시트의 전체 데이터를 반환한다.                                                                 ///
        /// </summary>                                                                                              ///
        /// <returns> object[,] : 사용된 영역의 모든 데이터 </returns>                                              ///
        ///=========================================================================================================///
        public object[,] GetData()
        {
            object[,] data = null;

            try
            {
                exlRange = (Excel.Range)exlWorkSheet.UsedRange;
                data = exlRange.Value;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : GetData ]");
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return data;
        }
        #endregion

        #region [ # Ver 1.03 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2019-02-25 ] ///
        /// @ MergeCells @                                                                                          ///
        ///     지정된 범위의 셀을 병합한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="strarPCell"> string : 범위 시작 위치 </param>                                              ///
        /// <param name="endPCell"> string : 범위 종료 위치 </param>                                                ///
        ///=========================================================================================================///
        public void MergeCells(string strarPCell, string endPCell)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range(strarPCell, endPCell);
                exlRange.MergeCells = true;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : InsertNewRow ]");
                MessageBuilder.AppendLine("# strarPCell : " + strarPCell);
                MessageBuilder.AppendLine("# endPCell : " + endPCell);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2019-02-25 ] ///
        /// @ InsertNewCol @                                                                                        ///
        ///     지정된 셀을 기준으로 새로운 열을 삽입한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <param name="strPCell"> string : 범위 시작 위치 </param>                                                ///
        ///=========================================================================================================///
        public void InsertNewRow(string strPCell)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range(strPCell, Type.Missing);
                exlRange.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
            }
            catch(Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : InsertNewRow ]");
                MessageBuilder.AppendLine("# strPCell : " + strPCell);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2019-02-25 ] ///
        /// @ InsertNewCol @                                                                                        ///
        ///     지정된 셀을 기준으로 새로운 행을 삽입한다.                                                          ///
        /// </summary>                                                                                              ///
        /// <param name="strPCell"> string : 범위 시작 위치 </param>                                                ///
        ///=========================================================================================================///
        public void InsertNewCol(string strPCell)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range(strPCell, Type.Missing);
                exlRange.EntireColumn.Insert(Excel.XlInsertShiftDirection.xlShiftToRight);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : InsertNewCol ]");
                MessageBuilder.AppendLine("# strPCell : " + strPCell);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2019-02-25 ] ///
        /// @ DeleteCol @                                                                                           ///
        ///     지정된 셀의 데이터를 삭제한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="strPCell"> string : 범위 시작 위치 </param>                                                ///
        /// <param name="hide"> bool : 숨김 속성 </param>                                                           ///
        ///=========================================================================================================///
        public void Delete(string strPCell)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range(strPCell, Missing.Value);
                exlRange.EntireRow.Delete(XlDirection.xlUp);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : DeleteRow ]");
                MessageBuilder.AppendLine("# strPCell : " + strPCell);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2019-02-25 ] ///
        /// @ DeleteCol @                                                                                           ///
        ///     지정된 범위의 데이터를 삭제한다.                                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="strarPCell"> string : 범위 시작 위치 </param>                                              ///
        /// <param name="endPCell"> string : 범위 종료 위치 </param>                                                ///
        /// <param name="hide"> bool : 숨김 속성 </param>                                                           ///
        ///=========================================================================================================///
        public void Delete(string strarPCell, string endPCell)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range(strarPCell, endPCell);
                exlRange.EntireRow.Delete(XlDirection.xlUp);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : DeleteRow ]");
                MessageBuilder.AppendLine("# strarPCell : " + strarPCell);
                MessageBuilder.AppendLine("# endPCell : " + endPCell);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2019-02-25 ] ///
        /// @ HiddenRow @                                                                                           ///
        ///     지정된 범위의 열을 숨기거나 복구한다.                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="strPCell"> string : 범위 시작 위치 </param>                                                ///
        /// <param name="hide"> bool : 숨김 속성 </param>                                                           ///
        ///=========================================================================================================///
        public void HiddenRow(string strPCell, bool hide)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range(strPCell, Missing.Value);
                exlRange.EntireRow.Hidden = hide;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : HiddenRow ]");
                MessageBuilder.AppendLine("# strPCell : " + strPCell);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2019-02-25 ] ///
        /// @ HiddenRow @                                                                                           ///
        ///     지정된 범위의 열을 숨기거나 복구한다.                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="strarPCell"> string : 범위 시작 위치 </param>                                              ///
        /// <param name="endPCell"> string : 범위 종료 위치 </param>                                                ///
        /// <param name="hide"> bool : 숨김 속성 </param>                                                           ///
        ///=========================================================================================================///
        public void HiddenRow(string strarPCell, string endPCell, bool hide)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range(strarPCell, endPCell);
                exlRange.EntireRow.Hidden = hide;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : HiddenRow ]");
                MessageBuilder.AppendLine("# strarPCell : " + strarPCell);
                MessageBuilder.AppendLine("# endPCell : " + endPCell);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2019-02-25 ] ///
        /// @ HiddenCol @                                                                                           ///
        ///     지정된 범위의 행을 숨기거나 복구한다.                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="strPCell"> string : 범위 시작 위치 </param>                                                ///
        /// <param name="hide"> bool : 숨김 속성 </param>                                                           ///
        ///=========================================================================================================///
        public void HiddenCol(string strPCell, bool hide)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range(strPCell, Missing.Value);
                exlRange.EntireColumn.Hidden = hide;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : HiddenCol ]");
                MessageBuilder.AppendLine("# strPCell : " + strPCell);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2019-02-25 ] ///
        /// @ HiddenCol @                                                                                           ///
        ///     지정된 범위의 행을 숨기거나 복구한다.                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="strarPCell"> string : 범위 시작 위치 </param>                                              ///
        /// <param name="endPCell"> string : 범위 종료 위치 </param>                                                ///
        /// <param name="hide"> bool : 숨김 속성 </param>                                                           ///
        ///=========================================================================================================///
        public void HiddenCol(string strarPCell, string endPCell, bool hide)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range(strarPCell, endPCell);
                exlRange.EntireColumn.Hidden = hide;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : HiddenCol ]");
                MessageBuilder.AppendLine("# strarPCell : " + strarPCell);
                MessageBuilder.AppendLine("# endPCell : " + endPCell);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.03 / 2019-02-25 ] ///
        /// @ BorderStyle @                                                                                         ///
        ///     지정된 범위의 경계선 스타일을 설정한다.                                                             ///
        /// </summary>                                                                                              ///
        /// <param name="strarPCell"> string : 범위 시작 위치 </param>                                              ///
        /// <param name="endPCell"> string : 범위 종료 위치 </param>                                                ///
        /// <param name="style"> XlLineStyle : 선 스타일 </param>                                                   ///
        /// <param name="color"> Color : 선 색상 </param>                                                           ///
        ///=========================================================================================================///
        public void BorderStyle(string strarPCell, string endPCell, XlLineStyle style, Color color)
        {
            try
            {
                exlRange = (Excel.Range)exlWorkSheet.get_Range(strarPCell, endPCell);
                exlRange.Borders.LineStyle = style;
                exlRange.Borders.Color = color;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : HiddenCol ]");
                MessageBuilder.AppendLine("# strarPCell : " + strarPCell);
                MessageBuilder.AppendLine("# endPCell : " + endPCell);
                MessageBuilder.AppendLine("# XlLineStyle : " + style);
                MessageBuilder.AppendLine("# Color    : " + color);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }
        #endregion

        #region [ # Ver 1.04 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2019-03-07 ] ///
        /// @ Find @                                                                                                ///
        ///     매개변수로 전달된 키워드의 위치를 검색하여 반환한다.                                                ///
        /// </summary>                                                                                              ///
        /// <param name="text"> string : 키워드 </param>                                                            ///
        ///=========================================================================================================///
        public string Find(string text)
        {
            try
            {
                exlRange = (Range)exlWorkSheet.UsedRange;
                Range search = exlRange.Cells.Find(text, Missing.Value, XlFindLookIn.xlValues, XlLookAt.xlPart,
                    XlSearchOrder.xlByRows, XlSearchDirection.xlNext, false, Missing.Value, Missing.Value);

                return search.Address;
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Find ]");
                MessageBuilder.AppendLine("# text     : " + text);
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);

                return string.Empty;
            }
        }
        #endregion

        #region [ # Ver 1.05 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.04 / 2019-03-07 ] ///
        /// @ Remove_Sheet @                                                                                        ///
        ///     지정된 워크 시트를 제거한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="sheet_name"> string : 시트 네임 </param>                                                   ///
        /// <returns> bool : 워크 시트 제거 여부 </returns>                                                         ///
        ///=========================================================================================================///
        public bool Remove_Sheet(string sheet_name)
        {
            bool result = false;

            try
            {
                int idx = 1;

                foreach (Excel.Worksheet shit in exlSheets)
                {
                    if (shit.Name == sheet_name)
                    {
                        break;
                    }

                    idx++;
                }

                exlApp.DisplayAlerts = false;
                ((Excel.Worksheet)exlWorkBook.Sheets[idx]).Delete();
                exlApp.DisplayAlerts = true;

                result = !Existing_Sheet(sheet_name);
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : Remove_Sheet ]");

                if (string.IsNullOrEmpty(sheet_name) == true)
                {
                    MessageBuilder.AppendLine("# sheet_name : NULL / EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# sheet_name : " + sheet_name);
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }

            return result;
        }
        #endregion
    }
    ///============================================================================= End of Class : Report_Manager =///
}
