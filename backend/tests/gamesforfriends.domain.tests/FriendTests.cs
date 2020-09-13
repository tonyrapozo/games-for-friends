using System;
using Xunit;
using gamesforfriends.domain.User;

namespace gamesforfriends.domain.tests
{
    public class FriendTests
    {
        [Fact]
        public void FRIEND_CREATION_MUST_CREATE_NEW_IDENTIFIER_TEST()
        {
            var friend = Friend.newFriend();
            Assert.NotNull(friend.Id);
        }

        [Fact]
        public void FRIEND_CREATION_MUST_USE_ARGUMENT_IDENTIFIER_TEST()
        {
            var  friend = Friend.newFriend("f204c0e0-8ecc-4212-938a-125bfd5de832");
            Assert.NotNull(friend.Id);
            Assert.Equal("f204c0e0-8ecc-4212-938a-125bfd5de832", friend.Id);
        }

        [Fact]
        public void FRIEND_CREATION_MUST_PERSIST_USER_ID_TEST()
        {
            var user = User.User.newUser("6499b712-2bac-4e05-9f53-9dd84bfe0a13");
            var friend = Friend.newFriend("f204c0e0-8ecc-4212-938a-125bfd5de832")
                            .called("Friend of user")
                            .friendOf(user)
                            .friendsSince(DateTime.Parse("2020/09/13"));

            Assert.Equal("f204c0e0-8ecc-4212-938a-125bfd5de832", friend.Id);
            Assert.Equal("Friend of user", friend.Name);
            Assert.Equal(DateTime.Parse("2020/09/13"), friend.FriendshipDate);
            Assert.Equal("6499b712-2bac-4e05-9f53-9dd84bfe0a13", friend.UserId);
        }
    }
}
