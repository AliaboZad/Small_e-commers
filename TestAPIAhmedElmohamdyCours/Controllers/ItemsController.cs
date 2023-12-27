using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Small_e_commers.Hubs;
using TestAPIAhmedElmohamdyCours.Data;
using TestAPIAhmedElmohamdyCours.DTO;
using TestAPIAhmedElmohamdyCours.Migrations;
using TestAPIAhmedElmohamdyCours.Models;

namespace TestAPIAhmedElmohamdyCours.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemsController : ControllerBase
	{
        private readonly IHubContext<ItemHub> _hubContext;
        private readonly AppDbContext _db;
        public ItemsController( AppDbContext db , IHubContext<ItemHub> hubContext)
        {
            _db = db;
            _hubContext = hubContext;
        }


        [HttpGet("getbyoneid")]
        public async Task<IActionResult> Getoneitem (int id)
        {
            var item = await _db.items.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                ItemwithCatagoryDTO dTO = new()
                {
                    
                    Name = item.Name,
                    Price = item.Price,
                    Notes = item.Notes,
                    CategoryId = item.categoryId
                };
                return Ok(dTO);

            }

			return NotFound($"item number {id} not exist");
		}
		[HttpGet("GetByCat")]
		public async Task<IActionResult> GetAllItemByCategory(int id)
		{
			var item = await _db.items.SingleOrDefaultAsync(x => x.categoryId == id);
			if (item == null)
				return NotFound($"Category ID {id} has no items");

			return Ok(item);
		}

		[HttpPost]
        public async Task<IActionResult> Additem(ItemwithCatagoryDTO itemwithCatagoryDTO)
        {
            //using var stream = new MemoryStream();
            //await itemwithCatagoryDTO.Image.CopyToAsync(stream);

            //to chick the category ID 
            var chickID = await _db.category.AnyAsync(x => x.Id == itemwithCatagoryDTO.CategoryId);

            var item = new Items
            {
                Name = itemwithCatagoryDTO.Name,
                Price = itemwithCatagoryDTO.Price,
                Notes = itemwithCatagoryDTO.Notes,
                categoryId = itemwithCatagoryDTO.CategoryId,
                //Image = stream.ToArray()
            };

            await _db.items.AddAsync(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]

        public async Task< IActionResult> Deleteitem(int id)
        {
            var item = await _db.items.SingleOrDefaultAsync(item => item.Id == id);

            if (item == null)
                return NotFound($"item id {id} not exsist");

            _db.Remove(item);
            await _db.SaveChangesAsync();
            return Ok(item);

        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromForm] ItemwithCatagoryDTO itemsDTO)
        {
            var i = await _db.items.FindAsync(id);

            if (i == null) return NotFound($"Item ID {id} not exsist");

            //To chick the Category ID
           var chickID = await _db.category.AnyAsync(x => x.Id == itemsDTO.CategoryId);
            if (chickID)
                return NotFound($"Category ID {id} not exsist");


   //         if (itemsDTO.Image != null)
   //         {
			//	using var stream = new MemoryStream();
			//	await itemsDTO.Image.CopyToAsync(stream);
   //             i.Image = stream.ToArray();
			//}

            i.Name = itemsDTO.Name;
            i.Price = itemsDTO.Price;
            i.Notes = itemsDTO.Notes;
            i.categoryId = itemsDTO.CategoryId;

            await _db.SaveChangesAsync();

            return Ok(i);
        }

        

    }
}
