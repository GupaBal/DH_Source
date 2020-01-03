namespace APROS_Serial_Utility
{
    partial class CommPanel
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
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.m_cb_databits = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.m_cb_portname = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_ckb_Server = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.m_txb_portnum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ipAddressInput1 = new DevComponents.Editors.IpAddressInput();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.m_rbtn_tcp = new System.Windows.Forms.RadioButton();
            this.m_rbtn_serial = new System.Windows.Forms.RadioButton();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_ckb_dispalyTime = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.m_ckb_displaySend = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.m_ckb_autofeedline = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.m_rbtn_recvH = new System.Windows.Forms.RadioButton();
            this.m_rbtn_recvT = new System.Windows.Forms.RadioButton();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_txb_loop = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.m_ckb_sendLoop = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.m_rbtn_sendH = new System.Windows.Forms.RadioButton();
            this.m_rbtn_sendT = new System.Windows.Forms.RadioButton();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_btn_fileload = new DevComponents.DotNetBar.ButtonX();
            this.m_btn_path_setup = new DevComponents.DotNetBar.ButtonX();
            this.m_txb_savepath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.m_btn_recvclear = new DevComponents.DotNetBar.ButtonX();
            this.m_btn_open = new DevComponents.DotNetBar.ButtonX();
            this.m_txb_recv = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.m_cb_sendHistory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.m_btn_send = new DevComponents.DotNetBar.ButtonX();
            this.m_btn_sendclear = new DevComponents.DotNetBar.ButtonX();
            this.m_txb_send = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.m_gp_commsetting = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer_loop = new System.Windows.Forms.Timer(this.components);
            this.timer_getter = new System.Windows.Forms.Timer(this.components);
            this.m_gp_serial.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            this.m_gp_commsetting.SuspendLayout();
            this.SuspendLayout();
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
            this.m_cb_baudrate.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6});
            this.m_cb_baudrate.Location = new System.Drawing.Point(96, 36);
            this.m_cb_baudrate.Name = "m_cb_baudrate";
            this.m_cb_baudrate.Size = new System.Drawing.Size(121, 21);
            this.m_cb_baudrate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_cb_baudrate.TabIndex = 1;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "9600";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "19200";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "38400";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "57600";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "115200";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "230400";
            // 
            // m_cb_databits
            // 
            this.m_cb_databits.DisplayMember = "Text";
            this.m_cb_databits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
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
            this.m_cb_portname.FocusHighlightEnabled = true;
            this.m_cb_portname.FormattingEnabled = true;
            this.m_cb_portname.ItemHeight = 15;
            this.m_cb_portname.Location = new System.Drawing.Point(96, 9);
            this.m_cb_portname.Name = "m_cb_portname";
            this.m_cb_portname.Size = new System.Drawing.Size(121, 21);
            this.m_cb_portname.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_cb_portname.TabIndex = 2;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.m_ckb_Server);
            this.groupPanel1.Controls.Add(this.labelX9);
            this.groupPanel1.Controls.Add(this.m_txb_portnum);
            this.groupPanel1.Controls.Add(this.ipAddressInput1);
            this.groupPanel1.Controls.Add(this.labelX8);
            this.groupPanel1.Controls.Add(this.labelX7);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(3, 255);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(238, 100);
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
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 3;
            // 
            // m_ckb_Server
            // 
            // 
            // 
            // 
            this.m_ckb_Server.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_ckb_Server.Enabled = false;
            this.m_ckb_Server.Location = new System.Drawing.Point(96, 8);
            this.m_ckb_Server.Name = "m_ckb_Server";
            this.m_ckb_Server.Size = new System.Drawing.Size(110, 23);
            this.m_ckb_Server.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_ckb_Server.TabIndex = 9;
            this.m_ckb_Server.Text = "Server";
            this.m_ckb_Server.CheckedChanged += new System.EventHandler(this.m_ckb_CheckedChanged);
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
            this.m_txb_portnum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txb_KeyPress);
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
            this.m_rbtn_tcp.Location = new System.Drawing.Point(3, 233);
            this.m_rbtn_tcp.Name = "m_rbtn_tcp";
            this.m_rbtn_tcp.Size = new System.Drawing.Size(108, 16);
            this.m_rbtn_tcp.TabIndex = 2;
            this.m_rbtn_tcp.Text = "Ethernet (TCP)";
            this.m_rbtn_tcp.UseVisualStyleBackColor = false;
            this.m_rbtn_tcp.CheckedChanged += new System.EventHandler(this.m_rbtn_serial_CheckedChanged);
            // 
            // m_rbtn_serial
            // 
            this.m_rbtn_serial.AutoSize = true;
            this.m_rbtn_serial.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtn_serial.Checked = true;
            this.m_rbtn_serial.Location = new System.Drawing.Point(3, 15);
            this.m_rbtn_serial.Name = "m_rbtn_serial";
            this.m_rbtn_serial.Size = new System.Drawing.Size(55, 16);
            this.m_rbtn_serial.TabIndex = 1;
            this.m_rbtn_serial.TabStop = true;
            this.m_rbtn_serial.Text = "Serial";
            this.m_rbtn_serial.UseVisualStyleBackColor = false;
            this.m_rbtn_serial.CheckedChanged += new System.EventHandler(this.m_rbtn_serial_CheckedChanged);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.m_ckb_dispalyTime);
            this.groupPanel2.Controls.Add(this.m_ckb_displaySend);
            this.groupPanel2.Controls.Add(this.m_ckb_autofeedline);
            this.groupPanel2.Controls.Add(this.m_rbtn_recvH);
            this.groupPanel2.Controls.Add(this.m_rbtn_recvT);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(3, 461);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(250, 120);
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
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "Recieve Setting";
            // 
            // m_ckb_dispalyTime
            // 
            // 
            // 
            // 
            this.m_ckb_dispalyTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_ckb_dispalyTime.Location = new System.Drawing.Point(125, 63);
            this.m_ckb_dispalyTime.Name = "m_ckb_dispalyTime";
            this.m_ckb_dispalyTime.Size = new System.Drawing.Size(110, 23);
            this.m_ckb_dispalyTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_ckb_dispalyTime.TabIndex = 7;
            this.m_ckb_dispalyTime.Text = "Display Time";
            this.m_ckb_dispalyTime.CheckedChanged += new System.EventHandler(this.m_ckb_CheckedChanged);
            // 
            // m_ckb_displaySend
            // 
            // 
            // 
            // 
            this.m_ckb_displaySend.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_ckb_displaySend.Location = new System.Drawing.Point(125, 34);
            this.m_ckb_displaySend.Name = "m_ckb_displaySend";
            this.m_ckb_displaySend.Size = new System.Drawing.Size(110, 23);
            this.m_ckb_displaySend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_ckb_displaySend.TabIndex = 6;
            this.m_ckb_displaySend.Text = "Display Send";
            this.m_ckb_displaySend.CheckedChanged += new System.EventHandler(this.m_ckb_CheckedChanged);
            // 
            // m_ckb_autofeedline
            // 
            // 
            // 
            // 
            this.m_ckb_autofeedline.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_ckb_autofeedline.Checked = true;
            this.m_ckb_autofeedline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ckb_autofeedline.CheckValue = "Y";
            this.m_ckb_autofeedline.Location = new System.Drawing.Point(9, 34);
            this.m_ckb_autofeedline.Name = "m_ckb_autofeedline";
            this.m_ckb_autofeedline.Size = new System.Drawing.Size(110, 23);
            this.m_ckb_autofeedline.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_ckb_autofeedline.TabIndex = 5;
            this.m_ckb_autofeedline.Text = "Auto Feed Line";
            this.m_ckb_autofeedline.CheckedChanged += new System.EventHandler(this.m_ckb_CheckedChanged);
            // 
            // m_rbtn_recvH
            // 
            this.m_rbtn_recvH.AutoSize = true;
            this.m_rbtn_recvH.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtn_recvH.Location = new System.Drawing.Point(125, 12);
            this.m_rbtn_recvH.Name = "m_rbtn_recvH";
            this.m_rbtn_recvH.Size = new System.Drawing.Size(47, 16);
            this.m_rbtn_recvH.TabIndex = 4;
            this.m_rbtn_recvH.Text = "HEX";
            this.m_rbtn_recvH.UseVisualStyleBackColor = false;
            // 
            // m_rbtn_recvT
            // 
            this.m_rbtn_recvT.AutoSize = true;
            this.m_rbtn_recvT.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtn_recvT.Checked = true;
            this.m_rbtn_recvT.Location = new System.Drawing.Point(9, 12);
            this.m_rbtn_recvT.Name = "m_rbtn_recvT";
            this.m_rbtn_recvT.Size = new System.Drawing.Size(48, 16);
            this.m_rbtn_recvT.TabIndex = 3;
            this.m_rbtn_recvT.TabStop = true;
            this.m_rbtn_recvT.Text = "Text";
            this.m_rbtn_recvT.UseVisualStyleBackColor = false;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.m_txb_loop);
            this.groupPanel3.Controls.Add(this.m_ckb_sendLoop);
            this.groupPanel3.Controls.Add(this.m_rbtn_sendH);
            this.groupPanel3.Controls.Add(this.m_rbtn_sendT);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(3, 587);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(250, 120);
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
            this.groupPanel3.TabIndex = 2;
            this.groupPanel3.Text = "Send Setting";
            // 
            // m_txb_loop
            // 
            // 
            // 
            // 
            this.m_txb_loop.Border.Class = "TextBoxBorder";
            this.m_txb_loop.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_loop.FocusHighlightEnabled = true;
            this.m_txb_loop.Location = new System.Drawing.Point(125, 51);
            this.m_txb_loop.MaxLength = 10;
            this.m_txb_loop.Name = "m_txb_loop";
            this.m_txb_loop.PreventEnterBeep = true;
            this.m_txb_loop.Size = new System.Drawing.Size(110, 21);
            this.m_txb_loop.TabIndex = 8;
            this.m_txb_loop.Text = "1000";
            this.m_txb_loop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txb_loop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txb_KeyPress);
            // 
            // m_ckb_sendLoop
            // 
            // 
            // 
            // 
            this.m_ckb_sendLoop.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_ckb_sendLoop.Location = new System.Drawing.Point(9, 49);
            this.m_ckb_sendLoop.Name = "m_ckb_sendLoop";
            this.m_ckb_sendLoop.Size = new System.Drawing.Size(110, 23);
            this.m_ckb_sendLoop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_ckb_sendLoop.TabIndex = 7;
            this.m_ckb_sendLoop.Text = "Loop (ms)";
            this.m_ckb_sendLoop.CheckedChanged += new System.EventHandler(this.m_ckb_CheckedChanged);
            // 
            // m_rbtn_sendH
            // 
            this.m_rbtn_sendH.AutoSize = true;
            this.m_rbtn_sendH.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtn_sendH.Location = new System.Drawing.Point(125, 27);
            this.m_rbtn_sendH.Name = "m_rbtn_sendH";
            this.m_rbtn_sendH.Size = new System.Drawing.Size(47, 16);
            this.m_rbtn_sendH.TabIndex = 6;
            this.m_rbtn_sendH.Text = "HEX";
            this.m_rbtn_sendH.UseVisualStyleBackColor = false;
            this.m_rbtn_sendH.CheckedChanged += new System.EventHandler(this.m_rbtn_sendT_CheckedChanged);
            // 
            // m_rbtn_sendT
            // 
            this.m_rbtn_sendT.AutoSize = true;
            this.m_rbtn_sendT.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtn_sendT.Checked = true;
            this.m_rbtn_sendT.Location = new System.Drawing.Point(9, 27);
            this.m_rbtn_sendT.Name = "m_rbtn_sendT";
            this.m_rbtn_sendT.Size = new System.Drawing.Size(48, 16);
            this.m_rbtn_sendT.TabIndex = 5;
            this.m_rbtn_sendT.TabStop = true;
            this.m_rbtn_sendT.Text = "Text";
            this.m_rbtn_sendT.UseVisualStyleBackColor = false;
            this.m_rbtn_sendT.CheckedChanged += new System.EventHandler(this.m_rbtn_sendT_CheckedChanged);
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.m_btn_fileload);
            this.groupPanel4.Controls.Add(this.m_btn_path_setup);
            this.groupPanel4.Controls.Add(this.m_txb_savepath);
            this.groupPanel4.Controls.Add(this.m_btn_recvclear);
            this.groupPanel4.Controls.Add(this.m_txb_recv);
            this.groupPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel4.Location = new System.Drawing.Point(259, 3);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(1326, 498);
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
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 3;
            this.groupPanel4.Text = "Recieve";
            // 
            // m_btn_fileload
            // 
            this.m_btn_fileload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_fileload.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_fileload.Location = new System.Drawing.Point(1161, 3);
            this.m_btn_fileload.Name = "m_btn_fileload";
            this.m_btn_fileload.Size = new System.Drawing.Size(75, 90);
            this.m_btn_fileload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_fileload.TabIndex = 9;
            this.m_btn_fileload.Text = "File Load";
            this.m_btn_fileload.Click += new System.EventHandler(this.m_btn_Click);
            // 
            // m_btn_path_setup
            // 
            this.m_btn_path_setup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_path_setup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_path_setup.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.m_btn_path_setup.Location = new System.Drawing.Point(1080, 295);
            this.m_btn_path_setup.Name = "m_btn_path_setup";
            this.m_btn_path_setup.Size = new System.Drawing.Size(75, 90);
            this.m_btn_path_setup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_path_setup.Symbol = "";
            this.m_btn_path_setup.SymbolColor = System.Drawing.Color.Goldenrod;
            this.m_btn_path_setup.SymbolSize = 35F;
            this.m_btn_path_setup.TabIndex = 8;
            this.m_btn_path_setup.Text = "Path Setup";
            this.m_btn_path_setup.Click += new System.EventHandler(this.m_btn_Click);
            // 
            // m_txb_savepath
            // 
            // 
            // 
            // 
            this.m_txb_savepath.Border.Class = "TextBoxBorder";
            this.m_txb_savepath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_savepath.Location = new System.Drawing.Point(1080, 391);
            this.m_txb_savepath.Multiline = true;
            this.m_txb_savepath.Name = "m_txb_savepath";
            this.m_txb_savepath.PreventEnterBeep = true;
            this.m_txb_savepath.Size = new System.Drawing.Size(237, 82);
            this.m_txb_savepath.TabIndex = 7;
            // 
            // m_btn_recvclear
            // 
            this.m_btn_recvclear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_recvclear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_recvclear.Location = new System.Drawing.Point(1080, 3);
            this.m_btn_recvclear.Name = "m_btn_recvclear";
            this.m_btn_recvclear.Size = new System.Drawing.Size(75, 90);
            this.m_btn_recvclear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_recvclear.TabIndex = 4;
            this.m_btn_recvclear.Text = "Clear";
            this.m_btn_recvclear.Click += new System.EventHandler(this.m_btn_Click);
            // 
            // m_btn_open
            // 
            this.m_btn_open.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_open.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_open.Location = new System.Drawing.Point(3, 366);
            this.m_btn_open.Name = "m_btn_open";
            this.m_btn_open.Size = new System.Drawing.Size(238, 50);
            this.m_btn_open.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_open.TabIndex = 3;
            this.m_btn_open.Text = "Open";
            this.m_btn_open.Click += new System.EventHandler(this.m_btn_Click);
            // 
            // m_txb_recv
            // 
            this.m_txb_recv.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.m_txb_recv.Border.Class = "TextBoxBorder";
            this.m_txb_recv.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_recv.FocusHighlightEnabled = true;
            this.m_txb_recv.Location = new System.Drawing.Point(3, 3);
            this.m_txb_recv.Multiline = true;
            this.m_txb_recv.Name = "m_txb_recv";
            this.m_txb_recv.PreventEnterBeep = true;
            this.m_txb_recv.ReadOnly = true;
            this.m_txb_recv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txb_recv.Size = new System.Drawing.Size(1071, 470);
            this.m_txb_recv.TabIndex = 0;
            // 
            // groupPanel5
            // 
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.m_cb_sendHistory);
            this.groupPanel5.Controls.Add(this.m_btn_send);
            this.groupPanel5.Controls.Add(this.m_btn_sendclear);
            this.groupPanel5.Controls.Add(this.m_txb_send);
            this.groupPanel5.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel5.Location = new System.Drawing.Point(259, 507);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(1326, 200);
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
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 4;
            this.groupPanel5.Text = "Send";
            // 
            // m_cb_sendHistory
            // 
            this.m_cb_sendHistory.DisplayMember = "Text";
            this.m_cb_sendHistory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.m_cb_sendHistory.FocusHighlightEnabled = true;
            this.m_cb_sendHistory.FormattingEnabled = true;
            this.m_cb_sendHistory.ItemHeight = 15;
            this.m_cb_sendHistory.Location = new System.Drawing.Point(3, 154);
            this.m_cb_sendHistory.Name = "m_cb_sendHistory";
            this.m_cb_sendHistory.Size = new System.Drawing.Size(1071, 21);
            this.m_cb_sendHistory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_cb_sendHistory.TabIndex = 12;
            this.m_cb_sendHistory.SelectedIndexChanged += new System.EventHandler(this.m_cb_sendHistory_SelectedIndexChanged);
            // 
            // m_btn_send
            // 
            this.m_btn_send.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_send.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_send.Location = new System.Drawing.Point(1161, 3);
            this.m_btn_send.Name = "m_btn_send";
            this.m_btn_send.Size = new System.Drawing.Size(75, 90);
            this.m_btn_send.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_send.TabIndex = 2;
            this.m_btn_send.Text = "Send";
            this.m_btn_send.Click += new System.EventHandler(this.m_btn_Click);
            // 
            // m_btn_sendclear
            // 
            this.m_btn_sendclear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.m_btn_sendclear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.m_btn_sendclear.Location = new System.Drawing.Point(1080, 3);
            this.m_btn_sendclear.Name = "m_btn_sendclear";
            this.m_btn_sendclear.Size = new System.Drawing.Size(75, 90);
            this.m_btn_sendclear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.m_btn_sendclear.TabIndex = 1;
            this.m_btn_sendclear.Text = "Clear";
            this.m_btn_sendclear.Click += new System.EventHandler(this.m_btn_Click);
            // 
            // m_txb_send
            // 
            // 
            // 
            // 
            this.m_txb_send.Border.Class = "TextBoxBorder";
            this.m_txb_send.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.m_txb_send.FocusHighlightEnabled = true;
            this.m_txb_send.Location = new System.Drawing.Point(3, 3);
            this.m_txb_send.Multiline = true;
            this.m_txb_send.Name = "m_txb_send";
            this.m_txb_send.PreventEnterBeep = true;
            this.m_txb_send.Size = new System.Drawing.Size(1071, 145);
            this.m_txb_send.TabIndex = 0;
            // 
            // m_gp_commsetting
            // 
            this.m_gp_commsetting.CanvasColor = System.Drawing.SystemColors.Control;
            this.m_gp_commsetting.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.m_gp_commsetting.Controls.Add(this.m_gp_serial);
            this.m_gp_commsetting.Controls.Add(this.m_rbtn_serial);
            this.m_gp_commsetting.Controls.Add(this.groupPanel1);
            this.m_gp_commsetting.Controls.Add(this.m_rbtn_tcp);
            this.m_gp_commsetting.Controls.Add(this.m_btn_open);
            this.m_gp_commsetting.DisabledBackColor = System.Drawing.Color.Empty;
            this.m_gp_commsetting.Location = new System.Drawing.Point(3, 3);
            this.m_gp_commsetting.Name = "m_gp_commsetting";
            this.m_gp_commsetting.Size = new System.Drawing.Size(250, 452);
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
            this.m_gp_commsetting.TabIndex = 5;
            this.m_gp_commsetting.Text = "Comm Setting";
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // timer_loop
            // 
            this.timer_loop.Tick += new System.EventHandler(this.timer_loop_Tick);
            // 
            // timer_getter
            // 
            this.timer_getter.Interval = 500;
            this.timer_getter.Tick += new System.EventHandler(this.timer_getter_Tick);
            // 
            // CommPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.m_gp_commsetting);
            this.Controls.Add(this.groupPanel5);
            this.Controls.Add(this.groupPanel4);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.DoubleBuffered = true;
            this.Name = "CommPanel";
            this.Size = new System.Drawing.Size(1588, 710);
            this.Load += new System.EventHandler(this.CommPanel_Load);
            this.m_gp_serial.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel5.ResumeLayout(false);
            this.m_gp_commsetting.ResumeLayout(false);
            this.m_gp_commsetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_portname;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_baudrate;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_flowtype;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_stopbits;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_parity;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_databits;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.RadioButton m_rbtn_tcp;
        private System.Windows.Forms.RadioButton m_rbtn_serial;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_portnum;
        private DevComponents.Editors.IpAddressInput ipAddressInput1;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.CheckBoxX m_ckb_dispalyTime;
        private DevComponents.DotNetBar.Controls.CheckBoxX m_ckb_displaySend;
        private DevComponents.DotNetBar.Controls.CheckBoxX m_ckb_autofeedline;
        private System.Windows.Forms.RadioButton m_rbtn_recvH;
        private System.Windows.Forms.RadioButton m_rbtn_recvT;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_loop;
        private DevComponents.DotNetBar.Controls.CheckBoxX m_ckb_sendLoop;
        private System.Windows.Forms.RadioButton m_rbtn_sendH;
        private System.Windows.Forms.RadioButton m_rbtn_sendT;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_recv;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.ButtonX m_btn_send;
        private DevComponents.DotNetBar.ButtonX m_btn_sendclear;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_send;
        private DevComponents.DotNetBar.ButtonX m_btn_recvclear;
        private DevComponents.DotNetBar.ButtonX m_btn_open;
        private DevComponents.DotNetBar.Controls.GroupPanel m_gp_serial;
        private DevComponents.DotNetBar.Controls.GroupPanel m_gp_commsetting;
        private System.IO.Ports.SerialPort serialPort;
        private DevComponents.DotNetBar.Controls.ComboBoxEx m_cb_sendHistory;
        private System.Windows.Forms.Timer timer_loop;
        private DevComponents.DotNetBar.Controls.CheckBoxX m_ckb_Server;
        private System.Windows.Forms.Timer timer_getter;
        private DevComponents.Editors.ComboItem comboItem11;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.Editors.ComboItem comboItem14;
        private DevComponents.Editors.ComboItem comboItem15;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.DotNetBar.ButtonX m_btn_path_setup;
        private DevComponents.DotNetBar.Controls.TextBoxX m_txb_savepath;
        private DevComponents.DotNetBar.ButtonX m_btn_fileload;
    }
}
