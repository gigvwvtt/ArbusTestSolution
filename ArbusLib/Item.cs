using System.ComponentModel.DataAnnotations;

namespace ArbusTest;

public class Item : IValidatable
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

    public void Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new List<ValidationResult>();

        if (string.IsNullOrWhiteSpace(Name))
            throw new Exception("Не указано название блюда");
        if (Name.Length is < 2 or > 50)
            throw new Exception("Некорректное имя блюда");
        if (Category == default)
            throw new Exception("Не указана категория блюда");
        if (Price < 0)
            throw new Exception("Значение цены ниже нуля");
    }
}

public enum Category
{
    HotDrink,
    ColdDrink,
    Iceсream,
    Alcohol
}