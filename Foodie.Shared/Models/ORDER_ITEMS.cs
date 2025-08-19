using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodie.Shared.Models;

public class ORDER_ITEMS
{
    [Key]
    public int OrderId { get; set; }
    
    [Key]
    public int ProductId { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal Price { get; set; }
    
    public virtual ORDER Order { get; set; } = null!;
    
    public virtual PRODUCT Product { get; set; } = null!;
}
