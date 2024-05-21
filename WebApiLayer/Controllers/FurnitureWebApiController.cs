using DALayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLayer.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin,Customer")]
    public class FurnitureWebApiController : ControllerBase
    {
        private IRepo DataService;

        public FurnitureWebApiController(IRepo ser)
        {
            DataService = ser;
        }

        [HttpGet("GetFurniture")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Furniture> dat;
            try
            {
                dat = await DataService.GetAllFurnitureData();
                if (dat != null)
                { 
                    return Ok(dat); 
                }
                else
                {
                   throw new Exception("some error at backend");
                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetFurnitureById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Furniture dat;
            try
            {
                dat = await DataService.GetFurnitureDataById(id);

                if (dat != null)
                {
                    return Ok(dat);
                }
                else
                {
                    return BadRequest("record not found");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DeleteFurniture/{id}")]
        public async Task<IActionResult> DelFurniture(int id)
        {
            try
            {
                await DataService.DeleteFurniture(id);

                return Ok("record deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddFurniture")]
        public async Task<IActionResult> AddFurniture(Furniture NewRec)
        {
            try
            {
                await DataService.AddFurniture(NewRec);

                return Ok("record Added");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateFurniture")]
        public async Task<IActionResult> UpdateFurniture(Furniture UpdRec)
        {
            try
            {
                await DataService.UpdateFurniture(UpdRec);

                return Ok("record Updated");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
