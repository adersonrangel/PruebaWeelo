using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.LogicaNegocio;
using Weelo.LogicaNegocio.Interface;
using Weelo.UnitOfWork;
using Weelo.UnitOfWork.Interfaces;

namespace Weelo.Transversal.IoC
{
    /// <summary>
    /// Clase para agregar las dependencias al sistema
    /// </summary>
    public static class InjeccionDependencia
    {
        /// <summary>
        /// Permite agregar los Servicios de logica de negocio del sistema
        /// </summary>
        /// <param name="services">Coleccion de servicios actuales</param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISeguridadBll, SeguridadBll>();
            services.AddScoped<IOwnerBll, OwnerBll>();

            return services;
        }

        /// <summary>
        /// Permite Agregar los Repositorios del sistema
        /// </summary>
        /// <param name="services">Colleccion de servicios actuales</param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorkSqlServer>();

            return services;
        }

    }
}
