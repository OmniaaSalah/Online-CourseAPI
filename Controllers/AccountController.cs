using API_Part_Project.DTO;
using API_Part_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_Part_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Users> userManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> rolemanger;
        

        public AccountController(UserManager<Users> userManager, IConfiguration Configuration, RoleManager<IdentityRole> _rolemanger)
        {
            this.userManager = userManager;
            configuration = Configuration;
            rolemanger = _rolemanger;
        }
     
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDto)
        { var i = 0;
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            Users user = new Users();
            
            user.UserName = registerDto.name;
            user.delivery = registerDto.reachedBy;
            user.deliverybyother = registerDto.reachedByOther;
            foreach (var item in registerDto.mobileNo)
            { user.MobileNos.Add(new Usermobile { id=i++,MobileNo = item }); }
            user.Address.city = registerDto.address.city;
            user.Address.street = registerDto.address.street;
            user.Address.postalcode = registerDto.address.postalcode;
            user.Email = registerDto.email;
           
            IdentityResult result = await userManager.CreateAsync(user, registerDto.password);
            if (result.Succeeded)
            {


                return Ok();

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            Users user = await userManager.FindByNameAsync(loginDto.UserName);
            if(user!=null)
            {
                if (await userManager.CheckPasswordAsync(user,loginDto.password) == true)
                {
                    //toke base on Claims "Name &Roles &id " +Jti ==>unique Key Token "String"
                    var mytoken = await GenerateToke(user);
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                        expiration = mytoken.ValidTo
                    });
                }
                else
                {
                    
                    return Unauthorized();
                }
            }
            return Unauthorized();
        }

        [NonAction]
        public async Task<JwtSecurityToken> GenerateToke(Users userModel)
        {
            var claims = new List<Claim>();
            
            claims.Add(new Claim(ClaimTypes.Name, userModel.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userModel.Id));
            var roles = await userManager.GetRolesAsync(userModel);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            //Jti "Identifier Token
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            //---------------------------------(: Token :)--------------------------------------
            var key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecrtKey"]));
            var mytoken = new JwtSecurityToken(
                audience: configuration["JWT:ValidAudience"],
                issuer: configuration["JWT:ValidIssuer"],
                expires: DateTime.Now.AddHours(9),
                claims: claims,
                signingCredentials:
                       new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            return mytoken;
        }


        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin(RegisterDTO registerDto)
        {
            
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            Users user = new Users();

            user.UserName = registerDto.name;
            user.delivery = registerDto.reachedBy;
            user.deliverybyother = registerDto.reachedByOther;
            foreach (var item in registerDto.mobileNo)
            { user.MobileNos.Add(new Usermobile { MobileNo = item }); }
            user.Address.city = registerDto.address.city;
            user.Address.street = registerDto.address.street;
            user.Address.postalcode = registerDto.address.postalcode;
            user.Email = registerDto.email;
            
            IdentityResult result = await userManager.CreateAsync(user, registerDto.password);
            if (result.Succeeded)
            {
                var roles = await userManager.AddToRoleAsync(user, "Admin");
               
                if (roles.Succeeded)
                {
                    
                    return Ok();
                }
                else
                {
                    foreach (var item in roles.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return BadRequest(ModelState);
                }


            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost("createrole")]
        public async Task<IActionResult> createrole(string role)
        {
            if(role !=null)
            {
                IdentityRole r = new IdentityRole();
                r.Name = role;
                IdentityResult res = await rolemanger.CreateAsync(r);
                if(res.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    foreach (var item in res.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return BadRequest(ModelState);
                }

            }
            else
            {
                
                return BadRequest(ModelState);
            }
        }

        [HttpGet("Admins")]
        public async Task< IActionResult> GetAlladmin()
        {
           
           List<Users> Admins = new List<Users>();
           var users = userManager.Users.ToList();
            if (users.Count != 0)
            { foreach (var user in users)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        if (role == "Admin")
                        {
                            
                            Admins.Add(user);
                        }
                    }
                }
                
                return Ok(Admins);
            }
           
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
