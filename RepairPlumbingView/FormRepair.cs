using AbstractRepairPlumbingServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.Interfaces;
using AbstractRepairPlumbingServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RepairOrderView
{
    public partial class FormRepair : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private List<RepairPlumbingViewModel> RepairPlumbings;
        public FormRepair()
        {
            InitializeComponent();
        }
        private void FormRepair_Load(object sender, EventArgs e)
        {
            Console.WriteLine("hi");
            if (id.HasValue)
            {
                try
                {
                    RepairViewModel view = APIClient.GetRequest<RepairViewModel>("api/Repair/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.RepairName;
                        textBoxPrice.Text = view.Price.ToString();
                        RepairPlumbings = view.RepairPlumbings;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                RepairPlumbings = new List<RepairPlumbingViewModel>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (RepairPlumbings != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = RepairPlumbings;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormRepairPlumbing();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.RepairId = id.Value;
                    }
                    RepairPlumbings.Add(form.Model);
                }
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormRepairPlumbing();
                form.Model = RepairPlumbings[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RepairPlumbings[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        RepairPlumbings.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (RepairPlumbings == null || RepairPlumbings.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<RepairPlumbingBindingModel> RepairPlumbingBM = new
               List<RepairPlumbingBindingModel>();
                for (int i = 0; i < RepairPlumbings.Count; ++i)
                {
                    RepairPlumbingBM.Add(new RepairPlumbingBindingModel
                    {
                        Id = RepairPlumbings[i].Id,
                        RepairId = RepairPlumbings[i].RepairId,
                        PlumbingId = RepairPlumbings[i].PlumbingId,
                        Count = RepairPlumbings[i].Count
                    });
                }
                if (id.HasValue)
                {
                    APIClient.PostRequest<RepairBindingModel, bool>("api/Repair/UpdElement", new RepairBindingModel
                    {
                        Id = id.Value,
                        RepairName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        RepairPlumbings = RepairPlumbingBM
                    });
                }
                else
                {
                    APIClient.PostRequest<RepairBindingModel, bool>("api/Repair/AddElement", new RepairBindingModel
                    {
                        RepairName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        RepairPlumbings = RepairPlumbingBM
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
