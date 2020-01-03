using ChartFX.WinForms.Gauge;

namespace DH_Facility_Report_Part2
{
    partial class AceControl
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_version = new DevComponents.DotNetBar.LabelX();
            this.m_btn_Init = new DevComponents.DotNetBar.ButtonX();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanel9 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel7 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_btn_TData_Path = new DevComponents.DotNetBar.ButtonX();
            this.m_txb_TuData_Path = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.m_btn_sel_infoSecT = new DevComponents.DotNetBar.ButtonX();
            this.m_txb_path_Section_Tunnel = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.m_btn_Proc_Tunnel = new DevComponents.DotNetBar.ButtonX();
            this.m_btn_sel_formTunn = new DevComponents.DotNetBar.ButtonX();
            this.m_txb_path_TuReport = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.m_btn_sel_infoSecL = new DevComponents.DotNetBar.ButtonX();
            this.m_btn_sel_infoFacT = new DevComponents.DotNetBar.ButtonX();
            this.m_txb_path_Section_Line = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.m_txb_path_TuFac = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_txb_comm_raws = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_txb_comm_logs = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.m_btn_log_clear = new DevComponents.DotNetBar.ButtonX();
            this.switchButton1 = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.timer_status = new System.Windows.Forms.Timer(this.components);
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.groupPanel9.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_version
            // 
            // 
            // 
            // 
            this.label_version.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label_version.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_version.ForeColor = System.Drawing.Color.White;
            this.label_version.Location = new System.Drawing.Point(1284, 4);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(300, 20);
            this.label_version.TabIndex = 20;
            this.label_version.Text = "labelX6";
            this.label_version.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // m_btn_Init
            // 
            this.m_btn_Init.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_Init.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_Init.Location = new System.Drawing.Point(300, 3);
            this.m_btn_Init.Name = "m_btn_Init";
            this.m_btn_Init.Size = new System.Drawing.Size(250, 23);
            this.m_btn_Init.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_Init.TabIndex = 19;
            this.m_btn_Init.Text = "Environment Initiation";
            this.m_btn_Init.Click += new System.EventHandler(this.m_btn_Init_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1582, 704);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.groupPanel9);
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(1582, 678);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 19;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // groupPanel9
            // 
            this.groupPanel9.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel9.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel9.Controls.Add(this.groupPanel7);
            this.groupPanel9.Controls.Add(this.groupPanel6);
            this.groupPanel9.Controls.Add(this.groupPanel5);
            this.groupPanel9.Controls.Add(this.groupPanel4);
            this.groupPanel9.Controls.Add(this.groupPanel1);
            this.groupPanel9.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel9.Location = new System.Drawing.Point(4, 4);
            this.groupPanel9.Name = "groupPanel9";
            this.groupPanel9.Size = new System.Drawing.Size(1574, 670);
            // 
            // 
            // 
            this.groupPanel9.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel9.Style.BackColorGradientAngle = 90;
            this.groupPanel9.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel9.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderBottomWidth = 1;
            this.groupPanel9.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel9.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderLeftWidth = 1;
            this.groupPanel9.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderRightWidth = 1;
            this.groupPanel9.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderTopWidth = 1;
            this.groupPanel9.Style.CornerDiameter = 4;
            this.groupPanel9.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel9.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel9.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel9.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel9.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel9.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel9.TabIndex = 0;
            // 
            // groupPanel7
            // 
            this.groupPanel7.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel7.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel7.Location = new System.Drawing.Point(1259, 3);
            this.groupPanel7.Name = "groupPanel7";
            this.groupPanel7.Size = new System.Drawing.Size(306, 658);
            // 
            // 
            // 
            this.groupPanel7.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel7.Style.BackColorGradientAngle = 90;
            this.groupPanel7.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel7.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderBottomWidth = 1;
            this.groupPanel7.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel7.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderLeftWidth = 1;
            this.groupPanel7.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderRightWidth = 1;
            this.groupPanel7.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderTopWidth = 1;
            this.groupPanel7.Style.CornerDiameter = 4;
            this.groupPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel7.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel7.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel7.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel7.TabIndex = 13;
            this.groupPanel7.Text = "groupPanel7";
            // 
            // groupPanel6
            // 
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel6.Location = new System.Drawing.Point(945, 3);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(306, 658);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
            this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderBottomWidth = 1;
            this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderLeftWidth = 1;
            this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderRightWidth = 1;
            this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderTopWidth = 1;
            this.groupPanel6.Style.CornerDiameter = 4;
            this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel6.TabIndex = 12;
            this.groupPanel6.Text = "groupPanel6";
            // 
            // groupPanel5
            // 
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel5.Location = new System.Drawing.Point(631, 3);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(306, 658);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 11;
            this.groupPanel5.Text = "groupPanel5";
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel4.Location = new System.Drawing.Point(317, 3);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(306, 658);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 10;
            this.groupPanel4.Text = "groupPanel4";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labelX10);
            this.groupPanel1.Controls.Add(this.labelX9);
            this.groupPanel1.Controls.Add(this.labelX8);
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Controls.Add(this.m_btn_TData_Path);
            this.groupPanel1.Controls.Add(this.m_txb_TuData_Path);
            this.groupPanel1.Controls.Add(this.labelX7);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.m_btn_sel_infoSecT);
            this.groupPanel1.Controls.Add(this.m_txb_path_Section_Tunnel);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.m_btn_Proc_Tunnel);
            this.groupPanel1.Controls.Add(this.m_btn_sel_formTunn);
            this.groupPanel1.Controls.Add(this.m_txb_path_TuReport);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.m_btn_sel_infoSecL);
            this.groupPanel1.Controls.Add(this.m_btn_sel_infoFacT);
            this.groupPanel1.Controls.Add(this.m_txb_path_Section_Line);
            this.groupPanel1.Controls.Add(this.m_txb_path_TuFac);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(3, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(306, 658);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 9;
            this.groupPanel1.Text = "터널";
            // 
            // m_btn_TData_Path
            // 
            this.m_btn_TData_Path.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_TData_Path.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_TData_Path.Location = new System.Drawing.Point(222, 385);
            this.m_btn_TData_Path.Name = "m_btn_TData_Path";
            this.m_btn_TData_Path.Size = new System.Drawing.Size(75, 23);
            this.m_btn_TData_Path.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_TData_Path.TabIndex = 17;
            this.m_btn_TData_Path.Text = "경로 선택";
            this.m_btn_TData_Path.Click += new System.EventHandler(this.m_btn_Tunnel_Button_Click);
            // 
            // m_txb_TuData_Path
            // 
            // 
            // 
            // 
            this.m_txb_TuData_Path.Border.Class = "TextBoxBorder";
            this.m_txb_TuData_Path.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_TuData_Path.Location = new System.Drawing.Point(3, 414);
            this.m_txb_TuData_Path.Name = "m_txb_TuData_Path";
            this.m_txb_TuData_Path.PreventEnterBeep = true;
            this.m_txb_TuData_Path.Size = new System.Drawing.Size(294, 21);
            this.m_txb_TuData_Path.TabIndex = 16;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(3, 385);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(213, 23);
            this.labelX7.TabIndex = 15;
            this.labelX7.Text = "데이터 파일 경로";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(3, 50);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(213, 23);
            this.labelX6.TabIndex = 14;
            this.labelX6.Text = "1. 공통";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(3, 145);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(213, 23);
            this.labelX5.TabIndex = 13;
            this.labelX5.Text = "    a. 본선 라이닝";
            // 
            // m_btn_sel_infoSecT
            // 
            this.m_btn_sel_infoSecT.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_sel_infoSecT.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_sel_infoSecT.Location = new System.Drawing.Point(222, 201);
            this.m_btn_sel_infoSecT.Name = "m_btn_sel_infoSecT";
            this.m_btn_sel_infoSecT.Size = new System.Drawing.Size(75, 23);
            this.m_btn_sel_infoSecT.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_sel_infoSecT.TabIndex = 12;
            this.m_btn_sel_infoSecT.Text = "파일 선택";
            this.m_btn_sel_infoSecT.Click += new System.EventHandler(this.m_btn_Tunnel_Button_Click);
            // 
            // m_txb_path_Section_Tunnel
            // 
            // 
            // 
            // 
            this.m_txb_path_Section_Tunnel.Border.Class = "TextBoxBorder";
            this.m_txb_path_Section_Tunnel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_path_Section_Tunnel.Location = new System.Drawing.Point(3, 230);
            this.m_txb_path_Section_Tunnel.Name = "m_txb_path_Section_Tunnel";
            this.m_txb_path_Section_Tunnel.PreventEnterBeep = true;
            this.m_txb_path_Section_Tunnel.Size = new System.Drawing.Size(294, 21);
            this.m_txb_path_Section_Tunnel.TabIndex = 11;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(3, 201);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(213, 23);
            this.labelX4.TabIndex = 10;
            this.labelX4.Text = "    b. 개착터널";
            // 
            // m_btn_Proc_Tunnel
            // 
            this.m_btn_Proc_Tunnel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_Proc_Tunnel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_Proc_Tunnel.Location = new System.Drawing.Point(3, 581);
            this.m_btn_Proc_Tunnel.Name = "m_btn_Proc_Tunnel";
            this.m_btn_Proc_Tunnel.Size = new System.Drawing.Size(294, 50);
            this.m_btn_Proc_Tunnel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_Proc_Tunnel.TabIndex = 9;
            this.m_btn_Proc_Tunnel.Text = "Data-Tunnel Process";
            this.m_btn_Proc_Tunnel.Click += new System.EventHandler(this.m_btn_Tunnel_Button_Click);
            // 
            // m_btn_sel_formTunn
            // 
            this.m_btn_sel_formTunn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_sel_formTunn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_sel_formTunn.Location = new System.Drawing.Point(222, 287);
            this.m_btn_sel_formTunn.Name = "m_btn_sel_formTunn";
            this.m_btn_sel_formTunn.Size = new System.Drawing.Size(75, 23);
            this.m_btn_sel_formTunn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_sel_formTunn.TabIndex = 8;
            this.m_btn_sel_formTunn.Text = "파일 선택";
            this.m_btn_sel_formTunn.Click += new System.EventHandler(this.m_btn_Tunnel_Button_Click);
            // 
            // m_txb_path_TuReport
            // 
            // 
            // 
            // 
            this.m_txb_path_TuReport.Border.Class = "TextBoxBorder";
            this.m_txb_path_TuReport.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_path_TuReport.Location = new System.Drawing.Point(3, 316);
            this.m_txb_path_TuReport.Name = "m_txb_path_TuReport";
            this.m_txb_path_TuReport.PreventEnterBeep = true;
            this.m_txb_path_TuReport.Size = new System.Drawing.Size(294, 21);
            this.m_txb_path_TuReport.TabIndex = 7;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(3, 287);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(213, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "3. 레포트 경로";
            // 
            // m_btn_sel_infoSecL
            // 
            this.m_btn_sel_infoSecL.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_sel_infoSecL.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_sel_infoSecL.Location = new System.Drawing.Point(222, 145);
            this.m_btn_sel_infoSecL.Name = "m_btn_sel_infoSecL";
            this.m_btn_sel_infoSecL.Size = new System.Drawing.Size(75, 23);
            this.m_btn_sel_infoSecL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_sel_infoSecL.TabIndex = 5;
            this.m_btn_sel_infoSecL.Text = "파일 선택";
            this.m_btn_sel_infoSecL.Click += new System.EventHandler(this.m_btn_Tunnel_Button_Click);
            // 
            // m_btn_sel_infoFacT
            // 
            this.m_btn_sel_infoFacT.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_sel_infoFacT.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_sel_infoFacT.Location = new System.Drawing.Point(222, 50);
            this.m_btn_sel_infoFacT.Name = "m_btn_sel_infoFacT";
            this.m_btn_sel_infoFacT.Size = new System.Drawing.Size(75, 23);
            this.m_btn_sel_infoFacT.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_sel_infoFacT.TabIndex = 4;
            this.m_btn_sel_infoFacT.Text = "파일 선택";
            this.m_btn_sel_infoFacT.Click += new System.EventHandler(this.m_btn_Tunnel_Button_Click);
            // 
            // m_txb_path_Section_Line
            // 
            // 
            // 
            // 
            this.m_txb_path_Section_Line.Border.Class = "TextBoxBorder";
            this.m_txb_path_Section_Line.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_path_Section_Line.Location = new System.Drawing.Point(3, 174);
            this.m_txb_path_Section_Line.Name = "m_txb_path_Section_Line";
            this.m_txb_path_Section_Line.PreventEnterBeep = true;
            this.m_txb_path_Section_Line.Size = new System.Drawing.Size(294, 21);
            this.m_txb_path_Section_Line.TabIndex = 3;
            // 
            // m_txb_path_TuFac
            // 
            // 
            // 
            // 
            this.m_txb_path_TuFac.Border.Class = "TextBoxBorder";
            this.m_txb_path_TuFac.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_path_TuFac.Location = new System.Drawing.Point(3, 79);
            this.m_txb_path_TuFac.Name = "m_txb_path_TuFac";
            this.m_txb_path_TuFac.PreventEnterBeep = true;
            this.m_txb_path_TuFac.Size = new System.Drawing.Size(294, 21);
            this.m_txb_path_TuFac.TabIndex = 2;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 116);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(213, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "2. 섹션 정보";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(213, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "@ 상세제원";
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "Setup";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.groupPanel3);
            this.tabControlPanel1.Controls.Add(this.groupPanel2);
            this.tabControlPanel1.Controls.Add(this.m_btn_log_clear);
            this.tabControlPanel1.Controls.Add(this.switchButton1);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(1582, 678);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 23;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.m_txb_comm_raws);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(794, 65);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(647, 578);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 12;
            this.groupPanel3.Text = "Raw Data";
            // 
            // m_txb_comm_raws
            // 
            // 
            // 
            // 
            this.m_txb_comm_raws.Border.Class = "TextBoxBorder";
            this.m_txb_comm_raws.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_comm_raws.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txb_comm_raws.Location = new System.Drawing.Point(3, 3);
            this.m_txb_comm_raws.Multiline = true;
            this.m_txb_comm_raws.Name = "m_txb_comm_raws";
            this.m_txb_comm_raws.PreventEnterBeep = true;
            this.m_txb_comm_raws.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txb_comm_raws.Size = new System.Drawing.Size(635, 550);
            this.m_txb_comm_raws.TabIndex = 9;
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.m_txb_comm_logs);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(141, 65);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(647, 578);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 11;
            this.groupPanel2.Text = "Communication Logs";
            // 
            // m_txb_comm_logs
            // 
            // 
            // 
            // 
            this.m_txb_comm_logs.Border.Class = "TextBoxBorder";
            this.m_txb_comm_logs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_comm_logs.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txb_comm_logs.Location = new System.Drawing.Point(3, 3);
            this.m_txb_comm_logs.Multiline = true;
            this.m_txb_comm_logs.Name = "m_txb_comm_logs";
            this.m_txb_comm_logs.PreventEnterBeep = true;
            this.m_txb_comm_logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txb_comm_logs.Size = new System.Drawing.Size(635, 550);
            this.m_txb_comm_logs.TabIndex = 7;
            // 
            // m_btn_log_clear
            // 
            this.m_btn_log_clear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_log_clear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_log_clear.Location = new System.Drawing.Point(1366, 36);
            this.m_btn_log_clear.Name = "m_btn_log_clear";
            this.m_btn_log_clear.Size = new System.Drawing.Size(75, 23);
            this.m_btn_log_clear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_log_clear.TabIndex = 10;
            this.m_btn_log_clear.Text = "Clear";
            this.m_btn_log_clear.Click += new System.EventHandler(this.m_btn_log_clear_Click);
            // 
            // switchButton1
            // 
            // 
            // 
            // 
            this.switchButton1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton1.Location = new System.Drawing.Point(141, 36);
            this.switchButton1.Name = "switchButton1";
            this.switchButton1.Size = new System.Drawing.Size(75, 23);
            this.switchButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton1.TabIndex = 8;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "Comm Log";
            // 
            // timer_status
            // 
            this.timer_status.Enabled = true;
            this.timer_status.Interval = 1000;
            this.timer_status.Tick += new System.EventHandler(this.timer_status_Tick);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(222, 465);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 18;
            this.buttonX1.Text = "buttonX1";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(3, 523);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(294, 23);
            this.labelX8.TabIndex = 19;
            this.labelX8.Text = "labelX8";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(3, 552);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(294, 23);
            this.labelX9.TabIndex = 20;
            this.labelX9.Text = "labelX9";
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(3, 494);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(294, 23);
            this.labelX10.TabIndex = 21;
            this.labelX10.Text = "labelX10";
            // 
            // AceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.m_btn_Init);
            this.Controls.Add(this.tabControl1);
            this.Name = "AceControl";
            this.Size = new System.Drawing.Size(1588, 710);
            this.Load += new System.EventHandler(this.AceControl_Load);
            this.VisibleChanged += new System.EventHandler(this.AceControl_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.groupPanel9.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX label_version;
        private DevComponents.DotNetBar.ButtonX m_btn_Init;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private ChartFX.WinForms.Gauge.DigitalPanel digitalPanel1;
        private System.Windows.Forms.Timer timer_status;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel9;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.ButtonX m_btn_log_clear;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_comm_raws;
        private DevComponents.DotNetBar.Controls.SwitchButton switchButton1;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_comm_logs;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX m_btn_sel_infoSecL;
        private DevComponents.DotNetBar.ButtonX m_btn_sel_infoFacT;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_path_Section_Line;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_path_TuFac;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX m_btn_sel_formTunn;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_path_TuReport;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel7;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel6;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.ButtonX m_btn_Proc_Tunnel;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ButtonX m_btn_sel_infoSecT;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_path_Section_Tunnel;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX m_btn_TData_Path;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_TuData_Path;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX10;
    }
}
