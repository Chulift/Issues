using System;
using System.Collections.Generic;
using System.Text;

namespace SDSDAL.Info
{
    public class IssueAttachmentInfo
    {
        public int AttachmentId { get; set; }
        public int IssueId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
    }
}
