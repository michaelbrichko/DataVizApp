using System.Collections.Generic;

namespace datavizapp.Data
{
    public class UserAgentsData
    {
        public UserAgentsData()
        {
            UserAgentsToClients = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> UserAgentsToClients { get; }

        // The method checks whether the record contains new data and if so, adds it to user agents data.
        public void AddEntry(AirBnbSessionRecord record)
        {
            // In case record's user agent is already present in the data
            if (UserAgentsToClients.ContainsKey(record.UserAgent))
            {
                // Check if we already know that record's user uses this user agent
                if (!UserAgentsToClients[record.UserAgent].Contains(record.VisitorId))
                {
                    UserAgentsToClients[record.UserAgent].Add(record.VisitorId);
                }
            }
            // In case the record contains new type of user agent
            else
            {
                UserAgentsToClients.Add(record.UserAgent, new List<string>() { record.VisitorId });
            }
        }
    }
}
