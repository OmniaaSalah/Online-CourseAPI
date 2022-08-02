using API_Part_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API_Part_Project.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        Online_Courses ctx;
        public CoursesRepository(Online_Courses context)
        {
            ctx = context;
        }
        public List<Courses> GetAll()
        {
            List<Courses> courseslist = ctx.courses.Include(c => c.category).Include(d=>d.date).ToList();
            return courseslist;


        }
        public Courses GetByID(int id)
        {
            Courses courseobj = ctx.courses.Include(c => c.category).Include(d => d.date).FirstOrDefault(c => c.id == id);
            return courseobj;


        }
        public int Insert(Courses c)
        {
            if (c != null)
            {
                ctx.courses.Add(c);
                int raws = ctx.SaveChanges();
                return raws;

            }
            else
            {
                return 0;
            }
        }

        public int update(int id, Courses c)
        {

            Courses oldcourseobj = ctx.courses.Include(c => c.category).Include(d => d.date).FirstOrDefault(c => c.id == id);
            if (oldcourseobj != null)
            {
                oldcourseobj.Name = c.Name;
                oldcourseobj.img = c.img;
                oldcourseobj.oldprice = c.oldprice;
                oldcourseobj.newprice = c.newprice;
                oldcourseobj.CateogryiD = c.CateogryiD;
                oldcourseobj.Description = c.Description;
                oldcourseobj.date.Dayfrom = c.date.Dayfrom;
                oldcourseobj.date.Dayto = c.date.Dayto;
                oldcourseobj.date.Month = c.date.Month;
                oldcourseobj.date.Year = c.date.Year;
                ctx.Entry(oldcourseobj).State = EntityState.Modified;

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
            ctx.courses.Remove(GetByID(id));
            int raws = ctx.SaveChanges();
            return raws;



        }
    }
}
