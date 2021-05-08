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
    /// Logica de negocio para PropertyIamge
    /// </summary>
    public class PropertyImageBll : IPropertyImageBll
    {
        private readonly IUnitOfWorkAdapter unitOfWorkSqlServerAdapter;

        public PropertyImageBll(IUnitOfWork unitOfWorkSqlServer)
        {
            this.unitOfWorkSqlServerAdapter = unitOfWorkSqlServer.Create();
        }

        public async Task Add(PropertyImage propertyImage)
        {
            unitOfWorkSqlServerAdapter.Repositories.PropertyImage.Add(propertyImage);
            await unitOfWorkSqlServerAdapter.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PropertyImage Get(int id)
        {
            var response = unitOfWorkSqlServerAdapter.Repositories.PropertyImage.Get(id);
            return response.Result;
        }

        public async Task<List<PropertyImage>> GetAll()
        {
            var response = await unitOfWorkSqlServerAdapter.Repositories.PropertyImage.GetAll();
            return response.ToList();
        }
    }
}
