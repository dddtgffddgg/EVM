using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace courses
{
    public partial class cli : Form
    {
        private string connection = String.Format("Server = localhost; port = 5432; user id = postgres; password = diana2004; database = qualification_courses;");
        private NpgsqlConnection conn;

        public delegate void UpdateClientListDelegate();
        public event UpdateClientListDelegate UpdateClientList;


        public cli()
        {
            InitializeComponent();

            conn = new NpgsqlConnection(connection);


            PopulateDataGridView("select * from client", dataGridView1);
            PopulateDataGridView("select * from training_programm", dataGridView2);
            PopulateDataGridView("select * from teacher", dataGridView3);

            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView2.CellClick += dataGridView2_CellClick;
            dataGridView3.CellClick += dataGridView3_CellClick;

            AddDeleteButtonColumn(dataGridView1, "id_client", "public.client");
            AddDeleteButtonColumn(dataGridView2, "id_training_programm", "public.training_programm");
            AddDeleteButtonColumn(dataGridView3, "id_teacher", "public.teacher");

            dataGridView1.Columns["id_client"].HeaderText = "ID клиента";
            dataGridView1.Columns["id_training_programm"].HeaderText = "ID учебной программы";
            dataGridView1.Columns["id_teacher"].HeaderText = "ID преподавателя";

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //переход к сертификату
        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report re = new Report();
            re.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        //объединение datagridview
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

        //Кнопка добавить клиента
        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection_ = new NpgsqlConnection(connection))
            {
                connection_.Open();
                string insertQuery = "INSERT INTO public.client (full_name, specialization, diplom_seria, diplom_number, phone_number) VALUES (@fullname, @spec, @seria, @diplomnumber, @phonenumber)";
                using (NpgsqlCommand comm = new NpgsqlCommand(insertQuery, connection_))
                {
                    comm.Parameters.AddWithValue("@fullname", textBox1.Text);
                    comm.Parameters.AddWithValue("@spec", textBox3.Text);
                    comm.Parameters.AddWithValue("@seria", maskedTextBox6.Text);
                    comm.Parameters.AddWithValue("@diplomnumber", maskedTextBox5.Text);
                    comm.Parameters.AddWithValue("@phonenumber", maskedTextBox1.Text);
                    comm.ExecuteNonQuery();
                }

                MessageBox.Show("Клиент успешно добавлен. ");

                PopulateDataGridView("SELECT * FROM public.client", dataGridView1);
            }

        }

        private DataTable getdata(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand(query, conn);
                comm.CommandType = CommandType.Text;
                NpgsqlDataReader dr = comm.ExecuteReader();

                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        //кнопка поиска клиента
        private void button11_Click(object sender, EventArgs e)
        {
            string searchKeyword = textBox4.Text;

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                string npgsql = $"SELECT * FROM public.client WHERE " + $"full_name LIKE '%{searchKeyword}%' OR " + $"specialization LIKE '%{searchKeyword}%' OR " + $"diplom_seria LIKE '%{searchKeyword}%' OR " + $"diplom_number LIKE '%{searchKeyword}%' ";

                DataTable dtSearchResult = getdata(npgsql);
                MessageBox.Show($"Найдено {dtSearchResult.Rows.Count} записей соотвествующих критериям поиска.");
                dataGridView1.DataSource = dtSearchResult;

            }
            else
            {
                DataTable dtAllData = getdata("SELECT * FROM public.client");
                dataGridView1.DataSource = dtAllData;
            }

        }

        //кнопка поиска преподавателя
        private void button12_Click(object sender, EventArgs e)
        {
            string searchKeyword = textBox5.Text;

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                string npgsql = $"SELECT * FROM public.teacher WHERE " + $"full_name LIKE '%{searchKeyword}%' OR " + $"specialization LIKE '%{searchKeyword}%' OR " + $"diplom_seria LIKE '%{searchKeyword}%' OR " + $"diplom_number LIKE '%{searchKeyword}%' ";

                DataTable dtSearchResult = getdata(npgsql);
                MessageBox.Show($"Найдено {dtSearchResult.Rows.Count} записей соотвествующих критериям поиска.");
                dataGridView3.DataSource = dtSearchResult;

            }
            else
            {
                DataTable dtAllData = getdata("SELECT * FROM public.teacher");
                dataGridView3.DataSource = dtAllData;
            }
        }


        //кнопка добавить учнебную программу
        private void button6_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection__ = new NpgsqlConnection(connection))
            {
                connection__.Open();

                // Проверяем, выбрана ли хотя бы одна строка
                if (!string.IsNullOrEmpty(textBox6.Text))
                {
                    // Получаем значение из textBox6
                    int selectedTeacherId = Convert.ToInt32(textBox6.Text);

                    // Используем selectedTeacherId при добавлении учебной программы
                    string insertQuery = "INSERT INTO public.training_programm (id_teacher_fk, name, number_of_hour, clients_group) " +
                                        "VALUES (@idteacherfk, @name, @numberofhour, @clientsgroup)";

                    using (NpgsqlCommand comm = new NpgsqlCommand(insertQuery, connection__))
                    {
                        comm.Parameters.AddWithValue("@idteacherfk", selectedTeacherId);
                        comm.Parameters.AddWithValue("@name", comboBox2.Text);
                        comm.Parameters.AddWithValue("@numberofhour", textBox9.Text);
                        comm.Parameters.AddWithValue("@clientsgroup", textBox2.Text);
                        comm.ExecuteNonQuery();
                    }

                    MessageBox.Show("Учебная программа добавлена.");

                    // Обновляем dataGridView2
                    PopulateDataGridView($"SELECT * FROM public.training_programm", dataGridView2);
                }
                else
                {
                    MessageBox.Show("Выберите преподавателя для добавления учебной программы.");
                }
            }

        }

        //кнопка добавить преподавателя
        private void button9_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connectionn = new NpgsqlConnection(connection))
            {
                connectionn.Open();
                string insertQuery = "INSERT INTO public.teacher (full_name, specialization, diplom_seria, diplom_number, phone_number) VALUES (@fullname, @spec, @seria, @diplomnumber, @phonenumber)";
                using (NpgsqlCommand comm = new NpgsqlCommand(insertQuery, connectionn))
                {
                    comm.Parameters.AddWithValue("@fullname", textBox12.Text);
                    comm.Parameters.AddWithValue("@spec", textBox11.Text);
                    comm.Parameters.AddWithValue("@seria", maskedTextBox3.Text);
                    comm.Parameters.AddWithValue("@diplomnumber", maskedTextBox4.Text);
                    comm.Parameters.AddWithValue("@phonenumber", maskedTextBox2.Text);
                    comm.ExecuteNonQuery();
                }

                MessageBox.Show("Преподаватель успешно добавлен.");

                PopulateDataGridView("SELECT * FROM public.teacher", dataGridView3);
            }

            
        }

        //кнопка очистки в клиенте
        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox1.Clear();
            maskedTextBox1.Clear();
            textBox3.Clear();
            maskedTextBox6.Clear();
            maskedTextBox5.Clear();
        }

        //кнопка удаления клиентов
        private void button3_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connectio_n = new NpgsqlConnection(connection))
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить запись с ID ?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    connectio_n.Open();
                    string deleteQuery = "DELETE FROM public.client WHERE id_client = @id_client AND full_name";
                    using (NpgsqlCommand comm = new NpgsqlCommand(deleteQuery, connectio_n)) ;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
            textBox2.Clear();
            textBox6.Clear();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox12.Clear();
            maskedTextBox2.Clear();
            textBox11.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            /* DataGridView dataGridView = (DataGridView)sender;
             DataGridView_CellContentClick(e, dataGridView, "id_client", "public.client");*/
        }

        private void AddDeleteButtonColumn(DataGridView dataGridView, string idColumnName, string tableName)
        {
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "Удалить";
            deleteColumn.Name = "DeleteColumn";
            deleteColumn.Text = "Удалить";
            deleteColumn.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(deleteColumn);

            dataGridView.Tag = tableName;

            dataGridView.CellContentClick += (sender, e) => DataGridView_CellContentClick(sender, e, idColumnName, tableName);
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e, string idColumnName, string tableName)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == ((DataGridView)sender).Columns["DeleteColumn"].Index)
            {
                DataGridView dataGridView = (DataGridView)sender;
                // Получаем значение из выбранной строки
                int selectedId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[idColumnName].Value);

                if (MessageBox.Show($"Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string deleteQuery = $"DELETE FROM {tableName} WHERE {idColumnName} = @Id";

                    using (NpgsqlConnection connection_ = new NpgsqlConnection(connection))
                    {
                        try
                        {
                            connection_.Open();

                            using (NpgsqlCommand comm = new NpgsqlCommand(deleteQuery, connection_))
                            {
                                comm.Parameters.AddWithValue("@Id", selectedId);
                                comm.ExecuteNonQuery();
                            }

                            // Уведомление о удалении
                            MessageBox.Show("Запись успешно удалена.");

                            // Обновление DataGridView после удаления
                            PopulateDataGridView($"SELECT * FROM {tableName}", dataGridView);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка удаления: {ex.Message}");
                        }
                        finally
                        {
                            connection_.Close();
                        }
                    }
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Получаем значение из выбранной строки в dataGridView3
                int selectedTeacherId = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells["id_teacher"].Value);

                // Заполняем textBox6 номером id преподавателя из dataGridView3
                textBox6.Text = selectedTeacherId.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView_CellContentClick(sender, e, "id_client", "public.client");
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView_CellContentClick(sender, e, "id_training_programm", "public.training_programm");
        }
    }
}
