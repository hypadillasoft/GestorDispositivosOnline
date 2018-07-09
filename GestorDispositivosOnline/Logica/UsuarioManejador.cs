using Comun.EntityFramework;
using Datos.Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class UsuarioManejador
    {
        private readonly UsuarioFachada interfaz;
        public UsuarioManejador()
        {
            interfaz = new UsuarioFachada();
        }
        public object Guardar(object Parametro)
        {
            Usuarios usuario = (Usuarios)Parametro;

            if (string.IsNullOrEmpty(usuario.Nombre))
            {
                return "No puedes ingresar un nombre de usuario vacío.";
            }

            if (string.IsNullOrEmpty(usuario.Password))
            {
                return "No puedes ingresar un password vacío.";
            }

            return interfaz.Guardar(Parametro);
        }
    }
}
