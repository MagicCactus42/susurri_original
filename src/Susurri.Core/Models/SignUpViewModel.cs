using System.ComponentModel.DataAnnotations;

namespace Susurri.Core.Models;

public class SignUpViewModel
{
    [Required]
    public string Username { get; init; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; init; }
}