using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DropDown_MVC.Models;

namespace DropDown_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        // dropdowna yüklemek için modeli hazırlayalım!!

        var cars = new List<Car>{

            new Car(){ Id=1, Name="Audi"},
            new Car(){ Id=2, Name="Peugeot"},
            new Car(){ Id=3, Name="BMW"},
            new Car(){ Id=4, Name="Mercedes"},
            new Car(){ Id=5, Name="Toyota"},
            new Car(){ Id=6, Name="Skoda"},
            new Car(){ Id=7, Name="Fiat"},
            new Car(){ Id=8, Name="Bentley"},

        };

        return View(new DropDownViewModel() { Cars = cars });
    }

    [HttpPost]
    public IActionResult Index(DropDownViewModel model){

        // drop down dan seçilen değer seçildikten sonra submit'e basıldığında, view model action'a gelir ve içerisinde dropdowndan seçilen değer olacaktır!!

        
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
