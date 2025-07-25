using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using NuGet.Common;
using NuGet.Protocol.Core.Types;

using F10Y.T0002;


namespace F10Y.L0022
{
    [FunctionsMarker]
    public partial interface IPackageSearchResourceOperator
    {
        public string Get_SearchTerm_ForPackageID(string packageID)
        {
            var output = $"packageid:{packageID}";
            return output;
        }

        public async Task<IEnumerable<IPackageSearchMetadata>> Search_Asynchronous(
            PackageSearchResource packageSearchResource,
            string packageID,
            SearchFilter searchFilter,
            ILogger logger,
            CancellationToken cancellationToken)
        {
            var searchTerm = this.Get_SearchTerm_ForPackageID(packageID);

            var output = await packageSearchResource.SearchAsync(
                searchTerm,
                searchFilter,
                skip: 0,
                take: 1, // Limit to one result for efficiency
                log: logger,
                cancellationToken: cancellationToken);

            return output;
        }

        public async Task<IEnumerable<IPackageSearchMetadata>> Search_Asynchronous(
            PackageSearchResource packageSearchResource,
            string packageID,
            bool includePreRelease = IValues.IncludePreRelase_Default_Constant)
        {
            var logger = Instances.Loggers.Null;

            var cancellationToken = Instances.CancellationTokens.None;

            var searchFilter = Instances.SearchFilterOperator.New(includePreRelease);

            var output = await this.Search_Asynchronous(
                packageSearchResource,
                packageID,
                searchFilter,
                logger,
                cancellationToken);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Search_Asynchronous(PackageSearchResource, string, bool)"/> as the default.
        /// </summary>
        public Task<IEnumerable<IPackageSearchMetadata>> Search(
            PackageSearchResource packageSearchResource,
            string packageID,
            bool includePreRelease = IValues.IncludePreRelase_Default_Constant)
            => this.Search_Asynchronous(
                packageSearchResource,
                packageID,
                includePreRelease);
    }
}
