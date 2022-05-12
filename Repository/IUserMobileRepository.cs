using API_Part_Project.Models;
using System.Collections.Generic;

namespace API_Part_Project.Repository
{
    public interface IUserMobileRepository
    {
        int Delete(int id);
        List<Usermobile> GetAll();
        Usermobile GetByID(int id);
        int Insert(Usermobile usermob);
        int update(int id, Usermobile usermob);
    }
}