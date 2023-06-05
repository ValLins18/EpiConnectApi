using EpiConnectAPI.Core.ViewModel;
using FluentValidation;

namespace EpiConnectAPI.Core.Validations {
    public class PhoneValidation : AbstractValidator<PhoneRequestView>{
        public PhoneValidation() {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Must(x => int.TryParse(x, out _))
                .WithMessage("O numero de telefone deve conter somente numeros");
            RuleFor(x => x.DDD)
                .NotEmpty()
                .Must(x => int.TryParse(x, out _))
                .MaximumLength(2)
                .WithMessage("O DDD deve ser numero e conter somente dois numeros");
        }
    }
}
