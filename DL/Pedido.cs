using System;
using System.Collections.Generic;

namespace DL;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public string? Nombre { get; set; }

    public int? Precio { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<RegistroPedido> RegistroPedidos { get; set; } = new List<RegistroPedido>();
}
