using DemoCyberSecurite.Api.Domain.Commands;
using DemoCyberSecurite.Api.Domain.Entities;
using DemoCyberSecurite.Api.Domain.Queries;
using DemoCyberSecurite.Api.Domain.Repositories;
using DemoCyberSecurite.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Tools.Encryption;

namespace DemoCyberSecurite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly RSAEncryptorTool _encryptorTool;

        public AuthController(IAuthRepository authRepository, RSAEncryptorTool encryptorTool)
        {
            _authRepository = authRepository;
            _encryptorTool = encryptorTool;
        }

        [HttpPost("Enregistrer")]
        public IActionResult Enregistrer([FromBody] EnregistrementUtilisateurDto dto)
        {
            try
            {
                _authRepository.Handle(new EnregistrementCommand(dto.Nom, dto.Prenom, dto.Email, _encryptorTool.Decrypt(dto.Passwd)));
                return NoContent();
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(new { ex.Message });
#else
                return BadRequest();
#endif
            }
        }

        [HttpPost("Authentifier")]
        public IActionResult Authentifier([FromBody] AuthentifierUtilisateurDto dto)
        {
            try
            {                
                Utilisateur? utilisateur = _authRepository.Handle(new AuthentifierQuery(dto.Email, _encryptorTool.Decrypt(dto.Passwd)));

                if (utilisateur is null)
                {
                    return NotFound();
                }
                return Ok(new UtilisateurDto(utilisateur));
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(new { ex.Message });
#else
                return BadRequest();
#endif
            }
        }
    }
}
