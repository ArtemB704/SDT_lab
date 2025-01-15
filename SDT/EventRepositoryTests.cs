using Moq;
using Xunit;
using System.Collections.Generic;

public class EventRepositoryTests
{
    [Fact]
    public void GetAllEvents_ShouldReturnListOfEvents()
    {
        // Arrange
        var mockRepository = new Mock<IEventRepository>();
        mockRepository.Setup(repo => repo.GetAllEvents()).Returns(new List<Event>
        {
            new Event { Id = 1, Name = "Пожежа", Location = "Київ" },
            new Event { Id = 2, Name = "Повінь", Location = "Одеса" }
        });

        var repository = mockRepository.Object;

        // Act
        var events = repository.GetAllEvents();

        // Assert
        Assert.NotNull(events);
        Assert.Equal(2, events.Count);
        Assert.Contains(events, e => e.Name == "Пожежа");
    }
}
