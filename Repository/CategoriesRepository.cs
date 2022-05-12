using API_Part_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API_Part_Project.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        E_Commerce ctx;
        public CategoriesRepository(E_Commerce context)
        {
            ctx = context;
        }
        public List<Categories> GetAll()
        {
            List<Categories> catogrylist = ctx.categories.ToList();
            return catogrylist;


        }
        public List<Products> GetproductBycatID(int CateogryiD)
        {
            List<Products> producs = ctx.products.Where(p => p.CateogryiD == CateogryiD).ToList();
            return producs;
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
