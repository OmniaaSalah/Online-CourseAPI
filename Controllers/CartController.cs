using API_Part_Project.Models;
using API_Part_Project.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_Part_Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartRepository Icartrepository;
        
        public CartController(ICartRepository cartrepository)
        {
            Icartrepository = cartrepository;
     
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                List<ProductsCart> cartlist = Icartrepository.GetAll();
                return Ok(cartlist);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("{id:int}", Name = "GetbyId")]
        public IActionResult GetbyId(int id)
        {
            if (ModelState.IsValid)
            {
                ProductsCart cartobj = Icartrepository.GetByID(id);
                return Ok(cartobj);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

       


        [HttpPost]
        public IActionResult Insert(ProductsCart c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = Icartrepository.Insert(c);
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

        [HttpPut("{Name:alpha}")]
        public IActionResult Update(string Name, ProductsCart c)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = Icartrepository.update(Name, c);

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
                int effectedraws = Icartrepository.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public IActionResult DeleteAll()
        {
            if (ModelState.IsValid)
            {
                int effectedraws = Icartrepository.DeleteAll();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
