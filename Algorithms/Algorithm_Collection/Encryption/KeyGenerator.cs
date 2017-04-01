using System;
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
            for(int i = 0; i < pass.Length; i++)
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
            long s = 1;
            while (CheckCoPrimeness(s, m))
            {
                s = _randomGen.Next(1, (int)m);
            }
            long t = CalculateT(s, m);

            return new KeyPair(new PrivateKey(t, k), new PublicKey(s, k));
        }

        private void GeneratePrimeSeed(ref long p, ref long q)
        {
            while(!IsPrimeNubmer(p) || !IsPrimeNubmer(q))
            {
                p = _randomGen.Next(1,(int)_maxPrimeValue) / 5;
                q = _randomGen.Next(1, (int)_maxPrimeValue) / 5;
            }
        }

        private long CalculateT(long s, long m)
        {
            long t = 0;
            while((s * t) % m != 1)
            {
                t = _randomGen.Next(1, (int)_maxPrimeValue);
            }
            return t;
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

        private bool CheckCoPrimeness(long u, long v)
        {
            while (u != 0 && v != 0)
            {
                if (u > v)
                    u %= v;
                else
                    v %= u;
            }
            return Math.Max(u, v) == 1;
        }
    }
}
