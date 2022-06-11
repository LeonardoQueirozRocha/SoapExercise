using Microsoft.Extensions.DependencyInjection;
using Soap.Business.Interfaces;
using Soap.Business.Services;
using Soap.Data.WebService;

namespace Soap.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var cidadeService = serviceProvider.GetService<ICidadeService>();
            var pessoaService = serviceProvider.GetService<IPessoaService>();
            var missaoService = serviceProvider.GetService<IDeclaracaoMissaoService>();

            try
            {
                var pessoa = await pessoaService.ProcurarPessoaAync("50");
                Console.WriteLine("Nome: " + pessoa.Nome);
                Console.WriteLine("SSN: " + pessoa.Ssn);
                Console.WriteLine("Data de Nascimento: " + pessoa.DataNascimento);
                Console.WriteLine("Idade: " + pessoa.Idade);
                Console.WriteLine("Endereço residencial:");
                Console.WriteLine("Cidade: " + pessoa.Casa.Nome);
                Console.WriteLine("Estado: " + pessoa.Casa.Estado);
                Console.WriteLine("Zip code: " + pessoa.Casa.Zip);
                Console.WriteLine("Endereço do escritório:");
                Console.WriteLine("Cidade: " + pessoa.Escritorio.Nome);
                Console.WriteLine("Estado: " + pessoa.Escritorio.Estado);
                Console.WriteLine("Zip code: " + pessoa.Escritorio.Zip);
                Console.WriteLine("Cores favoritas: " + string.Join(", ", pessoa.CoresFavoritas));

                Console.WriteLine("\n-------------------------------\n");
                var cidade = await cidadeService.ProcurarCidadeAsync("10012");
                Console.WriteLine("Cidade: " + cidade.Nome);
                Console.WriteLine("Estado: " + cidade.Estado);
                Console.WriteLine("Zip code: " + cidade.Zip);

                Console.WriteLine("\n-------------------------------\n");
                var missao = await missaoService.ObterDeclaracaoDeMissaoAsync();
                Console.WriteLine("Missão: " + missao);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Houve um erro:\n");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICidadeService, CidadeService>()
                    .AddScoped<IPessoaService, PessoaService>()
                    .AddScoped<ISoapWebService, SoapWebService>()
                    .AddScoped<IDeclaracaoMissaoService, DeclaracaoMissaoService>();
        }
    }
}