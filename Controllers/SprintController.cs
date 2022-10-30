using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sprint_backend.Business.Interface;

namespace sprint_backend.Controllers
{
    public class SprintController : BaseController
    {
        private readonly ISprintService _sprintService;

        public SprintController(ISprintService _sprintService){
            this._sprintService = _sprintService ?? throw new ArgumentNullException(nameof(_sprintService));
        }


        [HttpPost]
        public async Task<IActionResult> RecuperarSprints(){
            try {
                var dados = await _sprintService.RecuperarTodos();
                return Sucesso(dados);
            }
            catch(Exception ex)
            { return Falha(ex.Message); }
        }
    }
}