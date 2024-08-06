namespace BlazorPractical.Models;

public record class Person
{
    public string PersonId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
