using Nest;
using SearchingOptimize.Models;
using System.Reflection.Metadata;

namespace SearchingOptimize
{
    public static class ElasticSearchExtension
    {
        public static async Task AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ElasticSearchSettings:Uri"]!;
            var Username = configuration["ElasticSearchSettings:Username"]!;
            var Password = configuration["ElasticSearchSettings:Password"]!;
            var Thumbprint = configuration["ElasticSearchSettings:Thumbprint"]!;

            var settings = new ConnectionSettings(new Uri(connectionString)).PrettyJson().CertificateFingerprint(Thumbprint).BasicAuthentication(Username, Password); 
            
            var elasticClient = new ElasticClient(settings);    
            services.AddSingleton<IElasticClient>(elasticClient);

            await CreateAccountIndex(elasticClient);
            await CrudOperation(elasticClient);
        }

        private static async Task CreateAccountIndex(IElasticClient client)
        {
            var createIndexResponse = await client.Indices.CreateAsync("customer", c => c
                .Map<Customer>(m => m
                .AutoMap()));
        
    
        }

        public static async Task CrudOperation(IElasticClient client)
        {
            var createIndexResponse = await client.Indices.CreateAsync("crud", c => c
               .Map<CRUD>(m => m
               .AutoMap()));
        }




    }
}