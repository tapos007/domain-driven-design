using System;
using FluentValidation;
using SMSGATEWAY.DOMAIN.Commands.VendorInfo;

namespace SMSGATEWAY.DOMAIN.Validations.VendorInfo
{
    public class VendorInfoValidation<T>: AbstractValidator<T> where T: VendorInfoCommand
    {
        protected void ValidateName()
        {
            RuleFor(c=>c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 30).WithMessage("The Name must have between 2 and 150 characters");
        }
        
        protected void ValidateShortName()
        {
            RuleFor(c=>c.ShortName)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 30).WithMessage("The Name must have between 2 and 150 characters");
        }
        
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}