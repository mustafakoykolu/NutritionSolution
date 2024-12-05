using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserType.Commands.CreateUserType
{
    public class CreateUserTypeCommand : IRequest<int>
    {
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string Adress { get; set; } = String.Empty;
    }
}
