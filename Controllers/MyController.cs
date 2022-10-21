using Microsoft.AspNetCore.Mvc;

namespace SimpleCSApi.Controllers;

[ApiController]
public class MyController : ControllerBase
{
    [Route("/")]
    [HttpGet]
    public string Get()
    {
        return "Hello, World!";
    }
}