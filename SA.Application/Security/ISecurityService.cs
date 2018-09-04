using SA.Application.Account;
using System.Threading.Tasks;

namespace SA.Application.Security
{
    public interface ISecurityService
    {
        Task<AuthResponse> Login(LoginUserDto user);

        string GetMD5HashData(string data);

        Task<AuthResponse> ResetPassword(ChangePasswordDto obj);

        Task<bool> CheckUniqueUserName(string userName);

        Task<bool> CheckUniqueEmailAddress(string email);
    }
}
