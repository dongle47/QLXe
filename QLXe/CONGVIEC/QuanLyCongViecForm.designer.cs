
namespace QLXe.CongViec
{
    partial class QuanLyCongViecForm
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
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnToText = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.radioButtonCoiXe = new System.Windows.Forms.RadioButton();
            this.radioButtonSuaXe = new System.Windows.Forms.RadioButton();
            this.radioButtonRuaXe = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.btnThemCongViec = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCheck = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerNKT = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNBD = new System.Windows.Forms.DateTimePicker();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.radioButtonYes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNBD = new System.Windows.Forms.Label();
            this.labelNKT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(177, 32);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(139, 13);
            this.labelSearch.TabIndex = 18;
            this.labelSearch.Text = "Tìm Kiếm Theo ID, Tên Thợ";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(326, 25);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(179, 20);
            this.textBoxSearch.TabIndex = 17;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonSearch.Location = new System.Drawing.Point(511, 22);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 16;
            this.buttonSearch.Text = "SEARCH";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 301);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(801, 333);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // btnToText
            // 
            this.btnToText.BackColor = System.Drawing.Color.SteelBlue;
            this.btnToText.Location = new System.Drawing.Point(180, 663);
            this.btnToText.Margin = new System.Windows.Forms.Padding(2);
            this.btnToText.Name = "btnToText";
            this.btnToText.Size = new System.Drawing.Size(126, 39);
            this.btnToText.TabIndex = 23;
            this.btnToText.Text = "To Text";
            this.btnToText.UseVisualStyleBackColor = false;
            this.btnToText.Click += new System.EventHandler(this.btnToText_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPrint.Location = new System.Drawing.Point(511, 663);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(142, 39);
            this.btnPrint.TabIndex = 24;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // radioButtonCoiXe
            // 
            this.radioButtonCoiXe.AutoSize = true;
            this.radioButtonCoiXe.Location = new System.Drawing.Point(416, 14);
            this.radioButtonCoiXe.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonCoiXe.Name = "radioButtonCoiXe";
            this.radioButtonCoiXe.Size = new System.Drawing.Size(87, 17);
            this.radioButtonCoiXe.TabIndex = 28;
            this.radioButtonCoiXe.TabStop = true;
            this.radioButtonCoiXe.Text = "Trông Coi Xe";
            this.radioButtonCoiXe.UseVisualStyleBackColor = true;
            this.radioButtonCoiXe.CheckedChanged += new System.EventHandler(this.radioButtonCoiXe_CheckedChanged);
            // 
            // radioButtonSuaXe
            // 
            this.radioButtonSuaXe.AutoSize = true;
            this.radioButtonSuaXe.Location = new System.Drawing.Point(288, 14);
            this.radioButtonSuaXe.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonSuaXe.Name = "radioButtonSuaXe";
            this.radioButtonSuaXe.Size = new System.Drawing.Size(60, 17);
            this.radioButtonSuaXe.TabIndex = 27;
            this.radioButtonSuaXe.TabStop = true;
            this.radioButtonSuaXe.Text = "Sửa Xe";
            this.radioButtonSuaXe.UseVisualStyleBackColor = true;
            this.radioButtonSuaXe.CheckedChanged += new System.EventHandler(this.radioButtonSuaXe_CheckedChanged);
            // 
            // radioButtonRuaXe
            // 
            this.radioButtonRuaXe.AutoSize = true;
            this.radioButtonRuaXe.Location = new System.Drawing.Point(150, 14);
            this.radioButtonRuaXe.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonRuaXe.Name = "radioButtonRuaXe";
            this.radioButtonRuaXe.Size = new System.Drawing.Size(61, 17);
            this.radioButtonRuaXe.TabIndex = 26;
            this.radioButtonRuaXe.TabStop = true;
            this.radioButtonRuaXe.Text = "Rửa Xe";
            this.radioButtonRuaXe.UseVisualStyleBackColor = true;
            this.radioButtonRuaXe.CheckedChanged += new System.EventHandler(this.radioButtonRuaXe_CheckedChanged);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(36, 14);
            this.radioButtonAll.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(57, 17);
            this.radioButtonAll.TabIndex = 25;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "Tất Cả";
            this.radioButtonAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonAll_CheckedChanged);
            // 
            // btnThemCongViec
            // 
            this.btnThemCongViec.BackColor = System.Drawing.Color.MediumPurple;
            this.btnThemCongViec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThemCongViec.Location = new System.Drawing.Point(24, 118);
            this.btnThemCongViec.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemCongViec.Name = "btnThemCongViec";
            this.btnThemCongViec.Size = new System.Drawing.Size(64, 112);
            this.btnThemCongViec.TabIndex = 29;
            this.btnThemCongViec.Text = "Thêm Công Việc";
            this.btnThemCongViec.UseVisualStyleBackColor = false;
            this.btnThemCongViec.Click += new System.EventHandler(this.btnThemCongViec_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.radioButtonCoiXe);
            this.panel1.Controls.Add(this.radioButtonAll);
            this.panel1.Controls.Add(this.radioButtonRuaXe);
            this.panel1.Controls.Add(this.radioButtonSuaXe);
            this.panel1.Location = new System.Drawing.Point(108, 69);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 200);
            this.panel1.TabIndex = 30;
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCheck.Location = new System.Drawing.Point(492, 122);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(135, 38);
            this.btnCheck.TabIndex = 30;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelNKT);
            this.panel2.Controls.Add(this.labelNBD);
            this.panel2.Controls.Add(this.dateTimePickerNKT);
            this.panel2.Controls.Add(this.dateTimePickerNBD);
            this.panel2.Controls.Add(this.radioButtonNo);
            this.panel2.Controls.Add(this.radioButtonYes);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(91, 35);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 125);
            this.panel2.TabIndex = 29;
            // 
            // dateTimePickerNKT
            // 
            this.dateTimePickerNKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNKT.Location = new System.Drawing.Point(226, 78);
            this.dateTimePickerNKT.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerNKT.Name = "dateTimePickerNKT";
            this.dateTimePickerNKT.Size = new System.Drawing.Size(97, 20);
            this.dateTimePickerNKT.TabIndex = 4;
            // 
            // dateTimePickerNBD
            // 
            this.dateTimePickerNBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNBD.Location = new System.Drawing.Point(58, 78);
            this.dateTimePickerNBD.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerNBD.Name = "dateTimePickerNBD";
            this.dateTimePickerNBD.Size = new System.Drawing.Size(95, 20);
            this.dateTimePickerNBD.TabIndex = 3;
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Location = new System.Drawing.Point(196, 45);
            this.radioButtonNo.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(39, 17);
            this.radioButtonNo.TabIndex = 2;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "No";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            this.radioButtonNo.CheckedChanged += new System.EventHandler(this.radioButtonNo_CheckedChanged);
            // 
            // radioButtonYes
            // 
            this.radioButtonYes.AutoSize = true;
            this.radioButtonYes.Location = new System.Drawing.Point(102, 45);
            this.radioButtonYes.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonYes.Name = "radioButtonYes";
            this.radioButtonYes.Size = new System.Drawing.Size(43, 17);
            this.radioButtonYes.TabIndex = 1;
            this.radioButtonYes.TabStop = true;
            this.radioButtonYes.Text = "Yes";
            this.radioButtonYes.UseVisualStyleBackColor = true;
            this.radioButtonYes.CheckedChanged += new System.EventHandler(this.radioButtonYes_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm Kiếm Theo Ngày Sửa";
            // 
            // labelNBD
            // 
            this.labelNBD.AutoSize = true;
            this.labelNBD.Location = new System.Drawing.Point(23, 84);
            this.labelNBD.Name = "labelNBD";
            this.labelNBD.Size = new System.Drawing.Size(30, 13);
            this.labelNBD.TabIndex = 5;
            this.labelNBD.Text = "NBĐ";
            // 
            // labelNKT
            // 
            this.labelNKT.AutoSize = true;
            this.labelNKT.Location = new System.Drawing.Point(193, 84);
            this.labelNKT.Name = "labelNKT";
            this.labelNKT.Size = new System.Drawing.Size(29, 13);
            this.labelNKT.TabIndex = 5;
            this.labelNKT.Text = "NKT";
            // 
            // QuanLyCongViecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(823, 727);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnThemCongViec);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnToText);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuanLyCongViecForm";
            this.Text = "ThongKeCongViecForm";
            this.Load += new System.EventHandler(this.ThongKeCongViecForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnToText;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton radioButtonCoiXe;
        private System.Windows.Forms.RadioButton radioButtonSuaXe;
        private System.Windows.Forms.RadioButton radioButtonRuaXe;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.Button btnThemCongViec;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerNKT;
        private System.Windows.Forms.DateTimePicker dateTimePickerNBD;
        private System.Windows.Forms.RadioButton radioButtonNo;
        private System.Windows.Forms.RadioButton radioButtonYes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNKT;
        private System.Windows.Forms.Label labelNBD;
    }
}