
namespace Avia
{
    partial class Summary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Summary));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SummaryExit_Btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.SummaryFlightsConfirmed_Label = new System.Windows.Forms.Label();
            this.SummaryFlightsCancelled_Label = new System.Windows.Forms.Label();
            this.SummaryFlightsTime_Label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SummaryFlightsBusiest_Label = new System.Windows.Forms.Label();
            this.SummaryFlightsQuiet_Label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 160);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(638, 304);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "In the last 30 days";
            // 
            // SummaryExit_Btn
            // 
            this.SummaryExit_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SummaryExit_Btn.Location = new System.Drawing.Point(510, 577);
            this.SummaryExit_Btn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.SummaryExit_Btn.Name = "SummaryExit_Btn";
            this.SummaryExit_Btn.Size = new System.Drawing.Size(140, 32);
            this.SummaryExit_Btn.TabIndex = 45;
            this.SummaryExit_Btn.Text = "Close";
            this.SummaryExit_Btn.UseVisualStyleBackColor = true;
            this.SummaryExit_Btn.Click += new System.EventHandler(this.SummaryExit_Btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(170, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 110);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SummaryFlightsTime_Label);
            this.groupBox2.Controls.Add(this.SummaryFlightsCancelled_Label);
            this.groupBox2.Controls.Add(this.SummaryFlightsConfirmed_Label);
            this.groupBox2.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(6, 32);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox2.Size = new System.Drawing.Size(288, 110);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flights";
            // 
            // groupBox3
            // 
            this.groupBox3.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(331, 166);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox3.Size = new System.Drawing.Size(288, 125);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Flights";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SummaryFlightsQuiet_Label);
            this.groupBox4.Controls.Add(this.SummaryFlightsBusiest_Label);
            this.groupBox4.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(6, 166);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox4.Size = new System.Drawing.Size(288, 125);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Number of passenger flying";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(331, 32);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox5.Size = new System.Drawing.Size(288, 110);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Top customers (number of flying)";
            // 
            // SummaryFlightsConfirmed_Label
            // 
            this.SummaryFlightsConfirmed_Label.AutoSize = true;
            this.SummaryFlightsConfirmed_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SummaryFlightsConfirmed_Label.Location = new System.Drawing.Point(6, 27);
            this.SummaryFlightsConfirmed_Label.Name = "SummaryFlightsConfirmed_Label";
            this.SummaryFlightsConfirmed_Label.Size = new System.Drawing.Size(142, 20);
            this.SummaryFlightsConfirmed_Label.TabIndex = 44;
            this.SummaryFlightsConfirmed_Label.Text = "Number confirmed:";
            // 
            // SummaryFlightsCancelled_Label
            // 
            this.SummaryFlightsCancelled_Label.AutoSize = true;
            this.SummaryFlightsCancelled_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SummaryFlightsCancelled_Label.Location = new System.Drawing.Point(6, 51);
            this.SummaryFlightsCancelled_Label.Name = "SummaryFlightsCancelled_Label";
            this.SummaryFlightsCancelled_Label.Size = new System.Drawing.Size(143, 20);
            this.SummaryFlightsCancelled_Label.TabIndex = 45;
            this.SummaryFlightsCancelled_Label.Text = "Number cancelled:";
            // 
            // SummaryFlightsTime_Label
            // 
            this.SummaryFlightsTime_Label.AutoSize = true;
            this.SummaryFlightsTime_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SummaryFlightsTime_Label.Location = new System.Drawing.Point(6, 75);
            this.SummaryFlightsTime_Label.Name = "SummaryFlightsTime_Label";
            this.SummaryFlightsTime_Label.Size = new System.Drawing.Size(143, 20);
            this.SummaryFlightsTime_Label.TabIndex = 46;
            this.SummaryFlightsTime_Label.Text = "Average flight time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 49;
            this.label5.Text = "Average flight time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Number cancelled:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 20);
            this.label7.TabIndex = 47;
            this.label7.Text = "Number confirmed:";
            // 
            // SummaryFlightsBusiest_Label
            // 
            this.SummaryFlightsBusiest_Label.AutoSize = true;
            this.SummaryFlightsBusiest_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SummaryFlightsBusiest_Label.Location = new System.Drawing.Point(7, 24);
            this.SummaryFlightsBusiest_Label.Name = "SummaryFlightsBusiest_Label";
            this.SummaryFlightsBusiest_Label.Size = new System.Drawing.Size(88, 20);
            this.SummaryFlightsBusiest_Label.TabIndex = 45;
            this.SummaryFlightsBusiest_Label.Text = "Busiest day:";
            // 
            // SummaryFlightsQuiet_Label
            // 
            this.SummaryFlightsQuiet_Label.AutoSize = true;
            this.SummaryFlightsQuiet_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SummaryFlightsQuiet_Label.Location = new System.Drawing.Point(7, 44);
            this.SummaryFlightsQuiet_Label.Name = "SummaryFlightsQuiet_Label";
            this.SummaryFlightsQuiet_Label.Size = new System.Drawing.Size(116, 20);
            this.SummaryFlightsQuiet_Label.TabIndex = 46;
            this.SummaryFlightsQuiet_Label.Text = "Most quiet day:";
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 644);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SummaryExit_Btn);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Summary";
            this.Text = "Summary";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SummaryExit_Btn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label SummaryFlightsTime_Label;
        private System.Windows.Forms.Label SummaryFlightsCancelled_Label;
        private System.Windows.Forms.Label SummaryFlightsConfirmed_Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label SummaryFlightsQuiet_Label;
        private System.Windows.Forms.Label SummaryFlightsBusiest_Label;
    }
}