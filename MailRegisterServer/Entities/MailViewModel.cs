namespace MailRegisterServer.Entities
{
    public class MailViewModel
    {
        public MailViewModel(int id,
                             string name,
                             DateTime date,
                             string? body,
                             int? addresseeId,
                             int? senderId,
                             Guid? rowguid,
                             MailViewModelEmployee? addressee = null,
                             MailViewModelEmployee? sender = null)
        {
            Id = id;
            Name = name;
            Date = date;
            Body = body;
            AddresseeId = addresseeId;
            SenderId = senderId;
            Rowguid = rowguid;
            Addressee = addressee;
            Sender = sender;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public string? Body { get; set; }
        public int? AddresseeId { get; set; }
        public int? SenderId { get; set; }
        public Guid? Rowguid { get; set; }
        public MailViewModelEmployee? Addressee { get; set; }
        public MailViewModelEmployee? Sender { get; set; }

        public Mail AsModel()
        {
            var model = new Mail(Name, Date, Body, AddresseeId, SenderId)
            {
                Id = Id,
                Rowguid = Rowguid
            };
            if (Addressee != null)
            {
                model.Addressee = new Employee()
                {
                    Id = Addressee.Id,
                    Age = Addressee.Age,
                    FirstName = Addressee.FirstName,
                    MiddleName = Addressee.MiddleName,
                    LastName = Addressee.LastName,
                    JobTitle = Addressee.JobTitle,
                    Rowguid = Addressee.Rowguid
                };
            }
            if (Sender != null)
            {
                model.Sender = new Employee()
                {
                    Id = Sender.Id,
                    Age = Sender.Age,
                    FirstName = Sender.FirstName,
                    MiddleName = Sender.MiddleName,
                    LastName = Sender.LastName,
                    JobTitle = Sender.JobTitle,
                    Rowguid = Sender.Rowguid
                };
            }
            return model;
        }
    }
}
