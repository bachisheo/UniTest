
namespace University.Forms
{
    partial class Main_admin_form
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 57);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить студента";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(257, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(247, 57);
            this.button2.TabIndex = 1;
            this.button2.Text = "Добавить группу";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(257, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(247, 57);
            this.button3.TabIndex = 2;
            this.button3.Text = "Добавить преподавателя";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(257, 268);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(247, 57);
            this.button4.TabIndex = 3;
            this.button4.Text = "Добавить документацию";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Main_admin_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Main_admin_form";
            this.Text = "Рабочее пространство администратора";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_admin_form_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}