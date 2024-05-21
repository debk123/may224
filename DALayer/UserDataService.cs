using DALayer.Models;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public class UserDataService : IUserRepo
    {
        private AblazdbContext db;

        public UserDataService(AblazdbContext dbb)
        {
            db = dbb;

        }
        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetAllUserData()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserDataById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RegisterUser(UserModel NewRec)
        {
            UserDetail? det = new UserDetail();

            det.UserName = NewRec.UserName;
            det.Uid = NewRec.Uid;
            det.Password = NewRec.Password;
            det.Role = NewRec.Role;

            try
            {

                if (det != null)
                {
                    await db.UserDetails.AddAsync(det);
                    int r=await db.SaveChangesAsync();

                    if (r <= 0)
                    {
                        throw new Exception("record not saved");
                    }
                    else
                    {
                        return r;
                    }
                }
                else
                {
                    throw new Exception("UI Layer Error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task UpdateUser(UserModel UpdRec)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> ValidateUser(UserModel ExUsr)
        {
            UserDetail det;
            UserModel? usr = new UserModel();
            try
            {
                det =db.UserDetails.Where(f => f.UserName == ExUsr.UserName && f.Password == ExUsr.Password).SingleOrDefault();
                if(det!=null)
                {
                    usr.UserName = det.UserName;
                    usr.Password = det.Password;
                    usr.Role = det.Role;
                    return usr;
                }
                else
                {
                    throw new Exception("User not Found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
