using System;
using System.Drawing;
using System.Windows.Forms;
using Gigasoft.ProEssentials;
using Gigasoft.ProEssentials.Enums;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-04-14 ] ///
    /// ▷ Graph_Manager : CommonVariables ◁                                                                       ///
    ///     그래프에서 사용하는 공통 변수들을 선언한 클래스이다.                                                    ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-14 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class Graph_Manager : CommonVariables
    {
        #region [ # Defines & Variables ]
        public readonly float NULL_DATA_VALUE = -99999.0f;
        public double NULL_DATA = -99999.0;

        public double[] ex_XData;
        public double[] ex_YData;

        /// <summary>
        /// Red / Yellow / Blue / Orange / YellowGreen / LightSkyBlue / Pink / LightGree / Cyan / Magenta
        /// </summary>
        static public Color[] GraphColors = { Color.Red, Color.Yellow, Color.Blue, Color.Orange, Color.YellowGreen,
                                         Color.LightSkyBlue, Color.Pink, Color.LightGreen, Color.Cyan, Color.Magenta };
        #endregion
    }
    ///============================================================================== End of Class : Graph_Manager =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.01 / 2014-11-10 ] ///
    /// ▷ MultiSetGraph : Graph_Manager ◁                                                                         ///
    ///     선형 그래프 클래스로 그래프 생성 및 속성 설정 기능들을 지원한다.                                        ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-14 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// [ Ver 1.01 / 2014-11-10 ]                                                                                   ///
    ///     ▶ 그리드 색상 설정, 서브셋 표시 설정                                                                   ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class MultiSetGraph : Graph_Manager
    {
        #region [ # Defines & Variables ]
        private Pesgo m_hPE;
        #endregion

        #region [ # Delegate Functions ]
        private delegate void Redraw(Pesgo pe);
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ MultiSetGraph @                                                                                       ///
        ///     생성자로 그래프 인스턴스를 생성한다.                                                                ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public MultiSetGraph()
        {
            m_hPE = new Pesgo();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ GetSafeHwnd @                                                                                         ///
        ///     그래프 인스턴스의 핸들을 반환한다.                                                                  ///
        /// </summary>                                                                                              ///
        /// <returns>그래프 인스턴스</returns>                                                                      ///
        ///=========================================================================================================///
        public Pesgo GetSafeHwnd() { return m_hPE; }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ CreateGraph @                                                                                         ///
        /// </summary>                                                                                              ///
        /// <param name="pParentWnd"> Control : 그래프를 표시할 패널 </param>                                       ///
        /// <param name="method"> SGraphPlottingMethod : 그래프 표시 방법 </param>                                  ///
        /// <param name="bUseNullDataValueX"> bool : 널 데이터 사용 여부</param>                                    ///
        /// <returns> bool : 그래프 생성 여부</returns>                                                             ///
        ///=========================================================================================================///
        public bool CreateGraph(Control pParentWnd, SGraphPlottingMethod method, bool bUseNullDataValueX)
        {
            pParentWnd.Controls.Add(m_hPE);

            // Auto Resize
            m_hPE.Location = new Point(0, 0);
            m_hPE.Size = pParentWnd.ClientRectangle.Size;

            // Flicker를 제거하기 위해 설정
            m_hPE.PeConfigure.PrepareImages = true;
            m_hPE.PeConfigure.CacheBmp = true;
            m_hPE.PeConfigure.BorderTypes = TABorder.NoBorder;
            m_hPE.PeSpecial.AutoImageReset = false;
            m_hPE.PeData.SpeedBoost = 40;
            m_hPE.PeData.AutoScaleData = false;

            // Set Auto X, Y scale                        
            //m_hPE.PeGrid.Configure.ManualScaleControlX = ManualScaleControl.None;
            //m_hPE.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.MinMax;
            //m_hPE.PeGrid.Configure.ManualMinY = 0.0f;
            //m_hPE.PeGrid.Configure.ManualMaxY = 3.0f;
            m_hPE.PeGrid.Configure.ManualScaleControlX = ManualScaleControl.None;
            m_hPE.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.None;
            m_hPE.PeAnnotation.Show = true;

            // Clear Data
            m_hPE.PeData.X.Clear();
            m_hPE.PeData.Y.Clear();

            // Set NULL Value     
            if (bUseNullDataValueX)
                m_hPE.PeData.NullDataValueX = NULL_DATA_VALUE;

            m_hPE.PeData.NullDataValue = NULL_DATA_VALUE;

            m_hPE.PeData.SpeedBoost = 20;

            // Graph의 배경 및 스타일을 지정한다.
            m_hPE.PeColor.BitmapGradientMode = true;
            m_hPE.PeColor.GraphGradientStyle = GradientStyle.Vertical;
            //m_hPE.PeColor.GraphGradientStyle = GradientStyle.NoGradient;  
            m_hPE.PeColor.GraphGradientStart = Color.FromArgb(39, 39, 69);
            m_hPE.PeColor.GraphGradientEnd = Color.FromArgb(0, 0, 0);
            //m_hPE.PeColor.GraphBackground = Color.Black;
            //m_hPE.PeColor.GraphForeground = Color.White;
            //m_hPE.PeColor.Desk = Color.Black;
            //m_hPE.PeColor.Text = Color.White;            
            m_hPE.PeColor.QuickStyle = QuickStyle.DarkNoBorder;
            m_hPE.PeGrid.LineControl = GridLineControl.Both;
            //m_hPE.PeLegend.Location = LegendLocation.Right;

            // Main Title & Sub Title
            m_hPE.PeString.MainTitle = "";
            m_hPE.PeString.SubTitle = "";
            m_hPE.PeFont.FontSize = FontSize.Large;
            m_hPE.PeFont.Label.Bold = true;
            m_hPE.PeString.XAxisLabel = "";
            m_hPE.PeString.YAxisLabel = "";

            // Scale
            //m_hPE.PeData.AutoScaleData = false;                     
            //m_hPE.PeGrid.Configure.YAxisScaleControl = ScaleControl.Log;
            //m_hPE.PeGrid.Configure.XAxisScaleControl = ScaleControl.Log;            

            m_hPE.PeUserInterface.Allow.Popup = true;
            m_hPE.PeFont.Fixed = true;
            m_hPE.PeUserInterface.Dialog.RandomPointsToExport = true;
            //m_hPE.PeUserInterface.Scrollbar.HorzScrollPos
            m_hPE.PeUserInterface.Scrollbar.ScrollingHorzZoom = true;
            m_hPE.PeUserInterface.Scrollbar.ScrollingScaleControl = true;
            m_hPE.PeUserInterface.Allow.Zooming = AllowZooming.HorzAndVert;
            m_hPE.PeUserInterface.Allow.ZoomStyle = ZoomStyle.Ro2Not;
            m_hPE.PeUserInterface.Allow.FocalRect = false;
            m_hPE.PePlot.Method = method;

            m_hPE.PePlot.Option.NullDataGaps = true;

            // Disable Legend
            // m_hPE.PeLegend.SubsetsToLegend[0] = -1;

            // 커서 모드
            m_hPE.PeUserInterface.Cursor.Mode = CursorMode.DataCross;

            // Help See data points
            m_hPE.PePlot.MarkDataPoints = true;
            m_hPE.PeUserInterface.Cursor.MouseCursorControl = true;
            m_hPE.PeUserInterface.HotSpot.Data = true;

            m_hPE.PeUserInterface.Cursor.PromptTracking = true;
            m_hPE.PeUserInterface.Cursor.PromptStyle = CursorPromptStyle.XYValues;
            m_hPE.PeUserInterface.Cursor.PromptLocation = CursorPromptLocation.Left;

            // 그래프를 갱신한다.
            //m_hPE.PeFunction.Reinitialize();
            //m_hPE.PeFunction.ResetImage(0, 0);
            m_hPE.Refresh();

            ex_XData = new double[0];
            ex_YData = new double[0];

            return true;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ EnableTimeMode @                                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="bMode"> bool : X축 시간축으로 설정 여부 </param>                                           ///
        ///=========================================================================================================///
        public void EnableTimeMode(bool bMode)
        {
            if (bMode)
            {
                m_hPE.PeData.DateTimeMode = true;
                m_hPE.PeData.UsingXDataii = true;

                double ZoomInterval = (3.0 / 1440.0);
                //double ZoomSmallInterval = (0.5 / 1440.0);

                double StartTime = DateTime.Now.ToOADate();

                //m_hPE.PeGrid.Configure.ManualScaleControlX = ManualScaleControl.MinMax;
                m_hPE.PeGrid.Configure.ManualMinX = StartTime;
                m_hPE.PeGrid.Configure.ManualMaxX = StartTime + ZoomInterval;
            }
            else
            {
                m_hPE.PeData.DateTimeMode = false;
                m_hPE.PeData.UsingYDataii = false;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetPlottingMethod @                                                                                   ///
        ///     그래프 표시 유형을 설정한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="method"> SGraphPlottingMethod : 그래프 표시 유형 </param>                                  ///
        ///=========================================================================================================///
        public void SetPlottingMethod(SGraphPlottingMethod method)
        {
            m_hPE.PePlot.Method = method;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetMaxX @                                                                                             ///
        ///     X축의 최대값을 설정한다.                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="lfMax"> double : 설정할 최대 값 </param>                                                   ///
        ///=========================================================================================================///
        public void SetMaxX(double lfMax)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlX = ManualScaleControl.Max;
            m_hPE.PeGrid.Configure.ManualMaxX = lfMax;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetMaxY @                                                                                             ///
        ///     Y축의 최대값을 설정한다.                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="lfMax"> double : 설정할 최대 값 </param>                                                   ///
        ///=========================================================================================================///
        public void SetMaxY(double lfMax)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.Max;
            m_hPE.PeGrid.Configure.ManualMaxY = lfMax;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetMaxZ @                                                                                             ///
        ///     Z축의 최대값을 설정한다.                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="lfMax"> double : 설정할 최대 값 </param>                                                   ///
        ///=========================================================================================================///
        public void SetMaxZ(double lfMax)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlZ = ManualScaleControl.Max;
            m_hPE.PeGrid.Configure.ManualMaxZ = lfMax;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetMinX @                                                                                             ///
        ///     X축의 최소값을 설정한다.                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="lfMin"> double : 설정할 최소 값 </param>                                                   ///
        ///=========================================================================================================///
        public void SetMinX(double lfMin)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlX = ManualScaleControl.Min;
            m_hPE.PeGrid.Configure.ManualMinX = lfMin;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetMinY @                                                                                             ///
        ///     Y축의 최소값을 설정한다.                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="lfMin"> double : 설정할 최소 값 </param>                                                   ///
        ///=========================================================================================================///
        public void SetMinY(double lfMin)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.Min;
            m_hPE.PeGrid.Configure.ManualMinY = lfMin;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetMinZ @                                                                                             ///
        ///     Z축의 최소값을 설정한다.                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="lfMin"> double : 설정할 최소 값 </param>                                                   ///
        ///=========================================================================================================///
        public void SetMinZ(double lfMin)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlZ = ManualScaleControl.Min;
            m_hPE.PeGrid.Configure.ManualMinZ = lfMin;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetMinMaxX @                                                                                          ///
        ///     X축의 최소, 최대값을 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="lfMax"> double : 설정할 최대값 </param>                                                    ///
        /// <param name="lfMin"> double : 설정할 최소값 </param>                                                    ///
        ///=========================================================================================================///
        public void SetMinMaxX(double lfMax, double lfMin)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlX = ManualScaleControl.MinMax;
            m_hPE.PeGrid.Configure.ManualMaxX = lfMax;
            m_hPE.PeGrid.Configure.ManualMinX = lfMin;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetMinMaxY @                                                                                          ///
        ///     Y축의 최소, 최대값을 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="lfMax"> double : 설정할 최대값 </param>                                                    ///
        /// <param name="lfMin"> double : 설정할 최소값 </param>                                                    ///
        ///=========================================================================================================///
        public void SetMinMaxY(double lfMax, double lfMin)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.MinMax;
            m_hPE.PeGrid.Configure.ManualMaxY = lfMax;
            m_hPE.PeGrid.Configure.ManualMinY = lfMin;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetMinMaxZ @                                                                                          ///
        ///     Z축의 최소, 최대값을 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="lfMax"> double : 설정할 최대값 </param>                                                    ///
        /// <param name="lfMin"> double : 설정할 최소값 </param>                                                    ///
        ///=========================================================================================================///
        public void SetMinMaxZ(double lfMax, double lfMin)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlZ = ManualScaleControl.MinMax;
            m_hPE.PeGrid.Configure.ManualMaxZ = lfMax;
            m_hPE.PeGrid.Configure.ManualMinZ = lfMin;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetAutoScale @                                                                                        ///
        ///     Y축의 스케일이 값에 따라 자동으로 변화되도록 설정한다.                                              ///
        /// </summary>                                                                                              ///
        /// <param name="set"> bool : Y축 최대, 최소 스케일 설정 여부 </param>                                      ///
        ///=========================================================================================================///
        public void SetAutoScale(bool set)
        {
            if (set == true)
            {
                m_hPE.PeGrid.Configure.ManualScaleControlX = ManualScaleControl.None;
                m_hPE.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.None;
            }
            else
            {
                m_hPE.PeGrid.Configure.ManualScaleControlX = ManualScaleControl.None;
                m_hPE.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.MinMax;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SubsetCount @                                                                                         ///
        ///     부분 그래프의 개수를 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public int SubsetCount
        {
            get { return m_hPE.PeData.Subsets; }
            set { m_hPE.PeData.Subsets = value; }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ DataPointCount @                                                                                      ///
        ///     데이터 포인트의 개수를 설정한다.                                                                    ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public int DataPointCount
        {
            get { return m_hPE.PeData.Points; }
            set { m_hPE.PeData.Points = value; }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ GetSubsetLabels @                                                                                     ///
        ///     매개변수로 지정한 부분 그래프의 라벨을 반환한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="index"> int : 부분 그래프 인덱스 </param>                                                  ///
        /// <returns> string : 그래프 라벨 </returns>                                                               ///
        ///=========================================================================================================///
        public string GetSubsetLabels(int index)
        {
            string strLabel = string.Empty;

            if (index >= 0 && index < SubsetCount)
            {
                strLabel = m_hPE.PeString.SubsetLabels[index];
            }

            return strLabel;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ GetSubsetColoar @                                                                                     ///
        ///     매개변수로 지정한 부분 그래프의 색상을 반환한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="index"> int : 부분 그래프 인덱스 </param>                                                  ///
        /// <returns> Color : 색상 </returns>                                                                       ///
        ///=========================================================================================================///
        public Color GetSubsetColor(int index)
        {
            Color color = Color.Red;

            if (index >= 0 && index < SubsetCount)
            {
                color = m_hPE.PePlot.SubsetColors[index];
            }

            return color;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetSubsetGraph @                                                                                      ///
        ///     부분 그래프의 색상과 라벨을 설정한다.                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="subsetColor"> Color : 그래프 색상 </param>                                                 ///
        /// <param name="strLabel"> string : 그래프 라벨 </param>                                                   ///
        ///=========================================================================================================///
        public void SetSubsetGraph(int nSubsetIndex, Color subsetColor, string strLabel)
        {
            m_hPE.PePlot.SubsetColors[nSubsetIndex] = subsetColor;
            m_hPE.PePlot.SubsetPointTypes[nSubsetIndex] = PointType.DotSolid;
            m_hPE.PeString.SubsetLabels[nSubsetIndex] = strLabel;
            m_hPE.PePlot.PointSize = PointSize.Medium;
            m_hPE.PePlot.SubsetLineTypes[nSubsetIndex] = LineType.ThinSolid;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ ChangeSubsetGraph @                                                                                   ///
        ///     매개변수로 지정한 부분 그래프의 색상을 변경한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="subsetColor"> Color : 그래프 색상 </param>                                                 ///
        ///=========================================================================================================///
        public void ChangeSubsetGraph(int nSubsetIndex, Color subsetColor)
        {
            m_hPE.PePlot.SubsetColors[nSubsetIndex] = subsetColor;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ ChangeSubsetGraph @                                                                                   ///
        ///     매개변수로 지정한 부분 그래프의 라벨을 변경한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="strLabel"> string : 그래프 라벨 </param>                                                   ///
        ///=========================================================================================================///
        public void ChangeSubsetGraph(int nSubsetIndex, string strLabel)
        {
            m_hPE.PeString.SubsetLabels[nSubsetIndex] = strLabel;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetAnnotationX @                                                                                      ///
        ///     매개변수로 지정한 X값의 위치에 지정한 색상과 형태로 보조선을 추가하고 라벨을 표시한다.              ///
        /// </summary>                                                                                              ///
        /// <param name="nAnnoIndex"> int : 보조선 인덱스 </param>                                                  ///
        /// <param name="xAxis"> double : 보조선 X축 위치 </param>                                                  ///
        /// <param name="annotationcolor"> Color : 보조선 색상 </param>                                             ///
        /// <param name="label"> string : 보조선 라 벨</param>                                                      ///
        /// <param name="type"> LineAnnotationType : 보조선 형태 </param>                                           ///
        ///=========================================================================================================///
        public void SetAnnotationX(int nAnnoIndex, double xAxis, Color annotationcolor, string label, LineAnnotationType type)
        {
            m_hPE.PeAnnotation.Line.XAxisShow = true;
            m_hPE.PeAnnotation.Line.XAxis[nAnnoIndex] = xAxis;
            m_hPE.PeAnnotation.Line.XAxisColor[nAnnoIndex] = annotationcolor;
            m_hPE.PeAnnotation.Line.XAxisType[nAnnoIndex] = type;
            m_hPE.PeAnnotation.Line.XAxisText[nAnnoIndex] = label;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetAnnotationY @                                                                                      ///
        ///     매개변수로 지정한 Y값의 위치에 지정한 색상과 형태로 보조선을 추가하고 라벨을 표시한다.              ///
        /// </summary>                                                                                              ///
        /// <param name="nAnnoIndex"> int : 보조선 인덱스 </param>                                                  ///
        /// <param name="yAxis"> double : 보조선 Y축 위치 </param>                                                  ///
        /// <param name="annotationcolor"> Color : 보조선 색상 </param>                                             ///
        /// <param name="label"> string : 보조선 라벨 </param>                                                      ///
        /// <param name="type"> LineAnnotationType : 보조선 형태 </param>                                           ///
        ///=========================================================================================================///
        public void SetAnnotationY(int nAnnoIndex, double yAxis, Color annotationcolor, string label, LineAnnotationType type)
        {
            m_hPE.PeAnnotation.Line.YAxisShow = true;
            m_hPE.PeAnnotation.Line.YAxis[nAnnoIndex] = yAxis;
            m_hPE.PeAnnotation.Line.YAxisColor[nAnnoIndex] = annotationcolor;
            m_hPE.PeAnnotation.Line.YAxisType[nAnnoIndex] = type;
            m_hPE.PeAnnotation.Line.YAxisText[nAnnoIndex] = label;
        }

        ///=========================================================================================================///
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nAnnoIndex"></param>
        /// <param name="xVal"></param>
        /// <param name="yVal"></param>
        /// <param name="annotationcolor"></param>
        ///=========================================================================================================///
        public void SetAnnotationArrow(int nAnnoIndex, double xVal, double yVal, string text, Color annotationcolor, bool right)
        {
            double weight = 1;

            if (right == true)
            {
                weight = 1.1;
            }
            else
            {
                weight = 0.9;
            }

            m_hPE.PeAnnotation.Graph.X[nAnnoIndex] = xVal;
            m_hPE.PeAnnotation.Graph.Y[nAnnoIndex] = yVal;
            m_hPE.PeAnnotation.Graph.Type[nAnnoIndex] = (int)GraphAnnotationType.PointerArrowMedium;
            m_hPE.PeAnnotation.Graph.Color[nAnnoIndex] = annotationcolor;
            m_hPE.PeAnnotation.Graph.Text[nAnnoIndex] = "|H" + (xVal * weight) + "|" + (yVal * 1.1) + "|" + xVal + " " + text;

            m_hPE.PeAnnotation.Graph.Moveable = true;
            m_hPE.PeUserInterface.HotSpot.GraphAnnotation = AnnotationHotSpot.GraphOnly;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetPointType @                                                                                        ///
        ///     매개변수로 지정한 부분 그래프의 포인트 표시 형태를 설정한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="type"> PointType : 포인트 형태 </param>                                                    ///
        ///=========================================================================================================///
        public void SetPointType(int nSubsetIndex, PointType type)
        {
            m_hPE.PePlot.SubsetPointTypes[nSubsetIndex] = type;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetPointSize @                                                                                        ///
        ///     매개변수로 지정한 부분 그래프의 포인트 크기를 설정한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="size"> PointSize : 포인트 크기 </param>                                                    ///
        ///=========================================================================================================///
        public void SetPointSize(int nSubsetIndex, PointSize size)
        {
            m_hPE.PePlot.PointSize = size;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetLegendLocation @                                                                                   ///
        ///     그래프에 범례 위치를 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="Location"> LegendLocation : 범례 위치 </param>                                             ///
        ///=========================================================================================================///
        public void SetLegendLocation(LegendLocation Location)
        {
            m_hPE.PeLegend.Location = Location;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetLegend @                                                                                           ///
        ///     그래프에 범례를 설정한다.                                                                           ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="strLegend"> string : 그래프 범례 </param>                                                  ///
        ///=========================================================================================================///
        public void SetLegend(int nSubsetIndex, string strLegend)
        {
            m_hPE.PeString.SubsetLabels[nSubsetIndex] = strLegend;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetSubTitle @                                                                                         ///
        ///     그래프의 보조 제목을 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="strTitle"> string : 보조 제목 </param>                                                     ///
        ///=========================================================================================================///
        public void SetSubTitle(string strTitle)
        {
            m_hPE.PeString.SubTitle = strTitle;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetMainTitle @                                                                                        ///
        ///     그래프의 주 제목을 설정한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="strTitle"> string : 주 제목 </param>                                                       ///
        ///=========================================================================================================///
        public void SetMainTitle(string strTitle)
        {
            m_hPE.PeString.MainTitle = strTitle;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ AddGraphPoint @                                                                                       ///
        ///     그래프에 새로운 좌표를 추가한다.                                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="nDataPointIndex"> int : 그래프 데이터 버퍼 인덱스 </param>                                 ///
        /// <param name="x"> float : X축 좌표 </param>                                                              ///
        /// <param name="y"> float : Y축 좌표 </param>                                                              ///
        ///=========================================================================================================///
        public void AddGraphPoint(int nSubsetIndex, int nDataPointIndex, float x, float y)
        {
            if (nDataPointIndex >= m_hPE.PeData.Points)
            {
                int i = 1;

                for (i = 1; i < m_hPE.PeData.Points; i++)
                {
                    m_hPE.PeData.X[nSubsetIndex, i - 1] = m_hPE.PeData.X[nSubsetIndex, i];
                    m_hPE.PeData.Y[nSubsetIndex, i - 1] = m_hPE.PeData.Y[nSubsetIndex, i];
                }

                m_hPE.PeData.X[nSubsetIndex, m_hPE.PeData.Points - 1] = x;
                m_hPE.PeData.Y[nSubsetIndex, m_hPE.PeData.Points - 1] = y;
            }
            else
            {
                m_hPE.PeData.X[nSubsetIndex, nDataPointIndex] = x;
                m_hPE.PeData.Y[nSubsetIndex, nDataPointIndex] = y;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ AddGraphPoint @                                                                                       ///
        ///     그래프에 새로운 좌표(배열)를 추가한다.                                                              ///
        ///     매개변수로 지정한 X축의 위치부터 순차적으로 추가한다.                                               ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="nDataPointIndex"> int : 그래프 데이터 버퍼 인덱스 </param>                                 ///
        /// <param name="x"> float : X축 좌표 </param>                                                              ///
        /// <param name="y"> float[] : Y축 좌표 </param>                                                            ///
        ///=========================================================================================================///
        public void AddGraphPoint(int nSubsetIndex, int nDataPointIndex, float x, float[] y)
        {
            if (nDataPointIndex >= m_hPE.PeData.Points)
            {
                for (int i = y.Length; i < m_hPE.PeData.Points; i++)
                {
                    m_hPE.PeData.X[nSubsetIndex, i - y.Length] = m_hPE.PeData.X[nSubsetIndex, i];
                    m_hPE.PeData.Y[nSubsetIndex, i - y.Length] = m_hPE.PeData.Y[nSubsetIndex, i];
                }

                int idx = m_hPE.PeData.Points - y.Length;

                for (int i = 0; i < y.Length; i++)
                {
                    m_hPE.PeData.X[nSubsetIndex, idx + i] = x + i;
                    m_hPE.PeData.Y[nSubsetIndex, idx + i] = y[i];
                }
            }
            else
            {
                for (int i = 0; i < y.Length; i++)
                {
                    m_hPE.PeData.X[nSubsetIndex, nDataPointIndex + i] = x + i;
                    m_hPE.PeData.Y[nSubsetIndex, nDataPointIndex + i] = y[i];
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ AddGraphPoint @                                                                                       ///
        ///     그래프에 새로운 좌표를 추가한다.                                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="nDataPointIndex"> int : 그래프 데이터 버퍼 인덱스 </param>                                 ///
        /// <param name="theCurrentTime"> DateTime : X축 시간 좌표 </param>                                         ///
        /// <param name="y"> float : Y축 좌표 </param>                                                              ///
        ///=========================================================================================================///
        public void AddGraphPoint(int nSubsetIndex, int nDataPointIndex, DateTime theCurrentTime, float y)
        {
            double x = theCurrentTime.ToOADate();

            if (nDataPointIndex >= m_hPE.PeData.Points)
            {
                int i = 1;
                for (i = 1; i < m_hPE.PeData.Points; i++)
                {
                    m_hPE.PeData.Xii[nSubsetIndex, i - 1] = m_hPE.PeData.Xii[nSubsetIndex, i];
                    m_hPE.PeData.Y[nSubsetIndex, i - 1] = m_hPE.PeData.Y[nSubsetIndex, i];
                }

                m_hPE.PeData.Xii[nSubsetIndex, m_hPE.PeData.Points - 1] = x;
                m_hPE.PeData.Y[nSubsetIndex, m_hPE.PeData.Points - 1] = y;
            }
            else
            {
                m_hPE.PeData.Xii[nSubsetIndex, nDataPointIndex] = x;
                m_hPE.PeData.Y[nSubsetIndex, nDataPointIndex] = y;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ AddGraphPoint @                                                                                       ///
        ///     그래프에 새로운 좌표(배열)를 추가한다.                                                              ///
        ///     매개변수로 지정한 X축의 위치부터 순차적으로 추가한다.                                               ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="nDataPointIndex"> int : 그래프 데이터 버퍼 인덱스 </param>                                 ///
        /// <param name="theCurrentTime"> DateTime : X축 시간 좌표 </param>                                         ///
        /// <param name="y"> float[] : Y축 좌표 </param>                                                            ///
        ///=========================================================================================================///
        public void AddGraphPoint(int nSubsetIndex, int nDataPointIndex, DateTime theCurrentTime, double[] y)
        {
            double x = 0.0;// theCurrentTime.ToOADate();
            long tick = 10000000 / y.Length;

            if (nDataPointIndex >= m_hPE.PeData.Points)
            {
                for (int i = y.Length; i < m_hPE.PeData.Points; i++)
                {
                    m_hPE.PeData.Xii[nSubsetIndex, i - y.Length] = m_hPE.PeData.Xii[nSubsetIndex, i];
                    m_hPE.PeData.Y[nSubsetIndex, i - y.Length] = m_hPE.PeData.Y[nSubsetIndex, i];
                }

                int idx = m_hPE.PeData.Points - y.Length;

                for (int i = 0; i < y.Length; i++)
                {
                    x = theCurrentTime.AddTicks(tick * i).ToOADate();
                    m_hPE.PeData.Xii[nSubsetIndex, idx + i] = x;
                    m_hPE.PeData.Y[nSubsetIndex, idx + i] = (float)y[i];
                }
            }
            else
            {
                for (int i = 0; i < y.Length; i++)
                {
                    x = theCurrentTime.AddTicks(tick * i).ToOADate();
                    m_hPE.PeData.Xii[nSubsetIndex, nDataPointIndex + i] = x;
                    m_hPE.PeData.Y[nSubsetIndex, nDataPointIndex + i] = (float)y[i];
                }
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ AddGraphPoint @                                                                                       ///
        ///     그래프에 새로운 좌표(배열)를 추가한다.                                                              ///
        ///     X, Y축 좌표를 모두 매개변수를 통해 데이터 배열과 그 크기를 전달 받아 처리한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="pX"> double[] : X축 좌표 데이터 배열 </param>                                              ///
        /// <param name="pY"> double[] : Y축 좌표 데이터 배열 </param>                                              ///
        /// <param name="nCount"> int : 데이터 배열의 크기 </param>                                                 ///
        ///=========================================================================================================///
        public void AddGraphPoint(double[] pX, double[] pY, int nCount)
        {
            if ((ex_XData.Length < nCount) || (ex_YData.Length < nCount))
            {
                ex_XData = new double[nCount];
                ex_YData = new double[nCount];
            }

            // Perform the actual transfer of data //
            Api.PEvsetW(m_hPE.PeSpecial.HObject, DllProperties.XData, pX, nCount);
            Api.PEvsetW(m_hPE.PeSpecial.HObject, DllProperties.YData, pY, nCount);

            // Set plotting method to line and allow zooming //
            m_hPE.PePlot.Method = SGraphPlottingMethod.Line;
            m_hPE.PeUserInterface.Allow.Zooming = AllowZooming.Horizontal;
            m_hPE.PeUserInterface.Scrollbar.ScrollingHorzZoom = true;
            m_hPE.PeUserInterface.Dialog.PlotCustomization = false;

            // Helps speed large data se3ts, default is 3, good range is 0 to 20 //
            m_hPE.PeData.SpeedBoost = 10;

            // Set the padding between data and edge of chart //
            m_hPE.PeGrid.Configure.AutoMinMaxPadding = 1;

            // Disable auto scaling of data //
            m_hPE.PeData.AutoScaleData = false;

            m_hPE.PePlot.SubsetLineTypes[0] = LineType.ThinSolid;
            m_hPE.PePlot.Option.LineShadows = false;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ AddGraphPoint @                                                                                       ///
        ///     그래프에 새로운 좌표(배열)를 추가한다.                                                              ///
        ///     X, Y축 좌표를 모두 매개변수를 통해 데이터 배열과 그 크기를 전달 받아 처리한다.                      ///
        /// </summary>                                                                                              ///
        /// <param name="pX"> DateTime[] : X축 시간 데이터 배열 </param>                                            ///
        /// <param name="pY"> double[] : Y축 좌표 데이터 배열 </param>                                              ///
        /// <param name="nCount"> int : 데이터 배열의 크기 </param>                                                 ///
        ///=========================================================================================================///
        public void AddGraphPoint(DateTime[] pX, double[] pY, int nCount)
        {
            if ((ex_XData.Length < nCount) || (ex_YData.Length < nCount))
            {
                ex_XData = new double[nCount];
                ex_YData = new double[nCount];
            }

            // Perform the actual transfer of data //
            Api.PEvsetW(m_hPE.PeSpecial.HObject, DllProperties.XData, pX, nCount);
            Api.PEvsetW(m_hPE.PeSpecial.HObject, DllProperties.YData, pY, nCount);

            // Set plotting method to line and allow zooming //
            m_hPE.PePlot.Method = SGraphPlottingMethod.Line;
            m_hPE.PeUserInterface.Allow.Zooming = AllowZooming.Horizontal;
            m_hPE.PeUserInterface.Scrollbar.ScrollingHorzZoom = true;
            m_hPE.PeUserInterface.Dialog.PlotCustomization = false;

            // Helps speed large data se3ts, default is 3, good range is 0 to 20 //
            m_hPE.PeData.SpeedBoost = 10;

            // Set the padding between data and edge of chart //
            m_hPE.PeGrid.Configure.AutoMinMaxPadding = 1;

            // Disable auto scaling of data //
            m_hPE.PeData.AutoScaleData = false;

            m_hPE.PePlot.SubsetLineTypes[0] = LineType.ThinSolid;
            m_hPE.PePlot.Option.LineShadows = false;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetGraphPoint @                                                                                       ///
        ///     매개변수로 지정한 부분 그래프의 좌표 데이터를 매개변수로 전달하는 좌표 데이터로 변경한다.           ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="nDataPointIndex"> int : 그래프 데이터 버퍼 인덱스 </param>                                 ///
        /// <param name="x"> float : X축 변경 좌표 데이터 </param>                                                  ///
        /// <param name="y"> float : Y축 변경 좌표 데이터 </param>                                                  ///
        ///=========================================================================================================///
        public void SetGraphPoint(int nSubsetIndex, int nDataPointIndex, float x, float y)
        {
            m_hPE.PeData.X[nSubsetIndex, nDataPointIndex] = x;
            m_hPE.PeData.Y[nSubsetIndex, nDataPointIndex] = y;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetGraphPoint @                                                                                       ///
        ///     매개변수로 지정한 부분 그래프의 좌표 데이터를 매개변수로 전달하는 좌표 데이터로 변경한다.           ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="nDataPointIndex"> int : 그래프 데이터 버퍼 인덱스 </param>                                 ///
        /// <param name="theCurrentTime"> DateTime : X축 시간 좌표 </param>                                         ///
        /// <param name="y"> float : Y축 변경 좌표 데이터 </param>                                                  ///
        ///=========================================================================================================///
        public void SetGraphPoint(int nSubsetIndex, int nDataPointIndex, DateTime theCurrentTime, float y)
        {
            double x = theCurrentTime.ToOADate();
            m_hPE.PeData.Xii[nSubsetIndex, nDataPointIndex] = x;
            m_hPE.PeData.Y[nSubsetIndex, nDataPointIndex] = y;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ GetXDataIndexOf @                                                                                     ///
        ///     매개변수로 지정한 부분 그래프에서 해당 좌표의 X값을 반환한다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="nDataIndex"> int : 그래프 데이터 버퍼 인덱스 </param>                                      ///
        /// <returns> float : 좌표의 X값 </returns>                                                                 ///
        ///=========================================================================================================///
        public float GetXDataIndexOf(int nSubsetIndex, int nDataIndex)
        {
            return m_hPE.PeData.X[nSubsetIndex, nDataIndex];
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ GetYDataIndexOf @                                                                                     ///
        ///     매개변수로 지정한 부분 그래프에서 해당 좌표의 Y값을 반환한다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="nDataIndex"> int : 그래프 데이터 버퍼 인덱스 </param>                                      ///
        /// <returns> float : 좌표의 Y값 </returns>                                                                 ///
        ///=========================================================================================================///
        public float GetYDataIndexOf(int nSubsetIndex, int nDataIndex)
        {
            return m_hPE.PeData.Y[nSubsetIndex, nDataIndex];
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ GetZDataIndexOf @                                                                                     ///
        ///     매개변수로 지정한 부분 그래프에서 해당 좌표의 Z값을 반환한다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="nDataIndex"> int : 그래프 데이터 버퍼 인덱스 </param>                                      ///
        /// <returns> float : 좌표의 Z값 </returns>                                                                 ///
        ///=========================================================================================================///
        public float GetZDataIndexOf(int nSubsetIndex, int nDataIndex)
        {
            return m_hPE.PeData.Z[nSubsetIndex, nDataIndex];
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ GetXDataArray @                                                                                       ///
        ///     그래프 데이터 버퍼의 X축 좌표 데이터를 반환한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <returns> float[,] : X축 좌표 데이터 </returns>                                                         ///
        ///=========================================================================================================///
        public float[,] GetXDataArray()
        {
            return m_hPE.PeData.X.Copy();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ GetXDataArray @                                                                                       ///
        ///     그래프 데이터 버퍼의 X축 좌표 데이터를 반환한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <returns> double[,] : X축 좌표 데이터 </returns>                                                        ///
        ///=========================================================================================================///
        public double[,] GetXiiDataArray()
        {
            return m_hPE.PeData.Xii.Copy();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ GetXDataArray @                                                                                       ///
        ///     그래프 데이터 버퍼의 Y축 좌표 데이터를 반환한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <returns> float[,] : Y축 좌표 데이터 </returns>                                                         ///
        ///=========================================================================================================///
        public float[,] GetYDataArray()
        {
            return m_hPE.PeData.Y.Copy();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ GetXDataArray @                                                                                       ///
        ///     그래프 데이터 버퍼의 Y축 좌표 데이터를 반환한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <returns> double[,] : Y축 좌표 데이터 </returns>                                                        ///
        ///=========================================================================================================///
        public double[,] GetYiiDataArray()
        {
            return m_hPE.PeData.Yii.Copy();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ GetXDataArray @                                                                                       ///
        ///     그래프 데이터 버퍼의 Z축 좌표 데이터를 반환한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <returns> float[,] : Z축 좌표 데이터 </returns>                                                         ///
        ///=========================================================================================================///
        public float[,] GetZDataArray()
        {
            return m_hPE.PeData.Z.Copy();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ ClearGraph @                                                                                          ///
        ///     모든 그래프 버퍼의 데이터를 초기화한다.                                                             ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void ClearGraph()
        {
            m_hPE.PeData.X.Clear();
            m_hPE.PeData.Xii.Clear();
            m_hPE.PeData.Y.Clear();
            m_hPE.PeData.Yii.Clear();
            m_hPE.PeData.Z.Clear();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ RefreshGraph @                                                                                        ///
        ///     그래프를 다시 그린다.                                                                               ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void RefreshGraph()
        {
            //m_hPE.PeFunction.ReinitializeResetImage();
            //m_hPE.Refresh();
            ReDraw(m_hPE);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ ReDraw @                                                                                              ///
        ///     매개변수로 넘겨진 그래프 인스턴스의 이미지를 다시 그린다.                                           ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="pe"> Pesgo : 그래프 인스턴스 </param>                                                      ///
        ///=========================================================================================================///
        private void ReDraw(Pesgo pe)
        {
            if (pe.InvokeRequired == true)
            {
                pe.Invoke(new Redraw(ReDraw), pe);
            }
            else
            {
                pe.PeFunction.ReinitializeResetImage();
                pe.Refresh();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ SetXAxisLabel @                                                                                       ///
        ///     X축에 라벨을 설정한다.                                                                              ///
        /// </summary>                                                                                              ///
        /// <param name="strLabel"> string : X축 라벨 내용 </param>                                                 ///
        ///=========================================================================================================///
        public void SetXAxisLabel(string strLabel)
        {
            m_hPE.PeString.XAxisLabel = strLabel;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ SetXAxisLabel @                                                                                       ///
        ///     Y축에 라벨을 설정한다.                                                                              ///
        /// </summary>                                                                                              ///
        /// <param name="strLabel"> string : Y축 라벨 내용 </param>                                                 ///
        ///=========================================================================================================///
        public void SetYAxisLabel(string strLabel)
        {
            m_hPE.PeString.YAxisLabel = strLabel;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ SetSize @                                                                                             ///
        ///     그래프 인스턴스의 크기를 변경한다.                                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="theSize"> Size : 그래프 크기 </param>                                                      ///
        ///=========================================================================================================///
        public void SetSize(Size theSize)
        {
            m_hPE.Size = new Size(theSize.Width, theSize.Height - 20);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ SetLocation @                                                                                         ///
        ///     그래프 인스턴스의 위치를 변경한다.                                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="thePoint"> Point : 그래프 위치 </param>                                                    ///
        ///=========================================================================================================///
        public void SetLocation(Point thePoint)
        {
            m_hPE.Location = thePoint;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ Destroy @                                                                                             ///
        ///     그래프 인스턴스를 종료하고 자원을 회수한다.                                                         ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void Destroy()
        {
            m_hPE.Dispose();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ ExportToJPG @                                                                                         ///
        ///     그래프를 JPG 포맷의 이미지 파일로 저장한다.                                                         ///
        ///     매개변수를 통해 파일 이름과 이미지의 해상도를 지정할 수 있다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="strFileName"> string : 파일 이름 </param>                                                  ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 파일 저장 여부 </returns>                                                        ///
        ///=========================================================================================================///
        public int ExportToJPG(string strFileName, int width, int height)
        {
            return m_hPE.PeFunction.Image.JpegToFile(width, height, strFileName);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ ExportToBMP @                                                                                         ///
        ///     그래프를 BMP 포맷의 이미지 파일로 저장한다.                                                         ///
        ///     매개변수를 통해 파일 이름과 이미지의 해상도를 지정할 수 있다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="strFileName"> string : 파일 이름 </param>                                                  ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 파일 저장 여부 </returns>                                                        ///
        ///=========================================================================================================///
        public int ExportToBMP(string strFileName, int width, int height)
        {
            return m_hPE.PeFunction.Image.BitmapToFile(width, height, strFileName);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ ExportToPNG @                                                                                         ///
        ///     그래프를 PNG 포맷의 이미지 파일로 저장한다.                                                         ///
        ///     매개변수를 통해 파일 이름과 이미지의 해상도를 지정할 수 있다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="strFileName"> string : 파일 이름 </param>                                                  ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 파일 저장 여부 </returns>                                                        ///
        ///=========================================================================================================///
        public int ExportToPNG(string strFileName, int width, int height)
        {
            return m_hPE.PeFunction.Image.PngToFile(width, height, strFileName);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ BMPtoClipboard @                                                                                      ///
        ///     그래프를 BMP 포맷의 이미지로 캡쳐하여 클립보드에 복사한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 클립보드 복사 여부 </returns>                                                    ///
        ///=========================================================================================================///
        public int BMPtoClipboard(int width, int height)
        {
            return m_hPE.PeFunction.Image.BitmapToClipboard(width, height);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ JPGtoClipboard @                                                                                      ///
        ///     그래프를 JPG 포맷의 이미지로 캡쳐하여 클립보드에 복사한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 클립보드 복사 여부 </returns>                                                    ///
        ///=========================================================================================================///
        public int JPGtoClipboard(int width, int height)
        {
            return m_hPE.PeFunction.Image.JpegToClipboard(width, height);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ PNGtoClipboard @                                                                                      ///
        ///     그래프를 PNG 포맷의 이미지로 캡쳐하여 클립보드에 복사한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 클립보드 복사 여부 </returns>                                                    ///
        ///=========================================================================================================///
        public int PNGtoClipboard(int width, int height)
        {
            return m_hPE.PeFunction.Image.PngToClipboard(width, height);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ SetVewingStyle @                                                                                      ///
        ///     그래프의 컬러 모드를 설정한다.                                                                      ///
        ///     1(모노) / 2(모노 심볼) / 기본(컬러)                                                                 ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> int : 컬러 모드 </param>                                                            ///
        ///=========================================================================================================///
        public void SetViewingStyle(int mode)
        {
            switch (mode)
            {
                case 1: m_hPE.PeColor.ViewingStyle = ViewingStyle.Mono; break;
                case 2: m_hPE.PeColor.ViewingStyle = ViewingStyle.MonoWithSymbols; break;
                default: m_hPE.PeColor.ViewingStyle = ViewingStyle.Color; break;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ SetCursorMode @                                                                                       ///
        ///     그래프에 커서 표시를 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="set"> bool :  커서 표시 여부 </param>                                                      ///
        ///=========================================================================================================///
        public void SetCursorMode(bool set)
        {
            if (set == true)
            {
                m_hPE.PeUserInterface.Cursor.Mode = CursorMode.DataCross;
            }
            else
            {
                m_hPE.PeUserInterface.Cursor.Mode = CursorMode.NoCursor;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ SetMarkDataPoint @                                                                                    ///
        ///     그래프의 좌표 데이터 표시 지점에 마커 표시를 설정한다.                                              ///
        /// </summary>                                                                                              ///
        /// <param name="set"> bool : 마커 표시 여부 </param>                                                       ///
        ///=========================================================================================================///
        public void SetMarkDataPoint(bool set)
        {
            m_hPE.PePlot.MarkDataPoints = set;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-08 ] ///
        /// @ SetFontSize @                                                                                         ///
        ///     그래프에 적용할 폰트 크기를 설정한다.                                                               ///
        ///     0(작게) / 1(중간) / 2(크게)                                                                         ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> int : 폰트 크기 </param>                                                            ///
        ///=========================================================================================================///
        public void SetFontSize(int mode)
        {
            switch (mode)
            {
                case 0:
                    m_hPE.PeFont.FontSize = FontSize.Small; break;
                case 1:
                    m_hPE.PeFont.FontSize = FontSize.Medium; break;
                case 2:
                    m_hPE.PeFont.FontSize = FontSize.Large; break;
                default:
                    m_hPE.PeFont.FontSize = FontSize.Medium; break;
            }
        }
        #endregion

        #region [ # Ver 1.01 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-11-10 ] ///
        /// @ SetGridLineColor @                                                                                    ///
        ///     그래프의 x, y축 그리드의 색상을 설정한다.                                                           ///
        /// </summary>                                                                                              ///
        /// <param name="col"> Color : 설정 색상 </param>                                                           ///
        ///=========================================================================================================///
        public void SetGridLineColor(Color col)
        {
            m_hPE.PeColor.GridLineColor = col;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.01 / 2014-11-10 ] ///
        /// @ SetSubsetVisible @                                                                                    ///
        ///     그래프 서브셋의 표시 여부를 설정한다.                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="subset"> int : 서브셋 인덱스 </param>                                                      ///
        /// <param name="visible"> bool : 표시 여부 </param>                                                        ///
        ///=========================================================================================================///
        public void SetSubsetVisible(int subset, bool visible)
        {
            m_hPE.PeData.SubsetsToShow[subset] = Convert.ToInt32(visible);
        }
        #endregion
    }
    ///============================================================================== End of Class : MultiSetGraph =///

    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-04-14 ] ///
    /// ▷ MultiSetGraphBar : Graph_Manager ◁                                                                      ///
    ///     막대 그래프 클래스로 그래프 생성 및 속성 설정 기능들을 지원한다.                                        ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-14 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public class MultiSetGraphBar : Graph_Manager
    {
        #region [ # Defines & Variables ]
        private Pego m_hPE;
        #endregion

        #region [ # Delegate Functions ]
        private delegate void Redraw(Pego pe);
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ MultiSetGraph @                                                                                       ///
        ///     생성자로 그래프 인스턴스를 생성한다.                                                                ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public MultiSetGraphBar() 
        {
            // 그래프 인스턴스를 생성            
            m_hPE = new Pego();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ GetSafeHwnd @                                                                                         ///
        ///     그래프 인스턴스의 핸들을 반환한다.                                                                  ///
        /// </summary>                                                                                              ///
        /// <returns>그래프 인스턴스</returns>                                                                      ///
        ///=========================================================================================================///
        public Pego GetSafeHwnd() { return m_hPE; }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ CreateGraph @                                                                                         ///
        /// </summary>                                                                                              ///
        /// <param name="pParentWnd"> Control : 그래프를 표시할 패널 </param>                                       ///
        /// <returns> bool : 그래프 생성 여부 </returns>                                                            ///
        ///=========================================================================================================///
        public bool CreateGraph(Control pParentWnd)
        {
            pParentWnd.Controls.Add(m_hPE);

            // Auto Resize
            m_hPE.Location = new Point(0, 0);
            m_hPE.Size = pParentWnd.ClientRectangle.Size;

            // Flicker를 제거하기 위해 설정
            m_hPE.PeConfigure.PrepareImages = true;
            m_hPE.PeConfigure.CacheBmp = true;
            m_hPE.PeConfigure.BorderTypes = TABorder.DropShadow;
            m_hPE.PeSpecial.AutoImageReset = false;
            m_hPE.PeData.SpeedBoost = 0;
            m_hPE.PeData.AutoScaleData = false;

            // Set Auto X, Y scale                        
            m_hPE.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.None;
            m_hPE.PeAnnotation.Show = true;

            // Clear Data
            m_hPE.PeData.X.Clear();
            m_hPE.PeData.Y.Clear();

            // Set NULL Value            
            m_hPE.PeData.NullDataValue = NULL_DATA_VALUE;

            // Graph의 배경 및 스타일을 지정한다.
            //m_hPE.PeColor.BitmapGradientMode = true;
            //m_hPE.PeColor.GraphGradientStyle = GradientStyle.Vertical;
            //m_hPE.PeColor.GraphGradientStart = Color.FromArgb(39, 39, 69);
            //m_hPE.PeColor.GraphGradientEnd = Color.FromArgb(0, 0, 0);
            //m_hPE.PeColor.QuickStyle = QuickStyle.DarkNoBorder;
            //m_hPE.PeGrid.LineControl = GridLineControl.None;
            //m_hPE.PeLegend.Location = LegendLocation.Right;

            //m_hPE.PeColor.BitmapGradientMode = true;
            //m_hPE.PeColor.GraphGradientStyle = GradientStyle.Vertical;
            m_hPE.PeColor.GraphGradientStyle = GradientStyle.NoGradient;  
            //m_hPE.PeColor.GraphGradientStart = Color.FromArgb(39, 39, 69);
            //m_hPE.PeColor.GraphGradientEnd = Color.FromArgb(0, 0, 0);
            m_hPE.PeColor.GraphBackground = Color.White;
            m_hPE.PeColor.GraphForeground = Color.Black;
            m_hPE.PeColor.Desk = Color.White;
            m_hPE.PeColor.Text = Color.Black;   
         
            // Main Title & Sub Title
            m_hPE.PeString.MainTitle = "";
            m_hPE.PeString.SubTitle = "";
            m_hPE.PeFont.Label.Bold = true;
            m_hPE.PeString.XAxisLabel = "";
            m_hPE.PeString.YAxisLabel = "";

            // Scale
            //m_hPE.PeData.AutoScaleData = false;                     
            //m_hPE.PeGrid.Configure.YAxisScaleControl = ScaleControl.Log;
            //m_hPE.PeGrid.Configure.XAxisScaleControl = ScaleControl.Log;

            m_hPE.PeUserInterface.Allow.Popup = true;
            m_hPE.PeFont.Fixed = true;
            //m_hPE.PeUserInterface.Dialog.RandomPointsToExport = true;
            m_hPE.PeUserInterface.Allow.Zooming = AllowZooming.HorzAndVert;
            m_hPE.PeUserInterface.Allow.ZoomStyle = ZoomStyle.Ro2Not;
            m_hPE.PeUserInterface.Allow.FocalRect = false;
            m_hPE.PePlot.DataShadows = DataShadows.Shadows;
            m_hPE.PePlot.Method = GraphPlottingMethod.Bar;
            m_hPE.PePlot.Allow.StackedData = true;
            m_hPE.PePlot.Allow.Ribbon = true;
            //m_hPE.PePlot.Option.GradientBars = 8;
            m_hPE.PePlot.Option.LineShadows = true;

            // 그래프를 갱신한다.
            //m_hPE.PeFunction.Reinitialize();
            //m_hPE.PeFunction.ResetImage(0, 0);
            m_hPE.Refresh();
            
            return true;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetPlottingMethod @                                                                                   ///
        ///     그래프 표시 유형을 설정한다.                                                                        ///
        /// </summary>                                                                                              ///
        /// <param name="method"> SGraphPlottingMethod : 그래프 표시 유형 </param>                                  ///
        ///=========================================================================================================///
        public void SetPlottingMethod(GraphPlottingMethod method)
        {
            m_hPE.PePlot.Method = method;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetMaxX @                                                                                             ///
        ///     X축의 최대값을 설정한다.                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="lfMax"> double : 설정할 최대 값 </param>                                                   ///
        ///=========================================================================================================///
        public void SetMaxY(double lfMax)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.Max;
            m_hPE.PeGrid.Configure.ManualMaxY = lfMax;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetMinY @                                                                                             ///
        ///     Y축의 최소값을 설정한다.                                                                            ///
        /// </summary>                                                                                              ///
        /// <param name="lfMin"> double : 설정할 최소 값 </param>                                                   ///
        ///=========================================================================================================///
        public void SetMinY(double lfMin)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.Min;
            m_hPE.PeGrid.Configure.ManualMinY = lfMin;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetMinMaxY @                                                                                          ///
        ///     Y축의 최소, 최대값을 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="lfMax"> double : 설정할 최대값 </param>                                                    ///
        /// <param name="lfMin"> double : 설정할 최소값 </param>                                                    ///
        ///=========================================================================================================///
        public void SetMinMaxY(double lfMax, double lfMin)
        {
            m_hPE.PeGrid.Configure.ManualScaleControlY = ManualScaleControl.MinMax;
            m_hPE.PeGrid.Configure.ManualMaxY = lfMax;
            m_hPE.PeGrid.Configure.ManualMinY = lfMin;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SubsetCount @                                                                                         ///
        ///     부분 그래프의 개수를 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public int SubsetCount
        {
            get { return m_hPE.PeData.Subsets; }
            set { m_hPE.PeData.Subsets = value; }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ DataPointCount @                                                                                      ///
        ///     데이터 포인트의 개수를 설정한다.                                                                    ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public int DataPointCount
        {
            get { return m_hPE.PeData.Points; }
            set { m_hPE.PeData.Points = value; }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetSubsetGraph @                                                                                      ///
        ///     부분 그래프의 색상과 라벨을 설정한다.                                                               ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="subsetColor"> Color : 그래프 색상 </param>                                                 ///
        /// <param name="strLabel"> string : 그래프 라벨 </param>                                                   ///
        ///=========================================================================================================///
        public void SetSubsetGraph(int nSubsetIndex, Color subsetColor, string strLabel)
        {
            m_hPE.PePlot.SubsetColors[nSubsetIndex] = subsetColor;
            m_hPE.PePlot.SubsetPointTypes[nSubsetIndex] = PointType.DotSolid;
            m_hPE.PeString.SubsetLabels[nSubsetIndex] = strLabel;
            m_hPE.PePlot.PointSize = PointSize.Small;
            m_hPE.PePlot.SubsetLineTypes[nSubsetIndex] = LineType.ThinSolid;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetAnnotationX @                                                                                      ///
        ///     매개변수로 지정한 X값의 위치에 지정한 색상과 형태로 보조선을 추가하고 라벨을 표시한다.              ///
        /// </summary>                                                                                              ///
        /// <param name="nAnnoIndex"> int : 보조선 인덱스 </param>                                                  ///
        /// <param name="xAxis"> double : 보조선 X축 위치 </param>                                                  ///
        /// <param name="annotationcolor"> Color : 보조선 색상 </param>                                             ///
        /// <param name="label"> string : 보조선 라벨 </param>                                                      ///
        /// <param name="type"> LineAnnotationType : 보조선 형태 </param>                                           ///
        ///=========================================================================================================///
        public void SetAnnotationX(int nAnnoIndex, double xAxis, Color annotationcolor, string label, LineAnnotationType type)
        {
            m_hPE.PeAnnotation.Line.XAxisShow = true;
            m_hPE.PeAnnotation.Line.XAxis[nAnnoIndex] = xAxis;
            m_hPE.PeAnnotation.Line.XAxisColor[nAnnoIndex] = annotationcolor;
            m_hPE.PeAnnotation.Line.XAxisType[nAnnoIndex] = type;
            m_hPE.PeAnnotation.Line.XAxisText[nAnnoIndex] = label;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetAnnotationY @                                                                                      ///
        ///     매개변수로 지정한 Y값의 위치에 지정한 색상과 형태로 보조선을 추가하고 라벨을 표시한다.              ///
        /// </summary>                                                                                              ///
        /// <param name="nAnnoIndex"> int : 보조선 인덱스 </param>                                                  ///
        /// <param name="yAxis"> double : 보조선 Y축 위치 </param>                                                  ///
        /// <param name="annotationcolor"> Color : 보조선 색상 </param>                                             ///
        /// <param name="label"> string : 보조선 라벨 </param>                                                      ///
        /// <param name="type"> LineAnnotationType : 보조선 형태 </param>                                           ///
        ///=========================================================================================================///
        public void SetAnnotationY(int nAnnoIndex, double yAxis, Color annotationcolor, string label, LineAnnotationType type)
        {
            m_hPE.PeAnnotation.Line.YAxisShow = true;
            m_hPE.PeAnnotation.Line.YAxis[nAnnoIndex] = yAxis;
            m_hPE.PeAnnotation.Line.YAxisColor[nAnnoIndex] = annotationcolor;
            m_hPE.PeAnnotation.Line.YAxisType[nAnnoIndex] = type;
            m_hPE.PeAnnotation.Line.YAxisText[nAnnoIndex] = label;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetPointType @                                                                                        ///
        ///     매개변수로 지정한 부분 그래프의 포인트 표시 형태를 설정한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="type"> PointType : 포인트 형태 </param>                                                    ///
        ///=========================================================================================================///
        public void SetPointType(int nSubsetIndex, PointType type)
        {
            m_hPE.PePlot.SubsetPointTypes[nSubsetIndex] = type;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetPointSize @                                                                                        ///
        ///     매개변수로 지정한 부분 그래프의 포인트 크기를 설정한다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="size"> PointSize : 포인트 크기 </param>                                                    ///
        ///=========================================================================================================///
        public void SetPointSize(int nSubsetIndex, PointSize size)
        {
            m_hPE.PePlot.PointSize = size;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetLegendLocation @                                                                                   ///
        ///     그래프에 범례 위치를 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="Location"> LegendLocation : 범례 위치 </param>                                             ///
        ///=========================================================================================================///
        public void SetLegendLocation(LegendLocation Location)
        {
            m_hPE.PeLegend.Location = Location;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetLegend @                                                                                           ///
        ///     그래프에 범례를 설정한다.                                                                           ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex" >int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="strLegend"> string : 그래프 범례 </param>                                                  ///
        ///=========================================================================================================///
        public void SetLegend(int nSubsetIndex, string strLegend)
        {
            m_hPE.PeString.SubsetLabels[nSubsetIndex] = strLegend;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetSubTitle @                                                                                         ///
        ///     그래프의 보조 제목을 설정한다.                                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="strTitle"> string : 보조 제목 </param>                                                     ///
        ///=========================================================================================================///
        public void SetSubTitle(string strTitle)
        {
            m_hPE.PeString.SubTitle = strTitle;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetPointLabel @                                                                                       ///
        ///     매개변수로 지정한 데이터 포인트에 라벨을 설정한다.                                                  /// 
        /// </summary>                                                                                              ///
        /// <param name="index"> int : 데이터 포인트 인덱스 </param>                                                ///
        /// <param name="strLabel"> string : 라벨 </param>                                                          ///
        ///=========================================================================================================///
        public void SetPointLabel(int index, string strLabel)
        {
            m_hPE.PeString.PointLabels[index] = strLabel;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ SetPointColor @                                                                                       ///
        ///     매개변수로 지정한 부분 그래프의 데이터 포인트의 색상을 설정한다.                                    ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="nDataPointIndex"> int : 데이터 포인트 인덱스 </param>                                      ///
        /// <param name="pColor"> Color : 데이터 포인트 색상 </param>                                               ///
        ///=========================================================================================================///
        public void SetPointColor(int nSubsetIndex, int nDataPointIndex, Color pColor)
        {
            m_hPE.PeColor.PointColors[nSubsetIndex, nDataPointIndex] = pColor;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ AddGraphPoint @                                                                                       ///
        ///     매개변수로 지정한 부분 그래프에 데이터 포인트를 추가한다.                                           ///
        /// </summary>                                                                                              ///
        /// <param name="nSubsetIndex"> int : 부분 그래프 인덱스 </param>                                           ///
        /// <param name="nDataPointIndex"> int : 데이터 포인트 인덱스 </param>                                      ///
        /// <param name="y"> float : 데이터 값 </param>                                                             ///
        ///=========================================================================================================///
        public void AddGraphPoint(int nSubsetIndex, int nDataPointIndex, float y)
        {
            if (nDataPointIndex >= m_hPE.PeData.Points)
            {
                int i = 1;

                for (i = 1; i < m_hPE.PeData.Points; i++)
                {
                    m_hPE.PeData.Y[nSubsetIndex, i - 1] = m_hPE.PeData.Y[nSubsetIndex, i];
                }

                m_hPE.PeData.Y[nSubsetIndex, m_hPE.PeData.Points - 1] = y;
            }
            else
            {
                m_hPE.PeData.Y[nSubsetIndex, nDataPointIndex] = y;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ GetXDataArray @                                                                                       ///
        ///     그래프 데이터 버퍼의 X축 좌표 데이터를 반환한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <returns> float[,] : X축 좌표 데이터 </returns>                                                         ///
        ///=========================================================================================================///
        public float[,] GetXDataArray()
        {
            return m_hPE.PeData.X.Copy();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ GetXDataArray @                                                                                       ///
        ///     그래프 데이터 버퍼의 Y축 좌표 데이터를 반환한다.                                                    ///
        /// </summary>                                                                                              ///
        /// <returns> double[,] : Y축 좌표 데이터 </returns>                                                        ///
        ///=========================================================================================================///
        public float[,] GetYDataArray()
        {
            return m_hPE.PeData.Y.Copy();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ ClearGraph @                                                                                          ///
        ///     모든 그래프 버퍼의 데이터를 초기화한다.                                                             ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void ClearGraph()
        {
            m_hPE.PeData.X.Clear();
            m_hPE.PeData.Y.Clear();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ RefreshGraph @                                                                                        ///
        ///     그래프를 다시 그린다.                                                                               ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void RefreshGraph()
        {
            ReDraw(m_hPE);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ SetXAxisLabel @                                                                                       ///
        ///     X축에 라벨을 설정한다.                                                                              ///
        /// </summary>                                                                                              ///
        /// <param name="strLabel"> string : X축 라벨 내용 </param>                                                 ///
        ///=========================================================================================================///
        public void SetXAxisLabel(string strLabel)
        {
            m_hPE.PeString.XAxisLabel = strLabel;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ SetXAxisLabel @                                                                                       ///
        ///     Y축에 라벨을 설정한다.                                                                              ///
        /// </summary>                                                                                              ///
        /// <param name="strLabel"> string : Y축 라벨 내용 </param>                                                 ///
        ///=========================================================================================================///
        public void SetYAxisLabel(string strLabel)
        {
            m_hPE.PeString.YAxisLabel = strLabel;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ SetSize @                                                                                             ///
        ///     그래프 인스턴스의 크기를 변경한다.                                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="theSize"> Size : 그래프 크기 </param>                                                      ///
        ///=========================================================================================================///
        public void SetSize(Size theSize)
        {
            m_hPE.Size = new Size(theSize.Width, theSize.Height - 20);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ SetLocation @                                                                                         ///
        ///     그래프 인스턴스의 위치를 변경한다.                                                                  ///
        /// </summary>                                                                                              ///
        /// <param name="thePoint"> Point : 그래프 위치 </param>                                                    ///
        ///=========================================================================================================///
        public void SetLocation(Point thePoint)
        {
            m_hPE.Location = thePoint;
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ Destroy @                                                                                             ///
        ///     그래프 인스턴스를 종료하고 자원을 회수한다.                                                         ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public void Destroy()
        {
            m_hPE.Dispose();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ ExportToJPG @                                                                                         ///
        ///     그래프를 JPG 포맷의 이미지 파일로 저장한다.                                                         ///
        ///     매개변수를 통해 파일 이름과 이미지의 해상도를 지정할 수 있다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="strFileName"> string : 파일 이름 </param>                                                  ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 파일 저장 여부 </returns>                                                        ///
        ///=========================================================================================================///
        public int ExportToJPG(string strFileName, int width, int height)
        {
            return m_hPE.PeFunction.Image.JpegToFile(width, height, strFileName);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ ExportToBMP @                                                                                         ///
        ///     그래프를 BMP 포맷의 이미지 파일로 저장한다.                                                         ///
        ///     매개변수를 통해 파일 이름과 이미지의 해상도를 지정할 수 있다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="strFileName"> string : 파일 이름 </param>                                                  ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 파일 저장 여부 </returns>                                                        ///
        ///=========================================================================================================///
        public int ExportToBMP(string strFileName, int width, int height)
        {
            return m_hPE.PeFunction.Image.BitmapToFile(width, height, strFileName);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ ExportToPNG @                                                                                         ///
        ///     그래프를 PNG 포맷의 이미지 파일로 저장한다.                                                         ///
        ///     매개변수를 통해 파일 이름과 이미지의 해상도를 지정할 수 있다.                                       ///
        /// </summary>                                                                                              ///
        /// <param name="strFileName"> string : 파일 이름 </param>                                                  ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 파일 저장 여부 </returns>                                                        ///
        ///=========================================================================================================///
        public int ExportToPNG(string strFileName, int width, int height)
        {
            return m_hPE.PeFunction.Image.PngToFile(width, height, strFileName);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ BMPtoClipboard @                                                                                      ///
        ///     그래프를 BMP 포맷의 이미지로 캡쳐하여 클립보드에 복사한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 클립보드 복사 여부 </returns>                                                    ///
        ///=========================================================================================================///
        public int BMPtoClipboard(int width, int height)
        {
            return m_hPE.PeFunction.Image.BitmapToClipboard(width, height);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ JPGtoClipboard @                                                                                      ///
        ///     그래프를 JPG 포맷의 이미지로 캡쳐하여 클립보드에 복사한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 클립보드 복사 여부 </returns>                                                    ///
        ///=========================================================================================================///
        public int JPGtoClipboard(int width, int height)
        {
            return m_hPE.PeFunction.Image.JpegToClipboard(width, height);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ PNGtoClipboard @                                                                                      ///
        ///     그래프를 PNG 포맷의 이미지로 캡쳐하여 클립보드에 복사한다.                                          ///
        /// </summary>                                                                                              ///
        /// <param name="width"> int : 이미지 높이 </param>                                                         ///
        /// <param name="height"> int : 이미지 너비 </param>                                                        ///
        /// <returns> int : 이미지 클립보드 복사 여부 </returns>                                                    ///
        ///=========================================================================================================///
        public int PNGtoClipboard(int width, int height)
        {
            return m_hPE.PeFunction.Image.PngToClipboard(width, height);
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ ReDraw @                                                                                              ///
        ///     매개변수로 넘겨진 그래프 인스턴스의 이미지를 다시 그린다.                                           ///
        ///     크로스 스레드 예외를 회피하기 위한 델리게이트 함수이다.                                             ///
        /// </summary>                                                                                              ///
        /// <param name="pe"> Pesgo : 그래프 인스턴스 </param>                                                      ///
        ///=========================================================================================================///
        private void ReDraw(Pego pe)
        {
            if (pe.InvokeRequired == true)
            {
                pe.Invoke(new Redraw(ReDraw), pe);
            }
            else
            {
                pe.PeFunction.ReinitializeResetImage();
                pe.Refresh();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2015-04-16 ] ///
        /// @ SetVewingStyle @                                                                                      ///
        ///     그래프의 컬러 모드를 설정한다.                                                                      ///
        ///     1(모노) / 2(모노 심볼) / 기본(컬러)                                                                 ///
        /// </summary>                                                                                              ///
        /// <param name="mode"> int : 컬러 모드 </param>                                                            ///
        ///=========================================================================================================///
        public void SetViewingStyle(int mode)
        {
            switch (mode)
            {
                case 1: m_hPE.PeColor.ViewingStyle = ViewingStyle.Mono; break;
                case 2: m_hPE.PeColor.ViewingStyle = ViewingStyle.MonoWithSymbols; break;
                default: m_hPE.PeColor.ViewingStyle = ViewingStyle.Color; break;
            }
        }
        #endregion
    }
    ///=========================================================================== End of Class : MultiSetGraphBar =///
}
