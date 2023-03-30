using System;
using System.Collections.Generic;

namespace MailRegisterServer.Entities;

public class Mail
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

    public MailViewModel ToViewModel()
    {
        var viewModel = new MailViewModel(Id, Name, Date, Body, AddresseeId, SenderId, Rowguid);
        if (Addressee != null)
        {
            viewModel.Addressee = new MailViewModelEmployee(Addressee.Id,
                                               Addressee.Age,
                                               Addressee.FirstName,
                                               Addressee.MiddleName,
                                               Addressee.LastName,
                                               Addressee.JobTitle,
                                               Addressee.Rowguid);
        }
        if (Sender != null)
        {
            viewModel.Sender = new MailViewModelEmployee(Sender.Id,
                                               Sender.Age,
                                               Sender.FirstName,
                                               Sender.MiddleName,
                                               Sender.LastName,
                                               Sender.JobTitle,
                                               Sender.Rowguid);
        }
        return viewModel;
    }
}
