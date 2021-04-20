using System;

namespace DevIO.Business.Models
{
    public class CompraMateriaPrima : BaseEntity
    {
        public Guid MateriaPrimaEstoqueId { get; set; }
        public Guid UsuarioId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }

        public MateriaPrimaEstoque MateriaPrimaEstoque { get; set; }
    }
}
