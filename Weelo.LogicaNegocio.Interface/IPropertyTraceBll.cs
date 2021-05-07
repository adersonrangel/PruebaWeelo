using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;

namespace Weelo.LogicaNegocio.Interface
{
    public interface IPropertyTraceBll
    {
        PropertyTrace Get(int id);
        Task<List<PropertyTrace>> GetAll();
        Task Add(PropertyTrace propertyTrace);
        void Delete(int id);
    }
}
