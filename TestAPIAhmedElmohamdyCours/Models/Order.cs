using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Small_e_commers.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Creatdate { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<OrderItem>? orderitems { get; set; }

    }
}
