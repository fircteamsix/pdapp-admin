using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PDApp
{
    class UserService
    {
        static async Task Login (string user, string pass)
        {
            HttpClient Cliente = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com")};
            var response = await Cliente.GetAsync("/users");
            // var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(response);
        }
    }
}
