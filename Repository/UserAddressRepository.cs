using API_Part_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API_Part_Project.Repository
{
    public class UserAddressRepository : IUserAddressRepository
    {
        E_Commerce ctx;
        public UserAddressRepository(E_Commerce context)
        {
            ctx = context;
        }
        public List<Useraddress> GetAll()
        {
            List<Useraddress> catogrylist = ctx.userAddress.ToList();
            return catogrylist;


        }
        public Useraddress GetByID(int id)
        {
            Useraddress useruddress = ctx.userAddress.FirstOrDefault(c => c.id == id);
            return useruddress;


        }
        public int Insert(Useraddress userAddr)
        {
            if (userAddr != null)
            {
                ctx.userAddress.Add(userAddr);
                int raws = ctx.SaveChanges();
                return raws;

            }
            else
            {
                return 0;
            }
        }

        public int update(int id, Useraddress userAddr)
        {

            Useraddress olduserAddr = ctx.userAddress.FirstOrDefault(c => c.id == id);
            if (userAddr != null)
            {

                olduserAddr.city = userAddr.city;
                olduserAddr.street = userAddr.street;
                olduserAddr.postalcode = userAddr.postalcode;
                ctx.Entry(olduserAddr).State = EntityState.Modified;
                int raws = ctx.SaveChanges();
                return raws;

            }
            else
            {
                return 0;
            }


        }
        public int Delete(int id)
        {
            ctx.userAddress.Remove(GetByID(id));
            int raws = ctx.SaveChanges();
            return raws;



        }
    }
}
