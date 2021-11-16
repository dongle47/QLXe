
namespace QLXe
{
    partial class DanhSachXeForm
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
            this.dataGridViewList = new System.Windows.Forms.DataGridView();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelLoaiXe = new System.Windows.Forms.Label();
            this.labelNgayKetThuc = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonSearchXeHoi = new System.Windows.Forms.RadioButton();
            this.radioButtonSearchXeMay = new System.Windows.Forms.RadioButton();
            this.radioButtonSearchXeDap = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelNKT = new System.Windows.Forms.Label();
            this.labelNBD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonYes = new System.Windows.Forms.RadioButton();
            this.dateTimePickerNKT = new System.Windows.Forms.DateTimePicker();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.dateTimePickerNBD = new System.Windows.Forms.DateTimePicker();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewList
            // 
            this.dataGridViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewList.Location = new System.Drawing.Point(12, 259);
            this.dataGridViewList.Name = "dataGridViewList";
            this.dataGridViewList.Size = new System.Drawing.Size(743, 262);
            this.dataGridViewList.TabIndex = 0;
            this.dataGridViewList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewList_CellContentClick);
            this.dataGridViewList.Click += new System.EventHandler(this.dataGridViewList_Click);
            this.dataGridViewList.DoubleClick += new System.EventHandler(this.dataGridViewList_DoubleClick);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonRefresh.Location = new System.Drawing.Point(320, 552);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(123, 37);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "REFRESH";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // labelLoaiXe
            // 
            this.labelLoaiXe.AutoSize = true;
            this.labelLoaiXe.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelLoaiXe.Location = new System.Drawing.Point(169, 552);
            this.labelLoaiXe.Name = "labelLoaiXe";
            this.labelLoaiXe.Size = new System.Drawing.Size(35, 13);
            this.labelLoaiXe.TabIndex = 2;
            this.labelLoaiXe.Text = "label1";
            // 
            // labelNgayKetThuc
            // 
            this.labelNgayKetThuc.AutoSize = true;
            this.labelNgayKetThuc.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelNgayKetThuc.Location = new System.Drawing.Point(96, 552);
            this.labelNgayKetThuc.Name = "labelNgayKetThuc";
            this.labelNgayKetThuc.Size = new System.Drawing.Size(35, 13);
            this.labelNgayKetThuc.TabIndex = 2;
            this.labelNgayKetThuc.Text = "label1";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelId.Location = new System.Drawing.Point(55, 552);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(35, 13);
            this.labelId.TabIndex = 2;
            this.labelId.Text = "label1";
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(531, 44);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(222, 209);
            this.pieChart1.TabIndex = 3;
            this.pieChart1.Text = "pieChart1";
            this.pieChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.pieChart1_ChildChanged);
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(172, 8);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.DarkGray;
            this.buttonSearch.Location = new System.Drawing.Point(278, 8);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(71, 21);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search By ID";
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(20, 21);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(57, 17);
            this.radioButtonAll.TabIndex = 10;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "Tất Cả";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonAll_CheckedChanged);
            // 
            // radioButtonSearchXeHoi
            // 
            this.radioButtonSearchXeHoi.AutoSize = true;
            this.radioButtonSearchXeHoi.Location = new System.Drawing.Point(254, 21);
            this.radioButtonSearchXeHoi.Name = "radioButtonSearchXeHoi";
            this.radioButtonSearchXeHoi.Size = new System.Drawing.Size(57, 17);
            this.radioButtonSearchXeHoi.TabIndex = 7;
            this.radioButtonSearchXeHoi.TabStop = true;
            this.radioButtonSearchXeHoi.Text = "Xe Hơi";
            this.radioButtonSearchXeHoi.UseVisualStyleBackColor = true;
            this.radioButtonSearchXeHoi.CheckedChanged += new System.EventHandler(this.radioButtonSearchXeHoi_CheckedChanged);
            // 
            // radioButtonSearchXeMay
            // 
            this.radioButtonSearchXeMay.AutoSize = true;
            this.radioButtonSearchXeMay.Location = new System.Drawing.Point(177, 21);
            this.radioButtonSearchXeMay.Name = "radioButtonSearchXeMay";
            this.radioButtonSearchXeMay.Size = new System.Drawing.Size(61, 17);
            this.radioButtonSearchXeMay.TabIndex = 8;
            this.radioButtonSearchXeMay.TabStop = true;
            this.radioButtonSearchXeMay.Text = "Xe Máy";
            this.radioButtonSearchXeMay.UseVisualStyleBackColor = true;
            this.radioButtonSearchXeMay.CheckedChanged += new System.EventHandler(this.radioButtonSearchXeMay_CheckedChanged);
            // 
            // radioButtonSearchXeDap
            // 
            this.radioButtonSearchXeDap.AutoSize = true;
            this.radioButtonSearchXeDap.Location = new System.Drawing.Point(94, 21);
            this.radioButtonSearchXeDap.Name = "radioButtonSearchXeDap";
            this.radioButtonSearchXeDap.Size = new System.Drawing.Size(61, 17);
            this.radioButtonSearchXeDap.TabIndex = 9;
            this.radioButtonSearchXeDap.TabStop = true;
            this.radioButtonSearchXeDap.Text = "Xe Đạp";
            this.radioButtonSearchXeDap.UseVisualStyleBackColor = true;
            this.radioButtonSearchXeDap.CheckedChanged += new System.EventHandler(this.radioButtonSearchXeDap_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.labelNKT);
            this.panel3.Controls.Add(this.labelNBD);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.radioButtonYes);
            this.panel3.Controls.Add(this.dateTimePickerNKT);
            this.panel3.Controls.Add(this.radioButtonNo);
            this.panel3.Controls.Add(this.dateTimePickerNBD);
            this.panel3.Location = new System.Drawing.Point(72, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(229, 143);
            this.panel3.TabIndex = 12;
            // 
            // labelNKT
            // 
            this.labelNKT.AutoSize = true;
            this.labelNKT.Location = new System.Drawing.Point(20, 115);
            this.labelNKT.Name = "labelNKT";
            this.labelNKT.Size = new System.Drawing.Size(29, 13);
            this.labelNKT.TabIndex = 3;
            this.labelNKT.Text = "NKT";
            // 
            // labelNBD
            // 
            this.labelNBD.AutoSize = true;
            this.labelNBD.Location = new System.Drawing.Point(20, 73);
            this.labelNBD.Name = "labelNBD";
            this.labelNBD.Size = new System.Drawing.Size(30, 13);
            this.labelNBD.TabIndex = 3;
            this.labelNBD.Text = "NBD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tìm Kiếm Theo Ngày Gửi";
            // 
            // radioButtonYes
            // 
            this.radioButtonYes.AutoSize = true;
            this.radioButtonYes.Location = new System.Drawing.Point(48, 29);
            this.radioButtonYes.Name = "radioButtonYes";
            this.radioButtonYes.Size = new System.Drawing.Size(43, 17);
            this.radioButtonYes.TabIndex = 1;
            this.radioButtonYes.TabStop = true;
            this.radioButtonYes.Text = "Yes";
            this.radioButtonYes.UseVisualStyleBackColor = true;
            this.radioButtonYes.CheckedChanged += new System.EventHandler(this.radioButtonYes_CheckedChanged);
            // 
            // dateTimePickerNKT
            // 
            this.dateTimePickerNKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNKT.Location = new System.Drawing.Point(64, 109);
            this.dateTimePickerNKT.Name = "dateTimePickerNKT";
            this.dateTimePickerNKT.Size = new System.Drawing.Size(95, 20);
            this.dateTimePickerNKT.TabIndex = 2;
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Location = new System.Drawing.Point(131, 29);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(39, 17);
            this.radioButtonNo.TabIndex = 1;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "No";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            this.radioButtonNo.CheckedChanged += new System.EventHandler(this.radioButtonNo_CheckedChanged);
            // 
            // dateTimePickerNBD
            // 
            this.dateTimePickerNBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNBD.Location = new System.Drawing.Point(64, 67);
            this.dateTimePickerNBD.Name = "dateTimePickerNBD";
            this.dateTimePickerNBD.Size = new System.Drawing.Size(95, 20);
            this.dateTimePickerNBD.TabIndex = 2;
            // 
            // buttonCheck
            // 
            this.buttonCheck.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonCheck.Location = new System.Drawing.Point(362, 147);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(80, 30);
            this.buttonCheck.TabIndex = 11;
            this.buttonCheck.Text = "CHECK";
            this.buttonCheck.UseVisualStyleBackColor = false;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.radioButtonSearchXeDap);
            this.panel1.Controls.Add(this.buttonCheck);
            this.panel1.Controls.Add(this.radioButtonSearchXeMay);
            this.panel1.Controls.Add(this.radioButtonAll);
            this.panel1.Controls.Add(this.radioButtonSearchXeHoi);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 209);
            this.panel1.TabIndex = 13;
            // 
            // DanhSachXeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(765, 601);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.labelNgayKetThuc);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.labelLoaiXe);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.dataGridViewList);
            this.Name = "DanhSachXeForm";
            this.Text = "DanhSachXeForm";
            this.Load += new System.EventHandler(this.DanhSachXeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewList;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelLoaiXe;
        private System.Windows.Forms.Label labelNgayKetThuc;
        private System.Windows.Forms.Label labelId;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.RadioButton radioButtonSearchXeHoi;
        private System.Windows.Forms.RadioButton radioButtonSearchXeMay;
        private System.Windows.Forms.RadioButton radioButtonSearchXeDap;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelNKT;
        private System.Windows.Forms.Label labelNBD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonYes;
        private System.Windows.Forms.DateTimePicker dateTimePickerNKT;
        private System.Windows.Forms.RadioButton radioButtonNo;
        private System.Windows.Forms.DateTimePicker dateTimePickerNBD;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Panel panel1;
    }
}