using System;


namespace F10Y.L0022.Q000
{
    public class NuGetExperiments : INuGetExperiments
    {
        #region Infrastructure

        public static INuGetExperiments Instance { get; } = new NuGetExperiments();


        private NuGetExperiments()
        {
        }

        #endregion
    }
}


namespace F10Y.L0022.Q000.Deprecated
{
    public class NuGetExperiments : INuGetExperiments
    {
        #region Infrastructure

        public static INuGetExperiments Instance { get; } = new NuGetExperiments();


        private NuGetExperiments()
        {
        }

        #endregion
    }
}