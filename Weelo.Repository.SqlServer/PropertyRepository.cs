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
    /// <summary>
    /// Repositorio de property
    /// </summary>
    public class PropertyRepository : IPropertyRepository
    {
        private readonly WeeloDbContext context;

        public PropertyRepository(WeeloDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Metodo para agregar una Property
        /// </summary>
        /// <param name="property">Datos de Property</param>
        public void Add(Property property)
        {
            context.Property.Add(property);
        }

        /// <summary>
        /// Metodo para eliminar una propiedad
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var owner = context.Property.FirstOrDefault(x => x.IdProperty == id);
            if (owner != null)
            {
                context.Property.Remove(owner);
            }
        }

        /// <summary>
        /// Metodo para obtener una Property por identificador
        /// </summary>
        /// <param name="id">Identificador de Property</param>
        /// <returns></returns>
        public Task<Property> Get(int id)
        {
            return context.Property.FirstOrDefaultAsync(x => x.IdProperty == id);
        }

        /// <summary>
        /// Obtiene todas las Property's registradas 
        /// </summary>
        /// <returns></returns>
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
