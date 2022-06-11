using Soap.Business.Models;

namespace Soap.Business.Interfaces
{
    public interface IPessoaService
    {
        Task<Pessoa> ProcurarPessoaAync(string id);
    }
}
