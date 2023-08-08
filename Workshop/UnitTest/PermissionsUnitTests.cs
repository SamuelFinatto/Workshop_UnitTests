using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Controllers;
using Workshop.Helpers;

namespace WorkshopUnitTests
{
    [TestClass]
    public class PermissionsUnitTests
    {
        [TestMethod]
        public void Tools_GetUserPermission_ThrowsWhenUnexpectedPermission()
        {
            //Real class to test
            var tools = new Tools();

            var wrongList = new List<int>()
            {
                1,2,5,8,4
            };

            _ = Assert.ThrowsException<ArgumentOutOfRangeException>(() => tools.GetUserPermission(wrongList));

            wrongList = new List<int>()
            {
                6
            };

            _ = Assert.ThrowsException<ArgumentOutOfRangeException>(() => tools.GetUserPermission(wrongList));

            wrongList = new List<int>()
            {
                10
            };

            _ = Assert.ThrowsException<ArgumentOutOfRangeException>(() => tools.GetUserPermission(wrongList));

            wrongList = new List<int>()
            {
                -89
            };

            _ = Assert.ThrowsException<ArgumentOutOfRangeException>(() => tools.GetUserPermission(wrongList));
        }

        [TestMethod]
        public void Tools_GetUserPermission_ThrowsWhenListIsNull()
        {
            //Real class to test
            var tools = new Tools();

            _ = Assert.ThrowsException<NullReferenceException>(() => tools.GetUserPermission(null));
        }

        [TestMethod]
        public void Tools_GetUserPermission_ReceiveEmptyListWhenSendEmptyList()
        {
            //Real class to test
            var tools = new Tools();

            var emptyList = new List<int>();
            var permissionsList = tools.GetUserPermission(emptyList);

            Assert.AreEqual(0, permissionsList.Count());
        }

        [TestMethod]
        public void Tools_GetUserPermission_ReceiveNotDuplicatedListWhenSendWithDuplicatedOnList()
        {
            //Real class to test
            var tools = new Tools();

            var correctList = new List<int>()
            {
                1,2,3,4,5,1,4,2,3
            };

            var permissionsList = tools.GetUserPermission(correctList);

            //Check if the method returns the correct values
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission1", StringComparison.Ordinal)));
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission2", StringComparison.Ordinal)));
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission3", StringComparison.Ordinal)));
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission4", StringComparison.Ordinal)));
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission5", StringComparison.Ordinal)));
            Assert.AreEqual(5, permissionsList.Count());
        }

        [TestMethod]
        public void Tools_GetUserPermission_GetExpectedFromList()
        {
            //Real class to test
            var tools = new Tools();

            var correctList = new List<int>()
            {
                1,2,3,4,5
            };

            var permissionsList = tools.GetUserPermission(correctList);

            //Check if the method returns the correct values
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission1", StringComparison.Ordinal)));
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission2", StringComparison.Ordinal)));
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission3", StringComparison.Ordinal)));
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission4", StringComparison.Ordinal)));
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission5", StringComparison.Ordinal)));
            Assert.AreEqual(5, permissionsList.Count());


            correctList = new List<int>()
            {
                1
            };

            permissionsList = tools.GetUserPermission(correctList);
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission1", StringComparison.Ordinal)));
            Assert.AreEqual(1, permissionsList.Count());

            correctList = new List<int>()
            {
                2
            };

            permissionsList = tools.GetUserPermission(correctList);
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission2", StringComparison.Ordinal)));
            Assert.AreEqual(1, permissionsList.Count());

            correctList = new List<int>()
            {
                3
            };

            permissionsList = tools.GetUserPermission(correctList);
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission3", StringComparison.Ordinal)));
            Assert.AreEqual(1, permissionsList.Count());

            correctList = new List<int>()
            {
                4
            };

            permissionsList = tools.GetUserPermission(correctList);
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission4", StringComparison.Ordinal)));
            Assert.AreEqual(1, permissionsList.Count());

            correctList = new List<int>()
            {
                5
            };

            permissionsList = tools.GetUserPermission(correctList);
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission5", StringComparison.Ordinal)));
            Assert.AreEqual(1, permissionsList.Count());


            correctList = new List<int>()
            {
                1,2,3
            };

            permissionsList = tools.GetUserPermission(correctList);
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission1", StringComparison.Ordinal)));
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission2", StringComparison.Ordinal)));
            Assert.IsTrue(permissionsList.Any(r => r.Equals("Permission3", StringComparison.Ordinal)));
            Assert.AreEqual(3, permissionsList.Count());
        }
    }
}
