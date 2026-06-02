using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCTemp;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ServiceCatalog_BronzePlan_IsRecognized()
        {
            ServiceCartItem plan;

            bool found = ServiceCatalog.TryGetPlan("bronze", out plan);

            Assert.IsTrue(found);
            Assert.IsNotNull(plan);
            Assert.AreEqual("Bronze", plan.Name);
            Assert.AreEqual(100m, plan.UnitPrice);
        }

        [TestMethod]
        public void ServiceCatalog_InvalidPlanCode_IsRejected()
        {
            ServiceCartItem plan;

            bool found = ServiceCatalog.TryGetPlan("unknown", out plan);

            Assert.IsFalse(found);
            Assert.IsNull(plan);
        }

        [TestMethod]
        public void ServiceCartItem_LineTotal_ReturnsPriceTimesQuantity()
        {
            var item = new ServiceCartItem
            {
                UnitPrice = 200m,
                Quantity = 3
            };

            Assert.AreEqual(600m, item.LineTotal);
        }
    }
}
