using MessangerBackend.Core.Models;

namespace MessangerBackend.Core.Interfaces;

public interface IUserService
{
    Task<User> Login(string nickname, string password);
    Task<User> Register(string nickname, string password);
    Task AddStats(string nickname);
    
    Task<User> GetUserById(int id);
    IEnumerable<User> GetUsers(int page, int size);
    IEnumerable<User> SearchUsers(string nickname);
}