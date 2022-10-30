using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sprint_backend.Domain;

namespace sprint_backend.Business.Interface
{
    public interface ISprintService
    {
        Task NovaSprint(int usuarioId, SprintDto dto);
        Task<bool> ExisteSprint(int sprintId);
        Task<List<SprintDto>> RecuperarTodos();
    }
}