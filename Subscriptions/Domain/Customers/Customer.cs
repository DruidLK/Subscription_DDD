using System;
using System.Collections.Generic;
using Subscriptions.Domain.Base;
using Subscriptions.Domain.Subscriptions;
using Subscriptions.Domain.ValueObjects;

namespace Subscriptions.Domain.Customers
{
    public sealed class Customer : Entity
    {
        private readonly List<Subscription> subscriptions;

        private Customer()
        { }

        public string Email { get; private set; }
        public CustomerName CustomerName { get; private set; }
        public decimal MoneySpent { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions =>
            this.subscriptions.AsReadOnly();

        public Customer(string Email, CustomerName CustomerName, decimal MoneySpent)
        {
            Id = Guid.NewGuid();
            this.Email = Email;
            this.CustomerName = CustomerName;
            this.MoneySpent = MoneySpent;
            this.subscriptions = new List<Subscription>();
        }
    }
}
