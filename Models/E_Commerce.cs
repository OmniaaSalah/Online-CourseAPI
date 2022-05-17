using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API_Part_Project.Models
{
    public class E_Commerce:IdentityDbContext<Users>
    {
     
        public DbSet<Categories> categories { get; set; }
        public DbSet<ProductsCart> cart{ get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Useraddress> userAddress { get; set; }
        public DbSet<Usermobile> userMobile { get; set; }
        public E_Commerce() : base()
        { }
        public E_Commerce(DbContextOptions options) : base(options)
        {

        }
    }
}
