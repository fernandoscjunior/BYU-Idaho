class Customer
{
    public Customer()
    {
    }
    private string _name;
    private Adress _adress;

    public string GetCustomerName()
    {
        return _name;
    }

    public void SetCustomerName(string name)
    {
        _name = name;
    }

    public string GetAdress()
    {
        string street = _adress.GetStreet();
        string city = _adress.GetCity();
        string state = _adress.GetState();
        string country = _adress.GetCountry();
        string adress = $"{street}, {city}, {state}, {country}";

        return adress;
    }

    public void SetAdress(Adress adress)
    {
        _adress = adress;
    }

    public bool UsaOrNotUsa()
    {
        
        bool isUs = _adress.IsItUsa();
        return isUs;
    }
}