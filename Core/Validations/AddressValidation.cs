using EpiConnectAPI.Core.ViewModel;
using FluentValidation;

namespace EpiConnectAPI.Core.Validations {
    public class AddressValidation : AbstractValidator<AddressRequestView> {
        public AddressValidation() {
            RuleForEach(x => x.GetType().GetProperties())
                .NotEmpty().WithMessage("Todos os campos devem ser preenchidos");
            RuleFor(x => x.State).MaximumLength(2).WithMessage("O Estado deve ser a Sigla com letras maiusculas");
            RuleFor(x => x.ZipCode).Matches("^\\d{8}$").WithMessage("O CEP deve ser numerico e conter 8 digitos");
        }
    }
}
