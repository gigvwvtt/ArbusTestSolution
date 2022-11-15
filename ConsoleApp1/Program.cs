using ArbusTest;

var onPage = 2;
var items = new List<Item>
{
    new Item("Матча", 2, Category.Alcohol),
    new Item("Латте", 80, Category.HotDrink),
    new Item("Смузи", 90, Category.ColdDrink),
    new Item("Джин", 150, Category.Alcohol),
    new Item("Эскимо", 40, Category.Iceсream)
};


var master = new MenuMaster(items, onPage);

Console.WriteLine("ItemsAmount " + master.GetItemsAmount());
Console.WriteLine("TotalPages " + master.GetTotalPages());
Console.WriteLine("ItemsCountFromPage " + master.GetItemsCountFromPage(1));
Console.WriteLine("ItemsFromPage " + string.Join(", ", master.GetItemsFromPage(1)));
Console.WriteLine("FirstItemsFromPages " + string.Join(", ", master.GetFirstItemsFromPages()));

Console.ReadKey();