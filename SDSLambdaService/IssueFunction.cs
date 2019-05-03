using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using SDSDAL.Controller;
using SDSDAL.Enum;
using SDSDAL.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SDSLambdaService
{
    public class IssueFunction : BaseFunction
    {
        private const string ISSUE_ID_QUERY_STRING_NAME = "IssueId";

        public APIGatewayProxyResponse AddIssue(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");

            //IssueInfo info = new IssueInfo()
            //{
            //    Subject = "Test",
            //    Description = "TESTTTTTT",
            //    CategoryId = CategoryTypes.None,
            //    PriorityId = PriorityTypes.High,
            //    DueDate = DateTime.Today,
            //    Status = StatusTypes.New,
            //    CreatedBy = "kannop"
            //};
            //var json = JsonConvert.SerializeObject(info);
            
            IssueInfo info = JsonConvert.DeserializeObject<IssueInfo>(request.Body);

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(new IssueController().AddIssue(info)),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/json" } }
            };

            return response;
        }

        public APIGatewayProxyResponse GetIssues(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(new IssueController().GetIssues()),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/json" } }
            };

            return response;
        }

        public APIGatewayProxyResponse GetIssue(APIGatewayProxyRequest request, ILambdaContext context)
        {
            int issueId = 0;
            if (request.PathParameters != null && request.PathParameters.ContainsKey(ISSUE_ID_QUERY_STRING_NAME))
                issueId = Convert.ToInt32(request.PathParameters[ISSUE_ID_QUERY_STRING_NAME]);
            else if (request.QueryStringParameters != null && request.QueryStringParameters.ContainsKey(ISSUE_ID_QUERY_STRING_NAME))
                issueId = Convert.ToInt32(request.QueryStringParameters[ISSUE_ID_QUERY_STRING_NAME]);

            if (issueId == 0)
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Body = $"Missing required parameter {ISSUE_ID_QUERY_STRING_NAME}"
                };
            }

            IssueInfo info = new IssueController().GetIssue(issueId);
            if (info == null)
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.NoContent,
                    Body = $"Data not found for issue id {issueId}"
                };
            }

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(info),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/json" } }
            };
        }

    }
}
