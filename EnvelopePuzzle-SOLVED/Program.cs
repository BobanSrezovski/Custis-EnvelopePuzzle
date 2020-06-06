using System;
using System.Collections.Generic;
using System.Text;

namespace EnvelopePuzzle_SOLVED
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawLetter();
        }

        private static void DrawLetter()
        {
            List<String> possibleSolutions = new List<string>();

            for (int i = 0; i < 10000; i++)
            {
                List<string> allLines = InitAllLines();
                Random random = new Random();
                int startLine = random.Next(0, 16);
                string start = allLines[startLine];

                StringBuilder oneSolution = new StringBuilder();

                oneSolution.Append(start);
                allLines.Remove(start);
                allLines.Remove(start.Substring(1) + start.Substring(0, 1));

                DrawOnePath(start, allLines, oneSolution, possibleSolutions);
            }

            int counter = 0;
            foreach (string solution in possibleSolutions)
            {
                counter++;
                Console.WriteLine("Solution " + counter + " : " + solution);
            }
        }

        private static void DrawOnePath(string start, List<string> allLines, StringBuilder oneSolution, List<string> possibleSolutions)
        {
            List<string> nextAvailableLine = new List<string>();
            foreach (string remainingLine in allLines)
            {
                if (remainingLine.StartsWith(start.Substring(1)))
                {
                    nextAvailableLine.Add(remainingLine);
                }
            }

            if (nextAvailableLine.Count == 0)
            {
                if (oneSolution.ToString().Length == 9)
                {
                    if (!possibleSolutions.Contains(oneSolution.ToString()))
                    {
                        possibleSolutions.Add(oneSolution.ToString());
                    }
                }
            }
            else
            {
                Random random = new Random();
                string nextElement = nextAvailableLine[random.Next(0, nextAvailableLine.Count)];
                oneSolution.Append(nextElement.Substring(1));
                allLines.Remove(nextElement);
                allLines.Remove(nextElement.Substring(1) + nextElement.Substring(0, 1));
                DrawOnePath(nextElement, allLines, oneSolution, possibleSolutions);
            }
        }


        private static List<string> InitAllLines()
        {
            List<string> allLines = new List<string>()
            { "12", "13", "14", "21", "23", "24", "31", "32", "34", "35", "41", "42", "43", "45", "53", "54"};

            return allLines;
        }
    }
}
