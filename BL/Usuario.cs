namespace BL
{
    public class Usuario
    {

        public static Dictionary<string, object> Add(ML.Usuario usuario)
        {
            string msg = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object>() { { "Resultado", false }, { "Mensaje", msg } };

            try
            {
                using (DL.ServicesAjaxContext context = new DL.ServicesAjaxContext())
                {
                    DL.Usuario usuario1 = new DL.Usuario();

                    usuario1.Nombre = usuario.Nombre;
                    usuario1.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuario1.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuario1.Edad = usuario.Edad;

                    context.Usuarios.Add(usuario1);

                    int filas = context.SaveChanges();

                    if (filas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
                diccionario["Mensaje"] = msg;
            }

            return diccionario;
        }

        public static Dictionary<string, object> Update(ML.Usuario usuario)
        {
            string msg = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object>() { { "Resultado", false }, { "Mensaje", msg } };

            try
            {
                using (DL.ServicesAjaxContext context = new DL.ServicesAjaxContext())
                {
                    var query = (from user in context.Usuarios
                                 where usuario.IdUsuario == user.IdUsuario
                                 select user).Single();

                    if(query != null)
                    {
                        query.IdUsuario = usuario.IdUsuario;
                        query.Nombre = usuario.Nombre;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.Edad = usuario.Edad;

                        int filas = context.SaveChanges();

                        if (filas > 0)
                        {
                            diccionario["Resultado"] = true;
                        }
                    }

                }
            }
            catch (Exception e)
            {
                msg = e.Message;
                diccionario["Mensaje"] = msg;
            }

            return diccionario;
        }

        public static Dictionary<string, object> GetAll()
        {
            string msg = "";
            ML.Usuario usuario = new ML.Usuario();
            Dictionary<string, object> diccionario = new Dictionary<string, object>() { { "Resultado", false }, { "Mensaje", msg },{"Usuario",usuario}};

            try
            {
                using (DL.ServicesAjaxContext context = new DL.ServicesAjaxContext())
                {
                    var query = (from user in context.Usuarios                               
                                 select new
                                 {
                                     IdUsuario = user.IdUsuario,
                                     Nombre = user.Nombre,
                                     ApellidoPaterno = user.ApellidoPaterno,
                                     ApellidoMaterno = user.ApellidoMaterno,
                                     Edad = user.Edad

                                 }).ToList();

                    if (query.Count > 0)
                    {
                        usuario.Usuarios = new List<ML.Usuario>();

                        foreach (var item in query)
                        {
                            ML.Usuario usuario1 = new ML.Usuario();
                            usuario1.IdUsuario = item.IdUsuario;
                            usuario1.Nombre = item.Nombre;
                            usuario1.ApellidoPaterno = item.ApellidoPaterno;
                            usuario1.ApellidoMaterno = item.ApellidoMaterno;
                            usuario1.Edad = item.Edad.Value;

                            usuario.Usuarios.Add(usuario1);
                        }

                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
                diccionario["Mensaje"] = msg;
            }

            return diccionario;
        }

        public static Dictionary<string, object> GetById(int idUsuario)
        {
            string msg = "";
            ML.Usuario usuario = new ML.Usuario();
            Dictionary<string, object> diccionario = new Dictionary<string, object>() { { "Resultado", false }, { "Mensaje", msg }, { "Usuario", usuario } };

            try
            {
                using (DL.ServicesAjaxContext context = new DL.ServicesAjaxContext())
                {
                    var query = (from user in context.Usuarios where user.IdUsuario == idUsuario
                                 select new
                                 {
                                     IdUsuario = user.IdUsuario,
                                     Nombre = user.Nombre,
                                     ApellidoPaterno = user.ApellidoPaterno,
                                     ApellidoMaterno = user.ApellidoMaterno,
                                     Edad = user.Edad

                                 }).First();

                    if (query != null)
                    {
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Edad = query.Edad.Value;

                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
                diccionario["Mensaje"] = msg;
            }

            return diccionario;
        }

        public static Dictionary<string, object> Delete(int idUsuario)
        {
            string msg = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object>() { { "Resultado", false }, { "Mensaje", msg }};

            try
            {
                using (DL.ServicesAjaxContext context = new DL.ServicesAjaxContext())
                {
                    var query = (from user in context.Usuarios
                                 where user.IdUsuario == idUsuario
                                 select user).First();

                    context.Usuarios.Remove(query);

                    int filas = context.SaveChanges();

                    if (filas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }

                }
            }
            catch (Exception e)
            {
                msg = e.Message;
                diccionario["Mensaje"] = msg;
            }

            return diccionario;
        }


    }
}
