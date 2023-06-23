using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Physicwmp.Data
{
    public class Services
    {
        public HttpClient client = new HttpClient();
        public async Task<List<Notification>> GetAllNotification(int grade)
        {
            HttpClient client = new HttpClient();
            List<Notification> notis = new List<Notification>();
            string ri = "https://physicwmp.herokuapp.com/api/notifications/" + grade.ToString();
            Uri uri = new Uri(ri);
            HttpResponseMessage rep = await client.GetAsync(uri);
            rep.EnsureSuccessStatusCode();
            if (rep.IsSuccessStatusCode)
            {
                string content = await rep.Content.ReadAsStringAsync();
                notis = JsonConvert.DeserializeObject<List<Notification>>(content);
            }
            return notis;
        }

        public async Task<List<HomeworkModel>> GetAllHomeworks(int grade)
        {
            HttpClient client = new HttpClient();
            List<HomeworkModel> hws = new List<HomeworkModel>();
            string ri = "https://physicwmp.herokuapp.com/api/homeworks/" + grade.ToString();
            Uri uri = new Uri(ri);
            HttpResponseMessage rep = await client.GetAsync(uri);
            rep.EnsureSuccessStatusCode();
            if (rep.IsSuccessStatusCode)
            {
                string content = await rep.Content.ReadAsStringAsync();
                hws = JsonConvert.DeserializeObject<List<HomeworkModel>>(content);
            }
            return hws;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            HttpClient client = new HttpClient();
            List<Student> students = new List<Student>();
            string ri = "https://physicwmp.herokuapp.com/api/students";
            Uri uri = new Uri(ri);
            HttpResponseMessage rep = await client.GetAsync(uri);
            rep.EnsureSuccessStatusCode();
            if (rep.IsSuccessStatusCode)
            {
                string content = await rep.Content.ReadAsStringAsync();
                students = JsonConvert.DeserializeObject<List<Student>>(content);
            }
            return students;
        }
        
    }
}
