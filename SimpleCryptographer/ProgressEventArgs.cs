using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCryptographer
{
    public class ProgressInitArgs : EventArgs
    {
        public ProgressInitArgs(int Maximum)
        {
            this.Maximum = Maximum;
        }

        public int Maximum;
    }

    public class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(int Increment)
        {
            this.Increment = Increment;
        }

        public int Increment;
    }
}
