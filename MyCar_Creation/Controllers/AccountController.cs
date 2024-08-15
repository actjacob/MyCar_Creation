using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCar_Creation.Context;
using MyCar_Creation.Dtos;
using MyCar_Creation.Entities;

namespace MyCar_Creation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost("Register")]
        public ActionResult Register(RegisterRequestDTO model)
        {
            User user = new()
            {
                Email = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword

            };

            _context.Users.Add(user);
            if(_context.SaveChanges()>0)
            {
                return Ok(model);
            }
            return BadRequest(model);

        }

        [HttpPost("CheckIsTrueUser")]
        public ActionResult CheckTrueAdmin(LoginRequestDTO model)
        {
            User user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user != null && user.Password == model.Password )
            { 

                if(user.Role == Roles.Admin.ToString())
                {

                }
                return Ok(true);
            }
            return Ok(false);

        }
    }
}
