using Datos.Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class OperacionManejador
    {
        private readonly OperacionFachada fachada;
        public OperacionManejador()
        {
            fachada = new OperacionFachada();
        }
        public object Guardar(object Parametro)
        {
            return fachada.Guardar(Parametro);
        }
    }
}
