
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class Director
    {

        [Key] 
        public int id_director { get; set; }

        public string firstname { get; set; }

        public string surname { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var DirectorList = DB.director.ToList();
                foreach (Director p in DirectorList)
                {
                    if (p.id_director > Max) Max = p.id_director;
                }
                return (Max + 1);
            }
        }
    }
}
