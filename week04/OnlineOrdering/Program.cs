using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("12 Lake View", "Chicago", "IL", "USA");
        Customer customer1 = new Customer("John Adams", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Keyboard", "K123", 45, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25, 2));

        Address address2 = new Address("22 Olive Street", "Nairobi", "Nairobi", "Kenya");
        Customer customer2 = new Customer("Samantha King", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Laptop Bag", "B789", 30, 1));
        order2.AddProduct(new Product("USB Cable", "U247", 10, 3));

        PrintOrder(order1);
        Console.WriteLine();
        PrintOrder(order2);
    }

    static void PrintOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"TOTAL COST: ${order.GetTotalCost()}\n");
    }
}