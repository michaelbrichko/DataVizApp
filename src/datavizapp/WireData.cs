using System.Collections.Generic;
using System.Runtime.Serialization;

namespace datavizapp
{
    /*
     * This property bag represents tha data that is being transfered to the client over the wire
     */
    [DataContract]
    public class WireData
    {
        [DataMember]
        public Dictionary<string, int> DevicesToClientsCount { get; set; }

        [DataMember]
        public Dictionary<string, int> UserAgentsToClientsCount { get; set; }

        [DataMember]
        public Dictionary<string, double> UserToAverageSessionDurationInSeconds { get; set; }
    }
}
