using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword
{
    public static class StringExtention
    {
        public static bool OneCharacterDiff(this string @this, string with)
        {
            if (@this.Length != with.Length)
                return false;
            bool found = false;
            for (int i = 0; i < @this.Length; i++)
            {
                if (@this[i] != with[i])
                {
                    if (found)
                        return false;
                    found = true;
                }
            }
            return found;
        }
    }

    public class FindShortestStringPath
    {

        IEnumerable<string> dict;

        IList<string> best;

        private string From;
        private string To;

        public static IEnumerable<string> FindPath(string from, string to, IEnumerable<string> list)
        {
            return new FindShortestStringPath(from, to, list).ShortestPath();
        }

        public FindShortestStringPath(string from, string to, IEnumerable<string> list)
        {
            this.dict = list;
            this.From = from;
            this.To = to;
        }

        public IEnumerable<string> ShortestPath()
        {
            IList<string> path = new List<string>();
            path.Add(From);
            ShortestPath(From, path);
            return this.best;
        }

        private void ShortestPath(string from, IList<string> path)
        {
            if (best != null && best.Count < path.Count)
                return;

            if (To.OneCharacterDiff(from))
            {
                foreach (string s in path)
                {
                    Console.Write(s + ">");
                }
                Console.WriteLine(To);

                if (best == null)
                {
                    best = new List<string>(path);
                }
                else
                    if (path.Count < best.Count)
                    {
                        best = new List<string>(path);
                    }

                return;
            }

            foreach (string str in dict)
            {
                if (from.OneCharacterDiff(str) && !path.Contains(str))
                {
                    path.Add(str);
                    ShortestPath(str, path);
                    path.Remove(str);
                }
            }
        }
    }
}
