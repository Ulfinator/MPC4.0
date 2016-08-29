using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPC4.classes;

namespace MPC4._0_Unit_tests
{
    [TestClass]
    public class Magazine_test
    {

        private Magazine initialize_magazine()
        {
            return new Magazine("","","","9X19",30,30,"REGULAR");
        }

        [TestMethod]
        public void Magazine_check_initialize()
        {
            Magazine mg = initialize_magazine();
            Assert.AreEqual("9X19", mg.Calibre);
            Assert.AreEqual(30, mg.Max_projectiles);
            Assert.AreEqual(30, mg.Projectiles_left);
        }

        [TestMethod]
        public void Magazine_spend_ammo_confirm_spending()
        {
            Magazine mg = initialize_magazine();
            mg.spend_ammo(13);
            Assert.AreEqual(17, mg.Projectiles_left);
        }
    }
}
