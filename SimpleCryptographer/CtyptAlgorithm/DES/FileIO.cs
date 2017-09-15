using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SimpleCryptographer.DES
{
    class FileIO
    {
        public static string FileReadToBinary(string filename)
        {
            FileStream fs = new FileStream("C:\\" + filename, FileMode.Open);

            Console.WriteLine("File size : " + fs.Length);

            #region Read from file 100bytes per 1 time and transform to binary data.

            int fileLength = (int)fs.Length;

            StringBuilder text = new StringBuilder((int)fs.Length * 8);

            byte[] bytes = new byte[100];
            int startindex = 0;
            int IsEnd = -1;

            while (fs.Read(bytes, startindex, bytes.Length) != 0)
            {
                if (IsEnd > 0)
                {

                }
                foreach (byte b in bytes)
                {
                    if (text.Length == fileLength * 8)
                    {
                        break;
                    }

                    text.Append(ProcessDES.FromDeciamlToBinary(b));
                }
            }

            fs.Close();

            return text.ToString();

            #endregion
        }

        public static void WriteBinaryToFile(string filename, string binaryText)
        {
            #region Write binary encrypted or decrypted data to file.

            FileStream fs = new FileStream("C:\\"+ filename, FileMode.Create);
            StringBuilder sub_text = new StringBuilder(800);
            byte[] bytes = new byte[100];
            int length = 800;

            for (int i = 0; i <= binaryText.Length / 800; i++)
            {
                int remain = binaryText.Length - i * 800;
                if (remain < 800)
                {
                    length = remain;
                }

                sub_text.Remove(0, sub_text.Length);
                sub_text.Append(binaryText.Substring(i * 800, length));

                for (int j = 0; j < sub_text.Length / 8; j++)
                {
                    bytes[j] = ProcessDES.FromBinaryToByte(sub_text.ToString().Substring(j * 8, 8));
                }

                fs.Write(bytes, 0, sub_text.Length / 8);
            }
            fs.Close();

            #endregion
        }
    }
}
