﻿namespace HealthCare_System
{
    partial class AdminScreen
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
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(306, 131);
            button1.Name = "button1";
            button1.Size = new Size(495, 85);
            button1.TabIndex = 0;
            button1.Text = "Manage Doctors Profile";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(306, 264);
            button2.Name = "button2";
            button2.Size = new Size(495, 85);
            button2.TabIndex = 1;
            button2.Text = "Appointment History";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AdminScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1141, 613);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "AdminScreen";
            Text = "AdminScreen";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
    }
}