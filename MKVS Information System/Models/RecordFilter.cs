using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKVS_Information_System.Models
{
    public class RecordFilter
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Barangay { get; set; }
        public string Category { get; set; }
        public string AssistanceType { get; set; }
        public string Status { get; set; }

        public string Event { get; set; }
    }
}
