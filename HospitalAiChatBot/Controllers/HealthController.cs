﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace OpenAPIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var response = new JsonObject
            {
                ["status"] = "ok",
                ["timestamp"] = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
            };

            return Ok(response);
        }
    }
}
