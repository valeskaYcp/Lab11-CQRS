namespace App.Application.Response.DTOs;

public class ResponseDto
{
    public Guid ResponseId { get; set; }
    public Guid TicketId { get; set; }
    public string TicketTitle { get; set; } = null!;
    public Guid ResponderId { get; set; }
    public string ResponderName { get; set; } = null!;
    public string Message { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}