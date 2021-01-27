namespace Avia
{
    partial class AdminPanel
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
            this.AdminPanel_Menu = new System.Windows.Forms.MenuStrip();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserGridAdmin_View = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectOfficesAdmin_ComboBox = new System.Windows.Forms.ComboBox();
            this.ChangeRoleAdmin_Btn = new System.Windows.Forms.Button();
            this.ChangeActivateAdmin_Btn = new System.Windows.Forms.Button();
            this.AdminPanel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridAdmin_View)).BeginInit();
            this.SuspendLayout();
            // 
            // AdminPanel_Menu
            // 
            this.AdminPanel_Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AdminPanel_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.AdminPanel_Menu.Location = new System.Drawing.Point(0, 0);
            this.AdminPanel_Menu.Name = "AdminPanel_Menu";
            this.AdminPanel_Menu.Size = new System.Drawing.Size(800, 29);
            this.AdminPanel_Menu.TabIndex = 0;
            this.AdminPanel_Menu.Text = "menuStrip1";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Font = new System.Drawing.Font("TeX Gyre Adventor", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.addUserToolStripMenuItem.Text = "Add user";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(83, 25);
            this.scheduleToolStripMenuItem.Text = "Schedule";
            this.scheduleToolStripMenuItem.Click += new System.EventHandler(this.scheduleToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("TeX Gyre Adventor", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 25);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // UserGridAdmin_View
            // 
            this.UserGridAdmin_View.AllowUserToAddRows = false;
            this.UserGridAdmin_View.AllowUserToDeleteRows = false;
            this.UserGridAdmin_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserGridAdmin_View.Location = new System.Drawing.Point(0, 83);
            this.UserGridAdmin_View.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserGridAdmin_View.MultiSelect = false;
            this.UserGridAdmin_View.Name = "UserGridAdmin_View";
            this.UserGridAdmin_View.ReadOnly = true;
            this.UserGridAdmin_View.RowHeadersWidth = 51;
            this.UserGridAdmin_View.RowTemplate.Height = 24;
            this.UserGridAdmin_View.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserGridAdmin_View.Size = new System.Drawing.Size(800, 549);
            this.UserGridAdmin_View.TabIndex = 1;
            this.UserGridAdmin_View.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserGridAdmin_View_CellEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Office:";
            // 
            // SelectOfficesAdmin_ComboBox
            // 
            this.SelectOfficesAdmin_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectOfficesAdmin_ComboBox.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectOfficesAdmin_ComboBox.FormattingEnabled = true;
            this.SelectOfficesAdmin_ComboBox.Items.AddRange(new object[] {
            "All offices"});
            this.SelectOfficesAdmin_ComboBox.Location = new System.Drawing.Point(70, 44);
            this.SelectOfficesAdmin_ComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SelectOfficesAdmin_ComboBox.Name = "SelectOfficesAdmin_ComboBox";
            this.SelectOfficesAdmin_ComboBox.Size = new System.Drawing.Size(222, 27);
            this.SelectOfficesAdmin_ComboBox.TabIndex = 3;
            this.SelectOfficesAdmin_ComboBox.SelectedValueChanged += new System.EventHandler(this.SelectOfficesAdmin_ComboBox_SelectedValueChanged);
            // 
            // ChangeRoleAdmin_Btn
            // 
            this.ChangeRoleAdmin_Btn.Enabled = false;
            this.ChangeRoleAdmin_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeRoleAdmin_Btn.Location = new System.Drawing.Point(12, 639);
            this.ChangeRoleAdmin_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChangeRoleAdmin_Btn.Name = "ChangeRoleAdmin_Btn";
            this.ChangeRoleAdmin_Btn.Size = new System.Drawing.Size(133, 34);
            this.ChangeRoleAdmin_Btn.TabIndex = 4;
            this.ChangeRoleAdmin_Btn.Text = "Change Role";
            this.ChangeRoleAdmin_Btn.UseVisualStyleBackColor = true;
            this.ChangeRoleAdmin_Btn.Click += new System.EventHandler(this.ChangeRoleAdmin_Btn_Click);
            // 
            // ChangeActivateAdmin_Btn
            // 
            this.ChangeActivateAdmin_Btn.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeActivateAdmin_Btn.Location = new System.Drawing.Point(212, 640);
            this.ChangeActivateAdmin_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChangeActivateAdmin_Btn.Name = "ChangeActivateAdmin_Btn";
            this.ChangeActivateAdmin_Btn.Size = new System.Drawing.Size(207, 33);
            this.ChangeActivateAdmin_Btn.TabIndex = 5;
            this.ChangeActivateAdmin_Btn.Text = "Enable/Disable Login";
            this.ChangeActivateAdmin_Btn.UseVisualStyleBackColor = true;
            this.ChangeActivateAdmin_Btn.Click += new System.EventHandler(this.ChangeActivateAdmin_Btn_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 688);
            this.Controls.Add(this.ChangeActivateAdmin_Btn);
            this.Controls.Add(this.ChangeRoleAdmin_Btn);
            this.Controls.Add(this.SelectOfficesAdmin_ComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserGridAdmin_View);
            this.Controls.Add(this.AdminPanel_Menu);
            this.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.AdminPanel_Menu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminPanel";
            this.Text = "AMONIC Airlines Automation System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminPanel_FormClosed);
            this.AdminPanel_Menu.ResumeLayout(false);
            this.AdminPanel_Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridAdmin_View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip AdminPanel_Menu;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView UserGridAdmin_View;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SelectOfficesAdmin_ComboBox;
        private System.Windows.Forms.Button ChangeRoleAdmin_Btn;
        private System.Windows.Forms.Button ChangeActivateAdmin_Btn;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
    }
}