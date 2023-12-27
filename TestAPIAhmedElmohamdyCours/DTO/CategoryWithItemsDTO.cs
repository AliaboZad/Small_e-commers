using TestAPIAhmedElmohamdyCours.Models;

namespace TestAPIAhmedElmohamdyCours.DTO
{
	public class CategoryWithItemsDTO
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public ICollection<itemDTO> itemdto { get; set; } = new List<itemDTO>();
	}

	public class itemDTO
	{
        public int itemId { get; set; }
        public string itemName { get; set; }
        public bool itemsStatus { get; set; }
    }
}
