using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;


namespace Pizzaria.API.Domain;

[Table("bairros")]
public class Bairro : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("value")]
    public decimal Value { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

}
