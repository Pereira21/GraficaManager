using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class MateriaPrimaEstoque : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public IEnumerable<CompraMateriaPrima> Compras { get; set; }
        public IEnumerable<PedidoMateriaPrimaEstoque> Pedidos { get; set; }
    }
}
