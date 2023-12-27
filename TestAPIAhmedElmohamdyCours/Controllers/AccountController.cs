using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Small_e_commers.Data;
using Small_e_commers.DTO;

namespace Small_e_commers.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
        private readonly UserManager<AppUserDbContext> _user;
        public AccountController( UserManager<AppUserDbContext> user  )
        {
            _user = user;
        }

        [HttpPost]
        public  async Task<IActionResult> Register (RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                AppUserDbContext newuser = new AppUserDbContext
                {
                    UserName = registerDTO.UserName,
                    Email = registerDTO.Email,
                };

                IdentityResult result = await _user.CreateAsync(newuser, registerDTO.Passward);
                if (result.Succeeded)
                {
                    return Ok("Success");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            
            return BadRequest(ModelState);
        }
    }
}
