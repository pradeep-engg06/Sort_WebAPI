using API.Service;
using API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SortController : ControllerBase
    {
        private readonly ISortService WithoutInbuildFunctionService;
        private readonly ISortService WithInbuildFunctionService;
        private readonly ISortService CustomSortService;
        public SortController(ServiceResolver serviceResolver)
        {
            this.WithoutInbuildFunctionService = serviceResolver("WithoutInbuildFunction");
            this.WithInbuildFunctionService = serviceResolver("WithInbuildFunction");
           


        }
        [HttpPost("sorting")]
        public IActionResult SortingData([FromBody] SortRequestModel sortRequestModel )
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            Stopwatch _st = new Stopwatch();
            _st.Start();
            var Result = WithoutInbuildFunctionService.Sorting(sortRequestModel.sortdata);
            _st.Stop();
            stringBuilder.Append("Without Inbuild Array Sort Function: "+ _st.ElapsedMilliseconds + Environment.NewLine+ String.Join(",", Result)+Environment.NewLine);
            _st.Restart();
           var Result1 = WithInbuildFunctionService.Sorting(sortRequestModel.sortdata);
            _st.Stop();
            stringBuilder.Append("With Inbuild Array Sort Function: " + _st.ElapsedMilliseconds + Environment.NewLine + String.Join(",", Result1));
            _st.Restart();
            return File(System.Text.Encoding.UTF8.GetBytes(stringBuilder.ToString()), "text/plain", "Result.txt");
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> ReadFile(IFormFile file)
        {
            StringBuilder result = new StringBuilder();
            // check the MIME type and file extention.
            if (!file.FileName.Contains(".txt") && !file.ContentType.Contains("text/plain")) {
                return BadRequest(file);
            }

            using (var read = new System.IO.StreamReader(file.OpenReadStream())) {
                while (read.Peek() >= 0)
                    result.AppendLine(await read.ReadLineAsync());
            }

            return Ok(result);
        }
    }
}
