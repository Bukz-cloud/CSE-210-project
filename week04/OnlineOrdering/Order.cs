using System;
using System.Reflection.Emit;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public string GetPackingLabel()
    {
        string productLabel = "PACKING LABEL:\n";
        foreach (Product product in _products)
        {
            productLabel += $"{product.GetName()} (ID: {product.GetProductID()})\n";
        }
        return productLabel;
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL:\n:{_customer.GetName()}\n{_customer.GetAddress().GetFullAdress()}";
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.CalTotalCost();
        }
        total += _customer.IsInUSA() ? 5 : 35;

        return total;
    }
}