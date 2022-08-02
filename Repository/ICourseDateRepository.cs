using API_Part_Project.Models;
using System.Collections.Generic;

namespace API_Part_Project.Repository
{
    public interface ICourseDateRepository
    {
        int Delete(int id);
        List<Date> GetAll();
        Date GetByID(int id);
        int Insert(Date date);
        int update(int id, Date newdate);
    }
}