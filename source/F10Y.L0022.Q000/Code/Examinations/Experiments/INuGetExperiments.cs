using System;
using System.Linq;
using System.Threading.Tasks;

using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

using F10Y.T0006;
using F10Y.T0011;


namespace F10Y.L0022.Q000
{
    [ExperimentsMarker]
    public partial interface INuGetExperiments
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Deprecated.INuGetExperiments _Deprecated => Deprecated.NuGetExperiments.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public async Task Metadatas_OfNonExistentPackage()
        {
            /// Inputs.
            var packageID =
                Instances.NuGetPackageIDs.Example_NuGetPackage_NotExists
                ;

            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            var packageMetadataResource = await Instances.SourceRepositoryOperator.Get_PackageMetadataResource_Asynchronous();

            var lines_ForOutput = Instances.EnumerableOperator.From($"Attempt to get NuGet package metadatas for package that does not exist: \"{packageID}\"");

            try
            {
                var metadatas = await Instances.PackageMetadataResourceOperator.Get_Metadata_Asynchronous(
                    packageMetadataResource,
                    packageID);

                var metadatas_Count = metadatas.Count();

                lines_ForOutput = lines_ForOutput
                    .Append("=> No exception thrown")
                    .Append($"{metadatas_Count}: count of metadatas returned")
                    ;
            }
            catch (Exception ex)
            {
                lines_ForOutput = lines_ForOutput
                    .Append($"=> Exception thrown:\n{ex.Message}")
                    ;
            }

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }

        public async Task Exists_Package()
        {
            /// Inputs.
            var packageID =
                //Instances.NuGetPackageIDs.Newtonsoft_Json
                Instances.NuGetPackageIDs.Example_NuGetPackage_Exists
                //Instances.NuGetPackageIDs.Example_NuGetPackage_NotExists
                ;

            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            var exists_Package = await Instances.NuGetOperator.Exists_Package(packageID);

            var lines_ForOutput = Instances.EnumerableOperator.From($"{exists_Package}: package exist for package ID:\n\t{packageID}")
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }
    }
}
