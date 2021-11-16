
namespace QLXe
{
    partial class DanhSachCongViecXe
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelIdXe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(431, 280);
            this.dataGridView1.TabIndex = 0;
            // 
            // labelIdXe
            // 
            this.labelIdXe.AutoSize = true;
            this.labelIdXe.Location = new System.Drawing.Point(44, 384);
            this.labelIdXe.Name = "labelIdXe";
            this.labelIdXe.Size = new System.Drawing.Size(35, 13);
            this.labelIdXe.TabIndex = 1;
            this.labelIdXe.Text = "label1";
            // 
            // DanhSachCongViecXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(458, 314);
            this.Controls.Add(this.labelIdXe);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DanhSachCongViecXe";
            this.Text = "DanhSachCongViecXe";
            this.Load += new System.EventHandler(this.DanhSachCongViecXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label labelIdXe;
    }
}