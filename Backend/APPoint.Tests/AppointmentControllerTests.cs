using System.Threading;
using System.Threading.Tasks;
using APPoint.App.Models.DTO;
using APPoint.App.Models.Requests;
using APPoint.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace APPoint.Tests
{
    public class AppointmentControllerTests
    {
        private readonly AppointmentController _appointmentController;
        private readonly Mock<IMediator> _mediatorMock;

        public AppointmentControllerTests()
        {         
            _mediatorMock = new Mock<IMediator>();

            _appointmentController = new AppointmentController(_mediatorMock.Object);
        }

        [Fact]
        public async Task AppointmentControllerReturns200ForRegistrationWhenRequestIsHandledSuccesfully()
        {
            // Arrange
            _mediatorMock.Setup(mediator => mediator.Send(It.IsAny<AppointmentRegistrationRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new AppointmentRegistrationDTO());

            // Act
            var response = await _appointmentController.Register(new AppointmentRegistrationRequest()) as OkResult;

            // Assert
            Assert.NotNull(response);
            Assert.Equal(200, response?.StatusCode);
            _mediatorMock.Verify(_ => _.Send(It.IsAny<AppointmentRegistrationRequest>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}