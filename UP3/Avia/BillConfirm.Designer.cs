namespace Avia
{
    partial class BillConfirm
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
            this.BillConfirm_Btn = new System.Windows.Forms.Button();
            this.BillCancel_Btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BillingTotal_Label = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BillConfirm_Btn
            // 
            this.BillConfirm_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BillConfirm_Btn.Location = new System.Drawing.Point(12, 199);
            this.BillConfirm_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BillConfirm_Btn.Name = "BillConfirm_Btn";
            this.BillConfirm_Btn.Size = new System.Drawing.Size(132, 33);
            this.BillConfirm_Btn.TabIndex = 41;
            this.BillConfirm_Btn.Text = "Issue tickets";
            this.BillConfirm_Btn.UseVisualStyleBackColor = true;
            this.BillConfirm_Btn.Click += new System.EventHandler(this.BillConfirm_Btn_Click);
            // 
            // BillCancel_Btn
            // 
            this.BillCancel_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BillCancel_Btn.Location = new System.Drawing.Point(170, 199);
            this.BillCancel_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BillCancel_Btn.Name = "BillCancel_Btn";
            this.BillCancel_Btn.Size = new System.Drawing.Size(86, 33);
            this.BillCancel_Btn.TabIndex = 40;
            this.BillCancel_Btn.Text = "Cancel";
            this.BillCancel_Btn.UseVisualStyleBackColor = true;
            this.BillCancel_Btn.Click += new System.EventHandler(this.BillCancel_Btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(16, 48);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(156, 143);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paid using";
            // 
            // BillingTotal_Label
            // 
            this.BillingTotal_Label.AutoSize = true;
            this.BillingTotal_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BillingTotal_Label.Location = new System.Drawing.Point(12, 9);
            this.BillingTotal_Label.Name = "BillingTotal_Label";
            this.BillingTotal_Label.Size = new System.Drawing.Size(105, 20);
            this.BillingTotal_Label.TabIndex = 15;
            this.BillingTotal_Label.Text = "Total amount:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(111, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Credit Card";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Cash";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(15, 86);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(89, 24);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Voucher";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // BillConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 255);
            this.Controls.Add(this.BillConfirm_Btn);
            this.Controls.Add(this.BillCancel_Btn);
            this.Controls.Add(this.BillingTotal_Label);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BillConfirm";
            this.Text = "Billing confirmation";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BillConfirm_Btn;
        private System.Windows.Forms.Button BillCancel_Btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label BillingTotal_Label;
    }
}