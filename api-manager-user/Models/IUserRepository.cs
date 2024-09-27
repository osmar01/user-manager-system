namespace api_manager_user.Models
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User> Create(User user);
        Task<User?> Update(int id, User user);
        Task<User?> Delete(int id);
    }
}
