using System;


namespace F10Y.L0022.Q000
{
    public static class Instances
    {
        public static L0000.ICancellationTokens CancellationTokens => L0000.CancellationTokens.Instance;
        public static L0000.IEnumerableOperator EnumerableOperator => L0000.EnumerableOperator.Instance;
        public static L0000.IFileOperator FileOperator => L0000.FileOperator.Instance;
        public static L0004.L000.IFilePaths FilePaths => L0004.L000.FilePaths.Instance;
        public static ILoggers Loggers => L0022.Loggers.Instance;
        public static L0019.INotepadPlusPlusOperator NotepadPlusPlusOperator => L0019.NotepadPlusPlusOperator.Instance;
        public static INuGetOperator NuGetOperator => L0022.NuGetOperator.Instance;
        public static Z0000.INuGetPackageIDs NuGetPackageIDs => Z0000.NuGetPackageIDs.Instance;
        public static INuGetSources NuGetSources => L0022.NuGetSources.Instance;
        public static IPackageMetadataResourceOperator PackageMetadataResourceOperator => L0022.PackageMetadataResourceOperator.Instance;
        public static IPackageSearchMetadataOperator PackageSearchMetadataOperator => L0022.PackageSearchMetadataOperator.Instance;
        public static ISourceRepositoryOperator SourceRepositoryOperator => L0022.SourceRepositoryOperator.Instance;
    }
}