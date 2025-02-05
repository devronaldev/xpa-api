using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xpa_api.Contexts;
using xpa_api.Models.Tables;

namespace xpa_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetUsers()
        {
            try
            {
                var users = await _context.Users.ToListAsync();

                if (users == null || users.Count == 0)
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
        public async Task<ActionResult<dynamic>> CreateUser(User model)
        {
            if (model == null)
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
                _context.Add(model);
                await _context.SaveChangesAsync();
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
