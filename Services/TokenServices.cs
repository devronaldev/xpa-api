using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using xpa_api.Models.Tables;

namespace xpa_api.Services
{
    public static class TokenServices
    {
        private const string EmailClaim = "Email";
        private const string NameClaim = "Name";
        private const string RoleClaim = "Role";

        public static string GenerateJwtToken(User user, int expirationHours = 12)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = GetJwtSecretKey();

            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, user.Seniority.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(expirationHours),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception e)
            {
                //Trabalhar com log de erro.
                throw new Exception("Erro ao gerar o token JWT: " + e.Message, e);
            }
        }
        
        private static byte[] GetJwtSecretKey()
        {
            var secret = Environment.GetEnvironmentVariable("JWTKEY");

            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new KeyNotFoundException("Secret key not configured in the environment.");
            }

            return Encoding.ASCII.GetBytes(secret);
        }

        public static ClaimsPrincipal GetClaims(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = GetJwtSecretKey();

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

                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error loading token: {ex.Message}");
                throw new SecurityTokenException("Error loading the token.", ex);
            }
        }

        public static string? GetEmailFromClaims(ClaimsPrincipal principal)
        {
            var emailClaim = principal.FindFirst(ClaimTypes.Email)?.Value;
            return string.IsNullOrWhiteSpace(emailClaim) ? null : emailClaim;
        }
    }
}