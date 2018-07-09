using SA.Application.Account;
using SA.Core.Model;
using System.Threading.Tasks;

namespace SA.Application.Security
{
    public interface ISecurityService
    {
        Task<TokenDto> RequestToken();
        Task<User> Login(LoginUserDto user);
    }
}
