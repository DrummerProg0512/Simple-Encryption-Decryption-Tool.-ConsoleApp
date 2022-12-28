using System.Text;
using System.Security.Cryptography;

namespace EncryptionDecryptionConsole
{
    public sealed class EncryptDecrypt
    {
        private static string key = "nonlja7teweflfadruna7esivazaquxu";
        public string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aesService = Aes.Create())
            {
                aesService.Key = Encoding.UTF8.GetBytes(key);
                aesService.IV = iv;

                ICryptoTransform encryptionService = aesService.CreateEncryptor(aesService.Key, aesService.IV);

                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream crypStream = new CryptoStream((Stream)memStream, encryptionService, CryptoStreamMode.Write))
                    {
                        using (StreamWriter strWriter = new StreamWriter((Stream)crypStream))
                        {
                            strWriter.Write(plainText);
                        }
                        array = memStream.ToArray();
                    }

                }
            }

            return Convert.ToBase64String(array);
        }

        public string DecryptString(string encryptedText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(encryptedText);

            using (Aes aesService = Aes.Create())
            {
                aesService.Key = Encoding.UTF8.GetBytes(key);
                aesService.IV = iv;

                ICryptoTransform dencryptionService = aesService.CreateDecryptor(aesService.Key, aesService.IV);

                using (MemoryStream memStream = new MemoryStream(buffer))
                {
                    using (CryptoStream crypStream = new CryptoStream((Stream)memStream, dencryptionService, CryptoStreamMode.Read))
                    {
                        using (StreamReader strReader = new StreamReader((Stream)crypStream))
                        {
                            return strReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
