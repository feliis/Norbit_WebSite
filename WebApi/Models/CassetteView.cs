
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class CassetteView
    {
        public int id_cassette { get; set; }

        public string name_movie { get; set; }

        public string genre { get; set; }

        public string country { get; set; }

        public int year { get; set; }

        public int price { get; set; }

        public int qty { get; set; }

    }
}
