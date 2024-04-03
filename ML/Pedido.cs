using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Pedido
    {
        public int IdPedido { get; set; }

        public string Nombre { get; set; }  

        public int Precio { get; set;}
        public ML.Usuario Usuario { get; set; }

        public List<ML.Pedido> Pedidos { get; set; }
    }
}
