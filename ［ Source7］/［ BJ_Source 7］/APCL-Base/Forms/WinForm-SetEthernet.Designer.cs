namespace Apros_Class_Library_Base
{
    partial class WinForm_SetEthernet
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txb_port = new System.Windows.Forms.TextBox();
            this.m_btn_set = new System.Windows.Forms.Button();
            this.m_btn_cancel = new System.Windows.Forms.Button();
            this.m_rbtn_server = new System.Windows.Forms.RadioButton();
            this.m_rbtn_client = new System.Windows.Forms.RadioButton();
            this.m_ckb_autoreconn = new System.Windows.Forms.CheckBox();
            this.ipAddressInput1 = new DevComponents.Editors.IpAddressInput();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Remote IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // m_txb_port
            // 
            this.m_txb_port.Location = new System.Drawing.Point(12, 132);
            this.m_txb_port.MaxLength = 5;
            this.m_txb_port.Name = "m_txb_port";
            this.m_txb_port.Size = new System.Drawing.Size(79, 21);
            this.m_txb_port.TabIndex = 4;
            this.m_txb_port.Text = "0";
            this.m_txb_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txb_port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txb_port_KeyPress);
            // 
            // m_btn_set
            // 
            this.m_btn_set.Location = new System.Drawing.Point(12, 207);
            this.m_btn_set.Name = "m_btn_set";
            this.m_btn_set.Size = new System.Drawing.Size(75, 23);
            this.m_btn_set.TabIndex = 7;
            this.m_btn_set.Text = "Set";
            this.m_btn_set.UseVisualStyleBackColor = true;
            this.m_btn_set.Click += new System.EventHandler(this.m_btn_set_Click);
            // 
            // m_btn_cancel
            // 
            this.m_btn_cancel.Location = new System.Drawing.Point(127, 207);
            this.m_btn_cancel.Name = "m_btn_cancel";
            this.m_btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.m_btn_cancel.TabIndex = 6;
            this.m_btn_cancel.Text = "Cancel";
            this.m_btn_cancel.UseVisualStyleBackColor = true;
            this.m_btn_cancel.Click += new System.EventHandler(this.m_btn_cancel_Click);
            // 
            // m_rbtn_server
            // 
            this.m_rbtn_server.AutoSize = true;
            this.m_rbtn_server.Checked = true;
            this.m_rbtn_server.Location = new System.Drawing.Point(12, 12);
            this.m_rbtn_server.Name = "m_rbtn_server";
            this.m_rbtn_server.Size = new System.Drawing.Size(59, 16);
            this.m_rbtn_server.TabIndex = 8;
            this.m_rbtn_server.TabStop = true;
            this.m_rbtn_server.Text = "Server";
            this.m_rbtn_server.UseVisualStyleBackColor = true;
            this.m_rbtn_server.Click += new System.EventHandler(this.m_rbtn_server_Click);
            // 
            // m_rbtn_client
            // 
            this.m_rbtn_client.AutoSize = true;
            this.m_rbtn_client.Location = new System.Drawing.Point(127, 12);
            this.m_rbtn_client.Name = "m_rbtn_client";
            this.m_rbtn_client.Size = new System.Drawing.Size(55, 16);
            this.m_rbtn_client.TabIndex = 9;
            this.m_rbtn_client.Text = "Client";
            this.m_rbtn_client.UseVisualStyleBackColor = true;
            this.m_rbtn_client.Click += new System.EventHandler(this.m_rbtn_client_Click);
            // 
            // m_ckb_autoreconn
            // 
            this.m_ckb_autoreconn.AutoSize = true;
            this.m_ckb_autoreconn.Location = new System.Drawing.Point(12, 170);
            this.m_ckb_autoreconn.Name = "m_ckb_autoreconn";
            this.m_ckb_autoreconn.Size = new System.Drawing.Size(161, 16);
            this.m_ckb_autoreconn.TabIndex = 10;
            this.m_ckb_autoreconn.Text = "Automatic Reconnection";
            this.m_ckb_autoreconn.UseVisualStyleBackColor = true;
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
            this.ipAddressInput1.Location = new System.Drawing.Point(14, 69);
            this.ipAddressInput1.Name = "ipAddressInput1";
            this.ipAddressInput1.Size = new System.Drawing.Size(188, 21);
            this.ipAddressInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipAddressInput1.TabIndex = 11;
            // 
            // WinForm_SetEthernet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 241);
            this.Controls.Add(this.ipAddressInput1);
            this.Controls.Add(this.m_ckb_autoreconn);
            this.Controls.Add(this.m_rbtn_client);
            this.Controls.Add(this.m_rbtn_server);
            this.Controls.Add(this.m_btn_set);
            this.Controls.Add(this.m_btn_cancel);
            this.Controls.Add(this.m_txb_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(230, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(230, 280);
            this.Name = "WinForm_SetEthernet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP/IP Setting";
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txb_port;
        private System.Windows.Forms.Button m_btn_set;
        private System.Windows.Forms.Button m_btn_cancel;
        private System.Windows.Forms.RadioButton m_rbtn_server;
        private System.Windows.Forms.RadioButton m_rbtn_client;
        private System.Windows.Forms.CheckBox m_ckb_autoreconn;
        private DevComponents.Editors.IpAddressInput ipAddressInput1;
    }
}