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
    public class ThoClass
    {
        MyDB mydb = new MyDB();

        public bool insertTho(int id,string ten, string sdt, string diaChi, DateTime ngaySinh, string nhomTho, MemoryStream hinhAnh)
        {
            SqlCommand command = new SqlCommand("INSERT INTO THO(id, ten, sdt, diaChi, ngaySinh, nhomTho, hinhAnh)" + "VALUES (@id, @ten, @sdt, @diaChi, @ngaySinh, @nhomTho, @hinhAnh)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ten;
            command.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sdt;
            command.Parameters.Add("@diaChi", SqlDbType.NVarChar).Value = diaChi;
            command.Parameters.Add("@ngaySinh", SqlDbType.DateTime).Value = ngaySinh;
            command.Parameters.Add("@nhomTho", SqlDbType.NVarChar).Value = nhomTho;
            command.Parameters.Add("@hinhAnh", SqlDbType.Image).Value = hinhAnh.ToArray();

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

        public DataTable getTho(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool deleteTho(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Tho WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
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

        public bool updateTho(int id, string ten, string sdt, string diaChi, DateTime ngaySinh, string nhomTho, MemoryStream hinhAnh)
        {
            SqlCommand command = new SqlCommand("UPDATE Tho SET ten=@ten, sdt=@sdt, diaChi=@diaChi," + "ngaySinh=@ngaySinh, nhomTho=@nhomTho, hinhAnh=@hinhAnh WHERE id=@ID", mydb.getConnection);

            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ten;
            command.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sdt;
            command.Parameters.Add("@ngaySinh", SqlDbType.DateTime).Value = ngaySinh;
            command.Parameters.Add("@diaChi", SqlDbType.NVarChar).Value = diaChi;
            command.Parameters.Add("@nhomTho", SqlDbType.NVarChar).Value = nhomTho;
            command.Parameters.Add("@hinhAnh", SqlDbType.Image).Value = hinhAnh.ToArray();

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
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


        public int totalThoSuaXe()
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
        public int totalThoCoiXe()
        {
            MyDB db = new MyDB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE nhomTho=@xd", db.getConnection);
            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Trông coi xe";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count;
        }
        public int totalThoRuaXe()
        {
            MyDB db = new MyDB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE nhomTho=@xd", db.getConnection);
            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Rửa Xe";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table.Rows.Count;
        }

    }
}
