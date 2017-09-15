using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCryptographer.AES
{
    #region Custom Data structure of Matrix
    class Matrix
    {
        #region Private Fields
        private string[,] matrix;
        private int rows = 0;
        private int columns = 0;
        #endregion

        #region Constructor
        public Matrix(int rows, int columns)
            : this("", rows, columns)
        {
        }

        public Matrix(string text)
            : this(text, 4, 4)
        {
        }

        public Matrix(string text, int rows, int columns)
        {
            if (text.Length != columns * rows * 8)
            {
                text = text.PadRight(columns * rows * 8 - text.Length, '0');
            }

            matrix = new string[rows, columns];
            int count = 0;
            this.rows = rows;
            this.columns = columns;

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[j, i] = text.Substring(count * 8, 8);
                    count++;
                }
            }
        }
        #endregion

        public void setState(string text)
        {
            if (text.Length != columns * rows * 8)
            {
                throw new Exception("It's not equal size to state");
            }

            int count = 0;

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[j, i] = text.Substring(count * 8, 8);
                    count++;
                }
            }            
        }

        #region Properties, Indexer
        public int Rows
        {
            get
            {
                return rows;
            }
        }

        public int Columns
        {
            get
            {
                return columns;
            }
        }

        public string this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                //If it gets hexa decimal transform to binary
                if (value.Length == 2)
                {
                    matrix[i, j] = BaseTransform.FromHexToBinary(value);
                }
                else if (value.Length == 8)
                {
                    matrix[i, j] = value;
                }
            }
        }
        #endregion

        #region Overrided ToString method
        public override string ToString()
        {
            StringBuilder text = new StringBuilder(128);
            if (matrix != null)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        text.Append(matrix[i, j]);
                    }
                }
            }

            return text.ToString();
        }
        #endregion

        #region one row operation
        public string[] getRow(int rowindex)
        {
            string[] row = new string[this.columns];

            if (rowindex > this.rows)
            {
                throw new IndexOutOfRangeException("out of row index error.");
            }

            for (int i = 0; i < this.columns; i++)
            {
                row[i] = matrix[rowindex, i];
            }

            return row;
        }

        public void setRow(string[] row, int rowindex)
        {
            if (rowindex > this.rows)
            {
                throw new IndexOutOfRangeException("out of row index error.");
            }

            for (int i = 0; i < this.columns; i++)
            {
                matrix[rowindex, i] = row[i]; 
            }
        }
        #endregion

        #region one column operation
        public string[] getWord(int wordindex)
        {
            string[] word = new string[this.rows];

            if (wordindex > this.rows)
            {
                throw new IndexOutOfRangeException("out of column index error.");
            }

            for (int i = 0; i < this.rows; i++)
            {
                word[i] = matrix[i, wordindex];
            }

            return word;
        }

        public void setWord(string[] word, int wordindex)
        {
            if (wordindex > this.rows)
            {
                throw new IndexOutOfRangeException("out of column index error.");
            }

            for (int i = 0; i < this.rows; i++)
            {
                matrix[i, wordindex] = word[i];
            }
        }
        #endregion

    }
    #endregion

    #region Matrix Operations
    class MatrixMultiplication
    {
        public static Matrix Multiply(Matrix a, Matrix b, bool IsMixColumns)
        {
            if (IsMixColumns == true)
            {
                return MatrixMultiplication.MixColumnsMultiply(a, b);
            }
            else
            {
                return null;
            }
        }

        public static Matrix XOR(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.Rows, a.Columns);

            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    c[i, j] = MultiplicativeInverse.XOR(a[i, j], b[i, j]);
                }
            }

            return c;
        }

        #region Matrix multiplication by MixColumns step
        private static Matrix MixColumnsMultiply(Matrix a, Matrix b)
        {
            /* If A is an m-by-n matrix and B is an n-by-p matrix, then their matrix product AB is the m-by-p matrix (m rows, p columns) */
            //A - m rows, n columns
            //B - n rows, p columns
            //AB - m rows, p columns
            Matrix c = new Matrix(a.Rows, b.Columns);
            //string temp2 = "";


            for (int j = 0; j < c.Columns; j++)
            {
                //temp.Remove(0, temp.Length);

                for (int i = 0; i < c.Rows; i++)
                {
                    StringBuilder temp = new StringBuilder(32);

                    temp.Append(AES.MultiplicativeInverse.GetInverse(a[i, 0], b[0, j], "00011011", 8));
                    temp.Append(AES.MultiplicativeInverse.GetInverse(a[i, 1], b[1, j], "00011011", 8));
                    temp.Append(AES.MultiplicativeInverse.GetInverse(a[i, 2], b[2, j], "00011011", 8));
                    temp.Append(AES.MultiplicativeInverse.GetInverse(a[i, 3], b[3, j], "00011011", 8));

                    string temp2 = "";

                    temp2 = AES.MultiplicativeInverse.XOR(temp.ToString().Substring(0, 8), temp.ToString().Substring(8, 8));
                    
                    temp2 = AES.MultiplicativeInverse.XOR(temp2, temp.ToString().Substring(16, 8));
                    temp2 = AES.MultiplicativeInverse.XOR(temp2, temp.ToString().Substring(24, 8));
                    
                    c[i, j] = temp2;
                }
            }

            //Console.WriteLine(c.ToString());

            return c;
        }
        #endregion
    }
    #endregion
}