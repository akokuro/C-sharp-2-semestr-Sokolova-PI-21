namespace RepairOrderView
{
    partial class FormStoragesLoad
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnStorage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlunbing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStorage,
            this.ColumnPlunbing,
            this.ColumnCount});
            this.dataGridView.Location = new System.Drawing.Point(3, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(616, 336);
            this.dataGridView.TabIndex = 0;
            // 
            // ColumnStorage
            // 
            this.ColumnStorage.HeaderText = "Склад";
            this.ColumnStorage.Name = "ColumnStorage";
            this.ColumnStorage.Width = 200;
            // 
            // ColumnPlunbing
            // 
            this.ColumnPlunbing.HeaderText = "Сантехника";
            this.ColumnPlunbing.Name = "ColumnPlunbing";
            this.ColumnPlunbing.Width = 200;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.Width = 150;
            // 
            // FormStorageLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 360);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormStorageLoad";
            this.Text = "FormStorageLoad";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStorage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlunbing;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
    }
}