using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.Corcyra;
using R5T.Francia;
using R5T.Sindia;
using R5T.Siscia;


namespace R5T.Aestia
{
    public interface IAnomalyRepository
    {
        /// <summary>
        /// Creates a new anomaly identity.
        /// </summary>
        Task<AnomalyIdentity> New();


        Task SetReportedUTC(AnomalyIdentity anomaly, DateTime dateTime);

        Task<DateTime> GetReportedUTC(AnomalyIdentity anomaly);


        /// <summary>
        /// Adds an image file to the anomaly.
        /// There can be multiple images per anomaly.
        /// </summary>
        Task AddImageFile(AnomalyIdentity anomaly, ImageFileIdentity imageFile);

       Task<IEnumerable<ImageFileIdentity>> GetImageFiles(AnomalyIdentity anomalyIdentity);


        /// <summary>
        /// An anomaly has only one reported location.
        /// </summary>
        Task SetReportedLocation(AnomalyIdentity anomaly, LocationIdentity reportedLocation);

        Task<LocationIdentity> GetReportedLocation(AnomalyIdentity anomaly);


        Task SetReporterLocation(AnomalyIdentity anomaly, LocationIdentity reporterLocation);

        /// <summary>
        /// An anomaly might not have a reporter location. Perhaps the reporter turned off location services!
        /// </summary>
        Task<(bool HasReporterLocation, LocationIdentity LocationIdentity)> HasReporterLocation(AnomalyIdentity anomaly);

        Task<LocationIdentity> GetReporterLocation(AnomalyIdentity anomaly);


        Task<bool> ExistsTextItem(AnomalyIdentity anomaly, TextItemTypeIdentity textItemType);

        Task SetTextItem(AnomalyIdentity anomaly, TextItemTypeIdentity textItemType, TextItemIdentity textItem);

        Task<TextItemIdentity> GetTextItem(AnomalyIdentity anomaly, TextItemTypeIdentity textItemType);

        Task<IEnumerable<Tuple<TextItemTypeIdentity, TextItemIdentity>>> GetTextItems(AnomalyIdentity anomaly);
    }
}
