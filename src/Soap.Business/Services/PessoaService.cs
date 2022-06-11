using Soap.Business.Interfaces;
using Soap.Business.Models;

namespace Soap.Business.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly ISoapWebService _soapWebService;

        public PessoaService(ISoapWebService soapWebService) => _soapWebService = soapWebService;

        public async Task<Pessoa> ProcurarPessoaAync(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new Exception("Id não informado.");

            return await _soapWebService.FindPersonAsync(id);
        }
    }
}
