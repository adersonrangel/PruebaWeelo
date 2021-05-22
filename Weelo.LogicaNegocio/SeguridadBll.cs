using System;
using System.Threading.Tasks;
using Weelo.Dominio;
using Weelo.LogicaNegocio.Interface;

namespace Weelo.LogicaNegocio
{
    /// <summary>
    /// Clase de logica de negocio de Seguridad
    /// </summary>
    public class SeguridadBll : ISeguridadBll
    {
       

        //Constructor
        public SeguridadBll()
        {
           
        }


        public async Task<Cliente> ValidarUsuario(string usuario, string clave) {

            var tcs = new TaskCompletionSource<Cliente>();
            Cliente cliente = null;


            if (usuario == "cliente" && clave =="clavesegura1234567")
            {
                cliente = new() { 
                 Ciudad = "681003",
                 Usuario = "cliente",
                 Estado = 1
                };

            }

            tcs.SetResult(cliente);

            return await tcs.Task;
        }

    }
}
