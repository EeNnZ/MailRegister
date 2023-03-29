using System;
using System.Collections.Generic;

namespace MailRegisterServer.Entities;

public partial class Mail
{
    public Mail(string name, DateTime date, string? body, int? addresseeId, int? senderId)
    {
        Name = name;
        Date = date;
        Body = body;
        AddresseeId = addresseeId;
        SenderId = senderId;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Date { get; set; }
    public string? Body { get; set; }
    public int? AddresseeId { get; set; }
    public int? SenderId { get; set; }
    public Guid? Rowguid { get; set; }
    public virtual Employee? Addressee { get; set; }
    public virtual Employee? Sender { get; set; }
}
