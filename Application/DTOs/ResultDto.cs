namespace Application.DTOs;

public record ResultDto
{
    public int Id { get; init; }
    public bool Success { get; init; }
    public string Message { get; init; }
}