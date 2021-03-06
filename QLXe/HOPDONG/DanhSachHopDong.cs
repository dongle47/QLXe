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

namespace QLXe
{
    public partial class DanhSachHopDong : Form
    {
        public DanhSachHopDong()
        {
            InitializeComponent();
        }
        HDChoThue hdChoThue = new HDChoThue();
        HDThue hdThue = new HDThue();
        private void DanhSachHopDong_Load(object sender, EventArgs e)
        {
            radioButtonNo.Checked = true;
            radioButtonChoThue.Checked = true;
            fillGridChoThue();
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ChiTietHopDong f = new ChiTietHopDong();
            if (radioButtonChoThue.Checked == true)
            {
                f.labelTenHopDong.Text = "HỢP ĐỒNG CHO THUÊ";
                f.labelTenChoThue.Text = "Bên Cho Thuê: " + dataGridView1.CurrentRow.Cells[3].Value.ToString();
                f.labelTenNgThue.Text = "Bên Thuê: " + dataGridView1.CurrentRow.Cells[7].Value.ToString();
                byte[] picHinhXe, picBangSo, picChuXe, picNgThue, picNhanVien;
                picHinhXe = (byte[])dataGridView1.CurrentRow.Cells[1].Value;
                picBangSo = (byte[])dataGridView1.CurrentRow.Cells[2].Value;
                picChuXe = (byte[])dataGridView1.CurrentRow.Cells[4].Value;
                picNgThue = (byte[])dataGridView1.CurrentRow.Cells[8].Value;
                picNhanVien = (byte[])dataGridView1.CurrentRow.Cells[10].Value;

                MemoryStream hinhXe = new MemoryStream(picHinhXe);
                MemoryStream bangSo = new MemoryStream(picBangSo);
                MemoryStream chuXe = new MemoryStream(picChuXe);
                MemoryStream ngThue = new MemoryStream(picNgThue);
                MemoryStream nhanVien = new MemoryStream(picNhanVien);

                f.pictureBoxHinhXe.Image = Image.FromStream(hinhXe);
                f.pictureBoxBangSo.Image = Image.FromStream(bangSo);
                f.pictureBoxChoThue.Image = Image.FromStream(chuXe);
                f.pictureBoxNguoiThue.Image = Image.FromStream(ngThue);
                f.pictureBoxNV.Image = Image.FromStream(nhanVien);

                f.labelNBD.Text = "Ngày Bắt Đầu: " + dataGridView1.CurrentRow.Cells[5].Value;
                f.labelNKT.Text = "Ngày Kết Thúc: " + dataGridView1.CurrentRow.Cells[6].Value;

                f.labelTenNV.Text = "Tên Nhân Viên: " + dataGridView1.CurrentRow.Cells[9].Value;
                f.labelChiPhi.Text = "CHI PHÍ: " + dataGridView1.CurrentRow.Cells[11].Value;

                f.Show();
            }
            else if (radioButtonThue.Checked == true)
            {
                f.labelTenHopDong.Text = "HỢP ĐỒNG THUÊ";

                f.labelTenChoThue.Text = "Bên Cho Thuê: " + dataGridView1.CurrentRow.Cells[3].Value.ToString();
                f.labelTenNgThue.Text = "Bên Thuê: Công Ty ABC";
                f.pictureBoxNguoiThue.Image = Image.FromFile("C:/Users/PC/Pictures/matt-bagshaw-showroomdusk-viewthroughmedium.jpg");

                byte[] picHinhXe, picBangSo, picChuXe, picNhanVien;
                picHinhXe = (byte[])dataGridView1.CurrentRow.Cells[1].Value;
                picBangSo = (byte[])dataGridView1.CurrentRow.Cells[2].Value;
                picChuXe = (byte[])dataGridView1.CurrentRow.Cells[4].Value;
                picNhanVien = (byte[])dataGridView1.CurrentRow.Cells[8].Value;

                MemoryStream hinhXe = new MemoryStream(picHinhXe);
                MemoryStream bangSo = new MemoryStream(picBangSo);
                MemoryStream chuXe = new MemoryStream(picChuXe);
                MemoryStream nhanVien = new MemoryStream(picNhanVien);

                f.pictureBoxHinhXe.Image = Image.FromStream(hinhXe);
                f.pictureBoxBangSo.Image = Image.FromStream(bangSo);
                f.pictureBoxChoThue.Image = Image.FromStream(chuXe);
                f.pictureBoxNV.Image = Image.FromStream(nhanVien);

                f.labelNBD.Text = "Ngày Bắt Đầu " + dataGridView1.CurrentRow.Cells[5].Value;
                f.labelNKT.Text = "Ngày Kết Thúc" + dataGridView1.CurrentRow.Cells[6].Value;

                f.labelTenNV.Text = "Tên Nhân Viên: " + dataGridView1.CurrentRow.Cells[7].Value;
                f.labelChiPhi.Text = "CHI PHÍ: " + dataGridView1.CurrentRow.Cells[9].Value;


                f.Show();
            }
            
        }
        private void radioButtonChoThue_CheckedChanged(object sender, EventArgs e)
        {
            labelSearch.Text = "Tìm Kiếm Theo ID, Tên Bên Thuê, Tên Cho Thuê, Tên NV";
            fillGridChoThue();
        }
        public void fillGridChoThue()
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol3 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol4 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol5 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = hdChoThue.getHDNV();
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[1];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol3 = (DataGridViewImageColumn)dataGridView1.Columns[4];
            picCol3.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol4 = (DataGridViewImageColumn)dataGridView1.Columns[8];
            picCol4.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol5 = (DataGridViewImageColumn)dataGridView1.Columns[10];
            picCol5.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;
        }
        public void fillGridThue()
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol3 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol4 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = hdThue.getHDNV();
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[1];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol3 = (DataGridViewImageColumn)dataGridView1.Columns[4];
            picCol3.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol4 = (DataGridViewImageColumn)dataGridView1.Columns[8];
            picCol4.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;
        }

        private void radioButtonThue_CheckedChanged(object sender, EventArgs e)
        {
            labelSearch.Text = "Tìm Kiếm Theo ID, Tên Bên Cho Thuê, Tên NV";
            fillGridThue();
        }

        private void buttonToText_Click(object sender, EventArgs e)
        {
            if (radioButtonChoThue.Checked == true)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.DefaultExt = "*.docx";
                saveFile.Filter = "DOCX files(*.docx|*.docx";
                if (saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName.Length > 0)
                {
                    exportDataToWordChoThue(dataGridView1, saveFile.FileName);
                    MessageBox.Show("File saved!", "Message Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (radioButtonThue.Checked == true)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.DefaultExt = "*.docx";
                saveFile.Filter = "DOCX files(*.docx|*.docx";
                if (saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName.Length > 0)
                {
                    exportDataToWordThue(dataGridView1, saveFile.FileName);
                    MessageBox.Show("File saved!", "Message Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void exportDataToWordThue(DataGridView DGV, string fileName)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int rowCount = dataGridView1.Rows.Count;
                int columnCount = dataGridView1.Columns.Count;
                Object[,] dataArray = new object[rowCount + 1, columnCount + 1];
                //add row
                int r = 0;
                for (int c = 0; c < columnCount; c++)
                {
                    for (r = 0; r < rowCount; r++)
                    {
                        dataArray[r, c] = dataGridView1.Rows[r].Cells[c].Value;
                    }
                }
                for (r = 0; r < rowCount; r++)
                {
                    string[] temp = dataGridView1.Rows[r].Cells[6].Value.ToString().Split(' ');
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
                oDoc.Application.Selection.Tables[1].Cell(1, 1).Range.Text = "Contract ID";
                oDoc.Application.Selection.Tables[1].Cell(1, 2).Range.Text = "Hình Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 3).Range.Text = "Bảng Số";
                oDoc.Application.Selection.Tables[1].Cell(1, 4).Range.Text = "Tên Chủ Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 5).Range.Text = "Hình Chủ Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 6).Range.Text = "Ngày Bắt Đầu";
                oDoc.Application.Selection.Tables[1].Cell(1, 7).Range.Text = "Ngày Kết Thúc";
                oDoc.Application.Selection.Tables[1].Cell(1, 8).Range.Text = "Ten Nhân Viên";
                oDoc.Application.Selection.Tables[1].Cell(1, 9).Range.Text = "Hình Nhân Viên";
                //table style
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                //header text
                foreach (Microsoft.Office.Interop.Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Danh Sách Hợp Đồng Thuê Của Tất Cả Nhân Viên";
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
                //save file
                for (r = 0; r < rowCount; r++)
                {
                    byte[] hinhXe = (byte[])dataGridView1.Rows[r].Cells[1].Value;
                    byte[] bangSo = (byte[])dataGridView1.Rows[r].Cells[2].Value;
                    byte[] chuXe = (byte[])dataGridView1.Rows[r].Cells[4].Value;
                    byte[] hiNV = (byte[])dataGridView1.Rows[r].Cells[8].Value;

                    MemoryStream hx = new MemoryStream(hinhXe);
                    MemoryStream bs = new MemoryStream(bangSo);
                    MemoryStream cx = new MemoryStream(chuXe);
                    MemoryStream nv = new MemoryStream(hiNV);

                    Image finalhx = (new Bitmap(Image.FromStream(hx), new Size(70, 70)));
                    Image finalbs = (new Bitmap(Image.FromStream(bs), new Size(70, 70)));
                    Image finalcx = (new Bitmap(Image.FromStream(cx), new Size(70, 70)));
                    Image finalnv = (new Bitmap(Image.FromStream(nv), new Size(70, 70)));

                    Clipboard.SetDataObject(finalhx);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 2).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 2).Range.InsertParagraph();

                    Clipboard.SetDataObject(finalbs);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 3).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 3).Range.InsertParagraph();

                    Clipboard.SetDataObject(finalcx);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 5).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 5).Range.InsertParagraph();

                    Clipboard.SetDataObject(finalnv);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 9).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 9).Range.InsertParagraph();
                }
                oDoc.SaveAs(fileName);
            }
        }
        public void exportDataToWordChoThue(DataGridView DGV, string fileName)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int rowCount = dataGridView1.Rows.Count;
                int columnCount = dataGridView1.Columns.Count;
                Object[,] dataArray = new object[rowCount + 1, columnCount + 1];
                //add row
                int r = 0;
                for (int c = 0; c < columnCount; c++)
                {
                    for (r = 0; r < rowCount; r++)
                    {
                        dataArray[r, c] = dataGridView1.Rows[r].Cells[c].Value;
                    }
                }
                for (r = 0; r < rowCount; r++)
                {
                    string[] temp = dataGridView1.Rows[r].Cells[6].Value.ToString().Split(' ');
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
                oDoc.Application.Selection.Tables[1].Cell(1, 1).Range.Text = "Contract ID";
                oDoc.Application.Selection.Tables[1].Cell(1, 2).Range.Text = "Hình Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 3).Range.Text = "Bảng Số";
                oDoc.Application.Selection.Tables[1].Cell(1, 4).Range.Text = "Tên Chủ Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 5).Range.Text = "Hình Chủ Xe";
                oDoc.Application.Selection.Tables[1].Cell(1, 6).Range.Text = "Ngày Bắt Đầu";
                oDoc.Application.Selection.Tables[1].Cell(1, 7).Range.Text = "Ngày Kết Thúc";
                oDoc.Application.Selection.Tables[1].Cell(1, 8).Range.Text = "Tên Người Thue";
                oDoc.Application.Selection.Tables[1].Cell(1, 9).Range.Text = "Hình Người Thue";
                oDoc.Application.Selection.Tables[1].Cell(1, 10).Range.Text = "Ten Nhân Viên";
                oDoc.Application.Selection.Tables[1].Cell(1, 11).Range.Text = "Hình Nhân Viên";
                //table style
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                //header text
                foreach (Microsoft.Office.Interop.Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Danh Sách Hợp Đồng Cho Thuê Của Tất Cả Nhân Viên";
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
                //save file
                for (r = 0; r < rowCount; r++)
                {
                    byte[] hinhXe = (byte[])dataGridView1.Rows[r].Cells[1].Value;
                    byte[] bangSo = (byte[])dataGridView1.Rows[r].Cells[2].Value;
                    byte[] chuXe = (byte[])dataGridView1.Rows[r].Cells[4].Value;
                    byte[] ngthue = (byte[])dataGridView1.Rows[r].Cells[8].Value;
                    byte[] hiNV = (byte[])dataGridView1.Rows[r].Cells[10].Value;

                    MemoryStream hx = new MemoryStream(hinhXe);
                    MemoryStream bs = new MemoryStream(bangSo);
                    MemoryStream cx = new MemoryStream(chuXe);
                    MemoryStream nt = new MemoryStream(ngthue);
                    MemoryStream nv = new MemoryStream(hiNV);

                    Image finalhx = (new Bitmap(Image.FromStream(hx), new Size(70, 70)));
                    Image finalbs = (new Bitmap(Image.FromStream(bs), new Size(70, 70)));
                    Image finalcx = (new Bitmap(Image.FromStream(cx), new Size(70, 70)));
                    Image finalnt = (new Bitmap(Image.FromStream(nt), new Size(70, 70)));
                    Image finalnv = (new Bitmap(Image.FromStream(nv), new Size(70, 70)));

                    Clipboard.SetDataObject(finalhx);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 2).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 2).Range.InsertParagraph();

                    Clipboard.SetDataObject(finalbs);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 3).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 3).Range.InsertParagraph();

                    Clipboard.SetDataObject(finalcx);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 5).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 5).Range.InsertParagraph();

                    Clipboard.SetDataObject(finalnt);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 9).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 9).Range.InsertParagraph();

                    Clipboard.SetDataObject(finalnv);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 11).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 11).Range.InsertParagraph();
                }
                oDoc.SaveAs(fileName);
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (radioButtonChoThue.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT HDChoThue.id, HDChoThue.hinhXe, HDChoTHue.bangSo, HDChoThue.tenChuXe, HDChoThue.hinhChuXe, HDChoThue.ngayBatDau, " +
                "HDChoThue.ngayKetThuc, HDChoThue.tenNguoiThue, HDChoThue.hinhNguoiThue, NV.ten as TênNV, NV.hinhAnh " +
                "FROM HDChoThue INNER JOIN NV on HDChoThue.nv_id = NV.id  WHERE CONCAT(HDChoTHue.id, HDChoThue.tenChuXe, HDChoThue.tenNguoiThue, NV.ten) LIKE '%" + textBoxSearch.Text + "%'");
                fillGridChoThue(command);
            }
            else if(radioButtonThue.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT HDThue.id, HDThue.hinhXe, HDTHue.bangSo, HDThue.tenChuXe, HDThue.hinhChuXe, HDThue.ngayBatDau, " +
                "HDThue.ngayKetThuc, NV.ten as TênNV, NV.hinhAnh " +
                "FROM HDThue INNER JOIN NV on HDThue.nv_id = NV.id  WHERE CONCAT(HDThue.id, HDThue.tenChuXe, NV.ten) LIKE '%" + textBoxSearch.Text + "%'");
                fillGridThue(command);
            }
            
        }
        public void fillGridChoThue(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol3 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol4 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol5 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = hdChoThue.selectContractList(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[1];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol3 = (DataGridViewImageColumn)dataGridView1.Columns[4];
            picCol3.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol4 = (DataGridViewImageColumn)dataGridView1.Columns[8];
            picCol4.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol5 = (DataGridViewImageColumn)dataGridView1.Columns[10];
            picCol5.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;
        }
        public void fillGridThue(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol3 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol4 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = hdThue.selectContractList(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[1];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol3 = (DataGridViewImageColumn)dataGridView1.Columns[4];
            picCol3.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol4 = (DataGridViewImageColumn)dataGridView1.Columns[8];
            picCol4.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            string query;
            SqlCommand command = new SqlCommand();
            if (radioButtonYes.Checked == true)
            {
                string dateNBD = dateTimePickerNBD.Value.ToString("yyyy-MM-dd");
                string dateNKT = dateTimePickerNKT.Value.ToString("yyyy-MM-dd");
                if (radioButtonChoThue.Checked)
                {
                    query = "SELECT HDChoThue.id, HDChoThue.hinhXe, HDChoTHue.bangSo, HDChoThue.tenChuXe, HDChoThue.hinhChuXe, HDChoThue.ngayBatDau, " +
                "HDChoThue.ngayKetThuc, HDChoThue.tenNguoiThue, HDChoThue.hinhNguoiThue, NV.ten as TênNV, NV.hinhAnh " +
                "FROM HDChoThue INNER JOIN NV on HDChoThue.nv_id = NV.id WHERE ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'" +
                         "AND ngayKetThuc BETWEEN '" + dateNBD + "' AND '" + dateNKT + "' ";
                    command = new SqlCommand(query);
                    fillGridChoThue(command);
                }
                else if (radioButtonThue.Checked)
                {
                    query = "SELECT HDThue.id, HDThue.hinhXe, HDTHue.bangSo, HDThue.tenChuXe, HDThue.hinhChuXe, HDThue.ngayBatDau, " +
                "HDThue.ngayKetThuc, NV.ten as TênNV, NV.hinhAnh " +
                "FROM HDThue INNER JOIN NV on HDThue.nv_id = NV.id WHERE ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'" +
                         "AND ngayKetThuc BETWEEN '" + dateNBD + "' AND '" + dateNKT + "' ";
                    command = new SqlCommand(query);
                    fillGridThue(command);
                }
            }
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
    }
}
