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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace courses
{
    public partial class Report : Form
    {
        private string connection = String.Format("Server = localhost; port = 5432; user id = postgres; password = diana2004; database = qualification_courses;");
        private NpgsqlConnection conn;



        public Report()
        {
            InitializeComponent();

            conn = new NpgsqlConnection(connection);

            PopulateDataGridView("select * from training", dataGridView1);
            PopulateDataGridView("select * from certificate", dataGridView2);
            PopulateDataGridView("select * from client", dataGridView3);
            PopulateDataGridView("select * from training_programm", dataGridView4);

            //button5.Click += button5_Click;
            AddDeleteButtonColumn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            cli cli = new cli();
            cli.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
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
                    dataGridView.DataSource = dt;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*if (dataGridView2.SelectedRows.Count > 0)
            {
                // Получаем значение из выбранной строки в dataGridView2
                int selectedCertificateId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id_certificate"].Value);

                // Удаляем сертификат из базы данных
                using (NpgsqlConnection connection__ = new NpgsqlConnection(connection))
                {
                    connection__.Open();

                    string deleteQuery = "DELETE FROM public.certificate WHERE id_certificate = @idCertificate";

                    using (NpgsqlCommand comm = new NpgsqlCommand(deleteQuery, connection__))
                    {
                        comm.Parameters.AddWithValue("@idCertificate", selectedCertificateId);
                        comm.ExecuteNonQuery();
                    }

                    // Обновляем dataGridView2 после удаления
                    PopulateDataGridView("SELECT * FROM public.certificate", dataGridView2);
                }
            }
            else
            {
                MessageBox.Show("Выберите сертификат для удаления.");
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AddDeleteButtonColumn()
        {
            // Создаем столбец с кнопкой
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Удалить";
            deleteButtonColumn.Text = "Удалить";
            deleteButtonColumn.UseColumnTextForButtonValue = true;

            // Добавляем столбец в dataGridView2
            dataGridView2.Columns.Add(deleteButtonColumn);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, была ли нажата кнопка в столбце с кнопкой
            if (dataGridView2.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Получаем значение из выбранной строки в dataGridView2
                int selectedCertificateId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["id_certificate"].Value);

                // Удаляем сертификат из базы данных
                using (NpgsqlConnection connection_ = new NpgsqlConnection(connection))
                {
                    connection_.Open();

                    string deleteQuery = "DELETE FROM public.certificate WHERE id_certificate = @idCertificate";

                    using (NpgsqlCommand comm = new NpgsqlCommand(deleteQuery, connection_))
                    {
                        comm.Parameters.AddWithValue("@idCertificate", selectedCertificateId);
                        comm.ExecuteNonQuery();
                    }

                    // Обновляем dataGridView2 после удаления
                    PopulateDataGridView("SELECT * FROM public.certificate", dataGridView2);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection__ = new NpgsqlConnection(connection))
            {
                connection__.Open();

                // Проверяем, выбрана ли хотя бы одна строка
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    // Получаем значение из textBox1
                    int selectedClientId = Convert.ToInt32(textBox1.Text);


                    int selectedTrainingPrtId = Convert.ToInt32(textBox3.Text);


                    // Используем selectedClientId при добавлении сертификата
                    string insertQuery = "INSERT INTO public.training (id_client_fk, id_training_programm_fk, start_date, end_date, city, name_of_organization) " +
                                        "VALUES (@idclientfk, @idtrainingprfk, @start, @end, @city, @organizname)";
                    string inserttQuery = "INSERT INTO public.certificate (id_client_fk, id_training_fk, date_of_issue) " +
                                        "VALUES (@idclientfk, @idtrainingfk, @issue)";

                    using (NpgsqlCommand comm = new NpgsqlCommand(insertQuery, connection__))
                    {
                        comm.Parameters.AddWithValue("@idclientfk", selectedClientId);
                        comm.Parameters.AddWithValue("@idtrainingprfk", selectedTrainingPrtId);
                        comm.Parameters.AddWithValue("@start", dateTimePicker1.Value); // Пример даты начала
                        comm.Parameters.AddWithValue("@end", dateTimePicker2.Value); // Пример даты окончания
                        comm.Parameters.AddWithValue("@city", comboBox3.Text);
                        comm.Parameters.AddWithValue("@organizname", comboBox1.Text);
                        comm.ExecuteNonQuery();
                    }

                    using (NpgsqlCommand comm = new NpgsqlCommand(inserttQuery, connection__))
                    {
                        comm.Parameters.AddWithValue("@idclientfk", selectedClientId);
                        comm.Parameters.AddWithValue("@idtrainingfk", GetLastInsertedTrainingId(connection__));
                        comm.Parameters.AddWithValue("@issue", dateTimePicker3.Value); // Пример даты выдачи
                        comm.ExecuteNonQuery();
                    }

                    MessageBox.Show("Сертификат добавлен.");

                    // Обновляем dataGridView1 и dataGridView2
                    PopulateDataGridView("SELECT * FROM public.training", dataGridView1);
                    PopulateDataGridView("SELECT * FROM public.certificate", dataGridView2);
                }
                else
                {
                    MessageBox.Show("Выберите клиента для добавления сертификата.");
                }
            }
        }

        private int GetLastInsertedTrainingId(NpgsqlConnection connection)
        {
            using (NpgsqlCommand comm = new NpgsqlCommand("SELECT MAX(id_training) FROM public.training", connection))
            {
                return Convert.ToInt32(comm.ExecuteScalar());
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Получаем значение из выбранной строки в dataGridView3
                int selectedClientId = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells["id_client"].Value);

                // Заполняем textBox6 номером id преподавателя из dataGridView3
                textBox1.Text = selectedClientId.ToString();
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Получаем значение из выбранной строки в dataGridView3
                int selectedTrainingPrtId = Convert.ToInt32(dataGridView4.Rows[e.RowIndex].Cells["id_training_programm"].Value);

                // Заполняем textBox6 номером id преподавателя из dataGridView3
                textBox3.Text = selectedTrainingPrtId.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Otchet otchetik = new Otchet();
            otchetik.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем выделенную строку
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Добавляем вывод отладочной информации
                Console.WriteLine($"Selected Row Index: {selectedRow.Index}");

                // Создаем новую форму редактирования
                Edit editForm = new Edit();

                // Передаем данные из выбранной строки в форму редактирования
                editForm.SetData(
                    selectedRow.Cells["название_учебной_программы"].Value.ToString(),
                    Convert.ToDateTime(selectedRow.Cells["дата_начала"].Value),
                    Convert.ToDateTime(selectedRow.Cells["дата_окончания"].Value),
                    selectedRow.Cells["количество_часов"].Value.ToString(),
                    Convert.ToDateTime(selectedRow.Cells["дата_выдачи"].Value),
                    selectedRow.Cells["город"].Value.ToString(),
                    selectedRow.Cells["название_организации"].Value.ToString()
                );

                // Отображаем форму редактирования
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования.");
            }
        }
    }
}
