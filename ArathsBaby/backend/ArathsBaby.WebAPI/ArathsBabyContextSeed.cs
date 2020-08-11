using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArathsBaby.WebAPI
{
    public class ArathsBabyContextSeed
    {
        public static async Task SeedAsync(ArathsBabyContext context,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            using (var contextTransaction = context.Database.BeginTransaction())
            {
                int retryForAvailability = retry.Value;
                try
                {
                    contextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (retryForAvailability < 10)
                    {
                        retryForAvailability++;
                        var log = loggerFactory.CreateLogger<ArathsBabyContextSeed>();
                        log.LogError(ex.Message);
                        await SeedAsync(context, loggerFactory, retryForAvailability);
                    }

                    contextTransaction.Rollback();
                }
            }
        }
    }
}
