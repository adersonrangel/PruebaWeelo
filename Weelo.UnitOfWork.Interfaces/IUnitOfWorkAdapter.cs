using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkAdapter
    {
        IUnitOfWorkRepository Repositories { get; }
        Task<bool> SaveChangesAsync();
    }
}
