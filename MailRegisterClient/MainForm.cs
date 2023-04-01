using MailRegisterServer.Entities;
using MessagePack.Formatters;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net;

namespace MailRegisterClient
{
    public partial class MainForm : Form
    {
        private List<MailViewModel> _mails;
        private Dictionary<int, string> _employees;

        public MainForm()
        {
            InitializeComponent();

            _mails = new();
            _employees = new();

            FillDataGridView();

        }

        private void FillDataGridView()
        {
            //TODO: REWRITE THIS SHIT
            registerButton.Enabled = false;
            modifyButton.Enabled = false;
            deleteButton.Enabled = false;

            toolStripStatusLabel.Text = "Updating mail list...";

            Task.Run(() =>
            {
                _mails = GetMails().Result.ToList();
                _employees = GetEmployees().Result.ToDictionary(x => x.Key, x => x.Value);
            }).Wait();

            dataGridView.DataSource = _mails
            .Select(mail => new
            {
                mail.Id,
                mail.Name,
                mail.Date,
                mail.Body,
                Addressee = mail.Addressee?.ToString(),
                Sender = mail.Sender?.ToString()
            }).ToList();
            dataGridView.Columns["Id"].Visible = false;
            toolStripStatusLabel.Text = "Ready";
            registerButton.Enabled = true;
            modifyButton.Enabled = true;
            deleteButton.Enabled = true;
        }

        #region CRUD

        public async Task<IDictionary<int, string>> GetEmployees()
        {
            try
            {
                var employees = await HttpHelper.GetEmployees();
                return employees ?? new Dictionary<int, string>();
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show(httpEx.Message, httpEx.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Dictionary<int, string>();
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show(jsonEx.Message, "Json serializer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Dictionary<int, string>();
            }
            catch (Exception) { throw; }
        }

        public async Task<KeyValuePair<int, string>?> GetEmployee(int id)
        {
            try
            {
                var employee = await HttpHelper.GetEmployee(id);
                return employee;
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show(httpEx.Message, httpEx.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show(jsonEx.Message, "Json serializer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<MailViewModel>> GetMails()
        {
            try
            {
                var mails = await HttpHelper.GetMails();
                return mails ?? new List<MailViewModel>();
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show(httpEx.Message, httpEx.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<MailViewModel>();
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show(jsonEx.Message, "Json serializer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<MailViewModel>();
            }
            catch (Exception) { throw; }
        }

        public async Task<MailViewModel?> GetMail(int id)
        {
            try
            {
                var mail = await HttpHelper.GetMail(id);
                return mail;
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show(httpEx.Message, httpEx.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show(jsonEx.Message, "Json serializer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<HttpStatusCode?> DeleteMail(int id)
        {
            try
            {
                var statusCode = await HttpHelper.DeleteMail(id);
                return statusCode;
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show(httpEx.Message, httpEx.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return httpEx.StatusCode;
            }
            catch (Exception) { throw; }
        }

        public async Task<HttpStatusCode?> RegisterMail(Mail newMail)
        {
            try
            {
                var statusCode = await HttpHelper.PostMail(newMail);
                return statusCode;
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show(httpEx.Message, httpEx.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return httpEx.StatusCode;
            }
            catch (Exception) { throw; }
        }

        public async Task<HttpStatusCode?> ModifyMail(int id, MailViewModel mail)
        {
            try
            {
                var statusCode = await HttpHelper.PutMail(id, mail);
                return statusCode;
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show(httpEx.Message, httpEx.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return httpEx.StatusCode;
            }
            catch (Exception) { throw; }
        }

        #endregion

        #region Button clicks
        private async void registerButton_Click(object sender, EventArgs e)
        {
            EditForm mailForm = new(_employees);
            var formResult = mailForm.ShowDialog(this);
            if (formResult == DialogResult.Cancel)
            {
                mailForm.Close();
                return;
            }
            Mail newMail = new Mail(mailForm.nameTextBox.Text,
                                    mailForm.dateTimePicker.Value,
                                    mailForm.bodyTextBox.Text,
                                    mailForm.addresseeComboBox.SelectedIndex + 1,
                                    mailForm.senderComboBox.SelectedIndex + 1);
            var opResult = await RegisterMail(newMail);
            FillDataGridView();
            toolStripStatusLabel.Text = opResult.ToString();
        }

        private async void modifyButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select at least 1 row to modify", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool idFound = int.TryParse(dataGridView.SelectedRows[0].Cells[0].Value.ToString(), out int id);
            var selectedMail = _mails.FirstOrDefault(x => x.Id == id);

            if (!idFound || selectedMail is null) return;

            EditForm mailForm = new(selectedMail.Name, selectedMail.Date, selectedMail.SenderId - 1, selectedMail.AddresseeId - 1, selectedMail.Body, _employees);
            var formResult = mailForm.ShowDialog(this);
            if (formResult == DialogResult.Cancel)
            {
                mailForm.Close();
                return;
            }

            selectedMail.Name = mailForm.nameTextBox.Text;
            selectedMail.Date = mailForm.dateTimePicker.Value;
            selectedMail.Body = mailForm.bodyTextBox.Text;
            selectedMail.AddresseeId = mailForm.addresseeComboBox.SelectedIndex + 1;
            selectedMail.SenderId = mailForm.senderComboBox.SelectedIndex + 1;
            var opResult = await ModifyMail(id, selectedMail);
            FillDataGridView();
            toolStripStatusLabel.Text = opResult.ToString();
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select at least 1 row to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool idFound = int.TryParse(dataGridView.SelectedRows[0].Cells[0].Value.ToString(), out int id);
            var selectedMail = _mails.FirstOrDefault(x => x.Id == id);

            if (!idFound || selectedMail is null) return;

            var opResult = await DeleteMail(id);
            FillDataGridView();
            toolStripStatusLabel.Text = opResult.ToString();
        }
        #endregion
    }
}