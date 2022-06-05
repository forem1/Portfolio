
namespace NeuroWork
{
    partial class MainMenu
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
            this.WorkMenu_Btn = new System.Windows.Forms.Button();
            this.RelaxMenu_Btn = new System.Windows.Forms.Button();
            this.Debug_Btn = new System.Windows.Forms.Button();
            this.Stats_Btn = new System.Windows.Forms.Button();
            this.PostMenu_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WorkMenu_Btn
            // 
            this.WorkMenu_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.WorkMenu_Btn.Location = new System.Drawing.Point(343, 153);
            this.WorkMenu_Btn.Name = "WorkMenu_Btn";
            this.WorkMenu_Btn.Size = new System.Drawing.Size(134, 60);
            this.WorkMenu_Btn.TabIndex = 0;
            this.WorkMenu_Btn.Text = "Работа";
            this.WorkMenu_Btn.UseVisualStyleBackColor = true;
            this.WorkMenu_Btn.Click += new System.EventHandler(this.WorkMenu_Btn_Click);
            // 
            // RelaxMenu_Btn
            // 
            this.RelaxMenu_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.RelaxMenu_Btn.Location = new System.Drawing.Point(343, 219);
            this.RelaxMenu_Btn.Name = "RelaxMenu_Btn";
            this.RelaxMenu_Btn.Size = new System.Drawing.Size(134, 61);
            this.RelaxMenu_Btn.TabIndex = 1;
            this.RelaxMenu_Btn.Text = "Отдых";
            this.RelaxMenu_Btn.UseVisualStyleBackColor = true;
            this.RelaxMenu_Btn.Click += new System.EventHandler(this.RelaxMenu_Btn_Click);
            // 
            // Debug_Btn
            // 
            this.Debug_Btn.Location = new System.Drawing.Point(12, 12);
            this.Debug_Btn.Name = "Debug_Btn";
            this.Debug_Btn.Size = new System.Drawing.Size(75, 27);
            this.Debug_Btn.TabIndex = 2;
            this.Debug_Btn.Text = "Debug";
            this.Debug_Btn.UseVisualStyleBackColor = true;
            this.Debug_Btn.Click += new System.EventHandler(this.Debug_Btn_Click);
            // 
            // Stats_Btn
            // 
            this.Stats_Btn.Location = new System.Drawing.Point(605, 12);
            this.Stats_Btn.Name = "Stats_Btn";
            this.Stats_Btn.Size = new System.Drawing.Size(183, 27);
            this.Stats_Btn.TabIndex = 3;
            this.Stats_Btn.Text = "Статистика и дневник";
            this.Stats_Btn.UseVisualStyleBackColor = true;
            this.Stats_Btn.Click += new System.EventHandler(this.Stats_Btn_Click);
            // 
            // PostMenu_Btn
            // 
            this.PostMenu_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.PostMenu_Btn.Location = new System.Drawing.Point(343, 286);
            this.PostMenu_Btn.Name = "PostMenu_Btn";
            this.PostMenu_Btn.Size = new System.Drawing.Size(134, 61);
            this.PostMenu_Btn.TabIndex = 4;
            this.PostMenu_Btn.Text = "Новая запись в дневнике";
            this.PostMenu_Btn.UseVisualStyleBackColor = true;
            this.PostMenu_Btn.Click += new System.EventHandler(this.PostMenu_Btn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PostMenu_Btn);
            this.Controls.Add(this.Stats_Btn);
            this.Controls.Add(this.Debug_Btn);
            this.Controls.Add(this.RelaxMenu_Btn);
            this.Controls.Add(this.WorkMenu_Btn);
            this.Name = "MainMenu";
            this.Text = "Меню";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WorkMenu_Btn;
        private System.Windows.Forms.Button RelaxMenu_Btn;
        private System.Windows.Forms.Button Debug_Btn;
        private System.Windows.Forms.Button Stats_Btn;
        private System.Windows.Forms.Button PostMenu_Btn;
    }
}