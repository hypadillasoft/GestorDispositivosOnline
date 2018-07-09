using Datos.Interface;
using Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Fachada
{
    public class EmpresaFachada
    {
        private readonly IEmpresa interfaz;
        public EmpresaFachada()
        {
            interfaz = new EmpresaRepositorio();
        }

        public object Guardar(object Parametro)
        {
            return interfaz.Guardar(Parametro);
        }
    }
}
