using Comun.EntityFramework;
using Datos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    internal class OperacionRepositorio : IOperacion
    {
        public object Guardar(object Parametro)
        {
            try
            {
                using (Hogar2Entities contexto = new Hogar2Entities())
                {
                    Operaciones operaciones = (Operaciones)Parametro;
                    Operaciones resultado = new Operaciones();

                    resultado = contexto.Operaciones.Where(item => item.id == operaciones.id).FirstOrDefault();

                    if (resultado == null)
                    {
                        contexto.Operaciones.Add(operaciones);
                        contexto.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
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
