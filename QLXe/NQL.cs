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
    class NQL
    {
        MyDB db = new MyDB();
        public DataTable getNQLById(int id)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM NQL WHERE id=@id", db.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
        public bool insertNQL(int id, string ten, string phone, string address, DateTime ngaySinh, MemoryStream picture, string userName, string passWord)
        {
            SqlCommand command = new SqlCommand("INSERT INTO NQL(id, ten, sdt, diaChi, ngaySinh, hinhAnh, uname, pwd) VALUES (@id,@na, @phn, @adr, @birth,@pic, @uname,@pass)", db.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@na", SqlDbType.NVarChar).Value = ten;
            command.Parameters.Add("@phn", SqlDbType.NChar).Value =phone;
            command.Parameters.Add("@adr", SqlDbType.NChar).Value = address;
            command.Parameters.Add("@birth", SqlDbType.DateTime).Value = ngaySinh;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@uname", SqlDbType.NChar).Value = userName;
            command.Parameters.Add("@pass", SqlDbType.NChar).Value = passWord;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool userNameExist(string userName, string operation, int userId)
        {
            string query = "";
            if (operation == "register")
            {
                query = "SELECT * FROM hr WHERE uname=@un";
            }
            else if (operation == "edit")
            {
                query = "SELECT * FROM hr WHERE uname=@un AND id <>@uid";
            }
            SqlCommand command = new SqlCommand(query, db.getConnection);
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = userName;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool updateUser(int userId, string ho, string ten, string userName, string passWord, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE hr SET ho=@fn, ten=@ln, uname=@un, pwd=@pass, fig=@pic WHERE id=@uid", db.getConnection);
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = ho;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = ten;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = userName;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = passWord;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
    }
}
