using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using allopromo.Controllers;
using allopromoDataAccess.Model;
using allopromoServiceLayer.Abstract;
using allopromoServiceLayer.Model;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace alloPromoTest
{
    [TestClass]
    public class UserControllerTests
    {
        private UserRepository _userRepo;
        private UserService _userService;
        [TestMethod]
        public void PostCreatesUser()
        {
           // _userService = new UserService(_userRepo);
            //Arrange
            var userController = new UserController(_userService);
            //Act
            //Assert
        }
        [TestMethod]
        public void GetReturnUsers()
        {
            var usersList = new List<ApplicationUser>()
            {
                new ApplicationUser{},
                new ApplicationUser{}
            };
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetUsersByRole("admin"))
                            .Returns(Task.FromResult<IList<ApplicationUser>>(usersList));
            
            var userController = new UserController(userServiceMock.Object);
            var users = userController.GetUsersByRole("admin");
            Assert.AreEqual(users.Result.Count, 1);
        }
    }
}
