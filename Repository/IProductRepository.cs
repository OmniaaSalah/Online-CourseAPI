using API_Part_Project.Models;
using System.Collections.Generic;

namespace API_Part_Project.Repository
{
    public interface IProductRepository
    {
        int Delete(int id);
        List<Products> GetAll();
        Products GetByID(int id);
        int Insert(Products p);
        int update(int id, Products p);
    }
}