using DemoCyberSecurite.Api.Domain.Entities;
using System.Data;

namespace DemoCyberSecurite.Api.Domain.Mappers
{
    internal static class Mappers
    {
        internal static Utilisateur ToUtilisateur(this IDataRecord record)
        {
            return new Utilisateur(
                (int)record["Id"],
                (string)record["Nom"],
                (string)record["Prenom"],
                (string)record["Email"]);
        }
    }
}
