using System;
using System.Threading.Tasks;

namespace bdeliv_services.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}