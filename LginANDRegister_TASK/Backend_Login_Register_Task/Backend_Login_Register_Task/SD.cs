using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Backend_Login_Register_Task
{
    public static class SD
    {
        public static string Encrypt(string username, byte[] key, byte[] iv)
        {
            // Create an Aes object
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                // Create an encryptor to perform the stream transform
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // Create the streams used for encryption
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Write the plaintext to the stream
                            swEncrypt.Write(username);
                        }

                        // Return the encrypted bytes from the memory stream
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }
    
public static string Decrypt(string cipherText, byte[] key, byte[] iv)
{
    // Create an Aes object
    using (Aes aes = Aes.Create())
    {
        aes.Key = key;
        aes.IV = iv;

        // Create a decryptor to perform the stream transform
        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        // Create the streams used for decryption
        using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
        {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    // Read the decrypted bytes from the decrypting stream
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}
    }
}
