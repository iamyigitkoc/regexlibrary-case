using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/regex/")]
    public class RegexLibrariesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<RegexLibrary> GetRegexLibraries() {
            return new List<RegexLibrary> {
                new RegexLibrary{ Id=1, Name="Test 1", Pattern="testtest"},
                new RegexLibrary{ Id=2, Name="Test 2", Pattern="testsetse"}
            };
        }
    }
}
