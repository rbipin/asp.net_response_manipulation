using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serialize_in_action_filter.Serializer;
using System.Text;

namespace Serialize_in_action_filter
{
    public class QubecCanadaOuputFilterAttribute : ActionFilterAttribute
    {
        public override async void OnResultExecuting(ResultExecutingContext context)
        {
            var response = context.HttpContext.Response;
            if (response.StatusCode != 200)
            {
                base.OnResultExecuting(context);
            }
            var result = context.Result as ObjectResult;
            var serializedResult = QuebecCanadaOutputSerializer.Instance.Serialize(result.Value);
            var resultBytes = Encoding.UTF8.GetBytes(serializedResult);
            response.Headers.Add("Content-Type", "application/xml");
            await response.Body.WriteAsync(resultBytes, 0, resultBytes.Length);
            base.OnResultExecuting(context);
        }
    }
}
