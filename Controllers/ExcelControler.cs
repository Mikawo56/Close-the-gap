using Close_the_gap.Model;
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

        private string GetStringValue(IExcelDataReader reader, CTGCircularColumn column)
        {
            var value = reader.GetValue(CTGCircularColumn.AssetTag.GetInt());
            if(value == null)
            {
                return "";
            }
            else
            {
                return value.ToString();
            }
        }

        [HttpPost]
        [ActionName("Import")]
        public async Task<ActionResult> ImportAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            var materialList = new List<Material>();
            try
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
                        var iRow = 0;
                      
                        while (reader.Read())
                        {
                            if(iRow == 0 || iRow == 1 || iRow == 2)
                            {
                                iRow++;
                                continue;
                            }
                            var material = new Material()
                            {
                                Id = Guid.NewGuid(),
                                AssetTag = GetStringValue(reader, CTGCircularColumn.AssetTag),
                                Brand = GetStringValue(reader, CTGCircularColumn.Brand),
                                Model = GetStringValue(reader, CTGCircularColumn.Model),
                                Type = GetStringValue(reader, CTGCircularColumn.Type),
                                SerialNumber = GetStringValue(reader, CTGCircularColumn.SerialNumber),
                            };
                            materialList.Add(material);
                            iRow++;
                        };
                        // The result of each spreadsheet is in result.Tables
                    }
                }
            }catch(Exception e)
            {
                ;
            }
            

            return Ok(materialList);
        }

    }
}
