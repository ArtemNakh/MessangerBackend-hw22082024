namespace MessangerBackend.Core.Models;

public abstract class Chat
{
    public int Id { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public DateTime CreatedAt { get; set; }
}