using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

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

        [Route("Add/[controller]/{id_cassette}/{name_movie}/{year_movie}/{id_country}/{id_genre}/{id_director}/{price}")]
        [HttpGet]
        [EnableCors(PolicyName = "AllowAll")]
        public IActionResult AddCassette([FromRoute] int id_cassette, [FromRoute] string name_movie, [FromRoute] int year_movie,
            [FromRoute] int id_country, [FromRoute] int id_genre, [FromRoute] int id_director, [FromRoute] int price)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB DB = new ContextDB())
            {
                Cassette NewCassette = new Cassette();
                NewCassette.id_cassette = NewCassette.NewIndex();
                NewCassette.name_movie = name_movie;
                NewCassette.year_movie = year_movie;
                NewCassette.id_country = id_country;
                NewCassette.id_genre = id_genre;
                NewCassette.id_director = id_director;
                NewCassette.price = price;
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
