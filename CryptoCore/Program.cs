using CryptoCore.Interfaces;
using System;

namespace CryptoCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICryptography crypto = new Cryptography();

            Processor proc = new Processor(crypto);

            proc.Execute();
        }
    }
}
