using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sprint_backend.Domain.Dto;

namespace sprint_backend.Business.Interface
{
    public interface ITarefaService
    {
        Task NovaTarefa(int usuarioId, TarefaDto dto);

        Task<TarefaDto> RecuperarTarefa(int tarefaId);

        Task AtualizarStatusTarefa(int tarefaId, int statusId);

        Task ComentarTarefa(TarefaComentarioDto dto);
    }
}