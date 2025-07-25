using System;
using System.Collections.Generic;
using System.Linq;

using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

using F10Y.T0002;


namespace F10Y.L0022
{
    [FunctionsMarker]
    public partial interface IPackageSearchMetadataOperator
    {
        public bool Any_WithPackageID(
            IEnumerable<IPackageSearchMetadata> metadatas,
            Func<string, bool> packageID_Predicate)
        {
            var output = metadatas
                .Select(this.Get_PackageID)
                .Any(packageID_Predicate);

            return output;
        }

        public bool Any_WithPackageID(
            IEnumerable<IPackageSearchMetadata> metadatas,
            string packageID)
            => this.Any_WithPackageID(
                metadatas,
                this.Get_PackageID_Predicate_Default(packageID));

        /// <summary>
        /// Uses <see cref="StringComparison.OrdinalIgnoreCase"/>.
        /// </summary>
        public Func<string, bool> Get_PackageID_Predicate_Default(string packageID)
            => Instances.StringOperator.Get_Equals_Predicate(
                packageID,
                StringComparison.OrdinalIgnoreCase);

        public string Get_PackageID(IPackageSearchMetadata metadata)
            => metadata.Identity.Id;

        public DateTimeOffset Get_Published(IPackageSearchMetadata metadata)
            => metadata.Published.Value;

        public NuGetVersion Get_Version(IPackageSearchMetadata metadata)
            => metadata.Identity.Version;

        public Dictionary<NuGetVersion, DateTimeOffset> Get_Published_ByVersion(IEnumerable<IPackageSearchMetadata> metadatas)
        {
            var output = metadatas
                .ToDictionary(
                    this.Get_Version,
                    this.Get_Published
                );

            return output;
        }
    }
}
