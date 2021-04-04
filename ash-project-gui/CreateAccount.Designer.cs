namespace ash_project_gui
{
    partial class CreateAccount
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.customGroupBox2 = new ash_project_gui.customGroupBox();
            this.customGroupBox3 = new ash_project_gui.customGroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.customGroupBox1 = new ash_project_gui.customGroupBox();
            this.panel1.SuspendLayout();
            this.customGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tomato;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 30);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(185, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account Creation";
            // 
            // customGroupBox2
            // 
            this.customGroupBox2.BorderColor = System.Drawing.Color.Tomato;
            this.customGroupBox2.ForeColor = System.Drawing.Color.Tomato;
            this.customGroupBox2.Location = new System.Drawing.Point(272, 62);
            this.customGroupBox2.Name = "customGroupBox2";
            this.customGroupBox2.Size = new System.Drawing.Size(200, 43);
            this.customGroupBox2.TabIndex = 1;
            this.customGroupBox2.TabStop = false;
            this.customGroupBox2.Text = "Last Name";
            // 
            // customGroupBox3
            // 
            this.customGroupBox3.BorderColor = System.Drawing.Color.White;
            this.customGroupBox3.Controls.Add(this.dateTimePicker1);
            this.customGroupBox3.ForeColor = System.Drawing.Color.Tomato;
            this.customGroupBox3.Location = new System.Drawing.Point(12, 129);
            this.customGroupBox3.Name = "customGroupBox3";
            this.customGroupBox3.Size = new System.Drawing.Size(235, 43);
            this.customGroupBox3.TabIndex = 1;
            this.customGroupBox3.TabStop = false;
            this.customGroupBox3.Text = "Date Of Birth";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.White;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Tomato;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.Tomato;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 17);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(223, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // customGroupBox1
            // 
            this.customGroupBox1.BorderColor = System.Drawing.Color.Tomato;
            this.customGroupBox1.ForeColor = System.Drawing.Color.Tomato;
            this.customGroupBox1.Location = new System.Drawing.Point(12, 62);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.Size = new System.Drawing.Size(200, 43);
            this.customGroupBox1.TabIndex = 1;
            this.customGroupBox1.TabStop = false;
            this.customGroupBox1.Text = "First Name";
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.customGroupBox2);
            this.Controls.Add(this.customGroupBox3);
            this.Controls.Add(this.customGroupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Create Account";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.customGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private customGroupBox customGroupBox1;
        private customGroupBox customGroupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private customGroupBox customGroupBox3;
    }
}