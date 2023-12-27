using System.ComponentModel.DataAnnotations;

namespace TestAPIAhmedElmohamdyCours.DTO
{
	public class ItemwithCatagoryDTO
	{
		[MaxLength(150)]
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string? Notes { get; set; }
		//public IFormFile Image { get; set; }
		public int CategoryId { get; set; }
	}
}
