using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLXe
{
    class CONGVIEC
    {
        MyDB mydb = new MyDB();
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        //DateTime date = DateTime.Now;

        public int dtSuaXeNgay()
        {
            string date1 = DateTime.Now.ToString("yyyy-MM-dd ");
            string date2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int count = 0;
            MyDB db = new MyDB();
            SqlCommand command = new SqlCommand("SELECT SUM(mucPhi) FROM CONGVIEC WHERE loaiCongViec=@xd " +
                "AND ngayBatDau BETWEEN '" + date1 + "' AND '" + date2 + "'", db.getConnection);

            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Sửa Xe";
            db.openConnection();
            try
            {
                count = (int)command.ExecuteScalar();
            }
            catch { }
            return count;
        }
        public int dtRuaXeNgay()
        {
            string date1 = DateTime.Now.ToString("yyyy-MM-dd ");
            string date2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int count = 0;
            MyDB db = new MyDB();
            SqlCommand command = new SqlCommand("SELECT SUM(mucPhi) FROM CONGVIEC WHERE loaiCongViec=@xd " +
                "AND ngayBatDau BETWEEN '" + date1 + "' AND '" + date2 + "'", db.getConnection);

            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Rửa Xe";
            db.openConnection();
            try
            {
                count = (int)command.ExecuteScalar();
            }
            catch { }
            return count;
        }
        public int dtCoiXeNgay()
        {
            string date1 = DateTime.Now.ToString("yyyy-MM-dd ");
            string date2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int count = 0;
            MyDB db = new MyDB();
            SqlCommand command = new SqlCommand("SELECT SUM(mucPhi) FROM CONGVIEC WHERE loaiCongViec=@xd " +
                "AND ngayBatDau BETWEEN '" + date1 + "' AND '" + date2 + "'", db.getConnection);

            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Trông coi xe";
            db.openConnection();
            try
            {
                count = (int)command.ExecuteScalar();
            }
            catch { }
            return count;
        }
        public int totalRuaXe()
        {
            MyDB db = new MyDB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE loaiCongViec=@loaiCongViec", db.getConnection);
            command.Parameters.Add("@loaiCongViec", SqlDbType.NVarChar).Value = "Rửa Xe";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count;
        }

        public int totalCoiXe()
        {
            MyDB db = new MyDB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE loaiCongViec=@loaiCongViec", db.getConnection);
            command.Parameters.Add("@loaiCongViec", SqlDbType.NVarChar).Value = "Trông coi xe";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count;
        }
        public int totalSuaXe()
        {
            MyDB db = new MyDB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE loaiCongViec=@xd  " , db.getConnection);
            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Sửa Xe";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count;
        }
        public bool insertCV(int id, string loaiCV, int idXe, string loaiXe, MemoryStream hinhXe, MemoryStream bangSo, int idTho, string tenTho, MemoryStream hinhTho, DateTime ngaySua, DateTime ngayLay, int mucPhi)
        {
            SqlCommand command = new SqlCommand("INSERT INTO CONGVIEC(id, loaiCongViec, idXe, loaiXe, hinhXe, bangSo, idTho, tenTho, hinhTho, ngayBatDau, ngayKetThuc, mucPhi)" +
                "VALUES (@id, @loaiCongViec, @idXe, @loaiXe, @hinhXe, @bangSo, @idTho, @tenTho, @hinhTho, @ngaySua, @ngayLay, @mp)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@loaiCongViec", SqlDbType.NVarChar).Value = loaiCV;
            command.Parameters.Add("@idXe", SqlDbType.Int).Value = idXe;
            command.Parameters.Add("@loaiXe", SqlDbType.NVarChar).Value = loaiXe;
            command.Parameters.Add("@hinhXe", SqlDbType.Image).Value = hinhXe.ToArray();
            command.Parameters.Add("@bangSo", SqlDbType.Image).Value = bangSo.ToArray();
            command.Parameters.Add("@idTho", SqlDbType.Int).Value = idTho;
            command.Parameters.Add("@tenTho", SqlDbType.NVarChar).Value = tenTho;
            command.Parameters.Add("@hinhTho", SqlDbType.Image).Value = hinhTho.ToArray();
            command.Parameters.Add("@ngaySua", SqlDbType.DateTime).Value = ngaySua;
            command.Parameters.Add("@ngayLay", SqlDbType.DateTime).Value = ngayLay;
            command.Parameters.Add("@mp", SqlDbType.Int).Value = mucPhi;
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
        public DataTable getCV(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool deleteCV(int id)
        {

            SqlCommand command = new SqlCommand("DELETE FROM CONGVIEC WHERE id=@id", mydb.getConnection);
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
        public bool updateCV(int id, string loaiCV, int idXe, string loaiXe, MemoryStream hinhXe, MemoryStream bangSo, int idTho, string tenTho,
                                MemoryStream hinhTho, DateTime ngaySua, DateTime ngayLay, int mucPhi)
        {
            SqlCommand command = new SqlCommand("UPDATE CONGVIEC SET loaiCongViec=@loaiCongViec," +
                "idXe=@idXe, loaiXe=@loaiXe, hinhXe=@hinhXe, bangSo=@bangSo, idTho=@idTho, tenTho=@tenTho, hinhTho=@hinhTho, ngayBatDau=@ngaySua, ngayKetThuc=@ngayLay, mucPhi=@mp WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@loaiCongViec", SqlDbType.NVarChar).Value = loaiCV;
            command.Parameters.Add("@idXe", SqlDbType.Int).Value = idXe;
            command.Parameters.Add("@loaiXe", SqlDbType.NVarChar).Value = loaiXe;
            command.Parameters.Add("@hinhXe", SqlDbType.Image).Value = hinhXe.ToArray();
            command.Parameters.Add("@bangSo", SqlDbType.Image).Value = bangSo.ToArray();
            command.Parameters.Add("@idTho", SqlDbType.Int).Value = idTho;
            command.Parameters.Add("@tenTho", SqlDbType.NVarChar).Value = tenTho;
            command.Parameters.Add("@hinhTho", SqlDbType.Image).Value = hinhTho.ToArray();
            command.Parameters.Add("@ngaySua", SqlDbType.DateTime).Value = ngaySua;
            command.Parameters.Add("@ngayLay", SqlDbType.DateTime).Value = ngayLay;
            command.Parameters.Add("@mp", SqlDbType.Int).Value = mucPhi;



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
