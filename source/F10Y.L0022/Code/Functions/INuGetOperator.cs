using System;
using System.Threading.Tasks;

using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

using F10Y.T0002;
using System.Collections.Generic;
using NuGet.Versioning;
using System.Linq;


namespace F10Y.L0022
{
    /// <summary>
    /// NuGet.org operator.
    /// </summary>
    [FunctionsMarker]
    public partial interface INuGetOperator
    {
        public async Task<bool> Exists_Package(
            string packageID,
            PackageSearchResource packageSearchResource,
            bool includePreRelease = IValues.IncludePreRelase_Default_Constant)
        {
            var searchResults = await Instances.PackageSearchResourceOperator.Search_Asynchronous(
                packageSearchResource,
                packageID,
                includePreRelease);

            var output = Instances.PackageSearchMetadataOperator.Any_WithPackageID(
                searchResults,
                packageID);

            return output;
        }

        public async Task<bool> Exists_Package(
            string packageID,
            SourceRepository sourceRepository,
            bool includePreRelease = IValues.IncludePreRelase_Default_Constant)
        {
            var packageSearchResource = await Instances.SourceRepositoryOperator.Get_PackageSearchResource_Asynchronous(sourceRepository);

            var output = await this.Exists_Package(
                packageID,
                packageSearchResource,
                includePreRelease);

            return output;
        }

        public async Task<bool> Exists_Package(
            string packageID,
            string source_CoreV3,
            bool includePreRelease = IValues.IncludePreRelase_Default_Constant)
        {
            var repository = Instances.SourceRepositoryOperator.Get_Repository_CoreV3(source_CoreV3);

            var output = await this.Exists_Package(
                packageID,
                repository,
                includePreRelease);

            return output;
        }

        public Task<bool> Exists_Package(
            string packageID,
            bool includePreRelease = IValues.IncludePreRelase_Default_Constant)
            => this.Exists_Package(
                packageID,
                Instances.NuGetSources.NuGet_org_CoreV3,
                includePreRelease);

        public async Task<DateTimeOffset> Get_PublicationTimestamp_Latest(
            string packageID,
            bool includePreRelease = IValues.IncludePreRelase_Default_Constant,
            bool includeUnlisted = IValues.IncludeUnlisted_Default_Constant)
        {
            var publicationTimestamps_ByVersion = await this.Get_PublicationTimestamps_ByVersion(
                packageID,
                includePreRelease,
                includeUnlisted);

            var output = publicationTimestamps_ByVersion.Values.Max();
            return output;
        }

        public async Task<(NuGetVersion Version, DateTimeOffset Publication)> Get_PublicationTimestampAndVersion_Latest(
            string packageID,
            bool includePreRelease = IValues.IncludePreRelase_Default_Constant,
            bool includeUnlisted = IValues.IncludeUnlisted_Default_Constant)
        {
            var publicationTimestamps_ByVersion = await this.Get_PublicationTimestamps_ByVersion(
                packageID,
                includePreRelease,
                includeUnlisted);

            var latest = publicationTimestamps_ByVersion
                .OrderByDescending(x => x.Value)
                .First();

            var output = (latest.Key, latest.Value);
            return output;
        }

        public async Task<Dictionary<NuGetVersion, DateTimeOffset>> Get_PublicationTimestamps_ByVersion(
            string packageID,
            bool includePreRelease = IValues.IncludePreRelase_Default_Constant,
            bool includeUnlisted = IValues.IncludeUnlisted_Default_Constant) 
        {
            var packageMetadataResource = await Instances.SourceRepositoryOperator.Get_PackageMetadataResource_Asynchronous();

            var metadatas = await Instances.PackageMetadataResourceOperator.Get_Metadata_Asynchronous(
                packageMetadataResource,
                packageID,
                includePreRelease,
                includeUnlisted);

            var output = Instances.PackageSearchMetadataOperator.Get_Published_ByVersion(metadatas);
            return output;
        }
    }
}
