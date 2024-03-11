using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SAQ.Test.User
{
    [TestClass]
    public class UserApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext _testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        }
        /*
        [TestMethod]
        public async Task RegisterUser_WhenSendingNullOrEmpty_ValidationErrors()
        {
            using var scope = _scopeFactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<IUserApplication>();

            //Arrange
            var userName = "";
            var roleId = 1;
            var UrlImage = "";
            var positionId = 1;
            var status = 1;

            var expected = ReplyMessage.MESSAGE_VALIDATE;

            //Act
            var result = await context.RegisterUser(new UserRequestDto()
            {
                UserName = userName,
                IdRole = roleId,
                UrlImage = UrlImage,
                PositionId = positionId,
                Status = status
            });

            var current = result.Message;

            //Assert
            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        public async Task RegisterUser_WhenSendingCorrectValues_RegisteredSuccessFully()
        {
            using var scope = _scopeFactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<IUserApplication>();

            //Arrange
            var userName = "UsuarioTest";
            var roleId = 1;
            var UrlImage = "https://urltest.com";
            var positionId = 1;
            var status = 1;

            var expected = ReplyMessage.MESSAGE_SAVE;

            //Act
            var result = await context.RegisterUser(new UserRequestDto()
            {
                UserName = userName,
                IdRole = roleId,
                UrlImage = UrlImage,
                PositionId = positionId,
                Status = status
            });

            var current = result.Message;

            //Assert
            Assert.AreEqual(expected, current);
        }*/
    }
}
