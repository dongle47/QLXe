
namespace QLXe
{
    partial class XoaTho
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
            this.btnRm = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelDate = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.labelNKT = new System.Windows.Forms.Label();
            this.dateTimePickerNBD = new System.Windows.Forms.DateTimePicker();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.dateTimePickerNKT = new System.Windows.Forms.DateTimePicker();
            this.labelNBD = new System.Windows.Forms.Label();
            this.radioButtonYes = new System.Windows.Forms.RadioButton();
            this.radioButtonCoiXe = new System.Windows.Forms.RadioButton();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.radioButtonRuaXe = new System.Windows.Forms.RadioButton();
            this.radioButtonSuaXe = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 257);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(497, 257);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // btnRm
            // 
            this.btnRm.BackColor = System.Drawing.Color.Crimson;
            this.btnRm.Location = new System.Drawing.Point(186, 518);
            this.btnRm.Margin = new System.Windows.Forms.Padding(2);
            this.btnRm.Name = "btnRm";
            this.btnRm.Size = new System.Drawing.Size(131, 38);
            this.btnRm.TabIndex = 4;
            this.btnRm.Text = "Remove";
            this.btnRm.UseVisualStyleBackColor = false;
            this.btnRm.Click += new System.EventHandler(this.btnRm_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSearch.Location = new System.Drawing.Point(334, 24);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 23);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(159, 27);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(171, 20);
            this.txtSearch.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tìm Kiếm Theo ID, Tên Thợ";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panelDate);
            this.panel3.Controls.Add(this.radioButtonCoiXe);
            this.panel3.Controls.Add(this.buttonCheck);
            this.panel3.Controls.Add(this.radioButtonRuaXe);
            this.panel3.Controls.Add(this.radioButtonSuaXe);
            this.panel3.Controls.Add(this.radioButtonAll);
            this.panel3.Location = new System.Drawing.Point(12, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(495, 164);
            this.panel3.TabIndex = 18;
            // 
            // panelDate
            // 
            this.panelDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDate.Controls.Add(this.label9);
            this.panelDate.Controls.Add(this.labelNKT);
            this.panelDate.Controls.Add(this.dateTimePickerNBD);
            this.panelDate.Controls.Add(this.radioButtonNo);
            this.panelDate.Controls.Add(this.dateTimePickerNKT);
            this.panelDate.Controls.Add(this.labelNBD);
            this.panelDate.Controls.Add(this.radioButtonYes);
            this.panelDate.Location = new System.Drawing.Point(44, 48);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(282, 94);
            this.panelDate.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Use Date Range";
            // 
            // labelNKT
            // 
            this.labelNKT.AutoSize = true;
            this.labelNKT.Location = new System.Drawing.Point(136, 64);
            this.labelNKT.Name = "labelNKT";
            this.labelNKT.Size = new System.Drawing.Size(29, 13);
            this.labelNKT.TabIndex = 3;
            this.labelNKT.Text = "NKT";
            // 
            // dateTimePickerNBD
            // 
            this.dateTimePickerNBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNBD.Location = new System.Drawing.Point(22, 61);
            this.dateTimePickerNBD.Name = "dateTimePickerNBD";
            this.dateTimePickerNBD.Size = new System.Drawing.Size(95, 20);
            this.dateTimePickerNBD.TabIndex = 2;
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Location = new System.Drawing.Point(164, 26);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(39, 17);
            this.radioButtonNo.TabIndex = 1;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "No";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNKT
            // 
            this.dateTimePickerNKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNKT.Location = new System.Drawing.Point(181, 61);
            this.dateTimePickerNKT.Name = "dateTimePickerNKT";
            this.dateTimePickerNKT.Size = new System.Drawing.Size(79, 20);
            this.dateTimePickerNKT.TabIndex = 2;
            // 
            // labelNBD
            // 
            this.labelNBD.AutoSize = true;
            this.labelNBD.Location = new System.Drawing.Point(-47, 59);
            this.labelNBD.Name = "labelNBD";
            this.labelNBD.Size = new System.Drawing.Size(30, 13);
            this.labelNBD.TabIndex = 3;
            this.labelNBD.Text = "NBD";
            // 
            // radioButtonYes
            // 
            this.radioButtonYes.AutoSize = true;
            this.radioButtonYes.Location = new System.Drawing.Point(77, 26);
            this.radioButtonYes.Name = "radioButtonYes";
            this.radioButtonYes.Size = new System.Drawing.Size(43, 17);
            this.radioButtonYes.TabIndex = 1;
            this.radioButtonYes.TabStop = true;
            this.radioButtonYes.Text = "Yes";
            this.radioButtonYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonCoiXe
            // 
            this.radioButtonCoiXe.AutoSize = true;
            this.radioButtonCoiXe.Location = new System.Drawing.Point(303, 7);
            this.radioButtonCoiXe.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonCoiXe.Name = "radioButtonCoiXe";
            this.radioButtonCoiXe.Size = new System.Drawing.Size(84, 17);
            this.radioButtonCoiXe.TabIndex = 10;
            this.radioButtonCoiXe.TabStop = true;
            this.radioButtonCoiXe.Text = "Trông coi xe";
            this.radioButtonCoiXe.UseVisualStyleBackColor = true;
            // 
            // buttonCheck
            // 
            this.buttonCheck.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonCheck.Location = new System.Drawing.Point(374, 92);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(80, 30);
            this.buttonCheck.TabIndex = 11;
            this.buttonCheck.Text = "CHECK";
            this.buttonCheck.UseVisualStyleBackColor = false;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // radioButtonRuaXe
            // 
            this.radioButtonRuaXe.AutoSize = true;
            this.radioButtonRuaXe.Location = new System.Drawing.Point(209, 7);
            this.radioButtonRuaXe.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonRuaXe.Name = "radioButtonRuaXe";
            this.radioButtonRuaXe.Size = new System.Drawing.Size(61, 17);
            this.radioButtonRuaXe.TabIndex = 4;
            this.radioButtonRuaXe.TabStop = true;
            this.radioButtonRuaXe.Text = "Rửa Xe";
            this.radioButtonRuaXe.UseVisualStyleBackColor = true;
            // 
            // radioButtonSuaXe
            // 
            this.radioButtonSuaXe.AutoSize = true;
            this.radioButtonSuaXe.Location = new System.Drawing.Point(122, 9);
            this.radioButtonSuaXe.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonSuaXe.Name = "radioButtonSuaXe";
            this.radioButtonSuaXe.Size = new System.Drawing.Size(60, 17);
            this.radioButtonSuaXe.TabIndex = 3;
            this.radioButtonSuaXe.TabStop = true;
            this.radioButtonSuaXe.Text = "Sửa Xe";
            this.radioButtonSuaXe.UseVisualStyleBackColor = true;
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(43, 9);
            this.radioButtonAll.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(57, 17);
            this.radioButtonAll.TabIndex = 2;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "Tất Cả";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // XoaTho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(519, 567);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnRm);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "XoaTho";
            this.Text = "XoaTho";
            this.Load += new System.EventHandler(this.XoaTho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRm;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelNKT;
        private System.Windows.Forms.DateTimePicker dateTimePickerNBD;
        private System.Windows.Forms.RadioButton radioButtonNo;
        private System.Windows.Forms.DateTimePicker dateTimePickerNKT;
        private System.Windows.Forms.Label labelNBD;
        private System.Windows.Forms.RadioButton radioButtonYes;
        private System.Windows.Forms.RadioButton radioButtonCoiXe;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.RadioButton radioButtonRuaXe;
        private System.Windows.Forms.RadioButton radioButtonSuaXe;
        private System.Windows.Forms.RadioButton radioButtonAll;
    }
}