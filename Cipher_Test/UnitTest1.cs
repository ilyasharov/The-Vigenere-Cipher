using Microsoft.VisualStudio.TestTools.UnitTesting;
using protect_inf_LR1;
using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Drawing;

namespace Cipher_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                StreamReader sr = new StreamReader("in.txt");

            }
            catch (Exception e)
            {
                Console.WriteLine("Îרטבךא פאיכא!");
            }
        }
    } 
}
