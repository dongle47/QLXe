using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace QLXe
{
    class XE
    {
        MyDB mydb = new MyDB();
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        //them hoc sinh
        public bool insertXe(string loaiXe, MemoryStream nguoiGui, MemoryStream hinhXe, string guiTheo, int thoiGianGui, int mucPhi, int mucPhat, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            SqlCommand command = new SqlCommand("INSERT INTO XE(loaiXe, nguoiGuiHieuXe, hinhXeBangSo, guiTheo, thoiGianGui, mucPhi, mucPhat, ngayBatDau, ngayKetThuc)" +
                "VALUES (@lXe, @ngGui, @hiXe, @guiTheo, @tgGui, @mPhi, @mPhat, @nbd, @nkt)", mydb.getConnection);
            command.Parameters.Add("@lXe", SqlDbType.NVarChar).Value = loaiXe;
            command.Parameters.Add("@ngGui", SqlDbType.Image).Value = nguoiGui.ToArray();
            command.Parameters.Add("@hiXe", SqlDbType.Image).Value = hinhXe.ToArray();
            command.Parameters.Add("@guiTheo", SqlDbType.NVarChar).Value = guiTheo;
            command.Parameters.Add("@tgGui", SqlDbType.Int).Value = thoiGianGui;
            command.Parameters.Add("@mPhi", SqlDbType.Int).Value = mucPhi;
            command.Parameters.Add("@mPhat", SqlDbType.Int).Value = mucPhat;
            command.Parameters.Add("@nbd", SqlDbType.DateTime).Value = ngayBatDau;
            command.Parameters.Add("@nkt", SqlDbType.DateTime).Value = ngayKetThuc;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public DataTable getXe(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool deleteXe(int id)
        {

            SqlCommand command = new SqlCommand("DELETE FROM XE WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            if ((command.ExecuteNonQuery()) == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateXe(int id, string guiTheo, int thoiGianGui, int mucPhi, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            SqlCommand command = new SqlCommand("UPDATE XE SET guiTheo=@gt, thoiGianGui=@tgg," +
                "mucPhi=@mp, ngayBatDau=@nbd, ngayKetThuc=@nkt WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@gt", SqlDbType.NVarChar).Value = guiTheo;
            command.Parameters.Add("@tgg", SqlDbType.Int).Value = thoiGianGui;
            command.Parameters.Add("@mp", SqlDbType.Int).Value = mucPhi;
            command.Parameters.Add("@nbd", SqlDbType.DateTime).Value = ngayBatDau;
            command.Parameters.Add("@nkt", SqlDbType.DateTime).Value = ngayKetThuc;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public int doanhThuXeDap()
        {
            string date1 = DateTime.Now.ToString("yyyy-MM-dd ");
            string date2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int count = 0;
            MyDB db = new MyDB();
            SqlCommand command = new SqlCommand("SELECT SUM(mucPhi) FROM dbo.XE WHERE loaiXe=@xd " +
                "AND ngayBatDau BETWEEN '" + date1 + "' AND '" + date2 + "'", db.getConnection);

            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Đạp";
            db.openConnection();
            try
            {
                count = (int)command.ExecuteScalar();
            }
            catch { }
            return count;
        }
        public int doanhThuXeMay()
        {
            string date1 = DateTime.Now.ToString("yyyy-MM-dd ");
            string date2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int count = 0;
            MyDB db = new MyDB();
            SqlCommand command = new SqlCommand("SELECT SUM(mucPhi) FROM dbo.XE WHERE loaiXe=@xd " +
                "AND ngayBatDau BETWEEN '" + date1 + "' AND '" + date2 + "'", db.getConnection);

            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Máy";
            db.openConnection();
            try
            {
                count = (int)command.ExecuteScalar();
            }
            catch { }
            return count;
        }
        public int doanhThuXeHoi()
        {
            string date1 = DateTime.Now.ToString("yyyy-MM-dd ");
            string date2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int count = 0;
            MyDB db = new MyDB();
            SqlCommand command = new SqlCommand("SELECT SUM(mucPhi) FROM dbo.XE WHERE loaiXe=@xd " +
                "AND ngayBatDau BETWEEN '" + date1 + "' AND '" + date2 + "'", db.getConnection);

            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Máy";
            db.openConnection();
            try
            {
                count = (int)command.ExecuteScalar();
            }
            catch { }
            return count;
        }
        public int totalXeDapNgay()
        {
            string date1 = DateTime.Now.ToString("yyyy-MM-dd ");
            string date2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            MyDB db = new MyDB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.XE WHERE loaiXe=@xd " +
                "AND ngayBatDau BETWEEN '" + date1 + "' AND '" + date2 + "'", db.getConnection);
            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Đạp";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count;
        }
        public int totalXe()
        {

            int count = 0;
            MyDB db = new MyDB();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.XE", db.getConnection);
            db.openConnection();
            count = (int)command.ExecuteScalar();
            return count;
        }
        
        public int totalXeDap()
        {
            MyDB db = new MyDB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE loaiXe=@xd", db.getConnection);
            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Đạp";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count;
        }
        public int totalXeMay()
        {
            MyDB db = new MyDB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE loaiXe=@xm", db.getConnection);
            command.Parameters.Add("@xm", SqlDbType.NVarChar).Value = "Xe Máy";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count;
        }
        public int totalXeHoi()
        {
            MyDB db = new MyDB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE loaiXe=@xh", db.getConnection);
            command.Parameters.Add("@xh", SqlDbType.NVarChar).Value = "Xe Hơi";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count;
        }
        public int MucPhi(string loaiXe, string guiTheo, int thoiGianGui)
        {
            int x = 0;
            if (loaiXe == "Xe Đạp")
            {
                x = 500;
            }
            else if (loaiXe == "Xe Máy")
            {
                x = 1000;
            }
            else if (loaiXe == "Xe Hơi")
            {
                x = 3000;
            }

            if (guiTheo == "Giờ")
            {
                x = x * thoiGianGui;
            }
            else if (guiTheo == "Ngày")
            {
                x = x * 8 * thoiGianGui;
            }
            else if (guiTheo == "Tuần")
            {
                x = x * 24 * thoiGianGui;
            }
            else if (guiTheo == "Tháng")
            {
                x = x * 48 * thoiGianGui;
            }
            return x;
        }
        public int MucPhat(string loaiXe, string guiTheo,DateTime dateKt, DateTime dateNow)
        {
            int mucPhat = 0;
            TimeSpan ts = dateNow.Subtract(dateKt);
            int totalHour = Convert.ToInt32(ts.TotalHours);
            int totalDay = Convert.ToInt32(ts.TotalDays);
            if ( totalDay > 0 || totalHour>0)
            {
                //muc phat theo loai xe
                if (loaiXe == "Xe Đạp")
                {
                    mucPhat = 500;
                }
                else if (loaiXe == "Xe Máy")
                {
                    mucPhat = 1000;
                }
                else if (loaiXe == "Xe Hơi")
                {
                    mucPhat = 3000;
                }

                //muc phat thoi gian
                if (guiTheo=="Giờ")
                {
                    if (totalHour > 24)
                    {
                        mucPhat = totalHour * 8 * mucPhat * 2;
                    }
                    else
                    {
                        mucPhat = totalHour * mucPhat;
                    }
                }
                else if (guiTheo=="Ngày")
                {
                    if(totalDay < 7)
                    {
                        mucPhat =  mucPhat * totalDay * 8 * 7;
                    }
                    else
                    {
                        mucPhat = Convert.ToInt32((totalDay / 7) * mucPhat * 24);
                    }
                }
                else if (guiTheo=="Tuần")
                {
                    if((totalDay/7)>1 && (totalDay / 7)<4)
                    {
                        mucPhat = mucPhat * 24 * Convert.ToInt32(totalDay/7);
                    }
                    else if((totalDay/7)>4)
                    {
                        mucPhat = mucPhat * 48 * (totalDay / 7);
                    }
                }
                else if (guiTheo == "Tháng")
                {
                    if ((totalDay / 30) > 1)
                    {
                        mucPhat = mucPhat * 50 * (totalDay / 7);
                    }
                }
            }
            return mucPhat;
        }
        public bool updateMucPhat(int id, int mucPhat)
        {
            SqlCommand command = new SqlCommand("UPDATE XE SET mucPhat=@mp WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@mp", SqlDbType.Int).Value = mucPhat;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
