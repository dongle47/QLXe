using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLXe.Tho
{
    public partial class QuanLyThoForm : Form
    {
        public QuanLyThoForm()
        {
            InitializeComponent();
        }
        ThoClass tho = new ThoClass();
        MyDB mydb = new MyDB();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        bool verif()
        {
            if (txtID.Text.Trim() == "" || txtName.Text.Trim() == "" || txtAddress.Text.Trim() == "" || txtPhone.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }
        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = tho.getTho(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[6];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void QuanLyForm_Load(object sender, EventArgs e)
        {
            radioButtonAll.Checked = true;
            radioButtonNo.Checked = true;

            SqlCommand command = new SqlCommand("SELECT * FROM THO ");
            fillGrid(command);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM THO ");
            fillGrid(command);
        }

        private void radioButtonSuaXe_CheckedChanged(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE nhomTho=@xd", mydb.getConnection);
            //command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Sửa Xe";
            //fillGrid(command);
        }

        private void BtnAdd_Click_1(object sender, EventArgs e)
        {

            ThoClass tho = new ThoClass();

            int id = 0;
            string ten = txtName.Text;
            string phone = txtPhone.Text;
            string adrs = txtAddress.Text;
            DateTime bdate = dateTimePicker.Value;
            string nhomTho = "";

            if (radioButtonSuaXe.Checked)
            {
                nhomTho = "Sửa Xe";
            }
            else if (radioButtonRuaXe.Checked)
            {
                nhomTho = "Rửa Xe";
            }
            else
            {
                nhomTho = "Trông coi xe";
            }

            MemoryStream hinhAnh = new MemoryStream();
            pictureBox1.Image.Save(hinhAnh, pictureBox1.Image.RawFormat);



            int born_year = dateTimePicker.Value.Year;
            int this_year = DateTime.Now.Year;

            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The Tho age must be between 10 and 100 year", "Invalid date of birth", MessageBoxButtons.OK);
            }
            else if (verif())
            {
                id = Int32.Parse(txtID.Text);
                if (tho.insertTho(id, ten, phone, adrs, bdate, nhomTho, hinhAnh))
                {
                    MessageBox.Show("New Tho Added", "Add Tho", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Error", "Add Tho", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Tho", MessageBoxButtons.OK);
            }
        }

        private void btnUpload_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void radioButtonRuaXe_CheckedChanged(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE nhomTho=@xd", mydb.getConnection);
            //command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Rửa Xe";
            //fillGrid(command);

        }

        private void radioButtonCoiXe_CheckedChanged(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE nhomTho=@xd", mydb.getConnection);
            //command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Trông coi xe";
            //fillGrid(command);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text;
            SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE CONCAT(id,ten) LIKE '%" + txtSearch.Text + "%'");
            fillGrid(command);
        }

        private void Export_Data_To_Word(DataGridView dataGridViewStudentList, string fileName)
        {
            if (dataGridViewStudentList.Rows.Count != 0)
            {
                int rowCount = dataGridViewStudentList.Rows.Count;
                int columnCount = dataGridViewStudentList.Columns.Count;
                Object[,] dataArray = new object[rowCount + 1, columnCount + 1];
                //add row
                int r = 0;
                for (int c = 0; c < columnCount; c++)
                {
                    for (r = 0; r < rowCount; r++)
                    {
                        dataArray[r, c] = dataGridViewStudentList.Rows[r].Cells[c].Value;
                    }
                }
                for (r = 0; r < rowCount; r++)
                {
                    string[] temp = dataGridViewStudentList.Rows[r].Cells[6].Value.ToString().Split(' ');
                    dataArray[r, 6] = temp[0];
                }
                //fileword
                Microsoft.Office.Interop.Word.Document oDoc = new Microsoft.Office.Interop.Word.Document();
                //cho phep xem qua trinh hinh thanh va xuat file; true la xem; false la ko xem
                oDoc.Application.Visible = false;
                //chinh chieu xoay cua van ban
                oDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;
                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r < rowCount; r++)
                {
                    for (int c = 0; c < columnCount; c++)
                    {
                        oTemp = oTemp + dataArray[r, c] + "\t";
                    }
                }
                //table format
                oRange.Text = oTemp;
                object seperator = Microsoft.Office.Interop.Word.WdTableFieldSeparator.wdSeparateByTabs;
                object applyBorders = true;
                object autoFit = true;
                object autoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                oRange.ConvertToTable(ref seperator, ref rowCount, ref columnCount, Type.Missing, Type.Missing,
                    ref applyBorders, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    ref autoFit, ref autoFitBehavior, Type.Missing);
                oRange.Select();
                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;
                //add header row manually
                oDoc.Application.Selection.Tables[1].Cell(1, 1).Range.Text = "ID";
                oDoc.Application.Selection.Tables[1].Cell(1, 2).Range.Text = "Tên Thợ";
                oDoc.Application.Selection.Tables[1].Cell(1, 3).Range.Text = "Số điện thoại";
                oDoc.Application.Selection.Tables[1].Cell(1, 4).Range.Text = "Địa chỉ";
                oDoc.Application.Selection.Tables[1].Cell(1, 5).Range.Text = "Ngày Sinh";
                oDoc.Application.Selection.Tables[1].Cell(1, 6).Range.Text = "Nhóm Thợ";
                oDoc.Application.Selection.Tables[1].Cell(1, 7).Range.Text = "Hình ảnh";

                //table style
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                //header text
                foreach (Microsoft.Office.Interop.Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Danh Sách Thợ";
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
                //save file
                for (r = 0; r < rowCount; r++)
                {
                    byte[] hiXe = (byte[])dataGridViewStudentList.Rows[r].Cells[6].Value;

                    MemoryStream hx = new MemoryStream(hiXe);

                    Image finalHx = (new Bitmap(Image.FromStream(hx), new Size(70, 70)));

                    Clipboard.SetDataObject(finalHx);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 7).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 7).Range.InsertParagraph();
                }
                oDoc.SaveAs(fileName);
            }
        }

        private void btnToText_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = "*.docx";
            savefile.Filter = "DOCX files(*.docx)|*.docx";

            if (savefile.ShowDialog() == DialogResult.OK && savefile.FileName.Length > 0)
            {
                Export_Data_To_Word(dataGridView1, savefile.FileName);
                MessageBox.Show("File saved!", "Message Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            string query;
            if (radioButtonYes.Checked == true)
            {
                string dateNBD = dateTimePickerNBD.Value.ToString("yyyy-MM-dd");
                string dateNKT = dateTimePickerNKT.Value.ToString("yyyy-MM-dd");
                if (radioButtonAll.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE ngaySinh BETWEEN '" + dateNBD + "' AND '" + dateNKT + "' ";
                    command = new SqlCommand(query, mydb.getConnection);

                }
                else if (radioButtonSuaXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@lx AND ngaySinh BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Sửa Xe";
                }
                else if (radioButtonRuaXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@lx AND ngaySinh BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Rửa Xe";
                }
                else if (radioButtonCoiXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@lx AND ngaySinh BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Trông coi xe";
                }
                fillGrid(command);
            }
            else if (radioButtonNo.Checked == true)
            {
                if (radioButtonAll.Checked == true)
                {
                    query = "SELECT * FROM THO ";
                    command = new SqlCommand(query, mydb.getConnection);
                }
                else if (radioButtonSuaXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Sửa Xe";
                }
                else if (radioButtonRuaXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Rửa Xe";
                }
                else if (radioButtonCoiXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Coi Xe";
                }
                fillGrid(command);
            }
        }

        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerNBD.Enabled = true;
            dateTimePickerNKT.Enabled = true;
        }

        private void radioButtonNo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerNBD.Enabled = false;
            dateTimePickerNKT.Enabled = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateTho updateTho = new UpdateTho();

            updateTho.textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateTho.txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateTho.txtPhone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateTho.txtAddress.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            updateTho.dateTimePicker.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;


            string nhomTho = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            if (nhomTho == "Rửa Xe")
            {
                updateTho.radioButtonRuaXe.Checked = true;
            }
            else if (nhomTho == "Sửa Xe")
            {
                updateTho.radioButtonSuaXe.Checked = true;
            }
            else
            {
                updateTho.radioButtonCoiXe.Checked = true;
            }

            byte[] picHinhTho;
            picHinhTho = (byte[])dataGridView1.CurrentRow.Cells[6].Value;
            MemoryStream pictureHinhTho = new MemoryStream(picHinhTho);
            updateTho.pictureBox1.Image = Image.FromStream(pictureHinhTho);

            updateTho.Show();
        }
    }
}
