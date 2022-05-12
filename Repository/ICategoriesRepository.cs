using API_Part_Project.Models;
using System.Collections.Generic;

namespace API_Part_Project.Repository
{
    public interface ICategoriesRepository
    {
        int Delete(int id);
        List<Categories> GetAll();
        Categories GetByID(int id);
        List<Products> GetproductBycatID(int CateogryiD);
        int Insert(Categories cat);
        int update(int id, Categories cat);
    }
}