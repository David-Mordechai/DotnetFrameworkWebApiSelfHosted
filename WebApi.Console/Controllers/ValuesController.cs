using System.Collections.Generic;
using System.Web.Http;
using Serilog;
using WebApi.Console.Services;

namespace WebApi.Console.Controllers;

public class ValuesController : ApiController
{
    private readonly ILogger _logger;
    private readonly IMyService _myService;

    public ValuesController(ILogger logger, IMyService  myService)
    {
        _logger = logger;
        _myService = myService;
    }
    // GET api/values 
    public IEnumerable<string> Get()
    {
        return new[] { "value1", "value2" };
    }

    // GET api/values/5 
    public string Get(int id)
    {
        _logger.Information("Log from Get by Id");
        return _myService.GetValue();
    }

    // POST api/values 
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5 
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5 
    public void Delete(int id)
    {
    }
}