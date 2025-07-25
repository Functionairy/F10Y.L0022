using System;


namespace F10Y.L0022
{
    public static class Instances
    {
        public static L0000.ICancellationTokens CancellationTokens => L0000.CancellationTokens.Instance;
        public static ILoggers Loggers => L0022.Loggers.Instance;
        public static INuGetSources NuGetSources => L0022.NuGetSources.Instance;
        public static IPackageMetadataResourceOperator PackageMetadataResourceOperator => L0022.PackageMetadataResourceOperator.Instance;
        public static IPackageSearchMetadataOperator PackageSearchMetadataOperator => L0022.PackageSearchMetadataOperator.Instance;
        public static IPackageSearchResourceOperator PackageSearchResourceOperator => L0022.PackageSearchResourceOperator.Instance;
        public static ISearchFilterOperator SearchFilterOperator => L0022.SearchFilterOperator.Instance;
        public static ISourceRepositoryOperator SourceRepositoryOperator => L0022.SourceRepositoryOperator.Instance;
        public static L0000.IStringOperator StringOperator => L0000.StringOperator.Instance;
    }
}