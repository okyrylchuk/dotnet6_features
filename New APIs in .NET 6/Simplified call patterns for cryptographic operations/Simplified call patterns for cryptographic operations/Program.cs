
    using System.Security.Cryptography;

    static byte[] Decrypt(byte[] key, byte[] iv, byte[] ciphertext)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;

            return aes.DecryptCbc(ciphertext, iv, PaddingMode.PKCS7);
        }
    }

