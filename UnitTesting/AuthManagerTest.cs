using BuisnessLayer;
using DataLayer.Models;
using DataLayer.Repository.Abstraction;
using Moq;
using System.Diagnostics;

namespace UnitTesting
{
    [TestClass]
    public class AuthManagerTest    
    {
        
        private Mock<IAuthRepo> _authRepoMock;
        private AuthManager _authManager;
        [TestInitialize]
        public void Init() { 
            _authRepoMock = new Mock<IAuthRepo>();
            _authManager=new AuthManager( _authRepoMock.Object );
        }
        [TestMethod]
        public void Login_WithCorrectCredentials_ReturnsUserID()
        {
            #region ASSIGN
            Auth user = new(911, "ferari", "proshe");
            _authRepoMock.Setup(repo => repo.GetPassWord(It.IsAny<string>())).Returns(user);
            #endregion

            #region ACT
            int res = _authManager.Login(user);
            #endregion

            #region ASSERT
              Assert.AreNotEqual(res, 0);
            #endregion

        }

        [TestMethod]
        public void Login_WithIncorrectCredentials_ReturnsNegative()
        {
            #region ASSIGN
            Auth user = new(911, "ferari", "proshe");
            Auth auth = new(112, "Mba", "sa");
            _authRepoMock.Setup(repo => repo.GetPassWord(It.IsAny<string>())).Returns(user);
            #endregion

            #region ACT
             int res = _authManager.Login(auth);
            #endregion

            #region ASSERT
                Assert.AreEqual(res, -1);
            #endregion
        }

        [TestMethod]
        public async Task GetUsers_ReturnsListOfUsers() {
            #region ASSIGN
                List<string> users = new List<string>
                {
                    "user1",
                    "user2"
                };
                _authRepoMock.Setup(repo=>repo.GetAllUserNames()).ReturnsAsync(users);
            #endregion
            #region ACT
                List<string> res =await _authManager.getAllUsers();
            #endregion
            #region ASSERT
                Assert.AreEqual(users,res);
            #endregion
        }

    }
}