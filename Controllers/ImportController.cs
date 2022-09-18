using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using csvtestapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace csvtestapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ImportCsv(IFormFile file)
        {
            //var path = Path.GetTempPath();
            try
            {
                // var file = Request.Form.Files[0];
                //var contenType = file.ContentType;
                if (file.ContentType.ToString() != "text/csv")
                {
                    return Ok("invalie file format. Please upload only csv file.");
                }
                var folderName = Path.Combine("Resources", "Files");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {

                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }


        }

        [HttpGet]
        public IActionResult ReadData()
        {
            try
            {
                var olist = new List<Data>();
                var folderName = Path.Combine("Resources", "Files");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fullPath = Path.Combine(pathToSave, "convertcsv.csv");

                using (var reader = new StreamReader(fullPath))
                {
                    var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ",",
                        Comment = '%'
                    };
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<DataMap>();
                        var records = csv.GetRecords<Data>();
                        olist = records.ToList();

                    }
                    return Ok(olist);
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}