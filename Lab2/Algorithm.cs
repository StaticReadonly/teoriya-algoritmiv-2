namespace Lab2Classes
{
    public class Algorithm
    {
        //Calculate Rating for user
        public int CalculateRating(User comparable, User compared)
        {
            int[] inverseArray = new int[comparable.Films.Count];

            FillArray(comparable, compared, inverseArray);

            return CountInversion(inverseArray);
        }

        public int CalculateRating(User comparable, string[] userParams)
        {
            int[] inverseArray = new int[comparable.Films.Count];

            FillArray(comparable, userParams, inverseArray);

            return CountInversion(inverseArray);
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
    }
}