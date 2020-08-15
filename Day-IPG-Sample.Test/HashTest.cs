using System;
using Day_IPG_Sample.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day_IPG_Sample.Test
{
    [TestClass]
    public class HashTest
    {
        [TestMethod]
        public void should_return_hashed_string()
        {
            //AAA= Arrange, Act, Assert
            
            //arrange
            string input = "123";
            string expectedOutput = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3";

            //act
            string result = Hash.GetHash(input);

            //assert
            Assert.AreEqual(expectedOutput, result);
        }
    }
}
