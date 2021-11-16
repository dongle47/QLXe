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

namespace QLXe.CongViec
{
    public partial class QuanLyCongViecForm : Form
    {
        public QuanLyCongViecForm()
        {
            InitializeComponent();
        }
        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol3 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = congViec.getCV(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[4];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[5];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol3 = (DataGridViewImageColumn)dataGridView1.Columns[8];
            picCol3.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
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
                oDoc.Application.Selection.Tables[1].Cell(1, 2).Range.Text = "Loại Công Việc";
                oDoc.Application.Selection.Tables[1].Cell(1, 3).Range.Text = "ID Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 4).Range.Text = "Loại Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 5).Range.Text = "Ảnh Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 6).Range.Text = "Bảng Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 7).Range.Text = "ID Thợ";
                oDoc.Application.Selection.Tables[1].Cell(1, 8).Range.Text = "Tên Thợ";
                oDoc.Application.Selection.Tables[1].Cell(1, 9).Range.Text = "Hình Thợ";
                oDoc.Application.Selection.Tables[1].Cell(1, 10).Range.Text = "Ngày Sửa";
                oDoc.Application.Selection.Tables[1].Cell(1, 11).Range.Text = "Ngày Lấy";
                //table style
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                //header text
                foreach (Microsoft.Office.Interop.Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Danh Sách Công Việc";
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
                //save file
                for (r = 0; r < rowCount; r++)
                {
                    byte[] hinhXe = (byte[])dataGridViewStudentList.Rows[r].Cells[4].Value;

                    MemoryStream hx = new MemoryStream(hinhXe);

                    Image finalHx = (new Bitmap(Image.FromStream(hx), new Size(70, 70)));

                    Clipboard.SetDataObject(finalHx);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 5).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 5).Range.InsertParagraph();
                    //////////////////////////
                    byte[] bangXe = (byte[])dataGridViewStudentList.Rows[r].Cells[5].Value;

                    MemoryStream bx = new MemoryStream(bangXe);

                    Image finalBx = (new Bitmap(Image.FromStream(bx), new Size(70, 70)));

