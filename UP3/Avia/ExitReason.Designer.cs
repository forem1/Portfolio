namespace Avia
{
    partial class ExitReason
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
            this.NoLogoutText_Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NoLogoutHard_Radio = new System.Windows.Forms.RadioButton();
            this.NoLogoutSoft_Radio = new System.Windows.Forms.RadioButton();
            this.NoLogoutConfirm_Btn = new System.Windows.Forms.Button();
            this.NoLogoutReason_Box = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NoLogoutText_Label
            // 
            this.NoLogoutText_Label.AutoSize = true;
            this.NoLogoutText_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoLogoutText_Label.Location = new System.Drawing.Point(11, 21);
            this.NoLogoutText_Label.Name = "NoLogoutText_Label";
            this.NoLogoutText_Label.Size = new System.Drawing.Size(25, 20);
            this.NoLogoutText_Label.TabIndex = 0;
            this.NoLogoutText_Label.Text = "ex";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reason:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NoLogoutHard_Radio);
            this.panel1.Controls.Add(this.NoLogoutSoft_Radio);
            this.panel1.Location = new System.Drawing.Point(28, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 38);
            this.panel1.TabIndex = 2;
            // 
            // NoLogoutHard_Radio
            // 
            this.NoLogoutHard_Radio.AutoSize = true;
            this.NoLogoutHard_Radio.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoLogoutHard_Radio.Location = new System.Drawing.Point(162, 3);
            this.NoLogoutHard_Radio.Name = "NoLogoutHard_Radio";
            this.NoLogoutHard_Radio.Size = new System.Drawing.Size(140, 24);
            this.NoLogoutHard_Radio.TabIndex = 1;
            this.NoLogoutHard_Radio.TabStop = true;
            this.NoLogoutHard_Radio.Text = "Hardware crash";
            this.NoLogoutHard_Radio.UseVisualStyleBackColor = true;
            this.NoLogoutHard_Radio.CheckedChanged += new System.EventHandler(this.NoLogoutHard_Radio_CheckedChanged);
            // 
            // NoLogoutSoft_Radio
            // 
            this.NoLogoutSoft_Radio.AutoSize = true;
            this.NoLogoutSoft_Radio.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoLogoutSoft_Radio.Location = new System.Drawing.Point(3, 3);
            this.NoLogoutSoft_Radio.Name = "NoLogoutSoft_Radio";
            this.NoLogoutSoft_Radio.Size = new System.Drawing.Size(131, 24);
            this.NoLogoutSoft_Radio.TabIndex = 0;
            this.NoLogoutSoft_Radio.TabStop = true;
            this.NoLogoutSoft_Radio.Text = "Software crash";
            this.NoLogoutSoft_Radio.UseVisualStyleBackColor = true;
            this.NoLogoutSoft_Radio.CheckedChanged += new System.EventHandler(this.NoLogoutSoft_Radio_CheckedChanged);
            // 
            // NoLogoutConfirm_Btn
            // 
            this.NoLogoutConfirm_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoLogoutConfirm_Btn.Location = new System.Drawing.Point(355, 326);
            this.NoLogoutConfirm_Btn.Name = "NoLogoutConfirm_Btn";
            this.NoLogoutConfirm_Btn.Size = new System.Drawing.Size(75, 29);
            this.NoLogoutConfirm_Btn.TabIndex = 3;
            this.NoLogoutConfirm_Btn.Text = "Confirm";
            this.NoLogoutConfirm_Btn.UseVisualStyleBackColor = true;
            this.NoLogoutConfirm_Btn.Click += new System.EventHandler(this.NoLogoutConfirm_Btn_Click);
            // 
            // NoLogoutReason_Box
            // 
            this.NoLogoutReason_Box.Location = new System.Drawing.Point(11, 99);
            this.NoLogoutReason_Box.Multiline = true;
            this.NoLogoutReason_Box.Name = "NoLogoutReason_Box";
            this.NoLogoutReason_Box.Size = new System.Drawing.Size(419, 195);
            this.NoLogoutReason_Box.TabIndex = 4;
            // 
            // ExitReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 393);
            this.Controls.Add(this.NoLogoutReason_Box);
            this.Controls.Add(this.NoLogoutConfirm_Btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NoLogoutText_Label);
            this.Name = "ExitReason";
            this.Text = "No logout detected";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NoLogoutText_Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton NoLogoutHard_Radio;
        private System.Windows.Forms.RadioButton NoLogoutSoft_Radio;
        private System.Windows.Forms.Button NoLogoutConfirm_Btn;
        private System.Windows.Forms.TextBox NoLogoutReason_Box;
    }
}