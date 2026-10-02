using System;

class Program
{
    static void Main(string[] args)
    {
        Adress adress = new Adress();
        adress.SetStreet("Whatsigma street 800");
        adress.SetCity("SkibidiTown");
        adress.SetState("North Brainrot");
        adress.SetCountry("Mr Beast Land");

        Adress adress1 = new Adress();
        adress1.SetStreet("Times Square");
        adress1.SetCity("New York");
        adress1.SetState("New York");
        adress1.SetCountry("USA");

        Customer customer = new Customer();
        customer.SetCustomerName("Dave");
        customer.SetAdress(adress);

        Customer customer1 = new Customer();
        customer1.SetCustomerName("Jake");
        customer1.SetAdress(adress1);

        Product product = new Product();
        product.SetProductName("Book of Mormon");
        product.SetProductID(01);
        product.SetProductPrice(9.90);
        product.SetProductQuantity(1);

        Product product1 = new Product();
        product1.SetProductName("Root Beer");
        product1.SetProductID(02);
        product1.SetProductPrice(8.90);
        product1.SetProductQuantity(6);

        List<Product> productList = new List<Product>();
        productList.Add(product);
        productList.Add(product1);

        Order order = new Order();
        order.SetCustomer(customer);
        order.SetProductList(productList);
        order.PackingLabel();
        order.ShippingLabel();
        order.TotalPrice();

        Order order1 = new Order();
        order1.SetCustomer(customer);
        order1.SetProductList(productList);
        order1.PackingLabel();
        order1.ShippingLabel();
        order1.TotalPrice();

        Order order2 = new Order();
        order2.SetCustomer(customer1);
        order2.SetProductList(productList);
        order2.PackingLabel();
        order2.ShippingLabel();
        order2.TotalPrice();

        
        //create 3 orders that call packinglabel, shippinglabel and totalprice
    }
}