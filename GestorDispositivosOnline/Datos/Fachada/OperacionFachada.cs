using Datos.Interface;
using Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Fachada
{
    public class OperacionFachada
    {
        private readonly IOperacion interfaz;
        public OperacionFachada()
        {
            interfaz = new OperacionRepositorio();
        }
        public object Guardar(object Parametro)
        {
            return interfaz.Guardar(Parametro);
        }
    }
}
