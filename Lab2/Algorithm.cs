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

        public int CalculateRating(User comparable, int id, string[] userParams)
        {
            int[] inverseArray = new int[comparable.Films.Count];

            FillArray(comparable, userParams, inverseArray);

            return CountInversion(inverseArray);
        }

        //Find inversions
        public List<UserResult> FindInversions(List<User> users, int id)
        {
            List<UserResult> results = new List<UserResult>();

            User user = users[id - 1];

            //Loop through all users
            for (int i = 0; i < users.Count; i++)
            {
                if (i + 1 == user.Id)
                {
                    continue;
                }

                User compareUser = users[i];

                int inverseCount = CalculateRating(user, compareUser);

                //Create result and add to array
                UserResult userResult = new UserResult() 
                { 
                    Id = compareUser.Id,
                    Rating = inverseCount
                };
                results.Add(userResult);
            }

            return results;
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