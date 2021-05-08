using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;

namespace Weelo.LogicaNegocio.Interface
{
    /// <summary>
    /// Interfaz de negocio para Property
    /// </summary>
    public interface IPropertyBll
    {
        Property Get(int id);
        Task<List<Property>> GetAll();
        Task Add(Property property);
        void Delete(int id);
    }
}
