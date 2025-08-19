using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodie.Shared.Models;

public class ORDER
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Total { get; set; }
    public string Status { get; set; } = "Pending";
    public virtual USERS User { get; set; } = null!;
    [ForeignKey(nameof(Models.ORDER_ITEMS.OrderId))]
    public virtual ICollection<ORDER_ITEMS> OrderItems { get; set; } = new List<ORDER_ITEMS>();
}
