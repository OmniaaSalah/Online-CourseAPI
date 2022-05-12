using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Part_Project.Models
{
    public class Categories
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
       // public virtual ICollection<Products> products { get; set; }
    }
}
