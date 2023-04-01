using MailRegisterServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            Client.BaseAddress = new Uri("http://localhost:3517/api/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IEnumerable<MailViewModel>?> GetMails()
        {
            var response = await Client.GetAsync($"{Client.BaseAddress}mails");
            response.EnsureSuccessStatusCode();
            var mails = JsonSerializer.Deserialize<IEnumerable<MailViewModel>>(response.Content.ReadAsStream(), new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            });
            return mails;
        }

        public static async Task<MailViewModel?> GetMail(int id)
        {
            var response = await Client.GetAsync($"{Client.BaseAddress}mails/{id}");
            response.EnsureSuccessStatusCode();
            var mail = JsonSerializer.Deserialize<MailViewModel>(response.Content.ReadAsStream(), new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            });
            return mail;
        }

        public static async Task<HttpStatusCode> PostMail(Mail mail)
        {
            //var newMail = new Mail("test post method", DateTime.Now, "message body", 5, 2);
            MailViewModel mvm = mail.ToViewModel();
            var postContent = JsonContent.Create(mvm);
            var response = await Client.PostAsync($"{Client.BaseAddress}mails", postContent);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }

        public static async Task<HttpStatusCode> PutMail(int id, MailViewModel mail)
        {
            var putContent = JsonContent.Create(mail);
            var response = await Client.PutAsync($"{Client.BaseAddress}mails/{id}", putContent);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }

        public static async Task<HttpStatusCode> DeleteMail(int id)
        {
            var response = await Client.DeleteAsync($"{Client.BaseAddress}mails/{id}");
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }

        public static async Task<IDictionary<int, string>?> GetEmployees()
        {
            var response = await Client.GetAsync($"{Client.BaseAddress}employees");
            response.EnsureSuccessStatusCode();
            var empDic = JsonSerializer.Deserialize<IDictionary<int, string>?>(response.Content.ReadAsStream(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return empDic;
        }

        public static async Task<KeyValuePair<int, string>?> GetEmployee(int id)
        {
            var response = await Client.GetAsync($"{Client.BaseAddress}employees/{id}");
            response.EnsureSuccessStatusCode();
            var empStr = JsonSerializer.Deserialize<KeyValuePair<int, string>?>(response.Content.ReadAsStream(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return empStr;
        }
    }
}
