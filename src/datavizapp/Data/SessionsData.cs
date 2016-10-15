using System.Collections.Generic;

namespace datavizapp.Data
{
    public class SessionsData
    {
        public SessionsData()
        {
            UsersToSessions = new Dictionary<string, List<double>>();
        }

        public Dictionary<string, List<double>> UsersToSessions { get; }

        // The method checks whether the record contains new data and if so, adds it to sessions data.
        public void AddEntry(AirBnbSessionRecord record)
        {
            // In case record's user already present in the sessions data
            if (UsersToSessions.ContainsKey(record.VisitorId))
            {
                UsersToSessions[record.VisitorId].Add((record.SessionEnd - record.SessionStart).TotalMinutes);
            }
            // In case the record contains new user id
            else
            {
                UsersToSessions.Add(record.VisitorId, new List<double>() { (record.SessionEnd - record.SessionStart).TotalMinutes });
            }
        }
    }
}
