using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public interface IUserRepo
    {
        Task<IEnumerable<UserModel>> GetAllUserData();
        Task<UserModel> GetUserDataById(int id);

        Task<UserModel> ValidateUser(UserModel ExUsr);

        Task<int> RegisterUser(UserModel NewRec);

        Task DeleteUser(int id);

        Task UpdateUser(UserModel UpdRec);
    }
}
