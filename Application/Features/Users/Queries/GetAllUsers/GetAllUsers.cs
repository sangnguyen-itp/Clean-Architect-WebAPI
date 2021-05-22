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

namespace Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<PagedResponse<IEnumerable<GetAllUsersViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedResponse<IEnumerable<GetAllUsersViewModel>>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserRepositoryAsync userRepositoryAsync, IMapper mapper)
        {
            _userRepositoryAsync = userRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllUsersViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllUsersParameter>(request);
            var users = await _userRepositoryAsync.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var usersVM = _mapper.Map<IEnumerable<GetAllUsersViewModel>>(users);
            return new PagedResponse<IEnumerable<GetAllUsersViewModel>>(usersVM, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
