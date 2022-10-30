using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sprint_backend.Business.Interface;
using sprint_backend.Domain;
using sprint_backend.Domain.Model;
using sprint_backend.EF;

namespace sprint_backend.Business.Service
{
    public class SprintService : ISprintService
    {
        private readonly Context _context;

        public SprintService(Context _context)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public async Task NovaSprint(int usuarioId, SprintDto dto) {
            try {
                
                var novaSprint = new Sprint {
                    Nome = dto.Nome,
                    DataInicio = dto.DataInicio,
                    DataFim = dto.DataFim
                };

                novaSprint.UsuarioSprint.Add(new UsuarioSprint{
                    UsuarioId = usuarioId
                });

                _context.Sprint.Add(novaSprint);

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { var exception = ex; throw; }
        }

        public async Task<bool> ExisteSprint(int sprintId)
            => await _context.Sprint.AnyAsync(a => a.Id == sprintId);

        public async Task<List<SprintDto>> RecuperarTodos(){
            try {
                return await  _context.Sprint
                .Where(w => w.DataFim != null)
                .Select(s => new SprintDto{
                    DataFim = s.DataFim,
                    DataInicio = s.DataInicio,
                    Nome = s.Nome,
                    Id = s.Id
                }).ToListAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }
    }
}