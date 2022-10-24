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
                new Customer(new Email("email"), new CustomerName("f","d"), MoneySpent: 99);

            var product =
                new Product("f", new Money(15), BillingPeriod.Weekly);

            var expectedAmount = Fifteen;

            // Act - When
            var actualAmount =
                this.subscriptionAmountCalculator
                    .Calculate(customer, product);

            // Assert - Then
            actualAmount.Should().Be(expectedAmount);
        }
    }
}
