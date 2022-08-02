using API_Part_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API_Part_Project.Repository
{
    public class CourseDateRepository : ICourseDateRepository
    {
        Online_Courses ctx;
        public CourseDateRepository(Online_Courses context)
        {
            ctx = context;
        }
        public List<Date> GetAll()
        {
            List<Date> dateslist = ctx.date.ToList();
            return dateslist;


        }
        public Date GetByID(int id)
        {
            Date dateobj = ctx.date.FirstOrDefault(c => c.id == id);
            return dateobj;


        }
        public int Insert(Date date)
        {
            if (date != null)
            {
                ctx.date.Add(date);
                int raws = ctx.SaveChanges();
                return raws;

            }
            else
            {
                return 0;
            }
        }

        public int update(int id, Date newdate)
        {

            Date olddate = ctx.date.FirstOrDefault(c => c.id == id);
            if (olddate != null)
            {

                olddate.Dayfrom = newdate.Dayfrom;
                olddate.Dayto = newdate.Dayto;
                olddate.Month = newdate.Month;
                olddate.Year = newdate.Year;
                ctx.Entry(olddate).State = EntityState.Modified;
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
            ctx.date.Remove(GetByID(id));
            int raws = ctx.SaveChanges();
            return raws;



        }
    }
}
