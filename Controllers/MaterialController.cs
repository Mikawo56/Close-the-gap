using System;
using System.Threading.Tasks;
using Close_the_gap.Services;
using Microsoft.AspNetCore.Mvc;

namespace Close_the_gap.Controllers;

[ApiController]
[Route("[controller]")]
public class MaterialController : ControllerBase
{
    private readonly ICosmosDbService _cosmosDbService;
    public MaterialController(ICosmosDbService cosmosDbService)
    {
        _cosmosDbService = cosmosDbService;
    }

    [HttpGet]
    [ActionName("get/all")]
    public async Task<ActionResult> GetMaterialList()
    {
        var result =await  _cosmosDbService.GetMaterialListAsync();
        return Ok(result);
    }

    [HttpGet]
    [ActionName("get/report")]
    public async Task<ActionResult> GetDonorReport([FromQuery] string donor, [FromQuery] DateTime collectionDate)
    {
        var result = await _cosmosDbService.GetMaterialListPerDonorDateAsync(donor, collectionDate);
        return Ok(result);
    }
}