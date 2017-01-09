using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace siva.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {

                var dao = new DAL.DbUsuario();
                                
                Assert.Fail();

            }
            catch
            {

                throw;
            }
        }
    }
}
