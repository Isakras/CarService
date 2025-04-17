using System.ComponentModel.DataAnnotations;

namespace Invoice.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}