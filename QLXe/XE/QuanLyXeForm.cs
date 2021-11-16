using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace QLXe
{
    public partial class QuanLyXeForm : Form
    {
        public QuanLyXeForm()
        {
            InitializeComponent();
        }
        MyDB mydb = new MyDB();
        XE xe = new XE();
        int maxChoTrong = Globals.maxChoTrong;
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string loaiXe = "";
            int mucPhat = 0;
            int soChoTrong = 0;
            if (radioButtonXeDap.Checked)
            {
                loaiXe = "Xe Đạp";
                soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeDap());
            }
            else if (radioButtonXeMay.Checked)
            {
                loaiXe = "Xe Máy";
                soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeMay());
            }
            else if (radioButtonXeHoi.Checked)
            {
                loaiXe = "Xe Hơi";
                soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeHoi());
            }
            MemoryStream nguoiGuiHieuXe = new MemoryStream();
            MemoryStream hinhXeBangSo = new MemoryStream();
            string guiTheo = comboBoxGuiTheo.SelectedItem.ToString();
            int thoiGianGui = Convert.ToInt32(numericUpDownThoiGianGui.Value);
            int mucPhi = xe.MucPhi(loaiXe, guiTheo, thoiGianGui);
            DateTime ngayBatDau = dateTimePickerNgayBatDau.Value;
            DateTime ngayKetThuc = dateTimePickerNgayKetThuc.Value;
            if (verif() == true)
            {
                if (soChoTrong != 0)
                {
                    pictureBoxNguoiGuiHoacHieuXe.Image.Save(nguoiGuiHieuXe, pictureBoxNguoiGuiHoacHieuXe.Image.RawFormat);
                    pictureBoxHinhXeHoacBangSo.Image.Save(hinhXeBangSo, pictureBoxHinhXeHoacBangSo.Image.RawFormat);
                    if (xe.insertXe(loaiXe, nguoiGuiHieuXe, hinhXeBangSo, guiTheo, thoiGianGui, mucPhi, mucPhat, ngayBatDau, ngayKetThuc))
                    {
                        MessageBox.Show("Xe Đã Được Thêm", "Thêm Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Thêm Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Đã Hết Chỗ Trống", "Thêm Xe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin", "Thêm Xe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void radioButtonXeDap_Click(object sender, EventArgs e)
        {
            labelNguoiGuiHoacHieuXe.Text = "Người Gửi";
            labelHinhXeHoacBangSo.Text = "Hình Xe";
            int soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeDap());
            labelSoChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }
        private void radioButtonXeMay_Click(object sender, EventArgs e)
        {
            labelNguoiGuiHoacHieuXe.Text = "Người Gửi";
            labelHinhXeHoacBangSo.Text = "Bảng Số";
            int soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeMay());
            labelSoChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }
        private void radioButtonXeHoi_Click(object sender, EventArgs e)
        {
            labelHinhXeHoacBangSo.Text = "Bảng Số";
            labelNguoiGuiHoacHieuXe.Text = "Hiệu Xe";
            int soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeHoi());
            labelSoChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }

        private void numericUpDownThoiGianGui_ValueChanged(object sender, EventArgs e)
        {
            string loaiXe = "";
            if (radioButtonXeDap.Checked)
            {
                loaiXe = "Xe Đạp";
            }
            else if (radioButtonXeMay.Checked)
            {
                loaiXe = "Xe Máy";
            }
            else if (radioButtonXeHoi.Checked)
            {
                loaiXe = "Xe Hơi";
            }
            string guiTheo = comboBoxGuiTheo.SelectedItem.ToString();
            int thoiGianGui = Convert.ToInt32(numericUpDownThoiGianGui.Value);
            int mucPhi = xe.MucPhi(loaiXe, guiTheo, thoiGianGui);
            labelMucPhi.Text = "Mức Phí: " + mucPhi;

            int tgN = 0;
            int tgG = 0;
            if (guiTheo == "Giờ")
            {
                tgG = 1;
            }
            else if (guiTheo == "Ngày")
            {
                tgN = 1;
            }
            else if (guiTheo == "Tuần")
            {
                tgN = 7;
            }
            else if (guiTheo == "Tháng")
            {
                tgN = DateTime.DaysInMonth(dateTimePickerNgayBatDau.Value.Year, dateTimePickerNgayBatDau.Value.Month);
            }
            TimeSpan tgThem;
            if (guiTheo == "Giờ")
            {
                tgThem = new System.TimeSpan(0, tgG + thoiGianGui, 0, 0);
            }
            else
            {
                tgThem = new System.TimeSpan(tgN * thoiGianGui, 0, 0, 0);
            }
            dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value + tgThem;
        }

        private void QuanLyXeForm_Load(object sender, EventArgs e)
        {
            comboBoxGuiTheo.SelectedItem = "Giờ";
            radioButtonAll.Checked = true;
            radioButtonNo.Checked = true;
            radioButtonXeDap.Checked = true;
            
            labelSoChoTrong.Text = "Số Lượng Chỗ Trống";
            int soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeDap());
            labelSoChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
            //this line load data into 
            SqlCommand command = new SqlCommand("SELECT * FROM XE");
            dataGridView1.ReadOnly = true;
            //xu ly hinh anh
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = xe.getXe(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[3];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 70;
            dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[7].Width = 70;

            labelSoLuong.Text = "Số Lượng Xe: " + xe.totalXe();
            soChoTrong = maxChoTrong*3 - Convert.ToInt32(xe.totalXe());
            labelSearchChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }

        private void buttonUpNguoiGui_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxNguoiGuiHoacHieuXe.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonUpHinhXe_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxHinhXeHoacBangSo.Image = Image.FromFile(opf.FileName);
            }
        }

        private void comboBoxGuiTheo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string loaiXe = "";
            if (radioButtonXeDap.Checked)
            {
                loaiXe = "Xe Đạp";
            }
            else if (radioButtonXeMay.Checked)
            {
                loaiXe = "Xe Máy";
            }
            else if (radioButtonXeHoi.Checked)
            {
                loaiXe = "Xe Hơi";
            }
            string guiTheo = comboBoxGuiTheo.SelectedItem.ToString();
            int thoiGianGui = Convert.ToInt32(numericUpDownThoiGianGui.Value);
            int mucPhi = xe.MucPhi(loaiXe, guiTheo, thoiGianGui);
            labelMucPhi.Text = "Mức Phí: " + mucPhi;
        }
        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand("SELECT * FROM XE");
            //fillGrid(command);
            //labelSoLuong.Text = "Số Lượng Xe: " + xe.totalXe();
            //int soChoTrong = 15 - Convert.ToInt32(xe.totalXe());
            //labelSearchChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }
        private void radioButtonSearchXeDap_CheckedChanged(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE loaiXe=@xd", mydb.getConnection);
            //command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Đạp";
            //fillGrid(command);
            //labelSoLuong.Text = "Số Lượng Xe Đạp: " + xe.totalXeDap();
            //int soChoTrong = 5 - Convert.ToInt32(xe.totalXeDap());
            //labelSearchChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }

        private void radioButtonSearchXeMay_CheckedChanged(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE loaiXe=@xm", mydb.getConnection);
            //command.Parameters.Add("@xm", SqlDbType.NVarChar).Value = "Xe Máy";
            //fillGrid(command);
            //labelSoLuong.Text = "Số Lượng Xe Máy: " + xe.totalXeMay();
            //int soChoTrong = 5 - Convert.ToInt32(xe.totalXeMay());
            //labelSearchChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }

        private void radioButtonSearchXeHoi_CheckedChanged(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE loaiXe=@xh", mydb.getConnection);
            //command.Parameters.Add("@xh", SqlDbType.NVarChar).Value = "Xe Hơi";
            //fillGrid(command);
            //labelSoLuong.Text = "Số Lượng Xe Hơi: " + xe.totalXeHoi();
            //int soChoTrong = 5 - Convert.ToInt32(xe.totalXeHoi());
            //labelSearchChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string id = textBoxSearch.Text;
            SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE id="+id);
            fillGrid(command);
        }
        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = xe.getXe(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[3];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
        bool verif()
        {
            if (comboBoxGuiTheo.SelectedItem.ToString() == ""
                || pictureBoxHinhXeHoacBangSo.Image == null || pictureBoxNguoiGuiHoacHieuXe.Image == null

                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
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

        private void buttonToText_Click(object sender, EventArgs e)
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
                oDoc.Application.Selection.Tables[1].Cell(1, 2).Range.Text = "Loại Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 3).Range.Text = "Người Gửi";
                oDoc.Application.Selection.Tables[1].Cell(1, 4).Range.Text = "Hình Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 5).Range.Text = "Gửi Theo";
                oDoc.Application.Selection.Tables[1].Cell(1, 6).Range.Text = "Thời Gian Gửi";
                oDoc.Application.Selection.Tables[1].Cell(1, 7).Range.Text = "Mức Phí";
                oDoc.Application.Selection.Tables[1].Cell(1, 8).Range.Text = "Mức Phạt";
                oDoc.Application.Selection.Tables[1].Cell(1, 9).Range.Text = "Ngày Bắt Đầu";
                oDoc.Application.Selection.Tables[1].Cell(1, 10).Range.Text ="Ngày Kết Thúc";
                //table style
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                //header text
                foreach (Microsoft.Office.Interop.Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Danh Sách Xe";
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
                //save file
                for (r = 0; r < rowCount; r++)
                {
                    byte[] ngGui = (byte[])dataGridViewStudentList.Rows[r].Cells[2].Value;
                    byte[] hiXe = (byte[])dataGridViewStudentList.Rows[r].Cells[3].Value;

                    MemoryStream ng = new MemoryStream(ngGui);
                    MemoryStream hx = new MemoryStream(hiXe);

                    Image finalNg = (new Bitmap(Image.FromStream(ng), new Size(70, 70)));
                    Image finalHx = (new Bitmap(Image.FromStream(hx), new Size(70, 70)));

                    Clipboard.SetDataObject(finalNg);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 3).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 3).Range.InsertParagraph();

                    Clipboard.SetDataObject(finalHx);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 4).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 4).Range.InsertParagraph();
                }
                oDoc.SaveAs(fileName);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateDeleteXeForm upDeXe = new UpdateDeleteXeForm();
            //loai xe
            upDeXe.labelLoaiXe.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //gui theo
            upDeXe.labelID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string guiTheo = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            upDeXe.comboBoxGuiTheo.SelectedItem = guiTheo;
            //thoi gian gui
            upDeXe.numericUpDownTgGui.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[5].Value);
            //muc phi
            int mucPhi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value);
            upDeXe.labelMucPhi.Text = "Mức Phí: " + mucPhi;
            //muc phat
            int mucPhat = Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value);
            upDeXe.labelMucPhat.Text = "Mức Phạt: " + mucPhat;
            //
            upDeXe.dateTimePickerNgayBatDau.Value = (DateTime)dataGridView1.CurrentRow.Cells[8].Value;
            upDeXe.dateTimePickerNgayKetThuc.Value = (DateTime)dataGridView1.CurrentRow.Cells[9].Value;

            //xu ly hinh anh
            byte[] pic1;
            pic1 = (byte[])dataGridView1.CurrentRow.Cells[2].Value;
            MemoryStream picture1 = new MemoryStream(pic1);
            upDeXe.pictureBoxNguoiGui.Image = Image.FromStream(picture1);

            byte[] pic2;
            pic2 = (byte[])dataGridView1.CurrentRow.Cells[3].Value;
            MemoryStream picture2 = new MemoryStream(pic2);
            upDeXe.pictureBoxHinhXe.Image = Image.FromStream(picture2);


            upDeXe.Show();

            
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
            labelNBD.Enabled = true;
            labelNKT.Enabled = true;
            dateTimePickerNBD.Enabled = true;
            dateTimePickerNKT.Enabled = true;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command=new SqlCommand();
            string query;
            if (radioButtonYes.Checked == true)
            {
                string dateNBD = dateTimePickerNBD.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string dateNKT = dateTimePickerNKT.Value.ToString("yyyy-MM-dd HH:mm:ss");
                if (radioButtonAll.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "' ";
                    command = new SqlCommand(query,mydb.getConnection);

                    labelSoLuong.Text = "Số Lượng Xe: " + xe.totalXe();
                    int soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXe());
                    labelSearchChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;

                }
                else if (radioButtonSearchXeDap.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@lx AND ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Xe Đạp";
                    labelSoLuong.Text = "Số Lượng Xe Đạp: " + xe.totalXeDap();
                    int soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeDap());
                    labelSearchChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
                }
                else if(radioButtonSearchXeMay.Checked==true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@lx AND ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Xe Máy";

                    labelSoLuong.Text = "Số Lượng Xe Máy: " + xe.totalXeDap();
                    int soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeDap());
                    labelSearchChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
                }
                else if (radioButtonSearchXeHoi.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@lx AND ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Xe Hơi";

                    labelSoLuong.Text = "Số Lượng Xe Hơi: " + xe.totalXeDap();
                    int soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeDap());
                    labelSearchChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
                }
                fillGrid(command);
            }
            else if(radioButtonNo.Checked==true)
            {
                if (radioButtonAll.Checked==true)
                {
                    query = "SELECT * FROM XE ";
                    command = new SqlCommand(query, mydb.getConnection);
                }
                else if (radioButtonSearchXeDap.Checked==true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Đạp";
                }
                else if(radioButtonSearchXeMay.Checked==true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Máy";
                }
                else if (radioButtonSearchXeHoi.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Hơi";
                }
                fillGrid(command);
            }
        }

        private void radioButtonXeDap_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            labelId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            labelLoaiXe.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            labelNgayKetThuc.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value);
            string guiTheo = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            DateTime tNow = DateTime.Now;
            DateTime ngKT = Convert.ToDateTime(labelNgayKetThuc.Text);
            int mucPhat = xe.MucPhat(labelLoaiXe.Text, guiTheo, ngKT, tNow);
            xe.updateMucPhat(Convert.ToInt32(labelId.Text), mucPhat);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM XE");
            fillGrid(command);
            labelSoLuong.Text = "Số Lượng Xe: " + xe.totalXe();
            int soChoTrong = maxChoTrong*3 - Convert.ToInt32(xe.totalXe());
            labelSearchChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }
    }
}
