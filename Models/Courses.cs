using System.ComponentModel.DataAnnotations.Schema;

namespace API_Part_Project.Models
{
    public class Courses
    {
        public int id { get; set; }
      public string Name { get; set; }
    public string Type { get; set; }
    public string img { get; set; }
    public string Description { get; set; }
    public int oldprice { get; set; }
    public int newprice { get; set; }

    [ForeignKey("date")]
    public int dateiD { get; set; }
    public virtual Date date { get; set; } 
    public int rate { get; set; }

    [ForeignKey("category")]
     public int CateogryiD { get; set; }
     public virtual Categories category { get; set; }

    }
}
