﻿using AbstractRepairPlumbingOrderServiceDAL.Interfaces;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.ViewModel;
using System;
using System.Windows.Forms;

namespace RepairOrderView
{
    public partial class FormStorage : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        public FormStorage()
        {
            InitializeComponent();
        }
        private void FormStorage_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    StorageViewModel view = APIClient.GetRequest<StorageViewModel>("api/Storage/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.StorageName;
                        dataGridView.DataSource = view.StoragePlumbings;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].AutoSizeMode =
                       DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<StorageBindingModel, bool>("api/Storage/UpdElement", new StorageBindingModel
                    {
                        Id = id.Value,
                        StorageName = textBoxName.Text
                    });
                }
                else
                {
                     APIClient.PostRequest<StorageBindingModel, bool>("api/Storage/AddElement", new StorageBindingModel
                    {
                        StorageName = textBoxName.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
