using Soap.Business.Models;

namespace Soap.Business.Interfaces
{
    public interface ISoapWebService
    {
        Task<Pessoa> FindPersonAsync(string id);
        Task<Cidade> LookupCityAsync(string zipCode);
        Task<string> MissionAsync();
    }
}
