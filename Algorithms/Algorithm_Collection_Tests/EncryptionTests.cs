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
            EncryptionManager.InitEncryptionManager();
            EncryptionManager manager = EncryptionManager.GetEncryptionManagerInstance();
            KeyPair keyPair = manager.GenerateKeyPair("abcdefghijklmnopqrstuvwxyz");

            BigInteger encMessage = manager.Encrypt(123, keyPair.PublicKey);
            BigInteger decryptedResult = manager.Decrypt(encMessage, keyPair.PrivateKey);

            Assert.AreEqual(123, decryptedResult);            
        }
    }
}
