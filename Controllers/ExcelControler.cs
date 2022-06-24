using Close_the_gap.Services;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Close_the_gap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExcelController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;
        public ExcelController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpPost]
        [ActionName("Import")]
        public async Task<ActionResult> ImportAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                using (var reader = ExcelReaderFactory.CreateReader(ms))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet();

                    // The result of each spreadsheet is in result.Tables
                }
            }

            return Ok();
        }

    }
}
