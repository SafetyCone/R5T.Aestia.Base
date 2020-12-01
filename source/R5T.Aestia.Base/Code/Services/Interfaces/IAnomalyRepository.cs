using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.Corcyra;
using R5T.Francia;
using R5T.Orgerben;
using R5T.Sindia;
using R5T.Siscia;


namespace R5T.Aestia
{
    public interface IAnomalyRepository
    {
        Task AddAsync(AnomalyIdentity anomalyIdentity);

        Task<bool> ExistsAsync(AnomalyIdentity anomalyIdentity);

        Task SetReportedUTC(AnomalyIdentity anomalyIdentity, DateTime dateTime);

        Task<DateTime> GetReportedUTC(AnomalyIdentity anomalyIdentity);

        /// <summary>
        /// Get all information the repository contains about the anomaly.
        /// </summary>
        Task<AnomalyInfo> GetAnomalyInfo(AnomalyIdentity anomalyIdentity);

        Task<List<AnomalyInfo>> GetAnomalyInfos(List<AnomalyIdentity> anomalyIdentities);

        Task<int> GetUpvoteCount(AnomalyIdentity anomalyIdentity);

        Task SetUpvoteCount(AnomalyIdentity anomalyIdentity, int upvoteCount);


        #region Catchment

        Task<(bool HasCatchment, CatchmentIdentity CatchmentIdentity)> HasCatchment(AnomalyIdentity anomalyIdentity);

        Task<List<CatchmentIdentity>> GetCatchments(AnomalyIdentity anomalyIdentity);

        Task AddCatchment(AnomalyIdentity anomalyIdentity, CatchmentIdentity catchmentIdentity);

        Task<List<AnomalyIdentity>> GetAllAnomaliesInCatchment(CatchmentIdentity catchmentIdentity);

        #endregion


        #region Organization

        Task SetOrganization(AnomalyIdentity anomalyIdentity, OrganizationIdentity organizationIdentity);

        #endregion


        #region Image File

        /// <summary>
        /// Adds an image file to the anomaly.
        /// There can be multiple images per anomaly.
        /// </summary>
        Task AddImageFile(AnomalyIdentity anomalyIdentity, ImageFileIdentity imageFileIdentity);

        Task<List<ImageFileIdentity>> GetImageFiles(AnomalyIdentity anomalyIdentity);

        Task<Dictionary<AnomalyIdentity, List<ImageFileIdentity>>> GetImageFilesForAnomalies(IEnumerable<AnomalyIdentity> anomalyIdentities);

        #endregion


        #region Reported and Reporter Location

        /// <summary>
        /// An anomaly has only one reported location.
        /// </summary>
        Task SetReportedLocation(AnomalyIdentity anomalyIdentity, LocationIdentity reportedLocationIdentity);

        Task<LocationIdentity> GetReportedLocationAsync(AnomalyIdentity anomalyIdentity);

        Task SetReporterLocation(AnomalyIdentity anomalyIdentity, LocationIdentity reporterLocation);

        /// <summary>
        /// An anomaly might not have a reporter location. Perhaps the reporter turned off location services!
        /// </summary>
        Task<(bool HasReporterLocation, LocationIdentity LocationIdentity)> HasReporterLocation(AnomalyIdentity anomalyIdentity);

        Task<LocationIdentity> GetReporterLocation(AnomalyIdentity anomalyIdentity);

        #endregion


        #region Text Items

        Task<bool> ExistsTextItem(AnomalyIdentity anomalyIdentity, TextItemTypeIdentity textItemTypeIdentity);

        Task SetTextItem(AnomalyIdentity anomalyIdentity, TextItemTypeIdentity textItemTypeIdentity, TextItemIdentity textItemIdentity);

        Task<TextItemIdentity> GetTextItem(AnomalyIdentity anomalyIdentity, TextItemTypeIdentity textItemTypeIdentity);

        Task<List<Tuple<TextItemTypeIdentity, TextItemIdentity>>> GetTextItems(AnomalyIdentity anomalyIdentity);

        #endregion
    }
}
