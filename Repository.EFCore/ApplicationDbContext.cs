using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Repository.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        DbSet<Product> Products {  get; set; }
        DbSet<Category> Category {  get; set; }
        DbSet<Estatu> Estatus { get; set; }
    }

    //Esta clase la agregamos para ejecutar las migraciones de Entity Framework Core
    /// <summary>
    /// 1. Instalar Microsoft.EntityFrameworkCore.Tools y Microsoft.EntityFrameworkCore.SqlServer
    /// 2. Add-Migration NombreDeLaMigración -s Repository.EFCore -p Repository.EFCore -c ApplicationDbcontext -o Data\Migrations
    /// 3. Update-Database -s Repository.EFCore -p Repository.EFCore
    /// </summary>
    public class AplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            OptionsBuilder.UseSqlServer("Data Source = .;Initial Catalog = MyDbTest; Integrated Security = True;");

            return new ApplicationDbContext(OptionsBuilder.Options);
        }
    }
}
