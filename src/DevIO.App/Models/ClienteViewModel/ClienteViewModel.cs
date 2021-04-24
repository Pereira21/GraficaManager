using DevIO.Business.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.Models.ClienteViewModel
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Tipo Pessoa")]
        [Required(ErrorMessage = "Obrigatório!")]
        public ETipoPessoa TipoPessoa { get; set; }

        [Display(Name = "CPF/CNPJ")]
        [Required(ErrorMessage = "Obrigatório!")]
        public string CpfCnpj { get; set; }

        [Display(Name = "Nome Contato")]
        public string NomeCompleto { get; set; }

        [Display(Name = "Data Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Obrigatório!")]
        public string TelefoneContato { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Obrigatório!")]
        [EmailAddress(ErrorMessage = "O E-mail é inválido!")]
        public string EmailContato { get; set; }
    }
}
