
namespace QLXe.Tho
{
    partial class ThongKeThoForm
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
            this.label22 = new System.Windows.Forms.Label();
            this.labelCoiXe = new System.Windows.Forms.Label();
            this.labelRuaXe = new System.Windows.Forms.Label();
            this.labelSuaXe = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(286, 2);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(281, 227);
            this.pieChart1.TabIndex = 8;
            this.pieChart1.Text = "pieChart1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.labelCoiXe);
            this.panel1.Controls.Add(this.labelRuaXe);
            this.panel1.Controls.Add(this.labelSuaXe);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 227);
            this.panel1.TabIndex = 7;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(100, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "THỐNG KÊ THỢ";
            // 
            // labelCoiXe
            // 
            this.labelCoiXe.Location = new System.Drawing.Point(31, 156);
            this.labelCoiXe.Name = "labelCoiXe";
            this.labelCoiXe.Size = new System.Drawing.Size(100, 23);
            this.labelCoiXe.TabIndex = 1;
            this.labelCoiXe.Text = "Số thợ trông coi xe";
            // 
            // labelRuaXe
            // 
            this.labelRuaXe.Location = new System.Drawing.Point(31, 110);
            this.labelRuaXe.Name = "labelRuaXe";
            this.labelRuaXe.Size = new System.Drawing.Size(100, 23);
            this.labelRuaXe.TabIndex = 1;
            this.labelRuaXe.Text = "Số thợ rủa xe";
            // 
            // labelSuaXe
            // 
            this.labelSuaXe.Location = new System.Drawing.Point(31, 68);
            this.labelSuaXe.Name = "labelSuaXe";
            this.labelSuaXe.Size = new System.Drawing.Size(100, 23);
            this.labelSuaXe.TabIndex = 1;
            this.labelSuaXe.Text = "Số thợ sửa xe";
            // 
            // ThongKeThoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(581, 234);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ThongKeThoForm";
            this.Text = "ThongKeThoForm";
            this.Load += new System.EventHandler(this.ThongKeThoForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label labelCoiXe;
        private System.Windows.Forms.Label labelRuaXe;
        private System.Windows.Forms.Label labelSuaXe;
    }
}