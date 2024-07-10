using Microsoft.EntityFrameworkCore;
using WebAPIFornecedor.Data;
using WebAPIFornecedor.Models;
using WebAPIFornecedor.Repositories.Interfaces;

namespace WebAPIFornecedor.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly DBContext _dbContext;

        public FornecedorRepository(DBContext testeDBContext)
        {
            _dbContext = testeDBContext;
        }

        public async Task<List<Fornecedor>> BuscarTodosAsync()
        {
            return await _dbContext.Fornecedores.AsNoTracking().ToListAsync();
        }

        public async Task<Fornecedor> BuscarPorIdAsync(int id)
        {
            return await _dbContext.Fornecedores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Fornecedor> AdicionarAsync(Fornecedor fornecedor)
        {
            await _dbContext.Fornecedores.AddAsync(fornecedor);
            await _dbContext.SaveChangesAsync();

            return fornecedor;
        }

        public async Task<Fornecedor> AtualizarAsync(Fornecedor fornecedor, int id)
        {
            Fornecedor fornecedorRetorno = await BuscarPorIdAsync(id);

            if (fornecedorRetorno == null)
            {
                throw new Exception($"Fornecedor para o ID: {id} não foi encontrado.");
            }

            fornecedorRetorno.Nome = fornecedor.Nome;
            fornecedorRetorno.Email = fornecedor.Email;
            fornecedorRetorno.CNPJ = fornecedor.CNPJ;
            fornecedorRetorno.IE = fornecedor.IE;

            _dbContext.Update( fornecedorRetorno );
            await _dbContext.SaveChangesAsync();

            return fornecedorRetorno;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            Fornecedor fornecedorRetorno = await BuscarPorIdAsync(id);

            if (fornecedorRetorno == null)
            {
                throw new Exception($"Fornecedor para o ID: {id} não foi encontrado.");
            }

            _dbContext.Fornecedores.Remove( fornecedorRetorno );
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
