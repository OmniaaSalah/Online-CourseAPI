using API_Part_Project.Models;
using API_Part_Project.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_Part_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoriesRepository Icatogryrepository;
        public CategoriesController(ICategoriesRepository catogrepos)
        {
            Icatogryrepository = catogrepos;
        }
        [HttpGet]
        public IActionResult GetAll()
       {
            if (ModelState.IsValid)
            {
                List<Categories> catlist = Icatogryrepository.GetAll();

                return Ok(catlist);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("{id:int}", Name = "GetforGetbyIdcat")]
        public IActionResult GetbyId(int id)
        {
            if (ModelState.IsValid)
            {
                Categories catobj = Icatogryrepository.GetByID(id);
                return Ok(catobj);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost]
        public IActionResult Insert(Categories c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = Icatogryrepository.Insert(c);
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
        public IActionResult Update(int id, Categories c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = Icatogryrepository.update(id, c);
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
                int effectedraws = Icatogryrepository.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
