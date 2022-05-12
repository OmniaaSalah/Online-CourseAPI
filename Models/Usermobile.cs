using System.ComponentModel.DataAnnotations.Schema;

namespace API_Part_Project.Models
{
    public class Usermobile
    {
        public int id { get; set; }

        public string MobileNo { get; set; }


        [ForeignKey("user")]
        public string userid { get; set; }
        public virtual Users user { get; set; }

    }
}
