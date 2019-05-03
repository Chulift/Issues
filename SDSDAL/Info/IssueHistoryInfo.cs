using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDAL.Info
{
    public class IssueHistoryInfo
    {
        public int HistoryId { get; set; }
        public int IssueId { get; set; }
        public string Description { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
