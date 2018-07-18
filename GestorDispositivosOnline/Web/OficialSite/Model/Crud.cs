using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    class Crud
    {

        public ResponseModel Acceder(string Email, string Password)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    Password = HashHelper.MD5(Password);

                    var usuario = ctx.Usuario.Where(x => x.Email == Email)
                                             .Where(x => x.Password == Password)
                                             .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.id.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Correo o contraseña incorrecta");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }

        public Usuario Obtener(int id, bool includes = false)
        {
            var usuario = new Usuario();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (!includes)
                    {
                        usuario = ctx.Usuario.Where(x => x.id == id)
                                             .SingleOrDefault();
                    }
                    else
                    {
                        usuario = ctx.Usuario.Include("Experiencia")
                                             .Include("Habilidad")
                                             .Include("Testimonio")
                                             .Where(x => x.id == id)
                                             .SingleOrDefault();
                    }

                    // Trayendo un registro adicional de manera manual, sin usar Include
                    usuario.Pais = new TablaDato().Obtener("pais", usuario.Pais_id.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }

            return usuario;
        }

        public ResponseModel Guardar(HttpPostedFileBase Foto)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ctx.Configuration.ValidateOnSaveEnabled = false;

                    var eUsuario = ctx.Entry(this);
                    eUsuario.State = EntityState.Modified;

                    // Campos que queremos ignorar
                    if (Foto != null)
                    {
                        // Nombre del archivo, es decir, lo renombramos para que no se repita nunca
                        string archivo = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(Foto.FileName);

                        // La ruta donde lo vamos guardar
                        Foto.SaveAs(HttpContext.Current.Server.MapPath("~/uploads/" + archivo));

                        // Establecemos en nuestro modelo el nombre del archivo
                        this.Foto = archivo;
                    }
                    else eUsuario.Property(x => x.Foto).IsModified = false;

                    if (this.Password == null) eUsuario.Property(x => x.Password).IsModified = false;

                    ctx.SaveChanges();

                    rm.SetResponse(true);
                }
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }
    }
}

    }
}
