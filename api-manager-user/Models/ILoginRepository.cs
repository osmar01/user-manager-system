using api_manager_user.Dto;

namespace api_manager_user.Models
{
    public interface ILoginRepository
    {
        string generateToken(UserDTO userDTO);
        bool VerifyPassword(string password, string hash);
        Task<User> GetUserByEmail(string email);
    }
}
