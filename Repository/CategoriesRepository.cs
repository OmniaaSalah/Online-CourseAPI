using API_Part_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API_Part_Project.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        Online_Courses ctx;
        public CategoriesRepository(Online_Courses context)
        {
            ctx = context;
        }
        public List<Categories> GetAll()
        {
            List<Categories> catogrylist = ctx.categories.ToList();
            return catogrylist;


        }
        public List<Courses> GetCoursesBycatID(int CateogryiD)
        {
            List<Courses> courses = ctx.courses.Include(c=>c.category).Include(d => d.date).Where(c => c.CateogryiD == CateogryiD).ToList();
            return courses;
        }
        public Categories GetByID(int id)
        {
            Categories catogryobj = ctx.categories.FirstOrDefault(c => c.id == id);
            return catogryobj;


        }
        public int Insert(Categories cat)
        {
            if (cat != null)
            {
                ctx.categories.Add(cat);
                int raws = ctx.SaveChanges();
                return raws;

            }
            else
            {
                return 0;
            }
        }

        public int update(int id, Categories cat)
        {

            Categories oldcatogryobj = ctx.categories.FirstOrDefault(c => c.id == id);
            if (oldcatogryobj != null)
            {

                oldcatogryobj.name = cat.name;
                ctx.Entry(oldcatogryobj).State = EntityState.Modified;
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
            ctx.categories.Remove(GetByID(id));
            int raws = ctx.SaveChanges();
            return raws;



        }
    }
}
