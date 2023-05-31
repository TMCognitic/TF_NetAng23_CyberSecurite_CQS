namespace DemoCyberSecurite.Api.Domain.Queries
{
    public class AuthentifierQuery
    {
        public string Email { get; init; }
        public string Passwd { get; init; }
        public AuthentifierQuery(string email, string passwd)
        {
            Email = email;
            Passwd = passwd;
        }
    }
}
