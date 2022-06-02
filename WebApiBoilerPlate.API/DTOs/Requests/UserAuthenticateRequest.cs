using System.ComponentModel.DataAnnotations;


public class UserAuthenticateRequest
{

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

}

