using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sprint_backend.Domain.Infraestrutura;

namespace sprint_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController
    {
        public IActionResult Sucesso(object dados = null, string mensagem = "Requisição completada com sucesso.")
        {
            return new OkObjectResult(new RespostaPadrao{
                Data = dados,
                Mensagem = mensagem,
                Sucesso = true
            });
        }

        public IActionResult Falha(string mensagem = "Requisição falhou!")
        {
            return new BadRequestObjectResult(new RespostaPadrao{
                Data = null,
                Mensagem = mensagem
            });
        }
    }
}