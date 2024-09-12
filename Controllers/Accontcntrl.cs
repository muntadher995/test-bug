using FinanceProject.Dtos.Accont;
using FinanceProject.Interfaces;
using FinanceProject.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

namespace FinanceProject.Controllers
{
    [Route("api/account")]
    [ApiController]

    public class Accontcntrl : ControllerBase
    {
        private readonly UserManager<Users> _usermanager;

        private readonly ITokenService _tokenservice;
        private readonly SignInManager<Users> _signinmanager;


        public Accontcntrl(UserManager<Users>usermanager,ITokenService tokenService,SignInManager<Users>signinmanager)


        {
            _usermanager = usermanager;

            _tokenservice = tokenService;

            _signinmanager = signinmanager;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = _usermanager.Users.ToList(); // Retrieve all users

            if (users == null || !users.Any())
            {
                return NoContent(); // 204 No Content if no users found
            }

      


            return Ok(users); // Return 200 OK with the list of users
        }




        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterDto registerdto)
        {

            try
            {
                if (!ModelState.IsValid)

                    return BadRequest(ModelState);


                var appUser = new Users

                {
                    UserName = registerdto.Username,

                    Email = registerdto.Email


                };
                var createUser = await _usermanager.CreateAsync(appUser, registerdto.Password);

                if(createUser.Succeeded)
                {

                    var roleresult = await _usermanager.AddToRoleAsync(appUser, "Admin");

                    if (roleresult.Succeeded)
                    {
                        return Ok(

                            new NewUserDto
                            {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = _tokenservice.CreateToken(appUser)
                            }
                            
                            );
                    }
                    
                    else

                    {
                        return StatusCode(500, roleresult.Errors);

                    }


                }
                else

                {
                    return StatusCode(500, createUser.Errors);



                }


            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);

            }


        }


        [HttpPost("login")]

        public async Task <IActionResult> Login  (LoginDto logindto)

        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var user = await _usermanager.Users.FirstOrDefaultAsync(u => u.UserName == logindto.Username.ToLower());

           

            if (user == null) return Unauthorized("invalid username");

            var result = await _signinmanager.CheckPasswordSignInAsync(user, logindto.Password, false);

            if (!result.Succeeded)

                return Unauthorized("username not found or password incorrect");
          

            return Ok(
                
                new NewUserDto
                {
                    UserName=user.UserName,

                    Email = user.Email,

                    Token= _tokenservice.CreateToken(user)
                }
                 

                );
            

        }


    }
}

 

