using System.ComponentModel.DataAnnotations.Schema;

namespace MessangerBackend.Core.Models;

[Table("GroupChat")]
public class GroupChat : Chat
{
    public string Title { get; set; }
    public string Description { get; set; }
}