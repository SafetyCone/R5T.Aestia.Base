using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.Francia;
using R5T.Magyar;
using R5T.Sindia;


namespace R5T.Aestia
{
    public static class IAnomalyRepositoryExtensions
    {
        /// <summary>
        /// Creates a new anomaly identity.
        /// Uses the static <see cref="AnomalyIdentity.New()"/> functionality.
        /// </summary>
        public static async Task<AnomalyIdentity> New(this IAnomalyRepository anomalyRepository)
        {
            var anomalyIdentity = AnomalyIdentity.New();

            await anomalyRepository.AddAsync(anomalyIdentity);

            return anomalyIdentity;
        }

        public static async Task AddOnlyIfNotExistsAsync(this IAnomalyRepository anomalyRepository, AnomalyIdentity anomalyIdentity)
        {
            var exists = await anomalyRepository.ExistsAsync(anomalyIdentity);
            if (!exists)
            {
                await anomalyRepository.AddAsync(anomalyIdentity);
            }
        }

        public static async Task<List<(AnomalyIdentity AnomalyIdentity, WasFound<ImageFileIdentity> ImageFileIdentityWasFound)>> GetSingleImageForAnomalies(
            this IAnomalyRepository anomalyRepository,
            IEnumerable<AnomalyIdentity> anomalyIdentities)
        {
            var imageFileIdentityListByAnomalyIdentity = await anomalyRepository.GetImageFilesForAnomalies(anomalyIdentities);

            WasFound<ImageFileIdentity> DetermineIfWasFound(List<ImageFileIdentity> imageFileIdentities)
            {
                var firstOrDefault = imageFileIdentities.FirstOrDefault();

                var wasFound = WasFound.From(firstOrDefault);
                return wasFound;
            }

            var output = imageFileIdentityListByAnomalyIdentity
                .Select(x => (x.Key, DetermineIfWasFound(x.Value)))
                .ToList();

            return output;
        }

        public static async Task<WasFound<ImageFileIdentity>> GetSingleImageForAnomaly(
            this IAnomalyRepository anomalyRepository,
            AnomalyIdentity anomalyIdentity)
        {
            var anomalyIdentities = EnumerableHelper.From(anomalyIdentity);

            var singleImageForAnomalies = await anomalyRepository.GetSingleImageForAnomalies(anomalyIdentities);

            var singleImageForAnomaly = singleImageForAnomalies.First();

            var output = singleImageForAnomaly.ImageFileIdentityWasFound;
            return output;
        }

        public static async Task<Dictionary<AnomalyIdentity, WasFound<ImageFileIdentity>>> GetSingleImageForAnomaliesByAnomalyIdentity(
            this IAnomalyRepository anomalyRepository,
            IEnumerable<AnomalyIdentity> anomalyIdentities)
        {
            var singleImageForAnomalies = await anomalyRepository.GetSingleImageForAnomalies(anomalyIdentities);

            var output = singleImageForAnomalies
                .ToDictionary(
                    x => x.AnomalyIdentity,
                    x => x.ImageFileIdentityWasFound);

            return output;
        }
    }
}
