using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacService;

namespace ZodiacService
{
    public class ZodiacService : Zodiac.ZodiacBase
    {
        private readonly ILogger<ZodiacService> _logger;
        public ZodiacService(ILogger<ZodiacService> logger)
        {
            _logger = logger;
        }

        public override Task<ZodiacReply> FindZodiac(ZodiacRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ZodiacReply
            {
                
            });
        }
    }
}
