using Solution.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<RegistrationResponse> Register (AuthRequest request);
        Task<AuthResponse> Login (AuthRequest request);
    }
}
