using AbstractRepairPlumbingOrderServiceDAL.Interfaces;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.ViewModel;
using System;
using System.Windows.Forms;

namespace RepairOrderView
{
    public partial class FormPlumbing : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        public FormPlumbing()
        {
            InitializeComponent();
        }
        private void FormPlumbing_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    PlumbingViewModel view = APIClient.GetRequest<PlumbingViewModel>("api/Plumbing/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.PlumbingName;
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
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<PlumbingBindingModel, bool>("api/Plumbing/UpdElement", new PlumbingBindingModel
                    {
                        Id = id.Value,
                        PlumbingName = textBoxName.Text
                    });
                }
                else
                {
                   APIClient.PostRequest<PlumbingBindingModel, bool>("api/Plumbing/AddElement", new PlumbingBindingModel
                    {
                        PlumbingName = textBoxName.Text
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
