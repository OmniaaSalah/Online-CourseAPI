using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API_Part_Project.Models
{
    public class Online_Courses:DbContext
    {
     
        public DbSet<Categories> categories { get; set; }
        public DbSet<Date> date{ get; set; }
        public DbSet<Courses> courses{ get; set; }
  
        public Online_Courses() : base()
        { }
        public Online_Courses(DbContextOptions options) : base(options)
        {

        }
    }
}
