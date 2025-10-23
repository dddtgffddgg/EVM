namespace courses
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(359, 9);
            label1.Name = "label1";
            label1.Size = new Size(310, 55);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(188, 173);
            label2.Name = "label2";
            label2.Size = new Size(105, 36);
            label2.TabIndex = 1;
            label2.Text = "Логин";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            label3.Location = new Point(168, 247);
            label3.Name = "label3";
            label3.Size = new Size(125, 36);
            label3.TabIndex = 2;
            label3.Text = "Пароль";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(326, 178);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(387, 31);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(326, 252);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(387, 31);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            button1.Location = new Point(566, 383);
            button1.Name = "button1";
            button1.Size = new Size(147, 63);
            button1.TabIndex = 5;
            button1.Text = "Войти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            button2.Location = new Point(326, 383);
            button2.Name = "button2";
            button2.Size = new Size(175, 63);
            button2.TabIndex = 6;
            button2.Text = "Очистить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBox1.Location = new Point(550, 305);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(163, 24);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Показать пароль";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 544);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Form1";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
    }
}
