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
    /// Unidad de trabajo de SqlServer
    /// </summary>
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        private readonly WeeloDbContext context;

        public UnitOfWorkSqlServer(WeeloDbContext context)
        {
            this.context = context;
        }

        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkSqlServerAdapter(context);
        }
    }
}
