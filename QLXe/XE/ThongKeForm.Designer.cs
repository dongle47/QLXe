
namespace QLXe
{
    partial class ThongKeForm
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelNgay = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.labelXeDap = new System.Windows.Forms.Label();
            this.labelXeMay = new System.Windows.Forms.Label();
            this.labelXeHoi = new System.Windows.Forms.Label();
            this.labelTongDoanhThu = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonSave.Location = new System.Drawing.Point(116, 259);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(91, 37);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "TO TEXT";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelNgay
            // 
            this.labelNgay.AutoSize = true;
            this.labelNgay.Location = new System.Drawing.Point(83, 34);
            this.labelNgay.Name = "labelNgay";
            this.labelNgay.Size = new System.Drawing.Size(35, 13);
            this.labelNgay.TabIndex = 1;
            this.labelNgay.Text = "label1";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(100, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(106, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "TỔNG DOANH THU";
            // 
            // labelXeDap
            // 
            this.labelXeDap.Location = new System.Drawing.Point(31, 66);
            this.labelXeDap.Name = "labelXeDap";
            this.labelXeDap.Size = new System.Drawing.Size(100, 23);
            this.labelXeDap.TabIndex = 1;
            this.labelXeDap.Text = "Xe Đạp";
            // 
            // labelXeMay
            // 
            this.labelXeMay.Location = new System.Drawing.Point(31, 98);
            this.labelXeMay.Name = "labelXeMay";
            this.labelXeMay.Size = new System.Drawing.Size(100, 23);
            this.labelXeMay.TabIndex = 1;
            this.labelXeMay.Text = "Xe Máy";
            // 
            // labelXeHoi
            // 
            this.labelXeHoi.Location = new System.Drawing.Point(31, 131);
            this.labelXeHoi.Name = "labelXeHoi";
            this.labelXeHoi.Size = new System.Drawing.Size(100, 23);
            this.labelXeHoi.TabIndex = 1;
            this.labelXeHoi.Text = "Xe Hơi";
            // 
            // labelTongDoanhThu
            // 
            this.labelTongDoanhThu.AutoSize = true;
            this.labelTongDoanhThu.Location = new System.Drawing.Point(31, 173);
            this.labelTongDoanhThu.Name = "labelTongDoanhThu";
            this.labelTongDoanhThu.Size = new System.Drawing.Size(60, 13);
            this.labelTongDoanhThu.TabIndex = 3;
            this.labelTongDoanhThu.Text = "Tổng Cộng";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.labelTongDoanhThu);
            this.panel1.Controls.Add(this.labelNgay);
            this.panel1.Controls.Add(this.labelXeHoi);
            this.panel1.Controls.Add(this.labelXeMay);
            this.panel1.Controls.Add(this.labelXeDap);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 228);
            this.panel1.TabIndex = 4;
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(322, 12);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(326, 294);
            this.pieChart1.TabIndex = 5;
            this.pieChart1.Text = "pieChart1";
            // 
            // ThongKeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(665, 318);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonSave);
            this.Name = "ThongKeForm";
            this.Text = "ThongKeForm";
            this.Load += new System.EventHandler(this.ThongKeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelNgay;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label labelXeDap;
        private System.Windows.Forms.Label labelXeMay;
        private System.Windows.Forms.Label labelXeHoi;
        private System.Windows.Forms.Label labelTongDoanhThu;
        private System.Windows.Forms.Panel panel1;
        private LiveCharts.WinForms.PieChart pieChart1;
    }
}