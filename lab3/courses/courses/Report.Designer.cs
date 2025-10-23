namespace courses
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            label10 = new Label();
            label2 = new Label();
            button6 = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            comboBox3 = new ComboBox();
            label6 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            dataGridView2 = new DataGridView();
            label7 = new Label();
            label8 = new Label();
            comboBox4 = new ComboBox();
            dataGridView3 = new DataGridView();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker3 = new DateTimePicker();
            textBox3 = new TextBox();
            label1 = new Label();
            dataGridView4 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(583, 407);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(714, 168);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(44, 298);
            label10.Name = "label10";
            label10.Size = new Size(160, 25);
            label10.TabIndex = 33;
            label10.Text = "Количество часов";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 209);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 36;
            label2.Text = "Дата начала";
            // 
            // button6
            // 
            button6.Location = new Point(48, 618);
            button6.Name = "button6";
            button6.Size = new Size(235, 34);
            button6.TabIndex = 38;
            button6.Text = "Добавить";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(358, 209);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 41;
            label3.Text = "Дата конца";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 379);
            label4.Name = "label4";
            label4.Size = new Size(116, 25);
            label4.TabIndex = 43;
            label4.Text = "Дата выдачи";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 529);
            label5.Name = "label5";
            label5.Size = new Size(201, 25);
            label5.TabIndex = 45;
            label5.Text = "Название организации";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "ООО \"Луч Знаний\"", "ООО \"Центр повышения квалификации\"", "ООО \"Единый центр подготовки кадров\"", "ООО \"Академия безопасности\"", "ООО \"Академия Просвещение\"", "ООО \"Центр Толерантности\"", "ООО \"Экстерн\"" });
            comboBox1.Location = new Point(48, 557);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(470, 33);
            comboBox1.TabIndex = 46;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Красноярск", "Санкт-Петербург", "Грозный", "Ростов", "Москва", "Казань", "Волгоград", "Воронеж", "Краснодар", "Сочи" });
            comboBox3.Location = new Point(48, 481);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(470, 33);
            comboBox3.TabIndex = 47;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(48, 453);
            label6.Name = "label6";
            label6.Size = new Size(63, 25);
            label6.TabIndex = 48;
            label6.Text = "Город";
            // 
            // button1
            // 
            button1.Location = new Point(283, 618);
            button1.Name = "button1";
            button1.Size = new Size(235, 34);
            button1.TabIndex = 49;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(48, 326);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(221, 31);
            textBox2.TabIndex = 50;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(583, 581);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(714, 137);
            dataGridView2.TabIndex = 51;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(48, 26);
            label7.Name = "label7";
            label7.Size = new Size(98, 25);
            label7.TabIndex = 53;
            label7.Text = "ID клиента";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(48, 111);
            label8.Name = "label8";
            label8.Size = new Size(267, 25);
            label8.TabIndex = 55;
            label8.Text = "Название учебной программы";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "История", "Иностранный язык", "Математический анализ", "Физика", "Информатика", "Алгебра и геометрия", "Основы программирования", "Операционные системы", "Алгоритмические языки программирования", "Русский язык и культура речи", "Философия", "Инженерная и компьютерная графика", "Дискретная математика", "Системное программное обеспечение", "Базы данных и базы знаний" });
            comboBox4.Location = new Point(48, 139);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(470, 33);
            comboBox4.TabIndex = 57;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(583, 0);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 62;
            dataGridView3.Size = new Size(714, 184);
            dataGridView3.TabIndex = 58;
            dataGridView3.CellContentClick += dataGridView3_CellContentClick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(48, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(221, 31);
            textBox1.TabIndex = 59;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(48, 235);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(221, 31);
            dateTimePicker1.TabIndex = 60;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(289, 235);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(229, 31);
            dateTimePicker2.TabIndex = 61;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Location = new Point(48, 407);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(221, 31);
            dateTimePicker3.TabIndex = 62;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(297, 54);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(221, 31);
            textBox3.TabIndex = 64;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(297, 26);
            label1.Name = "label1";
            label1.Size = new Size(161, 25);
            label1.TabIndex = 63;
            label1.Text = "ID уч. программы";
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(583, 190);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.RowHeadersWidth = 62;
            dataGridView4.Size = new Size(714, 211);
            dataGridView4.TabIndex = 65;
            dataGridView4.CellContentClick += dataGridView4_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(48, 669);
            button2.Name = "button2";
            button2.Size = new Size(235, 34);
            button2.TabIndex = 66;
            button2.Text = "Отчет";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(283, 669);
            button3.Name = "button3";
            button3.Size = new Size(235, 34);
            button3.TabIndex = 67;
            button3.Text = "Редактировать";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Report
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 715);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView4);
            Controls.Add(textBox3);
            Controls.Add(label1);
            Controls.Add(dateTimePicker3);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView3);
            Controls.Add(comboBox4);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(dataGridView2);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(comboBox3);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button6);
            Controls.Add(label2);
            Controls.Add(label10);
            Controls.Add(dataGridView1);
            Name = "Report";
            Text = "Report";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label10;
        private Label label2;
        private Button button6;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private ComboBox comboBox3;
        private Label label6;
        private Button button1;
        private TextBox textBox2;
        private DataGridView dataGridView2;
        private Label label7;
        private Label label8;
        private ComboBox comboBox4;
        private DataGridView dataGridView3;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker3;
        private TextBox textBox3;
        private Label label1;
        private DataGridView dataGridView4;
        private Button button2;
        private Button button3;
    }
}