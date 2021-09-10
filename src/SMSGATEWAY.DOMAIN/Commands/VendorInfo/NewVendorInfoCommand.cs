using SMSGATEWAY.DOMAIN.Validations.VendorInfo;

namespace SMSGATEWAY.DOMAIN.Commands.VendorInfo
{
    public class NewVendorInfoCommand : VendorInfoCommand
    {
        public NewVendorInfoCommand(string name,string shortName, string details,
            string adminUrl,string userName, string password)
        {
            Name = name;
            ShortName = shortName;
            Details = details;
            AdminUrl = adminUrl;
            UserName = userName;
            Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewVendorInfoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}