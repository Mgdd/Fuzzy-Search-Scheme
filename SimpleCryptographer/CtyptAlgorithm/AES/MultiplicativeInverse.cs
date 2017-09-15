using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCryptographer.AES
{
    class MultiplicativeInverse
    {
        #region For Multiplication of GP(2n)

        #region Non-circular left shift
        public static string LeftShift2(string text, int level)
        {
            //string temp = text.Substring(0, count);
            StringBuilder shifted = new StringBuilder(text.Length);
            shifted.Append(text.Substring(1) + "0");

            if (!level.Equals(8))
            {
                for (int i = 0; i <= text.Length - (1 + level); i++)
                {
                    shifted[i] = '0';
                }
            }

            return shifted.ToString();
        }
        #endregion
        
        #region Calculate Multiplicative Inverse
        public static string GetInverse(string text1, string text2, string mx, int n)
        {
            string[] multiplyTable = new string[n];

            if (text1.IndexOf('1') > text2.IndexOf('1'))
            {
                string temp = text2;
                text2 = text1;
                text1 = temp;
            }

            multiplyTable[0] = text1;

            for (int i = 1; i < n; i++)
            {
                multiplyTable[i] = MultiplicativeInverse.LeftShift2(multiplyTable[i - 1], n);

                if (multiplyTable[i - 1][text1.Length - n].Equals('1'))
                {         
                    multiplyTable[i] = MultiplicativeInverse.XOR(multiplyTable[i], mx);
                }
            }

            string Mul_Inverse = "";

            for (int i = 0; i < text2.Length; i++)
            {
                if (text2[i].Equals('1'))
                {
                    if (Mul_Inverse.Equals(""))
                    {
                        Mul_Inverse = multiplyTable[(text2.Length - 1/*2*/) - i];
                    }
                    else
                    {
                        Mul_Inverse = MultiplicativeInverse.XOR(Mul_Inverse, multiplyTable[(text2.Length - 1) - i]);
                    }
                }
            }

            if (Mul_Inverse.Equals(""))
            {
                Mul_Inverse = "00000000";
            }

            return Mul_Inverse;
        }
        #endregion

        #region XOR Operation
        public static string XOR(string text1, string text2)
        {
            if (text1.Length != text2.Length)
            {
                int count = Math.Abs(text1.Length - text2.Length);
                string temp = "";

                for (int i = 0; i < count; i++)
                {
                    temp += "0";
                }

                if (text1.Length > text2.Length)
                {
                    text2 = temp + text2;
                }
                else
                {
                    text1 = temp + text1;
                }
            }

            StringBuilder XORed_Text = new StringBuilder(text1.Length);
            //string XORed_Text = "";

            for (int i = 0; i < text1.Length; i++)
            {
                if (text1[i] != text2[i])
                {
                    XORed_Text.Append("1");
                }
                else
                {
                    XORed_Text.Append("0");
                    //XORed_Text += "0";
                }
            }

            return XORed_Text.ToString();
        }
        #endregion

        #endregion
    }
}