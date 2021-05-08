using Microsoft.EntityFrameworkCore;
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
    public class PropertyRepository : IPropertyRepository
    {
        private readonly WeeloDbContext context;

        public PropertyRepository(WeeloDbContext context)
        {
            this.context = context;
        }

        public void Add(Property property)
        {
            context.Property.Add(property);
        }

        public void Delete(int id)
        {
            var owner = context.Property.FirstOrDefault(x => x.IdProperty == id);
            if (owner != null)
            {
                context.Property.Remove(owner);
            }
        }

        public Task<Property> Get(int id)
        {
            return context.Property.FirstOrDefaultAsync(x => x.IdProperty == id);
        }

        public async Task<IEnumerable<Property>> GetAll()
        {
            var query = context.Property.Select(p => new Property
            {
                IdProperty = p.IdProperty,
                Name = p.Name,
                Address = p.Address,
                Price = p.Price,
                CodeInternal = p.CodeInternal,
                Year = p.Year,
                OwnerId = p.OwnerId
            });

            return query;
        }
    }
}
