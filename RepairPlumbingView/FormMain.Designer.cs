namespace RepairOrderView
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ингридиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.едаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хранилищаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьХранилищеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прайсРемонтовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загруженностьСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьХранилищеToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.запускРаботыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.ингридиентыToolStripMenuItem,
            this.едаToolStripMenuItem,
            this.хранилищаToolStripMenuItem,
            this.сотрудникиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // ингридиентыToolStripMenuItem
            // 
            this.ингридиентыToolStripMenuItem.Name = "ингридиентыToolStripMenuItem";
            this.ингридиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ингридиентыToolStripMenuItem.Text = "Сантехника";
            this.ингридиентыToolStripMenuItem.Click += new System.EventHandler(this.ингредиентыToolStripMenuItem_Click);
            // 
            // едаToolStripMenuItem
            // 
            this.едаToolStripMenuItem.Name = "едаToolStripMenuItem";
            this.едаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.едаToolStripMenuItem.Text = "Ремонт";
            this.едаToolStripMenuItem.Click += new System.EventHandler(this.едаToolStripMenuItem_Click);
            // 
            // хранилищаToolStripMenuItem
            // 
            this.хранилищаToolStripMenuItem.Name = "хранилищаToolStripMenuItem";
            this.хранилищаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.хранилищаToolStripMenuItem.Text = "Хранилища";
            this.хранилищаToolStripMenuItem.Click += new System.EventHandler(this.хранилищаToolStripMenuItem_Click);
            // 
            // пополнитьХранилищеToolStripMenuItem
            // 
            this.пополнитьХранилищеToolStripMenuItem.Name = "пополнитьХранилищеToolStripMenuItem";
            this.пополнитьХранилищеToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.пополнитьХранилищеToolStripMenuItem.Text = "Пополнить хранилище";
            this.пополнитьХранилищеToolStripMenuItem.Click += new System.EventHandler(this.пополнитьХранилищеToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прайсРемонтовToolStripMenuItem,
            this.загруженностьСкладовToolStripMenuItem,
            this.заказыКлиентовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // прайсРемонтовToolStripMenuItem
            // 
            this.прайсРемонтовToolStripMenuItem.Name = "прайсРемонтовToolStripMenuItem";
            this.прайсРемонтовToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.прайсРемонтовToolStripMenuItem.Text = "Прайс ремонтов";
            this.прайсРемонтовToolStripMenuItem.Click += new System.EventHandler(this.прайсРемонтовToolStripMenuItem_Click);
            // 
            // загруженностьСкладовToolStripMenuItem
            // 
            this.загруженностьСкладовToolStripMenuItem.Name = "загруженностьСкладовToolStripMenuItem";
            this.загруженностьСкладовToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.загруженностьСкладовToolStripMenuItem.Text = "Загруженность складов";
            this.загруженностьСкладовToolStripMenuItem.Click += new System.EventHandler(this.загруженностьСкладовToolStripMenuItem_Click);
            // 
            // заказыКлиентовToolStripMenuItem
            // 
            this.заказыКлиентовToolStripMenuItem.Name = "заказыКлиентовToolStripMenuItem";
            this.заказыКлиентовToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.заказыКлиентовToolStripMenuItem.Text = "Заказы клиентов";
            this.заказыКлиентовToolStripMenuItem.Click += new System.EventHandler(this.заказыКлиентовToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(644, 352);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateOrder.Location = new System.Drawing.Point(662, 48);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(207, 30);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPayOrder.Location = new System.Drawing.Point(662, 254);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(207, 30);
            this.buttonPayOrder.TabIndex = 3;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.buttonPayOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRef.Location = new System.Drawing.Point(662, 318);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(207, 30);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // запускРаботыToolStripMenuItem
            // 
            this.запускРаботыToolStripMenuItem.Name = "запускРаботыToolStripMenuItem";
            this.запускРаботыToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.запускРаботыToolStripMenuItem.Text = "Запуск работы";
            this.запускРаботыToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 382);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Абстрактный ремонт сантехники";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ингридиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem едаToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem хранилищаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьХранилищеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсРемонтовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загруженностьСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыКлиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботыToolStripMenuItem;
    }
}

