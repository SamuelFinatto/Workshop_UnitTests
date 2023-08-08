using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop.Helpers
{
    public class Tools
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public virtual IEnumerable<WeatherForecast> GetRandomForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        public virtual IEnumerable<string> GetUserPermission(IEnumerable<int> permissions)
        {
            List<string> permissionsToReturn = new List<string>();
            List<int> alreadyAdded = new List<int>();

            foreach(int permissionCode in permissions)
            {
                if (alreadyAdded.Contains(permissionCode))
                {
                    continue;
                }

                switch(permissionCode)
                {
                    case 1:
                        permissionsToReturn.Add("Permission1");
                        break;
                    case 2:
                        permissionsToReturn.Add("Permission2");
                        break;
                    case 3:
                        permissionsToReturn.Add("Permission3");
                        break;
                    case 4:
                        permissionsToReturn.Add("Permission4");
                        break;
                    case 5:
                        permissionsToReturn.Add("Permission5");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(permissions));
                }

                alreadyAdded.Add(permissionCode);
            }

            return permissionsToReturn;
        }
    }
}
