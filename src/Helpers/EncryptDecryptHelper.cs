using System.Security.Cryptography;
using System.Text;

namespace MyCredVault;

internal class EncryptDecryptHelper
{
    public static string Encrypt(string UserId, string plainText)
    {
        // Check arguments.
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");

        if (UserId == null || UserId.Length <= 0)
        {
            throw new ArgumentNullException("UserId");
        }

        byte[] key = Encoding.UTF8.GetBytes(UserId.Substring(0, 32));
        byte[] iv = Encoding.UTF8.GetBytes(UserId.Substring(8, 16));

        return EncryptByAES(plainText, key, iv);
    }

    public static string Decrypt(string UserId, string cipherText)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");

        if (UserId == null || UserId.Length <= 0)
        {
            throw new ArgumentNullException("UserId");
        }

        byte[] key = Encoding.UTF8.GetBytes(UserId.Substring(0, 32));
        byte[] iv = Encoding.UTF8.GetBytes(UserId.Substring(8, 16));

        return DecryptByAES(cipherText, key, iv);
    }

    private static string EncryptByAES(string plainText, byte[] Key, byte[] IV)
    {
        var encrypted = string.Empty;

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }

                    encrypted = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }

    private static string DecryptByAES(string cipherText, byte[] Key, byte[] IV)
    {
        // Declare the string used to hold
        // the decrypted text.
        string plaintext = null;

        byte[] bytes = Convert.FromBase64String(cipherText);

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(bytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }
}
