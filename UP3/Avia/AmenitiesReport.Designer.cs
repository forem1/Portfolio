namespace Avia
{
    partial class AmenitiesReport
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
            this.AmenitiesReportOk_Btn = new System.Windows.Forms.Button();
            this.AmenitiesReportGrid_View = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.AmenitiesReportDate_Picker = new System.Windows.Forms.DateTimePicker();
            this.AmenitiesReportCode_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AmenitiesReportGrid_View)).BeginInit();
            this.SuspendLayout();
            // 
            // AmenitiesReportOk_Btn
            // 
            this.AmenitiesReportOk_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmenitiesReportOk_Btn.Location = new System.Drawing.Point(723, 39);
            this.AmenitiesReportOk_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AmenitiesReportOk_Btn.Name = "AmenitiesReportOk_Btn";
            this.AmenitiesReportOk_Btn.Size = new System.Drawing.Size(54, 26);
            this.AmenitiesReportOk_Btn.TabIndex = 45;
            this.AmenitiesReportOk_Btn.Text = "OK";
            this.AmenitiesReportOk_Btn.UseVisualStyleBackColor = true;
            // 
            // AmenitiesReportGrid_View
            // 
            this.AmenitiesReportGrid_View.AllowUserToAddRows = false;
            this.AmenitiesReportGrid_View.AllowUserToDeleteRows = false;
            this.AmenitiesReportGrid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AmenitiesReportGrid_View.Location = new System.Drawing.Point(12, 153);
            this.AmenitiesReportGrid_View.MultiSelect = false;
            this.AmenitiesReportGrid_View.Name = "AmenitiesReportGrid_View";
            this.AmenitiesReportGrid_View.ReadOnly = true;
            this.AmenitiesReportGrid_View.RowHeadersWidth = 51;
            this.AmenitiesReportGrid_View.RowTemplate.Height = 24;
            this.AmenitiesReportGrid_View.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AmenitiesReportGrid_View.Size = new System.Drawing.Size(1230, 369);
            this.AmenitiesReportGrid_View.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(387, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Flight date:";
            // 
            // AmenitiesReportDate_Picker
            // 
            this.AmenitiesReportDate_Picker.Location = new System.Drawing.Point(517, 39);
            this.AmenitiesReportDate_Picker.Name = "AmenitiesReportDate_Picker";
            this.AmenitiesReportDate_Picker.Size = new System.Drawing.Size(200, 26);
            this.AmenitiesReportDate_Picker.TabIndex = 50;
            // 
            // AmenitiesReportCode_Box
            // 
            this.AmenitiesReportCode_Box.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmenitiesReportCode_Box.Location = new System.Drawing.Point(517, 75);
            this.AmenitiesReportCode_Box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AmenitiesReportCode_Box.Name = "AmenitiesReportCode_Box";
            this.AmenitiesReportCode_Box.Size = new System.Drawing.Size(132, 26);
            this.AmenitiesReportCode_Box.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(387, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Reference code:";
            // 
            // AmenitiesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 534);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AmenitiesReportCode_Box);
            this.Controls.Add(this.AmenitiesReportDate_Picker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AmenitiesReportGrid_View);
            this.Controls.Add(this.AmenitiesReportOk_Btn);
            this.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AmenitiesReport";
            this.Text = "AmenitiesReport";
            ((System.ComponentModel.ISupportInitialize)(this.AmenitiesReportGrid_View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AmenitiesReportOk_Btn;
        private System.Windows.Forms.DataGridView AmenitiesReportGrid_View;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker AmenitiesReportDate_Picker;
        private System.Windows.Forms.TextBox AmenitiesReportCode_Box;
        private System.Windows.Forms.Label label1;
    }
}