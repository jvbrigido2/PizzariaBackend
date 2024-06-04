using Pizzaria.API.Contracts;
using Pizzaria.API.Domain;
using Pizzaria.API.Repositories.Interface;

namespace Pizzaria.API.Repositories.Implementation;

public class BairroRepository : IBairroRepository
{
    private readonly Supabase.Client _supabase;

    public BairroRepository(Supabase.Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<Bairro?> CreateBairroAsync(Bairro bairro)
    {
        var result =  _supabase.From<Bairro>().Where(x => x.Name == bairro.Name).Single();
        var bairroExistente = result.Result;
        
        if (bairroExistente != null)
        {
            return null;
        }

        await _supabase.From<Bairro>().Insert(bairro);

        return bairro;
      
       
    }

    public async Task<Bairro?> DeleteBairroAsync(long id)
    {
        var result = _supabase.From<Bairro>().Where(x => x.Id == id).Single();
        var bairro = result.Result;
        if (bairro is null)
        {
            return null;
        }

        await _supabase.From<Bairro>().Delete(bairro);

        return bairro;

    }

    public async Task<Bairro?> GetBairroByNameAsync(string name)
    {
        var result = _supabase.From<Bairro>().Where(x => x.Name == name).Single();
        var bairro = result.Result;
        if(bairro is null)
        {
            return null;
        }
        return bairro;
    }
    public async Task<IEnumerable<Bairro>> GetBairrosAsync()
    {
        var result = await _supabase.From<Bairro>().Get();
        var bairros = result.Models;

        return bairros;
    }

    public async Task<Bairro?> UpdateBairroAsync(long id, Bairro bairro)
    {
        var result = _supabase.From<Bairro>().Where(x => x.Id == id).Single();

        var bairroExistente = result.Result;

        if (bairroExistente is null)
        {
            return null;
        }

        bairroExistente.Name = bairro.Name;
        bairroExistente.Value = bairro.Value;

        await bairroExistente.Update<Bairro>();

        return bairroExistente;
    }
}
