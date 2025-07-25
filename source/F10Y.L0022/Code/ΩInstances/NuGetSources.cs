using System;


namespace F10Y.L0022
{
    public class NuGetSources : INuGetSources
    {
        #region Infrastructure

        public static INuGetSources Instance { get; } = new NuGetSources();


        private NuGetSources()
        {
        }

        #endregion
    }
}
