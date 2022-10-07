using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Infraestrutura
{
    public class JsonWebToken
    {
        /// <summary>
        /// Token de acesso
        /// </summary>
        public string AccessToken { get; set; }
        
        /// <summary>
        /// Tipo de token
        /// </summary>
        public string TokenType { get; set; } = "bearer";
        
        /// <summary>
        /// Tempo até que seja expirado
        /// </summary>
        public DateTime ExpiresIn { get; set; }

        /// <summary>
        /// <see cref="RefreshTokenDTO"/>
        /// </summary>
        public RefreshTokenDTO Refresh { get; set; }
    }

    public class RefreshTokenDTO
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
        
        /// <summary>
        /// Data de validade
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}