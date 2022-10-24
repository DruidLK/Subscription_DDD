using FluentAssertions;
using Subscriptions.Domain.Customers;
using Subscriptions.Domain.Products;
using Subscriptions.Domain.ValueObjects;
using Xunit;

namespace Subscriptions.Tests.Unit.Foundations.SubscriptionsFoundations
{
    public partial class SubscriptionsTest
    {
        [Fact]
        public void ShouldReturnOriginalSubscriptionAmount()
        {
            // Arrange - Given
            const int Fifteen = 15;

            var customer =
                new Customer(new Email("email"), new CustomerName("f", "d"));

            var product =
                new Product("f", new Money(15), BillingPeriod.Weekly);

            customer.AddSubscription(product, customer, 15, DateTimeOffset.UtcNow);

            var expectedAmount = Fifteen;

            // Act - When
            var actualAmount =
                this.subscriptionAmountCalculator
                    .Calculate(customer, product);

            // Assert - Then
            actualAmount.Should().Be(expectedAmount);
        }

        [Fact]
        public void ShouldReturnSubscriptionAmountWithTwentyPercentDiscount()
        {
            // Arrange - Given
            const int Twelve = 12;

            var customer =
                new Customer(new Email("email"), new CustomerName("f", "d"));

            var product =
                new Product("f", new Money(15), BillingPeriod.Weekly);

            customer.AddSubscription(product, customer, 100, DateTimeOffset.UtcNow);

            var expectedAmount = Twelve;

            // Act - When
            var actualAmount =
                this.subscriptionAmountCalculator
                        .Calculate(customer, product);

            // Assert - Then
            actualAmount.Should().Be(expectedAmount);
        }

        [Fact]
        public void ShouldReturnSubscriptionAmountWithFiftyPercentDiscount()
        {
            // Arrange - Given
            var customer =
                new Customer(new Email(""), new CustomerName("", ""));

            var product =
                new Product("", new Money(15), BillingPeriod.Weekly);

            customer.AddSubscription(product, customer, 1000, DateTimeOffset.UtcNow);

            var expectedAmount = 7.5M;

            // Act - When
            var actualAmount =
                this.subscriptionAmountCalculator
                        .Calculate(customer, product);

            // Assert - Then
            actualAmount.Should().Be(expectedAmount);

        }
    }
}
