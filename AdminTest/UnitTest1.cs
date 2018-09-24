using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdminDataEntity;
using AdminModels.Entities;
using System.Linq;
using AdminModels.Customs;
using System.Collections.Generic;

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

        [TestMethod]
        public void TestMethod2()
        {
            DataEntities entities = new DataEntities();
            var p = new { userId = 1 };

            var data = entities.ExecProcdure<int>("P_GetMenuByUserId", p);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var aa = new ConditionModelCollection();
            aa.Add(new ConditionModel()
            {
                Field = "UserName",
                Value = "s",
                Op = Operation.contain
            });
            aa.Add(new ConditionModel()
            {
                Field = "Mobile",
                Value = new string[] { "13255558796", "12555545856" },
                Op = Operation.contain
            });

            var exp = aa.ToExpression<T_User>();

            var users = new List<T_User>()
            {
                new T_User(){ UserName="zs",Mobile="13255558796" },
                new T_User(){ UserName="ls",Mobile="12555545856" }
            };

            var w = exp.Compile();

            var us = users.Where(w).ToList();

        }
    }
}
