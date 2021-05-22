using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;

namespace Weelo.Repository.Interfaces
{
    /// <summary>
    /// Interface de Owner
    /// </summary>
    public interface IOwnerRepository
    {
        Task<Owner> Get(int id);
        Task<IEnumerable<Owner>> GetAll();
        void Add(Owner owner);
        void Delete(int id);
    }
}
