using Xunit;
using Moq;
using System.Threading;
using Microsoft.Extensions.Logging;
using Onboarding.Application.Requests.Orders;
using Onboarding.Infrastructure.Repository;

namespace Onboarding.Application.Tests.Requests.Orders
{
    public class CreateOrderHandlerTest
    {
        private readonly CancellationToken _cancellationToken = new CancellationTokenSource().Token;

        [Fact]
        public void CreateOrderHandlerConstructorOk()
        {
            //Arrange
            var mockOrderRepository = new Mock<IOrderRepository>();
            var mockLogger = new Mock<ILogger<CreateOrderHandler>>();

            //Act
            var createOrderHandler = new CreateOrderHandler(
                mockOrderRepository.Object,
                mockLogger.Object
            );

            //Assert
            Assert.NotNull(createOrderHandler);
            Assert.IsType<CreateOrderHandler>(createOrderHandler);
        }
    }
}
