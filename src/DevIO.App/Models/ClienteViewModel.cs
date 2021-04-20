using DevIO.Business.Enums;
using System;

namespace DevIO.App.Models
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public ETipoPessoa TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string TelefoneContato { get; set; }
        public string EmailContato { get; set; }

        //public List<Pedido> Pedidos { get; set; }
    }
}
