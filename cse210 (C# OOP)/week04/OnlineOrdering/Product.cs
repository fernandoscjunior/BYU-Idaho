class Product
{
    public Product()
    {

    }

    private string _productName;
    private int _productID;
    private double _price;
    private int _quantity;

    public string GetProductName()
    {
        return _productName;
    }

    public void SetProductName(string name)
    {
        _productName = name;
    }

    public int GetProductID()
    {
        return _productID;
    }

    public void SetProductID(int id)
    {
        _productID = id;
    }

    public double GetProductPrice()
    {
        return _price;
    }

    public void SetProductPrice(double price)
    {
        _price = price;
    }    

    public int GetProductQuantity()
    {
        return _quantity;
    }

    public void SetProductQuantity(int quantity)
    {
        _quantity = quantity;
    }

    public double TotalCost()
    {
        double cost = _price * _quantity;
        return cost;
    }
}