using Microsoft.EntityFrameworkCore;

namespace CadastroGastos.Models
{
    public class BancoDeDados : DbContext
    {

        public DbSet<Contas> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=Contas;Integrated Security=True;");
        }
    }
}
