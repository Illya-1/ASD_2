namespace ASD_2;

public static class InversionsCounter
{
    private static int SortAndCountInv(int[] arr)
    {
        return SortAndCountInv(arr, 0, arr.Length-1);
    }

    private static int SortAndCountInv(int[] arr, int left, int right)
    {
        if (left >= right)
        {
            return 0;
        }
        int middleIndex = (left + right)/2;
        int leftInv = SortAndCountInv(arr, left, middleIndex);
        int rightInv = SortAndCountInv(arr, middleIndex + 1, right);
        int splitInv = MergeAndCountInv(arr, left, middleIndex, right);
        return leftInv + rightInv + splitInv;
    }

    private static int MergeAndCountInv(int[] arr, int left, int middle, int right)
    {
        int inversions = 0;
        
        int[] tmp = new int[right - left + 1];
        int tmpIndex = 0;
        
        int leftTmp = left;
        int rightTmp = middle + 1;
        
        while ((leftTmp <= middle) && (rightTmp <= right))
        {
            if (arr[leftTmp] < arr[rightTmp])
            {
                tmp[tmpIndex] = arr[leftTmp];
                leftTmp++;
            }
            else
            {
                tmp[tmpIndex] = arr[rightTmp];
                inversions += middle - leftTmp + 1;
                rightTmp++;
            }

            tmpIndex++;
        }

        for (int i = leftTmp; i <= middle; i++)
        {
            tmp[tmpIndex] = arr[i];
            tmpIndex++;
        }

        for (int i = rightTmp; i <= right; i++)
        {
            tmp[tmpIndex] = arr[i];
            tmpIndex++;
        }

        for (int i = 0; i < tmp.Length; i++)
        {
            arr[left + i] = tmp[i];
        }
        
        return inversions;
    }
    
    private static void IndexBasedPresort(int x, int[,] array)
    {
        if (x > array.GetLength(0) || x < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(x));
        }
        int j = 1;
        while (j < array.GetLength(1))
        {
            //Console.WriteLine($"j = {j}");
            if (array[x, j] > array.Length || array[x, j] < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            if (array[x, j] == j)
            {
                j++;
                continue;
            }

            for (int i = 1; i < array.GetLength(0); i++)
            {
                if (i != x)
                {
                    //Короче, тут вместо i было x, по идее я пофиксил, но хз, может я сейчас всё сломал нахуй. Посмотрим
                    (array[i, j], array[i, array[x, j]]) = (array[i, array[x, j]], array[i, j]);
                }
            }
            (array[x, j], array[x, array[x, j]]) = (array[x, array[x, j]], array[x, j]);
        }
    }

    public static void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write($" {array[i, j]} ");
            }

            Console.WriteLine();
        }
        
        Console.WriteLine();
    }

    private static int[] GetRow(int[,] array, int row)
    {
        int[] res = new int[array.GetLength(1) - 1];
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = array[row, i + 1];
        }

        return res;
    }

    public static (int user, int reverses)[] GetReversesForUser(int user, int[,] array)
    {
        IndexBasedPresort(user, array);
        
        var res = new (int user, int reverses)[array.GetLength(0) - 1];
        for (int i = 0; i < res.Length; i++)
        {
            Console.WriteLine($"Iter {i}");
            if (i+1 == user)
            {
                res[i] = (i+1, -1);
            }
            else
            {
                int[] row = GetRow(array, i+1);
                res[i] = (i+1, SortAndCountInv(row));
            }
        }
        
        //Array.Sort(res, (x, y) => x.reverses.CompareTo(y.reverses));
        return res.OrderBy(pare => pare.reverses * array.GetLength(0) - 1 + pare.user).ToArray();
    }
}