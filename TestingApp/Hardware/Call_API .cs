using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace API_SERVICE.Controllers
{
    public class TestCallApi
    {
        private static Job job;

        public TestCallApi()
        {

        }
        public static async void CallApi()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://reqres.in");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // GET Method
                HttpResponseMessage response = await client.GetAsync("api/users?page=2");   // https://reqres.in/api/users?page=2
                if (response.IsSuccessStatusCode)
                {
                    var obj = await response.Content.ReadAsAsync<Object>();
                }
                //System.Net.Http.PostAsJsonAsync;
                // POST method
                Job  job = new Job("quynh", "IT");
                HttpResponseMessage responsePost = await client.PostAsJsonAsync("/api/users", job); // put router and body value
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    var Url = responsePost.Headers.Location;
                    var obj = await responsePost.Content.ReadAsAsync<Object>();
                }
            }
        }

        public class Job
        {
          public Job(string name, string jobName)
            {
                Name = name;
                Job_Name = jobName;
            }
            public string Name { get; set; }
            public string Job_Name { get; set; }
        }
    }
}
