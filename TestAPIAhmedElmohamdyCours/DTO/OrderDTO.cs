using Castle.Components.DictionaryAdapter;

namespace Small_e_commers.DTO
{
	public class OrderDTO
	{
        
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }
        public ICollection<OrederandItemDTO> oredertandItem { get; set; } = new List<OrederandItemDTO>();
    }

    public class OrederandItemDTO
    {
        public int itemId { get; set; }
        public string? itemName { get; set; }
        public decimal Price { get; set; }
        public int quantity { get; set; }


    }
}
