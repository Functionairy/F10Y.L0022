using System;


namespace F10Y.L0022
{
    public class PackageMetadataResourceOperator : IPackageMetadataResourceOperator
    {
        #region Infrastructure

        public static IPackageMetadataResourceOperator Instance { get; } = new PackageMetadataResourceOperator();


        private PackageMetadataResourceOperator()
        {
        }

        #endregion
    }
}
