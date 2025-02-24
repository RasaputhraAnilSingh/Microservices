﻿using MediatR;
using Order.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Queries
{
    public class GetAllOrdersQueries : IRequest<IEnumerable<CreateOrderDTO>>
    {
    }
}
