using System;
using System.Collections.Generic;

namespace DL;

public partial class RegistroPedido
{
    public int IdRegistro { get; set; }

    public int? IdPedido { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }
}
