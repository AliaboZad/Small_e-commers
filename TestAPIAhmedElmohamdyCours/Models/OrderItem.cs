using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TestAPIAhmedElmohamdyCours.Models;

namespace Small_e_commers.Models
{
	public class OrderItem
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey(nameof(order))]
        public int OrderId { get; set; }
		[JsonIgnore]
		[IgnoreDataMember]
        public virtual Order? order { get; set; }
		[ForeignKey(nameof(items))]
		public int ItemId { get; set; }
		[JsonIgnore]
		[IgnoreDataMember]
		public virtual Items? items { get; set; }
		[Required]
        public decimal Price { get; set; }


    }
}
