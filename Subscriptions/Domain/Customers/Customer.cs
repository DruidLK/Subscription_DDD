﻿using System;
using System.Collections.Generic;
using Subscriptions.Domain.Base;
using Subscriptions.Domain.Subscriptions;
using Subscriptions.Domain.ValueObjects;

namespace Subscriptions.Domain.Customers
{
    public sealed class Customer : Entity
    {
        private readonly List<Subscription> subscriptions;

        private Customer() =>
            this.subscriptions = new List<Subscription>();

        public Email Email { get; private set; }
        public CustomerName CustomerName { get; private set; }
        public decimal MoneySpent { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions =>
            this.subscriptions.AsReadOnly();

        public Customer(Email Email, CustomerName CustomerName, decimal MoneySpent)
            : this()
        {
            Id = Guid.NewGuid();
            this.Email = Email ?? throw new ArgumentNullException(nameof(Email));
            this.CustomerName = CustomerName ?? throw new ArgumentNullException(nameof(CustomerName));
        }
    }
}
