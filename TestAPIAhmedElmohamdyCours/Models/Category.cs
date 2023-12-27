using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TestAPIAhmedElmohamdyCours.Models
{
	public class Category
	{
		[Key]
        public int Id { get; set; }
		public string Name { get; set; }
        public decimal Price { get; set; }
		public string Description { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
        public virtual ICollection<Items> items { get; set; } /* = new HashSet<Items>();*/

    }
}
