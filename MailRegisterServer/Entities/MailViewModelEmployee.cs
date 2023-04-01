namespace MailRegisterServer.Entities
{
    public class MailViewModelEmployee
    {
        public MailViewModelEmployee(int id, int? age, string firstName, string? middleName, string lastName, string jobTitle, Guid rowguid)
        {
            Id = id;
            Age = age;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            JobTitle = jobTitle;
            Rowguid = rowguid;
        }

        public int Id { get; set; }
        public int? Age { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public Guid Rowguid { get; set; }

        public override string ToString()
        {
            return $"{JobTitle} - {FirstName} {MiddleName ?? ""} {LastName}";
        }
    }
}
