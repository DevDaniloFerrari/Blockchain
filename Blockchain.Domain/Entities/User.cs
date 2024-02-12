﻿namespace Blockchain.Domain.Entities
{
    public class User
    {
        public User(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Balance { get; private set; }
    }
}
