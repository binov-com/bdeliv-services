using System;
using System.Threading.Tasks;

namespace bdeliv_services.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}