using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;
using Weelo.LogicaNegocio.Interface;
using Weelo.UnitOfWork.Interfaces;

namespace Weelo.LogicaNegocio
{
    /// <summary>
    /// Logica de negocio para PropertyTrace
    /// </summary>
    public class PropertyTraceBll : IPropertyTraceBll
    {
        private readonly IUnitOfWorkAdapter unitOfWorkSqlServerAdapter;

        public PropertyTraceBll(IUnitOfWork unitOfWorkSqlServer)
        {
            this.unitOfWorkSqlServerAdapter = unitOfWorkSqlServer.Create();
        }

        public async Task Add(PropertyTrace propertyTrace)
        {
            unitOfWorkSqlServerAdapter.Repositories.PropertyTrace.Add(propertyTrace);
            await unitOfWorkSqlServerAdapter.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PropertyTrace Get(int id)
        {
            var response = unitOfWorkSqlServerAdapter.Repositories.PropertyTrace.Get(id);
            return response.Result;
        }

        public async Task<List<PropertyTrace>> GetAll()
        {
            var response = await unitOfWorkSqlServerAdapter.Repositories.PropertyTrace.GetAll();
            return response.ToList();
        }
    }
}
