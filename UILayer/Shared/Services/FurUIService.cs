using EntityLayer;
using System.Net.Http.Json;

namespace UILayer.Shared.Services
{
    public class FurUIService : IFur
    {
        private HttpClient FSer;

        public FurUIService(HttpClient FSerr)
        {
            FSer = FSerr;
        }
        public async Task AddFurniture(Furniture NewRec)
        {
            await FSer.PostAsJsonAsync<Furniture>("AddFurniture", NewRec);
        }

        public async Task DeleteFurniture(int id)
        {
            await FSer.DeleteAsync("deleteFurniture/" + id);
        }

        public async Task<IEnumerable<Furniture>> GetAllFurnitureData()
        {
            return await FSer.GetFromJsonAsync<IEnumerable<Furniture>>("GetFurniture");
        }

        public async Task<Furniture> GetFurnitureDataById(int id)
        {
            return await FSer.GetFromJsonAsync<Furniture>("GetFurnitureById/" + id);
        }

        public async Task UpdateFurniture(Furniture UpdRec)
        {
            await FSer.PutAsJsonAsync<Furniture>("UpdateFurniture", UpdRec);
        }
    }
}
