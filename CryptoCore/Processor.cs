using CryptoCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CryptoCore
{
    public class Processor
    {
        public Processor(ICryptography crypto)
        {
            this.crypto = crypto;
        }

        private ICryptography crypto;

        public void Execute()
        {
            Console.WriteLine("Enter plaintext...");
            var plainText = Console.ReadLine();

            if (String.IsNullOrEmpty(plainText))
            {
                Console.WriteLine("You have not entered any text to encrypt, closing applicaiton...");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }

            Console.WriteLine("Enter passphrase...");
            var storedPassPhrase = Console.ReadLine();

            if (String.IsNullOrEmpty(storedPassPhrase))
            {
                Console.WriteLine ("You have not entered a passphrase, closing applicaiton...");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }

            Console.WriteLine("Encrypting...");

            var cipherText = crypto.EncryptText(plainText, storedPassPhrase);

            Console.WriteLine(String.Format("Encrypted text: {0}", cipherText));

            Console.WriteLine("Decrypting ciphertext, enter passphrase to decrypt...");

            var passPhraseForDecrypt = Console.ReadLine();

            try
            {
                if (String.IsNullOrEmpty(passPhraseForDecrypt))
                {
                    Console.WriteLine("You have not entered a passphrase, closing applicaiton...");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }

                if (passPhraseForDecrypt != storedPassPhrase)
                {
                    Console.WriteLine("The passphrase you have entered does not match, closing applicaiton...");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }

                var decryptedText = crypto.DecryptText(cipherText, storedPassPhrase, passPhraseForDecrypt);

                if(String.IsNullOrEmpty(decryptedText))
                {
                    Console.WriteLine("You did not specify a password, decryption unsuccessful...");
                }

                Console.WriteLine(String.Format("Decrypted text: {0}", decryptedText));
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
