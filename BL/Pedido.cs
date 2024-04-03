using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pedido
    {
        public static Dictionary<string, object> Add(ML.Pedido pedido)
        {
            string msg = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object>() { { "Resultado", false }, { "Mensaje", msg } };

            try
            {
                using (DL.ServicesAjaxContext context = new DL.ServicesAjaxContext())
                {
                    DL.Pedido pedido1 = new DL.Pedido();

                    pedido1.Nombre = pedido.Nombre;
                    pedido1.Precio = pedido.Precio;
                    pedido1.IdUsuario = pedido.Usuario.IdUsuario;
                    context.Pedidos.Add(pedido1);

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

        public static Dictionary<string, object> Update(ML.Pedido pedido)
        {
            string msg = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object>() { { "Resultado", false }, { "Mensaje", msg } };

            try
            {
                using (DL.ServicesAjaxContext context = new DL.ServicesAjaxContext())
                {
                    var query = (from pedi in context.Pedidos
                                 where pedido.IdPedido == pedi.IdPedido
                                 select pedi).Single();

                    if (query != null)
                    {
                        query.Nombre = pedido.Nombre;
                        query.Precio = pedido.Precio;
                        query.IdUsuario = pedido.Usuario.IdUsuario;
                    

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
            ML.Pedido pedido = new ML.Pedido();
            Dictionary<string, object> diccionario = new Dictionary<string, object>() { { "Resultado", false }, { "Mensaje", msg }, { "Pedido", pedido } };

            try
            {
                using (DL.ServicesAjaxContext context = new DL.ServicesAjaxContext())
                {
                    var query = (from ped in context.Pedidos
                                 select new
                                 {
                                     IdPedido = ped.IdPedido,
                                     Nombre = ped.Nombre,
                                     Precio = ped.Precio,
                                     IdUsuario = ped.IdPedido
                                 }).ToList();

                    if (query.Count > 0)
                    {
                        pedido.Pedidos = new List<ML.Pedido>();

                        foreach (var item in query)
                        {
                            ML.Pedido pedido1 = new ML.Pedido();
                            pedido1.IdPedido = item.IdPedido;
                            pedido1.Nombre = item.Nombre;
                            pedido1.Precio = item.Precio.Value;
                            pedido1.Usuario = new ML.Usuario();
                            pedido1.Usuario.IdUsuario = item.IdUsuario;

                            pedido.Pedidos.Add(pedido1);
                        }

                        diccionario["Resultado"] = true;
                        diccionario["Pedido"] = pedido;
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

        public static Dictionary<string, object> GetById(int idPedido)
        {
            string msg = "";
            ML.Pedido pedido = new ML.Pedido();
            Dictionary<string, object> diccionario = new Dictionary<string, object>() { { "Resultado", false }, { "Mensaje", msg }, { "Pedido", pedido } };

            try
            {
                using (DL.ServicesAjaxContext context = new DL.ServicesAjaxContext())
                {
                    var query = (from ped in context.Pedidos where ped.IdPedido == idPedido select ped).First();

                    if (query != null)
                    {
                        pedido.IdPedido = query.IdPedido;
                        pedido.Nombre = query.Nombre;
                        pedido.Precio = query.Precio.Value;
                        pedido.Usuario = new ML.Usuario();
                        pedido.Usuario.IdUsuario = query.IdUsuario.Value;

                        diccionario["Resultado"] = true;
                        diccionario["Pedido"] = pedido;
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

        public static Dictionary<string, object> Delete(int idPedido)
        {
            string msg = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object>() { { "Resultado", false }, { "Mensaje", msg } };

            try
            {
                using (DL.ServicesAjaxContext context = new DL.ServicesAjaxContext())
                {
                    var query = (from pedi in context.Pedidos
                                 where pedi.IdPedido == idPedido
                                 select pedi).First();

                    context.Pedidos.Remove(query);

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
