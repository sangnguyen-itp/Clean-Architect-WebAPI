using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUserCommand
{
    public partial class CreateUserCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public Int64 DOB { get; set; }
        public string Address { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepositoryAsync userRepositoryAsync, IMapper mapper)
        {
            _userRepositoryAsync = userRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _userRepositoryAsync.AddAsync(user);
            return new Response<int>(user.Id);
        }
    }
}
