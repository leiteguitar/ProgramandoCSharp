using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharp.UnitTest
{
    [TestClass]
    public class RepeticaTeste
    {
        [TestMethod]
        public void TabuadaTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i}*{j}={i*j}");
                }
            }
        }

        [TestMethod]
        public void ContinueTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i <= 5)
                {
                    continue;
                }

                Console.WriteLine(i);
            }
        }
    }
}
