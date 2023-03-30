using System;
using System.Collections.Generic;

namespace MailRegisterServer.Entities;

public class Employee
{
    public int Id { get; set; }
    public int? Age { get; set; }
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = null!;
    public string JobTitle { get; set; } = null!;
    public Guid Rowguid { get; set; }
    public virtual ICollection<Mail> MailRecieved { get; }
    public virtual ICollection<Mail> MailSent { get; }
}
