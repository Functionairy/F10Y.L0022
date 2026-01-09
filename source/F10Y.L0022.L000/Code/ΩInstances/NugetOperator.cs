using System;


namespace F10Y.L0022.L000
{
    public class NugetOperator : INugetOperator
    {
        #region Infrastructure

        public static INugetOperator Instance { get; } = new NugetOperator();


        private NugetOperator()
        {
        }

        #endregion
    }
}
