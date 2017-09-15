using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCryptographer.AES
{
    class BaseTransform
    {
        #region Transform a text to a hex
        public static string FromTextToHex(string text)
        {
            StringBuilder hexstring = new StringBuilder(text.Length * 2);

            foreach (char word in text)
            {
                hexstring.Append(String.Format("{0:X}", Convert.ToInt32(word)));
            }

            return hexstring.ToString();
        }
        #endregion

        #region Transform a hex or a binary number to text
        public static string FromHexToText(string hexstring)
        {
            StringBuilder text = new StringBuilder(hexstring.Length / 2);

            for (int i = 0; i < (hexstring.Length / 2); i++)
            {
                string word = hexstring.Substring(i * 2, 2);
                text.Append((char)Convert.ToInt32(word, 16));
            }

            return text.ToString();
        }

        public static string FromBinaryToText(string binarystring)
        {
            StringBuilder text = new StringBuilder(binarystring.Length / 8);

            for (int i = 0; i < (binarystring.Length / 8); i++)
            {
                string word = binarystring.Substring(i * 8, 8);
                text.Append((char)Convert.ToInt32(word, 2));
                //text += (char)Convert.ToInt32(word, 16);
            }

            return text.ToString();
        }
        #endregion

        #region Set a length of text to multiple of 64 bits
        public static string setTextMutipleOf64Bits(string text)
        {
            int maxLength = 0;

            if ((text.Length % 64) != 0)
            {
                maxLength = ((text.Length / 64) + 1) * 64;
            }

            text = text.PadRight(maxLength, '0');

            return text;
        }
        #endregion

        #region Transform an integer to binary number
        public static string FromDeciamlToBinary(int binary)
        {
            if (binary < 0)
            {
                Console.WriteLine("It requires a integer greater than 0.");
                return null;
            }

            string binarystring = "";
            int factor = 128;

            for (int i = 0; i < 8; i++)
            {
                if (binary >= factor)
                {
                    binary -= factor;
                    binarystring += "1";
                }
                else
                {
                    binarystring += "0";
                }
                factor /= 2;
            }

            return binarystring;
        }

        public static byte FromBinaryToByte(string binary)
        {
            byte value = 0;
            int factor = 128;

            for (int i = 0; i < 8; i++)
            {
                if (binary[i] == '1')
                {
                    value += (byte)factor;
                }

                factor /= 2;
            }

            return value;
        }
        #endregion

        #region Transform a hex integer to a binary number
        public static string FromHexToBinary(string hexstring)
        {
            StringBuilder binarystring = new StringBuilder(hexstring.Length * 4);            

            try
            {
                for (int i = 0; i < hexstring.Length; i++)
                {
                    int hex = Convert.ToInt32(hexstring[i].ToString(), 16);

                    int factor = 8;

                    for (int j = 0; j < 4; j++)
                    {
                        if (hex >= factor)
                        {
                            hex -= factor;
                            binarystring.Append("1");
                        }
                        else
                        {
                            binarystring.Append("0");
                        }
                        factor /= 2;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - wrong hexa integer format.");
            }

            return binarystring.ToString();
        }
        #endregion        

        #region Transform 4bit binary to hexa decimal
        public static string FromBinaryToHex(string binarystring)
        {
            StringBuilder hexstring = new StringBuilder(binarystring.Length / 4);

            for (int i = 0; i < binarystring.Length/4; i++)
            {
                int word = Convert.ToInt32(binarystring.Substring(i*4, 4), 2);

                hexstring.Append(String.Format("{0:X}", word));
            }

            return hexstring.ToString();
        }
        #endregion
        
        public static string FromTextToBinary(string text)
        {
            StringBuilder binarystring = new StringBuilder(text.Length * 8);

            foreach (char word in text)
            {
                int binary = (int)word;
                int factor = 128;

                for (int i = 0; i < 8; i++)
                {
                    if (binary >= factor)
                    {
                        binary -= factor;
                        binarystring.Append("1");
                    }
                    else
                    {
                        binarystring.Append("0");
                    }
                    factor /= 2;
                }
            }

            return binarystring.ToString();
        }

        #region Set a length of text to multiple of 128 bits
        public static string setTextMutipleOf128Bits(string text)
        {
            if ((text.Length % 128) != 0)
            {
                int maxLength = 0;
                maxLength = ((text.Length / 128) + 1) * 128;

                text = text.PadRight(maxLength, '0');
            }

            return text;
        }
        #endregion
    }
}