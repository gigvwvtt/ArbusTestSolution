namespace ArbusTest;

public class Item
{
    public string Name;

    public Category Category;

    public decimal Price;

    public Item(string name,  decimal price, Category category = Category.None)
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
    Alcohol,
    None
}