using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;

namespace Weelo.LogicaNegocio.Interface
{
    /// <summary>
    /// Interfaz de logica de negocio del Owner
    /// </summary>
    public interface IOwnerBll
    {
        Owner Get(int id);
        Task<List<Owner>> GetAll();
        Task Add(Owner owner);
        void Delete(int id);
    }
}
