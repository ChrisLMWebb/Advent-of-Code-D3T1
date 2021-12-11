using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using System.Collections;


namespace D3T1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
                        
            int numRows = CountRows(filename);
            string[] arrayRows = new string[numRows];
            GetRows(filename, arrayRows);
            int numCols = CountCols(filename, arrayRows);
            char[,] dataArray = new char[numRows, numCols];
            GetArray(arrayRows, numRows, dataArray);

            int gamma = 0;
            gamma = GetGamma(dataArray, numCols, numRows);

            int epsilon = 0;
            epsilon = GetEpsilon(dataArray, numCols, numRows);

            //WriteLine(dataArray[1,11]);
            //WriteLine("Num Rows " + numRows);
            //WriteLine("Num Cols " + numCols);
            WriteLine(gamma);
            WriteLine(epsilon);

            int powerConsumption = gamma * epsilon;
            WriteLine(powerConsumption);

            ReadLine();


        }

        private static int CountRows(string filename)
        {
            var file = new StreamReader(filename).ReadToEnd();
            var lines = file.Split(new char[] { '\n' });
            var count = lines.Length;
            return count - 1;

        }

        private static int CountCols(string filename, string[] arrayRows)
        {
            int numCols = arrayRows[0].Length;
            return numCols;

        }

        private static void GetArray(string[] arrayRows, int numRows, char[,] dataArray)
        {
            for (int i = 0; i < numRows; i++)
            {
                char[] tempRow = arrayRows[i].ToCharArray();
                for (int j = 0; j < arrayRows[i].Length; j++)
                {
                    dataArray [i, j] = tempRow [j];
                }
            }     
            
        }

        private static void GetRows(string filename, string[] arrayRows)
        {
            ReadFile(filename, arrayRows);
        }

        private static void ReadFile(string filename, string[] values)
        {
            StreamReader SR = new StreamReader(filename);

            int x = 0;
            while (!SR.EndOfStream)
            {

                string val = SR.ReadLine();
                values[x] = val;
                x++;
            }
            SR.Close();
        }

        private static int GetGamma(char[,] dataArray, int numCols, int numRows)
        {
            string binaryNumStr = "";
            
            for (int j = 0;j < numCols; j++)
            {
                int countOnes = 0;
                int countZeros = 0;

                for (int i = 0; i < numRows; i++)
                {
                    if (dataArray[i,j] == '0')
                    {
                        countZeros++;
                    }
                    else if (dataArray[i, j] == '1')
                    {
                        countOnes++;
                    }
                    else
                    {
                        WriteLine("Error");                    }
                }

                if (countZeros > countOnes)
                    binaryNumStr = binaryNumStr + "0";
                else binaryNumStr = binaryNumStr + "1";

                
            }

            int gamma = Convert.ToInt32(binaryNumStr, 2);
            return gamma;

        }

        private static int GetEpsilon(char[,] dataArray, int numCols, int numRows)
        {
            string binaryNumStr = "";

            for (int j = 0; j < numCols; j++)
            {
                int countOnes = 0;
                int countZeros = 0;

                for (int i = 0; i < numRows; i++)
                {
                    if (dataArray[i, j] == '0')
                    {
                        countZeros++;
                    }
                    else if (dataArray[i, j] == '1')
                    {
                        countOnes++;
                    }
                    else
                    {
                        WriteLine("Error");
                    }
                }

                if (countZeros > countOnes)
                    binaryNumStr = binaryNumStr + "1";
                else binaryNumStr = binaryNumStr + "0";


            }

            int gamma = Convert.ToInt32(binaryNumStr, 2);
            return gamma;

        }
    }
}