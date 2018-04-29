using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelperUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        enum TestEnum
        {
            A = 1,
            B = 5,
        }

        [TestMethod]
        public void TestMethod1()
        {
            string test = Helpers.Helper.enumGetString(TestEnum.B);
            Assert.AreEqual<string>("B",test);
        }
    }
}
