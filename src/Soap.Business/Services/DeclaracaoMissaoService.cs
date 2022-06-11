using Soap.Business.Interfaces;

namespace Soap.Business.Services
{
    public class DeclaracaoMissaoService : IDeclaracaoMissaoService
    {
        private readonly ISoapWebService _soapWebService;

        public DeclaracaoMissaoService(ISoapWebService soapWebService) => _soapWebService = soapWebService;

        public async Task<string> ObterDeclaracaoDeMissaoAsync() => await _soapWebService.MissionAsync();
    }
}
