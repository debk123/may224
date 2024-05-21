using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UserModel
    {
        [JsonIgnore]
        public int Uid { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        [JsonIgnore]
        public string? Role { get; set; } = "Customer";
    }
}
