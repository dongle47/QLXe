
namespace QLXe
{
    partial class RemoveContract
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
            this.radioButtonChoThue = new System.Windows.Forms.RadioButton();
            this.radioButtonThue = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.labelNKT = new System.Windows.Forms.Label();
            this.labelNBD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonYes = new System.Windows.Forms.RadioButton();
            this.dateTimePickerNKT = new System.Windows.Forms.DateTimePicker();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.dateTimePickerNBD = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 230);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(717, 224);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // radioButtonChoThue
            // 
            this.radioButtonChoThue.AutoSize = true;
            this.radioButtonChoThue.Location = new System.Drawing.Point(159, 167);
            this.radioButtonChoThue.Name = "radioButtonChoThue";
            this.radioButtonChoThue.Size = new System.Drawing.Size(72, 17);
            this.radioButtonChoThue.TabIndex = 1;
            this.radioButtonChoThue.TabStop = true;
            this.radioButtonChoThue.Text = "Cho Thuê";
            this.radioButtonChoThue.UseVisualStyleBackColor = true;
            this.radioButtonChoThue.CheckedChanged += new System.EventHandler(this.radioButtonChoThue_CheckedChanged);
            // 
            // radioButtonThue
            // 
            this.radioButtonThue.AutoSize = true;
            this.radioButtonThue.Location = new System.Drawing.Point(159, 122);
            this.radioButtonThue.Name = "radioButtonThue";
            this.radioButtonThue.Size = new System.Drawing.Size(50, 17);
            this.radioButtonThue.TabIndex = 1;
            this.radioButtonThue.TabStop = true;
            this.radioButtonThue.Text = "Thuê";
            this.radioButtonThue.UseVisualStyleBackColor = true;
            this.radioButtonThue.CheckedChanged += new System.EventHandler(this.radioButtonThue_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm Kiếm Theo ID, Tên Chủ Xe";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(329, 18);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearch.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonSearch.Location = new System.Drawing.Point(444, 16);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.Color.Crimson;
            this.buttonRemove.Location = new System.Drawing.Point(313, 482);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(131, 36);
            this.buttonRemove.TabIndex = 5;
            this.buttonRemove.Text = "REMOVE";
            this.buttonRemove.UseVisualStyleBackColor = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.buttonCheck);
            this.panel3.Controls.Add(this.labelNKT);
            this.panel3.Controls.Add(this.labelNBD);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.radioButtonYes);
            this.panel3.Controls.Add(this.dateTimePickerNKT);
            this.panel3.Controls.Add(this.radioButtonNo);
            this.panel3.Controls.Add(this.dateTimePickerNBD);
            this.panel3.Location = new System.Drawing.Point(287, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(366, 153);
            this.panel3.TabIndex = 9;
            // 
            // buttonCheck
            // 
            this.buttonCheck.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonCheck.Location = new System.Drawing.Point(150, 115);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 4;
            this.buttonCheck.Text = "CHECK";
            this.buttonCheck.UseVisualStyleBackColor = false;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // labelNKT
            // 
            this.labelNKT.AutoSize = true;
            this.labelNKT.Location = new System.Drawing.Point(213, 73);
            this.labelNKT.Name = "labelNKT";
            this.labelNKT.Size = new System.Drawing.Size(29, 13);
            this.labelNKT.TabIndex = 3;
            this.labelNKT.Text = "NKT";
            // 
            // labelNBD
            // 
            this.labelNBD.AutoSize = true;
            this.labelNBD.Location = new System.Drawing.Point(28, 73);
            this.labelNBD.Name = "labelNBD";
            this.labelNBD.Size = new System.Drawing.Size(30, 13);
            this.labelNBD.TabIndex = 3;
            this.labelNBD.Text = "NBD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tìm Kiếm Theo Ngày Bắt Đầu HĐ";
            // 
            // radioButtonYes
            // 
            this.radioButtonYes.AutoSize = true;
            this.radioButtonYes.Location = new System.Drawing.Point(136, 39);
            this.radioButtonYes.Name = "radioButtonYes";
            this.radioButtonYes.Size = new System.Drawing.Size(43, 17);
            this.radioButtonYes.TabIndex = 1;
            this.radioButtonYes.TabStop = true;
            this.radioButtonYes.Text = "Yes";
            this.radioButtonYes.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNKT
            // 
            this.dateTimePickerNKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNKT.Location = new System.Drawing.Point(248, 67);
            this.dateTimePickerNKT.Name = "dateTimePickerNKT";
            this.dateTimePickerNKT.Size = new System.Drawing.Size(95, 20);
            this.dateTimePickerNKT.TabIndex = 2;
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Location = new System.Drawing.Point(216, 39);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(39, 17);
            this.radioButtonNo.TabIndex = 1;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "No";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNBD
            // 
            this.dateTimePickerNBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNBD.Location = new System.Drawing.Point(64, 67);
            this.dateTimePickerNBD.Name = "dateTimePickerNBD";
            this.dateTimePickerNBD.Size = new System.Drawing.Size(95, 20);
            this.dateTimePickerNBD.TabIndex = 2;
            // 
            // RemoveContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(741, 530);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonThue);
            this.Controls.Add(this.radioButtonChoThue);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RemoveContract";
            this.Text = "RemoveContractForm";
            this.Load += new System.EventHandler(this.RemoveContract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioButtonChoThue;
        private System.Windows.Forms.RadioButton radioButtonThue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelNKT;
        private System.Windows.Forms.Label labelNBD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonYes;
        private System.Windows.Forms.DateTimePicker dateTimePickerNKT;
        private System.Windows.Forms.RadioButton radioButtonNo;
        private System.Windows.Forms.DateTimePicker dateTimePickerNBD;
        private System.Windows.Forms.Button buttonCheck;
    }
}