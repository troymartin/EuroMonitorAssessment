using Microsoft.VisualStudio.TestTools.UnitTesting;

//[assembly: Parallelize(Workers = 1, Scope = ExecutionScope.MethodLevel)]
namespace EuroMonitorAssessment.Tests
{
    
    [TestClass]
    [TestCategory("NummberTests")]
    public class NumberTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [Priority(1)]
        public void Input_Less_Than_5_Greater_Than_0_Returns_Correct_Output()
        {
            var result = NumberUtil.ProcessInput("3", out var mmessage, out var difference);
            Assert.IsTrue(result);
            Assert.AreEqual(difference, 2);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void Input_Less_Than_5_Less_Than_0_Returns_Error()
        {
            var result = NumberUtil.ProcessInput("-1", out var message, out var difference);
            Assert.IsFalse(result);
        }
    }
}
