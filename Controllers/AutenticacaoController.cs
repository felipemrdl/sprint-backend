using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sprint_backend.Business.Interface;

namespace sprint_backend.Controllers
{
    public class AutenticacaoController : BaseController
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService _autenticacaoService)
        {
            this._autenticacaoService = _autenticacaoService ?? throw new ArgumentNullException(nameof(_autenticacaoService));
        }

        [AllowAnonymous]
        [HttpPost("{login}/{senha}")]
        public async Task<IActionResult> Login(string login, string senha){
            try{
                await _autenticacaoService.RecuperarToken(login, senha);
                return Sucesso();
            }
            catch(Exception ex)
            { return Falha(ex.Message); }
        }
    }
}