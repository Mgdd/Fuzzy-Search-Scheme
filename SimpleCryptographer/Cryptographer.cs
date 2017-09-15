using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleCryptographer
{
    class Cryptographer
    {        
        CommonProcess cProcess = null;

        public Cryptographer(int algorithm_number, FrmDataOwner.ProgressEventHandler IncrementProgress, FrmDataOwner.ProgressInitHandler InitProgress)
        {            
            if (Algorithms.DES == algorithm_number || Algorithms.DES_File == algorithm_number)
            {
                cProcess = new DES.ProcessDES(IncrementProgress, InitProgress);
            }
            else
            {
                cProcess = new AES.ProcessAES(IncrementProgress, InitProgress);
            }
        }
        public void EncryptionStart(string filename, string EncryptedFilename, string key/*, bool IsBinary*/)
        {
            string binarytext = AES.FileIO.FileReadToBinary(filename);
            binarytext =  this.EncryptionStart(binarytext, key, true);
            AES.FileIO.WriteBinaryToFile(EncryptedFilename, binarytext);
            //return cProcess.EncryptionStart(text, key, IsBinary);
        }

        public string EncryptionStart(string text, string key, bool IsBinary)
        {            
            return cProcess.EncryptionStart(text, key, IsBinary);
        }

        public void DecryptionStart(string filename, string DecryptedFilename, string key/*, bool IsBinary*/)
        {
            string binarytext = AES.FileIO.FileReadToBinary(filename);
            binarytext = this.DecryptionStart(binarytext, key, true);
            AES.FileIO.WriteBinaryToFile(DecryptedFilename, binarytext);
            //return cProcess.DecryptionStart(text, key, IsBinary);
        }

        public string DecryptionStart(string text, string key, bool IsBinary)
        {
            return cProcess.DecryptionStart(text, key, IsBinary);
        }
    }
}