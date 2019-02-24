using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glosharp.Http;
using Glosharp.Models;
using Glosharp.Models.Response;
using Xunit;
using Xunit.Abstractions;

namespace Glosharp.Tests.Cards
{
    public class CardTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CardTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        #region Get
        
        [Fact]
        public async Task Card_GetAllForCurrentBoard()
        {
            var config = new Connection(new Configuration());
            var glo = new GloClient(config);
            var boards = await glo.Board.GetAllForCurrent();
            var boardId = boards.FirstOrDefault()?.Id;
            var cards = await glo.Card.GetAll(boardId);

            foreach (var card in cards)
            {
                _testOutputHelper.WriteLine($"Card Id: {card.Id} | Card Name: {card.Name}");
                    
                Assert.NotNull(card.Id);
                Assert.NotNull(card.Name);
            }
        }

        [Fact]
        public async Task Card_GetAllForCurrent()
        {
            var config = new Connection(new Configuration());
            var glo = new GloClient(config);

            var allCards = await glo.Card.GetAll();
            
            _testOutputHelper.WriteLine($"Cards Found: {allCards.Count}");
            foreach (var card in allCards)
            {
                _testOutputHelper.WriteLine($"Card Id: {card.Id} | Card Name: {card.Name} | Board Id: {card.BoardId}");
                Assert.NotNull(card.Id);
                Assert.NotNull(card.Name);
            }
        }

        [Fact]
        public async Task Card_GetAllAssignedForUser()
        {
            var config = new Connection(new Configuration());
            var glo = new GloClient(config);
            var boards = await glo.Board.GetAllForCurrent();
            var user = await glo.User.GetAllForCurrent();

            var allCards = await glo.Card.GetAllAssigned(boards, user);
            var assignedCards = (
                from card 
                in allCards let assignees = card.Assignees 
                from assignee in assignees 
                where assignee.Id == user.Id select card).ToList();

            foreach (var card in assignedCards)
            {
                _testOutputHelper.WriteLine($"ID: {card.Id} | Name: {card.Name}");
            }
            Assert.NotNull(assignedCards);
        }
        
        #endregion

    }
}