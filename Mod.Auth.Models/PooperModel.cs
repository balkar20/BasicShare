namespace Mod.Auth.Models;

public record PooperModel(string Id, int AmountOfPoops, string? PooperAlias, string? Description, List<string>? tags);