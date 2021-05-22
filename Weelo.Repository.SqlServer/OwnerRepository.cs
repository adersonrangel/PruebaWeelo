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
    /// <summary>
    /// Repositorio de Owner
    /// </summary>
    public class OwnerRepository : IOwnerRepository
    {
        private readonly WeeloDbContext context;

        public OwnerRepository(WeeloDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Agrega un Owner
        /// </summary>
        /// <param name="owner"></param>
        public void Add(Owner owner)
        {
            context.Owner.Add(owner);
        }

        /// <summary>
        /// Elimina un Owner
        /// </summary>
        /// <param name="id">Identificador del Owner a eliminar</param>
        public void Delete(int id)
        {
            var owner = context.Owner.FirstOrDefault(x => x.IdOwner == id);
            if (owner != null) {
                context.Owner.Remove(owner);
            }            
        }

        /// <summary>
        /// Obtiene un Owner por identificación
        /// </summary>
        /// <param name="id">Identificación del Owner a buscar</param>
        /// <returns>El Owner bucado</returns>
        public Task<Owner> Get(int id)
        {
            return context.Owner.FirstOrDefaultAsync(x => x.IdOwner == id);
        }

        /// <summary>
        /// Obtiene todos los Owners
        /// </summary>
        /// <returns>Enumeración con los Owners</returns>
        public async Task<IEnumerable<Owner>> GetAll()
        {

            var query =  context.Owner.Select(p => new Owner
            {
                IdOwner = p.IdOwner,
                Name = p.Name,
                Address = p.Address,
                Birthday = p.Birthday,
                Photo = p.Photo
            });

            return query;
        }
    }
}
