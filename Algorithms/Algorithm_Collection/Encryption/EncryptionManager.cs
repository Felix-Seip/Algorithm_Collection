using System.Numerics;

namespace Algorithm_Collection.Encryption
{
    public class EncryptionManager
    {
        private static EncryptionManager _encryptionManager;
        private static KeyGenerator _keyGenerator;

        private EncryptionManager()
        { }

        public static void InitEncryptionManager()
        {
            _encryptionManager = new EncryptionManager();
            _keyGenerator = new KeyGenerator();
        }

        public static EncryptionManager GetEncryptionManagerInstance()
        {
            return _encryptionManager;
        }

        public KeyPair GenerateKeyPair(string password)
        {
            return _keyGenerator.GenerateNewKeyPair(password);
        }

        public BigInteger Encrypt(long message, PublicKey key)
        {
            return BigInteger.Pow(message, (int)key.KeyValues[0]) % key.KeyValues[1];
        }

        public BigInteger Decrypt(BigInteger encMessage, PrivateKey key)
        {
            return BigInteger.Pow(encMessage, (int)key.KeyValues[0]) % key.KeyValues[1];
        }
    }
}
