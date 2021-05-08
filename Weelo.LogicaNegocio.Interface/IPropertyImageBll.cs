using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;

namespace Weelo.LogicaNegocio.Interface
{
    public interface IPropertyImageBll
    {
        PropertyImage Get(int id);
        Task<List<PropertyImage>> GetAll();
        Task Add(PropertyImage propertyImage);
        void Delete(int id);
    }
}
