using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymetriskKryptering
{
    internal class GeneretSymetricAlgorithm
    {
        SymmetricAlgorithm mySymetricAlg;
        public void Generate(string cipher)
        {
            //creating algorithms for symetrikcryptation
            //Rijndael is obsolete
            switch (cipher)
            {
                case "DES":
                    mySymetricAlg = DES.Create();
                    break;
                case "3DES":
                    mySymetricAlg = TripleDES.Create();
                    break;
                case "Rijndael":
                    mySymetricAlg = Rijndael.Create();
                    break;
            }
            mySymetricAlg.GenerateIV();
            mySymetricAlg.GenerateKey();
        }
        public byte[] Encrypt(byte[] mess, byte[] key, byte[] iv)
        {
            //takes the generated key and iv from the generater methode
            mySymetricAlg.Key = key;
            mySymetricAlg.IV = iv;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms,
                mySymetricAlg.CreateEncryptor(),
                CryptoStreamMode.Write);
            cs.Write(mess,0, mess.Length);
            cs.Close();
            return ms.ToArray();
        }
        public byte[] Decrypt(byte[] mess, byte[] key, byte[] iv)
        {
            byte[] plaintext = new byte[mess.Length];
            mySymetricAlg.Key = key;
            mySymetricAlg.IV = iv;
            MemoryStream ms = new MemoryStream(mess);
            CryptoStream cs = new CryptoStream(ms,
                mySymetricAlg.CreateDecryptor(),
                CryptoStreamMode.Read);
            cs.Read(plaintext, 0, mess.Length);
            cs.Close();
            return plaintext;
        }
    }
}
