using Pizzaria.API.Contracts;
using Pizzaria.API.Domain;

namespace Pizzaria.API.Repositories.Interface;

public interface IBairroRepository
{
    public Task<IEnumerable<Bairro>> GetBairrosAsync();

    public Task<Bairro?> CreateBairroAsync(Bairro bairro);

    public Task<Bairro?> GetBairroByNameAsync (string name);

    public Task<Bairro?> DeleteBairroAsync (long id);

    public Task<Bairro?> UpdateBairroAsync(long id, Bairro bairro);
}
