using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public abstract class ServiceBase<TService>
    {
        protected readonly ILogger<TService> _logger;
        protected readonly IMapper _mapper;

        protected ServiceBase(IMapper mapper, ILogger<TService> logger)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
