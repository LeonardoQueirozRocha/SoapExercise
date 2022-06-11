using Soap.Business.Models;

namespace Soap.Business.Interfaces
{
    public interface ICidadeService
    {
        Task<Cidade> ProcurarCidadeAsync(string zipCode);
    }
}
