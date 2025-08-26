using Microsoft.AspNetCore.Mvc;

namespace Gridify_In_DotNet.Controllers;
public class GridifyController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
