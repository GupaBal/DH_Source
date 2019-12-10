using ChartFX.WinForms.Gauge;

namespace Basic_Template
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
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_txb_comm_raws = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_txb_comm_logs = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.m_btn_log_clear = new DevComponents.DotNetBar.ButtonX();
            this.switchButton1 = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanel9 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel_comm = new System.Windows.Forms.Panel();
            this.widjet_Setting_Comm1 = new Apros_Class_Library_Base.Widjet_Setting_Comm();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.timer_status = new System.Windows.Forms.Timer(this.components);
            this.timer_getter = new System.Windows.Forms.Timer(this.components);
            this.timer_writer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.groupPanel9.SuspendLayout();
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
            this.groupPanel9.Controls.Add(this.panel_comm);
            this.groupPanel9.Controls.Add(this.widjet_Setting_Comm1);
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
            // panel_comm
            // 
            this.panel_comm.BackColor = System.Drawing.Color.Transparent;
            this.panel_comm.BackgroundImage = global::Basic_Template.Properties.Resources.offline_icon;
            this.panel_comm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_comm.Location = new System.Drawing.Point(6, 495);
            this.panel_comm.Name = "panel_comm";
            this.panel_comm.Size = new System.Drawing.Size(100, 100);
            this.panel_comm.TabIndex = 8;
            // 
            // widjet_Setting_Comm1
            // 
            this.widjet_Setting_Comm1.BackColor = System.Drawing.Color.Transparent;
            this.widjet_Setting_Comm1.Enabled = false;
            this.widjet_Setting_Comm1.Location = new System.Drawing.Point(3, 3);
            this.widjet_Setting_Comm1.Name = "widjet_Setting_Comm1";
            this.widjet_Setting_Comm1.Size = new System.Drawing.Size(250, 426);
            this.widjet_Setting_Comm1.TabIndex = 0;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "Setup";
            // 
            // timer_status
            // 
            this.timer_status.Enabled = true;
            this.timer_status.Interval = 1000;
            this.timer_status.Tick += new System.EventHandler(this.timer_status_Tick);
            // 
            // timer_getter
            // 
            this.timer_getter.Interval = 1000;
            this.timer_getter.Tick += new System.EventHandler(this.timer_getter_Tick);
            // 
            // timer_writer
            // 
            this.timer_writer.Enabled = true;
            this.timer_writer.Interval = 1000;
            this.timer_writer.Tick += new System.EventHandler(this.timer_writer_Tick);
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
            this.tabControlPanel1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.groupPanel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX label_version;
        private DevComponents.DotNetBar.ButtonX m_btn_Init;
        private Apros_Class_Library_Base.Widjet_Setting_Comm widjet_Setting_Comm1;
        private System.Windows.Forms.Panel panel_comm;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private ChartFX.WinForms.Gauge.DigitalPanel digitalPanel1;
        private System.Windows.Forms.Timer timer_status;
        private System.Windows.Forms.Timer timer_getter;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel9;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private System.Windows.Forms.Timer timer_writer;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.ButtonX m_btn_log_clear;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_comm_raws;
        private DevComponents.DotNetBar.Controls.SwitchButton switchButton1;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_comm_logs;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
    }
}
