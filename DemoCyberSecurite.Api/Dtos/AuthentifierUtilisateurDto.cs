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
        [StringLength(20, MinimumLength = 8)]
        public string Passwd { get; set; }
    }
}
