using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Utility
{   
    /// <summary>
    /// Encrypts/Decrypts files. The encryption type is symmetric, meaning that the same key is used in both processes.
    /// </summary>
    public static class Encryption
    {
        /// <summary>
        /// Encrypts the given filename into the encrypted version of said file. 
        /// </summary>
        /// <param name="unencryptedFileName"></param>
        /// <param name="encryptedFileName"></param>
        /// <param name="key"></param>
        public static void encrypt(string unencryptedFileName, string encryptedFileName, string key)
        {
            //2 Filestream objects are required to encrypt: one to read, one to write
            FileStream fileStreamRead = new FileStream(unencryptedFileName, FileMode.Open, FileAccess.Read);
            FileStream fileStreamWrite = new FileStream(encryptedFileName, FileMode.Create, FileAccess.Write);

            /*DES = Data Encryption Service, This class connects to this service and provides the methods
             * for encryption of the given filename.*/
            DESCryptoServiceProvider cryptoDES = new DESCryptoServiceProvider();

            //Encrypt the key
            cryptoDES.Key = ASCIIEncoding.ASCII.GetBytes(key);

            /*Sets the IV - the IV is a number used along with the key in encryption. Prevents repitition in the encryption process,
             * which makes it harder for hackers to determine the alogrithms used to encrypt.*/
            cryptoDES.IV = ASCIIEncoding.ASCII.GetBytes(key);

            //ICryptoTransform provides the methods for transforming of the files cryptographically.
            ICryptoTransform iCryptoTransform = cryptoDES.CreateEncryptor();

            /*Cryptostream links data streams and cryptographic transformations: links the Write filestreamn object to the
             * ICryptoTransform object*/
            CryptoStream cryptoStream = new CryptoStream(fileStreamWrite, iCryptoTransform, CryptoStreamMode.Write);

            /*The above Write method of CryptoSteamMode writes the encrypted data to the encrypted filestream.
             * The data must be passed in through a byte array format:*/
            byte[] byteArray = new byte[fileStreamRead.Length];

            /*Read the data from the unencrypted filestream: first argument is where the contents will go,
             * second argument is the starting point the array, 3rd is the endpoint of the reading*/
            fileStreamRead.Read(byteArray, 0, byteArray.Length);

            //Do the same thing but now encrypt the file using the cryptostream object
            cryptoStream.Write(byteArray, 0, byteArray.Length);

            //Close all of the streams
            cryptoStream.Close();
            fileStreamRead.Close();
            fileStreamWrite.Close();
        }

        /// <summary>
        /// Decrypts a given file using the defined key. 
        /// </summary>
        /// <param name="encryptedFileName"></param>
        /// <param name="unencryptedFileName"></param>
        /// <param name="key"></param>
        public static void decrypt(string encryptedFileName, string unencryptedFileName, string key)
        {
            //Streamwriter writes to the unencrypted file 
            StreamWriter streamWriterWriteToUnencrypted = new StreamWriter(unencryptedFileName);

            DESCryptoServiceProvider cryptoDES = new DESCryptoServiceProvider();
            cryptoDES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            cryptoDES.IV = ASCIIEncoding.ASCII.GetBytes(key);

            //Filestream object reads encrypted file
            FileStream fileStreamRead = new FileStream(encryptedFileName, FileMode.Open, FileAccess.Read);

            //ICryptoTransform has the decryption methods
            ICryptoTransform iCryptoTransform = cryptoDES.CreateDecryptor();

            //Link ICryptoTransform object to the encrypted file stream
            CryptoStream cryptoStream = new CryptoStream(fileStreamRead, iCryptoTransform, CryptoStreamMode.Read);

            try
            {
                //Streamwriter Write, Flush, Close methods are used in writing to the unecrypted file name.
                streamWriterWriteToUnencrypted.Write(new StreamReader(cryptoStream).ReadToEnd());
                streamWriterWriteToUnencrypted.Flush();
                streamWriterWriteToUnencrypted.Close();
            }
            catch (Exception)
            {
                Exception exception = new Exception("Exception occurred while trying to decrypt this file");
                streamWriterWriteToUnencrypted.Close();
                throw exception;
            }


        }
    }
}
