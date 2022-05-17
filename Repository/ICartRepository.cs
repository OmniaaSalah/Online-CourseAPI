using API_Part_Project.Models;
using System.Collections.Generic;

namespace API_Part_Project.Repository
{
    public interface ICartRepository
    {
        int Delete(int id);
        int DeleteAll();
        List<ProductsCart> GetAll();
        ProductsCart GetByID(int id);
        int Insert(ProductsCart c);
        int update(string name, ProductsCart c);
    }
}