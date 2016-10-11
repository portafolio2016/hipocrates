using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheekiBreeki.CMH.Terminal.DAL;
namespace CheekiBreeki.CMH.Terminal.DAL.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Entities ent = new Entities();
            PACIENTE paciente = new PACIENTE();
            paciente.ID_PACIENTE = 1;
            Object result = ent.PACIENTE.Find(paciente.ID_PACIENTE);


        }
    }
}
