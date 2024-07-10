using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAPIFornecedor.Models;

namespace WebAPIFornecedor.Controllers
{
    [Route("api/Token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] Token login)
        {
            if (login.Usuario == "admin" && login.Senha == "admin")
            {
                var token = GerarTokenJWT();

                return Ok(new { token });
            }

            return BadRequest(new { mensagem = "Credenciais inválidas, verifique seu nome de usuário e senha." });
        }

        private string GerarTokenJWT()
        {
            string chaveSecreta = "6e3af936-2763-46c2-8fdd-3b47c307b202";

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "nome_empresa",
                audience: "nome_aplicacao",
                claims: null,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credencial
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
