using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateEntriesRemoval
{
   

    public class UserActivity
    {
        public string Activity { get; set; }

        public UserActivity(string activity)
        {
            Activity = activity;
        }

        public override string ToString()
        {
            return $"Activity: {Activity}";
        }
    }

    public class RemoveDuplicates
    {
        public static void Main(string[] args)
        {
            List<UserActivity> activities = new List<UserActivity>
        {
            new UserActivity("Logged in"),
            new UserActivity("Accessed profile"),
            new UserActivity("Logged in"),
            new UserActivity("Made a purchase"),
            new UserActivity("Accessed profile"),
            new UserActivity("Logged out"),
            new UserActivity("Made a purchase"),
            new UserActivity("Viewed product")
        };

            // 1. Remove duplicate entries.
            var uniqueActivities = activities.Distinct();

            // 2. Display a unique list of user activities.
            Console.WriteLine("Unique user activities:");
            foreach (var activity in uniqueActivities)
            {
                Console.WriteLine(activity);
            }

            Console.ReadKey();
        }
    }
}
