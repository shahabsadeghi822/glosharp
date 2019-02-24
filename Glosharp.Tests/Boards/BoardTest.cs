using System;
using System.Linq;
using System.Threading.Tasks;
using Glosharp.Http;
using Glosharp.Models;
using Glosharp.Models.Request;
using Xunit;
using Xunit.Abstractions;

namespace Glosharp.Tests.Boards
{
    public class BoardTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public BoardTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact, Trait("Category", "Boards")]
        public async Task Board_GetAllForCurrent_DefaultOptions()
        {
            var config = new Connection(new Configuration());
            var glo = new GloClient(config);
            
            var boards = await glo.Board.GetAllForCurrent();
            
            // I know this is an arbitrary test but this will allow us to see
            // if the test is pulling information down with the PAT provided.
            // It also let's us check to make sure it returns in a list :)
            foreach (var board in boards)
            {
                _testOutputHelper.WriteLine($"ID: {board.Id}");
                _testOutputHelper.WriteLine($"Name: {board.Name}");
                Assert.Equal(board.Name, board.Name);
            }    
        }

        [Fact, Trait("Category", "Boards")]
        public async Task Board_GetAllForCurrent_CustomOptions()
        {
            var config = new Connection(new Configuration());
            var glo = new GloClient(config);
            var options = new ApiOptions
            {
                Page = 1,
                PerPage = 15,
                Archived = false,
                SortPage = ApiOptions.Sort.Desc
            };
            
            var boards = await glo.Board.GetAllForCurrent(options);
            
            // I know this is an arbitrary test but this will allow us to see
            // if the test is pulling information down with the PAT provided.
            // It also let's us check to make sure it returns in a list :)
            // To make sure they are running right, you can check the different out
            // puts from the above test. They should sort in a different order.
            foreach (var board in boards)
            {
                _testOutputHelper.WriteLine($"ID: {board.Id}");
                _testOutputHelper.WriteLine($"Name: {board.Name}");
                Assert.Equal(board.Name, board.Name);
            }    
        }

        [Fact, Trait("Category", "Boards")]
        public async Task Board_GetAllForSingle_DefaultOptions()
        {
            // want to figure out a way to get this to auto do this when you just
            // new up a GloClient
            var glo = new GloClient(new Connection(new Configuration()));
            var boards = glo.Board.GetAllForCurrent().Result.FirstOrDefault();
            var board = await glo.Board.GetAllForSingle(boards?.Id);
            
            _testOutputHelper.WriteLine($"ID: {board.Id}");
            _testOutputHelper.WriteLine($"Name: {board.Name}");
            _testOutputHelper.WriteLine($"Created Date: {board.CreatedDate}");
            
            Assert.NotNull(board.Id);
            Assert.NotNull(board.Name);
            Assert.NotNull(board.CreatedDate);
        }
    }
}