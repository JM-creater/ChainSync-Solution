using ChainSyncSolution.Domain.Entities;
using ChainSyncSolution.ServerApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ChainSyncSolution.UnitTesting.TestControllers.Users;

public class UserControllerTest
{
    private readonly UserController _userController;

    public UserControllerTest(UserController userController)
    {
        _userController = userController;
    }

    [Fact]
    public void GetAllTest()
    {
        // Arrange
        // Act
        var result = _userController.GetUsers();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        var list = okResult.Value as List<User>;

        Assert.NotNull(list);
        Assert.Equal(5, list.Count);
    }
}
