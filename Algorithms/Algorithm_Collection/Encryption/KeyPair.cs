using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Collection.Encryption
{
    public class KeyPair
    {
        public PrivateKey PrivateKey { get; private set; }
        public PublicKey PublicKey { get; private set; }

        public KeyPair(PrivateKey privateKey, PublicKey publicKey)
        {
            PrivateKey = privateKey;
            PublicKey  = publicKey;
        }

        public string Encrypt(PublicKey publicKey)
        {
            return "";
        }

        public string Decrypt()
        {
            return "";
        }
    }
}
