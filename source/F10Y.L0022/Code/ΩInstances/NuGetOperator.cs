using System;


namespace F10Y.L0022
{
    public class NuGetOperator : INuGetOperator
    {
        #region Infrastructure

        public static INuGetOperator Instance { get; } = new NuGetOperator();


        private NuGetOperator()
        {
        }

        #endregion
    }
}
