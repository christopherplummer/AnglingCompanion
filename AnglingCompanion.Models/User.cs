using AnglingCompanion.Models.Abstractions;

namespace AnglingCompanion.Models;

public class User : Resource
{
    public string Username { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public Profile Profile { get; set; }
}

public class Profile
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ProfilePicture { get; set; }
}