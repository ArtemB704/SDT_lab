using Moq;
using Xunit;
using System.Collections.Generic;

public class EventNotificationServiceTests
{
    [Fact]
    public void GetCriticalEvents_ShouldReturnOnlyCriticalEvents()
    {
        // Arrange
        var mockRepository = new Mock<IEventRepository>();
        mockRepository.Setup(repo => repo.GetAllEvents()).Returns(new List<Event>
        {
            new Event { Id = 1, Name = "Критичний: Пожежа", Location = "Київ" },
            new Event { Id = 2, Name = "Інформаційний: Дощ", Location = "Львів" }
        });

        var service = new EventNotificationService(mockRepository.Object);

        // Act
        var criticalEvents = service.GetCriticalEvents();

        // Assert
        Assert.Single(criticalEvents);
        Assert.Equal("Критичний: Пожежа", criticalEvents[0].Name);
    }

    [Fact]
    public void NotifyCitizens_ShouldReturnNotificationMessage()
    {
        // Arrange
        var criticalEvent = new Event { Id = 1, Name = "Критичний: Повінь", Location = "Одеса" };
        var service = new EventNotificationService(null);

        // Act
        var message = service.NotifyCitizens(criticalEvent);

        // Assert
        Assert.Equal("Оповіщення: Критичний: Повінь у місці Одеса", message);
    }
}
