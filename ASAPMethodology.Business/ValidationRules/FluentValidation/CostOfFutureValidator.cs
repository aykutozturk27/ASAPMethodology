using ASAPMethodology.Business.Constants;
using ASAPMethodology.Entities.Concrete;
using ASAPMethodology.Entities.Dtos;
using FluentValidation;

namespace ASAPMethodology.Business.ValidationRules.FluentValidation
{
    public class CostOfFutureValidator : AbstractValidator<CostOfFutureAddDto>
    {
        public CostOfFutureValidator()
        {
            RuleFor(x => x.CardName).NotEmpty().WithMessage(Messages.CardNameIsNotEmpty);
            RuleFor(x => x.CardLastName).NotEmpty().WithMessage(Messages.CardLastNameIsNotEmpty);
            RuleFor(x => x.PolicyNum).NotEmpty().WithMessage(Messages.PolicyNumIsNotEmpty);
            RuleFor(x => x.PolicyBegDate).NotEmpty().WithMessage(Messages.PolicyBegDateIsNotEmpty);
            RuleFor(x => x.InstallementNo).NotEmpty().WithMessage(Messages.InstallementNoIsNotEmpty);
            RuleFor(x => x.PolicyEndDate).NotEmpty().WithMessage(Messages.PolicyEndDateIsNotEmpty);
            RuleFor(x => x.Methodology).NotEmpty().WithMessage(Messages.MethodologyIsNotEmpty);
            RuleFor(x => x.InstallementAmount).NotEmpty().WithMessage(Messages.InstallementAmountIsNotEmpty);
        }
    }
}
