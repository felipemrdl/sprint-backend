using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sprint_backend.Business.Interface;
using sprint_backend.EF;

namespace sprint_backend.Business.Service
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly Context _context;
        private readonly IJWTService _jwtService;

        public AutenticacaoService(Context _context
        , IJWTService _jwtService){
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
            this._jwtService = _jwtService ?? throw new ArgumentNullException(nameof(_jwtService));
        }

        public async Task<string> RecuperarToken(string login, string senha){
            try {
                var usuario = await _context.Usuario
                .Where(w => w.Login == login)
                .FirstOrDefaultAsync();

                

                if(usuario is null)
                { throw new Exception($"Usuário {login} não encontrado."); }
                else
                {
                    if(!usuario.Ativo)
                    { throw new Exception($"Usuário desativado, favor redefina sua senha."); }
                    
                    var tentativas = usuario.Tentativas; 
                    if(tentativas > 3)
                    {
                        usuario.Ativo = false;
                        await _context.SaveChangesAsync();
                        throw new Exception($"Tentativas excedidas - usuário {login} bloqueado.");
                    }
                    else {
                        throw new Exception($"Senha incorreta - Tentativa {tentativas} de 3");
                    }
                }
            }
            catch(Exception ex)
            { var exception = ex; throw; }
        }
    }
}