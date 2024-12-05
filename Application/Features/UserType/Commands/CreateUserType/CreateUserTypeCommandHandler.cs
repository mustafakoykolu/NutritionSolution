using Application.Contracts.Persistence;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserType.Commands.CreateUserType
{
    public class CreateUserTypeCommandHandler : IRequestHandler<CreateUserTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserTypeCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<int> Handle(CreateUserTypeCommand request,  CancellationToken cancellationToken)
        {
            var userType = _mapper.Map<Domain.UserType>(request);
            await _userRepository.CreateAsync(userType);
            return userType.Id;
        }
    }
}
