using Dapper;
using SDSDAL.Enum;
using SDSDAL.Info;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SDSDAL.Controller
{
    public class IssueController : BaseController
    {
        public IssueInfo AddIssue(IssueInfo info)
        {
            using (var conn = GetSqlConnection())
            {
                info = conn.QueryFirst<IssueInfo>("usp_IssueUpdate", new
                {
                    issueId = info.IssueId,
                    subject = info.Subject,
                    description = info.Description,
                    categoryId = info.CategoryId,
                    priorityId = info.PriorityId,
                    dueDate = info.DueDate,
                    status = info.Status,
                    assignTo = info.AssignTo ?? "",
                    spentTime = info.SpentTime ?? "",
                    updatedBy = info.CreatedBy
                }, commandType: CommandType.StoredProcedure);
            }

            return info;
        }

        public List<IssueInfo> GetIssues()
        {
            return GetIssuesByCriteria();
        }

        public IssueInfo GetIssue(int issueId)
        {
            return GetIssuesByCriteria(issueId: issueId).FirstOrDefault();
        }

        public List<IssueInfo> GetIssuesByCriteria(int issueId = 0, string subject = "", StatusTypes status = StatusTypes.None,
            PriorityTypes priority = PriorityTypes.None, string assignTo = "", DateTime? dueDate = null)
        {
            using (var conn = GetSqlConnection())
            {
                List<IssueInfo> infos = conn.Query<IssueInfo>("usp_IssueGet", new
                {
                    issueId, 
                    subject,
                    status,
                    priorityId = priority,
                    assignTo,
                    dueDate
                }, commandType: CommandType.StoredProcedure).AsList();

                return infos;
            }
        }
    }
}
