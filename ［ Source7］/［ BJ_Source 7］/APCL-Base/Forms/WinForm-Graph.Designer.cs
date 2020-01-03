namespace Apros_Class_Library_Base
{
    partial class WinForm_Graph
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
            this.panel_graph = new System.Windows.Forms.Panel();
            this.m_btn_clear = new System.Windows.Forms.Button();
            this.panel_graph.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_graph
            // 
            this.panel_graph.Controls.Add(this.m_btn_clear);
            this.panel_graph.Location = new System.Drawing.Point(12, 12);
            this.panel_graph.Name = "panel_graph";
            this.panel_graph.Size = new System.Drawing.Size(560, 238);
            this.panel_graph.TabIndex = 0;
            // 
            // m_btn_clear
            // 
            this.m_btn_clear.Location = new System.Drawing.Point(485, 0);
            this.m_btn_clear.Name = "m_btn_clear";
            this.m_btn_clear.Size = new System.Drawing.Size(75, 23);
            this.m_btn_clear.TabIndex = 0;
            this.m_btn_clear.Text = "Clear";
            this.m_btn_clear.UseVisualStyleBackColor = true;
            this.m_btn_clear.Click += new System.EventHandler(this.m_btn_clear_Click);
            // 
            // WinForm_Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.panel_graph);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinForm_Graph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinForm_Graph";
            this.Load += new System.EventHandler(this.WinForm_Graph_Load);
            this.panel_graph.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_graph;
        private System.Windows.Forms.Button m_btn_clear;
    }
}