using Application.Features.Users.Commands.CreateUserCommand;
using Application.Features.Users.Queries.GetAllUsers;
using Application.Wrappers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.IntegrationTests.Users.Queries
{
    using static Testing;
    public class GetAllUsersTests : TestBase
    {
        [Test]
        public async Task GetAllUsersTest()
        {
            // Arrange
            var query = new GetAllUsersQuery();

            // Action
            PagedResponse<IEnumerable<GetAllUsersViewModel>> result = await SendAsync(query);

            // Assertion
            result.Should().NotBeNull();
            result.Data.Should().BeEmpty();
            result.Succeeded.Should().Equals(false);
            result.Errors.Should().BeNull();
        }
    }
}
