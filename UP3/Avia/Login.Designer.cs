namespace Avia
{
    partial class Login
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Login_Btn = new System.Windows.Forms.Button();
            this.ExitLogin_Btn = new System.Windows.Forms.Button();
            this.LoginEnter_Box = new System.Windows.Forms.TextBox();
            this.PasswordEnter_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Login_Btn
            // 
            this.Login_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login_Btn.Location = new System.Drawing.Point(156, 248);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(114, 31);
            this.Login_Btn.TabIndex = 0;
            this.Login_Btn.Text = "Login";
            this.Login_Btn.UseVisualStyleBackColor = true;
            this.Login_Btn.Click += new System.EventHandler(this.Login_Btn_Click);
            // 
            // ExitLogin_Btn
            // 
            this.ExitLogin_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitLogin_Btn.Location = new System.Drawing.Point(304, 248);
            this.ExitLogin_Btn.Name = "ExitLogin_Btn";
            this.ExitLogin_Btn.Size = new System.Drawing.Size(120, 31);
            this.ExitLogin_Btn.TabIndex = 1;
            this.ExitLogin_Btn.Text = "Exit";
            this.ExitLogin_Btn.UseVisualStyleBackColor = true;
            this.ExitLogin_Btn.Click += new System.EventHandler(this.ExitLogin_Btn_Click);
            // 
            // LoginEnter_Box
            // 
            this.LoginEnter_Box.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginEnter_Box.Location = new System.Drawing.Point(140, 164);
            this.LoginEnter_Box.Name = "LoginEnter_Box";
            this.LoginEnter_Box.Size = new System.Drawing.Size(306, 28);
            this.LoginEnter_Box.TabIndex = 2;
            // 
            // PasswordEnter_Box
            // 
            this.PasswordEnter_Box.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordEnter_Box.Location = new System.Drawing.Point(140, 204);
            this.PasswordEnter_Box.Name = "PasswordEnter_Box";
            this.PasswordEnter_Box.Size = new System.Drawing.Size(306, 28);
            this.PasswordEnter_Box.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(57, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(61, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(134, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(312, 130);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 309);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordEnter_Box);
            this.Controls.Add(this.LoginEnter_Box);
            this.Controls.Add(this.ExitLogin_Btn);
            this.Controls.Add(this.Login_Btn);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login_Btn;
        private System.Windows.Forms.Button ExitLogin_Btn;
        private System.Windows.Forms.TextBox LoginEnter_Box;
        private System.Windows.Forms.TextBox PasswordEnter_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

