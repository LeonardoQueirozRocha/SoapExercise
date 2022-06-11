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
                Console.WriteLine(pessoa.Nome);
                Console.WriteLine(pessoa.Ssn);
                Console.WriteLine(pessoa.DataNascimento);
                Console.WriteLine(pessoa.Idade);
                Console.WriteLine(pessoa.Casa.Nome);
                Console.WriteLine(pessoa.Casa.Estado);
                Console.WriteLine(pessoa.Casa.Zip);
                Console.WriteLine(pessoa.Escritorio.Nome);
                Console.WriteLine(pessoa.Escritorio.Estado);
                Console.WriteLine(pessoa.Escritorio.Zip);
                Console.WriteLine(string.Join(", ", pessoa.CoresFavoritas));

                Console.WriteLine("\n-------------------------------\n");
                var cidade = await cidadeService.ProcurarCidadeAsync("10012");
                Console.WriteLine(cidade.Nome);
                Console.WriteLine(cidade.Estado);
                Console.WriteLine(cidade.Zip);

                Console.WriteLine("\n-------------------------------\n");
                var missao = await missaoService.ObterDeclaracaoDeMissaoAsync();
                Console.WriteLine(missao);
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