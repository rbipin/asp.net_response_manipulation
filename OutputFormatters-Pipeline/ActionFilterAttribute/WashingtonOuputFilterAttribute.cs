using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using OutputFormatter.API;
using System.Collections.Generic;
using System.Xml;

namespace OutputFormatter.API
{
    public class WashingtonOuputFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var washingtonOutputFormat = new WashingtonOutputFormatter(new XmlWriterSettings()
            {
                OmitXmlDeclaration = true
            });

            var outputFormattersToRemove = new List<IOutputFormatter>()
            {
                new XmlSerializerOutputFormatter(),
                new SystemTextJsonOutputFormatter(new System.Text.Json.JsonSerializerOptions()),
                new QubecCanadaOutputFormatter()
            };
            var commonFormatter = new OutputFormatterCommon();
            commonFormatter.ClearOutputFormatters(context, outputFormattersToRemove);
            commonFormatter.AddOutputFormatter(context, washingtonOutputFormat);
            base.OnActionExecuting(context);
        }
    }
}
