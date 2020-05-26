using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections.Generic;

namespace OutputFormatter.API
{
    public class QuebecCanadaOuputFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var qubecCanadaOuputFormat = new QuebecCanadaOutputFormatter(new System.Xml.XmlWriterSettings()
            {
                OmitXmlDeclaration = false
            });
            var outputFormattersToRemove = new List<IOutputFormatter>()
            {
                new XmlSerializerOutputFormatter(),
                 new SystemTextJsonOutputFormatter(new System.Text.Json.JsonSerializerOptions()),
                new WashingtonOutputFormatter()
            };
            var commonFormatter = new FilterActionCommon();
            commonFormatter.ClearOutputFormatters(context, outputFormattersToRemove);
            commonFormatter.AddOutputFormatter(context, qubecCanadaOuputFormat);

        }
    }
}
