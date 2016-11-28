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

                var retorno = dao.EfetuarLogon("admin", "123");

                Assert.Fail();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
