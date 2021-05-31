using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrkeEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrkeEFCore.Models.Tests
{
    [TestClass()]
    public class FrkeInterlockDbTests
    {
        [TestMethod()]
        public void FrkeInterlockDbTest()
        {
            FrkeInterlockDb db = new FrkeInterlockDb();
            Assert.IsTrue(true);
        }
    }
}