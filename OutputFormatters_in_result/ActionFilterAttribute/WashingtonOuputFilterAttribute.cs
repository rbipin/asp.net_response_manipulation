using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OutputFormatter.API.OutputFormatter;
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
            result.Formatters.Add(new WashingtonOutputFormatter());
            base.OnResultExecuting(context);
        }
    }
}
