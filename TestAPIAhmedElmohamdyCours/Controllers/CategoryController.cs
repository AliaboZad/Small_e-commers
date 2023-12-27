using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPIAhmedElmohamdyCours.Data;
using TestAPIAhmedElmohamdyCours.DTO;
using TestAPIAhmedElmohamdyCours.Models;

namespace TestAPIAhmedElmohamdyCours.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly AppDbContext _db;
		public CategoryController (AppDbContext db)
		{
			_db = db;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var categories = await _db.category.ToListAsync();
			return Ok(categories);
		}

		[HttpPost]
		public async Task<IActionResult> Addcate(Category categ)
		{
			var cate = new Category
			{
				Id = categ.Id,
				Name = categ.Name,
				Price = categ.Price,
				Description = categ.Description

			};
			
			await _db.category.AddAsync(cate);
			await _db.SaveChangesAsync();
			return Ok(cate); 
			//return BadRequest($"cate {categ} is Not exsist");
		}

		[HttpGet("GetbyId")]
		public async Task<IActionResult> GetbyId(int catId)
		{
			var category = await _db.category.Where(c => c.Id == catId).FirstOrDefaultAsync();

			if (category != null)
			{
				CategoryWithItemsDTO categoryDTO = new()
				{
					Name = category.Name,
					Price = category.Price,
				};

				if (category.items != null && category.items.Any())
				{
					foreach (var item in category.items)
					{
						itemDTO itemdtoss = new()
						{
							itemName = item.Name,
							itemId = item.Id,
							itemsStatus = item.isActive
						};

						categoryDTO.itemdto.Add(itemdtoss);
					}
				}
				return Ok(categoryDTO);
			}

			return BadRequest($"the Category Id {catId} is not exist");
		}

	}
}
