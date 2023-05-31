using DemoCyberSecurite.Api.Domain.Commands;
using DemoCyberSecurite.Api.Domain.Entities;
using DemoCyberSecurite.Api.Domain.Mappers;
using DemoCyberSecurite.Api.Domain.Queries;
using DemoCyberSecurite.Api.Domain.Repositories;
using System.Data;
using Tools.Database;

namespace DemoCyberSecurite.Api.Domain.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly IDbConnection _dbConnection;

        public AuthService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Utilisateur? Handle(AuthentifierQuery query)
        {
            return _dbConnection.ExecuteReader("CSP_Authentifier", dr => dr.ToUtilisateur(), true, query).SingleOrDefault();
        }

        public void Handle(EnregistrementCommand command)
        {
            _dbConnection.ExecuteNonQuery("CSP_Enregistrement", true, command);
            
        }
    }
}
