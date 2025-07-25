using System;
using System.Threading.Tasks;

using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

using F10Y.T0002;


namespace F10Y.L0022
{
    [FunctionsMarker]
    public partial interface ISourceRepositoryOperator
    {
        /// <summary>
        /// Uses the <see cref="INuGetSources.NuGet_org"/> source.
        /// </summary>
        public Task<PackageMetadataResource> Get_PackageMetadataResource_Asynchronous()
            => this.Get_PackageMetadataResource_Asynchronous(
                Instances.NuGetSources.NuGet_org);

        /// <summary>
        /// Uses the <see cref="INuGetSources.NuGet_org"/> source.
        /// </summary>
        public PackageMetadataResource Get_PackageMetadataResource_Synchronous()
            => this.Get_PackageMetadataResource_Synchronous(
                Instances.NuGetSources.NuGet_org);

        public Task<PackageMetadataResource> Get_PackageMetadataResource_Asynchronous(string source)
            => this.Get_Resource_Asynchronous<PackageMetadataResource>(source);

        public PackageMetadataResource Get_PackageMetadataResource_Synchronous(string source)
            => this.Get_Resource_Synchronous<PackageMetadataResource>(source);

        public Task<PackageSearchResource> Get_PackageSearchResource_Asynchronous(string source)
            => this.Get_Resource_Asynchronous<PackageSearchResource>(source);

        /// <summary>
        /// Uses the <see cref="INuGetSources.NuGet_org"/> source.
        /// </summary>
        public Task<PackageSearchResource> Get_PackageSearchResource_Asynchronous()
            => this.Get_Resource_Asynchronous<PackageSearchResource>(
                Instances.NuGetSources.NuGet_org);

        public Task<PackageSearchResource> Get_PackageSearchResource_Asynchronous(SourceRepository sourceRepository)
            => this.Get_Resource_Asynchronous<PackageSearchResource>(sourceRepository);

        /// <summary>
        /// Uses the <see cref="INuGetSources.NuGet_org"/> source.
        /// </summary>
        public Task<PackageSearchResource> Get_PackageSearchResource_Synchronous()
            => this.Get_Resource_Asynchronous<PackageSearchResource>(
                Instances.NuGetSources.NuGet_org);

        public PackageSearchResource Get_PackageSearchResource_Synchronous(string source)
            => this.Get_Resource_Synchronous<PackageSearchResource>(source);

        public PackageSearchResource Get_PackageSearchResource_Synchronous(SourceRepository sourceRepository)
            => this.Get_Resource_Synchronous<PackageSearchResource>(sourceRepository);

        public SourceRepository Get_Repository_CoreV3(string source)
        {
            var output = Repository.Factory.GetCoreV3(source);
            return output;
        }

        public async Task<TResource> Get_Resource_Asynchronous<TResource>(SourceRepository sourceRepository)
            where TResource : class, INuGetResource
        {
            var output = await sourceRepository.GetResourceAsync<TResource>();
            return output;
        }

        public TResource Get_Resource_Synchronous<TResource>(SourceRepository sourceRepository)
            where TResource : class, INuGetResource
        {
            var output = sourceRepository.GetResource<TResource>();
            return output;
        }

        public async Task<(TResource Resource, SourceRepository SourceRepository)> Get_ResourceTuple_Asynchronous<TResource>(string source)
            where TResource : class, INuGetResource
        {
            var sourceRepository = Repository.Factory.GetCoreV3(source);

            var output = await sourceRepository.GetResourceAsync<TResource>();
            
            return (output, sourceRepository);
        }

        public async Task<TResource> Get_Resource_Asynchronous<TResource>(string source)
            where TResource : class, INuGetResource
        {
            var tuple = await this.Get_ResourceTuple_Asynchronous<TResource>(source);

            var output = tuple.Resource;
            return output;
        }

        public TResource Get_Resource_Synchronous<TResource>(
            string source,
            out SourceRepository sourceRepository)
            where TResource : class, INuGetResource
        {
            sourceRepository = Repository.Factory.GetCoreV3(source);

            var output = sourceRepository.GetResource<TResource>();
            return output;
        }

        public TResource Get_Resource_Synchronous<TResource>(string source)
            where TResource : class, INuGetResource
            => this.Get_Resource_Synchronous<TResource>(
                source,
                out _);
    }
}
