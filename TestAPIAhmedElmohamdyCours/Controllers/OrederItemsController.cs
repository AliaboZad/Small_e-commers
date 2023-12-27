using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPIAhmedElmohamdyCours.Data;

namespace Small_e_commers.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrederItemsController : ControllerBase
	{
        private readonly AppDbContext _appDbContext;
        public OrederItemsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrIt()
        {
			var orderItems = await _appDbContext.orderItems.ToListAsync();
			return Ok(orderItems);
		}
    }

}
