using System;


namespace F10Y.L0022
{
    public class PackageSearchResourceOperator : IPackageSearchResourceOperator
    {
        #region Infrastructure

        public static IPackageSearchResourceOperator Instance { get; } = new PackageSearchResourceOperator();


        private PackageSearchResourceOperator()
        {
        }

        #endregion
    }
}
