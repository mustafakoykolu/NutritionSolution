using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserType:BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string Adress { get; set; } = String.Empty;
    }
}
