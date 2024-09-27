using api_manager_user.Models;
using Microsoft.EntityFrameworkCore;

namespace api_manager_user.Infra
{
    public class UserRepository : IUserRepository
    {

        private readonly ConnectionContext _context;

        public UserRepository(ConnectionContext context)
        {
            _context = context;
        }


        public async Task<User> Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> Delete(int id)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.id == id);

            if (userModel == null)
            {
                return null;
            }

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.id == id);

        }

        public async Task<User?> Update(int id, User user)
        {
            User userId = await GetById(id);

            if (userId == null)
            {
                throw new InvalidOperationException("usuario não encontrado");
            }

            userId.nome = user.nome;
            userId.email = user.email;
            userId.senha = user.senha;
            userId.dataDeCadastro = user.dataDeCadastro;

            _context.Update(userId);
            await _context.SaveChangesAsync();

            return userId;

        }
    }
}
