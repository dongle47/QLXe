using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace QLXe
{
    class HDChoThue
    {
        MyDB mydb = new MyDB();
        int userId = Globals.globalUserId;
        public int dtNgay()
        {
            string date1 = DateTime.Now.ToString("yyyy-MM-dd ");
            string date2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int count = 0;
            MyDB db = new MyDB();
            SqlCommand command = new SqlCommand("SELECT SUM(mucPhi) FROM HDChoThue WHERE " +
                "ngayBatDau BETWEEN '" + date1 + "' AND '" + date2 + "'", db.getConnection);

            db.openConnection();
            try
            {
                count = (int)command.ExecuteScalar();
            }
            catch { }
            return count;
        }
        public DataTable getHDNV()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = ("SELECT HDChoThue.id, HDChoThue.hinhXe, HDChoTHue.bangSo, HDChoThue.tenChuXe, HDChoThue.hinhChuXe, HDChoThue.ngayBatDau, " +
                "HDChoThue.ngayKetThuc, HDChoThue.tenNguoiThue, HDChoThue.hinhNguoiThue, NV.ten as TênNV, NV.hinhAnh, HDChoThue.mucPhi " +
                "FROM HDChoThue INNER JOIN NV on HDChoThue.nv_id = NV.id ");
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getHD(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool insertContract(int id, MemoryStream hinhXe, MemoryStream bangSo, string tenChuXe, MemoryStream hinhChuXe, 
            DateTime ngayBatDau, DateTime ngayKetThuc, string tenNguoiThue, MemoryStream hinhNguoiThue , int nvId, int mucPhi)
        {
            SqlCommand command = new SqlCommand("INSERT INTO HDChoThue (id, hinhXe, bangSo, tenChuXe, hinhChuXe, ngayBatDau, ngayKetThuc, tenNguoiThue, hinhNguoiThue, nv_id, mucPhi) VALUES" +
                " (@id, @hx, @bs, @tenChu, @hinhChu, @nbd, @nkt, @tenNgThue, @hinhNgThue, @nvId, @mp)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@hx", SqlDbType.Image).Value = hinhXe.ToArray();
            command.Parameters.Add("@bs", SqlDbType.Image).Value = bangSo.ToArray();
            command.Parameters.Add("@tenChu", SqlDbType.NVarChar).Value = tenChuXe;
            command.Parameters.Add("@hinhChu", SqlDbType.Image).Value = hinhChuXe.ToArray();
            command.Parameters.Add("@nbd", SqlDbType.DateTime).Value = ngayBatDau;
            command.Parameters.Add("@nkt", SqlDbType.DateTime).Value = ngayKetThuc;
            command.Parameters.Add("@tenNgThue", SqlDbType.NVarChar).Value = tenNguoiThue;
            command.Parameters.Add("@hinhNgThue", SqlDbType.Image).Value = hinhNguoiThue.ToArray();
            command.Parameters.Add("@nvId", SqlDbType.Int).Value = nvId;
            command.Parameters.Add("@mp", SqlDbType.Int).Value = mucPhi;
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
        public bool updateContract(int id, MemoryStream hinhXe, MemoryStream bangSo, string tenChuXe, MemoryStream hinhChuXe,
            DateTime ngayBatDau, DateTime ngayKetThuc, string tenNguoiThue, MemoryStream hinhNguoiThue, int nvId, int mucPhi)
        {
            //id, hinhXe, bangSo, tenChuXe, hinhChuXe, ngayBatDau, ngayKetThuc,
            //tenNguoiThue, hinhNguoiThue, nv_id
            SqlCommand command = new SqlCommand("UPDATE HDChoThue SET id=@id, hinhXe=@hx, " +
                "bangSo=@bs, tenChuXe=@tenChu, hinhChuXe=@hinhChu, ngayBatDau=@nbd, " +
                "ngayKetThuc=@nkt, tenNguoiThue=@tenNgThue, hinhNguoiThue=@hinhNgThue WHERE id=@id AND nv_id=@nvId", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@hx", SqlDbType.Image).Value = hinhXe.ToArray();
            command.Parameters.Add("@bs", SqlDbType.Image).Value = bangSo.ToArray();
            command.Parameters.Add("@tenChu", SqlDbType.NVarChar).Value = tenChuXe;
            command.Parameters.Add("@hinhChu", SqlDbType.Image).Value = hinhChuXe.ToArray();
            command.Parameters.Add("@nbd", SqlDbType.DateTime).Value = ngayBatDau;
            command.Parameters.Add("@nkt", SqlDbType.DateTime).Value = ngayKetThuc;
            command.Parameters.Add("@tenNgThue", SqlDbType.NVarChar).Value = tenNguoiThue;
            command.Parameters.Add("@hinhNgThue", SqlDbType.Image).Value = hinhNguoiThue.ToArray();
            command.Parameters.Add("@nvId", SqlDbType.Int).Value = nvId;
            command.Parameters.Add("@mp", SqlDbType.Int).Value = mucPhi;
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
        public bool deleteContract(int contractId, int userId)
        {
            SqlCommand command = new SqlCommand("DELETE FROM HDChoThue WHERE id=@id AND nv_id=@uid", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = contractId;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
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
        public DataTable getContractById(int contactId)
        {
            SqlCommand command = new SqlCommand("SELECT hinhXe, bangSo, tenChuXe, hinhChuXe, ngayBatDau, " +
                "ngayKetThuc, tenNguoiThue, hinhNguoiThue, FROM HDChoTHue WHERE id=@id AND nv_id=@nvID", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = contactId;
            command.Parameters.Add("@nvID", SqlDbType.Int).Value = userId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable selectContractList(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
