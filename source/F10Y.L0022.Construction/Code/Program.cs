using System;
using System.Threading.Tasks;


namespace F10Y.L0022.Construction
{
    class Program
    {
        static async Task Main()
        {
            //await Program.Demonstrations_();
            //await Program.Demonstrations_NuGet();

            //await Program.Experiments_();
            await Program.Experiments_NuGet();
        }

        #region Demonstrations

        static Task Demonstrations_()
        {
            throw new NotImplementedException();
        }

        static async Task Demonstrations_NuGet()
        {
            await Instances.NuGetDemonstrations.Get_LatestPublicationTimestamp();
            //await Instances.NuGetDemonstrations.Get_PublicationTimestamps_ByVersion();
        }

        #endregion

        #region Experiments

        static Task Experiments_()
        {
            throw new NotImplementedException();
        }

        static async Task Experiments_NuGet()
        {
            await Instances.NuGetExperiments.Metadatas_OfNonExistentPackage();
            //await Instances.NuGetExperiments.Exists_Package();
            //await Instances.NuGetExperiments.Get_PublicationTimestamps_ForVersions();
        }

        #endregion
    }
}