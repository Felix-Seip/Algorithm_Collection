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
            KeyPair pair = generator.GenerateNewKeyPair();

            string message = "bla";
            string encMessage = generator.Encrypt(message, pair.PublicKey);
            generator.Decrypt(encMessage, pair.PrivateKey);

            bool bla = false;
        }
    }
}
