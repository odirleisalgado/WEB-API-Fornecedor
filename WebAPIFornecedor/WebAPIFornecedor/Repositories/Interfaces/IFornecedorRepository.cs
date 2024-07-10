using WebAPIFornecedor.Models;

namespace WebAPIFornecedor.Repositories.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<List<Fornecedor>> BuscarTodosAsync();
        Task<Fornecedor> BuscarPorIdAsync(int Id);
        Task<Fornecedor> AdicionarAsync(Fornecedor fornecedor);
        Task<Fornecedor> AtualizarAsync(Fornecedor fornecedor, int id);
        Task<bool> RemoverAsync(int id);
    }
}
