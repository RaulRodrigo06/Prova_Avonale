using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ProductImplementation : BaseRepository<ProductEntity>
    {
        private DbSet<ProductEntity> _dataset;

        public ProductImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ProductEntity>();
        }
    }
}
