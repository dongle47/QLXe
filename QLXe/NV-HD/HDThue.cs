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
    class HDThue
    {
        MyDB mydb = new MyDB();
        int userId = Globals.globalUserId;
        public bool danhDauContract(int id, int x)
        {
            SqlCommand command = new SqlCommand("UPDATE HDThue SET daDuocThue=@ddt WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@ddt", SqlDbType.Int).Value = x;
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
        public int dtNgay()
        {
            string date1 = DateTime.Now.ToString("yyyy-MM-dd ");
            string date2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int count = 0;
            MyDB db = new MyDB();
            SqlCommand command = new SqlCommand("SELECT SUM(mucPhi) FROM HDThue WHERE " +
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
            command.CommandText = ("SELECT HDThue.id, HDThue.hinhXe, HDTHue.bangSo, HDThue.tenChuXe, HDThue.hinhChuXe, HDThue.ngayBatDau, " +
                "HDThue.ngayKetThuc,NV.ten as TênNV, NV.hinhAnh, HDThue.mucPhi " +
                "FROM HDThue INNER JOIN NV on HDThue.nv_id = NV.id ");
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
            DateTime ngayBatDau, DateTime ngayKetThuc, int nvId, int mucPhi, int x)
        {
            SqlCommand command = new SqlCommand("INSERT INTO HDThue (id, hinhXe, bangSo, tenChuXe, hinhChuXe, ngayBatDau, ngayKetThuc, nv_id, mucPhi, daDuocThue) VALUES" +
                " (@id, @hx, @bs, @tenChu, @hinhChu, @nbd, @nkt, @nvId, @mp, @ddt)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@hx", SqlDbType.Image).Value = hinhXe.ToArray();
            command.Parameters.Add("@bs", SqlDbType.Image).Value = bangSo.ToArray();
            command.Parameters.Add("@tenChu", SqlDbType.NVarChar).Value = tenChuXe;
            command.Parameters.Add("@hinhChu", SqlDbType.Image).Value = hinhChuXe.ToArray();
            command.Parameters.Add("@nbd", SqlDbType.DateTime).Value = ngayBatDau;
            command.Parameters.Add("@nkt", SqlDbType.DateTime).Value = ngayKetThuc;
            command.Parameters.Add("@nvId", SqlDbType.Int).Value = nvId;
            command.Parameters.Add("@mp", SqlDbType.Int).Value = mucPhi;
            command.Parameters.Add("@ddt", SqlDbType.Int).Value = x;
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
            DateTime ngayBatDau, DateTime ngayKetThuc, int nvId, int mucPhi)
        {
            SqlCommand command = new SqlCommand("UPDATE HDThue SET id=@id, hinhXe=@hx, " +
                "bangSo=@bs, tenChuXe=@tenChu, hinhChuXe=@hinhChu, ngayBatDau=@nbd, " +
                "ngayKetThuc=@nkt, mucPhi=@mp WHERE id=@id AND nv_id=@nvId", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@hx", SqlDbType.Image).Value = hinhXe.ToArray();
            command.Parameters.Add("@bs", SqlDbType.Image).Value = bangSo.ToArray();
            command.Parameters.Add("@tenChu", SqlDbType.NVarChar).Value = tenChuXe;
            command.Parameters.Add("@hinhChu", SqlDbType.Image).Value = hinhChuXe.ToArray();
            command.Parameters.Add("@nbd", SqlDbType.DateTime).Value = ngayBatDau;
            command.Parameters.Add("@nkt", SqlDbType.DateTime).Value = ngayKetThuc;
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
            SqlCommand command = new SqlCommand("DELETE FROM HDThue WHERE id=@id AND nv_id=@uid", mydb.getConnection);
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
                "ngayKetThuc FROM HDTHue WHERE id=@id AND nv_id=@nvID", mydb.getConnection);
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
