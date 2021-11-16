
namespace QLXe.CongViec
{
    partial class UpdateCongViecForm
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
            this.idXe = new System.Windows.Forms.Label();
            this.comboBoxCongViec = new System.Windows.Forms.ComboBox();
            this.comboBoxNhanVien = new System.Windows.Forms.ComboBox();
            this.pictureBoxHinhTho = new System.Windows.Forms.PictureBox();
            this.dateTimePickerNgayLay = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNgaySua = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTenTho = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBoxBangSo = new System.Windows.Forms.PictureBox();
            this.pictureBoxHinhXe = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDCV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddCongViec = new System.Windows.Forms.Button();
            this.labelLoaiXe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHinhTho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBangSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHinhXe)).BeginInit();
            this.SuspendLayout();
            // 
            // idXe
            // 
            this.idXe.AutoSize = true;
            this.idXe.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.idXe.Location = new System.Drawing.Point(116, 105);
            this.idXe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.idXe.Name = "idXe";
            this.idXe.Size = new System.Drawing.Size(30, 13);
            this.idXe.TabIndex = 53;
            this.idXe.Text = "iDXe";
            // 
            // comboBoxCongViec
            // 
            this.comboBoxCongViec.FormattingEnabled = true;
            this.comboBoxCongViec.Location = new System.Drawing.Point(497, 49);
            this.comboBoxCongViec.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCongViec.Name = "comboBoxCongViec";
            this.comboBoxCongViec.Size = new System.Drawing.Size(161, 21);
            this.comboBoxCongViec.TabIndex = 52;
            // 
            // comboBoxNhanVien
            // 
            this.comboBoxNhanVien.FormattingEnabled = true;
            this.comboBoxNhanVien.Location = new System.Drawing.Point(499, 102);
            this.comboBoxNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxNhanVien.Name = "comboBoxNhanVien";
            this.comboBoxNhanVien.Size = new System.Drawing.Size(161, 21);
            this.comboBoxNhanVien.TabIndex = 51;
            this.comboBoxNhanVien.SelectionChangeCommitted += new System.EventHandler(this.comboBoxNhanVien_SelectionChangeCommitted);
            // 
            // pictureBoxHinhTho
            // 
            this.pictureBoxHinhTho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHinhTho.Location = new System.Drawing.Point(503, 139);
            this.pictureBoxHinhTho.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxHinhTho.Name = "pictureBoxHinhTho";
            this.pictureBoxHinhTho.Size = new System.Drawing.Size(157, 89);
            this.pictureBoxHinhTho.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHinhTho.TabIndex = 49;
            this.pictureBoxHinhTho.TabStop = false;
            // 
            // dateTimePickerNgayLay
            // 
            this.dateTimePickerNgayLay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayLay.Location = new System.Drawing.Point(503, 312);
            this.dateTimePickerNgayLay.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerNgayLay.Name = "dateTimePickerNgayLay";
            this.dateTimePickerNgayLay.Size = new System.Drawing.Size(135, 20);
            this.dateTimePickerNgayLay.TabIndex = 48;
            // 
            // dateTimePickerNgaySua
            // 
            this.dateTimePickerNgaySua.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgaySua.Location = new System.Drawing.Point(503, 262);
            this.dateTimePickerNgaySua.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerNgaySua.Name = "dateTimePickerNgaySua";
            this.dateTimePickerNgaySua.Size = new System.Drawing.Size(135, 20);
            this.dateTimePickerNgaySua.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(439, 318);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Ngày lấy";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(433, 268);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Ngày Sửa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 139);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Hình Thợ";
            // 
            // labelTenTho
            // 
            this.labelTenTho.AutoSize = true;
            this.labelTenTho.Location = new System.Drawing.Point(443, 105);
            this.labelTenTho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTenTho.Name = "labelTenTho";
            this.labelTenTho.Size = new System.Drawing.Size(44, 13);
            this.labelTenTho.TabIndex = 43;
            this.labelTenTho.Text = "Tên thợ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 268);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Bảng Số";
            // 
            // pictureBoxBangSo
            // 
            this.pictureBoxBangSo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBangSo.Location = new System.Drawing.Point(82, 268);
            this.pictureBoxBangSo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxBangSo.Name = "pictureBoxBangSo";
            this.pictureBoxBangSo.Size = new System.Drawing.Size(147, 104);
            this.pictureBoxBangSo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBangSo.TabIndex = 41;
            this.pictureBoxBangSo.TabStop = false;
            // 
            // pictureBoxHinhXe
            // 
            this.pictureBoxHinhXe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHinhXe.Location = new System.Drawing.Point(82, 130);
            this.pictureBoxHinhXe.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxHinhXe.Name = "pictureBoxHinhXe";
            this.pictureBoxHinhXe.Size = new System.Drawing.Size(147, 98);
            this.pictureBoxHinhXe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHinhXe.TabIndex = 40;
            this.pictureBoxHinhXe.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Hình xe";
            // 
            // txtIDCV
            // 
            this.txtIDCV.Location = new System.Drawing.Point(96, 49);
            this.txtIDCV.Margin = new System.Windows.Forms.Padding(2);
            this.txtIDCV.Name = "txtIDCV";
            this.txtIDCV.Size = new System.Drawing.Size(94, 20);
            this.txtIDCV.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "ID";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.Location = new System.Drawing.Point(321, 403);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 37);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnAddCongViec
            // 
            this.btnAddCongViec.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddCongViec.Location = new System.Drawing.Point(521, 403);
            this.btnAddCongViec.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCongViec.Name = "btnAddCongViec";
            this.btnAddCongViec.Size = new System.Drawing.Size(117, 37);
            this.btnAddCongViec.TabIndex = 35;
            this.btnAddCongViec.Text = "Update";
            this.btnAddCongViec.UseVisualStyleBackColor = false;
            this.btnAddCongViec.Click += new System.EventHandler(this.btnAddCongViec_Click);
            // 
            // labelLoaiXe
            // 
            this.labelLoaiXe.AutoSize = true;
            this.labelLoaiXe.Location = new System.Drawing.Point(93, 92);
            this.labelLoaiXe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLoaiXe.Name = "labelLoaiXe";
            this.labelLoaiXe.Size = new System.Drawing.Size(43, 13);
            this.labelLoaiXe.TabIndex = 34;
            this.labelLoaiXe.Text = "Loại Xe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(437, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Công Việc";
            // 
            // UpdateCongViecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(775, 460);
            this.Controls.Add(this.idXe);
            this.Controls.Add(this.comboBoxCongViec);
            this.Controls.Add(this.comboBoxNhanVien);
            this.Controls.Add(this.pictureBoxHinhTho);
            this.Controls.Add(this.dateTimePickerNgayLay);
            this.Controls.Add(this.dateTimePickerNgaySua);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelTenTho);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBoxBangSo);
            this.Controls.Add(this.pictureBoxHinhXe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIDCV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddCongViec);
            this.Controls.Add(this.labelLoaiXe);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UpdateCongViecForm";
            this.Text = "UpdateCongViecForm";
            this.Load += new System.EventHandler(this.UpdateCongViecForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHinhTho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBangSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHinhXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label idXe;
        public System.Windows.Forms.PictureBox pictureBoxHinhTho;
        public System.Windows.Forms.DateTimePicker dateTimePickerNgayLay;
        public System.Windows.Forms.DateTimePicker dateTimePickerNgaySua;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label labelTenTho;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.PictureBox pictureBoxBangSo;
        public System.Windows.Forms.PictureBox pictureBoxHinhXe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddCongViec;
        public System.Windows.Forms.Label labelLoaiXe;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtIDCV;
        public System.Windows.Forms.ComboBox comboBoxCongViec;
        public System.Windows.Forms.ComboBox comboBoxNhanVien;
    }
}