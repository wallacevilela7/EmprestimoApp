using Microsoft.EntityFrameworkCore;


namespace EmprestimoApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmprestimosModel> Emprestimos {get;set;}
    }
}