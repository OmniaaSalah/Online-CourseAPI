using API_Part_Project.Models;
using System.Collections.Generic;

namespace API_Part_Project.Repository
{
    public interface ICoursesRepository
    {
        int Delete(int id);
        List<Courses> GetAll();
        Courses GetByID(int id);
        int Insert(Courses c);
        int update(int id, Courses c);
    }
}