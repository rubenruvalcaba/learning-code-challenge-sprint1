using System.Collections;
using System.Collections.Generic;

public class Google
{

    public static bool IsPairSumTo(int[] array, int sum)
    {

        System.Array.Sort(array);
        int left = 0;
        int rigth = array.Length - 1;

        while (left < rigth)
        {
            var currentSum = array[left] + array[rigth];
            if (currentSum == sum)
                return true;

            if (currentSum > sum)
                rigth--;
            if (currentSum < sum)
                left++;

        }

        return false;
    }

    public static bool IsPairSumToNoSort(int[] array, int sum)
    {

        HashSet<int> pass = new HashSet<int>();
        for (var i = 0; i < array.Length; i++)
        {

            var thisNumber = array[i];
            var requiredPair = sum - thisNumber;
            if (pass.Contains(requiredPair))
                return true;

            pass.Add(array[i]);
        }
        return false;
    }

}