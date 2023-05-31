namespace DemoCyberSecurite.Api.Domain.Commands
{
    public class EnregistrementCommand
    {
        public string Nom { get; init; }
        public string Prenom { get; init; }
        public string Email { get; init; }
        public string Passwd { get; init; }
        public EnregistrementCommand(string nom, string prenom, string email, string passwd)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Passwd = passwd;
        }
    }
}
