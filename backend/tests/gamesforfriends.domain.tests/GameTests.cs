using System;
using Xunit;
using gamesforfriends.domain.User;

namespace gamesforfriends.domain.tests
{
    public class GameTests
    {
        [Fact]
        public void GAME_CREATION_MUST_CREATE_NEW_IDENTIFIER_TEST()
        {
            var game = Game.newGame();
            Assert.NotNull(game.Id);
        }

        [Fact]
        public void GAME_CREATION_MUST_USE_ARGUMENT_IDENTIFIER_TEST()
        {
            var game = Game.newGame("c635e7de-06cb-44f6-87c6-7bc6bdeb3f80");
            Assert.NotNull(game.Id);
            Assert.Equal("c635e7de-06cb-44f6-87c6-7bc6bdeb3f80", game.Id);
        }

        [Fact]
        public void GAME_CREATION_MUST_PERSIST_USER_ID_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var game = Game.newGame("c635e7de-06cb-44f6-87c6-7bc6bdeb3f80")
                            .called("Fifa 20")
                            .belongsTo(user);

            Assert.Equal("c635e7de-06cb-44f6-87c6-7bc6bdeb3f80", game.Id);
            Assert.Equal("Fifa 20", game.Name);
            Assert.Equal("6499b712-2bac-4e05-9f53-9dd84bfe0a13", game.UserId);
        }
    }
}
