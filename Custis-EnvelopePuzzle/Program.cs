using System;
using System.Collections.Generic;

namespace Custis_EnvelopePuzzle
{
    // This program bellow is my code but it cannot find the full path.
    class Program
    {
        static void Main(string[] args)
        {
            // The plan was to set the pathts that need to be taken and then loop throw tham whit the needed condititon.
            var connectivePoints = new List<string>()
            { "12", "13", "14", "21", "23", "24", "31", "32", "34", "35", "41", "42", "43", "45", "53", "54"};

            var allPaths = new List<List<string>>();

            // The first for each is to loop through all the connective points and make a different start every time
            foreach (var point in connectivePoints)
            {
                allPaths.Add(FindPath(point, connectivePoints));

            }

            foreach (var path in allPaths)
            {
                if (path.Count > 1)
                {
                    foreach (var item in path)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        // This is a function that returns a path whit different start point
        private static List<string> FindPath(string sPoint, List<string> connectivePoints)
        {

            string startPoint = sPoint;
            string temporaryPoint = sPoint;

            List<string> path = new List<string>();
            // First we add the starting point
            path.Add(startPoint);
            // Then whit for loop we iterate through the list and with the condition wi determinate the next point 
            for (var i = 0; i < connectivePoints.Count; i++)
            {
                var point = connectivePoints[i];
                if (!path.Contains(point) && point[0] == temporaryPoint[1] && point[1] != temporaryPoint[0] && !path.Contains(Reverse(point)))
                {

                    path.Add(point);
                    temporaryPoint = point;

                    i = 0;
                }
            }
            // But I got stuck whit the iteration of the seccond, third, fourth and fifth start point
            // Tried my best but i will find a solution in time it's a vary intresting problem to be solved

            return path;
        }

        // Simple reverse string method for checking allready crossed paths/points
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
