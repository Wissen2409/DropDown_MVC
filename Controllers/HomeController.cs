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

        return View(new DropDownModel() { Cars = cars });
    }

    [HttpPost]
    public IActionResult Index(DropDownViewModel model)
    {

        // drop down dan seçilen değer seçildikten sonra submit'e basıldığında, view model action'a gelir ve içerisinde dropdowndan seçilen değer olacaktır!!



        return View();
    }

    public IActionResult GetCities()
    {
        var returnValue = MakeCities();
        return View("Cities", returnValue);

    }

    [HttpPost]
    public IActionResult GetCities(DropDownViewModel model)
    {


        if (model.SelectedCityId != 0)
        {
            var returnModel = MakeCities();
            returnModel.SelectedCityId = model.SelectedCityId;
            returnModel.Districts = returnModel.Districts.Where(s => s.CityId == model.SelectedCityId).ToList();
            return View("Cities", returnModel);

        }
        else if(model.SelectedDistrictId!=0){

            var returnModel = MakeCities();

            // burada sorun semtleri dönerken city'id değerinin olmamasından kaynaklı!!


            // distict id değerinden city id bulmalıyım!!

            int selectedCityId=MakeCities().Districts.Where(s=>s.Id==model.SelectedDistrictId).SingleOrDefault().CityId;

            returnModel.SelectedCityId =selectedCityId;
            returnModel.SelectedDistrictId=model.SelectedDistrictId;
            returnModel.Neigborhoods = returnModel.Neigborhoods.Where(s => s.DistrictId == model.SelectedDistrictId).ToList();
            return View("Cities", returnModel);

        }
        return View("Cities");

    }
    public DropDownViewModel MakeCities()
    {
        return new DropDownViewModel()
        {
            Cities = new List<City>(){

                new City { Id=1, Name = "İstanbul"},
                 new City { Id=2, Name = "Ankara"},
                  new City { Id=3, Name = "İzmir"}
             },
            Districts = new List<District>(){

                new District { Id=1, CityId=1, Name="Beşiktaş"},
                new District { Id=2, CityId=1, Name="Kadıköy"},
                new District { Id=3, CityId=2, Name="Bala"},
                new District { Id=4, CityId=3, Name="Karşıyaka"},
            },
            Neigborhoods = new List<Neigborhood>(){

                new Neigborhood{ Id=1, DistrictId=1, Name="Akaretler"},
                new Neigborhood{ Id=2, DistrictId=1, Name="Etiler"},
                new Neigborhood{ Id=3, DistrictId=2, Name="Bahariye"},
                new Neigborhood{ Id=4, DistrictId=3, Name="Fevzi Çakmak Mahallesi"},
                new Neigborhood{ Id=5, DistrictId=4, Name="Kordon"},
            }

        };
    }
}
