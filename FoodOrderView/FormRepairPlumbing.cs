using AbdtractRepairOrderServiceDAL.Interfaces;
using AbstractRepairOrderServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace RepairOrderView
{
    public partial class FormRepairPlumbing : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public RepairPlumbingViewModel Model
        {
            set { model = value; }
            get
            {
                return model;
            }
        }
        private readonly IPlumbingService service;
        private RepairPlumbingViewModel model;
        public FormRepairPlumbing(IPlumbingService service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormProductPlumbing_Load(object sender, EventArgs e)
        {
            try
            {
                List<PlumbingViewModel> list = service.GetList();
                if (list != null)
                {
                    comboBoxPlumbing.DisplayMember = "PlumbingName";
                    comboBoxPlumbing.ValueMember = "Id";
                    comboBoxPlumbing.DataSource = list;
                    comboBoxPlumbing.SelectedItem = null;
                }
                else
                {
                    Console.WriteLine("пусто");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxPlumbing.Enabled = false;
                comboBoxPlumbing.SelectedValue = model.PlumbingId;
                comboBoxPlumbing.Text = model.Count.ToString();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxPlumbing.SelectedValue == null)
            {
                if (string.IsNullOrEmpty(comboBoxPlumbing.Text))
                {
                    MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    model = new RepairPlumbingViewModel
                    {
                        PlumbingId = Convert.ToInt32(comboBoxPlumbing.SelectedValue),
                        PlumbingName = comboBoxPlumbing.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
            }
            try
            {
                if (model == null)
                {
                    model = new RepairPlumbingViewModel
                    {
                        PlumbingId = Convert.ToInt32(comboBoxPlumbing.SelectedValue),
                        PlumbingName = comboBoxPlumbing.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBoxCount.Text);
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
