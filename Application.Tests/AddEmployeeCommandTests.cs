using Application.Commands;
using AutoFixture;
using Domain.Entities;
using FluentAssertions;
using Moq;

namespace Application.Tests;

public class AddEmployeeCommandTests
{
    [Fact]
    public async Task AddEmployeeCommandHandler_EmployeeWasAdded_ShouldReturnSuccessResult()
    {
        // Arrange
        var command = new Fixture().Create<AddEmployeeCommand>();
        var validId = 1;
        CommandFixture fixture= new();
        fixture.employeeRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Employee>())).ReturnsAsync(validId);
        
        // Act
        var result = await fixture.SendAsync(command);
        
        // Assert
        result.Success.Should().BeTrue();
        fixture.employeeRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Employee>()), Times.Once);
    }


    [Fact]
    public async Task AddEmployeeCommandHandler_EmployeeWasNotAdded_ShouldReturnFailResult()
    {
        // Arrange
        var command = new Fixture().Create<AddEmployeeCommand>();
        var invalidId = -1;
        CommandFixture fixture= new();
        fixture.employeeRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Employee>())).ReturnsAsync(invalidId);

        // Act
        var result = await fixture.SendAsync(command);

        // Assert
        result.Success.Should().BeFalse();
        fixture.employeeRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Employee>()), Times.Once);
    }
}