namespace Avia
{
    partial class SearchFlight
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
            this.SearchOutboundGrid_View = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UpdateUserRole_Radio = new System.Windows.Forms.Panel();
            this.SearchParametersOneWay_Radio = new System.Windows.Forms.RadioButton();
            this.SearchParametersReturn_Radio = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.SearchParametersReturn_Picker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchParametersApply_Btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SearchParametersOutbound_Picker = new System.Windows.Forms.DateTimePicker();
            this.SearchParametersCabin_Combobox = new System.Windows.Forms.ComboBox();
            this.SearchParametersTo_Combobox = new System.Windows.Forms.ComboBox();
            this.SearchParametersFrom_Combobox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SearchOutboundThree_Check = new System.Windows.Forms.CheckBox();
            this.SearchReturnThree_Check = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SearchReturnGrid_View = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SearchPassengers_Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchBook_Btn = new System.Windows.Forms.Button();
            this.SearchCancel_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SearchOutboundGrid_View)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.UpdateUserRole_Radio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchReturnGrid_View)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchOutboundGrid_View
            // 
            this.SearchOutboundGrid_View.AllowUserToAddRows = false;
            this.SearchOutboundGrid_View.AllowUserToDeleteRows = false;
            this.SearchOutboundGrid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchOutboundGrid_View.Location = new System.Drawing.Point(12, 186);
            this.SearchOutboundGrid_View.MultiSelect = false;
            this.SearchOutboundGrid_View.Name = "SearchOutboundGrid_View";
            this.SearchOutboundGrid_View.ReadOnly = true;
            this.SearchOutboundGrid_View.RowHeadersWidth = 51;
            this.SearchOutboundGrid_View.RowTemplate.Height = 24;
            this.SearchOutboundGrid_View.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SearchOutboundGrid_View.Size = new System.Drawing.Size(919, 175);
            this.SearchOutboundGrid_View.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UpdateUserRole_Radio);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.SearchParametersReturn_Picker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.SearchParametersApply_Btn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.SearchParametersOutbound_Picker);
            this.groupBox1.Controls.Add(this.SearchParametersCabin_Combobox);
            this.groupBox1.Controls.Add(this.SearchParametersTo_Combobox);
            this.groupBox1.Controls.Add(this.SearchParametersFrom_Combobox);
            this.groupBox1.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(919, 143);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Parameters";
            // 
            // UpdateUserRole_Radio
            // 
            this.UpdateUserRole_Radio.Controls.Add(this.SearchParametersOneWay_Radio);
            this.UpdateUserRole_Radio.Controls.Add(this.SearchParametersReturn_Radio);
            this.UpdateUserRole_Radio.Location = new System.Drawing.Point(20, 74);
            this.UpdateUserRole_Radio.Name = "UpdateUserRole_Radio";
            this.UpdateUserRole_Radio.Size = new System.Drawing.Size(180, 55);
            this.UpdateUserRole_Radio.TabIndex = 29;
            // 
            // SearchParametersOneWay_Radio
            // 
            this.SearchParametersOneWay_Radio.AutoSize = true;
            this.SearchParametersOneWay_Radio.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchParametersOneWay_Radio.Location = new System.Drawing.Point(84, 17);
            this.SearchParametersOneWay_Radio.Name = "SearchParametersOneWay_Radio";
            this.SearchParametersOneWay_Radio.Size = new System.Drawing.Size(93, 24);
            this.SearchParametersOneWay_Radio.TabIndex = 26;
            this.SearchParametersOneWay_Radio.TabStop = true;
            this.SearchParametersOneWay_Radio.Text = "One way";
            this.SearchParametersOneWay_Radio.UseVisualStyleBackColor = true;
            // 
            // SearchParametersReturn_Radio
            // 
            this.SearchParametersReturn_Radio.AutoSize = true;
            this.SearchParametersReturn_Radio.Checked = true;
            this.SearchParametersReturn_Radio.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchParametersReturn_Radio.Location = new System.Drawing.Point(3, 17);
            this.SearchParametersReturn_Radio.Name = "SearchParametersReturn_Radio";
            this.SearchParametersReturn_Radio.Size = new System.Drawing.Size(74, 24);
            this.SearchParametersReturn_Radio.TabIndex = 25;
            this.SearchParametersReturn_Radio.TabStop = true;
            this.SearchParametersReturn_Radio.Text = "Return";
            this.SearchParametersReturn_Radio.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(531, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Return";
            // 
            // SearchParametersReturn_Picker
            // 
            this.SearchParametersReturn_Picker.Location = new System.Drawing.Point(590, 88);
            this.SearchParametersReturn_Picker.Name = "SearchParametersReturn_Picker";
            this.SearchParametersReturn_Picker.Size = new System.Drawing.Size(132, 26);
            this.SearchParametersReturn_Picker.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(497, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Cabin type";
            // 
            // SearchParametersApply_Btn
            // 
            this.SearchParametersApply_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchParametersApply_Btn.Location = new System.Drawing.Point(761, 89);
            this.SearchParametersApply_Btn.Name = "SearchParametersApply_Btn";
            this.SearchParametersApply_Btn.Size = new System.Drawing.Size(132, 28);
            this.SearchParametersApply_Btn.TabIndex = 18;
            this.SearchParametersApply_Btn.Text = "Apply";
            this.SearchParametersApply_Btn.UseVisualStyleBackColor = true;
            this.SearchParametersApply_Btn.Click += new System.EventHandler(this.SearchParametersApply_Btn_Click);
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
            this.label6.Location = new System.Drawing.Point(226, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Outbound";
            // 
            // SearchParametersOutbound_Picker
            // 
            this.SearchParametersOutbound_Picker.Location = new System.Drawing.Point(314, 89);
            this.SearchParametersOutbound_Picker.Name = "SearchParametersOutbound_Picker";
            this.SearchParametersOutbound_Picker.Size = new System.Drawing.Size(132, 26);
            this.SearchParametersOutbound_Picker.TabIndex = 12;
            // 
            // SearchParametersCabin_Combobox
            // 
            this.SearchParametersCabin_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchParametersCabin_Combobox.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchParametersCabin_Combobox.FormattingEnabled = true;
            this.SearchParametersCabin_Combobox.Items.AddRange(new object[] {
            "",
            "Date",
            "Price",
            "Confirm"});
            this.SearchParametersCabin_Combobox.Location = new System.Drawing.Point(590, 40);
            this.SearchParametersCabin_Combobox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SearchParametersCabin_Combobox.Name = "SearchParametersCabin_Combobox";
            this.SearchParametersCabin_Combobox.Size = new System.Drawing.Size(132, 27);
            this.SearchParametersCabin_Combobox.TabIndex = 6;
            // 
            // SearchParametersTo_Combobox
            // 
            this.SearchParametersTo_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchParametersTo_Combobox.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchParametersTo_Combobox.FormattingEnabled = true;
            this.SearchParametersTo_Combobox.Location = new System.Drawing.Point(314, 40);
            this.SearchParametersTo_Combobox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SearchParametersTo_Combobox.Name = "SearchParametersTo_Combobox";
            this.SearchParametersTo_Combobox.Size = new System.Drawing.Size(132, 27);
            this.SearchParametersTo_Combobox.TabIndex = 5;
            // 
            // SearchParametersFrom_Combobox
            // 
            this.SearchParametersFrom_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchParametersFrom_Combobox.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchParametersFrom_Combobox.FormattingEnabled = true;
            this.SearchParametersFrom_Combobox.Location = new System.Drawing.Point(104, 40);
            this.SearchParametersFrom_Combobox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SearchParametersFrom_Combobox.Name = "SearchParametersFrom_Combobox";
            this.SearchParametersFrom_Combobox.Size = new System.Drawing.Size(132, 27);
            this.SearchParametersFrom_Combobox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Outbound flight details";
            // 
            // SearchOutboundThree_Check
            // 
            this.SearchOutboundThree_Check.AutoSize = true;
            this.SearchOutboundThree_Check.Location = new System.Drawing.Point(658, 156);
            this.SearchOutboundThree_Check.Name = "SearchOutboundThree_Check";
            this.SearchOutboundThree_Check.Size = new System.Drawing.Size(273, 24);
            this.SearchOutboundThree_Check.TabIndex = 19;
            this.SearchOutboundThree_Check.Text = "Display three days before and after";
            this.SearchOutboundThree_Check.UseVisualStyleBackColor = true;
            // 
            // SearchReturnThree_Check
            // 
            this.SearchReturnThree_Check.AutoSize = true;
            this.SearchReturnThree_Check.Location = new System.Drawing.Point(658, 377);
            this.SearchReturnThree_Check.Name = "SearchReturnThree_Check";
            this.SearchReturnThree_Check.Size = new System.Drawing.Size(273, 24);
            this.SearchReturnThree_Check.TabIndex = 22;
            this.SearchReturnThree_Check.Text = "Display three days before and after";
            this.SearchReturnThree_Check.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Outbound flight details";
            // 
            // SearchReturnGrid_View
            // 
            this.SearchReturnGrid_View.AllowUserToAddRows = false;
            this.SearchReturnGrid_View.AllowUserToDeleteRows = false;
            this.SearchReturnGrid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchReturnGrid_View.Location = new System.Drawing.Point(12, 407);
            this.SearchReturnGrid_View.MultiSelect = false;
            this.SearchReturnGrid_View.Name = "SearchReturnGrid_View";
            this.SearchReturnGrid_View.ReadOnly = true;
            this.SearchReturnGrid_View.RowHeadersWidth = 51;
            this.SearchReturnGrid_View.RowTemplate.Height = 24;
            this.SearchReturnGrid_View.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SearchReturnGrid_View.Size = new System.Drawing.Size(919, 175);
            this.SearchReturnGrid_View.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SearchPassengers_Box);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.SearchBook_Btn);
            this.groupBox2.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(319, 600);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 66);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Confirm boking for";
            // 
            // SearchPassengers_Box
            // 
            this.SearchPassengers_Box.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchPassengers_Box.Location = new System.Drawing.Point(18, 27);
            this.SearchPassengers_Box.Name = "SearchPassengers_Box";
            this.SearchPassengers_Box.Size = new System.Drawing.Size(68, 26);
            this.SearchPassengers_Box.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(92, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Passengers";
            // 
            // SearchBook_Btn
            // 
            this.SearchBook_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBook_Btn.Location = new System.Drawing.Point(194, 25);
            this.SearchBook_Btn.Name = "SearchBook_Btn";
            this.SearchBook_Btn.Size = new System.Drawing.Size(132, 28);
            this.SearchBook_Btn.TabIndex = 18;
            this.SearchBook_Btn.Text = "Book flight";
            this.SearchBook_Btn.UseVisualStyleBackColor = true;
            this.SearchBook_Btn.Click += new System.EventHandler(this.SearchBook_Btn_Click);
            // 
            // SearchCancel_Btn
            // 
            this.SearchCancel_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchCancel_Btn.Location = new System.Drawing.Point(758, 622);
            this.SearchCancel_Btn.Name = "SearchCancel_Btn";
            this.SearchCancel_Btn.Size = new System.Drawing.Size(132, 28);
            this.SearchCancel_Btn.TabIndex = 31;
            this.SearchCancel_Btn.Text = "Cancel";
            this.SearchCancel_Btn.UseVisualStyleBackColor = true;
            this.SearchCancel_Btn.Click += new System.EventHandler(this.SearchCancel_Btn_Click);
            // 
            // SearchFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 695);
            this.Controls.Add(this.SearchCancel_Btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SearchReturnThree_Check);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SearchReturnGrid_View);
            this.Controls.Add(this.SearchOutboundThree_Check);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SearchOutboundGrid_View);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SearchFlight";
            this.Text = "Search for flights";
            ((System.ComponentModel.ISupportInitialize)(this.SearchOutboundGrid_View)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.UpdateUserRole_Radio.ResumeLayout(false);
            this.UpdateUserRole_Radio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchReturnGrid_View)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SearchOutboundGrid_View;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SearchParametersApply_Btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker SearchParametersOutbound_Picker;
        private System.Windows.Forms.ComboBox SearchParametersCabin_Combobox;
        private System.Windows.Forms.ComboBox SearchParametersTo_Combobox;
        private System.Windows.Forms.ComboBox SearchParametersFrom_Combobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker SearchParametersReturn_Picker;
        private System.Windows.Forms.Panel UpdateUserRole_Radio;
        private System.Windows.Forms.RadioButton SearchParametersOneWay_Radio;
        private System.Windows.Forms.RadioButton SearchParametersReturn_Radio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox SearchOutboundThree_Check;
        private System.Windows.Forms.CheckBox SearchReturnThree_Check;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView SearchReturnGrid_View;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SearchBook_Btn;
        private System.Windows.Forms.TextBox SearchPassengers_Box;
        private System.Windows.Forms.Button SearchCancel_Btn;
    }
}