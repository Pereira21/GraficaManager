using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class MateriaPrimaEstoqueValidation : AbstractValidator<MateriaPrimaEstoque>
    {
        public MateriaPrimaEstoqueValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
                .Length(2, 255).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");
        }
    }
}
