using MailRegisterServer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailRegisterClient.Forms
{
    public partial class DraftsForm : Form
    {
        private List<MailViewModel> _viewModels;
        public MailViewModel? SelectedViewModel { get; private set; }
        public DraftsForm(List<MailViewModel> viewModels)
        {
            InitializeComponent();

            _viewModels = viewModels;
            dataGridView.DataSource = _viewModels;

            dataGridView.CellDoubleClick += (sender, e) =>
            {
                string? selectedViewModelName = dataGridView.SelectedRows[0].Cells[1].Value.ToString();

                SelectedViewModel = _viewModels.FirstOrDefault(x => x.Name == selectedViewModelName);

                DialogResult = DialogResult.OK;
                Close();
            };
        }
    }
}
