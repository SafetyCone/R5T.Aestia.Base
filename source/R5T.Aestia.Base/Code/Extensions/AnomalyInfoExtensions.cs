using System;
using System.Linq;


namespace R5T.Aestia
{
    public static class AnomalyInfoExtensions
    {
        public static bool HasAnyCatchments(this AnomalyInfo anomalyInfo)
        {
            var hasAnyCatchments = anomalyInfo.CatchmentIdentities.Any();
            return hasAnyCatchments;
        }
    }
}
