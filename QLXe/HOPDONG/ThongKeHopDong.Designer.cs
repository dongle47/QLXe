
namespace QLXe
{
    partial class ThongKeHopDong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTongDT = new System.Windows.Forms.Label();
            this.labelNgay = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.labelThue = new System.Windows.Forms.Label();
            this.labelChoThue = new System.Windows.Forms.Label();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.buttonToText = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelTongDT);
            this.panel1.Controls.Add(this.labelNgay);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.labelThue);
            this.panel1.Controls.Add(this.labelChoThue);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 227);
            this.panel1.TabIndex = 8;
            // 
            // labelTongDT
            // 
            this.labelTongDT.AutoSize = true;
            this.labelTongDT.Location = new System.Drawing.Point(17, 167);
            this.labelTongDT.Name = "labelTongDT";
            this.labelTongDT.Size = new System.Drawing.Size(60, 13);
            this.labelTongDT.TabIndex = 9;
            this.labelTongDT.Text = "Tổng Cộng";
            // 
            // labelNgay
            // 
            this.labelNgay.AutoSize = true;
            this.labelNgay.Location = new System.Drawing.Point(65, 34);
            this.labelNgay.Name = "labelNgay";
            this.labelNgay.Size = new System.Drawing.Size(35, 13);
            this.labelNgay.TabIndex = 9;
            this.labelNgay.Text = "label1";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(75, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(124, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "THỐNG KÊ HỢP ĐỒNG";
            // 
            // labelThue
            // 
            this.labelThue.Location = new System.Drawing.Point(17, 116);
            this.labelThue.Name = "labelThue";
            this.labelThue.Size = new System.Drawing.Size(100, 23);
            this.labelThue.TabIndex = 1;
            this.labelThue.Text = "Ký Gửi";
            // 
            // labelChoThue
            // 
            this.labelChoThue.Location = new System.Drawing.Point(17, 75);
            this.labelChoThue.Name = "labelChoThue";
            this.labelChoThue.Size = new System.Drawing.Size(100, 23);
            this.labelChoThue.TabIndex = 1;
            this.labelChoThue.Text = "Cho Thuê";
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(297, 12);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(358, 294);
            this.pieChart1.TabIndex = 9;
            this.pieChart1.Text = "pieChart1";
            // 
            // buttonToText
            // 
            this.buttonToText.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonToText.Location = new System.Drawing.Point(104, 260);
            this.buttonToText.Name = "buttonToText";
            this.buttonToText.Size = new System.Drawing.Size(96, 29);
            this.buttonToText.TabIndex = 10;
            this.buttonToText.Text = "TO TEXT";
            this.buttonToText.UseVisualStyleBackColor = false;
            this.buttonToText.Click += new System.EventHandler(this.buttonToText_Click);
            // 
            // ThongKeHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(667, 318);
            this.Controls.Add(this.buttonToText);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.panel1);
            this.Name = "ThongKeHopDong";
            this.Text = "ThongKeHopDong";
            this.Load += new System.EventHandler(this.ThongKeHopDong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNgay;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label labelThue;
        private System.Windows.Forms.Label labelChoThue;
        private System.Windows.Forms.Label labelTongDT;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Button buttonToText;
    }
}