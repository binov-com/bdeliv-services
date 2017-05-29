using System.Threading.Tasks;

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