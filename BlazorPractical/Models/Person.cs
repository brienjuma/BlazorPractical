using System.ComponentModel.DataAnnotations;

namespace BlazorPractical.Models;

public record class Person
{
    [Required(ErrorMessage = "Person ID is required")]
    public string PersonId { get; set; } = string.Empty;

    [Required(ErrorMessage = "First Name is required")]
    [StringLength(50, ErrorMessage = "First Name can't be longer than 50 characters")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required")]
    [StringLength(50, ErrorMessage = "Last Name can't be longer than 50 characters")]
    public string LastName { get; set; } = string.Empty;
}
