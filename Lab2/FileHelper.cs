using Lab2Classes;

namespace Lab2
{
    public class FileHelper
    {
        //Read results from file
        public async Task<Dictionary<int, List<UserResult>>> ReadResults(string file, int userId)
        {
            if (userId < 1)
            {
                throw new ArgumentException("userId must be >= 1");
            }

            if (!File.Exists(file))
            {
                throw new FileNotFoundException("File does not exist!");
            }

            //Open file
            using var fileStream = File.OpenRead(file);
            using var reader = new StreamReader(fileStream);

            //Read data parameters
            string? parameters = await reader.ReadLineAsync();

            if (string.IsNullOrEmpty(parameters))
            {
                throw new InvalidDataException("Invalid file data parameters");
            }

            //Split data parameters
            string[] strs = parameters.Split(' ');
            int usersAmount = 0;
            int filmsAmount = 1;

            switch (strs.Length)
            {
                case 2:
                    {
                        usersAmount = int.Parse(strs[0]);
                        filmsAmount = int.Parse(strs[1]);
                        break;
                    }
                case 1:
                    {
                        usersAmount = int.Parse(strs[0]);
                        break;
                    }
                default:
                    throw new InvalidDataException("Invalid amount of file data parameters");
            }

            if (userId > usersAmount)
            {
                throw new ArgumentException("userId exceeds total amount of users present in file");
            }

            //Results hashTable
            Dictionary<int, List<UserResult>> result = new Dictionary<int, List<UserResult>>();
            List<User> usersBuffer = new List<User>();
            Algorithm alg = new Algorithm();
            User? comparedUser = null;

            //Reading users data and filling results
            for (int i = 1; i <= usersAmount; i++)
            {
                //Reading line
                string? userData = await reader.ReadLineAsync();

                if (string.IsNullOrEmpty(userData))
                {
                    throw new InvalidDataException("Invalid user data");
                }

                //Spliting parameters
                string[] userParams = userData.Split(" ");

                if (userParams.Length != filmsAmount + 1)
                {
                    throw new InvalidDataException("Invalid user data");
                }

                int id = int.Parse(userParams[0]);

                //Decide what to do with user

                //Found compared user
                if (id == userId)
                {
                    comparedUser = CreateUser(id, userParams);

                    //If buffer is not empty, fill with results
                    if (usersBuffer.Count != 0)
                    {
                        foreach(var u in usersBuffer)
                        {
                            UserResult newRes = new UserResult()
                            {
                                Id = u.Id,
                                Rating = alg.CalculateRating(comparedUser, u)
                            };

                            AddResult(result, newRes);
                        }
                    }
                }
                else
                {
                    //Add new user to buffer because compared user isn't found yet
                    if (comparedUser == null)
                    {
                        User newUser = CreateUser(id, userParams);
                        usersBuffer.Add(newUser);
                    }
                    //Compared user found, calculate inversion and add into dictionary
                    else
                    {
                        UserResult newRes = new UserResult()
                        {
                            Id = id,
                            Rating = alg.CalculateRating(comparedUser, userParams)
                        };
                        AddResult(result, newRes);
                    }
                }
            }

            return result;
        }

        //Add result into dictionary
        private void AddResult(Dictionary<int, List<UserResult>> dic, UserResult res)
        {
            if (!dic.ContainsKey(res.Rating))
            {
                dic.Add(res.Rating, new List<UserResult>() { res });
            }
            else
            {
                dic[res.Rating].Add(res);
            }
        }

        //Create user object
        private User CreateUser(int id, string[] userParams)
        {
            User user = new User()
            {
                Id = id
            };

            for(int i = 1; i < userParams.Length; i++)
            {
                user.Films.Add(int.Parse(userParams[i]));
            }

            return user;
        }

        public async Task WriteUserResultsInFile(string name, Dictionary<int, List<UserResult>> results, int id)
        {
            //Open file
            using FileStream fileStream = File.Create(name);
            using StreamWriter writer = new StreamWriter(fileStream);

            //Write compared user id
            await writer.WriteLineAsync(id.ToString());

            int[] keys = results.Keys.ToArray();

            Array.Sort(keys);

            //Write results
            foreach(var key in keys)
            {
                foreach(var res in results[key])
                {
                    await writer.WriteLineAsync($"{res.Id} {res.Rating}");
                }
            }
        }
    }
}
