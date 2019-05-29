﻿using AbstractRepairPlumbingServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.Interfaces;
using AbstractRepairPlumbingServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.Interfaces;
using AbstractRepairPlumbingServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RepairOrderView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                List<OrderViewModel> list = APIClient.GetRequest<List<OrderViewModel>>("api/Main/GetList");
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка Load", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormClients();
            form.ShowDialog();
        }
        private void ингредиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPlumbings();
            form.ShowDialog();
        }
        private void едаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormRepairs();
            form.ShowDialog();
        }
        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = new FormCreateOrder();
            form.ShowDialog();
            LoadData();
        }
        private void buttonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    APIClient.PostRequest<OrderBindingModel, bool>("api/Main/PayOrder", new OrderBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void хранилищаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormStorages();
            form.ShowDialog();
        }

        private void пополнитьХранилищеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPutOnStorage();
            form.ShowDialog();
        }
        private void прайсРемонтовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    APIClient.PostRequest<ReportBindingModel, bool>("api/Report/SaveProductPrice", new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void загруженностьСкладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormStoragesLoad();
            form.ShowDialog();
        }
        private void заказыКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormClientOrders();
            form.ShowDialog();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormImplementers();
            form.ShowDialog();
        }
        private void запускРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                APIClient.PostRequest<int?, bool>("api/Main/StartWork", null);
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void письмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormMails();
            form.ShowDialog();
        }
    }
}