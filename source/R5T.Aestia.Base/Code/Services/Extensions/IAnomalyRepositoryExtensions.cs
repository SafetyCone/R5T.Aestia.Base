using System;
using System.Threading.Tasks;

using R5T.Sindia;

namespace R5T.Aestia
{
    public static class IAnomalyRepositoryExtensions
    {
        public static async Task AddOnlyIfNotExistsAsync(this IAnomalyRepository anomalyRepository, AnomalyIdentity anomalyIdentity)
        {
            var exists = await anomalyRepository.ExistsAsync(anomalyIdentity);
            if (!exists)
            {
                await anomalyRepository.AddAsync(anomalyIdentity);
            }
        }
    }
}
