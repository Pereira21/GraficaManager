using DevIO.Business.Enums;
using System;
using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class Cliente : BaseEntity
    {
        public ETipoPessoa TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string TelefoneContato { get; set; }
        public string EmailContato { get; set; }

        public List<Pedido> Pedidos { get; set; }
    }
}
