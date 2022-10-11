using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sprint_backend.Business.Interface;
using sprint_backend.Domain.Dto;
using sprint_backend.Domain.Model;
using sprint_backend.EF;

namespace sprint_backend.Business.Service
{
    public class TarefaService : ITarefaService
    {
        private readonly Context _context;
        private readonly ISprintService _sprintService;

        public TarefaService(Context _context
        , ISprintService _sprintService)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
            this._sprintService = _sprintService ?? throw new ArgumentNullException(nameof(_sprintService));
        }

        public async Task NovaTarefa(int usuarioId, TarefaDto dto) {
            try {

                var existeSprint = await _sprintService.ExisteSprint(dto.SprintId);
                
                if(!existeSprint)
                { throw new Exception($"Não foi possível encontrar a sprint [{dto.SprintId}]."); }
                
                var novaTarefa = new Tarefa {
                    UsuarioId = usuarioId,
                    Descricao = dto.Descricao,
                    Titulo = dto.Titulo,
                    SprintId = dto.SprintId
                };

                _context.Tarefa.Add(novaTarefa);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { var exception = ex; throw; }
        }

        private async Task<Tarefa> RecuperarTarefaModel(int tarefaId)
            => await _context.Tarefa.FirstOrDefaultAsync(f => f.Id == tarefaId);

        public async Task<TarefaDto> RecuperarTarefa(int tarefaId)
            => await _context.Tarefa.Where(f => f.Id == tarefaId)
            .Select(s => new TarefaDto {
                Descricao = s.Descricao,
                SprintId = s.SprintId,
                Titulo = s.Titulo,
                TarefaStatusId = s.TarefaStatusId,
                Comentarios = s.TarefaComentarios.Select(tc => new TarefaComentarioDto{
                    DataComentario = tc.DataComentario,
                    Descricao = tc.Descricao,
                    TarefaId = tc.TarefaId
                }).ToList()
            }).FirstOrDefaultAsync();

        public async Task AtualizarStatusTarefa(int tarefaId, int statusId) {
            try {
                var tarefa = await RecuperarTarefaModel(tarefaId);

                if(tarefa is null)
                { throw new Exception($"Não foi possível recuperar a tarefa [{tarefa}]"); }

                tarefa.TarefaStatusId = statusId;
            }
            catch(Exception ex)
            { var exception = ex; throw; }
        }

        public async Task ComentarTarefa(TarefaComentarioDto dto) {
            try {
                var tarefa = await RecuperarTarefaModel(dto.TarefaId);
                
                tarefa.TarefaComentarios.Add(new TarefaComentario{
                    Descricao = dto.Descricao,
                    DataComentario = dto.DataComentario
                });

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { var exception = ex; throw; }
        }
    }
}