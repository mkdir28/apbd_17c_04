using System.Data;

namespace LegacyApp.Tests;

public class userServicesTests
{
    [Fact]
    public void AddUser_ReturnsFlaseWhenTheFirstNameIsEmpty()
    {
        //Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            null,
            "Smith",
            "smith@page.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        //Assert
        Assert.False(result);
        //Assert.Throws<ArgumentException>(() ->{});
    }
}