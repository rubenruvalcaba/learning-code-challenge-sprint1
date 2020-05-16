public class MicrosoftExam
{

    public static int GreatestNumberInArray(int[] array)
    {
        var g = 0;
        var h = 0;
        var t = array.Length - 1;
        var mid = (array.Length - 1) / 2;
        var m = mid;
        while (h < t)
        {
            if (array[h] > array[t])
                g = array[h];
            else
                g = array[t];
            h++;
            t--;
        }

        return g;
    }

    public static void SortArray(int[] arr)
    {
        var swapped = true;
        while (swapped)
        {
            swapped = false;
            for (var i = 0; i < arr.Length - 1; i++)
            {

                if (arr[i] > arr[i + 1])
                {
                    var t = arr[i + 1];
                    var n = arr[i];
                    arr[i] = t;
                    arr[i + 1] = n;
                    swapped = true;
                }

            }
        }

    }

}