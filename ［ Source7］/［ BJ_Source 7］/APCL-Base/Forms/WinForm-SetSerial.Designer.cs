namespace Apros_Class_Library_Base
{
    partial class WinForm_SetSerial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cb_hs = new System.Windows.Forms.ComboBox();
            this.m_cb_sb = new System.Windows.Forms.ComboBox();
            this.m_cb_p = new System.Windows.Forms.ComboBox();
            this.m_cb_db = new System.Windows.Forms.ComboBox();
            this.m_btn_Cancel = new System.Windows.Forms.Button();
            this.m_cb_br = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cb_pn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btn_Set = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "Handshake";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "StopBits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "Parity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "DataBits";
            // 
            // m_cb_hs
            // 
            this.m_cb_hs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_hs.FormattingEnabled = true;
            this.m_cb_hs.Location = new System.Drawing.Point(89, 142);
            this.m_cb_hs.Name = "m_cb_hs";
            this.m_cb_hs.Size = new System.Drawing.Size(114, 20);
            this.m_cb_hs.TabIndex = 31;
            this.m_cb_hs.SelectedIndexChanged += new System.EventHandler(this.m_cb_hs_SelectedIndexChanged);
            // 
            // m_cb_sb
            // 
            this.m_cb_sb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_sb.FormattingEnabled = true;
            this.m_cb_sb.Location = new System.Drawing.Point(89, 116);
            this.m_cb_sb.Name = "m_cb_sb";
            this.m_cb_sb.Size = new System.Drawing.Size(114, 20);
            this.m_cb_sb.TabIndex = 30;
            this.m_cb_sb.SelectedIndexChanged += new System.EventHandler(this.m_cb_sb_SelectedIndexChanged);
            // 
            // m_cb_p
            // 
            this.m_cb_p.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_p.FormattingEnabled = true;
            this.m_cb_p.Location = new System.Drawing.Point(89, 90);
            this.m_cb_p.Name = "m_cb_p";
            this.m_cb_p.Size = new System.Drawing.Size(114, 20);
            this.m_cb_p.TabIndex = 29;
            this.m_cb_p.SelectedIndexChanged += new System.EventHandler(this.m_cb_p_SelectedIndexChanged);
            // 
            // m_cb_db
            // 
            this.m_cb_db.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_db.FormattingEnabled = true;
            this.m_cb_db.Location = new System.Drawing.Point(89, 64);
            this.m_cb_db.Name = "m_cb_db";
            this.m_cb_db.Size = new System.Drawing.Size(114, 20);
            this.m_cb_db.TabIndex = 28;
            this.m_cb_db.SelectedIndexChanged += new System.EventHandler(this.m_cb_db_SelectedIndexChanged);
            // 
            // m_btn_Cancel
            // 
            this.m_btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btn_Cancel.Location = new System.Drawing.Point(128, 187);
            this.m_btn_Cancel.Name = "m_btn_Cancel";
            this.m_btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.m_btn_Cancel.TabIndex = 27;
            this.m_btn_Cancel.Text = "Cancel";
            this.m_btn_Cancel.UseVisualStyleBackColor = true;
            this.m_btn_Cancel.Click += new System.EventHandler(this.m_btn_Cancel_Click);
            // 
            // m_cb_br
            // 
            this.m_cb_br.AutoCompleteCustomSource.AddRange(new string[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "76800",
            "115200",
            "230400"});
            this.m_cb_br.FormattingEnabled = true;
            this.m_cb_br.Location = new System.Drawing.Point(89, 38);
            this.m_cb_br.Name = "m_cb_br";
            this.m_cb_br.Size = new System.Drawing.Size(114, 20);
            this.m_cb_br.TabIndex = 26;
            this.m_cb_br.SelectedIndexChanged += new System.EventHandler(this.m_cb_Baud_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "Baudrate";
            // 
            // m_cb_pn
            // 
            this.m_cb_pn.AutoCompleteCustomSource.AddRange(new string[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20"});
            this.m_cb_pn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_pn.FormattingEnabled = true;
            this.m_cb_pn.Location = new System.Drawing.Point(89, 12);
            this.m_cb_pn.Name = "m_cb_pn";
            this.m_cb_pn.Size = new System.Drawing.Size(114, 20);
            this.m_cb_pn.Sorted = true;
            this.m_cb_pn.TabIndex = 24;
            this.m_cb_pn.SelectedIndexChanged += new System.EventHandler(this.m_cb_Port_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "Port";
            // 
            // m_btn_Set
            // 
            this.m_btn_Set.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btn_Set.Location = new System.Drawing.Point(11, 187);
            this.m_btn_Set.Name = "m_btn_Set";
            this.m_btn_Set.Size = new System.Drawing.Size(75, 23);
            this.m_btn_Set.TabIndex = 22;
            this.m_btn_Set.Text = "Set";
            this.m_btn_Set.UseVisualStyleBackColor = true;
            this.m_btn_Set.Click += new System.EventHandler(this.m_btn_Set_Click);
            // 
            // WinForm_SetSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 221);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_cb_hs);
            this.Controls.Add(this.m_cb_sb);
            this.Controls.Add(this.m_cb_p);
            this.Controls.Add(this.m_cb_db);
            this.Controls.Add(this.m_btn_Cancel);
            this.Controls.Add(this.m_cb_br);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cb_pn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btn_Set);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(230, 260);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(230, 260);
            this.Name = "WinForm_SetSerial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Setting";
            this.Load += new System.EventHandler(this.WinForm_SetSerial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox m_cb_hs;
        private System.Windows.Forms.ComboBox m_cb_sb;
        private System.Windows.Forms.ComboBox m_cb_p;
        private System.Windows.Forms.ComboBox m_cb_db;
        private System.Windows.Forms.Button m_btn_Cancel;
        private System.Windows.Forms.ComboBox m_cb_br;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cb_pn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_btn_Set;
    }
}