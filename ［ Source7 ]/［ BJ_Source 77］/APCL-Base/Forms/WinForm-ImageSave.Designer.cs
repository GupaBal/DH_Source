namespace Apros_Class_Library_Base
{
    partial class WinForm_ImageSave
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
            this.m_rbtn_bmp = new System.Windows.Forms.RadioButton();
            this.m_rbtn_jpg = new System.Windows.Forms.RadioButton();
            this.m_rbtn_png = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_ckb_changeresolution = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txb_height = new System.Windows.Forms.TextBox();
            this.m_txb_width = new System.Windows.Forms.TextBox();
            this.m_cb_resolution = new System.Windows.Forms.ComboBox();
            this.m_ckb_define = new System.Windows.Forms.CheckBox();
            this.m_btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txb_path = new System.Windows.Forms.TextBox();
            this.m_btn_path = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_txb_filename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_rbtn_bmp
            // 
            this.m_rbtn_bmp.AutoSize = true;
            this.m_rbtn_bmp.Checked = true;
            this.m_rbtn_bmp.Location = new System.Drawing.Point(6, 20);
            this.m_rbtn_bmp.Name = "m_rbtn_bmp";
            this.m_rbtn_bmp.Size = new System.Drawing.Size(50, 16);
            this.m_rbtn_bmp.TabIndex = 0;
            this.m_rbtn_bmp.TabStop = true;
            this.m_rbtn_bmp.Text = "BMP";
            this.m_rbtn_bmp.UseVisualStyleBackColor = true;
            this.m_rbtn_bmp.Click += new System.EventHandler(this.m_rbtn_bmp_Click);
            // 
            // m_rbtn_jpg
            // 
            this.m_rbtn_jpg.AutoSize = true;
            this.m_rbtn_jpg.Location = new System.Drawing.Point(108, 20);
            this.m_rbtn_jpg.Name = "m_rbtn_jpg";
            this.m_rbtn_jpg.Size = new System.Drawing.Size(46, 16);
            this.m_rbtn_jpg.TabIndex = 1;
            this.m_rbtn_jpg.Text = "JPG";
            this.m_rbtn_jpg.UseVisualStyleBackColor = true;
            this.m_rbtn_jpg.Click += new System.EventHandler(this.m_rbtn_jpg_Click);
            // 
            // m_rbtn_png
            // 
            this.m_rbtn_png.AutoSize = true;
            this.m_rbtn_png.Location = new System.Drawing.Point(206, 20);
            this.m_rbtn_png.Name = "m_rbtn_png";
            this.m_rbtn_png.Size = new System.Drawing.Size(49, 16);
            this.m_rbtn_png.TabIndex = 2;
            this.m_rbtn_png.Text = "PNG";
            this.m_rbtn_png.UseVisualStyleBackColor = true;
            this.m_rbtn_png.Click += new System.EventHandler(this.m_rbtn_png_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rbtn_png);
            this.groupBox1.Controls.Add(this.m_rbtn_jpg);
            this.groupBox1.Controls.Add(this.m_rbtn_bmp);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 45);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_ckb_changeresolution);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_txb_height);
            this.groupBox2.Controls.Add(this.m_txb_width);
            this.groupBox2.Controls.Add(this.m_cb_resolution);
            this.groupBox2.Controls.Add(this.m_ckb_define);
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 151);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "해상도";
            // 
            // m_ckb_changeresolution
            // 
            this.m_ckb_changeresolution.AutoSize = true;
            this.m_ckb_changeresolution.Location = new System.Drawing.Point(6, 29);
            this.m_ckb_changeresolution.Name = "m_ckb_changeresolution";
            this.m_ckb_changeresolution.Size = new System.Drawing.Size(88, 16);
            this.m_ckb_changeresolution.TabIndex = 5;
            this.m_ckb_changeresolution.Text = "해상도 변경";
            this.m_ckb_changeresolution.UseVisualStyleBackColor = true;
            this.m_ckb_changeresolution.Click += new System.EventHandler(this.m_ckb_changeresolution_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            // 
            // m_txb_height
            // 
            this.m_txb_height.Enabled = false;
            this.m_txb_height.Location = new System.Drawing.Point(155, 112);
            this.m_txb_height.Name = "m_txb_height";
            this.m_txb_height.Size = new System.Drawing.Size(100, 21);
            this.m_txb_height.TabIndex = 3;
            this.m_txb_height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txb_width_KeyPress);
            // 
            // m_txb_width
            // 
            this.m_txb_width.Enabled = false;
            this.m_txb_width.Location = new System.Drawing.Point(5, 112);
            this.m_txb_width.Name = "m_txb_width";
            this.m_txb_width.Size = new System.Drawing.Size(100, 21);
            this.m_txb_width.TabIndex = 2;
            this.m_txb_width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txb_width_KeyPress);
            // 
            // m_cb_resolution
            // 
            this.m_cb_resolution.Enabled = false;
            this.m_cb_resolution.FormattingEnabled = true;
            this.m_cb_resolution.Items.AddRange(new object[] {
            "1024 * 768",
            "512 * 384",
            "256 * 192",
            "128 * 96"});
            this.m_cb_resolution.Location = new System.Drawing.Point(54, 50);
            this.m_cb_resolution.Name = "m_cb_resolution";
            this.m_cb_resolution.Size = new System.Drawing.Size(148, 20);
            this.m_cb_resolution.TabIndex = 1;
            // 
            // m_ckb_define
            // 
            this.m_ckb_define.AutoSize = true;
            this.m_ckb_define.Enabled = false;
            this.m_ckb_define.Location = new System.Drawing.Point(5, 90);
            this.m_ckb_define.Name = "m_ckb_define";
            this.m_ckb_define.Size = new System.Drawing.Size(76, 16);
            this.m_ckb_define.TabIndex = 0;
            this.m_ckb_define.Text = "직접 입력";
            this.m_ckb_define.UseVisualStyleBackColor = true;
            this.m_ckb_define.Click += new System.EventHandler(this.m_ckb_define_Click);
            // 
            // m_btn_save
            // 
            this.m_btn_save.Location = new System.Drawing.Point(466, 220);
            this.m_btn_save.Name = "m_btn_save";
            this.m_btn_save.Size = new System.Drawing.Size(106, 30);
            this.m_btn_save.TabIndex = 5;
            this.m_btn_save.Text = "이미지 저장";
            this.m_btn_save.UseVisualStyleBackColor = true;
            this.m_btn_save.Click += new System.EventHandler(this.m_btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "저장 경로";
            // 
            // m_txb_path
            // 
            this.m_txb_path.Location = new System.Drawing.Point(8, 48);
            this.m_txb_path.Name = "m_txb_path";
            this.m_txb_path.Size = new System.Drawing.Size(240, 21);
            this.m_txb_path.TabIndex = 7;
            // 
            // m_btn_path
            // 
            this.m_btn_path.Location = new System.Drawing.Point(249, 48);
            this.m_btn_path.Name = "m_btn_path";
            this.m_btn_path.Size = new System.Drawing.Size(21, 21);
            this.m_btn_path.TabIndex = 8;
            this.m_btn_path.Text = "▼";
            this.m_btn_path.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.m_btn_path.UseVisualStyleBackColor = true;
            this.m_btn_path.Click += new System.EventHandler(this.m_btn_path_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_txb_filename);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.m_btn_path);
            this.groupBox3.Controls.Add(this.m_txb_path);
            this.groupBox3.Location = new System.Drawing.Point(280, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(292, 151);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "파일 정보";
            // 
            // m_txb_filename
            // 
            this.m_txb_filename.Location = new System.Drawing.Point(8, 112);
            this.m_txb_filename.Name = "m_txb_filename";
            this.m_txb_filename.Size = new System.Drawing.Size(240, 21);
            this.m_txb_filename.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "파일 이름";
            // 
            // WinForm_ImageSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.m_btn_save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "WinForm_ImageSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Save Option";
            this.Load += new System.EventHandler(this.WinForm_ImageSave_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton m_rbtn_bmp;
        private System.Windows.Forms.RadioButton m_rbtn_jpg;
        private System.Windows.Forms.RadioButton m_rbtn_png;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button m_btn_save;
        private System.Windows.Forms.CheckBox m_ckb_define;
        private System.Windows.Forms.TextBox m_txb_height;
        private System.Windows.Forms.TextBox m_txb_width;
        private System.Windows.Forms.ComboBox m_cb_resolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txb_path;
        private System.Windows.Forms.Button m_btn_path;
        private System.Windows.Forms.CheckBox m_ckb_changeresolution;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox m_txb_filename;
        private System.Windows.Forms.Label label3;
    }
}