﻿using Application.DTOs.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteUseCase
    {
        Task<ClienteResponse> Salvar(ClienteRequest request);
    }
}
