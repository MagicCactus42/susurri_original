using Susurri.Client.Hubs;

namespace Susurri.Client.Entities;


public class ChatMessage
{
    public int GroupId { get; set; }
    public int Id { get; private set; }
    public string Content { get; set; }
    public string SenderUsername { get; set; }
    public DateTime Timestamp { get; private set; }
    

    public ChatMessage()
    {
        Timestamp = DateTime.UtcNow;
    }
    
}