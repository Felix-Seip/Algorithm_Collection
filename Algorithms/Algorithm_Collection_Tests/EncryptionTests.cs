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
			EncryptionManager manager = EncryptionManager.Instance;
            KeyPair keyPair = manager.GenerateKeyPair("HelloBumStinkInTheFace");
            
            string mess = manager.EncryptStringMessage("ByeBumStinkInTheFace", keyPair.PublicKey);
            mess = manager.DecryptStringMessage(mess, keyPair.PrivateKey);

            Assert.AreEqual("ByeBumStinkInTheFace", mess);            
        }
    }
}
