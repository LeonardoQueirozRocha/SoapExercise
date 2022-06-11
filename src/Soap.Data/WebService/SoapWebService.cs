using Soap.Business.Interfaces;
using Soap.Business.Models;
using Soap.Data.Mappings;
using SoapServiceReference;

namespace Soap.Data.WebService
{
    public class SoapWebService : ISoapWebService
    {
        public async Task<Pessoa> FindPersonAsync(string id)
        {
            var client = new SOAPDemoSoapClient();

            var res = await client.FindPersonAsync(id);

            if (res == null) throw new Exception($"Não possível encontrar a pessoa com o id {id}.");

            await client.CloseAsync();

            return WebServiceMapper.PessoaMap(res);
        }
        public async Task<Cidade> LookupCityAsync(string zipCode)
        {
            var client = new SOAPDemoSoapClient();

            var res = await client.LookupCityAsync(zipCode);

            if (res == null) throw new Exception($"Não possível encontrar a cidade com o zip code {zipCode}.");

            await client.CloseAsync();

            return WebServiceMapper.CidadeMap(res);
        }

        public async Task<string> MissionAsync()
        {
            var client = new SOAPDemoSoapClient();

            var res = await client.MissionAsync();

            if (res == null) throw new Exception("Não foi retornada nenhuma declaração de missão.");

            await client.CloseAsync();

            return res;
        }
    }
}
