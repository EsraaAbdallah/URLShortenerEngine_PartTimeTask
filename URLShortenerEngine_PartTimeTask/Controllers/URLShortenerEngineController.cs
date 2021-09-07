using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShortenerEngine_PartTimeTask.Model;

namespace URLShortenerEngine_PartTimeTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class URLShortenerEngineController : ControllerBase
    {
        private readonly IService service;
        public URLShortenerEngineController(IService _service)
        {
            service = _service;
        }
        [HttpGet]
        [Route("GetAllURL")]
        public IActionResult GetAllURL()
        {
            try
            {
                var result = service.GetAllURL();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] ShortenURL ShortenURL)
        {
            try
            {
                Uri uriResult;
                bool result = Uri.TryCreate(ShortenURL.url, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (result)
                {
                    var checkurl = service.IsURLExist(ShortenURL.url);
                    if (string.IsNullOrEmpty(checkurl))
                    {
                        var slug = service.AddURL(ShortenURL.url);
                        return Ok(true);
                    }
                    else
                    {
                        return Ok(true);
                    }

                }
                else
                {
                    return StatusCode(400, "invalid url");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}