using API_Part_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API_Part_Project.Repository
{
    public class UserMobileRepository : IUserMobileRepository
    {
        E_Commerce ctx;
        public UserMobileRepository(E_Commerce context)
        {
            ctx = context;
        }
        public List<Usermobile> GetAll()
        {
            List<Usermobile> UserMobilelist = ctx.userMobile.Include(c => c.user).ToList();
            return UserMobilelist;


        }
        public Usermobile GetByID(int id)
        {
            Usermobile useruddress = ctx.userMobile.Include(c => c.user).FirstOrDefault(c => c.id == id);
            return useruddress;


        }
        public int Insert(Usermobile usermob)
        {
            if (usermob != null)
            {
                ctx.userMobile.Add(usermob);
                int raws = ctx.SaveChanges();
                return raws;

            }
            else
            {
                return 0;
            }
        }

        public int update(int id, Usermobile usermob)
        {

            Usermobile oldusermob = ctx.userMobile.Include(c => c.user).FirstOrDefault(c => c.id == id);
            if (oldusermob != null)
            {

                oldusermob.MobileNo = usermob.MobileNo;
                oldusermob.userid = usermob.userid;
                oldusermob.user = usermob.user;
                ctx.Entry(oldusermob).State = EntityState.Modified;
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
            ctx.userMobile.Remove(GetByID(id));
            int raws = ctx.SaveChanges();
            return raws;



        }
    }
}
