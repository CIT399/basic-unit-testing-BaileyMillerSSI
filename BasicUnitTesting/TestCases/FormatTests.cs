using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TelephoneLib;

namespace TestCases
{
    [TestClass]
    public class FormatTests
    {
        /// <summary>
        /// Verify that a correctly 10 count string gets formatted correctly
        /// </summary>
        [TestMethod]
        public void FormatsCorrectly()
        {
            var correctAnswer = "(123)456-7890";
            Assert.AreEqual(correctAnswer, Telephone.format("1234567890"));
        }

        /// <summary>
        /// Verify that if !UNFORMATTED_LENGTH returns same value
        /// </summary>
        [TestMethod]
        public void ReturnsInvalid()
        {
            var nineLength = new string('*', 9);
            var elevenLength = new string('*', 11);


            Assert.AreEqual(nineLength, Telephone.format(nineLength));

            Assert.AreEqual(elevenLength, Telephone.format(elevenLength));

            Assert.IsTrue(Telephone.format(null) == null);
        }

        /// <summary>
        /// Verify that method can handle null values
        /// </summary>
        [TestMethod]
        public void HandlesNullValues()
        {
            try
            {
                Telephone.format(null);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

    }
}
