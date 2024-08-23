using MessangerBackend.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MessangerBackend.Storage;

public class MessangerContext : DbContext
{
    public MessangerContext(DbContextOptions<MessangerContext> options) : base(options)
    {
        
    }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MessangerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }*/

    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<PrivateChat> PrivateChats { get; set; }
    public DbSet<GroupChat> GroupChats { get; set; }
    public DbSet<Stats> Stats { get; set; }
}