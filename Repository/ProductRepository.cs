using API_Part_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API_Part_Project.Repository
{
    public class ProductRepository : IProductRepository
    {
        E_Commerce ctx;
        public ProductRepository(E_Commerce context)
        {
            ctx = context;
        }
        public List<Products> GetAll()
        {
            List<Products> catogrylist = ctx.products.Include(c => c.category).ToList();
            return catogrylist;


        }
        public Products GetByID(int id)
        {
            Products productobj = ctx.products.Include(c => c.category).FirstOrDefault(c => c.id == id);
            return productobj;


        }
        public int Insert(Products p)
        { 
            if (p != null)
            {
                ctx.products.Add(p);
                int raws = ctx.SaveChanges();
                return raws;

            }
            else
            {
                return 0;
            }
        }

        public int update(int id, Products p)
        {

            Products oldproductobj = ctx.products.Include(c => c.category).FirstOrDefault(c => c.id == id);
            if (oldproductobj != null)
            {
                oldproductobj.quantity = p.quantity;
                oldproductobj.img = p.img;
                oldproductobj.price = p.price;
                oldproductobj.name = p.name;
                oldproductobj.CateogryiD = p.CateogryiD;
            
                ctx.Entry(oldproductobj).State = EntityState.Modified;
               
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
            ctx.products.Remove(GetByID(id));
            int raws = ctx.SaveChanges();
            return raws;



        }
    }
}
