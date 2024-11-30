public class DropDownViewModel
{

    public int SelectedCityId { get; set; }
    public int SelectedDistrictId { get; set; }
    public int NeigborhoodId { get; set; }


    public List<City> Cities { get; set; }
    public List<District> Districts { get; set; }
    public List<Neigborhood> Neigborhoods { get; set; }
}

public class City
{

    public int Id { get; set; }
    public string Name { get; set; }
}
public class District
{
    public int Id { get; set; }

    public int CityId { get; set; }
    public string Name { get; set; }
}
public class Neigborhood
{

    public int Id { get; set; }

    public int DistrictId { get; set; }
    public string Name { get; set; }
}