using API_Part_Project.Models;
using System.Collections.Generic;

namespace API_Part_Project.DTO
{
    public class RegisterDTO
    {
         
         public string name { get; set; }
         public string email { get; set; }
         public string password { get; set; }
         public string reachedBy { get; set; }
         public string reachedByOther { get; set; }

        public virtual Useraddress address { get; set; } = new Useraddress();
        /*public string city { get; set; }
         public string postalcode { get; set; }
         public string street { get; set; }*/

        //public List<Usermobile> mobileNo { get; set; } = new List<Usermobile>();
        public List<string> mobileNo { get; set; } = new List<string>();
    }
}
