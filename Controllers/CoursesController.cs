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
    public class CoursesController : ControllerBase
    {
        ICoursesRepository iCoursesRepository;
        ICategoriesRepository icategoriesrepository;
        public CoursesController(ICoursesRepository courserepos, ICategoriesRepository categoriesrepository)
        {
            iCoursesRepository = courserepos;
            icategoriesrepository = categoriesrepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                List<Courses> crslist = iCoursesRepository.GetAll();
                return Ok(crslist);
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
                Courses crsobj = iCoursesRepository.GetByID(id);
                return Ok(crsobj);
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
                List<Courses> courses = icategoriesrepository.GetCoursesBycatID(CateogryiD);
                return Ok(courses);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPost]
        public IActionResult Insert(Courses c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = iCoursesRepository.Insert(c);
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
        public IActionResult Update(int id, Courses c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = iCoursesRepository.update(id, c);
                    
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
                int effectedraws = iCoursesRepository.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
