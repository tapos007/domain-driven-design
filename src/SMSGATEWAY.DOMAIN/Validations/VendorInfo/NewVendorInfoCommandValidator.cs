using SMSGATEWAY.DOMAIN.Commands.VendorInfo;

namespace SMSGATEWAY.DOMAIN.Validations.VendorInfo
{
    public class NewVendorInfoCommandValidator : VendorInfoValidation<NewVendorInfoCommand>
    {
        public NewVendorInfoCommandValidator()
        {
             ValidateName();
             ValidateShortName();
        }
    }
}