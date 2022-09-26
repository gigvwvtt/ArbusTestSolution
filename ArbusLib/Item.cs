using System.ComponentModel.DataAnnotations;

namespace ArbusTest;

public class Item
{
    public string Name;

    public Category Category;

    public decimal Price;

    public Item(string name, Category category, decimal price)
    {
        Name = name;
        Category = category;
        Price = price;
    }
}

public enum Category
{
    HotDrink,
    ColdDrink,
    Iceсream,
    Alcohol
}