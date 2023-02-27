using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class User
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = "";

        public List<string> SocialSkills { get; set; } = new List<string>();

        public List<Socials> SocialAccounts { get; set; } = new List<Socials>();

    }
    public class Socials
    {
        public string Type { get; set; } = "";

        public string Address { get; set; } = "";
    }
}
