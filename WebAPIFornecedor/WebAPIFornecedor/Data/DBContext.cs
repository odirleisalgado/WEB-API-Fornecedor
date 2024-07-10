using Microsoft.EntityFrameworkCore;
using WebAPIFornecedor.Map;
using WebAPIFornecedor.Models;

namespace WebAPIFornecedor.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

