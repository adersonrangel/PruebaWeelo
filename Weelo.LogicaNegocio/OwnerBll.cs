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
    /// Clase de negocio del Owner
    /// </summary>
    public class OwnerBll : IOwnerBll
    {
        private readonly IUnitOfWorkAdapter unitOfWorkSqlServerAdapter;

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="unitOfWorkSqlServer"></param>
        public OwnerBll(IUnitOfWork unitOfWorkSqlServer)
        {
            this.unitOfWorkSqlServerAdapter = unitOfWorkSqlServer.Create();
        }

        public async Task Add(Owner owner)
        {
            unitOfWorkSqlServerAdapter.Repositories.Owner.Add(owner);
            await unitOfWorkSqlServerAdapter.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un Owner por identificacion
        /// </summary>
        /// <param name="id">Identificador del Owner</param>
        public Owner Get(int id)
        {
           var response = unitOfWorkSqlServerAdapter.Repositories.Owner.Get(id);
           return response.Result;
        }

        /// <summary>
        /// Retorna los todos los Owners del sistema
        /// </summary>
        /// <returns></returns>
        public async Task<List<Owner>> GetAll()
        {
            var response = await unitOfWorkSqlServerAdapter.Repositories.Owner.GetAll();
            return response.ToList();
        }
    }
}
