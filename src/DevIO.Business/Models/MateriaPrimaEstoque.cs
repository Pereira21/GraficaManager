using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Business.Models
{
    public class MateriaPrimaEstoque : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }

        public IEnumerable<CompraMateriaPrima> Compras { get; set; }
        public IEnumerable<PedidoMateriaPrimaEstoque> Pedidos { get; set; }
    }
}
