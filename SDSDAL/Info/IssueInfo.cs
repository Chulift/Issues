using SDSDAL.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace SDSDAL.Info
{
    public class IssueInfo
    {
        public int IssueId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public CategoryTypes CategoryId { get; set; }
        public PriorityTypes PriorityId { get; set; }
        public DateTime DueDate { get; set; }
        public StatusTypes Status { get; set; }
        public string AssignTo { get; set; }
        public string SpentTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public IssueInfo()
        {
            DueDate = (DateTime)SqlDateTime.MinValue;
            CreatedDate = (DateTime)SqlDateTime.MinValue;
            UpdatedDate = (DateTime)SqlDateTime.MinValue;
        }
    }
}
