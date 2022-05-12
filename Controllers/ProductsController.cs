using API_Part_Project.Models;
using API_Part_Project.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_Part_Project.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductRepository Iproductrepository;
        ICategoriesRepository Icategoriesrepository;
        public ProductsController(IProductRepository productrepos, ICategoriesRepository categoriesrepository)
        {
            Iproductrepository = productrepos;
            Icategoriesrepository = categoriesrepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                List<Products> prolist = Iproductrepository.GetAll();
                return Ok(prolist);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("{id:int}", Name = "GetforGetbyId")]
        public IActionResult GetbyId(int id)
        {
            if (ModelState.IsValid)
            {
                Products proobj = Iproductrepository.GetByID(id);
                return Ok(proobj);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{CateogryiD:int}")]
        public IActionResult GetbycatId(int CateogryiD)
        {
            if (ModelState.IsValid)
            {
                List<Products> products = Icategoriesrepository.GetproductBycatID(CateogryiD);
                return Ok(products);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPost]
        public IActionResult Insert(Products p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = Iproductrepository.Insert(p);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Products p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = Iproductrepository.update(id, p);
                    
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
       [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                int effectedraws = Iproductrepository.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
