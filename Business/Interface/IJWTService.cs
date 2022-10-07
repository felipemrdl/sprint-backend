using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using sprint_backend.Domain.Infraestrutura;

namespace sprint_backend.Business.Interface
{
    public interface IJWTService
    {
        JsonWebToken CreateJsonWebToken(List<Claim> claims);
    }
}