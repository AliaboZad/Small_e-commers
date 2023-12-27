using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Small_e_commers.DTO;
using Small_e_commers.Models;
using TestAPIAhmedElmohamdyCours.Data;

namespace Small_e_commers.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly AppDbContext _appDbContext;
        public OrderController(AppDbContext appDbContext)
        {
			_appDbContext = appDbContext;
        }

		[HttpGet]
		public async Task< IActionResult> GetAllOrders()
		{

			/// Lazy Loading
			/// 
			var order = _appDbContext.orders.Where(t => t.Id == 1)
				//.Include(x => x.orderitems)
				//.ThenInclude(c => c.items)
				.FirstOrDefault().orderitems
				.FirstOrDefault().items;


			///Eager Loading 
			//var order = _appDbContext.orders.Where(t => t.Id == 1)
			//	.Include(x => x.orderitems)
			//	.ThenInclude(c => c.items)
			//	.FirstOrDefault().orderitems
			//	.FirstOrDefault().items;



			return Ok(order);
		}

		[HttpPost]
		public async Task<IActionResult> PostOreder(Order order)
		{
			return Ok(order);
		}

		[HttpGet("getone")]
		public async Task<IActionResult> GetnoeorderbyID(int orderId)
		{
			var order = await _appDbContext.orders.Where(i => i.Id == orderId).FirstOrDefaultAsync();

			if (order != null)
			{
				OrderDTO orderDTO = new()
				{
					orderId = order.Id,
					orderDate = order.Creatdate,
				};
				if (order.orderitems!= null && order.orderitems.Any())
				{
					foreach(var item in order.orderitems)
					{
						OrederandItemDTO orederandItem = new()
						{
							itemId = item.items.Id,
							itemName = item.items.Name,
							Price = item.items.Price,
							quantity = 1
						};

						orderDTO.oredertandItem.Add(orederandItem);
					}
				}
				return Ok(orderDTO);
			}

			return NotFound($"the order Id {orderId} is not exist");
		}
	}
}
