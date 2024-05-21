using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public interface IRepo
    {
        Task<IEnumerable<Furniture>> GetAllFurnitureData();
        Task<Furniture> GetFurnitureDataById(int id);

        Task AddFurniture(Furniture NewRec);

        Task DeleteFurniture(int id);

        Task UpdateFurniture(Furniture UpdRec);
    }
}
