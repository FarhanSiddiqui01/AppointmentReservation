namespace HealthCare_System
{
    partial class Form1
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            login = new Button();
            Signup = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(350, 149);
            label1.Name = "label1";
            label1.Size = new Size(193, 23);
            label1.TabIndex = 0;
            label1.Text = "Please Enter Your Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(350, 223);
            label2.Name = "label2";
            label2.Size = new Size(217, 23);
            label2.TabIndex = 1;
            label2.Text = "Please Enter Your Password";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(350, 175);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(319, 45);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(350, 249);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(319, 45);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // login
            // 
            login.Location = new Point(527, 318);
            login.Name = "login";
            login.Size = new Size(142, 51);
            login.TabIndex = 4;
            login.Text = "LogIn";
            login.UseVisualStyleBackColor = true;
            login.Click += login_Click;
            // 
            // Signup
            // 
            Signup.Location = new Point(350, 318);
            Signup.Name = "Signup";
            Signup.Size = new Size(142, 51);
            Signup.TabIndex = 5;
            Signup.Text = "SignUp";
            Signup.TextImageRelation = TextImageRelation.TextAboveImage;
            Signup.UseVisualStyleBackColor = true;
            Signup.Click += Signup_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1141, 613);
            Controls.Add(Signup);
            Controls.Add(login);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button login;
        private Button Signup;
    }
}