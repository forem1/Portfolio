namespace Avia
{
    partial class ImportSchedule
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ImportScheduleNoFull_Label = new System.Windows.Forms.Label();
            this.ImportScheduleDuplicate_Label = new System.Windows.Forms.Label();
            this.ImportScheduleSuccess_Label = new System.Windows.Forms.Label();
            this.ImportScheduleImport_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ImportSchedulePath_Box = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ImportScheduleNoFull_Label);
            this.groupBox1.Controls.Add(this.ImportScheduleDuplicate_Label);
            this.groupBox1.Controls.Add(this.ImportScheduleSuccess_Label);
            this.groupBox1.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(64, 144);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(482, 141);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // ImportScheduleNoFull_Label
            // 
            this.ImportScheduleNoFull_Label.AutoSize = true;
            this.ImportScheduleNoFull_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImportScheduleNoFull_Label.Location = new System.Drawing.Point(6, 98);
            this.ImportScheduleNoFull_Label.Name = "ImportScheduleNoFull_Label";
            this.ImportScheduleNoFull_Label.Size = new System.Drawing.Size(258, 20);
            this.ImportScheduleNoFull_Label.TabIndex = 28;
            this.ImportScheduleNoFull_Label.Text = "Record with missing fields discarded:";
            // 
            // ImportScheduleDuplicate_Label
            // 
            this.ImportScheduleDuplicate_Label.AutoSize = true;
            this.ImportScheduleDuplicate_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImportScheduleDuplicate_Label.Location = new System.Drawing.Point(6, 63);
            this.ImportScheduleDuplicate_Label.Name = "ImportScheduleDuplicate_Label";
            this.ImportScheduleDuplicate_Label.Size = new System.Drawing.Size(213, 20);
            this.ImportScheduleDuplicate_Label.TabIndex = 27;
            this.ImportScheduleDuplicate_Label.Text = "Duplicate Records Discarded;";
            // 
            // ImportScheduleSuccess_Label
            // 
            this.ImportScheduleSuccess_Label.AutoSize = true;
            this.ImportScheduleSuccess_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImportScheduleSuccess_Label.Location = new System.Drawing.Point(6, 33);
            this.ImportScheduleSuccess_Label.Name = "ImportScheduleSuccess_Label";
            this.ImportScheduleSuccess_Label.Size = new System.Drawing.Size(212, 20);
            this.ImportScheduleSuccess_Label.TabIndex = 26;
            this.ImportScheduleSuccess_Label.Text = "Successful Changed Applied:";
            // 
            // ImportScheduleImport_Btn
            // 
            this.ImportScheduleImport_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImportScheduleImport_Btn.Location = new System.Drawing.Point(414, 74);
            this.ImportScheduleImport_Btn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ImportScheduleImport_Btn.Name = "ImportScheduleImport_Btn";
            this.ImportScheduleImport_Btn.Size = new System.Drawing.Size(132, 39);
            this.ImportScheduleImport_Btn.TabIndex = 32;
            this.ImportScheduleImport_Btn.Text = "Import";
            this.ImportScheduleImport_Btn.UseVisualStyleBackColor = true;
            this.ImportScheduleImport_Btn.Click += new System.EventHandler(this.ImportScheduleImport_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(60, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Please select the text file with the changes";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ImportSchedulePath_Box
            // 
            this.ImportSchedulePath_Box.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImportSchedulePath_Box.Location = new System.Drawing.Point(64, 87);
            this.ImportSchedulePath_Box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ImportSchedulePath_Box.Name = "ImportSchedulePath_Box";
            this.ImportSchedulePath_Box.ReadOnly = true;
            this.ImportSchedulePath_Box.Size = new System.Drawing.Size(288, 26);
            this.ImportSchedulePath_Box.TabIndex = 34;
            // 
            // ImportSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 353);
            this.Controls.Add(this.ImportSchedulePath_Box);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ImportScheduleImport_Btn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ImportSchedule";
            this.Text = "Apply Schedule Changes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ImportScheduleNoFull_Label;
        private System.Windows.Forms.Label ImportScheduleDuplicate_Label;
        private System.Windows.Forms.Label ImportScheduleSuccess_Label;
        private System.Windows.Forms.Button ImportScheduleImport_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox ImportSchedulePath_Box;
    }
}