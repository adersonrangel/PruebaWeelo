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
    public class PropertyTraceRepository:IPropertyTraceRepository
    {
        private readonly WeeloDbContext context;

        public PropertyTraceRepository(WeeloDbContext context)
        {
            this.context = context;
        }

        public void Add(PropertyTrace propertyTrace)
        {
            context.PropertyTrace.Add(propertyTrace);
        }

        public void Delete(int id)
        {
            var propertyTrace = context.PropertyTrace.FirstOrDefault(x => x.IdPropertyTrace == id);
            if (propertyTrace != null)
            {
                context.PropertyTrace.Remove(propertyTrace);
            }
        }

        public Task<PropertyTrace> Get(int id)
        {
            return context.PropertyTrace.FirstOrDefaultAsync(x => x.IdPropertyTrace == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyTrace>> GetAll()
        {
            var query = context.PropertyTrace.Select(p => new PropertyTrace
            {
                IdPropertyTrace = p.IdPropertyTrace,
                Name = p.Name,
                DateSale = p.DateSale,
                Value = p.Value,
                Tax = p.Tax,
                PropertyId = p.PropertyId
            });

            return query;
        }
    }
}
