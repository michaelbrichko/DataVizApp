using System;
using System.Collections.Generic;
using System.IO;

namespace datavizapp.Data
{
    public static class AirBnbSessionsData
    {
        private static char delimiter = '|';

        public static IEnumerable<AirBnbSessionRecord> GetAllAirBnbSessionsRecords(string dataFilePath)
        {

            string[] rawDatalines = File.ReadAllLines(dataFilePath);

            var data = new List<AirBnbSessionRecord>();
            for (int i = 1; i < rawDatalines.Length; i++)
            {
                string[] rawEntry = rawDatalines[i].Split(delimiter);

                try
                {
                    var entry = new AirBnbSessionRecord
                    {
                        VisitorId = rawEntry[0],
                        SessionId = Guid.Parse(rawEntry[1]),
                        SessionNumber = int.Parse(rawEntry[2]),
                        UserAgent = rawEntry[3],
                        DeviceAppCombo = rawEntry[4],
                        SessionDate = DateTime.Parse(rawEntry[5]),
                        SessionStart = DateTime.Parse(rawEntry[6]),
                        SessionEnd = DateTime.Parse(rawEntry[7]),
                        DidSearch = rawEntry[8].Equals("1"),
                        SentMessage = rawEntry[9].Equals("1"),
                        SentBookingRequest = rawEntry[10].Equals("1"),
                    };

                    data.Add(entry);
                }
                catch (Exception e)
                {
                   Console.WriteLine("Bad input:'{0}'. Skipping current line.", e.Message);
                }
            }

             return data;
        }
    }
}