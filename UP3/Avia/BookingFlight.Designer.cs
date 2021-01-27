namespace Avia
{
    partial class BookingFlight
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
            this.BookingOutboundFlight_Label = new System.Windows.Forms.Label();
            this.BookingOutboundDate_Label = new System.Windows.Forms.Label();
            this.BookingOutboundFrom_Label = new System.Windows.Forms.Label();
            this.BookingOutboundCabin_Label = new System.Windows.Forms.Label();
            this.BookingOutboundTo_Label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BookingReturnFlight_Label = new System.Windows.Forms.Label();
            this.BookingReturnDate_Label = new System.Windows.Forms.Label();
            this.BookingReturnFrom_Label = new System.Windows.Forms.Label();
            this.BookingReturnCabin_Label = new System.Windows.Forms.Label();
            this.BookingReturnTo_Label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BookingPassengerPhone_Box = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BookingPassengerAdd_Btn = new System.Windows.Forms.Button();
            this.BookingPassengerPassportCountry_Combobox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BookingPassengerPassportNum_Box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BookingPassengerLastname_Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BookingPassengerBirthdate_Picker = new System.Windows.Forms.DateTimePicker();
            this.BookingPassengerFirstname_Box = new System.Windows.Forms.TextBox();
            this.laben2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BookingPassengersGrid_View = new System.Windows.Forms.DataGridView();
            this.Firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AirCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookingCancel_Btn = new System.Windows.Forms.Button();
            this.BookingConfirm_Btn = new System.Windows.Forms.Button();
            this.BookingRemovePassenger_Btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BookingPassengersGrid_View)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BookingOutboundFlight_Label);
            this.groupBox1.Controls.Add(this.BookingOutboundDate_Label);
            this.groupBox1.Controls.Add(this.BookingOutboundFrom_Label);
            this.groupBox1.Controls.Add(this.BookingOutboundCabin_Label);
            this.groupBox1.Controls.Add(this.BookingOutboundTo_Label);
            this.groupBox1.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(730, 70);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Outbounding flight details";
            // 
            // BookingOutboundFlight_Label
            // 
            this.BookingOutboundFlight_Label.AutoSize = true;
            this.BookingOutboundFlight_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingOutboundFlight_Label.Location = new System.Drawing.Point(571, 26);
            this.BookingOutboundFlight_Label.Name = "BookingOutboundFlight_Label";
            this.BookingOutboundFlight_Label.Size = new System.Drawing.Size(107, 20);
            this.BookingOutboundFlight_Label.TabIndex = 21;
            this.BookingOutboundFlight_Label.Text = "Flight number:";
            // 
            // BookingOutboundDate_Label
            // 
            this.BookingOutboundDate_Label.AutoSize = true;
            this.BookingOutboundDate_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingOutboundDate_Label.Location = new System.Drawing.Point(426, 26);
            this.BookingOutboundDate_Label.Name = "BookingOutboundDate_Label";
            this.BookingOutboundDate_Label.Size = new System.Drawing.Size(47, 20);
            this.BookingOutboundDate_Label.TabIndex = 19;
            this.BookingOutboundDate_Label.Text = "Date:";
            // 
            // BookingOutboundFrom_Label
            // 
            this.BookingOutboundFrom_Label.AutoSize = true;
            this.BookingOutboundFrom_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingOutboundFrom_Label.Location = new System.Drawing.Point(15, 26);
            this.BookingOutboundFrom_Label.Name = "BookingOutboundFrom_Label";
            this.BookingOutboundFrom_Label.Size = new System.Drawing.Size(46, 20);
            this.BookingOutboundFrom_Label.TabIndex = 15;
            this.BookingOutboundFrom_Label.Text = "From:";
            // 
            // BookingOutboundCabin_Label
            // 
            this.BookingOutboundCabin_Label.AutoSize = true;
            this.BookingOutboundCabin_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingOutboundCabin_Label.Location = new System.Drawing.Point(226, 26);
            this.BookingOutboundCabin_Label.Name = "BookingOutboundCabin_Label";
            this.BookingOutboundCabin_Label.Size = new System.Drawing.Size(92, 20);
            this.BookingOutboundCabin_Label.TabIndex = 14;
            this.BookingOutboundCabin_Label.Text = "Cabin Type:";
            // 
            // BookingOutboundTo_Label
            // 
            this.BookingOutboundTo_Label.AutoSize = true;
            this.BookingOutboundTo_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingOutboundTo_Label.Location = new System.Drawing.Point(140, 26);
            this.BookingOutboundTo_Label.Name = "BookingOutboundTo_Label";
            this.BookingOutboundTo_Label.Size = new System.Drawing.Size(28, 20);
            this.BookingOutboundTo_Label.TabIndex = 13;
            this.BookingOutboundTo_Label.Text = "To:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BookingReturnFlight_Label);
            this.groupBox2.Controls.Add(this.BookingReturnDate_Label);
            this.groupBox2.Controls.Add(this.BookingReturnFrom_Label);
            this.groupBox2.Controls.Add(this.BookingReturnCabin_Label);
            this.groupBox2.Controls.Add(this.BookingReturnTo_Label);
            this.groupBox2.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 91);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(730, 70);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Return flight details";
            // 
            // BookingReturnFlight_Label
            // 
            this.BookingReturnFlight_Label.AutoSize = true;
            this.BookingReturnFlight_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingReturnFlight_Label.Location = new System.Drawing.Point(571, 26);
            this.BookingReturnFlight_Label.Name = "BookingReturnFlight_Label";
            this.BookingReturnFlight_Label.Size = new System.Drawing.Size(107, 20);
            this.BookingReturnFlight_Label.TabIndex = 21;
            this.BookingReturnFlight_Label.Text = "Flight number:";
            // 
            // BookingReturnDate_Label
            // 
            this.BookingReturnDate_Label.AutoSize = true;
            this.BookingReturnDate_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingReturnDate_Label.Location = new System.Drawing.Point(426, 26);
            this.BookingReturnDate_Label.Name = "BookingReturnDate_Label";
            this.BookingReturnDate_Label.Size = new System.Drawing.Size(47, 20);
            this.BookingReturnDate_Label.TabIndex = 19;
            this.BookingReturnDate_Label.Text = "Date:";
            // 
            // BookingReturnFrom_Label
            // 
            this.BookingReturnFrom_Label.AutoSize = true;
            this.BookingReturnFrom_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingReturnFrom_Label.Location = new System.Drawing.Point(15, 26);
            this.BookingReturnFrom_Label.Name = "BookingReturnFrom_Label";
            this.BookingReturnFrom_Label.Size = new System.Drawing.Size(46, 20);
            this.BookingReturnFrom_Label.TabIndex = 15;
            this.BookingReturnFrom_Label.Text = "From:";
            // 
            // BookingReturnCabin_Label
            // 
            this.BookingReturnCabin_Label.AutoSize = true;
            this.BookingReturnCabin_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingReturnCabin_Label.Location = new System.Drawing.Point(226, 26);
            this.BookingReturnCabin_Label.Name = "BookingReturnCabin_Label";
            this.BookingReturnCabin_Label.Size = new System.Drawing.Size(92, 20);
            this.BookingReturnCabin_Label.TabIndex = 14;
            this.BookingReturnCabin_Label.Text = "Cabin Type:";
            // 
            // BookingReturnTo_Label
            // 
            this.BookingReturnTo_Label.AutoSize = true;
            this.BookingReturnTo_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingReturnTo_Label.Location = new System.Drawing.Point(140, 26);
            this.BookingReturnTo_Label.Name = "BookingReturnTo_Label";
            this.BookingReturnTo_Label.Size = new System.Drawing.Size(28, 20);
            this.BookingReturnTo_Label.TabIndex = 13;
            this.BookingReturnTo_Label.Text = "To:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BookingPassengerPhone_Box);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.BookingPassengerAdd_Btn);
            this.groupBox3.Controls.Add(this.BookingPassengerPassportCountry_Combobox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.BookingPassengerPassportNum_Box);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.BookingPassengerLastname_Box);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.BookingPassengerBirthdate_Picker);
            this.groupBox3.Controls.Add(this.BookingPassengerFirstname_Box);
            this.groupBox3.Controls.Add(this.laben2);
            this.groupBox3.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(12, 188);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(730, 176);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Passenger details";
            // 
            // BookingPassengerPhone_Box
            // 
            this.BookingPassengerPhone_Box.Location = new System.Drawing.Point(592, 102);
            this.BookingPassengerPhone_Box.Mask = "(999) 000-0000";
            this.BookingPassengerPhone_Box.Name = "BookingPassengerPhone_Box";
            this.BookingPassengerPhone_Box.Size = new System.Drawing.Size(132, 26);
            this.BookingPassengerPhone_Box.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(533, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "Phone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(245, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Passport country";
            // 
            // BookingPassengerAdd_Btn
            // 
            this.BookingPassengerAdd_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingPassengerAdd_Btn.Location = new System.Drawing.Point(592, 142);
            this.BookingPassengerAdd_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookingPassengerAdd_Btn.Name = "BookingPassengerAdd_Btn";
            this.BookingPassengerAdd_Btn.Size = new System.Drawing.Size(132, 33);
            this.BookingPassengerAdd_Btn.TabIndex = 31;
            this.BookingPassengerAdd_Btn.Text = "Add passenger";
            this.BookingPassengerAdd_Btn.UseVisualStyleBackColor = true;
            this.BookingPassengerAdd_Btn.Click += new System.EventHandler(this.BookingPassengerAdd_Btn_Click);
            // 
            // BookingPassengerPassportCountry_Combobox
            // 
            this.BookingPassengerPassportCountry_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BookingPassengerPassportCountry_Combobox.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingPassengerPassportCountry_Combobox.FormattingEnabled = true;
            this.BookingPassengerPassportCountry_Combobox.Location = new System.Drawing.Point(372, 108);
            this.BookingPassengerPassportCountry_Combobox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BookingPassengerPassportCountry_Combobox.Name = "BookingPassengerPassportCountry_Combobox";
            this.BookingPassengerPassportCountry_Combobox.Size = new System.Drawing.Size(132, 27);
            this.BookingPassengerPassportCountry_Combobox.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(514, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Birthdate";
            // 
            // BookingPassengerPassportNum_Box
            // 
            this.BookingPassengerPassportNum_Box.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingPassengerPassportNum_Box.Location = new System.Drawing.Point(144, 110);
            this.BookingPassengerPassportNum_Box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookingPassengerPassportNum_Box.Name = "BookingPassengerPassportNum_Box";
            this.BookingPassengerPassportNum_Box.Size = new System.Drawing.Size(81, 26);
            this.BookingPassengerPassportNum_Box.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(15, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Passport number";
            // 
            // BookingPassengerLastname_Box
            // 
            this.BookingPassengerLastname_Box.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingPassengerLastname_Box.Location = new System.Drawing.Point(341, 43);
            this.BookingPassengerLastname_Box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookingPassengerLastname_Box.Name = "BookingPassengerLastname_Box";
            this.BookingPassengerLastname_Box.Size = new System.Drawing.Size(132, 26);
            this.BookingPassengerLastname_Box.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(259, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Lastname";
            // 
            // BookingPassengerBirthdate_Picker
            // 
            this.BookingPassengerBirthdate_Picker.Location = new System.Drawing.Point(592, 43);
            this.BookingPassengerBirthdate_Picker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookingPassengerBirthdate_Picker.Name = "BookingPassengerBirthdate_Picker";
            this.BookingPassengerBirthdate_Picker.Size = new System.Drawing.Size(132, 26);
            this.BookingPassengerBirthdate_Picker.TabIndex = 23;
            // 
            // BookingPassengerFirstname_Box
            // 
            this.BookingPassengerFirstname_Box.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingPassengerFirstname_Box.Location = new System.Drawing.Point(114, 43);
            this.BookingPassengerFirstname_Box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookingPassengerFirstname_Box.Name = "BookingPassengerFirstname_Box";
            this.BookingPassengerFirstname_Box.Size = new System.Drawing.Size(111, 26);
            this.BookingPassengerFirstname_Box.TabIndex = 24;
            // 
            // laben2
            // 
            this.laben2.AutoSize = true;
            this.laben2.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laben2.Location = new System.Drawing.Point(34, 46);
            this.laben2.Name = "laben2";
            this.laben2.Size = new System.Drawing.Size(74, 20);
            this.laben2.TabIndex = 13;
            this.laben2.Text = "Firstname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Passenger list";
            // 
            // BookingPassengersGrid_View
            // 
            this.BookingPassengersGrid_View.AllowUserToAddRows = false;
            this.BookingPassengersGrid_View.AllowUserToDeleteRows = false;
            this.BookingPassengersGrid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookingPassengersGrid_View.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Firstname,
            this.Lastname,
            this.Birthdate,
            this.PassNum,
            this.PassCountry,
            this.Phone,
            this.ScheduleID,
            this.AirCode});
            this.BookingPassengersGrid_View.Location = new System.Drawing.Point(12, 391);
            this.BookingPassengersGrid_View.MultiSelect = false;
            this.BookingPassengersGrid_View.Name = "BookingPassengersGrid_View";
            this.BookingPassengersGrid_View.ReadOnly = true;
            this.BookingPassengersGrid_View.RowHeadersWidth = 51;
            this.BookingPassengersGrid_View.RowTemplate.Height = 24;
            this.BookingPassengersGrid_View.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BookingPassengersGrid_View.Size = new System.Drawing.Size(730, 175);
            this.BookingPassengersGrid_View.TabIndex = 36;
            // 
            // Firstname
            // 
            this.Firstname.HeaderText = "Firstname";
            this.Firstname.MinimumWidth = 6;
            this.Firstname.Name = "Firstname";
            this.Firstname.ReadOnly = true;
            this.Firstname.Width = 125;
            // 
            // Lastname
            // 
            this.Lastname.HeaderText = "Lastname";
            this.Lastname.MinimumWidth = 6;
            this.Lastname.Name = "Lastname";
            this.Lastname.ReadOnly = true;
            this.Lastname.Width = 125;
            // 
            // Birthdate
            // 
            this.Birthdate.HeaderText = "Birthdate";
            this.Birthdate.MinimumWidth = 6;
            this.Birthdate.Name = "Birthdate";
            this.Birthdate.ReadOnly = true;
            this.Birthdate.Width = 125;
            // 
            // PassNum
            // 
            this.PassNum.HeaderText = "Passport number";
            this.PassNum.MinimumWidth = 6;
            this.PassNum.Name = "PassNum";
            this.PassNum.ReadOnly = true;
            this.PassNum.Width = 125;
            // 
            // PassCountry
            // 
            this.PassCountry.HeaderText = "Passport country";
            this.PassCountry.MinimumWidth = 6;
            this.PassCountry.Name = "PassCountry";
            this.PassCountry.ReadOnly = true;
            this.PassCountry.Width = 125;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Width = 125;
            // 
            // ScheduleID
            // 
            this.ScheduleID.HeaderText = "ScheduleID";
            this.ScheduleID.MinimumWidth = 6;
            this.ScheduleID.Name = "ScheduleID";
            this.ScheduleID.ReadOnly = true;
            this.ScheduleID.Width = 125;
            // 
            // AirCode
            // 
            this.AirCode.HeaderText = "AirCode";
            this.AirCode.MinimumWidth = 6;
            this.AirCode.Name = "AirCode";
            this.AirCode.ReadOnly = true;
            this.AirCode.Width = 125;
            // 
            // BookingCancel_Btn
            // 
            this.BookingCancel_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingCancel_Btn.Location = new System.Drawing.Point(218, 596);
            this.BookingCancel_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookingCancel_Btn.Name = "BookingCancel_Btn";
            this.BookingCancel_Btn.Size = new System.Drawing.Size(86, 33);
            this.BookingCancel_Btn.TabIndex = 37;
            this.BookingCancel_Btn.Text = "Cancel";
            this.BookingCancel_Btn.UseVisualStyleBackColor = true;
            this.BookingCancel_Btn.Click += new System.EventHandler(this.BookingCancel_Btn_Click);
            // 
            // BookingConfirm_Btn
            // 
            this.BookingConfirm_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingConfirm_Btn.Location = new System.Drawing.Point(353, 596);
            this.BookingConfirm_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookingConfirm_Btn.Name = "BookingConfirm_Btn";
            this.BookingConfirm_Btn.Size = new System.Drawing.Size(132, 33);
            this.BookingConfirm_Btn.TabIndex = 38;
            this.BookingConfirm_Btn.Text = "Confirm booking";
            this.BookingConfirm_Btn.UseVisualStyleBackColor = true;
            this.BookingConfirm_Btn.Click += new System.EventHandler(this.BookingConfirm_Btn_Click);
            // 
            // BookingRemovePassenger_Btn
            // 
            this.BookingRemovePassenger_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingRemovePassenger_Btn.Location = new System.Drawing.Point(573, 573);
            this.BookingRemovePassenger_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookingRemovePassenger_Btn.Name = "BookingRemovePassenger_Btn";
            this.BookingRemovePassenger_Btn.Size = new System.Drawing.Size(177, 33);
            this.BookingRemovePassenger_Btn.TabIndex = 39;
            this.BookingRemovePassenger_Btn.Text = "Remove passenger";
            this.BookingRemovePassenger_Btn.UseVisualStyleBackColor = true;
            this.BookingRemovePassenger_Btn.Click += new System.EventHandler(this.BookingRemovePassenger_Btn_Click);
            // 
            // BookingFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 642);
            this.Controls.Add(this.BookingRemovePassenger_Btn);
            this.Controls.Add(this.BookingConfirm_Btn);
            this.Controls.Add(this.BookingCancel_Btn);
            this.Controls.Add(this.BookingPassengersGrid_View);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BookingFlight";
            this.Text = "Booking confirmation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BookingPassengersGrid_View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label BookingOutboundFlight_Label;
        private System.Windows.Forms.Label BookingOutboundDate_Label;
        private System.Windows.Forms.Label BookingOutboundFrom_Label;
        private System.Windows.Forms.Label BookingOutboundCabin_Label;
        private System.Windows.Forms.Label BookingOutboundTo_Label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label BookingReturnFlight_Label;
        private System.Windows.Forms.Label BookingReturnDate_Label;
        private System.Windows.Forms.Label BookingReturnFrom_Label;
        private System.Windows.Forms.Label BookingReturnCabin_Label;
        private System.Windows.Forms.Label BookingReturnTo_Label;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label laben2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BookingPassengerPassportNum_Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BookingPassengerLastname_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker BookingPassengerBirthdate_Picker;
        private System.Windows.Forms.TextBox BookingPassengerFirstname_Box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BookingPassengerAdd_Btn;
        private System.Windows.Forms.ComboBox BookingPassengerPassportCountry_Combobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView BookingPassengersGrid_View;
        private System.Windows.Forms.Button BookingCancel_Btn;
        private System.Windows.Forms.Button BookingConfirm_Btn;
        private System.Windows.Forms.Button BookingRemovePassenger_Btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AirCode;
        private System.Windows.Forms.MaskedTextBox BookingPassengerPhone_Box;
    }
}