using System.ComponentModel.DataAnnotations;

namespace DevIO.Business.Enums
{
    public enum ETipoPessoa
    {
        [Display(Name = "Pessoa Física")]
        PessoaFisica = 1,
        [Display(Name = "Pessoa Jurídica")]
        PessoaJuridica
    }
}
