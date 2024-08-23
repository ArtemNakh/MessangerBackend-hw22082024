using MessangerBackend.Core.Interfaces;
using MessangerBackend.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MessangerBackend.Core.Services;

public class UserService : IUserService
{
    private readonly IRepository _repository;

    public UserService(IRepository repository)
    {
        _repository = repository;
    }

    public Task<User> Login(string nickname, string password)
    {
        if (nickname == null || string.IsNullOrEmpty(nickname.Trim()) || 
            password == null || string.IsNullOrEmpty(password.Trim()))
        {
            throw new ArgumentNullException();
        }
        return _repository.GetAll<User>()
            .SingleAsync(x => x.Nickname == nickname && x.Password == password);
    }

    public async Task<User> Register(string nickname, string password)
    {
        var user = await _repository.Add(new User()
        {
            Nickname = nickname,
            Password = password,
            CreatedAt = DateTime.UtcNow,
            LastSeenOnline = DateTime.UtcNow,
        });
        return user;
    }

    public async Task AddStats(string nickname)
    {
        var stats = _repository.GetAll<Stats>().FirstOrDefault(x => x.Name == nickname);
        if (stats == null)
            await _repository.Add(new Stats() { Name = nickname, Count = 1 });
        else
        {
            stats.Count++;
            await _repository.Update(stats);
        }
    }

    public Task<User> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetUsers(int page, int size)
    {
        return _repository.GetAll<User>().Skip(page * size).Take(size);
    }

    public IEnumerable<User> SearchUsers(string nickname)
    {
        return _repository.GetAll<User>().Where(x => x.Nickname.ToLower().Contains(nickname.ToLower()));
    }
    
    // якщо нікнейм коректний 
    // якщо нікнейм пустий 
    // якщо немає такого нікнейму
    // якщо нікнейм є частиною чиєгось нікнейму (User { Nickname = "TestDevUser" }, nickname = "Dev")
    // різні регістри (User { Nickname = "User" }, nickname = "user")
}