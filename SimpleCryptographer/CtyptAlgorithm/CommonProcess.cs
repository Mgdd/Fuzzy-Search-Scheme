using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCryptographer
{
    abstract class CommonProcess
    {
        public abstract string EncryptionStart(string text, string key, bool IsTextBinary);

        public abstract string DecryptionStart(string text, string key, bool IsTextBinary);
    }
}