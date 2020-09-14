namespace gamesforfriends.domain.Helper
{
    using System;
    
    public abstract class Identifier
    {
        public string Id { get; set; }

        public Identifier(string id)
        {
            Id = id;
            if (String.IsNullOrEmpty(Id))
                Id = Guid.NewGuid().ToString();
        }

        public Identifier()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}