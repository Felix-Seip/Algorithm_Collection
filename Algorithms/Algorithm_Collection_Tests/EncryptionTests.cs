using Algorithm_Collection.Encryption;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;

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

            BigInteger encMessage = generator.Encrypt(123, pair.PublicKey);
            BigInteger decryptedResult = generator.Decrypt(encMessage, pair.PrivateKey);

            Assert.AreEqual(123, decryptedResult);            
        }
    }
}
