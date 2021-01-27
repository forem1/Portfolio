namespace cyic
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.InventoryQuantity = new System.Windows.Forms.NumericUpDown();
            this.InventoryCost = new System.Windows.Forms.NumericUpDown();
            this.InventoryStorage = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.UpdateInventory = new System.Windows.Forms.Button();
            this.DeleteInventory = new System.Windows.Forms.Button();
            this.AddInventory = new System.Windows.Forms.Button();
            this.InventoryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ExportExel = new System.Windows.Forms.Button();
            this.ReceiptNumber = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ReceiptCost = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ReceiptDate = new System.Windows.Forms.DateTimePicker();
            this.DeleteReceipt = new System.Windows.Forms.Button();
            this.AddReceipt = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.StatusName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateStatus = new System.Windows.Forms.Button();
            this.DeleteStatus = new System.Windows.Forms.Button();
            this.AddStatus = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.StorageName = new System.Windows.Forms.TextBox();
            this.UpdateStorage = new System.Windows.Forms.Button();
            this.DeleteStorage = new System.Windows.Forms.Button();
            this.AddStorage = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.TypeName = new System.Windows.Forms.TextBox();
            this.UpdateType = new System.Windows.Forms.Button();
            this.DeleteType = new System.Windows.Forms.Button();
            this.AddType = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.WorkTask = new System.Windows.Forms.TextBox();
            this.WorkInventory = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.WorkStatus = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.WorkType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.WorkName = new System.Windows.Forms.TextBox();
            this.UpdateWork = new System.Windows.Forms.Button();
            this.DeleteWork = new System.Windows.Forms.Button();
            this.AddWork = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.UserLogin = new System.Windows.Forms.TextBox();
            this.UpdateUser = new System.Windows.Forms.Button();
            this.DeleteUser = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.UserPassBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.UserLogBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.UserLog = new System.Windows.Forms.Button();
            this.UserReg = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryCost)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptCost)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 328);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.InventoryQuantity);
            this.tabPage1.Controls.Add(this.InventoryCost);
            this.tabPage1.Controls.Add(this.InventoryStorage);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.UpdateInventory);
            this.tabPage1.Controls.Add(this.DeleteInventory);
            this.tabPage1.Controls.Add(this.AddInventory);
            this.tabPage1.Controls.Add(this.InventoryName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Инвентарь";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // InventoryQuantity
            // 
            this.InventoryQuantity.Location = new System.Drawing.Point(100, 152);
            this.InventoryQuantity.Name = "InventoryQuantity";
            this.InventoryQuantity.Size = new System.Drawing.Size(150, 22);
            this.InventoryQuantity.TabIndex = 12;
            // 
            // InventoryCost
            // 
            this.InventoryCost.Location = new System.Drawing.Point(296, 100);
            this.InventoryCost.Name = "InventoryCost";
            this.InventoryCost.Size = new System.Drawing.Size(150, 22);
            this.InventoryCost.TabIndex = 11;
            // 
            // InventoryStorage
            // 
            this.InventoryStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InventoryStorage.FormattingEnabled = true;
            this.InventoryStorage.Location = new System.Drawing.Point(296, 150);
            this.InventoryStorage.Name = "InventoryStorage";
            this.InventoryStorage.Size = new System.Drawing.Size(150, 24);
            this.InventoryStorage.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Тип хранения";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Цена";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Количество";
            // 
            // UpdateInventory
            // 
            this.UpdateInventory.Location = new System.Drawing.Point(430, 255);
            this.UpdateInventory.Name = "UpdateInventory";
            this.UpdateInventory.Size = new System.Drawing.Size(83, 23);
            this.UpdateInventory.TabIndex = 4;
            this.UpdateInventory.Text = "Изменить";
            this.UpdateInventory.UseVisualStyleBackColor = true;
            this.UpdateInventory.Click += new System.EventHandler(this.UpdateInventory_Click);
            // 
            // DeleteInventory
            // 
            this.DeleteInventory.Location = new System.Drawing.Point(349, 255);
            this.DeleteInventory.Name = "DeleteInventory";
            this.DeleteInventory.Size = new System.Drawing.Size(75, 23);
            this.DeleteInventory.TabIndex = 3;
            this.DeleteInventory.Text = "Удалить";
            this.DeleteInventory.UseVisualStyleBackColor = true;
            this.DeleteInventory.Click += new System.EventHandler(this.DeleteInventory_Click);
            // 
            // AddInventory
            // 
            this.AddInventory.Location = new System.Drawing.Point(255, 255);
            this.AddInventory.Name = "AddInventory";
            this.AddInventory.Size = new System.Drawing.Size(88, 23);
            this.AddInventory.TabIndex = 2;
            this.AddInventory.Text = "Добавить";
            this.AddInventory.UseVisualStyleBackColor = true;
            this.AddInventory.Click += new System.EventHandler(this.AddInventory_Click);
            // 
            // InventoryName
            // 
            this.InventoryName.Location = new System.Drawing.Point(100, 100);
            this.InventoryName.Name = "InventoryName";
            this.InventoryName.Size = new System.Drawing.Size(150, 22);
            this.InventoryName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ExportExel);
            this.tabPage2.Controls.Add(this.ReceiptNumber);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.ReceiptCost);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.ReceiptDate);
            this.tabPage2.Controls.Add(this.DeleteReceipt);
            this.tabPage2.Controls.Add(this.AddReceipt);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(793, 299);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Чеки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ExportExel
            // 
            this.ExportExel.Location = new System.Drawing.Point(430, 255);
            this.ExportExel.Name = "ExportExel";
            this.ExportExel.Size = new System.Drawing.Size(129, 23);
            this.ExportExel.TabIndex = 16;
            this.ExportExel.Text = "Экспортировать";
            this.ExportExel.UseVisualStyleBackColor = true;
            this.ExportExel.Click += new System.EventHandler(this.ExportExel_Click);
            // 
            // ReceiptNumber
            // 
            this.ReceiptNumber.FormattingEnabled = true;
            this.ReceiptNumber.Location = new System.Drawing.Point(462, 98);
            this.ReceiptNumber.Name = "ReceiptNumber";
            this.ReceiptNumber.Size = new System.Drawing.Size(150, 24);
            this.ReceiptNumber.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(459, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 17);
            this.label16.TabIndex = 14;
            this.label16.Text = "Номер заказа";
            // 
            // ReceiptCost
            // 
            this.ReceiptCost.Location = new System.Drawing.Point(306, 100);
            this.ReceiptCost.Name = "ReceiptCost";
            this.ReceiptCost.Size = new System.Drawing.Size(150, 22);
            this.ReceiptCost.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(303, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 17);
            this.label15.TabIndex = 12;
            this.label15.Text = "Цена";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(97, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 17);
            this.label14.TabIndex = 8;
            this.label14.Text = "Дата";
            // 
            // ReceiptDate
            // 
            this.ReceiptDate.Location = new System.Drawing.Point(100, 100);
            this.ReceiptDate.Name = "ReceiptDate";
            this.ReceiptDate.Size = new System.Drawing.Size(200, 22);
            this.ReceiptDate.TabIndex = 7;
            // 
            // DeleteReceipt
            // 
            this.DeleteReceipt.Location = new System.Drawing.Point(349, 255);
            this.DeleteReceipt.Name = "DeleteReceipt";
            this.DeleteReceipt.Size = new System.Drawing.Size(75, 23);
            this.DeleteReceipt.TabIndex = 6;
            this.DeleteReceipt.Text = "Удалить";
            this.DeleteReceipt.UseVisualStyleBackColor = true;
            this.DeleteReceipt.Click += new System.EventHandler(this.DeleteReceipt_Click);
            // 
            // AddReceipt
            // 
            this.AddReceipt.Location = new System.Drawing.Point(255, 255);
            this.AddReceipt.Name = "AddReceipt";
            this.AddReceipt.Size = new System.Drawing.Size(88, 23);
            this.AddReceipt.TabIndex = 5;
            this.AddReceipt.Text = "Добавить";
            this.AddReceipt.UseVisualStyleBackColor = true;
            this.AddReceipt.Click += new System.EventHandler(this.AddReceipt_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.StatusName);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.UpdateStatus);
            this.tabPage3.Controls.Add(this.DeleteStatus);
            this.tabPage3.Controls.Add(this.AddStatus);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(793, 299);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Статус";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // StatusName
            // 
            this.StatusName.Location = new System.Drawing.Point(100, 100);
            this.StatusName.Name = "StatusName";
            this.StatusName.Size = new System.Drawing.Size(150, 22);
            this.StatusName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Название статуса";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateStatus
            // 
            this.UpdateStatus.Location = new System.Drawing.Point(430, 255);
            this.UpdateStatus.Name = "UpdateStatus";
            this.UpdateStatus.Size = new System.Drawing.Size(83, 23);
            this.UpdateStatus.TabIndex = 7;
            this.UpdateStatus.Text = "Изменить";
            this.UpdateStatus.UseVisualStyleBackColor = true;
            this.UpdateStatus.Click += new System.EventHandler(this.UpdateStatus_Click);
            // 
            // DeleteStatus
            // 
            this.DeleteStatus.Location = new System.Drawing.Point(349, 255);
            this.DeleteStatus.Name = "DeleteStatus";
            this.DeleteStatus.Size = new System.Drawing.Size(75, 23);
            this.DeleteStatus.TabIndex = 6;
            this.DeleteStatus.Text = "Удалить";
            this.DeleteStatus.UseVisualStyleBackColor = true;
            this.DeleteStatus.Click += new System.EventHandler(this.DeleteStatus_Click);
            // 
            // AddStatus
            // 
            this.AddStatus.Location = new System.Drawing.Point(255, 255);
            this.AddStatus.Name = "AddStatus";
            this.AddStatus.Size = new System.Drawing.Size(88, 23);
            this.AddStatus.TabIndex = 5;
            this.AddStatus.Text = "Добавить";
            this.AddStatus.UseVisualStyleBackColor = true;
            this.AddStatus.Click += new System.EventHandler(this.AddStatus_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.StorageName);
            this.tabPage4.Controls.Add(this.UpdateStorage);
            this.tabPage4.Controls.Add(this.DeleteStorage);
            this.tabPage4.Controls.Add(this.AddStorage);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(793, 299);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Хранение";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Название типа хранения";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StorageName
            // 
            this.StorageName.Location = new System.Drawing.Point(100, 100);
            this.StorageName.Name = "StorageName";
            this.StorageName.Size = new System.Drawing.Size(150, 22);
            this.StorageName.TabIndex = 10;
            // 
            // UpdateStorage
            // 
            this.UpdateStorage.Location = new System.Drawing.Point(429, 255);
            this.UpdateStorage.Name = "UpdateStorage";
            this.UpdateStorage.Size = new System.Drawing.Size(83, 23);
            this.UpdateStorage.TabIndex = 7;
            this.UpdateStorage.Text = "Изменить";
            this.UpdateStorage.UseVisualStyleBackColor = true;
            this.UpdateStorage.Click += new System.EventHandler(this.UpdateStorage_Click);
            // 
            // DeleteStorage
            // 
            this.DeleteStorage.Location = new System.Drawing.Point(348, 255);
            this.DeleteStorage.Name = "DeleteStorage";
            this.DeleteStorage.Size = new System.Drawing.Size(75, 23);
            this.DeleteStorage.TabIndex = 6;
            this.DeleteStorage.Text = "Удалить";
            this.DeleteStorage.UseVisualStyleBackColor = true;
            this.DeleteStorage.Click += new System.EventHandler(this.DeleteStorage_Click);
            // 
            // AddStorage
            // 
            this.AddStorage.Location = new System.Drawing.Point(255, 255);
            this.AddStorage.Name = "AddStorage";
            this.AddStorage.Size = new System.Drawing.Size(88, 23);
            this.AddStorage.TabIndex = 5;
            this.AddStorage.Text = "Добавить";
            this.AddStorage.UseVisualStyleBackColor = true;
            this.AddStorage.Click += new System.EventHandler(this.AddStorage_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.TypeName);
            this.tabPage5.Controls.Add(this.UpdateType);
            this.tabPage5.Controls.Add(this.DeleteType);
            this.tabPage5.Controls.Add(this.AddType);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(793, 299);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Тип работы";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Название типа работ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TypeName
            // 
            this.TypeName.Location = new System.Drawing.Point(100, 100);
            this.TypeName.Name = "TypeName";
            this.TypeName.Size = new System.Drawing.Size(150, 22);
            this.TypeName.TabIndex = 12;
            // 
            // UpdateType
            // 
            this.UpdateType.Location = new System.Drawing.Point(430, 255);
            this.UpdateType.Name = "UpdateType";
            this.UpdateType.Size = new System.Drawing.Size(83, 23);
            this.UpdateType.TabIndex = 7;
            this.UpdateType.Text = "Изменить";
            this.UpdateType.UseVisualStyleBackColor = true;
            this.UpdateType.Click += new System.EventHandler(this.UpdateType_Click);
            // 
            // DeleteType
            // 
            this.DeleteType.Location = new System.Drawing.Point(349, 255);
            this.DeleteType.Name = "DeleteType";
            this.DeleteType.Size = new System.Drawing.Size(75, 23);
            this.DeleteType.TabIndex = 6;
            this.DeleteType.Text = "Удалить";
            this.DeleteType.UseVisualStyleBackColor = true;
            this.DeleteType.Click += new System.EventHandler(this.DeleteType_Click);
            // 
            // AddType
            // 
            this.AddType.Location = new System.Drawing.Point(255, 255);
            this.AddType.Name = "AddType";
            this.AddType.Size = new System.Drawing.Size(88, 23);
            this.AddType.TabIndex = 5;
            this.AddType.Text = "Добавить";
            this.AddType.UseVisualStyleBackColor = true;
            this.AddType.Click += new System.EventHandler(this.AddType_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label13);
            this.tabPage6.Controls.Add(this.WorkTask);
            this.tabPage6.Controls.Add(this.WorkInventory);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Controls.Add(this.WorkStatus);
            this.tabPage6.Controls.Add(this.label11);
            this.tabPage6.Controls.Add(this.WorkType);
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.label9);
            this.tabPage6.Controls.Add(this.WorkName);
            this.tabPage6.Controls.Add(this.UpdateWork);
            this.tabPage6.Controls.Add(this.DeleteWork);
            this.tabPage6.Controls.Add(this.AddWork);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(793, 299);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Заказы";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(367, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 17);
            this.label13.TabIndex = 23;
            this.label13.Text = "Задача";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WorkTask
            // 
            this.WorkTask.Location = new System.Drawing.Point(100, 161);
            this.WorkTask.Name = "WorkTask";
            this.WorkTask.Size = new System.Drawing.Size(618, 22);
            this.WorkTask.TabIndex = 22;
            // 
            // WorkInventory
            // 
            this.WorkInventory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkInventory.FormattingEnabled = true;
            this.WorkInventory.Location = new System.Drawing.Point(568, 100);
            this.WorkInventory.Name = "WorkInventory";
            this.WorkInventory.Size = new System.Drawing.Size(150, 24);
            this.WorkInventory.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(565, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Инвентарь";
            // 
            // WorkStatus
            // 
            this.WorkStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkStatus.FormattingEnabled = true;
            this.WorkStatus.Location = new System.Drawing.Point(412, 100);
            this.WorkStatus.Name = "WorkStatus";
            this.WorkStatus.Size = new System.Drawing.Size(150, 24);
            this.WorkStatus.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(409, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 18;
            this.label11.Text = "Статус";
            // 
            // WorkType
            // 
            this.WorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkType.FormattingEnabled = true;
            this.WorkType.Location = new System.Drawing.Point(256, 100);
            this.WorkType.Name = "WorkType";
            this.WorkType.Size = new System.Drawing.Size(150, 24);
            this.WorkType.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(253, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Тип работ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Название работы";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WorkName
            // 
            this.WorkName.Location = new System.Drawing.Point(100, 100);
            this.WorkName.Name = "WorkName";
            this.WorkName.Size = new System.Drawing.Size(150, 22);
            this.WorkName.TabIndex = 14;
            // 
            // UpdateWork
            // 
            this.UpdateWork.Location = new System.Drawing.Point(430, 255);
            this.UpdateWork.Name = "UpdateWork";
            this.UpdateWork.Size = new System.Drawing.Size(83, 23);
            this.UpdateWork.TabIndex = 7;
            this.UpdateWork.Text = "Изменить";
            this.UpdateWork.UseVisualStyleBackColor = true;
            this.UpdateWork.Click += new System.EventHandler(this.UpdateWork_Click);
            // 
            // DeleteWork
            // 
            this.DeleteWork.Location = new System.Drawing.Point(349, 255);
            this.DeleteWork.Name = "DeleteWork";
            this.DeleteWork.Size = new System.Drawing.Size(75, 23);
            this.DeleteWork.TabIndex = 6;
            this.DeleteWork.Text = "Удалить";
            this.DeleteWork.UseVisualStyleBackColor = true;
            this.DeleteWork.Click += new System.EventHandler(this.DeleteWork_Click);
            // 
            // AddWork
            // 
            this.AddWork.Location = new System.Drawing.Point(255, 255);
            this.AddWork.Name = "AddWork";
            this.AddWork.Size = new System.Drawing.Size(88, 23);
            this.AddWork.TabIndex = 5;
            this.AddWork.Text = "Добавить";
            this.AddWork.UseVisualStyleBackColor = true;
            this.AddWork.Click += new System.EventHandler(this.AddWork_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label5);
            this.tabPage7.Controls.Add(this.UserLogin);
            this.tabPage7.Controls.Add(this.UpdateUser);
            this.tabPage7.Controls.Add(this.DeleteUser);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(793, 299);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Пользователи";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Логин";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserLogin
            // 
            this.UserLogin.Location = new System.Drawing.Point(100, 100);
            this.UserLogin.Name = "UserLogin";
            this.UserLogin.Size = new System.Drawing.Size(150, 22);
            this.UserLogin.TabIndex = 12;
            // 
            // UpdateUser
            // 
            this.UpdateUser.Location = new System.Drawing.Point(429, 255);
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.Size = new System.Drawing.Size(83, 23);
            this.UpdateUser.TabIndex = 7;
            this.UpdateUser.Text = "Изменить";
            this.UpdateUser.UseVisualStyleBackColor = true;
            this.UpdateUser.Click += new System.EventHandler(this.UpdateUser_Click);
            // 
            // DeleteUser
            // 
            this.DeleteUser.Location = new System.Drawing.Point(348, 255);
            this.DeleteUser.Name = "DeleteUser";
            this.DeleteUser.Size = new System.Drawing.Size(75, 23);
            this.DeleteUser.TabIndex = 6;
            this.DeleteUser.Text = "Удалить";
            this.DeleteUser.UseVisualStyleBackColor = true;
            this.DeleteUser.Click += new System.EventHandler(this.DeleteUser_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.UserPassBox);
            this.tabPage8.Controls.Add(this.label18);
            this.tabPage8.Controls.Add(this.UserLogBox);
            this.tabPage8.Controls.Add(this.label17);
            this.tabPage8.Controls.Add(this.UserLog);
            this.tabPage8.Controls.Add(this.UserReg);
            this.tabPage8.Location = new System.Drawing.Point(4, 25);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(793, 299);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Авторизация";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // UserPassBox
            // 
            this.UserPassBox.Location = new System.Drawing.Point(315, 140);
            this.UserPassBox.Name = "UserPassBox";
            this.UserPassBox.PasswordChar = '*';
            this.UserPassBox.Size = new System.Drawing.Size(150, 22);
            this.UserPassBox.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(312, 120);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 17);
            this.label18.TabIndex = 9;
            this.label18.Text = "Пароль";
            // 
            // UserLogBox
            // 
            this.UserLogBox.Location = new System.Drawing.Point(315, 86);
            this.UserLogBox.Name = "UserLogBox";
            this.UserLogBox.Size = new System.Drawing.Size(150, 22);
            this.UserLogBox.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(312, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 17);
            this.label17.TabIndex = 7;
            this.label17.Text = "Логин";
            // 
            // UserLog
            // 
            this.UserLog.Location = new System.Drawing.Point(405, 249);
            this.UserLog.Name = "UserLog";
            this.UserLog.Size = new System.Drawing.Size(75, 23);
            this.UserLog.TabIndex = 6;
            this.UserLog.Text = "Вход";
            this.UserLog.UseVisualStyleBackColor = true;
            this.UserLog.Click += new System.EventHandler(this.UserLog_Click);
            // 
            // UserReg
            // 
            this.UserReg.Location = new System.Drawing.Point(297, 249);
            this.UserReg.Name = "UserReg";
            this.UserReg.Size = new System.Drawing.Size(102, 23);
            this.UserReg.TabIndex = 5;
            this.UserReg.Text = "Регистрация";
            this.UserReg.UseVisualStyleBackColor = true;
            this.UserReg.Click += new System.EventHandler(this.UserReg_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 334);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(797, 418);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 753);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryCost)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptCost)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button UpdateInventory;
        private System.Windows.Forms.Button DeleteInventory;
        private System.Windows.Forms.Button AddInventory;
        private System.Windows.Forms.TextBox InventoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteReceipt;
        private System.Windows.Forms.Button AddReceipt;
        private System.Windows.Forms.Button UpdateStatus;
        private System.Windows.Forms.Button DeleteStatus;
        private System.Windows.Forms.Button AddStatus;
        private System.Windows.Forms.Button UpdateStorage;
        private System.Windows.Forms.Button DeleteStorage;
        private System.Windows.Forms.Button AddStorage;
        private System.Windows.Forms.Button UpdateType;
        private System.Windows.Forms.Button DeleteType;
        private System.Windows.Forms.Button AddType;
        private System.Windows.Forms.Button UpdateWork;
        private System.Windows.Forms.Button DeleteWork;
        private System.Windows.Forms.Button AddWork;
        private System.Windows.Forms.Button UpdateUser;
        private System.Windows.Forms.Button DeleteUser;
        private System.Windows.Forms.Button UserLog;
        private System.Windows.Forms.Button UserReg;
        private System.Windows.Forms.TextBox StatusName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox StorageName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TypeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UserLogin;
        private System.Windows.Forms.ComboBox InventoryStorage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown InventoryCost;
        private System.Windows.Forms.NumericUpDown InventoryQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox WorkName;
        private System.Windows.Forms.ComboBox WorkInventory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox WorkStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox WorkType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox WorkTask;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown ReceiptCost;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker ReceiptDate;
        private System.Windows.Forms.ComboBox ReceiptNumber;
        private System.Windows.Forms.TextBox UserPassBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox UserLogBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button ExportExel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

