namespace Avia
{
    partial class QuestionsImport
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
            this.ImportQuestionsOpen_Btn = new System.Windows.Forms.Button();
            this.ImportQuestionsImport_Btn = new System.Windows.Forms.Button();
            this.ImportQuestionsPath_Box = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.ImportQuestionsDate_Picker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // ImportQuestionsOpen_Btn
            // 
            this.ImportQuestionsOpen_Btn.Location = new System.Drawing.Point(334, 97);
            this.ImportQuestionsOpen_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ImportQuestionsOpen_Btn.Name = "ImportQuestionsOpen_Btn";
            this.ImportQuestionsOpen_Btn.Size = new System.Drawing.Size(100, 27);
            this.ImportQuestionsOpen_Btn.TabIndex = 0;
            this.ImportQuestionsOpen_Btn.Text = "Open file";
            this.ImportQuestionsOpen_Btn.UseVisualStyleBackColor = true;
            this.ImportQuestionsOpen_Btn.Click += new System.EventHandler(this.ImportQuestionsOpen_Btn_Click);
            // 
            // ImportQuestionsImport_Btn
            // 
            this.ImportQuestionsImport_Btn.Location = new System.Drawing.Point(168, 131);
            this.ImportQuestionsImport_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ImportQuestionsImport_Btn.Name = "ImportQuestionsImport_Btn";
            this.ImportQuestionsImport_Btn.Size = new System.Drawing.Size(75, 27);
            this.ImportQuestionsImport_Btn.TabIndex = 1;
            this.ImportQuestionsImport_Btn.Text = "Import";
            this.ImportQuestionsImport_Btn.UseVisualStyleBackColor = true;
            this.ImportQuestionsImport_Btn.Click += new System.EventHandler(this.ImportQuestionsImport_Btn_Click);
            // 
            // ImportQuestionsPath_Box
            // 
            this.ImportQuestionsPath_Box.Location = new System.Drawing.Point(12, 97);
            this.ImportQuestionsPath_Box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ImportQuestionsPath_Box.Name = "ImportQuestionsPath_Box";
            this.ImportQuestionsPath_Box.ReadOnly = true;
            this.ImportQuestionsPath_Box.Size = new System.Drawing.Size(295, 26);
            this.ImportQuestionsPath_Box.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select date";
            // 
            // ImportQuestionsDate_Picker
            // 
            this.ImportQuestionsDate_Picker.CustomFormat = "yyyy-MM";
            this.ImportQuestionsDate_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ImportQuestionsDate_Picker.Location = new System.Drawing.Point(107, 24);
            this.ImportQuestionsDate_Picker.Name = "ImportQuestionsDate_Picker";
            this.ImportQuestionsDate_Picker.ShowUpDown = true;
            this.ImportQuestionsDate_Picker.Size = new System.Drawing.Size(200, 26);
            this.ImportQuestionsDate_Picker.TabIndex = 4;
            // 
            // QuestionsImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 171);
            this.Controls.Add(this.ImportQuestionsDate_Picker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImportQuestionsPath_Box);
            this.Controls.Add(this.ImportQuestionsImport_Btn);
            this.Controls.Add(this.ImportQuestionsOpen_Btn);
            this.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QuestionsImport";
            this.Text = "Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ImportQuestionsOpen_Btn;
        private System.Windows.Forms.Button ImportQuestionsImport_Btn;
        private System.Windows.Forms.TextBox ImportQuestionsPath_Box;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ImportQuestionsDate_Picker;
    }
}