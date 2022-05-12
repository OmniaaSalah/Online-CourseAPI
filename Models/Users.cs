using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Part_Project.Models
{
    public class Users:IdentityUser
    {
        public string delivery { get; set; }
        public string deliverybyother { get; set; }
        //public List<string> MobileNos { get; set; } = new List<string>();
        public virtual List<Usermobile> MobileNos { get; set; } = new List<Usermobile>();
        [ForeignKey("Address")]
        public int addressiD { get; set; }
        public virtual Useraddress Address { get; set; } = new Useraddress();
        
      

        
  
}
}
