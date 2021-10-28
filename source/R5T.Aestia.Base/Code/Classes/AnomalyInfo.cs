using System;
using System.Collections.Generic;

using R5T.Corcyra;
using R5T.Francia;
using R5T.Magyar;
using R5T.Sindia;
using R5T.Siscia;


namespace R5T.Aestia
{
    public class AnomalyInfo
    {
        public AnomalyIdentity AnomalyIdentity { get; set; }
        public List<CatchmentIdentity> CatchmentIdentities { get; set; }
        public List<ImageFileIdentity> ImageFileIdentities { get; set; }
        public LocationIdentity ReportedLocationIdentity { get; set; }
        public DateTime ReportedUTC { get; set; }
        public LocationIdentity ReporterLocationIdentity { get; set; }
        public List<TextItemIdentity> TextItemsIdentities { get; set; }
        public int UpvotesCount { get; set; }

        // Extension properties.
        public bool HasReportedLocation => NullHelper.IsNonNull(this.ReportedLocationIdentity);
        public bool HasReporterLocation => NullHelper.IsNonNull(this.ReporterLocationIdentity);
        public bool HasUpvotes => this.UpvotesCount > 0;
    }
}
