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
    public class CourseDateController : ControllerBase
    {

        ICourseDateRepository iCourseDateRepository;
        public CourseDateController(ICourseDateRepository coursedateRepos)
        {
            iCourseDateRepository = coursedateRepos;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                List<Date> coursedateslist = iCourseDateRepository.GetAll();

                return Ok(coursedateslist);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("{id:int}", Name = "Getuseraddrbyid")]
        public IActionResult GetbyId(int id)
        {
            if (ModelState.IsValid)
            {
                Date useraddr = iCourseDateRepository.GetByID(id);
                return Ok(useraddr);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost]
        public IActionResult Insert(Date d)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = iCourseDateRepository.Insert(d);
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
        public IActionResult Update(int id, Date d)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = iCourseDateRepository.update(id, d);
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
                int effectedraws = iCourseDateRepository.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
