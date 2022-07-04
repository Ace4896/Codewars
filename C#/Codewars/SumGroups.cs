namespace Codewars
{
    using System.Collections.Generic;
    using System.Linq;

    public static partial class Kata
    {
        // NOTE: A recursive solution is shorter and more readable
        public static int SumGroups(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }

            List<int> finalList = new(arr);
            List<int> tmpList = new();
            bool sumPerformed;

            do
            {
                bool isEven = finalList[0] % 2 == 0;
                int currentSum = finalList[0];
                sumPerformed = false;

                foreach (int num in finalList.Skip(1))
                {
                    if (num % 2 == 0 == isEven)
                    {
                        currentSum += num;
                        sumPerformed = true;
                    }
                    else
                    {
                        tmpList.Add(currentSum);
                        currentSum = num;
                        isEven = !isEven;
                    }
                }

                tmpList.Add(currentSum);

                finalList.Clear();
                finalList.AddRange(tmpList);

                tmpList.Clear();
            }
            while (sumPerformed);

            return finalList.Count;
        }
    }
}
