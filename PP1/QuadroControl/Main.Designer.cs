
namespace QuadroControl
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.ConnectBtnMain_Btn = new System.Windows.Forms.Button();
            this.ConnectPortMain_ComboBox = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.DirectionForward_Btn = new System.Windows.Forms.Button();
            this.DirectionBackward_Btn = new System.Windows.Forms.Button();
            this.DirectionLeft_Btn = new System.Windows.Forms.Button();
            this.DirectionRight_Btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TelemetryDirection_Label = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SendRawCommand_Btn = new System.Windows.Forms.Button();
            this.RawCommand_TextBox = new System.Windows.Forms.TextBox();
            this.TelemetryRawMain_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.TelemetryStatus_Label = new System.Windows.Forms.Label();
            this.Emergency_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectBtnMain_Btn
            // 
            this.ConnectBtnMain_Btn.BackColor = System.Drawing.Color.Red;
            this.ConnectBtnMain_Btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBtnMain_Btn.ForeColor = System.Drawing.Color.Snow;
            this.ConnectBtnMain_Btn.Location = new System.Drawing.Point(695, 12);
            this.ConnectBtnMain_Btn.Name = "ConnectBtnMain_Btn";
            this.ConnectBtnMain_Btn.Size = new System.Drawing.Size(180, 43);
            this.ConnectBtnMain_Btn.TabIndex = 0;
            this.ConnectBtnMain_Btn.Text = "Connect";
            this.ConnectBtnMain_Btn.UseVisualStyleBackColor = false;
            this.ConnectBtnMain_Btn.Click += new System.EventHandler(this.ConnectBtnMain_Btn_Click);
            // 
            // ConnectPortMain_ComboBox
            // 
            this.ConnectPortMain_ComboBox.DropDownHeight = 110;
            this.ConnectPortMain_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConnectPortMain_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ConnectPortMain_ComboBox.FormattingEnabled = true;
            this.ConnectPortMain_ComboBox.IntegralHeight = false;
            this.ConnectPortMain_ComboBox.Location = new System.Drawing.Point(257, 18);
            this.ConnectPortMain_ComboBox.Name = "ConnectPortMain_ComboBox";
            this.ConnectPortMain_ComboBox.Size = new System.Drawing.Size(121, 37);
            this.ConnectPortMain_ComboBox.TabIndex = 1;
            // 
            // DirectionForward_Btn
            // 
            this.DirectionForward_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.DirectionForward_Btn.Location = new System.Drawing.Point(175, 779);
            this.DirectionForward_Btn.Name = "DirectionForward_Btn";
            this.DirectionForward_Btn.Size = new System.Drawing.Size(100, 50);
            this.DirectionForward_Btn.TabIndex = 2;
            this.DirectionForward_Btn.Text = "↑";
            this.DirectionForward_Btn.UseVisualStyleBackColor = true;
            this.DirectionForward_Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DirectionForward_Btn_MouseDown);
            this.DirectionForward_Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DirectionForward_Btn_MouseUp);
            // 
            // DirectionBackward_Btn
            // 
            this.DirectionBackward_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.DirectionBackward_Btn.Location = new System.Drawing.Point(175, 856);
            this.DirectionBackward_Btn.Name = "DirectionBackward_Btn";
            this.DirectionBackward_Btn.Size = new System.Drawing.Size(100, 50);
            this.DirectionBackward_Btn.TabIndex = 3;
            this.DirectionBackward_Btn.Text = "↓";
            this.DirectionBackward_Btn.UseVisualStyleBackColor = true;
            this.DirectionBackward_Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DirectionBackward_Btn_MouseDown);
            this.DirectionBackward_Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DirectionForward_Btn_MouseUp);
            // 
            // DirectionLeft_Btn
            // 
            this.DirectionLeft_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.DirectionLeft_Btn.Location = new System.Drawing.Point(52, 820);
            this.DirectionLeft_Btn.Name = "DirectionLeft_Btn";
            this.DirectionLeft_Btn.Size = new System.Drawing.Size(100, 50);
            this.DirectionLeft_Btn.TabIndex = 5;
            this.DirectionLeft_Btn.Text = "←";
            this.DirectionLeft_Btn.UseVisualStyleBackColor = true;
            this.DirectionLeft_Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DirectionLeft_Btn_MouseDown);
            this.DirectionLeft_Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DirectionRight_Btn_MouseUp);
            // 
            // DirectionRight_Btn
            // 
            this.DirectionRight_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.DirectionRight_Btn.Location = new System.Drawing.Point(303, 820);
            this.DirectionRight_Btn.Name = "DirectionRight_Btn";
            this.DirectionRight_Btn.Size = new System.Drawing.Size(100, 50);
            this.DirectionRight_Btn.TabIndex = 4;
            this.DirectionRight_Btn.Text = "→";
            this.DirectionRight_Btn.UseVisualStyleBackColor = true;
            this.DirectionRight_Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DirectionRight_Btn_MouseDown);
            this.DirectionRight_Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DirectionRight_Btn_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(361, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1039, 651);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(435, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(243, 37);
            this.comboBox1.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabControl1.Location = new System.Drawing.Point(1479, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(411, 900);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TelemetryDirection_Label);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(403, 862);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Telemetry";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TelemetryDirection_Label
            // 
            this.TelemetryDirection_Label.AutoSize = true;
            this.TelemetryDirection_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TelemetryDirection_Label.Location = new System.Drawing.Point(6, 16);
            this.TelemetryDirection_Label.Name = "TelemetryDirection_Label";
            this.TelemetryDirection_Label.Size = new System.Drawing.Size(94, 25);
            this.TelemetryDirection_Label.TabIndex = 1;
            this.TelemetryDirection_Label.Text = "Direction:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.SendRawCommand_Btn);
            this.tabPage2.Controls.Add(this.RawCommand_TextBox);
            this.tabPage2.Controls.Add(this.TelemetryRawMain_RichTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(403, 862);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Raw data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SendRawCommand_Btn
            // 
            this.SendRawCommand_Btn.Location = new System.Drawing.Point(328, 825);
            this.SendRawCommand_Btn.Name = "SendRawCommand_Btn";
            this.SendRawCommand_Btn.Size = new System.Drawing.Size(69, 31);
            this.SendRawCommand_Btn.TabIndex = 2;
            this.SendRawCommand_Btn.Text = "Send";
            this.SendRawCommand_Btn.UseVisualStyleBackColor = true;
            this.SendRawCommand_Btn.Click += new System.EventHandler(this.SendRawCommand_Btn_Click);
            // 
            // RawCommand_TextBox
            // 
            this.RawCommand_TextBox.Location = new System.Drawing.Point(6, 826);
            this.RawCommand_TextBox.Name = "RawCommand_TextBox";
            this.RawCommand_TextBox.Size = new System.Drawing.Size(320, 30);
            this.RawCommand_TextBox.TabIndex = 1;
            this.RawCommand_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RawCommand_TextBox_KeyPress);
            // 
            // TelemetryRawMain_RichTextBox
            // 
            this.TelemetryRawMain_RichTextBox.Location = new System.Drawing.Point(3, 6);
            this.TelemetryRawMain_RichTextBox.Name = "TelemetryRawMain_RichTextBox";
            this.TelemetryRawMain_RichTextBox.Size = new System.Drawing.Size(394, 803);
            this.TelemetryRawMain_RichTextBox.TabIndex = 0;
            this.TelemetryRawMain_RichTextBox.Text = "";
            this.TelemetryRawMain_RichTextBox.TextChanged += new System.EventHandler(this.TelemetryRawMain_RichTextBox_TextChanged);
            // 
            // TelemetryStatus_Label
            // 
            this.TelemetryStatus_Label.AutoSize = true;
            this.TelemetryStatus_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.TelemetryStatus_Label.ForeColor = System.Drawing.Color.White;
            this.TelemetryStatus_Label.Location = new System.Drawing.Point(1477, 5);
            this.TelemetryStatus_Label.Name = "TelemetryStatus_Label";
            this.TelemetryStatus_Label.Size = new System.Drawing.Size(151, 31);
            this.TelemetryStatus_Label.TabIndex = 0;
            this.TelemetryStatus_Label.Text = "Status: Idle";
            // 
            // Emergency_Btn
            // 
            this.Emergency_Btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Emergency_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.Emergency_Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Emergency_Btn.Location = new System.Drawing.Point(23, 8);
            this.Emergency_Btn.Name = "Emergency_Btn";
            this.Emergency_Btn.Size = new System.Drawing.Size(200, 47);
            this.Emergency_Btn.TabIndex = 9;
            this.Emergency_Btn.Text = "Emergency";
            this.Emergency_Btn.UseVisualStyleBackColor = false;
            this.Emergency_Btn.Visible = false;
            this.Emergency_Btn.Click += new System.EventHandler(this.Emergency_Btn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.Emergency_Btn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.TelemetryStatus_Label);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DirectionLeft_Btn);
            this.Controls.Add(this.DirectionRight_Btn);
            this.Controls.Add(this.DirectionBackward_Btn);
            this.Controls.Add(this.DirectionForward_Btn);
            this.Controls.Add(this.ConnectPortMain_ComboBox);
            this.Controls.Add(this.ConnectBtnMain_Btn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Main";
            this.Text = "QuadroControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectBtnMain_Btn;
        private System.Windows.Forms.ComboBox ConnectPortMain_ComboBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button DirectionForward_Btn;
        private System.Windows.Forms.Button DirectionBackward_Btn;
        private System.Windows.Forms.Button DirectionLeft_Btn;
        private System.Windows.Forms.Button DirectionRight_Btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox TelemetryRawMain_RichTextBox;
        private System.Windows.Forms.Button SendRawCommand_Btn;
        private System.Windows.Forms.TextBox RawCommand_TextBox;
        private System.Windows.Forms.Label TelemetryDirection_Label;
        private System.Windows.Forms.Label TelemetryStatus_Label;
        private System.Windows.Forms.Button Emergency_Btn;
    }
}

