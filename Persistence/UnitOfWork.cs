using System.Threading.Tasks;
using bdeliv_services.Core;

namespace bdeliv_services.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BdelivDbContext context;

        public UnitOfWork(BdelivDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
           await context.SaveChangesAsync();
        }
    }
}