using Application.Exceptions;
using Application.Features.Users.Commands.CreateUserCommand;
using Application.Wrappers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.IntegrationTests.Users.Commands
{
    using static Testing;
    public class CreateUserCommandTest : TestBase
    {
        [Test]
        public async Task CreateUserTest_ReturnsUserID()
        {
            // Arrange
            var query = new CreateUserCommand
            {
                Email = "test@test.com",
                Name = "Test",
                DOB = 142420054,
                Address = "ABC, XYZ"
            };

            // Action
            Response<int> result = await SendAsync(query);

            // Assertion
            result.Should().NotBeNull();
            result.Data.Should().BeGreaterThan(0);
            result.Succeeded.Should().Equals(true);
            result.Errors.Should().BeNull();
        }

        [Test]
        public void CreateUserTest_ReturnsMinimumFields()
        {
            var query = new CreateUserCommand();
            FluentActions.Invoking(() => SendAsync(query)).Should().Throw<ValidationException>();
        }

        [Test]
        public void CreateUserTest_ReturnsMissingEmail()
        {
            // Arrange
            var query = new CreateUserCommand()
            {
                Email = "",
                Name = "ABC",
                DOB = 1231420480,
                Address = "AVC AXT"
            };

            FluentActions.Invoking(() => SendAsync(query)).Should().Throw<ValidationException>();
        }

        [Test]
        public void CreateUserTest_ReturnsInvalidEmail()
        {
            // Arrange
            var query = new CreateUserCommand()
            {
                Email = "test",
                Name = "ABC",
                DOB = 1231420480,
                Address = "AVC AXT"
            };

            FluentActions.Invoking(() => SendAsync(query)).Should().Throw<ValidationException>();
        }

        [Test]
        public void CreateUserTest_ReturnsMissingName()
        {
            // Arrange
            var query = new CreateUserCommand()
            {
                Email = "email@email.com",
                Name = "",
                DOB = 1231420480,
                Address = "AVC AXT"
            };

            FluentActions.Invoking(() => SendAsync(query)).Should().Throw<ValidationException>();
        }

        [Test]
        public void CreateUserTest_ReturnsInvalidDOB()
        {
            // Arrange
            var query = new CreateUserCommand()
            {
                Email = "email@email.com",
                Name = "ABC",
                DOB = -4121231420480,
                Address = "AVC AXT"
            };

            FluentActions.Invoking(() => SendAsync(query)).Should().Throw<ValidationException>();
        }
    }
}
