using QLXe.CongViec;
using QLXe.Tho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLXe
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void thêmXeGửiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themXeForm f = new themXeForm();
            f.ShowDialog();
        }

        private void danhSáchXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachXeForm f = new DanhSachXeForm();
            f.ShowDialog();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyXeForm f = new QuanLyXeForm();
            f.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeForm f = new ThongKeForm();
            f.ShowDialog();
        }

        private void danhSáchHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachHopDong f = new DanhSachHopDong();
            f.Show();
        }

        private void thêmThợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTho f = new ThemTho();
            f.Show();
        }

        private void xóaThợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaTho f = new XoaTho();
            f.Show();
        }

        private void danhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListTho f = new ListTho();
            f.Show();
        }

        private void quảnLýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QuanLyThoForm f = new QuanLyThoForm();
            f.Show();
        }

        private void thốngKêToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ThongKeThoForm f = new ThongKeThoForm();
            f.Show();
        }

        private void thêmCôngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemCongViecForm f = new ThemCongViecForm();
            f.Show();
        }

        private void danhSáchCôngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachCongViecForm f = new DanhSachCongViecForm();
            f.Show();
        }

        private void quảnLýToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            QuanLyCongViecForm f = new QuanLyCongViecForm();
            f.Show();
        }

        private void thốngKêToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ThongKeCongViecForm f = new ThongKeCongViecForm();
            f.Show();
        }

        private void thốngKêToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ThongKeHopDong f = new ThongKeHopDong();
            f.Show();
        }

        private void tỔNGDOANHTHUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TongDoanhThuNgay f = new TongDoanhThuNgay();
            f.Show();
        }
    }
}
