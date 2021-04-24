using DevIO.Business.Enums;
using DevIO.Business.Models.Validations.Common;
using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(f => f.NomeCompleto)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
                .Length(2, 255).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");

            When(f => f.TipoPessoa == ETipoPessoa.PessoaFisica, () =>
            {
                RuleFor(f => CpfValidation.IsCpf(f.CpfCnpj)).Equal(true).WithMessage("O CPF é inválido!");
            });

            When(f => f.TipoPessoa == ETipoPessoa.PessoaJuridica, () =>
            {
                RuleFor(f => CnpjValidation.IsCnpj(f.CpfCnpj)).Equal(true).WithMessage("O CNPJ é inválido!");
            });
        }
    }
}
