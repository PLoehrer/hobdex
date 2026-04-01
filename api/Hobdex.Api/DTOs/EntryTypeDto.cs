namespace Hobdex.Api.DTOs;

public record EntryTypeDto(int Id, string Name, string? Color, bool IsGlobal);
public record CreateEntryTypeDto(int UserId, string Name, string? Color, bool IsGlobal);