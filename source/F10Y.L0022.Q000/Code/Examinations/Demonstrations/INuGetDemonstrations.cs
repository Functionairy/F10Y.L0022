using System;
using System.Linq;
using System.Threading.Tasks;

using F10Y.L0000.Extensions;
using F10Y.T0006;


namespace F10Y.L0022.Q000
{
    [DemonstrationsMarker]
    public partial interface INuGetDemonstrations
    {
        /// <summary>
        /// For a package, get timestamp of the latest publication.
        /// </summary>
        public async Task Get_LatestPublicationTimestamp()
        {
            /// Inputs.
            var packageID =
                Instances.NuGetPackageIDs.Newtonsoft_Json
                ;

            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            var tuple = await Instances.NuGetOperator.Get_PublicationTimestampAndVersion_Latest(packageID);

            var lines_ForOutput = Instances.EnumerableOperator.From($"{packageID} - package, latest publication version and timestamp:\n")
                .Append($"{tuple.Version}, {tuple.Publication.ToLocalTime()} (Local)")
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }

        /// <summary>
        /// For a package, get the series of timestamps and versions.
        /// </summary>
        public async Task Get_PublicationTimestamps_ByVersion()
        {
            /// Inputs.
            var packageID =
                Instances.NuGetPackageIDs.Newtonsoft_Json
                ;

            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            var publicationTimestamps_ByVersion = await Instances.NuGetOperator.Get_PublicationTimestamps_ByVersion(packageID);

            var lines_ForOutput = Instances.EnumerableOperator.From($"{packageID} - package publication versions and timestamps:\n")
                .Append(publicationTimestamps_ByVersion
                    // Order by published, newest to oldest.
                    .OrderByDescending(x => x.Value)
                    .Select(x => $"{x.Key}: {x.Value.LocalDateTime} (Local)")
                )
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }
    }
}
