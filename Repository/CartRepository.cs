using API_Part_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API_Part_Project.Repository
{
    public class CartRepository : ICartRepository
    {
        E_Commerce ctx;
        public CartRepository(E_Commerce context)
        {
            ctx = context;
        }
        public List<ProductsCart> GetAll()
        {
            List<ProductsCart> cartlist = ctx.cart.ToList();
            return cartlist;


        }
        
        public ProductsCart GetByID(int id)
        {
            ProductsCart cartobj = ctx.cart.FirstOrDefault(c => c.ProductID == id);
            return cartobj;


        }
        public int Insert(ProductsCart c)
        {
            ProductsCart p = new ProductsCart();
            if (c != null)
            {
                p.ProductName = c.ProductName;
                p.totalquantityofthisproduct = c.totalquantityofthisproduct;
                p.Unitprice = c.Unitprice;
                p.productcount = c.productcount;
                ctx.cart.Add(p);
                int raws = ctx.SaveChanges();
                return raws;

            }
            else
            {
                return 0;
            }
        }

        public int update(string name, ProductsCart c)
        {

            ProductsCart oldcartobj = ctx.cart.FirstOrDefault(c => c.ProductName == name);
            if (oldcartobj != null)
            {
                oldcartobj.ProductName = c.ProductName;
                oldcartobj.productcount = c.productcount;
                oldcartobj.totalquantityofthisproduct = c.totalquantityofthisproduct;
                oldcartobj.Unitprice = c.Unitprice;


                ctx.Entry(oldcartobj).State = EntityState.Modified;

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
            ctx.cart.Remove(GetByID(id));
            int raws = ctx.SaveChanges();
            return raws;



        }

        public int DeleteAll()
        {
            List<ProductsCart> cartlist = ctx.cart.ToList();
            foreach (var item in cartlist)
            { ctx.cart.Remove(GetByID(item.ProductID)); }
            int raws = ctx.SaveChanges();
            return raws;
        }
    }
}
