using System.Collections.Generic;

namespace datavizapp.Data
{
    public class DevicesData
    {
        public DevicesData()
        {
            DevicesToClients = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> DevicesToClients { get; }

        // The method checks whether the record contains new data and if so, adds it to devices data.
        public void AddEntry(AirBnbSessionRecord record)
        {
            // In case record's device already present in the data
            if (DevicesToClients.ContainsKey(record.DeviceAppCombo))
            {
                // Check if we already know that record's user uses this device
                if (!DevicesToClients[record.DeviceAppCombo].Contains(record.VisitorId))
                {
                    DevicesToClients[record.DeviceAppCombo].Add(record.VisitorId);
                }
            }
            // In case the record contains new type of device
            else
            {
                DevicesToClients.Add(record.DeviceAppCombo, new List<string>() { record.VisitorId });
            }
        }
    }
}
