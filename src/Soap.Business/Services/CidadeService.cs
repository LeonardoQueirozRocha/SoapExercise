using Soap.Business.Interfaces;
using Soap.Business.Models;

namespace Soap.Business.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ISoapWebService _soapWebService;

        public CidadeService(ISoapWebService soapWebService) => _soapWebService = soapWebService;

        public async Task<Cidade> ProcurarCidadeAsync(string zipCode)
        {
            if (string.IsNullOrEmpty(zipCode)) throw new Exception("Zip code não informado.");

            return await _soapWebService.LookupCityAsync(zipCode);
        }
    }
}
