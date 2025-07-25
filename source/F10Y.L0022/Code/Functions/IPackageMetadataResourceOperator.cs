using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using NuGet.Protocol.Core.Types;

using F10Y.T0002;
using NuGet.Common;
using System.Threading;


namespace F10Y.L0022
{
    [FunctionsMarker]
    public partial interface IPackageMetadataResourceOperator
    {
        public async Task<IEnumerable<IPackageSearchMetadata>> Get_Metadata_Asynchronous(
            PackageMetadataResource packageMetadataResource,
            string packageID,
            bool includePreRelease,
            bool includeUnlisted,
            SourceCacheContext sourceCacheContext,
            ILogger logger,
            CancellationToken cancellationToken)
        {
            var output = await packageMetadataResource.GetMetadataAsync(
                packageID,
                includePrerelease: true,
                includeUnlisted: false,
                sourceCacheContext: sourceCacheContext,
                log: logger,
                token: Instances.CancellationTokens.None);

            return output;
        }

        public async Task<IEnumerable<IPackageSearchMetadata>> Get_Metadata_Asynchronous(
            PackageMetadataResource packageMetadataResource,
            string packageID,
            bool includePreRelease = IValues.IncludePreRelase_Default_Constant,
            bool includeUnlisted = IValues.IncludeUnlisted_Default_Constant)
        {
            using var sourceCacheContext = new SourceCacheContext();

            var output = await this.Get_Metadata_Asynchronous(
                packageMetadataResource,
                packageID,
                includePreRelease,
                includeUnlisted,
                sourceCacheContext,
                Instances.Loggers.Null,
                Instances.CancellationTokens.None);

            return output;
        }
    }
}
