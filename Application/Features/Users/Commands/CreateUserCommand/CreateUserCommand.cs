using Application.Enums;
using Application.Interfaces;
using Application.Interfaces.Common;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUserCommand
{
    public partial class CreateUserCommand : IRequest<Response<int>>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public Int64 DOB { get; set; }
        public string Address { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncryptionService _encryptionService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(
            IUnitOfWork unitOfWork,
            IEncryptionService encryptionService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _encryptionService = encryptionService;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.SetLoginType(AuthenticateTypes.Basic.Value);
            user.HashPassword(_encryptionService.HashMD5("p@ssword123!"));

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(user.Id);
        }
    }
}
