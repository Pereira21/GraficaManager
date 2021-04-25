﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Business.Models
{
    public class MateriaPrimaEstoque : BaseEntity
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Imagem")]
        public string Imagem { get; set; }

        public IEnumerable<CompraMateriaPrima> Compras { get; set; }
        public IEnumerable<PedidoMateriaPrimaEstoque> Pedidos { get; set; }
    }
}
