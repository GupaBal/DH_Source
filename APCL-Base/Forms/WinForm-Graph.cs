using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gigasoft.ProEssentials.Enums;

namespace Apros_Class_Library_Base
{
    ///=============================================================================================================///
    /// <summary>                                                                         [ Ver 1.00 / 2014-04-14 ] ///
    /// ▷ WinForm_Graph : Form ◁                                                                                  ///
    ///     그래프 표시를 위한 폼으로 3가지 형태(선형, 막대, 3D)의 그래프를 지원한다.                               ///
    ///                                                                                                             ///
    /// [ Ver 1.00 / 2014-04-14 ]                                                                                   ///
    ///     ▶ 초기버전                                                                                             ///
    /// </summary>                                                                                                  ///
    ///=============================================================================================================///
    public partial class WinForm_Graph : Form
    {
        #region [ # Defines & Variables ]
        private readonly string ErrorPath = CommonVariables.ErrorPath;
        private readonly string ErrorLogName = CommonVariables.ErrorLogName;

        private string Message = string.Empty;
        private StringBuilder MessageBuilder;

        //private readonly int Defalut_Width = 600;
        //private readonly int Defalut_Height = 300;

        private string graph_info = string.Empty;
        private CommonVariables.GraphKind Graph = CommonVariables.GraphKind.Line;
        private MultiSetGraph MSG = null;
        private MultiSetGraphBar MSGB = null;

        private bool UseNullData = false;
        private int SubSets = 1;
        private int DataPoints = 1000;

        private delegate void setborderstyle(FormBorderStyle fbs);
        private delegate void setformsize(Size size);
        #endregion

