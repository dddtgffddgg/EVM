namespace courses
{
    partial class Otchet
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
            label1 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            button2 = new Button();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(458, 9);
            label1.Name = "label1";
            label1.Size = new Size(79, 32);
            label1.TabIndex = 0;
            label1.Text = "Отчет";
            // 
            // button1
            // 
            button1.Location = new Point(905, 293);
            button1.Name = "button1";
            button1.Size = new Size(224, 39);
            button1.TabIndex = 7;
            button1.Text = "Отсортировать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(43, 129);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(692, 439);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(905, 221);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(224, 31);
            textBox1.TabIndex = 9;
            // 
            // button2
            // 
            button2.Location = new Point(905, 529);
            button2.Name = "button2";
            button2.Size = new Size(224, 39);
            button2.TabIndex = 11;
            button2.Text = "Назад";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(905, 156);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(224, 31);
            dateTimePicker1.TabIndex = 12;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // Otchet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 665);
            Controls.Add(dateTimePicker1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Otchet";
            Text = "Otchet";
            Load += Otchet_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Button button2;
        private DateTimePicker dateTimePicker1;
    }
}