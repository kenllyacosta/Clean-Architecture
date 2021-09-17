using Domain.Entities;

namespace Repository.EFCore.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
