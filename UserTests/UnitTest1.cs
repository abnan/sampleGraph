using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RailTownAITest;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UserTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckFurthestUserTest()
        {
            string testJson = File.ReadAllText("../../test1.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(testJson);
            users[0].setFurthestUser(users);
            string expected = "Abhishek Nan";
            string actual = users[0].furthestUser.name;
            Assert.AreEqual(expected, actual, false, "Calculation incorrect");
        }
    }
}
