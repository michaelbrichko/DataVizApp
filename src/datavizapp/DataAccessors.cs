using System.IO;
using datavizapp.Data;

namespace datavizapp
{
    public class AirBnbDataAccessors
    {
        private static AirBnbDataAccessors airBnbDataAccessors = null;
        private readonly string dataFilePath = Directory.GetCurrentDirectory() + @"\Data\airbnb_session_data.txt";

        public static AirBnbDataAccessors GetInstance()
        {
            return airBnbDataAccessors ?? (airBnbDataAccessors = new AirBnbDataAccessors());
        }

        public DevicesData DevicesData { get; }

        public UserAgentsData UserAgentsData { get; }

        public SessionsData SessionsData { get; }

        private AirBnbDataAccessors()
        {
            // Get all sessions data
            var sessions = AirBnbSessionsData.GetAllAirBnbSessionsRecords(dataFilePath);

            DevicesData = new DevicesData();
            UserAgentsData = new UserAgentsData();
            SessionsData = new SessionsData();

            foreach (var airBnbSessionRecord in sessions)
            {
                // Initialize devices data
                DevicesData.AddEntry(airBnbSessionRecord);

                // Initialize UserAgent data
                UserAgentsData.AddEntry(airBnbSessionRecord);

                // Initialize Sessions data
                SessionsData.AddEntry(airBnbSessionRecord);
            }
        }
    }
}
