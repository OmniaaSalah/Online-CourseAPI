using API_Part_Project.Models;
using System.Collections.Generic;

namespace API_Part_Project.Repository
{
    public interface IUserAddressRepository
    {
        int Delete(int id);
        List<Useraddress> GetAll();
        Useraddress GetByID(int id);
        int Insert(Useraddress userAddr);
        int update(int id, Useraddress userAddr);
    }
}