using System;
using System.Threading.Tasks;
using Glosharp.Http;
using Glosharp.Models;
using Xunit;
using Xunit.Abstractions;

namespace Glosharp.Tests.Users
{
    public class UserTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UserTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact, Trait("Category", "User")]
        public async Task User_GetAllForCurrent()
        {
            // want to figure out a way to get this to auto do this when you just
            // new up a GloClient
            var config = new Connection(new Configuration());
            var glo = new GloClient(config);
            var user = await glo.User.GetAllForCurrent();
            
            _testOutputHelper.WriteLine($"ID: {user.Id}");
            _testOutputHelper.WriteLine($"Name: {user.Name}");
            _testOutputHelper.WriteLine($"Username: {user.Username}");
            _testOutputHelper.WriteLine($"Email: {user.Email}");
            
            // Test to make sure all fields return a value.
            Assert.NotNull(user.Id);
            Assert.NotNull(user.Name);
            Assert.NotNull(user.Username);
            Assert.NotNull(user.Email);
        }

        [Fact, Trait("Category", "User")]
        public async Task User_GetPartialForCurrent()
        {
            var config = new Connection(new Configuration());
            var glo = new GloClient(config);
            var partialUser = await glo.User.GetPartialForCurrent();
            
            _testOutputHelper.WriteLine($"ID: {partialUser.Id}");
            _testOutputHelper.WriteLine($"Username: {partialUser.Username}");
            
            Assert.NotNull(partialUser.Username);
            Assert.NotNull(partialUser.Username);
        }
    }
}
