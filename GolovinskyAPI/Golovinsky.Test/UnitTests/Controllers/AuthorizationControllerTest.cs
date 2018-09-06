using System;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using GolovinskyAPI.Controllers;
using GolovinskyAPI.Models;
using GolovinskyAPI.Infrastructure;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Golovinsky.Test.UnitTests.Controllers
{
   public class AuthorizationControllerTest
    {
        private readonly Mock<IRepository> _mockRepo = new Mock<IRepository>();
        private readonly AuthorizationController _controller; 
        
        public AuthorizationControllerTest()
        {
            _controller = new AuthorizationController(_mockRepo.Object);
        }
            
        [Fact]
        public async Task Post_ReturnsBadRequest_GivenInvalidModel()
        {
            _controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await _controller.Post(model: null);
            // result
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_ReturnsHttpNotFound_ForInvalidLoginModel()
        {
            // Act
            var result = await _controller.Post(new LoginModel());
            //Result
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Post_ReturnsNewlyCreatedToken()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            AuthorizationController controller = new AuthorizationController(mockRepo.Object);
        // arrange
        var newLoginModel = new LoginModel
            {
                UserName = "example@mail.com",
                Password = "123456789",
                Cust_ID_Main = 19139
            };
            int y = 0;
            // Result            
            var result = await controller.Post(newLoginModel);
            int x = 0;
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnResponse = Assert.IsType<LoginSuccessModel>(okResult.Value);
            _mockRepo.Verify();
            Assert.Equal("41607", returnResponse.UserId);
            Assert.Equal("customer", returnResponse.Role);
            Assert.Equal("example@mail.com", returnResponse.UserName);
            Assert.NotEmpty(returnResponse.AccessToken);
        }

        //private LoginSuccessModel GetUser()
        //{
            //var users = new List<LoginSuccessModel>();
            //users.Add(new BrainstormSession()
            //{
            //    DateCreated = new DateTime(2016, 7, 2),
            //    Id = 1,
            //    Name = "Test One"
            //});
            //sessions.Add(new BrainstormSession()
            //{
            //    DateCreated = new DateTime(2016, 7, 1),
            //    Id = 2,
            //    Name = "Test Two"
            //});
            //return sessions;
        //}
    }
}
