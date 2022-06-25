using Close_the_gap.Model;
using Close_the_gap.Services;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var value = reader.GetValue(column.GetInt());
            if(value == null)
            {
                return "";
            }
            else
            {
                return value.ToString().Trim().ToLower();
            }
        }

       

        [HttpPost]
        [ActionName("ImportCTG")]
        public async Task<ActionResult> ImportCTGAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            var materialList = new List<Material>();
            try
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    using (var reader = ExcelReaderFactory.CreateReader(ms))
                    {
                        // 2. Use the AsDataSet extension method
                        var result = reader.AsDataSet();
                        var iRow = 0;
                        var donor = "";
                        var date = new DateTime();
                        while (reader.Read())
                        {
                            if(iRow == 0)
                            {
                                donor = reader.GetValue(5).ToString();
                            }
                            if(iRow == 1)
                            {
                                date = DateTime.ParseExact(reader.GetValue(4).ToString(),"dd/mm/yyyy",CultureInfo.InvariantCulture);
                            }
                            if (iRow == 0 || iRow == 1 || iRow == 2)
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
                                //Type = GetStringValue(reader, CTGCircularColumn.Type),
                                SerialNumber = GetStringValue(reader, CTGCircularColumn.SerialNumber),
                                Grade = GetStringValue(reader, CTGCircularColumn.CustomGrade),
                                Donor = donor,
                                CollectionDate = date,
                            };
                           
                            material.Defects = new List<string>();
                            if(GetStringValue(reader, CTGCircularColumn.CustomDefects) != "")
                            {
                                var defects = GetStringValue(reader, CTGCircularColumn.CustomDefects).Split("/");
                                foreach (var item in defects)
                                {
                                    material.Defects.Add(item);
                                }
                            }

                            if(GetStringValue(reader, CTGCircularColumn.Type) == "pc" || GetStringValue(reader, CTGCircularColumn.Type) == "tablet" || GetStringValue(reader, CTGCircularColumn.Type) == "notebook" || GetStringValue(reader, CTGCircularColumn.Type) == "mobile phone")
                            {
                                material.Components = new Dictionary<string, string>();
                                var components = GetStringValue(reader, CTGCircularColumn.CustomSpecifications).Split(",");
                                foreach (var item in components)
                                {
                                    if (item.Contains("GB"))
                                    {
                                        material.Components.Add("memory", item);
                                    }
                                    if (item.Contains("GHZ"))
                                    {
                                        var value = "";
                                        if (material.Components.TryGetValue("cpu", out value))
                                        {
                                            material.Components["cpu"] = value + " " + item;
                                        }
                                        else
                                        {
                                            material.Components.Add("cpu", item);
                                        }
                                    }
                                    
                                    if (item.Contains("core"))
                                    {
                                        var value = "";
                                        if (material.Components.TryGetValue("cpu", out value))
                                        {
                                            material.Components["cpu"] = item + " " + value;
                                        }
                                        else
                                        {
                                            material.Components.Add("cpu", item);
                                        }
                                    }
                                    if (item.Contains("MB"))
                                    {
                                        material.Components.Add("ram", item);
                                    }

                                }
                            }
                            material.ReconditionerData = new Dictionary<string, string>();
                            material.ReconditionerData.Add("load number", GetStringValue(reader, CTGCircularColumn.ReconditionnerLoadNumber));
                            material.ReconditionerData.Add("tracking reference", GetStringValue(reader, CTGCircularColumn.ReconditionnerTrackingReference));
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

            await _cosmosDbService.AddBulkMaterialListAsync(materialList);
            return Ok(materialList);
        }

        private string GetStringValueTES(IExcelDataReader reader, TESCircularColumn column)
        {
            var valueTES = reader.GetValue(column.GetInt());
            if (valueTES == null)
            {
                return "";
            }
            else
            {
                return valueTES.ToString().Trim().ToLower();
            }
        }

        private string GetStringTypeTES(IExcelDataReader reader, TESCircularColumn column)
        {
           var valueTES = reader.GetValue(column.GetInt());
           if (valueTES == null)
            {
                return "";
            }
            else
            {
                return valueTES.ToString().Trim().ToLower();
            }
        }

        [HttpPost]
        [ActionName("ImportTES")]
        public async Task<ActionResult> ImportTESAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            var materialList = new List<Material>();
            try
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    using (var reader = ExcelReaderFactory.CreateReader(ms))
                    {
                        var result = reader.AsDataSet();
                        var iRow = 0;
                        var donnor = "";
                        var date = new DateTime();
                        while (reader.Read())
                        {
                            if (iRow == 2)
                            {
                                donnor = reader.GetValue(1).ToString();
                            }
                            if (iRow == 9)
                            {
                                date = DateTime.ParseExact(reader.GetValue(4).ToString(), "dd/mm/yyyy", CultureInfo.InvariantCulture);
                            }
                            if (iRow == 0 || iRow == 1 || iRow == 3 || iRow == 4 || iRow == 5 || iRow == 6 || iRow == 7 || iRow == 8 || iRow == 10 || iRow == 11 || iRow == 12 || iRow == 13 || iRow == 14 || iRow == 15 || iRow == 16 || iRow == 17)
                            {

                                iRow++;
                                continue;
                            }
                            var material = new Material()
                            {
                                Id = Guid.NewGuid(),
                                AssetTag = GetStringValueTES(reader, TESCircularColumn.AssetTag),
                                Brand = GetStringValueTES(reader, TESCircularColumn.Manufacturer),
                                Model = GetStringValueTES(reader, TESCircularColumn.Model),
                                Type = (MaterialType)MaterialTypeMethods.GetMaterialEnum(GetStringValueTES(reader, TESCircularColumn.StockType)),
                                //Type = GetStringValueTES(reader, TESCircularColumn.StockType).,
                                SerialNumber = GetStringValueTES(reader, TESCircularColumn.SerialNumber),
                                Grade = GetStringValueTES(reader, TESCircularColumn.ConditionCode),
                                Donnor = donnor,
                                CollectionDate = date,
                            };

                            material.Defects = new List<string>();
                            string str = GetStringValueTES(reader, TESCircularColumn.StockComments);
                            str = string.Join("", str.Split('-'));
                            if (str != "")
                            {
                                var defects = GetStringValueTES(reader, TESCircularColumn.StockComments).Split("/");
                                foreach (var item in defects)
                                {
                                    material.Defects.Add(item);
                                }
                            }

                            if (GetStringValue(reader, CTGCircularColumn.Type) == "pc" || GetStringValue(reader, CTGCircularColumn.Type) == "tablet" || GetStringValue(reader, CTGCircularColumn.Type) == "notebook" || GetStringValue(reader, CTGCircularColumn.Type) == "mobile phone")
                            {
                                material.Components = new Dictionary<string, string>();
                                material.Components.Add("cpu", GetStringValueTES(reader, TESCircularColumn.Processor));
                                material.Components.Add("memory", GetStringValueTES(reader, TESCircularColumn.HDD) + "GB");
                                material.Components.Add("cd-rom", GetStringValueTES(reader, TESCircularColumn.CDROM));
                                material.Components.Add("weigth", GetStringValueTES(reader, TESCircularColumn.Weight));
                                material.Components.Add("processing fee", GetStringValueTES(reader, TESCircularColumn.ProcessingFee) + " "+" USD");
                                if (GetStringValueTES(reader, TESCircularColumn.Memory) != "-")
                                {
                                    if(GetStringValueTES(reader, TESCircularColumn.Memory).Contains("G")){
                                        material.Components.Add("ram", GetStringValueTES(reader, TESCircularColumn.Memory));
                                    }
                                    else
                                    {
                                        material.Components.Add("ram", GetStringValueTES(reader, TESCircularColumn.Memory) + "MB");
                                    }                                  
                                }

                                if (GetStringValueTES(reader, TESCircularColumn.ScreenSize) != "-")
                                {                                   
                                        material.Components.Add("screen size", GetStringValueTES(reader, TESCircularColumn.ScreenSize));   
                                }
                                else
                                {
                                    material.Components.Add("screen size", "");
                                }
                                if (GetStringValueTES(reader, TESCircularColumn.DiskStatus) != "-")
                                {
                                    material.Components.Add("disk status", GetStringValueTES(reader, TESCircularColumn.DiskStatus));
                                }
                                else
                                {
                                    material.Components.Add("disk status", "");
                                }

                                if (GetStringValueTES(reader, TESCircularColumn.ParentIdOfHDD) != "-")
                                {
                                    material.Components.Add("parent id of hdd", GetStringValueTES(reader, TESCircularColumn.ParentIdOfHDD) +"XH");
                                }
                                else
                                {
                                    material.Components.Add("parent id of hdd", "");
                                }

                            }
                            material.ReconditionnerData = new Dictionary<string, string>();
                            material.ReconditionnerData.Add("book number", GetStringValueTES(reader, TESCircularColumn.ReconditionnerBookNumber));          
                            materialList.Add(material);
                            iRow++;
                        };
                        // The result of each spreadsheet is in result.Tables
                    }
                }
            }
            catch (Exception e)
            {
                ;
            }

            await _cosmosDbService.AddBulkMaterialListAsync(materialList);
            return Ok(materialList);
        }

    }
}
