using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodie.Shared.Models;

public class USERS
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public string IdNo { get; set; } = string.Empty;
    [ForeignKey(nameof(Models.ORDER.UserId))]
    public virtual ICollection<ORDER> Orders { get; set; } = new List<ORDER>();
}
