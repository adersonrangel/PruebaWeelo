using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Repository.Interfaces;

namespace Weelo.UnitOfWork.Interfaces
{
    /// <summary>
    /// Interface de unidad de trabajo del repository
    /// </summary>
    public interface IUnitOfWorkRepository
    {
        IOwnerRepository Owner { get; }
        IPropertyRepository Property { get; }
        IPropertyImageRepository PropertyImage { get; }
        IPropertyTraceRepository PropertyTrace { get; }

    }
}
