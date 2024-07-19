using Application.Commands;
using AutoFixture;
using Domain.Entities;
using FluentAssertions;
using Moq;

namespace Application.Tests;

public class AddEmployeeCommandTests
{
    private readonly CommandFixture _fixture= new();

    [Fact]
    public async Task AddEmployeeCommandHandler_ShouldReturnSuccessResult()
    {
        // Arrange
        var command = new Fixture().Create<AddEmployeeCommand>();
        var validId = 1;
        _fixture.employeeRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Employee>())).ReturnsAsync(validId);
        
        // Act
        var result = await _fixture.SendAsync(command);
        
        // Assert
        result.Success.Should().BeTrue();
        _fixture.employeeRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Employee>()), Times.Once);
    }


    [Fact]
    public async Task AddEmployeeCommandHandler_ShouldReturnFailResult()
    {
        // Arrange
        var command = new Fixture().Create<AddEmployeeCommand>();
        var invalidId = -1;
        _fixture.employeeRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Employee>())).ReturnsAsync(invalidId);

        // Act
        var result = await _fixture.SendAsync(command);

        // Assert
        result.Success.Should().BeFalse();
        _fixture.employeeRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Employee>()), Times.Once);
    }
}