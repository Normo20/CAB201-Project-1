using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Search16s
{
    class Levels
    {

        /// <summary>
        ///The class levels contains all of the functions relating to levels 1-3 and runs them through main.
        /// </summary>

        public static void Level1(string file, string lineNum, string sequence)
        {

            /// <summary>
            /// This function "Level1" takes three user inputs The file, The line number and the number of sequences wanted
            /// It then goes and finds the desired line number and produces the number of sequences wanted and outputs to the console
            /// providing relevant error messages when invalid input numbers are given
            ///
            /// </summary>
            /// <param name="file">This parameter is the 3rd user input which provides the name of the file to be read</param>
            /// <param name="lineNum">This parameter is the 4th user input which provides the line number which wants to be displayed</param>
            /// <param name="sequence">This parameter is the 5th user input which provides the number of sequences that want to be displayed</param>
            /// <returns>This function returns void</returns>

            string[] inputLines = File.ReadAllLines(file);
            int length = inputLines.Length;
            int lineNum1;

            if (int.TryParse(lineNum, out lineNum1))
            {

            }

            else
            {
                Console.WriteLine("Please enter an integer value for line number");
                Environment.Exit(0);

            }

            int sequence1;

            if (int.TryParse(sequence, out sequence1))
            {

            }

            else
            {
                Console.WriteLine("Please enter an integer value for seuqence length");
                Environment.Exit(0);

            }

            if (lineNum1 <= 0 || lineNum1 > length)
            {
                Console.WriteLine("Please Enter a line number greater then 0 and less then the total length of the file");
                Environment.Exit(0);


            }

            if ((lineNum1 + (sequence1 * 2)) > length)
            {
                Console.WriteLine("Please enter a number of outputs that does not exceed file length");
                Environment.Exit(0);
            }

            if (lineNum1 % 2 == 0)
            {
                Console.WriteLine("You must enter an odd number");

            }

            else if (sequence1 < 0)
            {
                Console.WriteLine("Please enter a positive sequence number");


            }

            else
            {
                for (int i = 0; i < sequence1 * 2; i++, i++)

                    Console.WriteLine("{0}\n{1})", inputLines[i + lineNum1 - 1], inputLines[i + lineNum1]);

            }


        }


        public static void Level2(string file1, string id)
        {

            /// <summary>
            /// This function "level2" takes 2 user inputs file 1 and id and then proceeds to find the id in the file
            /// and print the id and it's matching sequence out to the console.
            /// This program provides relevant error messages when invalid input id is given.
            /// </summary>
            /// <param name="file1">This parameter is the 3rd user input which provides the name of the file to be read</param>
            /// <param name="id">This parameter is the 4th user input which provides the sequence id that is wanted to be found and output</param>
            /// <returns>This program returns void</returns>

            int counter = 0;
            string line;
            int length = file1.Length;
            string[] inputLines = File.ReadAllLines(file1);
            string result = string.Empty;
            System.IO.StreamReader file = new System.IO.StreamReader(file1);

            //This method iterates through the file incrementing a line counter until the line matches the input id
            //Then it prints the line contianing the id and the line below it containing the sequence.
            // The loop also stores the result of the search in the variabe result so it can tell if result has been found.

            while ((line = file.ReadLine()) != null)
            {

                if (line.Contains(id))
                {
                    line = null;
                    var text = line;
                    result = text;

                    Console.WriteLine("{0}\n{1})", inputLines[counter], inputLines[counter + 1]);
                }

                else
                    counter++;
            }

            if (result == (""))
            {
                Console.WriteLine("Error sequence {0} not found", id);

            }

            // Closes the file and Suspends the screen.  

            file.Close();
            System.Console.ReadLine();

        }


        public static void Level3(string inputFile, string queryFile, string resultFile)
        {

            /// <summary>
            /// This function level 3 takes 3 user inputs a filename, a querfyile and the name for an ouput file
            /// it then reads the query file for sequence id's and finds them in the inputfile
            ///proceeding to create an output file and print to it the designated id's and sequences 
            /// providing relevant error messages to the console when id's aren't found
            /// </summary>
            /// <param name="inputFile">This parameter is the 3rd user input which provides the name of the file to be read</param>
            /// <param name="queryFile">This parameter is the 4th user input which provides the name of the query file to be read</param>
            /// <param name="resultFile">This parameter is the 5th user input which provides the name of the file to be created</param>
            /// <returns>This function returns void </returns>
 
            if (File.Exists(queryFile))
            {

            }

            else
            {
                Console.WriteLine("Please enter a valid file name");
                Environment.Exit(0);
            }

            var lineCount = File.ReadLines(queryFile).Count();

            for (int i = 0; i < lineCount; i++)
            {
                string[] inputLines = File.ReadAllLines(inputFile);
                string[] queryLines = File.ReadAllLines(queryFile);
                string query1 = queryLines[i];
                string result1 = string.Empty;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string line;
                string result = string.Empty;
                int counter = 0;
                System.IO.StreamReader file =
               new System.IO.StreamReader(inputFile);

                while ((line = file.ReadLine()) != null)
                {

                    if (line.Contains(query1))
                    {
                        line = null;
                        var text = line;
                        result = text;

                        //This function creates the output file in the users documents.
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, resultFile), true))
                        {
                            outputFile.WriteLine("{0}\n{1}", inputLines[counter], inputLines[counter + 1]);
                        }

                    }

                    else
                        counter++;

                }

                if (result == (""))
                {
                    Console.WriteLine("Error sequence {0} not found", query1);
                }


            }

        }
    }

}
