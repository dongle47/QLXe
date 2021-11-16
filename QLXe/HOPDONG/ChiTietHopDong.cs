using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QLXe
{
    public partial class ChiTietHopDong : Form
    {
        public ChiTietHopDong()
        {
            InitializeComponent();
        }
        private void ChiTietHopDong_Load(object sender, EventArgs e)
        {

        }
        private void exportDataToWord(string tenHD, string NBD, string NKT, string tenChoThue, 
            Image choThue, string tenNgThue, Image ngThue, string ptlv, Image hinhXe, Image bangSo, 
            string NVQL, string tenNV, Image hinhNV, string tongChiPhi, string fileName)
        {
            
            Document oDoc = new Document();
            
            //Section s = oDoc.AddSection();
            //Paragraph p = s.AddParagraph();

            ////Insert Image and Set Its Size  
            //DocPicture Pic = p.AppendPicture(Image.FromFile(@"D:\C# Corner.png"));
            //Pic.Width = 500;
            //Pic.Height = 500;

            ////Save and Launch  
            //document.SaveToFile("Image.docx", FileFormat.Docx);
            //System.Diagnostics.Process.Start("Image.docx");


            oDoc.Application.Visible = true;
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            Object oMissing = System.Reflection.Missing.Value;
            string oTemp;
            oTemp = tenHD + "\n" + NBD + "\t" + NKT + "\n" + tenChoThue + "\n" + choThue.RawFormat.ToString() + "\n" + tenNgThue + "\n" + ngThue +
                "\n" + ptlv + "\n" + hinhXe + "\n" + bangSo + "\n" + NVQL + "\n" + tenNV + "\n" + hinhNV + "\n" + tongChiPhi;
            var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            
            //cho phep xem qua trinh hinh thanh va xuat file; true la xem; false la ko xem
            oDoc.Application.Visible = false;
            //chinh chieu xoay cua van ban
            oDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;
            dynamic oRange = oDoc.Content.Application.Selection.Range;
       

       

            oPara1.Range.Text = oTemp;
            oPara1.Range.InsertParagraphAfter();
            oDoc.SaveAs2(fileName);


            

        }
        //private void buttonToText_Click_1(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFile = new SaveFileDialog();
        //    saveFile.DefaultExt = "*.docx";
        //    saveFile.Filter = "DOCX files(*.docx|*.docx";
        //    if (saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName.Length > 0)
        //    {
        //        exportDataToWord(labelTenChoThue.Text, labelNBD.Text, labelNKT.Text,
        //            labelTenChoThue.Text, pictureBoxChoThue.Image, labelTenNgThue.Text, pictureBoxNguoiThue.Image,
        //            labelPhgTien.Text, pictureBoxHinhXe.Image, pictureBoxBangSo.Image, labelNVQL.Text, labelTenNV.Text,
        //            pictureBoxNV.Image, labelChiPhi.Text, saveFile.FileName);
        //        MessageBox.Show("File saved!", "Message Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }
}
