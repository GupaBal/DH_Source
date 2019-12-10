namespace Apros_Class_Library_Base
{
    partial class WinForm_Mail
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
            this.m_btn_attachment = new System.Windows.Forms.Button();
            this.m_btn_cancel = new System.Windows.Forms.Button();
            this.m_btn_mailsend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txb_body = new System.Windows.Forms.TextBox();
            this.m_txb_retrunmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txb_sender = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_btn_attachment
            // 
            this.m_btn_attachment.Location = new System.Drawing.Point(199, 257);
            this.m_btn_attachment.Name = "m_btn_attachment";
            this.m_btn_attachment.Size = new System.Drawing.Size(120, 35);
            this.m_btn_attachment.TabIndex = 17;
            this.m_btn_attachment.Text = "파일 첨부";
            this.m_btn_attachment.UseVisualStyleBackColor = true;
            this.m_btn_attachment.Click += new System.EventHandler(this.m_btn_attachment_Click);
            // 
            // m_btn_cancel
            // 
            this.m_btn_cancel.Location = new System.Drawing.Point(452, 257);
            this.m_btn_cancel.Name = "m_btn_cancel";
            this.m_btn_cancel.Size = new System.Drawing.Size(120, 35);
            this.m_btn_cancel.TabIndex = 16;
            this.m_btn_cancel.Text = "취소";
            this.m_btn_cancel.UseVisualStyleBackColor = true;
            this.m_btn_cancel.Click += new System.EventHandler(this.m_btn_cancel_Click);
            // 
            // m_btn_mailsend
            // 
            this.m_btn_mailsend.Location = new System.Drawing.Point(325, 257);
            this.m_btn_mailsend.Name = "m_btn_mailsend";
            this.m_btn_mailsend.Size = new System.Drawing.Size(120, 35);
            this.m_btn_mailsend.TabIndex = 15;
            this.m_btn_mailsend.Text = "메일 전송";
            this.m_btn_mailsend.UseVisualStyleBackColor = true;
            this.m_btn_mailsend.Click += new System.EventHandler(this.m_btn_mailsend_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "본문 내용";
            // 
            // m_txb_body
            // 
            this.m_txb_body.Location = new System.Drawing.Point(12, 76);
            this.m_txb_body.Multiline = true;
            this.m_txb_body.Name = "m_txb_body";
            this.m_txb_body.Size = new System.Drawing.Size(433, 175);
            this.m_txb_body.TabIndex = 13;
            // 
            // m_txb_retrunmail
            // 
            this.m_txb_retrunmail.Location = new System.Drawing.Point(245, 26);
            this.m_txb_retrunmail.Name = "m_txb_retrunmail";
            this.m_txb_retrunmail.Size = new System.Drawing.Size(200, 21);
            this.m_txb_retrunmail.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "회신 이메일 주소";
            // 
            // m_txb_sender
            // 
            this.m_txb_sender.Location = new System.Drawing.Point(12, 26);
            this.m_txb_sender.Name = "m_txb_sender";
            this.m_txb_sender.Size = new System.Drawing.Size(200, 21);
            this.m_txb_sender.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "보내는 사람 (ex. 상호, 성명)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(452, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(120, 175);
            this.dataGridView1.TabIndex = 18;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "파일명";
            this.Column1.Name = "Column1";
            this.Column1.Width = 115;
            // 
            // WinForm_Mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 302);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.m_btn_attachment);
            this.Controls.Add(this.m_btn_cancel);
            this.Controls.Add(this.m_btn_mailsend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txb_body);
            this.Controls.Add(this.m_txb_retrunmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txb_sender);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(600, 340);
            this.MinimumSize = new System.Drawing.Size(600, 340);
            this.Name = "WinForm_Mail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinForm_Mail";
            this.Load += new System.EventHandler(this.WinForm_Mail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btn_attachment;
        private System.Windows.Forms.Button m_btn_cancel;
        private System.Windows.Forms.Button m_btn_mailsend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txb_body;
        private System.Windows.Forms.TextBox m_txb_retrunmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txb_sender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;

    }
}