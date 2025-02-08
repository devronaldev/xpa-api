using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xpa_api.Contexts;
using xpa_api.DTOs;
using xpa_api.Models.Tables;
using xpa_api.Services;

namespace xpa_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(AppDbContext context) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(DtoLogin model)
        {
            if (!ModelState.IsValid) return BadRequest(new
            {
                    message = "Erro ao enviar dados de login",
                    error = "Modelo de dados inválido",
                    endpoint = "api/user/login",
                    method = "post"
            });

            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new
                {
                    message = "Senha e/ou e-mail estão vazios",
                    error = "Os valores de senha ou email chegaram vazios ou nulos.",
                    endpoint = "api/user/login",
                    method = "post"
                });
            }

            try
            {
                var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == model.Email);
                // Implementar Hashing de senhas e verificador de igualdade com BCrypt
                if (user == null || user.Password != model.Password)
                {
                    return Unauthorized(new
                    {
                        message = "Senha ou e-mail incorretos.",
                        error = "A senha e/ou o e-mail estão incorretos",
                        endpoint = "api/user/login",
                        method = "post"
                    });
                }
                
                return TokenServices.GenerateJwtToken(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var users = await context.Users.ToListAsync();

                if (users.Count == 0)
                {
                    return NotFound(new 
                    {
                        message = "Não foram encontrados usuários.",
                        error = "Pesquisa nula ou zerada",
                        endpoint = "api/user",
                        method = "get"
                    });
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Erro ao executar busca, por favor tente novamente ou contacte o suporte.",
                    error = ex.Message,
                    endpoint = "api/user",
                    method = "get"
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Erro ao salvar um usuário.",
                    error = "O usuário foi enviado vazio.",
                    endpoint = "api/user",
                    method = "post"
                });
            }

            try
            {
                context.Add(model);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Erro inesperado ao salvar um usuário. Por favor, contacte o suporte.",
                    error = ex.Message,
                    endpoint = "api/user",
                    method = "post"
                });
            }
        }
    }
}
