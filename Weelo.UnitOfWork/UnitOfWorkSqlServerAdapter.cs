using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Data;
using Weelo.UnitOfWork.Interfaces;

namespace Weelo.UnitOfWork
{
    /// <summary>
    /// Adpatador de unidad de trabajo
    /// </summary>
    public class UnitOfWorkSqlServerAdapter : IUnitOfWorkAdapter
    {
        private readonly WeeloDbContext context;
        public IUnitOfWorkRepository Repositories { get; }


        public UnitOfWorkSqlServerAdapter(WeeloDbContext context)
        {
            this.context = context;
            this.Repositories = new UnitOfWorkSqlServerRepository(this.context);
        }

        public async Task<bool> SaveChangesAsync()
        {
            bool respuesta = false;
            try
            {
                respuesta = await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                throw;
            }
          
            return  respuesta;
           
        }
    }
}
