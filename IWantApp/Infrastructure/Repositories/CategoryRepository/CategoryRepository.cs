using IWantApp.Domain.Products;
using IWantApp.Infrastructure.Data;

namespace IWantApp.Infrastructure.Repositories.CategoryRepository;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationContext context) : base(context)
    {
    }
}