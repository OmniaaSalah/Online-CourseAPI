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
    public class UserMobileController : ControllerBase
    {
        IUserMobileRepository IusermobileRepository;
        public UserMobileController(IUserMobileRepository usermobileRepos)
        {
            IusermobileRepository = usermobileRepos;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                List<Usermobile> catlist = IusermobileRepository.GetAll();

                return Ok(catlist);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("{id:int}", Name = "Getusermobbyid")]
        public IActionResult GetbyId(int id)
        {
            if (ModelState.IsValid)
            {
                Usermobile usermob = IusermobileRepository.GetByID(id);
                return Ok(usermob);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost]
        public IActionResult Insert(Usermobile um)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = IusermobileRepository.Insert(um);
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
        public IActionResult Update(int id, Usermobile um)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = IusermobileRepository.update(id, um);
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
                int effectedraws = IusermobileRepository.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