                    Clipboard.SetDataObject(finalBx);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 6).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 6).Range.InsertParagraph();
                    //////////////////////////
                    byte[] hinhTho = (byte[])dataGridViewStudentList.Rows[r].Cells[8].Value;

                    MemoryStream ht = new MemoryStream(hinhTho);

                    Image finalHt = (new Bitmap(Image.FromStream(ht), new Size(70, 70)));

                    Clipboard.SetDataObject(finalHt);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 9).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 9).Range.InsertParagraph();
                }
                oDoc.SaveAs(fileName);
            }
        }

        CONGVIEC congViec = new CONGVIEC();
        ThoClass tho = new ThoClass();
        MyDB mydb = new MyDB();
      


     

        private void ThongKeCongViecForm_Load(object sender, EventArgs e)
        {
            radioButtonAll.Checked = true;
            radioButtonNo.Checked = true;

            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC");
            fillGrid(command);
        }
        
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string id = textBoxSearch.Text;
            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE CONCAT(id,tenTho) LIKE '%" + textBoxSearch.Text + "%'");
            fillGrid(command);
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC");

            fillGrid(command);
        }

        private void radioButtonRuaXe_CheckedChanged(object sender, EventArgs e)
        {

            //SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE loaiCongViec =@loaiCongViec", mydb.getConnection);
            //command.Parameters.Add("@loaiCongViec", SqlDbType.NVarChar).Value = "Rửa Xe";
            //fillGrid(command);
        }

        private void radioButtonSuaXe_CheckedChanged(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE loaiCongViec =@loaiCongViec", mydb.getConnection);
            //command.Parameters.Add("@loaiCongViec", SqlDbType.NVarChar).Value = "Sửa Xe";
            //fillGrid(command);
        }

        private void radioButtonCoiXe_CheckedChanged(object sender, EventArgs e)
        {
        //    SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE loaiCongViec=@loaiCongViec", mydb.getConnection);
        //    command.Parameters.Add("@loaiCongViec", SqlDbType.NVarChar).Value = "Trông coi xe";
        //    fillGrid(command);
        }

        private void btnThemCongViec_Click(object sender, EventArgs e)
        {
            ThemCongViecForm themCongViecForm = new ThemCongViecForm();
            themCongViecForm.Show();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            string query;
            if (radioButtonYes.Checked == true)
            {
                string dateNBD = dateTimePickerNBD.Value.ToString("yyyy-MM-dd");
                string dateNKT = dateTimePickerNKT.Value.ToString("yyyy-MM-dd");
                if (radioButtonAll.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE ngaySua BETWEEN '" + dateNBD + "' AND '" + dateNKT + "' ";
                    command = new SqlCommand(query, mydb.getConnection);

                }
                else if (radioButtonRuaXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx AND ngaySua BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Rửa Xe";
                }
                else if (radioButtonSuaXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx AND ngaySua BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Sửa Xe";
                }
                else if (radioButtonCoiXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx AND ngaySua BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Trông coi xe";
                }
                fillGrid(command);
            }
            else if (radioButtonNo.Checked == true)
            {
                
                if (radioButtonAll.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC";
                    command = new SqlCommand(query, mydb.getConnection);

                }
                else if (radioButtonRuaXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Rửa Xe";
                }
                else if (radioButtonSuaXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Sửa Xe";
                }
                else if (radioButtonCoiXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Trông coi xe";
                }
                fillGrid(command);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateCongViecForm updateCongViecForm = new UpdateCongViecForm();

            updateCongViecForm.txtIDCV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateCongViecForm.comboBoxCongViec.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateCongViecForm.idXe.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateCongViecForm.labelLoaiXe.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            updateCongViecForm.dateTimePickerNgaySua.Value = (DateTime)dataGridView1.CurrentRow.Cells[9].Value;
            updateCongViecForm.dateTimePickerNgayLay.Value = (DateTime)dataGridView1.CurrentRow.Cells[10].Value;

            updateCongViecForm.comboBoxNhanVien.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            //SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE id =@id", mydb.getConnection);
            //command.Parameters.Add("@id", SqlDbType.Int).Value = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            //updateCongViecForm.comboBoxNhanVien.DataSource = tho.getTho(command);
            //updateCongViecForm.comboBoxNhanVien.DisplayMember = "ten";
            //updateCongViecForm.comboBoxNhanVien.ValueMember = "id";

            byte[] picHinhXe;
            picHinhXe = (byte[])dataGridView1.CurrentRow.Cells[4].Value;
            MemoryStream pictureHinhXe = new MemoryStream(picHinhXe);
            updateCongViecForm.pictureBoxHinhXe.Image = Image.FromStream(pictureHinhXe);

            byte[] picBangSo;
            picBangSo = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
            MemoryStream pictureBangSo = new MemoryStream(picBangSo);
            updateCongViecForm.pictureBoxBangSo.Image = Image.FromStream(pictureBangSo);

            byte[] picHinhTho;
            picHinhTho = (byte[])dataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream pictureHinhTho = new MemoryStream(picHinhTho);
            updateCongViecForm.pictureBoxHinhTho.Image = Image.FromStream(pictureHinhTho);

            //updateTho.comboBoxTho.DisplayMember = "Text";
            //updateTho.comboBoxTho.ValueMember = "Value";
            //updateTho.comboBoxTho.Items.Add(new { Text = "Rửa Xe", Value = "rua-xe" });
            //updateTho.comboBoxTho.Items.Add(new { Text = "Sửa Xe", Value = "sua-xe" });
            //updateTho.comboBoxTho.Items.Add(new { Text = "Trông coi xe", Value = "trong-coi-xe" });

            //updateTho.comboBoxTho.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();


            updateCongViecForm.Show();
        }

        private void radioButtonNo_CheckedChanged(object sender, EventArgs e)
        {
            labelNBD.Enabled = false;
            labelNKT.Enabled = false;
            dateTimePickerNBD.Enabled = false;
            dateTimePickerNKT.Enabled = false;
        }

        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            labelNBD.Enabled = true ;
            labelNKT.Enabled = true ;
            dateTimePickerNBD.Enabled = true    ;
            dateTimePickerNKT.Enabled = true    ;
        }
    }
}
