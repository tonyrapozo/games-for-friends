using System;
using Xunit;
using gamesforfriends.domain.User;

namespace gamesforfriends.domain.tests
{
    public class SharingTests
    {
        [Fact]
        public void SHARING_CREATION_MUST_CREATE_NEW_IDENTIFIER_TEST()
        {
            var sharing = Sharing.Sharing.newSharing();
            Assert.NotNull(sharing.Id);
        }

        [Fact]
        public void SHARING_CREATION_MUST_USE_ARGUMENT_IDENTIFIER_TEST()
        {
            var sharing = Sharing.Sharing.newSharing("849e17fa-99d5-43ff-ab8d-16c673e0c026");
            Assert.NotNull(sharing.Id);
            Assert.Equal("849e17fa-99d5-43ff-ab8d-16c673e0c026", sharing.Id);
        }

        [Fact]
        public void SHARING_CREATION_MUST_PERSIST_USER_GAME_FRIEND_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var game = Game.newGame("c635e7de-06cb-44f6-87c6-7bc6bdeb3f80");
            var friend = Friend.newFriend("f204c0e0-8ecc-4212-938a-125bfd5de832");
            var sharing = Sharing.Sharing.newSharing()
                                         .fromUser(user)
                                         .toFriend(friend)
                                         .thisGame(game)
                                         .at(DateTime.Parse("2020/09/10"))
                                         .returnedAt(DateTime.Parse("2020/09/13"));

            Assert.Equal("6499b712-2bac-4e05-9f53-9dd84bfe0a13", sharing.User.Id);
            Assert.Equal("c635e7de-06cb-44f6-87c6-7bc6bdeb3f80", sharing.Game.Id);
            Assert.Equal("f204c0e0-8ecc-4212-938a-125bfd5de832", sharing.Friend.Id);
            Assert.Equal(DateTime.Parse("2020/09/10"), sharing.SharingDate);
            Assert.Equal(DateTime.Parse("2020/09/13"), sharing.ReturnDate);
        }

        [Fact]
        public void SHARING_CREATION_THROWS_EXECPTION_ON_NULL_USER_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var game = Game.newGame("c635e7de-06cb-44f6-87c6-7bc6bdeb3f80");
            var friend = Friend.newFriend("f204c0e0-8ecc-4212-938a-125bfd5de832");

            Assert.Throws<System.ArgumentException>(() => Sharing.Sharing.newSharing()
                                         .fromUser(null)
                                         .toFriend(friend)
                                         .thisGame(game)
                                         .at(DateTime.Parse("2020/09/10"))
                                         .returnedAt(DateTime.Parse("2020/09/13")));
        }

        [Fact]
        public void SHARING_CREATION_THROWS_EXECPTION_ON_NULL_FRIEND_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var game = Game.newGame("c635e7de-06cb-44f6-87c6-7bc6bdeb3f80");
            var friend = Friend.newFriend("f204c0e0-8ecc-4212-938a-125bfd5de832");

            Assert.Throws<System.ArgumentException>(() => Sharing.Sharing.newSharing()
                                         .fromUser(user)
                                         .toFriend(null)
                                         .thisGame(game)
                                         .at(DateTime.Parse("2020/09/10"))
                                         .returnedAt(DateTime.Parse("2020/09/13")));
        }

        [Fact]
        public void SHARING_CREATION_THROWS_EXECPTION_ON_NULL_GAME_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var game = Game.newGame("c635e7de-06cb-44f6-87c6-7bc6bdeb3f80");
            var friend = Friend.newFriend("f204c0e0-8ecc-4212-938a-125bfd5de832");

            Assert.Throws<System.ArgumentException>(() => Sharing.Sharing.newSharing()
                                         .fromUser(user)
                                         .toFriend(friend)
                                         .thisGame(null)
                                         .at(DateTime.Parse("2020/09/10"))
                                         .returnedAt(DateTime.Parse("2020/09/13")));
        }
    }
}
