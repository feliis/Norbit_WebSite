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
        public async Task<IActionResult> AddNewCassette()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7022/Show/Cassette");
            string json = await response.Content.ReadAsStringAsync();
            List<CassetteView> data = JsonConvert.DeserializeObject<List<CassetteView>>(json);
            var cassettes = data.ToList();
            ViewBag.Cassette = cassettes;

            HttpResponseMessage ResponseCountry = await client.GetAsync("https://localhost:7022/ShowCountry/InfoCassette");

            json = await ResponseCountry.Content.ReadAsStringAsync();

            List<Country> dataCountry = JsonConvert.DeserializeObject<List<Country>>(json);

            var country = dataCountry.ToList();

            ViewBag.Country = country;


            HttpResponseMessage ResponseGenre = await client.GetAsync("https://localhost:7022/ShowGenre/InfoCassette");

            json = await ResponseGenre.Content.ReadAsStringAsync();

            List<Genre> dataGenre = JsonConvert.DeserializeObject<List<Genre>>(json);

            var genre = dataGenre.ToList();

            ViewBag.Genre = genre;

            HttpResponseMessage ResponseDirector = await client.GetAsync("https://localhost:7022/ShowDirector/InfoCassette");

            json = await ResponseDirector.Content.ReadAsStringAsync();

            List<Director> dataDirector = JsonConvert.DeserializeObject<List<Director>>(json);

            var director = dataDirector.ToList();

            ViewBag.Director = director;

            return View();


        }

        public IActionResult DeleteCassette()
        {
            return View();
        }

        public async Task<IActionResult> CassettePageAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7022/Show/Cassette");
            string json = await response.Content.ReadAsStringAsync();
            List<CassetteView> data = JsonConvert.DeserializeObject<List<CassetteView>>(json);
            var cassettes = data.ToList();
            ViewBag.Cassette = cassettes;
            return View(data);
        }

    }
}
