using System.ComponentModel.DataAnnotations;

namespace DemoCyberSecurite.Api.Dtos
{
#nullable disable
    public class AuthentifierUtilisateurDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Passwd { get; set; }
    }
}
