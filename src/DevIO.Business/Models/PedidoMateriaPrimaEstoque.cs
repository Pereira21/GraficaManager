using System;

namespace DevIO.Business.Models
{
    public class PedidoMateriaPrimaEstoque : BaseEntity
    {
        public Guid PedidoId { get; set; }
        public Guid MateriaPrimaEstoqueId { get; set; }
        public int Quantidade { get; set; }

        public Pedido Pedido { get; set; }
        public MateriaPrimaEstoque MateriaPrimaEstoque { get; set; }
    }
}
