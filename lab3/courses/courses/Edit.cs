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
    public partial class Edit : Form
    {
        private string connection = String.Format("Server=localhost;Port=5432;User Id=postgres;Password=diana2004;Database=qualification_courses;");
        private NpgsqlConnection conn;

        public Edit()
        {
            InitializeComponent();

            conn = new NpgsqlConnection(connection);
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }

        public void SetData(string programName, DateTime startDate, DateTime endDate, string hours, DateTime issueDate, string city, string organization)
        {
            // Заполняем элементы управления данными
            comboBox4.Text = programName;
            dateTimePicker1.Value = startDate;
            dateTimePicker2.Value = endDate;
            textBox2.Text = hours;
            dateTimePicker3.Value = issueDate;
            comboBox3.Text = city;
            comboBox1.Text = organization;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // Получаем данные из элементов управления
                string programName = comboBox4.Text;
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;
                string hours = textBox2.Text;
                DateTime issueDate = dateTimePicker3.Value;
                string city = comboBox3.Text;
                string organization = comboBox1.Text;

                // Получаем id выбранной строки из DataGridView (предполагается, что у вас есть столбец "id_certificate")
                int selectedCertificateId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_certificate"].Value);

                // Обновляем данные в базе данных
                string updateQuery = "UPDATE public.certificate " +
                                     "SET название_учебной_программы = @programName, " +
                                     "    дата_начала = @startDate, " +
                                     "    дата_окончания = @endDate, " +
                                     "    количество_часов = @hours, " +
                                     "    дата_выдачи = @issueDate, " +
                                     "    город = @city, " +
                                     "    название_организации = @organization " +
                                     "WHERE id_certificate = @idCertificate";

                using (NpgsqlCommand comm = new NpgsqlCommand(updateQuery, conn))
                {
                    comm.Parameters.AddWithValue("@programName", programName);
                    comm.Parameters.AddWithValue("@startDate", startDate);
                    comm.Parameters.AddWithValue("@endDate", endDate);
                    comm.Parameters.AddWithValue("@hours", hours);
                    comm.Parameters.AddWithValue("@issueDate", issueDate);
                    comm.Parameters.AddWithValue("@city", city);
                    comm.Parameters.AddWithValue("@organization", organization);
                    comm.Parameters.AddWithValue("@idCertificate", selectedCertificateId);

                    comm.ExecuteNonQuery();
                }

                MessageBox.Show("Изменения сохранены успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
