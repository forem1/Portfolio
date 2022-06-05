
namespace NeuroWork
{
    partial class Headband
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
            this.State_Label = new System.Windows.Forms.Label();
            this.ButtonConnect_Btn = new System.Windows.Forms.Button();
            this.PoorSignal_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // State_Label
            // 
            this.State_Label.AutoSize = true;
            this.State_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.State_Label.Location = new System.Drawing.Point(335, 72);
            this.State_Label.Name = "State_Label";
            this.State_Label.Size = new System.Drawing.Size(96, 20);
            this.State_Label.TabIndex = 0;
            this.State_Label.Text = "Ожидание";
            // 
            // ButtonConnect_Btn
            // 
            this.ButtonConnect_Btn.Location = new System.Drawing.Point(324, 348);
            this.ButtonConnect_Btn.Name = "ButtonConnect_Btn";
            this.ButtonConnect_Btn.Size = new System.Drawing.Size(123, 29);
            this.ButtonConnect_Btn.TabIndex = 1;
            this.ButtonConnect_Btn.Text = "Подключиться";
            this.ButtonConnect_Btn.UseVisualStyleBackColor = true;
            this.ButtonConnect_Btn.Click += new System.EventHandler(this.ButtonConnect_Btn_Click);
            // 
            // PoorSignal_Label
            // 
            this.PoorSignal_Label.AutoSize = true;
            this.PoorSignal_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PoorSignal_Label.Location = new System.Drawing.Point(243, 169);
            this.PoorSignal_Label.Name = "PoorSignal_Label";
            this.PoorSignal_Label.Size = new System.Drawing.Size(128, 20);
            this.PoorSignal_Label.TabIndex = 2;
            this.PoorSignal_Label.Text = "Сила сигнала:";
            // 
            // Headband
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PoorSignal_Label);
            this.Controls.Add(this.ButtonConnect_Btn);
            this.Controls.Add(this.State_Label);
            this.Name = "Headband";
            this.Text = "Подключение к устройству";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label State_Label;
        private System.Windows.Forms.Button ButtonConnect_Btn;
        private System.Windows.Forms.Label PoorSignal_Label;
    }
}
