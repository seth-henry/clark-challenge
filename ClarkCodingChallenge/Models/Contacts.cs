using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization.Infrastructure;

public class Contacts
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName {get; set; }
    
    [Required]
    [Display(Name = "Last Name")]
    public string LastName {get; set; }

    public override string ToString()
    {
        return string.Format("{0} - {1} - {2}", LastName, FirstName, Email);
    }
}