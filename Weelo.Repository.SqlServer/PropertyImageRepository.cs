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
            context.PropertyImage.Add(propertyImage);
        }

        public void Delete(int id)
        {
            var propertyImage = context.PropertyImage.FirstOrDefault(x => x.IdPropertyImage == id);
            if (propertyImage != null)
            {
                context.PropertyImage.Remove(propertyImage);
            }
        }

        public Task<PropertyImage> Get(int id)
        {
            return context.PropertyImage.FirstOrDefaultAsync(x => x.IdPropertyImage == id);
        }

        public async Task<IEnumerable<PropertyImage>> GetAll()
        {
            var query = context.PropertyImage.Select(p => new PropertyImage
            {
                IdPropertyImage = p.IdPropertyImage,
                Enabled = p.Enabled,
                File = p.File,
                PropertyId = p.PropertyId
            });

            return query;
        }
    }
}
