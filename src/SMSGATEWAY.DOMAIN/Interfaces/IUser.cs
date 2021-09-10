using System.Collections.Generic;
using System.Security.Claims;

namespace SMSGATEWAY.DOMAIN.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
