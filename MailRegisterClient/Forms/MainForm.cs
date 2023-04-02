using MailRegisterClient.Forms;
using MailRegisterServer.Entities;
using System.Net;
using System.Text.Json;

namespace MailRegisterClient
{
    public partial class MainForm : Form
    {
        #region Fields
        private const string DraftsFolderName = "Drafts";

        private string _draftsFolder;
        private string _workingDirectory;

        private List<MailViewModel> _drafts;
        private List<MailViewModel> _mails;

        private Dictionary<int, string> _employees;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            _workingDirectory = Directory.GetCurrentDirectory();
            _draftsFolder = Path.Combine(_workingDirectory, DraftsFolderName);

            _drafts = LoadDrafts();
            _mails = new();
            _employees = new();

            Load += MainForm_LoadAsync;
            FormClosed += MainForm_FormClosed;

        }

        #region drafts
        private void SaveDrafts()
        {
            if (!Directory.Exists(_draftsFolder))
            {
                Directory.CreateDirectory(_draftsFolder);
            }

            foreach (var draft in _drafts)
            {
                string serialized = JsonSerializer.Serialize(draft, new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(Path.Combine(_workingDirectory, DraftsFolderName, $"{draft.Name}_draft.json"), serialized);
            }
        }
        private List<MailViewModel> LoadDrafts()
        {
            if (!Directory.Exists(_draftsFolder))
            {
                Directory.CreateDirectory(_draftsFolder);
            }

            var deserializedDrafts = new List<MailViewModel>();

            var jsonFilePaths = Directory.EnumerateFiles(_draftsFolder);
            int filesCount = jsonFilePaths.Count();

            int successDeserialized = 0;
            foreach (var path in jsonFilePaths)
            {
                string jsonContent = File.ReadAllText(path);
                var deserialized = JsonSerializer.Deserialize<MailViewModel>(jsonContent);
                if (deserialized != null)
                {
                    deserializedDrafts.Add(deserialized);
                    successDeserialized++;
                }
            }

            if (filesCount != successDeserialized)
            {
                MessageBox.Show($"{filesCount - successDeserialized} files cannot be deserialized. Check if .json is malformed",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            return deserializedDrafts;
        }
        #endregion

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

            if (formResult == DialogResult.Abort)
            {
                var viewmodel = newMail.ToViewModel();
                _drafts.Add(viewmodel);
                MessageBox.Show("Draft will be saved to folder when application closes", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var opResult = await RegisterMail(newMail);
            await UpdateDataGridViewAsyncTask();
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

            if (formResult == DialogResult.Abort)
            {
                _drafts.Add(selectedMail);
                MessageBox.Show("Draft will be saved to folder when application closes", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var opResult = await ModifyMail(id, selectedMail);
            await UpdateDataGridViewAsyncTask();
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
            await UpdateDataGridViewAsyncTask();
            toolStripStatusLabel.Text = opResult.ToString();
        }

        private async void checkDraftsButton_Click(object sender, EventArgs e)
        {
            DraftsForm draftsForm = new DraftsForm(_drafts);
            var formResult = draftsForm.ShowDialog(this);

            if (formResult == DialogResult.OK)
            {
                var draft = draftsForm.SelectedViewModel;
                if (draft == null)
                {
                    //TODO: Handle null
                    return;
                }
                //TODO: Code duplication here
                EditForm regForm = new(draft.Name, draft.Date, draft.SenderId, draft.AddresseeId, draft.Body, _employees);
                var editFormResult = regForm.ShowDialog(this);
                if (editFormResult == DialogResult.Cancel)
                {
                    regForm.Close();
                    return;
                }
                Mail newMail = new Mail(regForm.nameTextBox.Text,
                                    regForm.dateTimePicker.Value,
                                    regForm.bodyTextBox.Text,
                                    regForm.addresseeComboBox.SelectedIndex + 1,
                                    regForm.senderComboBox.SelectedIndex + 1);

                if (editFormResult == DialogResult.Abort)
                {
                    var viewmodel = newMail.ToViewModel();
                    _drafts.Add(viewmodel);
                    MessageBox.Show("Draft will be saved to folder when application closes", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var opResult = await RegisterMail(newMail);
                await UpdateDataGridViewAsyncTask();
                toolStripStatusLabel.Text = opResult.ToString();
            }
        }
        #endregion

        #region form events handlers
        private async void MainForm_LoadAsync(object? sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Updating mail list...";
            await UpdateDataGridViewAsyncTask();
        }
        private void MainForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (_drafts.Any())
            {
                SaveDrafts();
            }
        }
        #endregion

        #region DataGrid methods
        private async Task UpdateDataGridViewAsyncTask()
        {
            await InitializeLocalCollectoins();
            FillDataGridView();
        }

        private async Task InitializeLocalCollectoins()
        {
            DisableButtons();

            var employees = GetEmployees();
            var mails = await GetMails();

            _mails = mails.ToList();
            _employees = (await employees).ToDictionary(x => x.Key, x => x.Value);
        }

        private void FillDataGridView()
        {
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

            EnableButtons();
        }
        #endregion

        #region controls
        private void EnableButtons()
        {
            registerButton.Enabled = true;
            modifyButton.Enabled = true;
            deleteButton.Enabled = true;
        }
        private void DisableButtons()
        {
            registerButton.Enabled = false;
            modifyButton.Enabled = false;
            deleteButton.Enabled = false;
        }
        #endregion
    }
}