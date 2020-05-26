using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections.Generic;

namespace OutputFormatter.API
{
    public class QubecCanadaOuputFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var qubecCanadaOuputFormat = new QubecCanadaOutputFormatter(new System.Xml.XmlWriterSettings()
            {
                OmitXmlDeclaration = false
            });
            var outputFormattersToRemove = new List<IOutputFormatter>()
            {
                new XmlSerializerOutputFormatter(),
                 new SystemTextJsonOutputFormatter(new System.Text.Json.JsonSerializerOptions()),
                new WashingtonOutputFormatter()
            };
            var commonFormatter = new OutputFormatterCommon();
            commonFormatter.ClearOutputFormatters(context, outputFormattersToRemove);
            commonFormatter.AddOutputFormatter(context, qubecCanadaOuputFormat);

        }
    }
}
