using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Data;
using Weelo.Repository.Interfaces;
using Weelo.Repository.SqlServer;
using Weelo.UnitOfWork.Interfaces;

namespace Weelo.UnitOfWork
{
    /// <summary>
    /// Repositorio de Unidad de trabajo de SqlServer
    /// </summary>
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        private readonly WeeloDbContext context;

        public IOwnerRepository Owner { get; }

        public IPropertyRepository Property {get;}

        public IPropertyImageRepository PropertyImage { get; }

        public IPropertyTraceRepository PropertyTrace { get; }
        

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public UnitOfWorkSqlServerRepository(WeeloDbContext context)
        {
            this.context = context;
            Owner = new OwnerRepository(this.context);
            PropertyImage = new PropertyImageRepository(this.context);
            Property = new PropertyRepository(this.context);
            PropertyTrace = new PropertyTraceRepository(this.context);
        }
    }
}
