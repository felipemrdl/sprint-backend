using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace sprint_backend.Domain.Infraestrutura
{
    public class JwtSettings
    {
        /// <summary>
        /// Audiencia
        /// </summary>
        public string Audience { get; }
        
        /// <summary>
        /// Issuer
        /// </summary>
        public string Issuer { get; }
        
        /// <summary>
        /// Validade do token (em minutos)
        /// </summary>
        public int ValidForMinutes { get; }
        
        /// <summary>
        /// Validade do RefreshToken (em minutos)
        /// </summary>
        public int RefreshTokenValidForMinutes { get; }

        /// <summary>
        /// Objeto que contem as credenciais de acesso.
        /// </summary>
        public SigningCredentials SigningCredentials { get; }

        /// <summary>
        /// Issued at
        /// </summary>
        public DateTime IssuedAt => DateTime.UtcNow;
        
        /// <summary>
        /// NotBefore 
        /// </summary>
        public DateTime NotBefore => IssuedAt;
        
        /// <summary>
        /// Tempo de validade do Token
        /// </summary>
        public DateTime AccessTokenExpiration => IssuedAt.AddMinutes(ValidForMinutes);
        
        /// <summary>
        /// Tempo de validade do refresh token
        /// </summary>
        public DateTime RefreshTokenExpiration => IssuedAt.AddMinutes(RefreshTokenValidForMinutes);

        /// <summary>
        /// Construtor do objeto.
        /// </summary>
        /// <param name="configuration"></param>
        public JwtSettings(IConfiguration configuration)
        {
            Issuer = configuration["TokenManagement:Issuer"];
            Audience = configuration["TokenManagement:Audience"];
            ValidForMinutes = Convert.ToInt32(configuration["TokenManagement:ValidForMinutes"]);
            RefreshTokenValidForMinutes = Convert.ToInt32(configuration["TokenManagement:RefreshTokenValidForMinutes"]);

            var secretKey = configuration["TokenManagement:Secret"];
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha512);

        }
    }
}