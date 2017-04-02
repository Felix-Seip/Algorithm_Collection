using System;
using System.Numerics;
using System.Text;

namespace Algorithm_Collection.Encryption
{
    public class KeyGenerator
    {
        private string _password;
        private long _maxPrimeValue;
        private Random _randomGen;
        public KeyGenerator(string password)
        {
            _password = password;

            byte[] pass = Encoding.ASCII.GetBytes(password);
            for (int i = 0; i < pass.Length; i++)
            {
                _maxPrimeValue += pass[i];
            }

            _randomGen = new Random();

            _maxPrimeValue = _maxPrimeValue * _randomGen.Next(1, 100);
        }

        public KeyPair GenerateNewKeyPair()
        {
            long p = 1;
            long q = 1;
            GeneratePrimeSeed(ref p, ref q);

            long k = p * q;
            long m = (p - 1) * (q - 1);
            long s = 2;
            while (!AreCoprimes(m, s))
            {
                s = _randomGen.Next(1, (int)m);
            }
            long t = CalculateT(s, m);

            return new KeyPair(new PrivateKey(t, k), new PublicKey(s, k));
        }

        private void GeneratePrimeSeed(ref long p, ref long q)
        {
            while (!IsPrimeNubmer(p) || !IsPrimeNubmer(q))
            {
                p = _randomGen.Next(1, (int)_maxPrimeValue / 10);
                q = _randomGen.Next(1, (int)_maxPrimeValue / 10);
            }
        }

        private long CalculateT(long s, long m)
        {
            s = s % m;
            for (long t = 1; t < m; t++)
            {
                if ((s * t) % m == 1)
                {
                    return t;
                }
            }   
            return 0;
        }

        private bool IsPrimeNubmer(long n)
        {
            if (n == 1) return false;
            if (n == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(n));

            for (int i = 2; i <= boundary; ++i)
            {
                if (n % i == 0) return false;
            }

            return true;
        }

        private bool AreCoprimes(long a, long b)
        {
            return BigInteger.GreatestCommonDivisor(a, b) == 1;
        }
    }
}
