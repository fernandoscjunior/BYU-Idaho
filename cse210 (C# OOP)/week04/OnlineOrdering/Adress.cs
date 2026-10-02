class Adress
{
    public Adress()
    {

    }
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public string GetStreet()
    {
        return _street;
    }

    public void SetStreet(string street)
    {
        _street = street;
    }

    public string GetCity()
    {
        return _city;
    }

    public void SetCity(string city)
    {
        _city = city;
    }

    public string GetState()
    {
        return _state;
    }

    public void SetState(string state)
    {
        _state = state;
    }

    public string GetCountry()
    {
        return _country;
    }
    public void SetCountry(string country)
    {
        _country = country;
    }
    
    public string CompleteAdress()
    {
        string completeAdress = ($"{_street}, {_city}, {_state}, {_country}.");
        return completeAdress;
    }

    public bool IsItUsa()
    {
        
        if (_country == "USA")
        {
            return true;
        }
        else if (_country == "United States")
        {
            return true;
        }
        else if (_country == "US")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}