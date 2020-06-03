using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace DBServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok("Сервер запущен");
        }

        // GET: api/Company
        [HttpGet("company")]
        public ActionResult<CompanyDetails> GetCompanyDetails()
        {
            try
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "companyDetails.json");
                string json = System.IO.File.ReadAllText(filePath, Encoding.UTF8);

                CompanyDetails company = JsonConvert.DeserializeObject<CompanyDetails>(json);

                return company;
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось получить реквизиты компании | {ex.Message}");
            }
        }

        // POST: api/Company
        [HttpPost("company")]
        public ActionResult SetCompanyDetails(CompanyDetails companyDetails)
        {
            try
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "companyDetails.json");
                string json = JsonConvert.SerializeObject(companyDetails, Formatting.Indented);

                System.IO.File.WriteAllText(filePath, json, Encoding.UTF8);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}