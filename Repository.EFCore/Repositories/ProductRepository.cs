using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.EFCore.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            //Aquí ya existen los métodos del repositorio base con sus operaciones CRUD ya implementadas.
        }
    }
}
