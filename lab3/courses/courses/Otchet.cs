using Npgsql;
using NpgsqlTypes;
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
    public partial class Otchet : Form
    {
        private string connection = String.Format("Server = localhost; port = 5432; user id = postgres; password = diana2004; database = qualification_courses;");
        private NpgsqlConnection conn;

        public Otchet()
        {
            InitializeComponent();

            conn = new NpgsqlConnection(connection);

            /*dataGridView1.Columns.Add("ClientName", "Имя клиента");
            dataGridView1.Columns.Add("Programname", "Название программы");
            dataGridView1.Columns.Add("IssueDate", "Дата выдачи");

            PopulateProgramsComboBox();*/

            PopulateDataGridView("select * from certificate", dataGridView1);

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void Otchet_Load(object sender, EventArgs e)
        {

        }

        private void PopulateDataGridView(string query, DataGridView dataGridView)
        {
            try
            {
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand(query, conn);
                comm.CommandType = CommandType.Text;
                NpgsqlDataReader dr = comm.ExecuteReader();

                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                                       
                    dt.Columns.Add("Полное имя клиента", typeof(string));
                    dt.Columns.Add("Название программы", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        int clientId = Convert.ToInt32(row["id_client_fk"]);
                        int programId = Convert.ToInt32(row["id_training_fk"]);
                        string full_name = GetClientFullName(clientId);
                        string program_name = GetProgramName(programId);
                        row["Полное имя клиента"] = full_name;
                        row["Название программы"] = program_name;
                    }

                    dt.Columns.Remove("id_client_fk");
                    dt.Columns.Remove("id_training_fk");

                    DataView dv = dt.DefaultView;
                    dv.Sort = "date_of_issue DESC";
                    DataTable sortedDataTable = dv.ToTable();

                    dataGridView.DataSource = sortedDataTable;

                    dataGridView.Columns["date_of_issue"].HeaderText = "Дата выдачи";
                    dataGridView.Columns["id_certificate"].HeaderText = "ID сертификата";

                }
            }
            finally
            {
                conn.Close();
            }   
        }

        private string GetProgramName(int programId) 
        {
            string programName = "";

            try
            {
                // Используем запрос JOIN для объединения таблиц
                string programQuery = $"SELECT tp.name FROM public.training t " +
                                      $"JOIN public.training_programm tp ON t.id_training_programm_fk = tp.id_training_programm " +
                                      $"WHERE t.id_training = @programId";

                using (NpgsqlCommand programCommand = new NpgsqlCommand(programQuery, conn))
                {
                    programCommand.Parameters.AddWithValue("@programId", NpgsqlDbType.Integer).Value = programId;
                    programName = programCommand.ExecuteScalar()?.ToString();
                }
            }
            finally
            {

            }

            return programName;
        }

        private string GetClientFullName(int clientId)
        {
            string fullName = "";

            try
            {
                string clientQuery = $"SELECT full_name FROM public.client WHERE id_client = {clientId}";
                using (NpgsqlCommand clientCommand = new NpgsqlCommand(clientQuery, conn))
                {
                    fullName = clientCommand.ExecuteScalar()?.ToString();
                }
            }
            finally
            {
                // Не закрывайте соединение здесь, чтобы оно осталось открытым для других операций
            }

            return fullName;
        }


        private void CalculateSortedDates(string selectedDate)
        {
            try
            {
                // Открываем соединение
                conn.Open();

                // Запрос для получения строк с датой меньше или равной выбранной дате
                string query = $"SELECT id_certificate AS \"ID сертификата\", " +
                       "date_of_issue AS \"Дата выдачи\" " +
                       "FROM public.certificate " +
                       "WHERE date_of_issue <= @selectedDate " +
                       "ORDER BY date_of_issue DESC";

                using (NpgsqlCommand comm = new NpgsqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@selectedDate", NpgsqlDbType.Date).Value = DateTime.Parse(selectedDate);

                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(comm))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Выводим результат в DataGridView
                        dataGridView1.DataSource = dataTable;

                        // Выводим количество строк в TextBox
                        textBox1.Text = dataTable.Rows.Count.ToString();
                    }
                }
            }
            finally
            {
                // Закрываем соединение
                conn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report re = new Report();
            re.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CalculateSortedDates(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        }

        
    }
}
