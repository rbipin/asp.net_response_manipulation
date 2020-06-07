using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OutputFormatter.API.Serializer;
using System.Text;

namespace OutputFormatter.API
{
    public class WashingtonOuputFilterAttribute : ActionFilterAttribute
    {
        public override async void OnResultExecuting(ResultExecutingContext context)
        {
            var response = context.HttpContext.Response;
            if (response.StatusCode != 200)
            {
               base.OnResultExecuting(context);
            }
            var result = context.Result as ObjectResult;
            var serializedResult = WashingtonOutputSerializer.Instance.Serialize(result.Value);
            var resultBytes = Encoding.UTF8.GetBytes(serializedResult);
            response.Headers.Add("Content-Type","application/xml");
            await response.Body.WriteAsync(resultBytes, 0, resultBytes.Length);
            base.OnResultExecuting(context);
        }
    }
}
