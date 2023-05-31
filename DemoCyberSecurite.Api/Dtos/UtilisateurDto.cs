using DemoCyberSecurite.Api.Domain.Entities;

namespace DemoCyberSecurite.Api.Dtos
{
    public class UtilisateurDto
    {
        public UtilisateurDto(Utilisateur utilisateur)
        {
            Id = utilisateur.Id;
            Nom = utilisateur.Nom;
            Prenom = utilisateur.Prenom;
            Email = utilisateur.Email;
        }

        public int Id { get; init; }
        public string Nom { get; init; }
        public string Prenom { get; init; }
        public string Email { get; init; }

    }
}
