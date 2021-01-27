namespace Avia
{
    partial class SchedulePanel
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
            this.label4 = new System.Windows.Forms.Label();
            this.ScheduleSortApply_Btn = new System.Windows.Forms.Button();
            this.ScheduleFlightNumber_Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ScheduleOutbound_Picker = new System.Windows.Forms.DateTimePicker();
            this.ScheduleSortBy_ComboBox = new System.Windows.Forms.ComboBox();
            this.ScheduleTo_ComboBox = new System.Windows.Forms.ComboBox();
            this.ScheduleFrom_ComboBox = new System.Windows.Forms.ComboBox();
            this.ScheduleGrid_View = new System.Windows.Forms.DataGridView();
            this.ScheduleCancelFlight_Btn = new System.Windows.Forms.Button();
            this.ScheduleEditFlight_Btn = new System.Windows.Forms.Button();
            this.ScheduleImport_Btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleGrid_View)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ScheduleSortApply_Btn);
            this.groupBox1.Controls.Add(this.ScheduleFlightNumber_Box);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ScheduleOutbound_Picker);
            this.groupBox1.Controls.Add(this.ScheduleSortBy_ComboBox);
            this.groupBox1.Controls.Add(this.ScheduleTo_ComboBox);
            this.groupBox1.Controls.Add(this.ScheduleFrom_ComboBox);
            this.groupBox1.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1018, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter by";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(478, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Sort by";
            // 
            // ScheduleSortApply_Btn
            // 
            this.ScheduleSortApply_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScheduleSortApply_Btn.Location = new System.Drawing.Point(547, 98);
            this.ScheduleSortApply_Btn.Name = "ScheduleSortApply_Btn";
            this.ScheduleSortApply_Btn.Size = new System.Drawing.Size(132, 28);
            this.ScheduleSortApply_Btn.TabIndex = 18;
            this.ScheduleSortApply_Btn.Text = "Apply";
            this.ScheduleSortApply_Btn.UseVisualStyleBackColor = true;
            this.ScheduleSortApply_Btn.Click += new System.EventHandler(this.ScheduleSortApply_Btn_Click);
            // 
            // ScheduleFlightNumber_Box
            // 
            this.ScheduleFlightNumber_Box.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScheduleFlightNumber_Box.Location = new System.Drawing.Point(408, 95);
            this.ScheduleFlightNumber_Box.Name = "ScheduleFlightNumber_Box";
            this.ScheduleFlightNumber_Box.Size = new System.Drawing.Size(112, 26);
            this.ScheduleFlightNumber_Box.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(284, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Flight number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(284, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(16, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Outbound";
            // 
            // ScheduleOutbound_Picker
            // 
            this.ScheduleOutbound_Picker.Location = new System.Drawing.Point(104, 95);
            this.ScheduleOutbound_Picker.Name = "ScheduleOutbound_Picker";
            this.ScheduleOutbound_Picker.Size = new System.Drawing.Size(132, 26);
            this.ScheduleOutbound_Picker.TabIndex = 12;
            this.ScheduleOutbound_Picker.ValueChanged += new System.EventHandler(this.ScheduleOutbound_Picker_ValueChanged);
            // 
            // ScheduleSortBy_ComboBox
            // 
            this.ScheduleSortBy_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScheduleSortBy_ComboBox.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScheduleSortBy_ComboBox.FormattingEnabled = true;
            this.ScheduleSortBy_ComboBox.Items.AddRange(new object[] {
            "",
            "Date",
            "Price",
            "Confirm"});
            this.ScheduleSortBy_ComboBox.Location = new System.Drawing.Point(547, 40);
            this.ScheduleSortBy_ComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScheduleSortBy_ComboBox.Name = "ScheduleSortBy_ComboBox";
            this.ScheduleSortBy_ComboBox.Size = new System.Drawing.Size(132, 27);
            this.ScheduleSortBy_ComboBox.TabIndex = 6;
            // 
            // ScheduleTo_ComboBox
            // 
            this.ScheduleTo_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScheduleTo_ComboBox.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScheduleTo_ComboBox.FormattingEnabled = true;
            this.ScheduleTo_ComboBox.Location = new System.Drawing.Point(314, 40);
            this.ScheduleTo_ComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScheduleTo_ComboBox.Name = "ScheduleTo_ComboBox";
            this.ScheduleTo_ComboBox.Size = new System.Drawing.Size(132, 27);
            this.ScheduleTo_ComboBox.TabIndex = 5;
            // 
            // ScheduleFrom_ComboBox
            // 
            this.ScheduleFrom_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScheduleFrom_ComboBox.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScheduleFrom_ComboBox.FormattingEnabled = true;
            this.ScheduleFrom_ComboBox.Location = new System.Drawing.Point(104, 40);
            this.ScheduleFrom_ComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScheduleFrom_ComboBox.Name = "ScheduleFrom_ComboBox";
            this.ScheduleFrom_ComboBox.Size = new System.Drawing.Size(132, 27);
            this.ScheduleFrom_ComboBox.TabIndex = 4;
            // 
            // ScheduleGrid_View
            // 
            this.ScheduleGrid_View.AllowUserToAddRows = false;
            this.ScheduleGrid_View.AllowUserToDeleteRows = false;
            this.ScheduleGrid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScheduleGrid_View.Location = new System.Drawing.Point(12, 161);
            this.ScheduleGrid_View.MultiSelect = false;
            this.ScheduleGrid_View.Name = "ScheduleGrid_View";
            this.ScheduleGrid_View.ReadOnly = true;
            this.ScheduleGrid_View.RowHeadersWidth = 51;
            this.ScheduleGrid_View.RowTemplate.Height = 24;
            this.ScheduleGrid_View.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ScheduleGrid_View.Size = new System.Drawing.Size(1018, 365);
            this.ScheduleGrid_View.TabIndex = 1;
            // 
            // ScheduleCancelFlight_Btn
            // 
            this.ScheduleCancelFlight_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScheduleCancelFlight_Btn.Location = new System.Drawing.Point(41, 542);
            this.ScheduleCancelFlight_Btn.Name = "ScheduleCancelFlight_Btn";
            this.ScheduleCancelFlight_Btn.Size = new System.Drawing.Size(132, 28);
            this.ScheduleCancelFlight_Btn.TabIndex = 19;
            this.ScheduleCancelFlight_Btn.Text = "Cancel Flight";
            this.ScheduleCancelFlight_Btn.UseVisualStyleBackColor = true;
            this.ScheduleCancelFlight_Btn.Click += new System.EventHandler(this.ScheduleCancelFlight_Btn_Click);
            // 
            // ScheduleEditFlight_Btn
            // 
            this.ScheduleEditFlight_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScheduleEditFlight_Btn.Location = new System.Drawing.Point(199, 542);
            this.ScheduleEditFlight_Btn.Name = "ScheduleEditFlight_Btn";
            this.ScheduleEditFlight_Btn.Size = new System.Drawing.Size(132, 28);
            this.ScheduleEditFlight_Btn.TabIndex = 20;
            this.ScheduleEditFlight_Btn.Text = "Edit Flight";
            this.ScheduleEditFlight_Btn.UseVisualStyleBackColor = true;
            this.ScheduleEditFlight_Btn.Click += new System.EventHandler(this.ScheduleEditFlight_Btn_Click);
            // 
            // ScheduleImport_Btn
            // 
            this.ScheduleImport_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScheduleImport_Btn.Location = new System.Drawing.Point(780, 542);
            this.ScheduleImport_Btn.Name = "ScheduleImport_Btn";
            this.ScheduleImport_Btn.Size = new System.Drawing.Size(132, 28);
            this.ScheduleImport_Btn.TabIndex = 21;
            this.ScheduleImport_Btn.Text = "Import Changes";
            this.ScheduleImport_Btn.UseVisualStyleBackColor = true;
            this.ScheduleImport_Btn.Click += new System.EventHandler(this.ScheduleImport_Btn_Click);
            // 
            // SchedulePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 582);
            this.Controls.Add(this.ScheduleImport_Btn);
            this.Controls.Add(this.ScheduleEditFlight_Btn);
            this.Controls.Add(this.ScheduleCancelFlight_Btn);
            this.Controls.Add(this.ScheduleGrid_View);
            this.Controls.Add(this.groupBox1);
            this.Name = "SchedulePanel";
            this.Text = "Manage Flight Schedules";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleGrid_View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ScheduleFrom_ComboBox;
        private System.Windows.Forms.ComboBox ScheduleSortBy_ComboBox;
        private System.Windows.Forms.ComboBox ScheduleTo_ComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker ScheduleOutbound_Picker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ScheduleFlightNumber_Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ScheduleSortApply_Btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView ScheduleGrid_View;
        private System.Windows.Forms.Button ScheduleCancelFlight_Btn;
        private System.Windows.Forms.Button ScheduleEditFlight_Btn;
        private System.Windows.Forms.Button ScheduleImport_Btn;
    }
}