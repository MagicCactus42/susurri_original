using System.ComponentModel.DataAnnotations;

namespace Susurri.Core.Entities;

public class ChatMessage
{
    [Required]
    public int GroupId { get; init; }
    public int Id { get; init; }
    public string Content { get; init; }
    public string SenderUsername { get; init; }
    
    public string RecipientUsername { get; init; }
    public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
}