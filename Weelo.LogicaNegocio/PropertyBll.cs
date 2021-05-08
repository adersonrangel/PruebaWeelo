using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;
using Weelo.LogicaNegocio.Interface;
using Weelo.UnitOfWork;
using Weelo.UnitOfWork.Interfaces;

namespace Weelo.LogicaNegocio
{
    /// <summary>
    /// Clase de negocio del Property
    /// </summary>
    public class PropertyBll : IPropertyBll
    {
        private readonly IUnitOfWorkAdapter unitOfWorkSqlServerAdapter;

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="unitOfWorkSqlServer"></param>
        public PropertyBll(IUnitOfWork unitOfWorkSqlServer)
        {
            this.unitOfWorkSqlServerAdapter = unitOfWorkSqlServer.Create();
        }

        public async Task Add(Property property)
        {
            unitOfWorkSqlServerAdapter.Repositories.Property.Add(property);
            await unitOfWorkSqlServerAdapter.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un Property por identificacion
        /// </summary>
        /// <param name="id">Identificador del Property</param>
        public Property Get(int id)
        {
           var response = unitOfWorkSqlServerAdapter.Repositories.Property.Get(id);
           return response.Result;
        }

        /// <summary>
        /// Retorna los todos los Property del sistema
        /// </summary>
        /// <returns></returns>
        public async Task<List<Property>> GetAll()
        {
            var response = await unitOfWorkSqlServerAdapter.Repositories.Property.GetAll();
            return response.ToList();
        }
    }
}
