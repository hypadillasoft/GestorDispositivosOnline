using Comun.EntityFramework;
using Datos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    internal class EmpresaRepositorio : IEmpresa

    {
        public object Guardar(object Parametro)
        {
            try
            {
                using (Hogar2Entities contexto = new Hogar2Entities())
                {
                    Empresas empresas = (Empresas)Parametro;
                    Empresas resultado = new Empresas();

                    resultado = contexto.Empresas.Where(item => item.id == empresas.id).FirstOrDefault();

                    if (resultado == null)
                    {
                        contexto.Empresas.Add(empresas);
                        contexto.SaveChanges();
                        return true;
                    }
                    else
                    {
                        resultado.Direccion = empresas.Direccion;
                        resultado.RazonSocial = empresas.RazonSocial;
                        resultado.Email = empresas.Email;
                        resultado.Nit = empresas.Nit;
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
