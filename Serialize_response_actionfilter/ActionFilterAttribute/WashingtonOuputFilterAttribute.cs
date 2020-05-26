using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using OutputFormatter.API;
using System.Collections.Generic;
using System.Xml;

namespace OutputFormatter.API
{
    public class WashingtonOuputFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {       
            base.OnResultExecuting(context);
        }
    }
}
