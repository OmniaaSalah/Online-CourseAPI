using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Part_Project.Models
{
    public class Useraddress
    {
        [Key]
        public int id { get; set; }
        public string city { get; set; }
        public string postalcode { get; set; }
        public string street { get; set; }
       
    }
}
