using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Part_Project.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
       
        public int quantity { get; set; }
        public int price { get; set; }

        public string img { get; set; }

        [ForeignKey("category")]
        public int CateogryiD { get; set; }
        public virtual Categories category { get; set; }

        


    }
}
