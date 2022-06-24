﻿using Close_the_gap.Model;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Close_the_gap.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddMaterialAsync(Material material)
        {
            await _container.CreateItemAsync<Material>(material, new PartitionKey(material.Id.ToString()));
        }

        public async Task DeleteMaterialAsync(string id)
        {
            await _container.DeleteItemAsync<Material>(id, new PartitionKey(id));
        }

        public async Task<Material> GetMaterialAsync(string id)
        {
            try
            {
                ItemResponse<Material> response = await _container.ReadItemAsync<Material>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<List<Material>> GetMaterialListAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<Material>(new QueryDefinition(queryString));
            List<Material> results = new List<Material>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateMaterialAsync(string id, Material material)
        {
            await _container.UpsertItemAsync<Material>(material, new PartitionKey(id));
        }
    }
}