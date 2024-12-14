using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Identity
{
    public class ResetPasswordRequest
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}
