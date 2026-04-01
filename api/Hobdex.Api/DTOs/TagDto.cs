namespace Hobdex.Api.DTOs;

public record TagDto(int Id, string Name, string? Color);
public record CreateTagDto(int UserId, string Name, string? Color);