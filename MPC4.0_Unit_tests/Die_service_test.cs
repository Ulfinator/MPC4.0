using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPC4.classes;

namespace MPC4._0_Unit_tests
{
    [TestClass]
    public class Die_service_test
    {
        [TestMethod]
        public void throw_dies_positive()
        {
            int ret = Die_service.throw_dies("2T8");
            Assert.AreEqual(true,(ret>0));
        }

        [TestMethod]
        public void throw_dies_negative()
        {
            int ret = Die_service.throw_dies("-2T6");
            Assert.AreEqual(true, (ret < 0));
        }

        [TestMethod]
        public void throw_dies_negative_die_positive_addon()
        {
            int ret = Die_service.throw_dies("-1T4+5");
            Assert.AreEqual(true, (ret > 0));
        }

        [TestMethod]
        public void throw_dies_positive_die_negative_addon()
        {
            int ret = Die_service.throw_dies("1T4-5");
            Assert.AreEqual(true, (ret < 0));
        }
    }
}
