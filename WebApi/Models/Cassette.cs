
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace WebApi.Models
{
    public class Cassette
    {

        [Key]
        public int id_cassette { get; set; }

        public string name_movie { get; set; }

        public int id_genre { get; set; }

        public int id_country { get; set; }

        public int id_director { get; set; }

        public int year_movie { get; set; }

        public int price { get; set; }

        public int qty { get; set; }

        [ForeignKey("id_country")]
        public Country country { get; set; }

        [ForeignKey("id_genre")]
        public Genre genre { get; set; }

        [ForeignKey("id_director")]
        public Director director { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var CassetteList = DB.cassette.ToList();
                foreach (Cassette p in CassetteList)
                {
                    if (p.id_cassette > Max) Max = p.id_cassette;
                }
                return (Max + 1);
            }
        }
    }
}
