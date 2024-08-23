namespace MessangerBackend.Core.Models;

public class Message
{
    public int Id { get; set; }
    public virtual User Sender { get; set; }
    public virtual Chat Chat { get; set; }
    public DateTime SentAt { get; set; }
    public string Content { get; set; }
    public virtual ICollection<Attachment> Attachments { get; set; }
}

/*
 * id user_id chat_id
 * 
 */

/*class User_Chat
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ChatId { get; set; }
}
 
public class Message
{
    public int Id { get; set; }
    public User_Chat UserChat { get; set; }
}*/

/*
 * user_chat: id user_id chat_id
 * message: 
 * 
 */