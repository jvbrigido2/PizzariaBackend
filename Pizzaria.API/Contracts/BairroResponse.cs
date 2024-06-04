using Pizzaria.API.Domain;

namespace Pizzaria.API.Contracts;

public class BairroResponse
{
    public long Id { get; set; }
   
    public string Name { get; set; }
  
    public decimal Value { get; set; }

    public DateTime CreatedAt { get; set; }

    public BairroResponse(Bairro bairro)
    {
        Id = bairro.Id;
        Name = bairro.Name;
        Value = bairro.Value;
        CreatedAt = bairro.CreatedAt;
    }

}
