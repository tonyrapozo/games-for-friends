using System;
using Xunit;
using gamesforfriends.domain.User;

namespace gamesforfriends.domain.tests
{
    public class UserTests
    {
        [Fact]
        public void USER_CREATION_MUST_CREATE_NEW_IDENTIFIER_TEST()
        {
            var user = User.User.newUser();
            Assert.NotNull(user.Id);
        }

        [Fact]
        public void USER_CREATION_MUST_USE_ARGUMENT_IDENTIFIER_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            Assert.NotNull(user.Id);
            Assert.Equal("6499b712-2bac-4e05-9f53-9dd84bfe0a13", user.Id);
        }

        [Fact]
        public void USER_CREATION_MUST_PERSIST_USER_DATE_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13")
                                .called("Test User")
                                .withEmail("test@test.com")
                                .withPassword("123456");

            Assert.Equal("6499b712-2bac-4e05-9f53-9dd84bfe0a13", user.Id);
            Assert.Equal("test@test.com", user.Email);
            Assert.Equal("123456", user.Password);
            Assert.Equal("Test User", user.Name);
        }


        [Fact]
        public void USER_ADD_NEW_FRIEND_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var friend = Friend.newFriend()
                               .friendOf(user)
                               .called("Friend of user")
                               .friendsSince(DateTime.Parse("2020/09/13"));
            user.newFriend(friend);

            Assert.True(user.Friends.Count > 0);
            Assert.Equal("Friend of user", user.Friends[0].Name);
            Assert.Equal(DateTime.Parse("2020/09/13"), user.Friends[0].FriendshipDate);
            Assert.Equal("6499b712-2bac-4e05-9f53-9dd84bfe0a13", user.Friends[0].UserId);
        }

        [Fact]
        public void USER_ADD_EXISTENT_FRIEND_THROWS_EXCEPTION_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var friend = Friend.newFriend()
                               .friendOf(user)
                               .called("Friend of user")
                               .friendsSince(DateTime.Parse("2020/09/13"));
            user.newFriend(friend);
            Assert.Throws<System.ArgumentException>(() => user.newFriend(friend));
        }

        [Fact]
        public void USER_REMOVE_FRIEND_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var friend = Friend.newFriend()
                               .friendOf(user)
                               .called("Friend of user")
                               .friendsSince(DateTime.Parse("2020/09/13"));
            user.newFriend(friend);

            Assert.True(user.Friends.Count > 0);

            user.removeFriend(friend);

            Assert.True(user.Friends.Count == 0);
        }

        [Fact]
        public void USER_REMOVE_INEXISTENT_FRIEND_THROWS_EXCEPTION_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var friend = Friend.newFriend()
                               .friendOf(user)
                               .called("Friend of user")
                               .friendsSince(DateTime.Parse("2020/09/13"));

            Assert.Throws<System.ArgumentException>(() => user.removeFriend(friend));
        }

        [Fact]
        public void USER_ADD_NEW_GAME_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var game = Game.newGame()
                           .belongsTo(user)
                           .called("Fifa 20");
                           
            user.newGame(game);

            Assert.True(user.Games.Count > 0);
            Assert.Equal("Fifa 20", user.Games[0].Name);
            Assert.Equal("6499b712-2bac-4e05-9f53-9dd84bfe0a13", user.Games[0].UserId);
        }

        [Fact]
        public void USER_ADD_EXISTENT_GAME_THROWS_EXCEPTION_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var game = Game.newGame("04462bde-f01d-4400-9977-c39ca0a13a2f")
                           .belongsTo(user)
                           .called("Fifa 20");
                           
            user.newGame(game);
            Assert.Throws<System.ArgumentException>(() => user.newGame(game));
        }

        [Fact]
        public void USER_REMOVE_GAME_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var game = Game.newGame();
                           
            user.newGame(game);
            Assert.True(user.Games.Count > 0);

            user.removeGame(game);
            Assert.True(user.Games.Count == 0);
        }

        [Fact]
        public void USER_REMOVE_INEXISTENT_GAME_THROWS_EXCEPTION_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var game = Game.newGame("04462bde-f01d-4400-9977-c39ca0a13a2f");
            Assert.Throws<System.ArgumentException>(() => user.removeGame(game));
        }
    }
}