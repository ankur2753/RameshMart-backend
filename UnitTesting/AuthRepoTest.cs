using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using DataLayer.DBContext;
using DataLayer.Models;
using DataLayer.Repository;
using Moq;

namespace UnitTesting
{
    [TestClass]
    public class AuthRepoTest
    {
        private readonly Fixture fixture = new Fixture();
        private  Auth fakeUser;
        private AuthRepository authRepository;
        private Mock<IDBContext> dbContextMock;

        [TestInitialize]
        public void Init() { 
            fakeUser = fixture.Create<Auth>();
            dbContextMock = new Mock<IDBContext>();
            authRepository = new(dbContextMock.Object);
        }

        [TestMethod]
        public void GetPassword_WhenGivenCorrectCredentails_ReturnsString()
        {
            dbContextMock.Setup(db => db.QuerySingle<Auth>(It.IsAny<string>())).Returns(fakeUser);

            Auth res = authRepository.GetPassWord(fakeUser.UserName);

            Assert.AreEqual(fakeUser, res);
        }
    }
}
