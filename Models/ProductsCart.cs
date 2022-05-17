using System.ComponentModel.DataAnnotations;

namespace API_Part_Project.Models
{
    public class ProductsCart
    {
        
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public int productcount { get; set; }
        public int Unitprice { get; set; }

        public int totalquantityofthisproduct { get; set; }

   
    }
}
