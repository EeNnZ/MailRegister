using System;
using System.Collections.Generic;

namespace MailRegisterServer;

public partial class Employee
{
    public int Id { get; set; }

    public int? Age { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public Guid Rowguid { get; set; }

    public virtual ICollection<Mail> MailRecieved { get; } = new List<Mail>();

    public virtual ICollection<Mail> MailSent { get; } = new List<Mail>();
}
