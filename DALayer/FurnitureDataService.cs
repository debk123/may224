using DALayer.Models;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public class FurnitureDataService : IRepo
    {
        private AblazdbContext db;

        public FurnitureDataService(AblazdbContext dbb)
        {
            db = dbb;

        }
        public async Task AddFurniture(Furniture NewRec)
        {
            FurnitureDetail? det=new FurnitureDetail();

            det.Fid = NewRec.Fid;
            det.Fname = NewRec.Fname;

            try
            {
               
                if (det != null)
                {
                    await db.FurnitureDetails.AddAsync(det);
                    await db.SaveChangesAsync();
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

        public async Task DeleteFurniture(int id)
        {
            try
            {
                FurnitureDetail det = await db.FurnitureDetails.FindAsync(id);

                if (det != null)
                {
                    db.FurnitureDetails.Remove(det);
                    await db.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Furniture>> GetAllFurnitureData()
        {
            List<Furniture> lst = new List<Furniture>();
            try
            {
                var dat =await db.FurnitureDetails.ToListAsync();
                foreach (var f in dat) 
                {
                    Furniture ff = new Furniture();

                    ff.Fid = f.Fid;
                    ff.Fname = f.Fname;

                    lst.Add(ff);
                }
                return lst;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Furniture> GetFurnitureDataById(int id)
        {
            FurnitureDetail det;
            Furniture fur = new Furniture();
            try
            {
                det = await db.FurnitureDetails.FindAsync(id);
                if (det != null)
                {
                    fur.Fid = det.Fid;
                    fur.Fname = det.Fname;
                    return fur;
                }
                else
                {
                    throw new Exception("record not found");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateFurniture(Furniture UpdRec)
        {
            FurnitureDetail? det;

            try
            {
              det= await db.FurnitureDetails.FindAsync(UpdRec.Fid);

                if (det != null)
                {
                    det.Fid = UpdRec.Fid;
                    det.Fname = UpdRec.Fname;

                    db.Entry(det).State = EntityState.Modified;
                   await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("record not found or not Updated...");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
