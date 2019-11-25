using System;
using System.Collections.Generic;

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
        AnomalyIdentity New();


        void SetReportedUTC(AnomalyIdentity anomaly, DateTime dateTime);

        DateTime GetReportedUTC(AnomalyIdentity anomaly);


        /// <summary>
        /// Adds an image file to the anomaly.
        /// There can be multiple images per anomaly.
        /// </summary>
        void AddImageFile(AnomalyIdentity anomaly, ImageFileIdentity imageFile);

        IEnumerable<ImageFileIdentity> GetImageFiles(AnomalyIdentity anomalyIdentity);


        /// <summary>
        /// An anomaly has only one reported location.
        /// </summary>
        void SetReportedLocation(AnomalyIdentity anomaly, LocationIdentity reportedLocation);

        LocationIdentity GetReportedLocation(AnomalyIdentity anomaly);


        void SetReporterLocation(AnomalyIdentity anomaly, LocationIdentity reporterLocation);

        /// <summary>
        /// An anomaly might not have a reporter location. Perhaps the reporter turned off location services!
        /// </summary>
        bool HasReporterLocation(AnomalyIdentity anomaly, out LocationIdentity reporterLocation);

        LocationIdentity GetReporterLocation(AnomalyIdentity anomaly);


        void SetTextItem(AnomalyIdentity anomaly, TextItemTypeIdentity textItemType, TextItemIdentity textItem);

        TextItemIdentity GetTextItem(AnomalyIdentity anomaly, TextItemTypeIdentity textItemType);

        IEnumerable<Tuple<TextItemTypeIdentity, TextItemIdentity>> GetTextItems(AnomalyIdentity anomaly);
    }
}
