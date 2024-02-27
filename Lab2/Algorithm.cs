namespace Lab2Classes
{
    public class Algorithm
    {
        //Calculate Rating for user
        public int CalculateRating(User comparable, User compared)
        {
            int[] inverseArray = new int[comparable.Films.Count];

            FillArray(comparable, compared, inverseArray);

            return CountInversion2(inverseArray);
            //return CountInversion(inverseArray);
        }

        public int CalculateRating(User comparable, string[] userParams)
        {
            int[] inverseArray = new int[comparable.Films.Count];

            FillArray(comparable, userParams, inverseArray);

            return CountInversion2(inverseArray);
            //return CountInversion(inverseArray);
        }

        //Fill inversion array
        private void FillArray(User comparable, User compared, int[] arr)
        {
            //Setup array
            for (int j = 0; j < comparable.Films.Count; j++)
            {
                arr[comparable.Films[j] - 1] = compared.Films[j];
            }
        }

        private void FillArray(User comparable, string[] userParams, int[] arr)
        {
            //Setup array
            for (int j = 0; j < comparable.Films.Count; j++)
            {
                arr[comparable.Films[j] - 1] = int.Parse(userParams[j+1]);
            }
        }

        //Count inversion O(n^2)
        private int CountInversion(int[] arr)
        {
            int res = 0;

            //Count inversion O(n^2)
            for (int j = 0; j < arr.Length - 1; j++)
            {
                for (int k = j + 1; k < arr.Length; k++)
                {
                    if (arr[j] > arr[k])
                    {
                        res++;
                    }
                }
            }
            return res;
        }

        //Count inversion O(n*logn)
        private int CountInversion2(int[] arr)
        {
            int[] buf = new int[arr.Length];
            return MergeInversion(arr, buf, 0, arr.Length - 1);
        }

        private int MergeInversion(int[] arr, int[] buf, int left, int right)
        {
            int res = 0;

            if (right > left)
            {
                int m = (left + right) / 2;

                res += MergeInversion(arr, buf, left, m);
                res += MergeInversion(arr, buf, m + 1, right);
                res += MergeInversionSort(arr, buf, left, m + 1, right);
            }

            return res;
        }

        private int MergeInversionSort(int[] arr, int[] buf, int left, int mid, int right)
        {
            int res = 0;

            int i = left;
            int j = mid;
            int cur = left;

            while ((i <= mid - 1) && (j <= right))
            {
                if (arr[i] <= arr[j])
                {
                    buf[cur++] = arr[i++];
                }
                else
                {
                    buf[cur++] = arr[j++];
                    res += mid - i;
                }
            }

            while(i <= mid - 1)
            {
                buf[cur++] = arr[i++];
            }

            while(j <= right)
            {
                buf[cur++] = arr[j++];
            }

            for(int k = left; k <= right; k++)
            {
                arr[k] = buf[k];
            }

            return res;
        }
    }
}