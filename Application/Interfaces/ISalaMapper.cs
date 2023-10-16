﻿using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISalaMapper
    {
        Task<Response.Sala> GetSalaResponse(Domain.Entities.Sala sala);
    }
}