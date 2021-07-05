using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestPOCWebApp.Controllers;
using TestPOCWebApp.Models;
using Assert = NUnit.Framework.Assert;

namespace TestPOCWEbAppTest.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Get_WhenCalled_GetsCorrectNumberOfRecords()
        {
            //Arrange
            var testUsers = GetAllUser();
            var controller = new UserController();
            //Act
            var result = controller.Get() as List<UserDetail>;
            //Assert
            Assert.AreEqual(testUsers.Count, result.Count);
        }

        [TestMethod]
        public void Post_WhenCalled_SetsValuesCorrectly()
        {
            //Arrange
            var testUsers = GetAllUser();
            var user = new UserDetail { UserId = "1", FirstName = "Tom", LastName = "Cruise", Role = "Actor", Location = "New York", IsActive = true };
            var controller = new UserController();
            //Act
            var result = controller.Post(user);
            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(user.UserId, result.UserId);
                Assert.AreEqual(user.FirstName, result.FirstName);
                Assert.AreEqual(user.IsActive, result.IsActive);
                Assert.AreEqual(user.LastName, result.LastName);
                Assert.AreEqual(user.Location, result.Location);
                Assert.AreEqual(user.Role, result.Role);
            });
        }

        private static List<UserDetail> GetAllUser()
        {
            var testUsers = new List<UserDetail>
            {
                new UserDetail { UserId = "1", FirstName = "Tom", LastName = "Cruise", Role = "Actor", Location = "New York", IsActive = true },
                new UserDetail { UserId = "2", FirstName = "Chris", LastName = "Pratt", Role = "Actor", Location = "Virginia", IsActive = true },
                new UserDetail { UserId = "3", FirstName = "Jennifer ", LastName = "Ann", Role = "Actress", Location = "California", IsActive = true },
                new UserDetail { UserId = "4", FirstName = "Ross", LastName = "Geller", Role = "Actor", Location = "New York", IsActive = true },
                new UserDetail { UserId = "5", FirstName = "Rachel", LastName = "Green", Role = "Actress", Location = "New York", IsActive = false }
             };
            return testUsers;
        }
    }
}
