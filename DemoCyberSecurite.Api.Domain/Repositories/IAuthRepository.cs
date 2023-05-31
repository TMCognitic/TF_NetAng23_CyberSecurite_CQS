using DemoCyberSecurite.Api.Domain.Commands;
using DemoCyberSecurite.Api.Domain.Entities;
using DemoCyberSecurite.Api.Domain.Queries;

namespace DemoCyberSecurite.Api.Domain.Repositories
{
    public interface IAuthRepository
    {
        Utilisateur? Handle(AuthentifierQuery query);
        void Handle(EnregistrementCommand command);
    }
}
