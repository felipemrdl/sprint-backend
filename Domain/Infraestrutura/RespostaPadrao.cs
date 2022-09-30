using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sprint_backend.Domain.Infraestrutura
{
    public class RespostaPadrao
    {
        public object Data { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}