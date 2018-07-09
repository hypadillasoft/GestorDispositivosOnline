using Datos.Interface;
using Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Fachada
{
    public class DispositivoFachada 
    {
        private readonly IDispositivo interfaz;
        public DispositivoFachada()
        {
            interfaz = new DispositivoRepositorio();
        }
        public object Guardar(object Parametro)
        {
            return interfaz.Guardar(Parametro);
        }
    }
}
