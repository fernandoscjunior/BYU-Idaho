class Order
{
    public Order()
    {
    }

    private Customer _customer;
    List<Product> _products = new List<Product>();

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    public void SetProductList(List<Product> product)
    {
        _products = product;
    }

    public int GetShippingCost()
    {
        bool home = _customer.UsaOrNotUsa();


        if (home == true)
        {
            int shippingCost = 5;
            return shippingCost;
        }
        else if (home == false)
        {
            int shippingCost = 35;
            return shippingCost;
        }
        else
        {
            int test = 1;
            return test;
        }
    }
    public void TotalPrice()
    {
        double productPrice = _products[0].GetProductPrice();
        double productPrice2 = _products[1].GetProductPrice();
        double productQuantity = _products[0].GetProductQuantity();
        double productQuantity2 = _products[1].GetProductQuantity();
        double total = productPrice + productPrice2 * productQuantity * productQuantity2;

        int ship = GetShippingCost();

        double totalPrice = total + ship;

        Console.WriteLine("Total price: $" + totalPrice.ToString("F2"));

    }

    public void PackingLabel()
    {
        foreach (Product product in _products)
        {
            Console.WriteLine("Product name: " + product.GetProductName());
            Console.WriteLine("Product ID: " + product.GetProductID());
        }
    }

    public void ShippingLabel()
    {
        Console.WriteLine("Buyer: " + _customer.GetCustomerName());
        Console.WriteLine("Adress: " + _customer.GetAdress());
    }    
}