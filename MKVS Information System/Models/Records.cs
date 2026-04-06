using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKVS_Information_System.Models
{
    public class Records
    {
        public int RecordId { get; set; }        // <-- record_id in DB
        public string SerialNo { get; set; }
        public string DateReceived { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public int AddressId { get; set; }      // maps to address_id FK
        public string Category { get; set; }
        public string AssistanceType { get; set; }
        public string Organization { get; set; }
        public string EventName { get; set; }
        public string EventDate { get; set; }
        public string EventVenue { get; set; }
        public string RequestSolicit { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string Barangay { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
