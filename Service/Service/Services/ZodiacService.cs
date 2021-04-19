using Grpc.Core;
using Microsoft.Extensions.Logging;
using Server.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacServer;

namespace ZodiacService
{
    public class ZodiacService : Zodiac.ZodiacBase
    {
        private readonly ZodiacOperations zodiacOperations = new ZodiacOperations();
        private readonly ILogger<ZodiacService> _logger;
        public ZodiacService(ILogger<ZodiacService> logger)
        {
            _logger = logger;
        }

        public override Task<ZodiacReply> FindZodiac(ZodiacRequest request, ServerCallContext context)
        {
            var zodiac = request.Zodiac;
            string zodiacName = zodiacOperations.CalculateZodiac(zodiac);

            _logger.Log(LogLevel.Information, "Calculated zodiac");

            return Task.FromResult(new ZodiacReply() { ZodiacName =  zodiacName});
        }
    }
}
