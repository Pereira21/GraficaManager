using DevIO.Business.Enums;
using System;
using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class Pedido : BaseEntity
    {
        public Guid ClienteId { get; set; }
        public string NumeroPedido { get; set; }
        public DateTime? DataEntrega { get; set; }
        public string Descricao { get; set; }
        public EStatusPedido Status { get; set; }

        public Cliente Cliente { get; set; }
        public List<PedidoMateriaPrimaEstoque> MateriasPrimas { get; set; }
    }
}