        #region [ # Ver 1.00 ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ WinForm_Graph @                                                                                       ///
        ///     기본 생성자로 컨트롤들을 초기화한다.                                                                ///
        ///     별도의 그래프 설정이 없으면 라인 그래프 형태로 생성된다.                                            ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        public WinForm_Graph()
        {
            InitializeComponent();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-09 ] ///
        /// @ WinForm_Graph @                                                                                       ///
        ///     그래프 종류를 매개변수로 가지는 생성자로 생성할 그래프 종류를 설정한다.                             ///
        /// </summary>                                                                                              ///
        /// <param name="gk"> GraphKind : 그래프 종류 </param>                                                      ///
        /// <param name="usenull"> bool : Null Data 사용 여부 </param>                                              ///
        /// <param name="subsets"> int : 부분 그래프 개수 </param>                                                  ///
        /// <param name="datapoints"> int : 그래프 데이터 좌표 수 </param>                                          ///
        ///=========================================================================================================///
        public WinForm_Graph(CommonVariables.GraphKind gk, bool usenull, int subsets, int datapoints)
        {
            InitializeComponent();

            Graph = gk;
            UseNullData = usenull;
            SubSets = subsets;
            DataPoints = datapoints;
        }
        
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ WinForm_Graph_Load @                                                                                  ///
        ///     그래프 형태에 맞는 초기화 함수를 호출한다.                                                          ///  
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void WinForm_Graph_Load(object sender, EventArgs e)
        {
            switch (Graph)
            {
                case CommonVariables.GraphKind.Bar : InitMultiSetGraphBar(); break;
                default : InitMultiSetGraph(); break;
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-11 ] ///
        /// @ InitMultiSetGraph @                                                                                   ///
        ///     선형 그래프를 생성하고 초기화한다.                                                                  ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void InitMultiSetGraph()
        {
            MSG = new MultiSetGraph();
            MSG.CreateGraph(panel_graph, SGraphPlottingMethod.PointsPlusLine, UseNullData);
            MSG.SubsetCount = SubSets;
            MSG.DataPointCount = DataPoints;

            for (int i = 0; i < MSG.SubsetCount; i++)
            {
                MSG.SetSubsetGraph(i, Graph_Manager.GraphColors[i], "");
            }

            MSG.RefreshGraph();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-11 ] ///
        /// @ InitMultiSetGraphBar @                                                                                ///
        ///     막대 그래프를 생성하고 초기화한다.                                                                  ///
        /// </summary>                                                                                              ///
        ///=========================================================================================================///
        private void InitMultiSetGraphBar()
        {
            MSGB = new MultiSetGraphBar();
            MSGB.CreateGraph(panel_graph);
            MSGB.SubsetCount = SubSets;
            MSGB.DataPointCount = DataPoints;

            for (int i = 0; i < MSGB.SubsetCount; i++)
            {
                MSGB.SetSubsetGraph(i, Graph_Manager.GraphColors[i], "");
            }

            MSGB.RefreshGraph();
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-11 ] ///
        /// @ SetBorderStyle @                                                                                      ///
        ///     폼의 외곽 경계 스타일을 매개변수로 지정한 스타일로 설정한다.                                        ///
        /// </summary>                                                                                              ///
        /// <param name="style"> FormBorderStyle : 폼 경계 스타일 </param>                                          ///
        ///=========================================================================================================///
        public void SetBorderStyle(FormBorderStyle style)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    this.Invoke(new setborderstyle(SetBorderStyle), style);
                }
                else
                {
                    this.FormBorderStyle = style;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetBorderStyle ]");
                MessageBuilder.AppendLine("# Style    : " + style.ToString());
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-11 ] ///
        /// @ SetFormSize @                                                                                         ///
        ///     폼의 크기를 매개변수로 지정한 크기로 설정한다.                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="size"> Size : 폼 크기 </param>                                                             ///
        ///=========================================================================================================///
        public void SetFormSize(Size size)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    this.Invoke(new setformsize(SetFormSize), size);
                }
                else
                {
                    this.Width = size.Width;
                    this.Height = size.Height;
                }
            }
            catch (Exception e)
            {
                MessageBuilder = new StringBuilder();
                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine("[ Function : SetFormSize ]");

                if (size.IsEmpty == true)
                {
                    MessageBuilder.AppendLine("# Size     : EMPTY");
                }
                else
                {
                    MessageBuilder.AppendLine("# Size     : " + size.ToString());
                }

                MessageBuilder.AppendLine();
                MessageBuilder.AppendLine(e.Message);
                MessageBuilder.AppendLine();

                Message = MessageBuilder.ToString();

                FileManager.LogWriter(Message, ErrorPath, ErrorLogName, true, true, true, true, true);
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ m_btn_clear_Click @                                                                                   ///
        ///     그래프의 좌표 데이터를 초기화하고 다시 그린다.                                                      ///
        /// </summary>                                                                                              ///
        /// <param name="sender"> object : 이벤트 발생 객체 </param>                                                ///
        /// <param name="e"> EventArgs : 이벤트 관련 정보 </param>                                                  ///
        ///=========================================================================================================///
        private void m_btn_clear_Click(object sender, EventArgs e)
        {
            if (MSG != null)
            {
                MSG.ClearGraph();
                MSG.RefreshGraph();
            }

            if (MSGB != null)
            {
                MSGB.ClearGraph();
                MSGB.RefreshGraph();
            }
        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ ChangeSubsetColor @                                                                                   ///
        ///     지정한 그래프의 색상을 변경한다.                                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="idx"> int : 부분 그래프 인덱스 </param>                                                    ///
        /// <param name="col"> Color : 그래프 색상 </param>                                                         ///
        ///=========================================================================================================///
        public void ChangeSubsetColor(int idx, Color col)
        {
            if (MSG != null)
            {
                MSG.ChangeSubsetGraph(idx, col);
            }
            else if (MSGB != null)
            {
                //MSGB.ChangeBackgroudColor
            }
        }
        #endregion

        #region [ # Working... ]
        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-14 ] ///
        /// @ ChangeSubsetLabel @                                                                                   ///
        ///     지정한 그래프의 라벨을 변경한다.                                                                    ///
        /// </summary>                                                                                              ///
        /// <param name="idx"> int : 부분 그래프 인덱스 </param>                                                    ///
        /// <param name="label"> string : 그래프 라벨 </param>                                                      ///
        ///=========================================================================================================///
        public void ChangeSubsetLabel(int idx, string label)
        {
            if (MSG != null)
            {
                MSG.ChangeSubsetGraph(idx, label);
            }
            else if (MSGB != null)
            {

            }
        }

        ///=========================================================================================================///
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vluae"></param>
        ///=========================================================================================================///
        public void SetData(float vluae)
        {

        }

        ///=========================================================================================================///
        /// <summary>                                                                     [ Ver 1.00 / 2014-04-07 ] ///
        /// @ SetData @                                                                                             ///
        ///     
        /// </summary>                                                                                              ///
        /// <param name="values">float[] : 그래프에 표시할 값</param>                                                ///
        ///=========================================================================================================///
        public void SetData(float[] values)
        {
            
        }
        #endregion
    }
    ///============================================================================== End of Class : WinForm_Graph =///
}
