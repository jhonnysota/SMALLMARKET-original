using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Infraestructura.Tools
{
    public class EncryptHelper
    {
        private static Random _ramdomObj;

        static EncryptHelper()
        {
            _ramdomObj = new Random();
        }

        public static String GetMd5Hash(String key)
        {
            MD5 md5Hasher = MD5.Create();
            Byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(key));
            StringBuilder sBuilder = new StringBuilder();
            for (Int32 i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static Boolean VerifyMd5Hash(String input, String hash)
        {
            String hashOfInput = GetMd5Hash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return (0 == comparer.Compare(hashOfInput, hash)) ? true : false;
        }

        public static String GenerateClave()
        {
            String _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Byte[] randomByte = new Byte[8];
            char[] chars = new char[8];
            Int32 allowedCharCount = _allowedChars.Length;

            for (Int32 i = 0; i < 8; i++)
            {
                _ramdomObj.NextBytes(randomByte);
                chars[i] = _allowedChars[randomByte[i] % allowedCharCount];
            }

            return new String(chars);
        }

        #region "SHA1"

        public static Byte[] GetSHA1Hash(String key)
        {
            return GetSHA1Hash(Encoding.Default.GetBytes(key));
        }

        public static Byte[] GetSHA1Hash(Byte[] key)
        {
            var sha1Hasher = SHA1.Create();
            return sha1Hasher.ComputeHash(key);
        }

        /// <summary>
        /// Comprueba que dos hash sean iguales
        /// </summary>
        /// <param name="hashInput"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static Boolean VerifySHA1Hash(Byte[] hashInput, Byte[] hash)
        {
            return hash.SequenceEqual(hashInput);
        }

        /// <summary>
        /// Comprueba que el hash de la cadena input sea igual al hash pasado por parámetro
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static Boolean VerifySHA1Hash(String input, Byte[] hash)
        {
            var hashInput = GetSHA1Hash(input);
            return hash.SequenceEqual(hashInput);
        }

        #endregion

        /// <summary>
        /// Encripta cualquier texto usando el algoridmo Rijndael.
        /// </summary>
        /// <param name="rawText">texto a encryptar</param>
        /// <returns>Texto encriptado en Base64.</returns>
        public static String Encrypt(String rawText)
        {
            var rijndaelCipher = new RijndaelManaged();
            Byte[] rawTextData = Encoding.UTF8.GetBytes(rawText);

            Rfc2898DeriveBytes secretKey = GetSecretKey();

            using (var encryptor = rijndaelCipher.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(rawTextData, 0, rawTextData.Length);
                        cryptoStream.FlushFinalBlock();
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// Desencripta un texto previamente encriptado con el algoritmo Rijndael.
        /// </summary>
        /// <param name="encryptText">Texto encriptado a desencriptar.</param>
        /// <returns>Texto desencriptado.</returns>
        public static String Decrypt(String encryptText)
        {
            try
            {
                var rijndaelCipher = new RijndaelManaged();
                Byte[] encryptTextData = Convert.FromBase64String(encryptText);

                Rfc2898DeriveBytes secretKey = GetSecretKey();

                using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
                {
                    using (var memoryStream = new MemoryStream(encryptTextData))
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            var plainText = new Byte[encryptTextData.Length];
                            Int32 decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
                            return Encoding.UTF8.GetString(plainText, 0, decryptedCount);
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Encripta cualquier texto usando el algoridmo Rijndael.
        /// </summary>
        /// <param name="rawText">texto a encryptar</param>
        /// <returns>Array de bytes con el texto encriptado</returns>
        public static Byte[] EncryptToByte(String rawText)
        {
            var rijndaelCipher = new RijndaelManaged();
            Byte[] rawTextData = Encoding.UTF8.GetBytes(rawText);

            Rfc2898DeriveBytes secretKey = GetSecretKey();

            using (var encryptor = rijndaelCipher.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(rawTextData, 0, rawTextData.Length);
                        cryptoStream.FlushFinalBlock();
                        return memoryStream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Encripta cualquier texto usando el algoridmo Rijndael.
        /// </summary>
        /// <param name="rawByte">array de bytes a encryptar</param>
        /// <returns>Array de bytes con el texto encriptado</returns>
        public static Byte[] EncryptToByte(Byte[] rawByte)
        {
            var rijndaelCipher = new RijndaelManaged();
            Rfc2898DeriveBytes secretKey = GetSecretKey();

            using (var encryptor = rijndaelCipher.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(rawByte, 0, rawByte.Length);
                        cryptoStream.FlushFinalBlock();
                        return memoryStream.ToArray();
                    }
                }
            }
        }

        public static String ToHex(Byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];

            Byte b;

            for (Int32 bx = 0, cx = 0; bx < bytes.Length; ++bx, ++cx)
            {
                b = ((Byte)(bytes[bx] >> 4));
                c[cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);

                b = ((Byte)(bytes[bx] & 0x0F));
                c[++cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);
            }

            return new String(c);
        }

        public static Byte[] HexToBytes(String str)
        {
            if (str.Length == 0 || str.Length % 2 != 0)
                return new Byte[0];

            Byte[] buffer = new Byte[str.Length / 2];
            char c;
            for (Int32 bx = 0, sx = 0; bx < buffer.Length; ++bx, ++sx)
            {
                // Convert first half of Byte
                c = str[sx];
                buffer[bx] = (Byte)((c > '9' ? (c > 'Z' ? (c - 'a' + 10) : (c - 'A' + 10)) : (c - '0')) << 4);

                // Convert second half of Byte
                c = str[++sx];
                buffer[bx] |= (Byte)(c > '9' ? (c > 'Z' ? (c - 'a' + 10) : (c - 'A' + 10)) : (c - '0'));
            }

            return buffer;
        }

        /// <summary>
        /// Desencripta un texto previamente encriptado con el algoritmo Rijndael.
        /// </summary>
        /// <param name="encryptByte">Array de bytes del texto encriptado a desencriptar.</param>
        /// <returns>Texto desencriptado.</returns>
        public static String Decrypt(Byte[] encryptByte)
        {
            try
            {
                var rijndaelCipher = new RijndaelManaged();

                Rfc2898DeriveBytes secretKey = GetSecretKey();

                using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
                {
                    using (var memoryStream = new MemoryStream(encryptByte))
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            var plainText = new Byte[encryptByte.Length];
                            Int32 decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
                            return Encoding.UTF8.GetString(plainText, 0, decryptedCount);
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private static Rfc2898DeriveBytes GetSecretKey()
        {
            //const String encryptionKey = "s3ñ0R-d3-10$-@n¡110$";
            const String encryptionKey = "L0$-c4b4113R0$-d31-Z0d¡4c0";
            Byte[] salt = Encoding.UTF8.GetBytes(encryptionKey);

            var secretKey = new Rfc2898DeriveBytes(encryptionKey, salt);
            return secretKey;
        }

    }
}
