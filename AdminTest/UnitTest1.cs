using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdminDataEntity;
using AdminModels.Entities;
using System.Linq;

namespace AdminTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataEntities entities = new DataEntities();
            var menus = entities.Menus.ToList();
        }
    }
}
