using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLXe
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            MyDB db = new MyDB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            if (radioButtonQL.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM NQL WHERE uname=@User AND pwd=@Pass", db.getConnection);
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = textBoxUserName.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = textBoxPassWord.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    int max = 10;
                    Globals.setMaxChoTrong(max);
                    mainForm f = new mainForm();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password ", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButtonHopDong.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM NV WHERE uname=@User AND pwd=@Pass", db.getConnection);
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = textBoxUserName.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = textBoxPassWord.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    int userId = Convert.ToInt32(table.Rows[0][0].ToString());
                    string name = table.Rows[0][1].ToString();
                    Globals.setName(name);
                    Globals.setGlobalUserId(userId);
                    NhanVienHopDongForm f = new NhanVienHopDongForm();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password ", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        void createErrorProvider()
        {
            ErrorProvider ep = new ErrorProvider();
            ep.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            TextBox txt = new TextBox();
            txt.Name = "txtUser";
            ep.SetError(txt, "Blank is not valid");
            this.Controls.Add(txt);
        }
        private void textBoxPassWord_Validated(object sender, EventArgs e)
        {
            if (textBoxPassWord.Text != "")
            {
                errorProvider1.SetError(this.textBoxPassWord, "");
            }
            else
            {
                errorProvider1.SetError(this.textBoxPassWord, "Password is required");
            }
        }

        private void textBoxPassWord_TextChanged(object sender, EventArgs e)
        {
            textBoxPassWord.PasswordChar = '*';
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            radioButtonQL.Checked = true;
        }

        private void labelNewUser_Click(object sender, EventArgs e)
        {
            CreateAccountForm f = new CreateAccountForm();
            f.Show();
        }
    }
}
