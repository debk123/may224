using EntityLayer;

namespace UILayer.Shared.Services
{
    public interface IFur
    {
        Task<IEnumerable<Furniture>> GetAllFurnitureData();
        Task<Furniture> GetFurnitureDataById(int id);

        Task AddFurniture(Furniture NewRec);

        Task DeleteFurniture(int id);

        Task UpdateFurniture(Furniture UpdRec);
    }
}
