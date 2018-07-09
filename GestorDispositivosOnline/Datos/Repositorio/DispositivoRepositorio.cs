using Comun.EntityFramework;
using Datos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    internal class DispositivoRepositorio : IDispositivo
    {
        public object Guardar(object Parametro)
        {
            try
            {
                using (Hogar2Entities contexto = new Hogar2Entities())
                {
                    Dispositivos dispositivos = (Dispositivos)Parametro;
                    Dispositivos resultado = new Dispositivos();

                    resultado = contexto.Dispositivos.Where(item => item.id == dispositivos.id).FirstOrDefault();

                    if (resultado == null)
                    {
                        contexto.Dispositivos.Add(dispositivos);
                        contexto.SaveChanges();
                        return true;
                    }
                    else
                    {
                        resultado.Descripcion = dispositivos.Descripcion;
                        resultado.Nombre = dispositivos.Nombre;
                        contexto.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
