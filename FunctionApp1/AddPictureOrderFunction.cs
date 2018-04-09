
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace FunctionApp1
{
    public static class AddPictureOrderFunction
    {
        [FunctionName("AddPictureFunction")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "AddPictureOrder")]HttpRequest req, TraceWriter log, [Table("PictureFormDB", Connection = "StorageConnection")]ICollector<PictureForm> formTable)
            
        {
            log.Info("C# HTTP trigger function processed a request.");
            

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            PictureForm data =  JsonConvert.DeserializeObject<PictureForm>(requestBody);
            data.PartitionKey = DateTime.UtcNow.DayOfYear.ToString();
            data.RowKey = data.FileName;

            formTable.Add(data);

            return data != null
                ? (ActionResult)new OkObjectResult($"Hello, {"OK"}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
