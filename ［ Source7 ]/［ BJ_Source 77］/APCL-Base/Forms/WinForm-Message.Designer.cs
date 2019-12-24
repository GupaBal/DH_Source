namespace Apros_Class_Library_Base
{
    partial class WinForm_Message
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm_Message));
            this.timer_close = new System.Windows.Forms.Timer(this.components);
            this.label_message = new System.Windows.Forms.Label();
            this.m_btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer_close
            // 
            this.timer_close.Interval = 1000;
            this.timer_close.Tick += new System.EventHandler(this.timer_close_Tick);
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.BackColor = System.Drawing.Color.Transparent;
            this.label_message.Location = new System.Drawing.Point(12, 34);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(58, 12);
            this.label_message.TabIndex = 1;
            this.label_message.Text = "Message";
            // 
            // m_btn_ok
            // 
            this.m_btn_ok.BackColor = System.Drawing.Color.Transparent;
            this.m_btn_ok.Location = new System.Drawing.Point(105, 77);
            this.m_btn_ok.Name = "m_btn_ok";
            this.m_btn_ok.Size = new System.Drawing.Size(75, 23);
            this.m_btn_ok.TabIndex = 2;
            this.m_btn_ok.Text = "확인";
            this.m_btn_ok.UseVisualStyleBackColor = false;
            this.m_btn_ok.Click += new System.EventHandler(this.m_btn_ok_Click);
            // 
            // WinForm_Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 112);
            this.Controls.Add(this.m_btn_ok);
            this.Controls.Add(this.label_message);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinForm_Message";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caption";
            this.Load += new System.EventHandler(this.WinForm_Message_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_close;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Button m_btn_ok;
    }
}