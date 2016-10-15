using System;

namespace datavizapp.Data
{
    public class AirBnbSessionRecord
    {
        public string VisitorId { get; set; }

        public Guid SessionId { get; set; }

        // The number of session on a given day for a visitor
        public int SessionNumber { get; set; }

        // User agent of the session
        public string UserAgent { get; set; }

        // Parsed out device/app combo from user agent
        public string DeviceAppCombo { get; set; }

        // Date stamp of session
        public DateTime SessionDate { get; set; }

        public DateTime SessionStart { get; set; }

        public DateTime SessionEnd { get; set; }

        // Binary flag indicating if the visitor performed a search during the session
        public bool DidSearch { get; set; }

        // Binary flag indicating if the visitor sent a message during the session
        public bool SentMessage { get; set; }

        // Binary flag indicating if the visitor sent a booking request during the session
        public bool SentBookingRequest { get; set; }

    }
}









