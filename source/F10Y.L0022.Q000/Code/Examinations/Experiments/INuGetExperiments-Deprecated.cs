using System;
using System.Linq;
using System.Threading.Tasks;

using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

using F10Y.T0006;


namespace F10Y.L0022.Q000.Deprecated
{
    [ExperimentsMarker]
    public partial interface INuGetExperiments
    {
        public async Task Exists_Package_ShowInternals()
        {
            /// Inputs.
            var packageID =
                //Instances.NuGetPackageIDs.Newtonsoft_Json
                Instances.NuGetPackageIDs.Example_NuGetPackage_Exists
                //Instances.NuGetPackageIDs.Example_NuGetPackage_NotExists
                ;

            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            var sourceUrl = Instances.NuGetSources.NuGet_org_CoreV3;

            SourceRepository repository = Repository.Factory.GetCoreV3(sourceUrl);

            // Get the PackageSearchResource to search for the package
            PackageSearchResource searchResource = await repository.GetResourceAsync<PackageSearchResource>();

            // Search for the package by ID
            var logger = Instances.Loggers.Null;

            var cancellationToken = Instances.CancellationTokens.None;

            var searchFilter = new SearchFilter(includePrerelease: true);

            var searchResults = await searchResource.SearchAsync(
                $"packageid:{packageID}",
                searchFilter,
                skip: 0,
                take: 1, // Limit to one result for efficiency
                log: logger,
                cancellationToken: cancellationToken);

            // Return true if the package is found, false otherwise
            var exists_Package = searchResults
                .Any(p => p.Identity.Id.Equals(packageID, StringComparison.OrdinalIgnoreCase));

            var lines_ForOutput = Instances.EnumerableOperator.From($"{exists_Package}: package exist for package ID:\n\t{packageID}")
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }
    }
}
