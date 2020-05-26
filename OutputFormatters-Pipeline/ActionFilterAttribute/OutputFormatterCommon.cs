using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace OutputFormatter.API
{
    public sealed class OutputFormatterCommon
    {

        /// <summary>
        /// Clear the existing output formatter
        /// </summary>
        /// <param name="context">action context</param>
        /// <param name="outputFormatter">Output formatter to add</param>
        public void AddOutputFormatter(ActionExecutingContext context, IOutputFormatter outputFormatter)
        {
            var options = context
        .HttpContext
        .RequestServices
        .GetService(serviceType: typeof(IOptions<MvcOptions>)) as IOptions<MvcOptions>;
            var mvcOptions = options.Value;

            mvcOptions.OutputFormatters.Add(outputFormatter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="outputFormatters"></param>
        public void ClearOutputFormatters(ActionExecutingContext context, List<IOutputFormatter> outputFormatters)
        {

            var options = context
         .HttpContext
         .RequestServices
         .GetService(serviceType: typeof(IOptions<MvcOptions>)) as IOptions<MvcOptions>;
            var mvcOptions = options.Value;

            foreach (var outputFormatter in outputFormatters)
            {
                mvcOptions.OutputFormatters.RemoveType(outputFormatter.GetType());
            }
        }
    }
}
