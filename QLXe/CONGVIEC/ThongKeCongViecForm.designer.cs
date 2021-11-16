
namespace QLXe
{
    partial class ThongKeCongViecForm
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
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTongDt = new System.Windows.Forms.Label();
            this.labelDtCoi = new System.Windows.Forms.Label();
            this.labelDtRua = new System.Windows.Forms.Label();
            this.labelDtSua = new System.Windows.Forms.Label();
            this.labelNgay = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(311, 0);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(324, 300);
            this.pieChart1.TabIndex = 10;
            this.pieChart1.Text = "pieChart1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelTongDt);
            this.panel1.Controls.Add(this.labelDtCoi);
            this.panel1.Controls.Add(this.labelDtRua);
            this.panel1.Controls.Add(this.labelDtSua);
            this.panel1.Controls.Add(this.labelNgay);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 228);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelTongDt
            // 
            this.labelTongDt.AutoSize = true;
            this.labelTongDt.Location = new System.Drawing.Point(38, 186);
            this.labelTongDt.Name = "labelTongDt";
            this.labelTongDt.Size = new System.Drawing.Size(89, 13);
            this.labelTongDt.TabIndex = 12;
            this.labelTongDt.Text = "Tổng Doanh Thu";
            // 
            // labelDtCoi
            // 
            this.labelDtCoi.AutoSize = true;
            this.labelDtCoi.Location = new System.Drawing.Point(38, 144);
            this.labelDtCoi.Name = "labelDtCoi";
            this.labelDtCoi.Size = new System.Drawing.Size(35, 13);
            this.labelDtCoi.TabIndex = 4;
            this.labelDtCoi.Text = "label1";
            // 
            // labelDtRua
            // 
            this.labelDtRua.AutoSize = true;
            this.labelDtRua.Location = new System.Drawing.Point(38, 103);
            this.labelDtRua.Name = "labelDtRua";
            this.labelDtRua.Size = new System.Drawing.Size(35, 13);
            this.labelDtRua.TabIndex = 4;
            this.labelDtRua.Text = "label1";
            // 
            // labelDtSua
            // 
            this.labelDtSua.AutoSize = true;
            this.labelDtSua.Location = new System.Drawing.Point(38, 63);
            this.labelDtSua.Name = "labelDtSua";
            this.labelDtSua.Size = new System.Drawing.Size(35, 13);
            this.labelDtSua.TabIndex = 4;
            this.labelDtSua.Text = "label1";
            // 
            // labelNgay
            // 
            this.labelNgay.AutoSize = true;
            this.labelNgay.Location = new System.Drawing.Point(81, 31);
            this.labelNgay.Name = "labelNgay";
            this.labelNgay.Size = new System.Drawing.Size(35, 13);
            this.labelNgay.TabIndex = 3;
            this.labelNgay.Text = "label1";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(63, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(192, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "THỐNG KÊ DOANH THU CÔNG VIỆC";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.Location = new System.Drawing.Point(95, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 31);
            this.button1.TabIndex = 11;
            this.button1.Text = "TO TEXT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ThongKeCongViecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(638, 303);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ThongKeCongViecForm";
            this.Text = "ThongKeCongViecForm";
            this.Load += new System.EventHandler(this.ThongKeCongViecForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label labelNgay;
        private System.Windows.Forms.Label labelDtCoi;
        private System.Windows.Forms.Label labelDtRua;
        private System.Windows.Forms.Label labelDtSua;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTongDt;
    }
}