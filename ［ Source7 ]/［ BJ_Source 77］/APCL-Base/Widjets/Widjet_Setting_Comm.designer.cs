namespace Apros_Class_Library_Base
{
    partial class Widjet_Setting_Comm
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
            this.m_gp_commsetting = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_btn_refresh = new DevComponents.DotNetBar.ButtonX();
            this.m_btn_conn = new DevComponents.DotNetBar.ButtonX();
            this.m_gp_serial = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_cb_flowtype = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.m_cb_stopbits = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.m_cb_parity = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem11 = new DevComponents.Editors.ComboItem();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.comboItem14 = new DevComponents.Editors.ComboItem();
            this.comboItem15 = new DevComponents.Editors.ComboItem();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.m_cb_baudrate = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.m_cb_databits = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.m_cb_portname = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.m_rbtn_serial = new System.Windows.Forms.RadioButton();
            this.m_gp_tcp = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_rbtn_tcp_client = new System.Windows.Forms.RadioButton();
            this.m_rbtn_tcp_server = new System.Windows.Forms.RadioButton();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.m_txb_portnum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ipAddressInput1 = new DevComponents.Editors.IpAddressInput();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.m_rbtn_tcp = new System.Windows.Forms.RadioButton();
            this.timer_grabber = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.m_gp_commsetting.SuspendLayout();
            this.m_gp_serial.SuspendLayout();
            this.m_gp_tcp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_gp_commsetting
            // 
            this.m_gp_commsetting.BackColor = System.Drawing.Color.Transparent;
            this.m_gp_commsetting.CanvasColor = System.Drawing.SystemColors.Control;
            this.m_gp_commsetting.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.m_gp_commsetting.Controls.Add(this.m_btn_refresh);
            this.m_gp_commsetting.Controls.Add(this.m_btn_conn);
            this.m_gp_commsetting.Controls.Add(this.m_gp_serial);
            this.m_gp_commsetting.Controls.Add(this.m_rbtn_serial);
            this.m_gp_commsetting.Controls.Add(this.m_gp_tcp);
            this.m_gp_commsetting.Controls.Add(this.m_rbtn_tcp);
            this.m_gp_commsetting.DisabledBackColor = System.Drawing.Color.Empty;
            this.m_gp_commsetting.Location = new System.Drawing.Point(0, 0);
            this.m_gp_commsetting.Name = "m_gp_commsetting";
            this.m_gp_commsetting.Size = new System.Drawing.Size(250, 426);
            // 
            // 
            // 
            this.m_gp_commsetting.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.m_gp_commsetting.Style.BackColorGradientAngle = 90;
            this.m_gp_commsetting.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.m_gp_commsetting.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_commsetting.Style.BorderBottomWidth = 1;
            this.m_gp_commsetting.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.m_gp_commsetting.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_commsetting.Style.BorderLeftWidth = 1;
            this.m_gp_commsetting.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_commsetting.Style.BorderRightWidth = 1;
            this.m_gp_commsetting.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_commsetting.Style.BorderTopWidth = 1;
            this.m_gp_commsetting.Style.CornerDiameter = 4;
            this.m_gp_commsetting.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.m_gp_commsetting.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.m_gp_commsetting.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.m_gp_commsetting.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.m_gp_commsetting.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_gp_commsetting.TabIndex = 6;
            this.m_gp_commsetting.Text = "Comm Setting";
            // 
            // m_btn_refresh
            // 
            this.m_btn_refresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_refresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_refresh.Location = new System.Drawing.Point(213, 3);
            this.m_btn_refresh.Name = "m_btn_refresh";
            this.m_btn_refresh.Size = new System.Drawing.Size(28, 28);
            this.m_btn_refresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_refresh.Symbol = "";
            this.m_btn_refresh.TabIndex = 6;
            this.m_btn_refresh.Click += new System.EventHandler(this.m_btn_refresh_Click);
            // 
            // m_btn_conn
            // 
            this.m_btn_conn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_conn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_conn.Location = new System.Drawing.Point(3, 351);
            this.m_btn_conn.Name = "m_btn_conn";
            this.m_btn_conn.Size = new System.Drawing.Size(238, 50);
            this.m_btn_conn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_conn.TabIndex = 5;
            this.m_btn_conn.Text = "Connect";
            this.m_btn_conn.Click += new System.EventHandler(this.m_btn_conn_Click);
            // 
            // m_gp_serial
            // 
            this.m_gp_serial.CanvasColor = System.Drawing.SystemColors.Control;
            this.m_gp_serial.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.m_gp_serial.Controls.Add(this.m_cb_flowtype);
            this.m_gp_serial.Controls.Add(this.labelX1);
            this.m_gp_serial.Controls.Add(this.labelX5);
            this.m_gp_serial.Controls.Add(this.m_cb_stopbits);
            this.m_gp_serial.Controls.Add(this.labelX3);
            this.m_gp_serial.Controls.Add(this.labelX2);
            this.m_gp_serial.Controls.Add(this.m_cb_parity);
            this.m_gp_serial.Controls.Add(this.labelX4);
            this.m_gp_serial.Controls.Add(this.m_cb_baudrate);
            this.m_gp_serial.Controls.Add(this.m_cb_databits);
            this.m_gp_serial.Controls.Add(this.labelX6);
            this.m_gp_serial.Controls.Add(this.m_cb_portname);
            this.m_gp_serial.DisabledBackColor = System.Drawing.Color.Empty;
            this.m_gp_serial.Location = new System.Drawing.Point(3, 37);
            this.m_gp_serial.Name = "m_gp_serial";
            this.m_gp_serial.Size = new System.Drawing.Size(238, 180);
            // 
            // 
            // 
            this.m_gp_serial.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.m_gp_serial.Style.BackColorGradientAngle = 90;
            this.m_gp_serial.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.m_gp_serial.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_serial.Style.BorderBottomWidth = 1;
            this.m_gp_serial.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.m_gp_serial.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_serial.Style.BorderLeftWidth = 1;
            this.m_gp_serial.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_serial.Style.BorderRightWidth = 1;
            this.m_gp_serial.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_serial.Style.BorderTopWidth = 1;
            this.m_gp_serial.Style.CornerDiameter = 4;
            this.m_gp_serial.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.m_gp_serial.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.m_gp_serial.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.m_gp_serial.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.m_gp_serial.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.m_gp_serial.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_gp_serial.TabIndex = 4;
            // 
            // m_cb_flowtype
            // 
            this.m_cb_flowtype.DisplayMember = "Text";
            this.m_cb_flowtype.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.m_cb_flowtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_flowtype.FocusHighlightEnabled = true;
            this.m_cb_flowtype.FormattingEnabled = true;
            this.m_cb_flowtype.ItemHeight = 15;
            this.m_cb_flowtype.Location = new System.Drawing.Point(96, 144);
            this.m_cb_flowtype.Name = "m_cb_flowtype";
            this.m_cb_flowtype.Size = new System.Drawing.Size(121, 21);
            this.m_cb_flowtype.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_cb_flowtype.TabIndex = 11;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX1.Location = new System.Drawing.Point(15, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Port";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX5.Location = new System.Drawing.Point(15, 117);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 21);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "Stop Bits";
            // 
            // m_cb_stopbits
            // 
            this.m_cb_stopbits.DisplayMember = "Text";
            this.m_cb_stopbits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.m_cb_stopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_stopbits.FocusHighlightEnabled = true;
            this.m_cb_stopbits.FormattingEnabled = true;
            this.m_cb_stopbits.ItemHeight = 15;
            this.m_cb_stopbits.Location = new System.Drawing.Point(96, 117);
            this.m_cb_stopbits.Name = "m_cb_stopbits";
            this.m_cb_stopbits.Size = new System.Drawing.Size(121, 21);
            this.m_cb_stopbits.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_cb_stopbits.TabIndex = 10;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX3.Location = new System.Drawing.Point(15, 63);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 21);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Data Bits";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX2.Location = new System.Drawing.Point(15, 36);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 21);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "Baudrate";
            // 
            // m_cb_parity
            // 
            this.m_cb_parity.DisplayMember = "Text";
            this.m_cb_parity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.m_cb_parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_parity.FocusHighlightEnabled = true;
            this.m_cb_parity.FormattingEnabled = true;
            this.m_cb_parity.ItemHeight = 15;
            this.m_cb_parity.Items.AddRange(new object[] {
            this.comboItem11,
            this.comboItem12,
            this.comboItem13,
            this.comboItem14,
            this.comboItem15});
            this.m_cb_parity.Location = new System.Drawing.Point(96, 90);
            this.m_cb_parity.Name = "m_cb_parity";
            this.m_cb_parity.Size = new System.Drawing.Size(121, 21);
            this.m_cb_parity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_cb_parity.TabIndex = 9;
            // 
            // comboItem11
            // 
            this.comboItem11.Text = "None";
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "Even";
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "Odd";
            // 
            // comboItem14
            // 
            this.comboItem14.Text = "Mark";
            // 
            // comboItem15
            // 
            this.comboItem15.Text = "Space";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX4.Location = new System.Drawing.Point(15, 90);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 21);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "Parity";
            // 
            // m_cb_baudrate
            // 
            this.m_cb_baudrate.DisplayMember = "Text";
            this.m_cb_baudrate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.m_cb_baudrate.FocusHighlightEnabled = true;
            this.m_cb_baudrate.FormattingEnabled = true;
            this.m_cb_baudrate.ItemHeight = 15;
            this.m_cb_baudrate.Location = new System.Drawing.Point(96, 36);
            this.m_cb_baudrate.Name = "m_cb_baudrate";
            this.m_cb_baudrate.Size = new System.Drawing.Size(121, 21);
            this.m_cb_baudrate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_cb_baudrate.TabIndex = 1;
            // 
            // m_cb_databits
            // 
            this.m_cb_databits.DisplayMember = "Text";
            this.m_cb_databits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.m_cb_databits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_databits.FocusHighlightEnabled = true;
            this.m_cb_databits.FormattingEnabled = true;
            this.m_cb_databits.ItemHeight = 15;
            this.m_cb_databits.Items.AddRange(new object[] {
            this.comboItem7,
            this.comboItem8,
            this.comboItem9,
            this.comboItem10});
            this.m_cb_databits.Location = new System.Drawing.Point(96, 63);
            this.m_cb_databits.Name = "m_cb_databits";
            this.m_cb_databits.Size = new System.Drawing.Size(121, 21);
            this.m_cb_databits.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_cb_databits.TabIndex = 8;
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "5";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "6";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "7";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "8";
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX6.Location = new System.Drawing.Point(15, 144);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 21);
            this.labelX6.TabIndex = 7;
            this.labelX6.Text = "Flow Type";
            // 
            // m_cb_portname
            // 
            this.m_cb_portname.DisplayMember = "Text";
            this.m_cb_portname.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.m_cb_portname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_portname.FocusHighlightEnabled = true;
            this.m_cb_portname.FormattingEnabled = true;
            this.m_cb_portname.ItemHeight = 15;
            this.m_cb_portname.Location = new System.Drawing.Point(96, 9);
            this.m_cb_portname.Name = "m_cb_portname";
            this.m_cb_portname.Size = new System.Drawing.Size(121, 21);
            this.m_cb_portname.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_cb_portname.TabIndex = 2;
            // 
            // m_rbtn_serial
            // 
            this.m_rbtn_serial.AutoSize = true;
            this.m_rbtn_serial.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtn_serial.Checked = true;
            this.m_rbtn_serial.Location = new System.Drawing.Point(3, 3);
            this.m_rbtn_serial.Name = "m_rbtn_serial";
            this.m_rbtn_serial.Size = new System.Drawing.Size(55, 16);
            this.m_rbtn_serial.TabIndex = 1;
            this.m_rbtn_serial.TabStop = true;
            this.m_rbtn_serial.Text = "Serial";
            this.m_rbtn_serial.UseVisualStyleBackColor = false;
            this.m_rbtn_serial.CheckedChanged += new System.EventHandler(this.m_rbtn_CheckedChanged);
            // 
            // m_gp_tcp
            // 
            this.m_gp_tcp.BackColor = System.Drawing.Color.Transparent;
            this.m_gp_tcp.CanvasColor = System.Drawing.SystemColors.Control;
            this.m_gp_tcp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.m_gp_tcp.Controls.Add(this.m_rbtn_tcp_client);
            this.m_gp_tcp.Controls.Add(this.m_rbtn_tcp_server);
            this.m_gp_tcp.Controls.Add(this.labelX9);
            this.m_gp_tcp.Controls.Add(this.m_txb_portnum);
            this.m_gp_tcp.Controls.Add(this.ipAddressInput1);
            this.m_gp_tcp.Controls.Add(this.labelX8);
            this.m_gp_tcp.Controls.Add(this.labelX7);
            this.m_gp_tcp.DisabledBackColor = System.Drawing.Color.Empty;
            this.m_gp_tcp.Location = new System.Drawing.Point(3, 245);
            this.m_gp_tcp.Name = "m_gp_tcp";
            this.m_gp_tcp.Size = new System.Drawing.Size(238, 100);
            // 
            // 
            // 
            this.m_gp_tcp.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.m_gp_tcp.Style.BackColorGradientAngle = 90;
            this.m_gp_tcp.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.m_gp_tcp.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_tcp.Style.BorderBottomWidth = 1;
            this.m_gp_tcp.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.m_gp_tcp.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_tcp.Style.BorderLeftWidth = 1;
            this.m_gp_tcp.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_tcp.Style.BorderRightWidth = 1;
            this.m_gp_tcp.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.m_gp_tcp.Style.BorderTopWidth = 1;
            this.m_gp_tcp.Style.CornerDiameter = 4;
            this.m_gp_tcp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.m_gp_tcp.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.m_gp_tcp.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.m_gp_tcp.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.m_gp_tcp.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.m_gp_tcp.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_gp_tcp.TabIndex = 3;
            // 
            // m_rbtn_tcp_client
            // 
            this.m_rbtn_tcp_client.AutoSize = true;
            this.m_rbtn_tcp_client.Enabled = false;
            this.m_rbtn_tcp_client.Location = new System.Drawing.Point(162, 13);
            this.m_rbtn_tcp_client.Name = "m_rbtn_tcp_client";
            this.m_rbtn_tcp_client.Size = new System.Drawing.Size(55, 16);
            this.m_rbtn_tcp_client.TabIndex = 12;
            this.m_rbtn_tcp_client.TabStop = true;
            this.m_rbtn_tcp_client.Text = "Client";
            this.m_rbtn_tcp_client.UseVisualStyleBackColor = true;
            this.m_rbtn_tcp_client.CheckedChanged += new System.EventHandler(this.m_rbtn_CheckedChanged);
            // 
            // m_rbtn_tcp_server
            // 
            this.m_rbtn_tcp_server.AutoSize = true;
            this.m_rbtn_tcp_server.Checked = true;
            this.m_rbtn_tcp_server.Enabled = false;
            this.m_rbtn_tcp_server.Location = new System.Drawing.Point(96, 13);
            this.m_rbtn_tcp_server.Name = "m_rbtn_tcp_server";
            this.m_rbtn_tcp_server.Size = new System.Drawing.Size(59, 16);
            this.m_rbtn_tcp_server.TabIndex = 11;
            this.m_rbtn_tcp_server.TabStop = true;
            this.m_rbtn_tcp_server.Text = "Server";
            this.m_rbtn_tcp_server.UseVisualStyleBackColor = true;
            this.m_rbtn_tcp_server.CheckedChanged += new System.EventHandler(this.m_rbtn_CheckedChanged);
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX9.Location = new System.Drawing.Point(15, 10);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(75, 21);
            this.labelX9.TabIndex = 8;
            this.labelX9.Text = "Mode";
            // 
            // m_txb_portnum
            // 
            // 
            // 
            // 
            this.m_txb_portnum.Border.Class = "TextBoxBorder";
            this.m_txb_portnum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_portnum.Enabled = false;
            this.m_txb_portnum.FocusHighlightEnabled = true;
            this.m_txb_portnum.Location = new System.Drawing.Point(96, 64);
            this.m_txb_portnum.MaxLength = 5;
            this.m_txb_portnum.Name = "m_txb_portnum";
            this.m_txb_portnum.PreventEnterBeep = true;
            this.m_txb_portnum.Size = new System.Drawing.Size(121, 21);
            this.m_txb_portnum.TabIndex = 7;
            this.m_txb_portnum.Text = "9999";
            this.m_txb_portnum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ipAddressInput1
            // 
            this.ipAddressInput1.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipAddressInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipAddressInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipAddressInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipAddressInput1.ButtonFreeText.Visible = true;
            this.ipAddressInput1.Enabled = false;
            this.ipAddressInput1.FocusHighlightEnabled = true;
            this.ipAddressInput1.Location = new System.Drawing.Point(96, 37);
            this.ipAddressInput1.Name = "ipAddressInput1";
            this.ipAddressInput1.Size = new System.Drawing.Size(121, 21);
            this.ipAddressInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipAddressInput1.TabIndex = 6;
            this.ipAddressInput1.Value = "127.0.0.1";
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX8.Location = new System.Drawing.Point(15, 64);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 21);
            this.labelX8.TabIndex = 5;
            this.labelX8.Text = "Port";
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX7.Location = new System.Drawing.Point(15, 37);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 21);
            this.labelX7.TabIndex = 3;
            this.labelX7.Text = "IP";
            // 
            // m_rbtn_tcp
            // 
            this.m_rbtn_tcp.AutoSize = true;
            this.m_rbtn_tcp.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtn_tcp.Location = new System.Drawing.Point(3, 223);
            this.m_rbtn_tcp.Name = "m_rbtn_tcp";
            this.m_rbtn_tcp.Size = new System.Drawing.Size(108, 16);
            this.m_rbtn_tcp.TabIndex = 2;
            this.m_rbtn_tcp.Text = "Ethernet (TCP)";
            this.m_rbtn_tcp.UseVisualStyleBackColor = false;
            this.m_rbtn_tcp.CheckedChanged += new System.EventHandler(this.m_rbtn_CheckedChanged);
            // 
            // timer_grabber
            // 
            this.timer_grabber.Tick += new System.EventHandler(this.timer_grabber_Tick);
            // 
            // serialPort
            // 
            this.serialPort.DtrEnable = true;
            this.serialPort.RtsEnable = true;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // Widjet_Setting_Comm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.m_gp_commsetting);
            this.Name = "Widjet_Setting_Comm";
            this.Size = new System.Drawing.Size(250, 426);
            this.Load += new System.EventHandler(this.Widjet_Setting_Comm_Load);
            this.m_gp_commsetting.ResumeLayout(false);
            this.m_gp_commsetting.PerformLayout();
            this.m_gp_serial.ResumeLayout(false);
            this.m_gp_tcp.ResumeLayout(false);
            this.m_gp_tcp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel m_gp_commsetting;
        private DevComponents.DotNetBar.Controls.GroupPanel m_gp_serial;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_flowtype;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_stopbits;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_parity;
        private DevComponents.Editors.ComboItem comboItem11;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.Editors.ComboItem comboItem14;
        private DevComponents.Editors.ComboItem comboItem15;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_baudrate;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_databits;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_portname;
        private System.Windows.Forms.RadioButton m_rbtn_serial;
        private DevComponents.DotNetBar.Controls.GroupPanel m_gp_tcp;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_portnum;
        private DevComponents.Editors.IpAddressInput ipAddressInput1;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.RadioButton m_rbtn_tcp;
        private System.Windows.Forms.RadioButton m_rbtn_tcp_client;
        private System.Windows.Forms.RadioButton m_rbtn_tcp_server;
        private DevComponents.DotNetBar.ButtonX m_btn_conn;
        private DevComponents.DotNetBar.ButtonX m_btn_refresh;
        private System.Windows.Forms.Timer timer_grabber;
        private System.IO.Ports.SerialPort serialPort;
    }
}
