using System;
using System.Collections.Generic;
using Subscriptions.Domain.Base;
using Subscriptions.Domain.Subscriptions;

namespace Subscriptions.Domain.Customers
{
    public sealed class Customer : Entity
    {
        private readonly List<Subscription> subscriptions;

        private Customer()
        { }

        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public decimal MoneySpent { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions =>
            this.subscriptions.AsReadOnly();

        public Customer(string Email, string FirstName, string LastName, decimal MoneySpent)
        {
            Id = Guid.NewGuid();
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MoneySpent = MoneySpent;
            this.subscriptions = new List<Subscription>();
        }
    }
}
