using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;


namespace D3T1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";

            //CheckFile(filename);

            int numEntries = CountEntries(filename);
            string[] values = new string[numEntries];
            string[] dirMatr = new string[numEntries];
            int[] distMatr = new int[numEntries];

            int[] firstCol = new int[numEntries];


            ReadFile(filename, values);
            getDirections(filename, dirMatr);
            getDistances(filename, distMatr);

            //displayStringMatr(dirMatr); //To check correctly parsed.
            //displayIntMatr(distMatr); //To check correctly parsed.

            

            WriteLine("The final horizontal position is {0}", xPos);
            WriteLine("The final depth is {0}", depth);

            int multiple = xPos * depth;

            WriteLine("The mutiple of these is {0}", multiple);

            ReadLine();

        }


        //*** INPUT ***

        private static int CountEntries(string filename)
        {
            var file = new StreamReader(filename).ReadToEnd();
            var lines = file.Split(new char[] { '\n' });
            var count = lines.Length;
            return count - 1;

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

        private static void getDirections(string filename, string[] dirMatr)
        {
            char DELIM = ' ';

            StreamReader SR = new StreamReader(filename);

            int x = 0;
            while (!SR.EndOfStream)
            {

                string readIn = SR.ReadLine();
                string[] fields;
                fields = readIn.Split(DELIM);
                dirMatr[x] = fields[0];
                x++;
            }
            SR.Close();
        }

        private static void getDistances(string filename, int[] distMatr)
        {
            char DELIM = ' ';

            StreamReader SR = new StreamReader(filename);

            int x = 0;
            while (!SR.EndOfStream)
            {

                string readIn = SR.ReadLine();
                string[] fields;
                fields = readIn.Split(DELIM);
                distMatr[x] = Convert.ToInt32(fields[1]);
                x++;
            }
            SR.Close();
        }


        //*** CALCULATION ***

        private static void travel(string[] dirMatr, int[] distMatr, ref int xPos, ref int depth, ref int aim)
        {
            for (int i = 0; i < dirMatr.Length; i++)
            {
                if (dirMatr[i].Equals("forward"))
                {
                    xPos = xPos + distMatr[i];
                    depth = depth + (aim * distMatr[i]);
                }


                else if (dirMatr[i].Equals("down"))
                {
                    //depth = depth + distMatr[i];
                    aim = aim + distMatr[i];
                }

                else if (dirMatr[i].Equals("up"))
                {
                    //depth = depth - distMatr[i];
                    aim = aim - distMatr[i];
                }

            }
        }

        //*** DEBUGGING ***

        private static void CheckFile(string filename) //For future use.
        {

            if (File.Exists(filename))
            {
                WriteLine("File Exists");
                WriteLine("File was created " + File.GetCreationTime(filename));
                WriteLine("File was laast written to " + File.GetLastWriteTime(filename));
            }
            else
            {
                WriteLine("File does not exist.");
            }

        }

        private static void displayStringMatr(string[] inputMatr)
        {
            for (int i = 0; i < inputMatr.Length; i++)
            {
                WriteLine(inputMatr[i]);
            }
        }

        private static void displayIntMatr(int[] inputMatr)
        {
            for (int i = 0; i < inputMatr.Length; i++)
            {
                WriteLine(inputMatr[i]);
            }
        }
    }
   
}
