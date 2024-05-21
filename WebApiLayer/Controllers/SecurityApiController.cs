using DALayer;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiLayer.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class SecurityApiController : ControllerBase
    {
        private IUserRepo DataService;

        public SecurityApiController(IUserRepo ser)
        {
            DataService = ser;
        }

        [HttpPost("Validate")]
        public async Task<IActionResult> ValidateUser(UserModel Usr)
        {
            UserModel dat;
            try
            {
                dat = await DataService.ValidateUser(Usr);

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

        [HttpPost("ValidateWithToken")]
        public async Task<IActionResult> ValidateUserWithToken(UserModel Usr)
        {
            string Token="";
            UserModel? dat;
            TokenModel? TokDat = new TokenModel();
            try
            {
                dat = await DataService.ValidateUser(Usr);

                if (dat != null)
                {
                    Token = IssueToken(dat.Role);
                    TokDat.token=Token;
                    TokDat.UserName = dat.UserName;
                    TokDat.Role = dat.Role;

                    return Ok(TokDat);
                }
                else
                {
                    return BadRequest("User not found");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string IssueToken(string role)
        {
          //  var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdefghijklmnopqrst"));
            var issuer = "http://localhost:5018";

            var SecKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdefghijklmnopqrst"));

            var UserDet = new SigningCredentials(SecKey, SecurityAlgorithms.HmacSha256);

            var clm = new Claim[]
            {
               new Claim(ClaimTypes.Role,role)
            };
            var tok = new JwtSecurityToken(issuer, issuer,clm,
                expires: DateTime.Now.AddDays(2),
                
                signingCredentials: UserDet
                );
            return new JwtSecurityTokenHandler().WriteToken(tok);

        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(UserModel Usr)
        {
            int status;
            try
            {
                status = await DataService.RegisterUser(Usr);

                if (status>0)
                {
                    return Ok("Record Inserted successfully");
                }
                else
                {
                    return BadRequest("record not created");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
