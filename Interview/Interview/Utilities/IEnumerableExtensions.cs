namespace Interview.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static bool IsSubsetOfWithoutDuplication<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return !first.Except(second).Any();
            //return second.Intersect(first).Count() == second.Count();
            //return first.All(element => second.Contains(element));
        }

        public static bool IsSubsetOf<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstList = first.ToList();
            firstList.Sort();
            var secondList = second.ToList();
            secondList.Sort();
            int i = 0, j = 0;
            while (i < firstList.Count() && j < secondList.Count())
            {
                while (i < firstList.Count() && j < secondList.Count() && firstList[i].Equals(secondList[j]))
                {
                    i++;
                    j++;
                }
                j++;
            }

            if (i == firstList.Count())
            {
                return true;
            }

            return false;
        }
    }
}
