using EpiConnectAPI.Core.Enums;
using EpiConnectAPI.Core.ViewModel;
using FluentValidation;

namespace EpiConnectAPI.Core.Validations {
    public class EpiValidation : AbstractValidator<EpiRequestView> {
        public EpiValidation() {
            RuleForEach(x => x.GetType().GetProperties())
                .NotEmpty()
                .WithMessage("Todos os Campos devem ser preenchidos");
        }
    }
    public class EpiRequestView {
        public string Name { get; set; }
        public ProtectionType ProtectionType { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
