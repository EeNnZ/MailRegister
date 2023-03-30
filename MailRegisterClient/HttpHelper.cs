using MailRegisterServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MailRegisterClient
{
    public static class HttpHelper
    {
        public static HttpClient Client { get; }

        static HttpHelper()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:3517/api/mails/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IEnumerable<MailViewModel>?> GetMails()
        {
            var response = await Client.GetStringAsync("http://localhost:3517/api/mails");
            var mails = JsonSerializer.Deserialize<IEnumerable<MailViewModel>>(response, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            });
            return mails;
        }

        public static async Task<MailViewModel?> GetMail(int id)
        {
            var response = await Client.GetStringAsync($"http://localhost:3517/api/mails/{id}");
            var mail = JsonSerializer.Deserialize<MailViewModel>(response, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            });
            return mail;
        }

        public static async Task<bool> PostMail(Mail mail)
        {
            //var newMail = new Mail("test post method", DateTime.Now, "message body", 5, 2);
            MailViewModel mvm = mail.ToViewModel();
            var postContent = JsonContent.Create(mvm);
            var response = await Client.PostAsync("http://localhost:3517/api/mails", postContent);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> PutMail(int id, MailViewModel mail)
        {
            var putContent = JsonContent.Create(mail);
            var response = await Client.PutAsync($"http://localhost:3517/api/mails/{id}", putContent);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> DeleteMail(int id)
        {
            var response = await Client.DeleteAsync($"http://localhost:3517/api/mails/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
