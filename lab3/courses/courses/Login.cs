using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace courses
{
    public partial class Login : Form
    {
        private string connection = String.Format("Server = localhost; port = 5432; user id = postgres; password = diana2004; database = qualification_courses;");
        private NpgsqlConnection conn;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select * from client where full_name = @full_name and password = @password", conn);
            cmd.Parameters.AddWithValue("@full_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count.ToString() == "1")
            {
                this.Hide();
                cli cli = new cli();
                cli.Show();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль. Пожалуйста повторите!", "Title",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}