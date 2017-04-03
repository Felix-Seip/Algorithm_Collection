using Algorithm_Collection.Encryption;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithm_Collection_Tests
{
    [TestClass]
    public class EncryptionTests
    {
        [TestMethod]
        public void TestRSAKeyGeneration()
        {
            KeyGenerator generator = new KeyGenerator("abcdefghijklmnopqrstuvwxyz");
            generator.GenerateNewKeyPair();
            bool bla = false;
        }
    }
}
