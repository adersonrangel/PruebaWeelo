using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;

namespace Weelo.Repository.Interfaces
{
    /// <summary>
    /// Interface de PropertyTrace
    /// </summary>
    public interface IPropertyTraceRepository
    {
        Task<PropertyTrace> Get(int id);
        Task<IEnumerable<PropertyTrace>> GetAll();
        void Add(PropertyTrace propertyTrace);
        void Delete(int id);
    }
}
