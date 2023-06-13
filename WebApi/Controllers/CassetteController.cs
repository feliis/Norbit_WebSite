using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;



namespace WebApi.Controllers
{
    public class CassetteController : Controller
    {

        [Route("Show/[controller]")]
        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            using (ContextDB db = new ContextDB())
            {
                var cassetteList = await db.cassette
                .Include(s => s.country)
                .Include(s => s.genre)
                .Include(s => s.director)
                .ToListAsync();



                var cassetteViewList = cassetteList.Select(s => new CassetteView
                {
                    id_cassette = s.id_cassette,
                    name_movie = s.name_movie,
                    genre = s.genre.name_genre,
                    country = s.country.name_country,
                    year = s.year_movie,
                    price = s.price,
                    director_firstname = s.director.firstname,
                    director_surname = s.director.surname,
                    qty = s.qty
                }).ToList();

                return Ok(cassetteViewList);
            }
        }

        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult AddCassette([FromBody] Cassette NewCassette)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB DB = new ContextDB())
            {
                NewCassette.id_cassette = NewCassette.NewIndex();
                DB.Add(NewCassette);
                DB.SaveChanges();
                return Ok();
            }
        }

        

        [Route("DeleteCassette/[controller]/{id_cassette}")]
        [HttpGet]
        public IActionResult DeleteCassetteByID(int id_cassette)
        {
            using (ContextDB DB = new ContextDB())
            {
                Cassette data = DB.cassette.Find(id_cassette);
                if (data != null)
                {
                    DB.cassette.Remove(data);
                    DB.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);

            }
        }
    }
}
