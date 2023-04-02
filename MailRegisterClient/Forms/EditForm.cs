namespace MailRegisterClient
{
    public partial class EditForm : Form
    {
        private Dictionary<int, string> _employees;
        public EditForm(Dictionary<int, string> employees)
        {
            InitializeComponent();
            _employees = employees;
            senderComboBox.DataSource = _employees.Values.ToList();
            addresseeComboBox.DataSource = _employees.Values.ToList();
        }

        public EditForm(string name, DateTime dateTime, int? senderId, int? addresseeId, string? body, Dictionary<int, string> employees)
            : this(employees)
        {
            nameTextBox.Text = name;
            dateTimePicker.Value = dateTime;
            senderComboBox.DataSource = _employees.Values.ToList();
            addresseeComboBox.DataSource = _employees.Values.ToList();
            senderComboBox.SelectedIndex = senderId ?? 0;
            addresseeComboBox.SelectedIndex = addresseeId ?? 0;
            bodyTextBox.Text = body;
        }
    }
}
