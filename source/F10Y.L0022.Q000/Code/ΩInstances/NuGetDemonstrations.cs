using System;


namespace F10Y.L0022.Q000
{
    public class NuGetDemonstrations : INuGetDemonstrations
    {
        #region Infrastructure

        public static INuGetDemonstrations Instance { get; } = new NuGetDemonstrations();


        private NuGetDemonstrations()
        {
        }

        #endregion
    }
}
