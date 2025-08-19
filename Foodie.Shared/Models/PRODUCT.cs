using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodie.Shared.Models;

public class PRODUCT
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public decimal Price { get; set; }
    
    public string Category { get; set; } = string.Empty;
    [ForeignKey(nameof(Models.ORDER_ITEMS.ProductId))]
    public virtual ICollection<ORDER_ITEMS> OrderItems { get; set; } = new List<ORDER_ITEMS>();//hashset
}
