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
    public class UserAddressController : ControllerBase
    {

        IUserAddressRepository IuseraddressRepository;
        public UserAddressController(IUserAddressRepository useraddresRepos)
        {
            IuseraddressRepository = useraddresRepos;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                List<Useraddress> usersAddrlist = IuseraddressRepository.GetAll();

                return Ok(usersAddrlist);
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
                Useraddress useraddr = IuseraddressRepository.GetByID(id);
                return Ok(useraddr);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost]
        public IActionResult Insert(Useraddress ua)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = IuseraddressRepository.Insert(ua);
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
        public IActionResult Update(int id, Useraddress ua)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int effectedraws = IuseraddressRepository.update(id, ua);
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
                int effectedraws = IuseraddressRepository.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
