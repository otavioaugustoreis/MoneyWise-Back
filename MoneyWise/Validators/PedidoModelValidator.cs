using FluentValidation;
using MoneyWise.Models;

namespace MoneyWise.Validators
{

    //Validator é uma classe usada para validar as classes conforme nosso
    public class PedidoModelValidator : AbstractValidator<PedidoModel>
    {
        // Nome obrigatório, com no mínimo 3 caracteres
        public PedidoModelValidator()
        {
            //Validação para o campo DsNome
            RuleFor(pedido => pedido.DsNome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.");
        }

    }
}
