using System.Security.Cryptography;
using System.Text;

namespace Tools.Encryption
{
    public class RSAEncryptorTool
    {
        private readonly RSACryptoServiceProvider _service;

        public RSAEncryptorTool(int keySize)
        {
            _service = new RSACryptoServiceProvider(keySize);
        }

        public RSAEncryptorTool(byte[] keys)
        {
            _service = new RSACryptoServiceProvider();
            _service.ImportCspBlob(keys);
        }

        public string Encrypt(string message)
        {
            byte[] passwdInBytes = Encoding.Default.GetBytes(message);
            byte[] cipher = _service.Encrypt(passwdInBytes, true);
            return Convert.ToBase64String(cipher);
        }

        public string Decrypt(string encryptedData)
        {
            if (_service.PublicOnly)
            {
                throw new Exception("On ne peut pas décrypter juste avec la clé publique");
            }

            byte[] cipher = Convert.FromBase64String(encryptedData);
            byte[] decryptedPasswdInBytes = _service.Decrypt(cipher, true);
            return Encoding.Default.GetString(decryptedPasswdInBytes);
        }

        public byte[] Export(bool includePrivateKey)
        {
            return _service.ExportCspBlob(includePrivateKey);
        }
    }
}