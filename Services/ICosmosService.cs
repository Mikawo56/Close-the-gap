using System;
using Close_the_gap.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Close_the_gap.Services
{
    public interface ICosmosDbService
    {
        Task<List<Material>> GetMaterialListAsync();
        Task<Material> GetMaterialAsync(string id);
        Task<List<Material>> GetMaterialListPerDonorDateAsync(string donor, string collectionDate);
        Task AddMaterialAsync(Material item);
        Task AddBulkMaterialListAsync(List<Material> materials);
        Task UpdateMaterialAsync(string id, Material item);
        Task DeleteMaterialAsync(string id);
    }
}
