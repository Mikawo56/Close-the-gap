using System;
using System.Globalization;
using System.Threading.Tasks;
using Close_the_gap.Services;
using Microsoft.AspNetCore.Mvc;

namespace Close_the_gap.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaterialController : ControllerBase
{
    private readonly ICosmosDbService _cosmosDbService;
    public MaterialController(ICosmosDbService cosmosDbService)
    {
        _cosmosDbService = cosmosDbService;
    }

    [HttpGet]
    [Route("get/all")]
    public async Task<ActionResult> GetMaterialList()
    {
        var result =await  _cosmosDbService.GetMaterialListAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("get/report")]
    public async Task<ActionResult> GetDonorReport(string donor, string collectionDate)
    {
        var result = await _cosmosDbService.GetMaterialListPerDonorDateAsync(donor, collectionDate);
        return Ok(result);
    }
}