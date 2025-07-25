using System;


namespace F10Y.L0022
{
    public class PackageSearchMetadataOperator : IPackageSearchMetadataOperator
    {
        #region Infrastructure

        public static IPackageSearchMetadataOperator Instance { get; } = new PackageSearchMetadataOperator();


        private PackageSearchMetadataOperator()
        {
        }

        #endregion
    }
}
