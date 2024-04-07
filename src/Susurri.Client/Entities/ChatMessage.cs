namespace Susurri.Client.Entities;

public class ChatMessage
{
    public int GroupId { get; init; }
    public int Id { get; private set; }
    public string Content { get; init; }
    public string SenderUsername { get; init; }
    public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
}