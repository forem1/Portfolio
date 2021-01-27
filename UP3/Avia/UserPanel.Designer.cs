namespace Avia
{
    partial class UserPanel
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
            this.UserPanelErrors_Label = new System.Windows.Forms.Label();
            this.UserPanelWelcome_Label = new System.Windows.Forms.Label();
            this.UserPanelTime_Label = new System.Windows.Forms.Label();
            this.UserPanel_Menu = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchFlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userFeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amenitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserGridUser_View = new System.Windows.Forms.DataGridView();
            this.UserPanel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridUser_View)).BeginInit();
            this.SuspendLayout();
            // 
            // UserPanelErrors_Label
            // 
            this.UserPanelErrors_Label.AutoSize = true;
            this.UserPanelErrors_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserPanelErrors_Label.Location = new System.Drawing.Point(568, 68);
            this.UserPanelErrors_Label.Name = "UserPanelErrors_Label";
            this.UserPanelErrors_Label.Size = new System.Drawing.Size(25, 20);
            this.UserPanelErrors_Label.TabIndex = 1;
            this.UserPanelErrors_Label.Text = "ex";
            // 
            // UserPanelWelcome_Label
            // 
            this.UserPanelWelcome_Label.AutoSize = true;
            this.UserPanelWelcome_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserPanelWelcome_Label.Location = new System.Drawing.Point(12, 34);
            this.UserPanelWelcome_Label.Name = "UserPanelWelcome_Label";
            this.UserPanelWelcome_Label.Size = new System.Drawing.Size(25, 20);
            this.UserPanelWelcome_Label.TabIndex = 2;
            this.UserPanelWelcome_Label.Text = "ex";
            // 
            // UserPanelTime_Label
            // 
            this.UserPanelTime_Label.AutoSize = true;
            this.UserPanelTime_Label.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserPanelTime_Label.Location = new System.Drawing.Point(334, 68);
            this.UserPanelTime_Label.Name = "UserPanelTime_Label";
            this.UserPanelTime_Label.Size = new System.Drawing.Size(25, 20);
            this.UserPanelTime_Label.TabIndex = 3;
            this.UserPanelTime_Label.Text = "ex";
            // 
            // UserPanel_Menu
            // 
            this.UserPanel_Menu.Font = new System.Drawing.Font("TeX Gyre Adventor", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserPanel_Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.UserPanel_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.searchFlightToolStripMenuItem,
            this.userFeedbackToolStripMenuItem,
            this.amenitiesToolStripMenuItem,
            this.summaryToolStripMenuItem});
            this.UserPanel_Menu.Location = new System.Drawing.Point(0, 0);
            this.UserPanel_Menu.Name = "UserPanel_Menu";
            this.UserPanel_Menu.Size = new System.Drawing.Size(737, 29);
            this.UserPanel_Menu.TabIndex = 4;
            this.UserPanel_Menu.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 25);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // searchFlightToolStripMenuItem
            // 
            this.searchFlightToolStripMenuItem.Name = "searchFlightToolStripMenuItem";
            this.searchFlightToolStripMenuItem.Size = new System.Drawing.Size(116, 25);
            this.searchFlightToolStripMenuItem.Text = "Search Flight";
            this.searchFlightToolStripMenuItem.Click += new System.EventHandler(this.searchFlightToolStripMenuItem_Click);
            // 
            // userFeedbackToolStripMenuItem
            // 
            this.userFeedbackToolStripMenuItem.Name = "userFeedbackToolStripMenuItem";
            this.userFeedbackToolStripMenuItem.Size = new System.Drawing.Size(134, 25);
            this.userFeedbackToolStripMenuItem.Text = "User Feedback";
            this.userFeedbackToolStripMenuItem.Click += new System.EventHandler(this.userFeedbackToolStripMenuItem_Click);
            // 
            // amenitiesToolStripMenuItem
            // 
            this.amenitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToolStripMenuItem});
            this.amenitiesToolStripMenuItem.Name = "amenitiesToolStripMenuItem";
            this.amenitiesToolStripMenuItem.Size = new System.Drawing.Size(95, 25);
            this.amenitiesToolStripMenuItem.Text = "Amenities";
            this.amenitiesToolStripMenuItem.Click += new System.EventHandler(this.amenitiesToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.reportToolStripMenuItem.Text = "Report";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // summaryToolStripMenuItem
            // 
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new System.Drawing.Size(91, 25);
            this.summaryToolStripMenuItem.Text = "Summary";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.summaryToolStripMenuItem_Click);
            // 
            // UserGridUser_View
            // 
            this.UserGridUser_View.AllowUserToAddRows = false;
            this.UserGridUser_View.AllowUserToDeleteRows = false;
            this.UserGridUser_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserGridUser_View.Location = new System.Drawing.Point(12, 158);
            this.UserGridUser_View.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserGridUser_View.MultiSelect = false;
            this.UserGridUser_View.Name = "UserGridUser_View";
            this.UserGridUser_View.ReadOnly = true;
            this.UserGridUser_View.RowHeadersWidth = 51;
            this.UserGridUser_View.RowTemplate.Height = 24;
            this.UserGridUser_View.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserGridUser_View.Size = new System.Drawing.Size(713, 457);
            this.UserGridUser_View.TabIndex = 5;
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 629);
            this.Controls.Add(this.UserGridUser_View);
            this.Controls.Add(this.UserPanelTime_Label);
            this.Controls.Add(this.UserPanelWelcome_Label);
            this.Controls.Add(this.UserPanelErrors_Label);
            this.Controls.Add(this.UserPanel_Menu);
            this.Font = new System.Drawing.Font("TeX Gyre Adventor", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.UserPanel_Menu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserPanel";
            this.Text = "AMONIC Airlines Automation System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserPanel_FormClosed);
            this.UserPanel_Menu.ResumeLayout(false);
            this.UserPanel_Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridUser_View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserPanelErrors_Label;
        private System.Windows.Forms.Label UserPanelWelcome_Label;
        private System.Windows.Forms.Label UserPanelTime_Label;
        private System.Windows.Forms.MenuStrip UserPanel_Menu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView UserGridUser_View;
        private System.Windows.Forms.ToolStripMenuItem searchFlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userFeedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amenitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summaryToolStripMenuItem;
    }
}