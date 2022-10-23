using System;
using Ardalis.SmartEnum;

namespace Subscriptions.Domain.Products
{
    public sealed class BillingPeriod : SmartEnum<BillingPeriod>
    {
        private readonly Func<DateTimeOffset> currentDateTime;

        private const int SevenDays = 7;
        private const int OneMonth = 1;

        public static readonly BillingPeriod Weekly =
            new BillingPeriod(nameof(Weekly), 1, () => DateTimeOffset.UtcNow.AddDays(SevenDays));

        public static readonly BillingPeriod Monthly =
            new BillingPeriod(nameof(Monthly), 2, () => DateTimeOffset.UtcNow.AddMonths(OneMonth));

        public BillingPeriod(string name, int value, Func<DateTimeOffset> currentDateTime)
            : base(name, value) =>
                  this.currentDateTime = currentDateTime;
    }
}
