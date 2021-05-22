using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;

namespace Weelo.Repository.Interfaces
{
    /// <summary>
    /// Interface de PropertyImage
    /// </summary>
    public interface IPropertyImageRepository
    {
        Task<PropertyImage> Get(int id);
        Task<IEnumerable<PropertyImage>> GetAll();
        void Add(PropertyImage propertyImage);
        void Delete(int id);
    }
}
