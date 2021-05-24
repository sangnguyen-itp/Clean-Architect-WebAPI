using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructures.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructures.Persistence.Repositories
{
    public class UserRepositoryAsync : BaseRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly DbSet<User> _users;
        public UserRepositoryAsync(ApplicationDBContext context) : base(context)
        {
            _users = context.Set<User>();
        }
    }
}
