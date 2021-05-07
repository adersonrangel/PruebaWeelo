using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;

namespace Weelo.Repository.Interfaces
{
    /// <summary>
    /// Interface de Property
    /// </summary>
    public interface IPropertyRepository
    {
        Task<Property> Get(int id);
        Task<IEnumerable<Property>> GetAll();
        void Add(Property property);
        void Delete(int id);
    }
}
