using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCore.Interfaces
{
    public interface ICryptography
    {
        string PasswordHash { get; set; }

        string SaltKey { get; set; } 

        string VIKey { get; set; }

        string EncryptText(string plainText, string passPhrase);

        string DecryptText(string cipherText, string storedPassPhrase, string passPhraseForDecrypt);
    }
}
