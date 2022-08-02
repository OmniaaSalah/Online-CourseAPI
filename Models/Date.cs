using System.ComponentModel.DataAnnotations;

namespace API_Part_Project.Models
{
    public class Date
    {
        [Key]
        public int id { get; set; }
       public int Dayto { get; set; }
        public int Dayfrom { get; set; }
        public string Month { get; set; }
       public int Year { get; set; }
    }
}
