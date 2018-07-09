using Datos.Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DispositivoManejador
    {
        private readonly DispositivoFachada fachada;
        public DispositivoManejador()
        {
            fachada = new DispositivoFachada();
        }

        public object Guardar(object Parametro)
        {
            return fachada.Guardar(Parametro);
        }
    }
}
