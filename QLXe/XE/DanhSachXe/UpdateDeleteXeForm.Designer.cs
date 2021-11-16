
namespace QLXe
{
    partial class UpdateDeleteXeForm
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
            this.labelGuiTheo = new System.Windows.Forms.Label();
            this.labelThoiGianGui = new System.Windows.Forms.Label();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.numericUpDownTgGui = new System.Windows.Forms.NumericUpDown();
            this.comboBoxGuiTheo = new System.Windows.Forms.ComboBox();
            this.labelMucPhi = new System.Windows.Forms.Label();
            this.pictureBoxNguoiGui = new System.Windows.Forms.PictureBox();
            this.pictureBoxHinhXe = new System.Windows.Forms.PictureBox();
            this.labelID = new System.Windows.Forms.Label();
            this.labelLoaiXe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.labelMucPhat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTgGui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNguoiGui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHinhXe)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGuiTheo
            // 
            this.labelGuiTheo.AutoSize = true;
            this.labelGuiTheo.Location = new System.Drawing.Point(327, 22);
            this.labelGuiTheo.Name = "labelGuiTheo";
            this.labelGuiTheo.Size = new System.Drawing.Size(51, 13);
            this.labelGuiTheo.TabIndex = 1;
            this.labelGuiTheo.Text = "Gửi Theo";
            // 
            // labelThoiGianGui
            // 
            this.labelThoiGianGui.AutoSize = true;
            this.labelThoiGianGui.Location = new System.Drawing.Point(306, 58);
            this.labelThoiGianGui.Name = "labelThoiGianGui";
            this.labelThoiGianGui.Size = new System.Drawing.Size(72, 13);
            this.labelThoiGianGui.TabIndex = 1;
            this.labelThoiGianGui.Text = "Thời Gian Gửi";
            // 
            // buttonSua
            // 
            this.buttonSua.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonSua.Location = new System.Drawing.Point(394, 252);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(107, 44);
            this.buttonSua.TabIndex = 2;
            this.buttonSua.Text = "SỬA";
            this.buttonSua.UseVisualStyleBackColor = false;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // buttonXoa
            // 
            this.buttonXoa.BackColor = System.Drawing.Color.Crimson;
            this.buttonXoa.Location = new System.Drawing.Point(177, 252);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(99, 44);
            this.buttonXoa.TabIndex = 3;
            this.buttonXoa.Text = "XÓA";
            this.buttonXoa.UseVisualStyleBackColor = false;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // numericUpDownTgGui
            // 
            this.numericUpDownTgGui.Location = new System.Drawing.Point(394, 56);
            this.numericUpDownTgGui.Name = "numericUpDownTgGui";
            this.numericUpDownTgGui.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownTgGui.TabIndex = 6;
            this.numericUpDownTgGui.ValueChanged += new System.EventHandler(this.numericUpDownTgGui_ValueChanged);
            // 
            // comboBoxGuiTheo
            // 
            this.comboBoxGuiTheo.FormattingEnabled = true;
            this.comboBoxGuiTheo.Items.AddRange(new object[] {
            "Giờ",
            "Ngày",
            "Tuần",
            "Tháng"});
            this.comboBoxGuiTheo.Location = new System.Drawing.Point(394, 19);
            this.comboBoxGuiTheo.Name = "comboBoxGuiTheo";
            this.comboBoxGuiTheo.Size = new System.Drawing.Size(77, 21);
            this.comboBoxGuiTheo.TabIndex = 7;
            this.comboBoxGuiTheo.SelectionChangeCommitted += new System.EventHandler(this.comboBoxGuiTheo_SelectionChangeCommitted);
            // 
            // labelMucPhi
            // 
            this.labelMucPhi.AutoSize = true;
            this.labelMucPhi.Location = new System.Drawing.Point(331, 176);
            this.labelMucPhi.Name = "labelMucPhi";
            this.labelMucPhi.Size = new System.Drawing.Size(54, 13);
            this.labelMucPhi.TabIndex = 8;
            this.labelMucPhi.Text = "Mức Phí: ";
            // 
            // pictureBoxNguoiGui
            // 
            this.pictureBoxNguoiGui.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxNguoiGui.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxNguoiGui.Location = new System.Drawing.Point(29, 17);
            this.pictureBoxNguoiGui.Name = "pictureBoxNguoiGui";
            this.pictureBoxNguoiGui.Size = new System.Drawing.Size(100, 86);
            this.pictureBoxNguoiGui.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNguoiGui.TabIndex = 9;
            this.pictureBoxNguoiGui.TabStop = false;
            // 
            // pictureBoxHinhXe
            // 
            this.pictureBoxHinhXe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHinhXe.Location = new System.Drawing.Point(29, 131);
            this.pictureBoxHinhXe.Name = "pictureBoxHinhXe";
            this.pictureBoxHinhXe.Size = new System.Drawing.Size(100, 95);
            this.pictureBoxHinhXe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHinhXe.TabIndex = 10;
            this.pictureBoxHinhXe.TabStop = false;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelID.Location = new System.Drawing.Point(41, 259);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(46, 13);
            this.labelID.TabIndex = 11;
            this.labelID.Text = "idddddđ";
            // 
            // labelLoaiXe
            // 
            this.labelLoaiXe.AutoSize = true;
            this.labelLoaiXe.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelLoaiXe.Location = new System.Drawing.Point(41, 283);
            this.labelLoaiXe.Name = "labelLoaiXe";
            this.labelLoaiXe.Size = new System.Drawing.Size(62, 13);
            this.labelLoaiXe.TabIndex = 12;
            this.labelLoaiXe.Text = "labelLoaiXe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ngày Bắt Đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ngày Kết Thúc";
            // 
            // dateTimePickerNgayBatDau
            // 
            this.dateTimePickerNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayBatDau.Location = new System.Drawing.Point(394, 93);
            this.dateTimePickerNgayBatDau.Name = "dateTimePickerNgayBatDau";
            this.dateTimePickerNgayBatDau.Size = new System.Drawing.Size(78, 20);
            this.dateTimePickerNgayBatDau.TabIndex = 14;
            // 
            // dateTimePickerNgayKetThuc
            // 
            this.dateTimePickerNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayKetThuc.Location = new System.Drawing.Point(394, 131);
            this.dateTimePickerNgayKetThuc.Name = "dateTimePickerNgayKetThuc";
            this.dateTimePickerNgayKetThuc.Size = new System.Drawing.Size(78, 20);
            this.dateTimePickerNgayKetThuc.TabIndex = 15;
            // 
            // labelMucPhat
            // 
            this.labelMucPhat.AutoSize = true;
            this.labelMucPhat.Location = new System.Drawing.Point(327, 213);
            this.labelMucPhat.Name = "labelMucPhat";
            this.labelMucPhat.Size = new System.Drawing.Size(53, 13);
            this.labelMucPhat.TabIndex = 16;
            this.labelMucPhat.Text = "Mức Phạt";
            // 
            // UpdateDeleteXeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(607, 315);
            this.Controls.Add(this.labelMucPhat);
            this.Controls.Add(this.dateTimePickerNgayKetThuc);
            this.Controls.Add(this.dateTimePickerNgayBatDau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLoaiXe);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.pictureBoxHinhXe);
            this.Controls.Add(this.pictureBoxNguoiGui);
            this.Controls.Add(this.labelMucPhi);
            this.Controls.Add(this.comboBoxGuiTheo);
            this.Controls.Add(this.numericUpDownTgGui);
            this.Controls.Add(this.buttonXoa);
            this.Controls.Add(this.buttonSua);
            this.Controls.Add(this.labelThoiGianGui);
            this.Controls.Add(this.labelGuiTheo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "UpdateDeleteXeForm";
            this.Text = "UpdateDeleteXeForm";
            this.Load += new System.EventHandler(this.UpdateDeleteXeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTgGui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNguoiGui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHinhXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGuiTheo;
        private System.Windows.Forms.Label labelThoiGianGui;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonXoa;
        public System.Windows.Forms.NumericUpDown numericUpDownTgGui;
        public System.Windows.Forms.ComboBox comboBoxGuiTheo;
        public System.Windows.Forms.Label labelMucPhi;
        public System.Windows.Forms.PictureBox pictureBoxNguoiGui;
        public System.Windows.Forms.PictureBox pictureBoxHinhXe;
        public System.Windows.Forms.Label labelID;
        public System.Windows.Forms.Label labelLoaiXe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dateTimePickerNgayBatDau;
        public System.Windows.Forms.DateTimePicker dateTimePickerNgayKetThuc;
        public System.Windows.Forms.Label labelMucPhat;
    }
}