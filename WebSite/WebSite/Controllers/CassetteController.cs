using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApi.Models;
using Newtonsoft.Json;

namespace WebSite.Controllers
{
    public class CassetteController : Controller
    {
        public async Task<IActionResult> CassettePageAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7022/Show/Cassette");
            string json = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(json);
            List<CassetteView> data = JsonConvert.DeserializeObject<List<CassetteView>>(json);
            
            foreach (var item in data)
            {
                Debug.WriteLine(item); 
            }
            return View(data);
        }
    }
    
}
