using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using xpa_api.Models.Tables;
using static System.Security.Claims.ClaimTypes;

namespace xpa_api.Services
{
    public class TokenServices
    {
        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = GetKey();

            var tokenDescriptor = new SecurityTokenDescriptor();
            tokenDescriptor.Subject.AddClaim(new Claim(Email, user.Email));
            tokenDescriptor.Subject.AddClaim(new Claim(Name, user.Name));
            tokenDescriptor.Subject.AddClaim(new Claim(Role, user.Seniority.ToString()));

            tokenDescriptor.Expires = DateTime.UtcNow.AddHours(12);
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static byte[] GetKey()
        {
            var secret = Environment.GetEnvironmentVariable("SECRET-KEY");

            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new KeyNotFoundException("Chave secreta não configurada no ambiente.");
            }
            
            return Encoding.ASCII.GetBytes(secret);
        }

        public static ClaimsPrincipal GetClaims(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = GetKey();

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                var principal =
                    tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Erro ao carregar Token: " + ex.Message);
                //Implementar log de erro...
            }
        }

        public static string? GetEmail(ClaimsPrincipal principal)
        {
            var emailClaim = principal.FindFirst(ClaimTypes.Email)?.Value;
            return string.IsNullOrWhiteSpace(emailClaim) ? null : emailClaim;
        }
    }
}