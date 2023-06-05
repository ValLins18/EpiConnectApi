using EpiConnectAPI.Core.ViewModel;
using FluentValidation;

namespace EpiConnectAPI.Core.Validations {
    public class AlertValidation : AbstractValidator<AlertRequestView>{
        public AlertValidation() {

        }
    }
}
