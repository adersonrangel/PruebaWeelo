using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Data;
using Weelo.Dominio;
using Weelo.Repository.Interfaces;

namespace Weelo.Repository.SqlServer
{
    /// <summary>
    /// Repositorio de PropertyImage
    /// </summary>
    public class PropertyImageRepository : IPropertyImageRepository
    {

        private readonly WeeloDbContext context;

        public PropertyImageRepository(WeeloDbContext context)
        {
            this.context = context;
        }

        public void Add(PropertyImage propertyImage)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyImage> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PropertyImage>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
