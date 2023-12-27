using Small_e_commers.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TestAPIAhmedElmohamdyCours.Models
{
	public class Items
	{
        [Key]
        public int Id { get; set; }
		public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Notes { get; set; }
        public byte[]? Image { get; set; }
        public bool isActive { get; set; }

        [ForeignKey(nameof(category))]
        public int categoryId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Category? category { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public virtual ICollection<OrderItem> OrderItems { get; set; }


    }
}
