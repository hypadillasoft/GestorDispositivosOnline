using Comun.EntityFramework;
using Datos.Interface;
using Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Fachada
{
    public class UsuarioFachada
    {
        private readonly IUsuario interfaz;
        public UsuarioFachada()
        {
            interfaz = new UsuarioRepositroio();
        }
        public object Guardar(object Parametro)
        {
            Usuarios usuario = (Usuarios)Parametro;
            if (usuario.Nombre.Length > 10)
            {
                return "Ingresaste más de 10 caracteres.";
            }
            
            return interfaz.Guardar(Parametro); 
        }
    }
}
