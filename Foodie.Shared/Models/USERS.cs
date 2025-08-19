using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Foodie.Shared.Models;

public class USERS
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;
    
    [JsonPropertyName("idNo")]
    public string IdNo { get; set; } = string.Empty;
    
    [JsonPropertyName("orders")]
    public virtual ICollection<ORDER> Orders { get; set; } = new List<ORDER>();
}
