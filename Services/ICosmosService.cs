using Close_the_gap.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Close_the_gap.Services
{
    public interface ICosmosDbService
    {
        Task<List<Material>> GetMaterialListAsync(string query);
        Task<Material> GetMaterialAsync(string id);
        Task AddMaterialAsync(Material item);
        Task UpdateMaterialAsync(string id, Material item);
        Task DeleteMaterialAsync(string id);
    }
}
