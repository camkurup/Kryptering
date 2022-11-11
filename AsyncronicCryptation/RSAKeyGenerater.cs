using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsyncronicCryptation
{
    internal class RSAKeyGenerater
    {
        public void RSA()
        {
            RSACryptoServiceProvider myRSA = new RSACryptoServiceProvider();
            //Is obsolete
            AesManaged myAES = new AesManaged();
            byte[] RSAciphertext;
            byte[] plaintext;
            //generate an AES key
            myAES.GenerateKey();
            //Encrypt an AES key with RSA
            RSAciphertext = myRSA.Encrypt(myAES.Key, true);
            //decrypt and recover the AES key
            plaintext = myRSA.Decrypt(myAES.Key, true);

            //is obsolete
            SHA256Managed myHash = new SHA256Managed();
            string someText = "This is some text that are hardecoded";
            //sign the message
            byte[] signature;
            signature = myRSA.SignData(Encoding.ASCII.GetBytes(someText), myHash);
            //Vy a signatureon a given message
            bool verified;

            verified = myRSA.VerifyData(Encoding.ASCII.GetBytes(someText), myHash, signature);
        }
    }
}
