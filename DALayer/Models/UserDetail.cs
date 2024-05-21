using System;
using System.Collections.Generic;

namespace DALayer.Models
{
    public partial class UserDetail
    {
        public int Uid { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
